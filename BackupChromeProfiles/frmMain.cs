using SimpleJSON;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BackupChromeProfiles
{
    public partial class frmMain : Form
    {
        DataTable ctable = new DataTable();

        public frmMain()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ctable = new DataTable();
            ctable.Columns.Add("_stt", typeof(string));
            ctable.Columns.Add("_profile", typeof(string));
            ctable.Columns.Add("_fullpath", typeof(string));
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            string userdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Google", "Chrome", "User Data");
            if (Directory.Exists(userdata))
            {
                textUserdata.Text = userdata;
                GetAllProfiles();
            }
            textSave.Text = Application.StartupPath;
        }

        private void buttonOpenUserdata_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textUserdata.Text = dialog.SelectedPath;
                GetAllProfiles();
            }
        }

        private void buttonOpenSave_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textSave.Text = dialog.SelectedPath;
            }
        }

        private void buttonOpenUserdataFolder_Click(object sender, EventArgs e)
        {
            string folder = textUserdata.Text;
            if (Directory.Exists(folder))
            {
                Process.Start(folder);
            }
        }

        private void buttonOpenSaveFolder_Click(object sender, EventArgs e)
        {
            string folder = textSave.Text;
            if (Directory.Exists(folder))
            {
                Process.Start(folder);
            }
        }

        private void buttonBackup_Click(object sender, EventArgs e)
        {
            KillChrome();

            string userdata = textUserdata.Text;
            for (int i = 0; i < ctable.Rows.Count; i++)
            {
                string name = string.Empty;
                string profile = ctable.Rows[i]["_profile"].ToString();
                string fullpath = ctable.Rows[i]["_fullpath"].ToString();

                string localstate = Path.Combine(textUserdata.Text, "Local State");
                string json = File.ReadAllText(localstate);

                JSONNode jnode = JSON.Parse(json);
                string price = jnode["USD"]["15m"].Value;
                name = jnode["profile"]["info_cache"][profile]["name"].Value;

                List<Account> accounts = Chromium.Accounts(userdata, fullpath);
                List<Cookies> cookies = Chromium.CookiesList(userdata, fullpath);

                ChromeProfile chrome = new ChromeProfile();
                chrome.Profile = profile;
                chrome.Name = name;
                chrome.ListAccount = accounts;
                chrome.ListCookies = cookies;

                string datetime = DateTime.Now.ToString("yyyy-MM-dd");
                string savepath = Path.Combine(textSave.Text, $"backup_chrome_{profile.Replace(" ", "")}_{datetime}.json");

                json = string.Empty;
                json += "{\"Profile\":\"" + profile + "\",\"Name\":\"" + name + "\",\"ListAccount\":[";

                List<string> lists = new List<string>();
                foreach (var item in accounts)
                {
                    string text = "{\"UserName\":\"" + item.UserName + "\",\"Password\":\"" + item.Password + "\",\"URL\":\"" + item.URL + "\"}";
                    lists.Add(text);
                }
                json += string.Join(",", lists);
                json += "],\"ListCookies\":[";

                lists = new List<string>();
                foreach (var item in cookies)
                {
                    string text = "{\"HostKey\":\"" + item.HostKey + "\",\"Name\":\"" + item.Name + "\",\"Value\":\"" + item.Value + "\",\"Path\":\"" + item.Path + "\",\"ExpiresUtc\":\"" + item.ExpiresUtc + "\",\"IsSecure\":\"" + item.IsSecure + "\"}";
                    lists.Add(text);
                }
                json += string.Join(",", lists);
                json += "]}";

                File.WriteAllText(savepath, json);
            }
            Process.Start(textSave.Text);
        }

        public void GetAllProfiles()
        {
            ctable.Rows.Clear();
            string userdata = textUserdata.Text;
            int stt = 0;
            string profile = string.Empty;
            string fullpath = string.Empty;

            List<string> profiles = Directory.GetDirectories(userdata, "Default", SearchOption.TopDirectoryOnly).ToList();
            foreach (var item in profiles)
            {
                profile = item.Split('\\').Last();
                fullpath = item;
                ctable.Rows.Add(++stt, profile, fullpath);
            }
            profiles = Directory.GetDirectories(userdata, "Profile *", SearchOption.TopDirectoryOnly).ToList();
            foreach (var item in profiles)
            {
                profile = item.Split('\\').Last();
                fullpath = item;
                ctable.Rows.Add(++stt, profile, fullpath);
            }
            dataGridProfile.DataSource = ctable;
        }

        public void KillChrome()
        {
            Process process = new Process();
            process.StartInfo.FileName = "taskkill.exe";
            process.StartInfo.Arguments = "/f /im chrome.exe";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();
            process.WaitForExit();
        }

    }
}
