using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActiveSublime
{
    public partial class frmMain : Form
    {

        string sublime = "C:\\Program Files\\Sublime Text\\sublime_text.exe";

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.FileName = "sublime_text.exe";
            dialog.InitialDirectory = "C:\\Program Files\\Sublime Text";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                sublime = dialog.FileName;
            }
            // kill process
            Process[] sublimes = Process.GetProcessesByName("sublime_text");
            foreach (Process process in sublimes) { process.Kill(); }
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

        private void buttonForBuild4169_Click(object sender, EventArgs e)
        {
            if (!File.Exists(sublime)) return;

            string hexexe = ReadFileAsHexString(sublime);

            // for Build 4169 to lower
            hexexe = hexexe.Replace("80 78 05 00 0F 94 C1", "C6 40 05 01 48 85 C9"); // Unlimited User License

            WriteHexStringAsBinaryToFile(hexexe, sublime);

            // finish
            Process.Start(sublime);

            Environment.Exit(0);
        }

        private void buttonForBuild4180_Click(object sender, EventArgs e)
        {
            if (!File.Exists(sublime)) return;

            string hexexe = ReadFileAsHexString(sublime);

            // for Build 4180
            hexexe = hexexe.Replace("80 79 05 00 0F 94 C2", "C6 41 05 01 B2 00 90"); // Unlimited User License

            WriteHexStringAsBinaryToFile(hexexe, sublime);

            // finish
            Process.Start(sublime);

            Environment.Exit(0);
        }
    }
}
