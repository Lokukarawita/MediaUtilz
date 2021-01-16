using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Integrity_Checker.Ops
{
    class AgentInput
    {
        public string[] Formats { get; set; }
        public string FFMPEG { get; set; }
        public string SrcPath { get; set; }

        public string Path { get; set; }
        public bool MoveOk { get; set; }
        public string MoveOkPath { get; set; }
    }
}
