using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Video_Integrity_Checker
{
    public partial class Form1 : Form
    {
        private Timer timer = new Timer();
        private List<Ops.VideoCheckAgent> agents = new List<Ops.VideoCheckAgent>();
        private IEnumerator<string> fileEnumarator = null;
        private bool endOfFileEnum = false;
        private StreamWriter logWriter;

        private int total = 0, okno = 0;

        public Form1()
        {
            InitializeComponent();

            chkMoveOkFiles.Checked = true;
            chkMoveOkFiles.Checked = false;

            //  chkMoveOkFiles.En

            timer.Tick += Timer_Tick;
            timer.Interval = 100;
            //agents.Add(new Ops.VideoCheckAgent());
            //agents.Add(new Ops.VideoCheckAgent());

        }

        private void Timer_Tick(object sender, EventArgs e)
        {

            if (fileEnumarator != null)
            {
                var idle = agents.Where(x => !x.IsActive).ToList();
                idle.ForEach(x =>
                {
                    if (x.NonFormat.HasValue && x.NonFormat.Value)
                    {
                        total += 1;
                        //logWriter.WriteLine("")
                    }
                    else if (x.OK.HasValue && x.OK.Value)
                    {
                        total += 1;
                        okno += 1;
                        logWriter.WriteLine($"OK,\"{x.Input.Path}\",\"{x.Input.MoveOkPath ?? string.Empty}\"");
                    }
                    else if (x.OK.HasValue && !x.OK.Value)
                    {
                        total += 1;
                        logWriter.WriteLine($"FAIL,\"{x.Input.Path}\",\"{string.Empty}\"");
                    }

                    x.OK = null;
                    x.NonFormat = null;

                });

                lblOkFiles.Text = okno.ToString();
                lblTotal.Text = total.ToString();

                if (endOfFileEnum)
                {
                    if(idle.Count == agents.Count)
                    {
                        timer.Stop();
                        lblActivity.Text = "Idle";
                        logWriter.Close();
                        logWriter.Dispose();
                        logWriter = null;
                    }
                }
                else
                {
                    lblActivity.Text = $"Active {DateTime.Now}";
                }


                for (int i = 0; i < idle.Count; i++)
                {
                    if(fileEnumarator.MoveNext())
                    {
                        idle[i].Begin(new Ops.AgentInput()
                        {
                            FFMPEG = txtFF.Text,
                            Formats = txtFileTypes.Text.Split(','),
                            MoveOk = chkMoveOkFiles.Checked,
                            MoveOkPath = txtOkFilesMove.Text,
                            Path = fileEnumarator.Current,
                            SrcPath = txtSrc.Text
                        });
                    }
                    else
                    {
                        endOfFileEnum = true;
                        break;
                    }
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            txtFF.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ffmpeg.exe");
            if (!File.Exists(txtFF.Text))
            {
                MessageBox.Show(this, "FFMPEG.exe not found");
            }
        }

        private void btnBrowseSrc_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog()
            {
                ShowNewFolderButton = false
            };
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtSrc.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnBrowseOKFiles_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog()
            {
                ShowNewFolderButton = true
            };
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtOkFilesMove.Text = folderBrowserDialog.SelectedPath;
            }

        }

        private void btnBrowseFFMPEG_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                FileName = "ffmpeg.exe",
                Filter = "FFMPEG|ffmpeg.exe"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFF.Text = openFileDialog.FileName;
            }
        }

        private void chkMoveOkFiles_CheckedChanged(object sender, EventArgs e)
        {

            txtOkFilesMove.Enabled = chkMoveOkFiles.Checked;
            btnBrowseOKFiles.Enabled = chkMoveOkFiles.Checked;

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (fileEnumarator != null) fileEnumarator.Dispose();
            }
            catch (Exception) { }

            try
            {
                if (logWriter != null)
                {
                    logWriter.Close();
                    logWriter.Dispose();
                }
            }
            catch (Exception) { }

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            agents.Clear();
            for (int i = 0; i < nudThreads.Value; i++)
            {
                agents.Add(new Ops.VideoCheckAgent());
            }


            logWriter?.Close();
            logWriter = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"RUN_{DateTime.Now:yyyyMMddHHmmss}.csv"));
            logWriter.AutoFlush = true;
            logWriter.WriteLine("STATUS,SRC,DST");

            var direnumerator = Directory.EnumerateFiles(txtSrc.Text, "*.*", SearchOption.AllDirectories);
            fileEnumarator = direnumerator.GetEnumerator();
            total = 0;
            okno = 0;
            endOfFileEnum = false;
            timer.Start();
        }
    }
}
