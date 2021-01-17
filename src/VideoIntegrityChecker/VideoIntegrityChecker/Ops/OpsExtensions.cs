using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Integrity_Checker.Ops
{
    public static class OpsExtensions
    {
        public static bool IsValidFormat(this string path, string[] formats)
        {
            if (!File.Exists(path)) return false;
            var ext = Path.GetExtension(path).Trim('.').ToLower();
            var fmts = formats ?? new string[0];
            if (ext == "" || Array.IndexOf(fmts, ext) > -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
