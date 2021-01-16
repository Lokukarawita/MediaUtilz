using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Integrity_Checker.Ops
{
    class VideoCheckAgent
    {

        private void DoWork()
        {
            try
            {
                Debug.WriteLine(Input.Path);

                var ext = Path.GetExtension(Input.Path).Trim('.').ToLower();
                var fmts = Input.Formats ?? new string[0];
                if (ext == "" || Array.IndexOf(fmts, ext) > -1)
                {
                    NonFormat = false;
                    //var log = Input.Path + ".log";
                    var procStart = new ProcessStartInfo()
                    {
                        FileName = Input.FFMPEG,
                        //Arguments = "-v error -i " + Input.Path + " -f null - > \"" + log + "\" 2>&1",
                        //Arguments = "-v error -i \"" + Input.Path + "\" -f null - > \"" + log + "\"",
                        Arguments = "-v error -i \"" + Input.Path + "\" -f null - ",

                        CreateNoWindow = true,
                        UseShellExecute = false,
                        RedirectStandardError = true,
                        WorkingDirectory = Path.GetDirectoryName(Input.Path),


                        //sta
                    };
                    try
                    {
                        var srbErrorList = new StringBuilder();
                        var proc = Process.Start(procStart);
                        proc.EnableRaisingEvents = true;
                        proc.BeginErrorReadLine();
                        proc.ErrorDataReceived += (source, eventArg) =>
                        {
                            if (!proc.HasExited)
                            {
                                try
                                {
                                    proc.Kill();
                                }
                                catch (Exception) { }

                            }
                            if (!string.IsNullOrEmpty(eventArg.Data))
                                srbErrorList.Append(eventArg.Data);
                        };
                        proc.Exited += (src, evt) =>
                        {
                            OK = srbErrorList.Length == 0;


                            if (OK.Value && Input.MoveOk)
                            {
                                var replaced = Input.Path.Replace(Input.SrcPath, "").TrimStart(Path.DirectorySeparatorChar);
                                NewPath = Path.Combine(Input.MoveOkPath, replaced);
                                var combiledDir = Path.GetDirectoryName(NewPath);
                                Directory.CreateDirectory(combiledDir);
                                new FileInfo(Input.Path).MoveTo(NewPath);
                            }

                            IsActive = false;
                        };
                    }
                    catch (Exception)
                    {
                        OK = false;
                        IsActive = false;
                    }
                    //proc.WaitForExit();
                    //OK = OK ?? true;
                    //var err = proc.StandardError.ReadToEnd();

                    //OK = string.IsNullOrWhiteSpace(err);


                }
                else
                {
                    NonFormat = true;
                    IsActive = false;
                }
            }
            catch (Exception ex)
            {
                IsActive = false;
            }
            finally
            {
                //IsActive = false;
            }
        }




        public void Begin(AgentInput agentInput)
        {
            IsActive = true;
            Input = agentInput;
            OK = null;
            NonFormat = null;
            Task.Factory.StartNew(() => { DoWork(); });
        }

        public bool IsActive { get; private set; }
        public AgentInput Input { get; private set; }

        public bool? NonFormat { get; set; }
        public bool? OK { get; set; }
        public string NewPath { get; set; }
    }
}
