using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
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
            if (!File.Exists(sublime))
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.InitialDirectory = "C:\\Program Files";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    sublime = dialog.FileName;
                }
            }
            if (File.Exists(sublime))
            {
                // kill process
                Process[] sublimes = Process.GetProcessesByName("sublime_text");
                foreach (Process process in sublimes) { process.Kill(); }
                // active
                string hexexe = ReadFileAsHexString(sublime);
                hexexe = hexexe.Replace("97 94 0D", "00 00 00"); // License for TwitterInc
                /*
                 ----- BEGIN LICENSE -----
                TwitterInc
                200 User License
                EA7E-890007
                1D77F72E 390CDD93 4DCBA022 FAF60790
                61AA12C0 A37081C5 D0316412 4584D136
                94D7F7D4 95BC8C1C 527DA828 560BB037
                D1EDDD8C AE7B379F 50C9D69D B35179EF
                2FE898C4 8E4277A8 555CE714 E1FB0E43
                D5D52613 C3D12E98 BC49967F 7652EED2
                9D2D2E61 67610860 6D338B72 5CF95C69
                E36B85CC 84991F19 7575D828 470A92AB
                ------ END LICENSE ------
                 */
                hexexe = hexexe.Replace("80 78 05 00 0F 94 C1", "C6 40 05 01 48 85 C9"); // Unlimited User License
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
