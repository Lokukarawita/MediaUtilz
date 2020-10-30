//Build csc /t:exe /out:D:\csc\RenameApp.exe /r:System.dll;System.Collections.dll;mscorlib.dll D:\csc\RenameApp.cs 

using System;
using System.IO;
using System.Collections.Generic;

namespace RenameApp
{
	public class RenameApp
	{
		private static bool IsDir(string path)
		{
			FileAttributes attr = File.GetAttributes(path);
			return attr.HasFlag(FileAttributes.Directory);
		}
		
		public static void Main(string[] args)
		{
			var subTyps = new string[] {".srt", ".sass"};
			var skipTypes = new string[] { ".db", ".ini"};
			
			var listOfFiles = new List<string>();
			
			foreach(var arg in args)
			{
				if(IsDir(arg))
				{
					Console.WriteLine("Directory Detected " + arg);
					var files = Directory.GetFiles(arg, "*.*", SearchOption.AllDirectories);
					foreach(var file in files)
					{
						var fi = new FileInfo(file);
						var ext = fi.Extension;
						if(Array.IndexOf(skipTypes, ext.ToLower()) == -1)
						{
							Console.WriteLine("Adding file : " + file);
							listOfFiles.Add(file);
						}
					}
				}
				else
				{
					Console.WriteLine("Adding file : " + arg);
					listOfFiles.Add(arg);
				}
			}
			
			foreach(var x in listOfFiles)
			{
				var fi = new FileInfo(x);
				var dname = fi.Directory.Name;
				var ext = fi.Extension;
				var newpath = string.Empty;
				if(Array.IndexOf(subTyps, ext.ToLower()) > -1)
				{
					Console.WriteLine(x);
					Console.WriteLine("** Sub Language ? ***");
					var lang = Console.ReadLine();
					lang = string.IsNullOrWhiteSpace(lang) ? "eng" : lang;
					ext = "." + lang + ext;
				}
				
				newpath = Path.Combine(fi.Directory.FullName, dname + ext);
				
				//Console.ReadLine();
				File.Move(x, newpath);
			}
		}
	}
}