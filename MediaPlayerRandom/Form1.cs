using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MediaPlayerRandom
{
    public partial class Form1 : Form
    {
        List<string> mediaFiles = new List<string>();
        int index = 0;

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
                string mediaFolder = Path.GetDirectoryName(dlg.FileName);
                mediaFiles = Directory.GetFiles(mediaFolder, "*.mp4").ToList();
                //mediaFiles.RandomList();
                mediaFiles.Shuffle();
            }
            else
            {
                Application.Exit();
            }
        }

        private void buttonRandom_Click(object sender, EventArgs e)
        {
            Process.Start(mediaFiles[index++]);

            if (index >= mediaFiles.Count)
            {
                index = 0;
            }
        }
    }

    public static class ListExtensions
    {
        private static Random rng = new Random();

        public static void Shuffle<T>(this List<T> list)
        {
            int n = list.Count;

            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);

                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }


        public static List<T> RandomList<T>(this List<T> input, int take = 0)
        {
            Random rnd = new Random();
            List<T> list = (from item in input orderby rnd.Next() select item).ToList<T>();
            return list.Take((take == 0) ? list.Count : take).ToList<T>();
        }

    }
}
