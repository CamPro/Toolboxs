using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FixChromeWindowsAllProfile
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            string userDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Google", "Chrome", "User Data");

            string[] files = Directory.GetFiles(userDataFolder, "Preferences", SearchOption.AllDirectories);

            foreach (string file in files)
            {
                if (file.Contains("Guest Profile") || file.Contains("System Profile"))
                {
                    continue;
                }

                string jsontext = File.ReadAllText(file);

                JObject objs = JObject.Parse(jsontext);

                objs["browser"]["window_placement"]["left"] = 0;
                objs["browser"]["window_placement"]["top"] = 0;
                objs["browser"]["window_placement"]["right"] = Screen.PrimaryScreen.Bounds.Width;
                objs["browser"]["window_placement"]["bottom"] = Screen.PrimaryScreen.Bounds.Height - 40;
                objs["browser"]["window_placement"]["maximized"] = true;

                jsontext = objs.ToString();

                File.WriteAllText(file, jsontext);
            }

            MessageBox.Show("Done");

            Application.Exit();
        }
    }
}
