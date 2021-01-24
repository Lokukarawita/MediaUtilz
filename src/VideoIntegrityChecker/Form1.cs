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
using Video_Integrity_Checker.Ops;

namespace Video_Integrity_Checker
{
    public partial class Form1 : Form
    {
        private Timer timer = new Timer();
        private List<Ops.VideoCheckAgent> agents = new List<Ops.VideoCheckAgent>();
        private IEnumerator<string> fileEnumarator = null;
        private bool endOfFileEnum = false;
        private StreamWriter logWriter;

        private bool isCountingFiles = false;
        private int processedTotal = 0, okno = 0, foundTotal;
        private DateTime processStartedOn;
        private System.Threading.CancellationTokenSource cancellationTokenSource;
        private System.Threading.CancellationToken cancellationToken;

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
            processedTotal = 0;
            okno = 0;
            endOfFileEnum = false;

            lblETA.Text = "";
            processStartedOn = DateTime.Now;
            btnCancel.Enabled = true;
            cancellationTokenSource = new System.Threading.CancellationTokenSource();
            cancellationToken = cancellationTokenSource.Token;

            CountFiles();
            timer.Start();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancellationTokenSource.Cancel();
            btnCancel.Enabled = false;
        }

        private void CountFiles()
        {
            isCountingFiles = true;
            foundTotal = 0;

            var src = txtSrc.Text;
            var formats = txtFileTypes.Text.Split(',');

            Task.Factory.StartNew(() =>
            {
                foreach (var item in Directory.EnumerateFiles(src, "*.*", SearchOption.AllDirectories))
                {
                    var validFormat = item?.IsValidFormat(formats) ?? false;
                    if (validFormat)
                    {
                        System.Threading.Interlocked.Increment(ref foundTotal);
                    }

                }
            }, cancellationToken)
                .ContinueWith((ob) =>
                {
                    isCountingFiles = false;
                });
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var foundLocal = System.Threading.Thread.VolatileRead(ref foundTotal);
            lblTotalFound.Text = foundLocal.ToString();

            if (isCountingFiles)
            {
                lblActivity.Text = $"Searching... {DateTime.Now}";
                return;
            }
            else
            {
                var elapsedTimeTS = (DateTime.Now - processStartedOn);
                var elapsedTime = elapsedTimeTS.TotalSeconds;
                var remainingitems = foundTotal - processedTotal;
                var perItemTime = processedTotal / elapsedTime;
                var totalItemWillTake = foundTotal * perItemTime;
                var totalItemWillTakeTS = TimeSpan.FromSeconds(totalItemWillTake);
                var eta = totalItemWillTakeTS - elapsedTimeTS;

                //var remainingTime = remainingitems * perItemTime;
                //var remainingTimeTs = TimeSpan.FromSeconds(remainingTime);
                lblETA.Text = $"{elapsedTimeTS:hh\\:mm\\:s} / {totalItemWillTakeTS:hh\\:mm\\:s} ({eta:hh\\:mm\\:s})";
            }
            
            if (fileEnumarator != null)
            {
                var idle = agents.Where(x => !x.IsActive).ToList();

                // stats
                idle.ForEach(x =>
                {
                    if (x.NonFormat.HasValue && x.NonFormat.Value)
                    {
                        //processedTotal += 1;
                        //logWriter.WriteLine("")
                    }
                    else if (x.OK.HasValue && x.OK.Value)
                    {
                        processedTotal += 1;
                        okno += 1;
                        logWriter.WriteLine($"OK,\"{x.Input.Path}\",\"{x.NewPath ?? string.Empty}\"");
                    }
                    else if (x.OK.HasValue && !x.OK.Value)
                    {
                        processedTotal += 1;
                        logWriter.WriteLine($"FAIL,\"{x.Input.Path}\",\"{string.Empty}\"");
                    }

                    x.OK = null;
                    x.NonFormat = null;

                });

                //show stats
                lblOkFiles.Text = okno.ToString();
                lblTotal.Text = processedTotal.ToString();

                if (cancellationToken.IsCancellationRequested || endOfFileEnum)
                {
                    //check end of activity
                    if (idle.Count == agents.Count)
                    {
                        btnCancel.Enabled = false;
                        timer.Stop();
                        lblActivity.Text = "Idle";
                        logWriter.Close();
                        logWriter.Dispose();
                        logWriter = null;
                    }
                    else if (cancellationToken.IsCancellationRequested)
                    {
                        lblActivity.Text = $"Active {DateTime.Now}... Cancel Pending!";
                    }
                    else if (endOfFileEnum)
                    {
                        lblActivity.Text = $"Active {DateTime.Now}... Last files!";
                    }
                }
                else
                {
                    lblActivity.Text = $"Active {DateTime.Now}";
                }

                //start new work only if not cancelled
                if (!cancellationToken.IsCancellationRequested)
                {
                    for (int i = 0; i < idle.Count; i++)
                    {
                        if (fileEnumarator.MoveNext())
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
        }
    }
}
