using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActiveSublimeText
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string sublime = "C:\\Program Files\\Sublime Text\\sublime_text.exe";
            if (File.Exists(sublime))
            {
                // kill process
                Process[] sublimes = Process.GetProcessesByName("sublime_text");
                foreach (Process process in sublimes) { process.Kill(); }
                // active
                string hexexe = ReadFileAsHexString(sublime);
                hexexe = hexexe.Replace("97 94 0D", "00 00 00");
                hexexe = hexexe.Replace("80 78 05 00 0F 94 C1", "C6 40 05 01 48 85 C9");
                WriteHexStringAsBinaryToFile(hexexe, sublime);
                // finish
                Process.Start(sublime);
            }
            else
            {
                MessageBox.Show("Sublime Text not installed.");
            }
            Environment.Exit(0);
        }

        static string ReadFileAsHexString(string filename)
        {
            var bytes = File.ReadAllBytes(filename);
            return bytes.Aggregate(new StringBuilder(),
                                   (sb, v) => sb.AppendFormat("{0:X2} ", v))
                        .ToString();
        }

        static void WriteHexStringAsBinaryToFile(string hex, string filename)
        {
            var bytes = hex.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                           .Select(s => Convert.ToByte(s, 16))
                           .ToArray();
            File.WriteAllBytes(filename, bytes);
        }
    }
}
