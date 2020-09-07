using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Framework.Utils
{
    public class EnvUtils
    {
        public static string projectPath = AppDomain.CurrentDomain.BaseDirectory;

        public static DirectoryInfo GetDirectory(string subfolder)
        {
            string path = Path.Combine(projectPath, subfolder);
            string localpath = new Uri(path).LocalPath;
            DirectoryInfo di = new DirectoryInfo(localpath);
            Directory.CreateDirectory(localpath);
            di.Attributes |= FileAttributes.Normal;

            return di;
        }

        public static string GetDirectory(string subfolder, string ssname)
        {
            string ssdir = Path.Combine(projectPath, subfolder);
            string cleanssname = Regex.Replace(ssname, @"[^0-9a-zA-Z- ]+", "");
            string path = ssdir + cleanssname + ".png";
            string localpath = new Uri(path).LocalPath;
            Directory.CreateDirectory(ssdir);
            DirectoryInfo di = new DirectoryInfo(ssdir);
            di.Attributes |= FileAttributes.Normal;

            return localpath;
        }
    }
}
