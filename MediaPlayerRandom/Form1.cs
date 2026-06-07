using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace MediaPlayerRandom
{
    public partial class Form1 : Form
    {
        static string mediaFolder = string.Empty;

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ValidateNames = false;
            dlg.CheckFileExists = false;
            dlg.CheckPathExists = true;
            dlg.FileName = "Select Folder";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                mediaFolder = Path.GetDirectoryName(dlg.FileName);
            }
            else
            {
                Application.Exit();
            }
        }

        private void buttonRandom_Click(object sender, EventArgs e)
        {
            string[] mediaFiles = Directory.GetFiles(mediaFolder, "*.mp4");
            int index = new Random().Next(0, mediaFiles.Length);

            Process.Start(mediaFiles[index]);
        }

    }
}
