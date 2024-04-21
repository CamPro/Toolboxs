using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HashFile
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.AllowDrop = true;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void frmMain_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                string hash = CalculateMD5(file);
                if (string.IsNullOrEmpty(textHash1.Text))
                {
                    textHash1.Text = hash;
                    buttonOpen1.Text = Path.GetFileName(file);
                }
                else if (string.IsNullOrEmpty(textHash2.Text))
                {
                    textHash2.Text = hash;
                    buttonOpen2.Text = Path.GetFileName(file);
                }
                else if (string.IsNullOrEmpty(textHash3.Text))
                {
                    textHash3.Text = hash;
                    buttonOpen3.Text = Path.GetFileName(file);
                }
                else if (string.IsNullOrEmpty(textHash4.Text))
                {
                    textHash4.Text = hash;
                    buttonOpen4.Text = Path.GetFileName(file);
                }
            }
        }

        private void frmMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void buttonOpen1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textHash1.Text = CalculateMD5(dialog.FileName);
                buttonOpen1.Text = Path.GetFileName(dialog.FileName);
            }
        }

        private void buttonOpen2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textHash2.Text = CalculateMD5(dialog.FileName);
                buttonOpen2.Text = Path.GetFileName(dialog.FileName);
            }
        }

        private void buttonOpen3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textHash3.Text = CalculateMD5(dialog.FileName);
                buttonOpen3.Text = Path.GetFileName(dialog.FileName);
            }
        }

        private void buttonOpen4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textHash4.Text = CalculateMD5(dialog.FileName);
                buttonOpen4.Text = Path.GetFileName(dialog.FileName);
            }
        }

        static string CalculateMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

    }
}
