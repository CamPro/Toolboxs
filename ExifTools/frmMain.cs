using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExifTools
{
    public partial class frmMain : Form
    {
        private DataTable mytable = new DataTable();
        private double Version = 0.1;
        private string exiftool = Path.Combine(Application.StartupPath, "exiftool.exe");
        private string metaFolder = Path.Combine(Application.StartupPath, "metadatas");

        public frmMain()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(frmMain_DragEnter);
            this.DragDrop += new DragEventHandler(frmMain_DragDrop);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            this.Text = Application.ProductName + " " + Version.ToString("0.0");
            mytable.Columns.Add("img_filename", typeof(string));
            mytable.Columns.Add("img_status", typeof(string));
            mytable.Columns.Add("img_filepath", typeof(string));
            dataGridImage.DataSource = mytable;
        }

        private void frmMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void frmMain_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
            GetTable(files);
        }

        private void dataGridImage_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridImage.CurrentCell.RowIndex;
            string filename = dataGridImage.Rows[index].Cells["img_filepath"].Value.ToString();
            if (File.Exists(filename))
            {
                Process.Start(filename);
            }
        }

        public void GetTable(string[] files)
        {
            mytable.Rows.Clear();
            foreach (string filePath in files)
            {
                if (Directory.Exists(filePath))
                {
                    string[] array = Directory.GetFiles(filePath, "*", SearchOption.TopDirectoryOnly);
                    foreach (var item in array)
                    {
                        string fileName = item.Split('\\').Last();
                        mytable.Rows.Add(fileName, "", item);
                    }
                }
                if (File.Exists(filePath))
                {
                    string fileName = filePath.Split('\\').Last();
                    mytable.Rows.Add(fileName, "", filePath);
                }
            }
        }

        public void ExifCleaner()
        {
            Task[] tasks = new Task[mytable.Rows.Count];

            for (int i = 0; i < mytable.Rows.Count; i++)
            {
                int index = i;
                tasks[index] = new Task(() =>
                {
                    mytable.Rows[i]["img_status"] = "...";

                    string filePath = mytable.Rows[index]["img_filepath"].ToString();

                    Process process = new Process();
                    process.StartInfo.FileName = exiftool;
                    process.StartInfo.Arguments = "-overwrite_original -all= \"" + filePath + "\"";
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();
                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();

                    foreach (var item in output.Split('\n'))
                    {
                        if (item.Contains("1"))
                        {
                            output = item.Trim();
                            break;
                        }
                    }
                    mytable.Rows[index]["img_status"] = output.Trim();
                });
                tasks[index].Start();
                System.Threading.Thread.Sleep(10);
            }
        }

        public void ExifExport()
        {
            if (!Directory.Exists(metaFolder))
            {
                Directory.CreateDirectory(metaFolder);
            }
            for (int i = 0; i < mytable.Rows.Count; i++)
            {
                mytable.Rows[i]["img_status"] = "...";

                string filePath = mytable.Rows[i]["img_filepath"].ToString();
                string export = Path.Combine(metaFolder, Path.GetFileNameWithoutExtension(filePath) + ".json");

                Process process = new Process();
                process.StartInfo.FileName = exiftool;
                process.StartInfo.Arguments = $"-g -json \"{filePath}\"";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                File.WriteAllText(export, output.Trim());
                mytable.Rows[i]["img_status"] = "done";
            }
            Process.Start(metaFolder);
        }

        public void ExifImport()
        {
            string jsonexif = textImportJson.Text;
            if (string.IsNullOrEmpty(jsonexif))
            {
                buttonOpenExifJson_Click(null, null);
                jsonexif = textImportJson.Text;
            }

            for (int i = 0; i < mytable.Rows.Count; i++)
            {
                mytable.Rows[i]["img_status"] = "...";

                string filePath = mytable.Rows[i]["img_filepath"].ToString();
                string directory = Path.GetDirectoryName(filePath);

                Process process = new Process();
                process.StartInfo.FileName = exiftool;
                process.StartInfo.Arguments = $"-json=\"{jsonexif}\" \"{filePath}\"";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                mytable.Rows[i]["img_status"] = output;
            }
        }

        public void ExifCopy()
        {
            string copyexif = textExifCopy.Text;
            if (string.IsNullOrEmpty(copyexif))
            {
                buttonExifCopyOpen_Click(null, null);
                copyexif = textExifCopy.Text;
            }

            for (int i = 0; i < mytable.Rows.Count; i++)
            {
                mytable.Rows[i]["img_status"] = "...";

                string filePath = mytable.Rows[i]["img_filepath"].ToString();
                string directory = Path.GetDirectoryName(filePath);

                Process process = new Process();
                process.StartInfo.FileName = exiftool;
                process.StartInfo.Arguments = $"-tagsFromFile \"{copyexif}\" -overwrite_original -exif:all --icc_profile -gps:all= -XMP:all= \"{filePath}\"";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                mytable.Rows[i]["img_status"] = output;
            }
        }

        private void buttonChoseImages_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Chọn hình ảnh";
            dialog.Filter = "Images files|*.jpg;*.gif;*.png;*.jpeg;*.jfif;*.pjpeg;*.pjp;*.svg;*.webp;*.bmp;*.ico;*.cur;*.tif;*.tiff;*.jpe;*.jif;*.jfi;*.heif;*.heic;*.ind;*.indd;*.indt;*.apng;*.avif|All files (*.*)|*.*";
            dialog.Multiselect = true;
            //
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string[] files = dialog.FileNames;
                GetTable(files);
            }
        }

        private void buttonExifCleaner_Click(object sender, EventArgs e)
        {
            ExifCleaner();
        }

        private void buttonExifExport_Click(object sender, EventArgs e)
        {
            ExifExport();
        }

        private void buttonExifImport_Click(object sender, EventArgs e)
        {
            ExifImport();
        }

        private void buttonOpenExifJson_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JSON files|*.json|All files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textImportJson.Text = dialog.FileName;
            }
        }

        private void buttonOpenFolder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(metaFolder))
            {
                Process.Start(metaFolder);
            }
        }

        private void buttonExifCopy_Click(object sender, EventArgs e)
        {
            ExifCopy();
        }

        private void buttonExifCopyOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Chọn hình ảnh";
            dialog.Filter = "Images files|*.jpg;*.gif;*.png;*.jpeg;*.jfif;*.pjpeg;*.pjp;*.svg;*.webp;*.bmp;*.ico;*.cur;*.tif;*.tiff;*.jpe;*.jif;*.jfi;*.heif;*.heic;*.ind;*.indd;*.indt;*.apng;*.avif|All files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textExifCopy.Text = dialog.FileName;
            }
        }

        private void checkEnable_CheckedChanged(object sender, EventArgs e)
        {
            buttonExifExport.Enabled = checkEnable.Checked;
            buttonExifImport.Enabled = checkEnable.Checked;
            textImportJson.Enabled = checkEnable.Checked;
            buttonOpenExifJson.Enabled = checkEnable.Checked;
        }
    }
}
