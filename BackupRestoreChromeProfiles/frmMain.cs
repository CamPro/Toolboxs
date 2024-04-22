using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using PuppeteerSharp;
using System.Threading.Tasks;

namespace BackupRestoreChromeProfiles
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
                JObject jobj = JObject.Parse(json);
                name = jobj["profile"]["info_cache"][profile]["name"].ToString();

                List<Account> accounts = Chromium.Accounts(userdata, fullpath);
                List<Cookies> cookies = Chromium.CookiesList(userdata, fullpath);

                ChromeProfile chrome = new ChromeProfile();
                chrome.Profile = profile;
                chrome.Name = name;
                chrome.ListAccount = accounts;
                chrome.ListCookies = cookies;

                string datetime = DateTime.Now.ToString("yyyy-MM-dd");
                json = JsonConvert.SerializeObject(chrome);

                string savepath = Path.Combine(textSave.Text, $"backup_chrome_{profile.Replace(" ", "")}_{datetime}.json");
                File.WriteAllText(savepath, json);
            }
            Process.Start(textSave.Text);
        }

        private void buttonRestore_Click(object sender, EventArgs e)
        {
            KillChrome();

            string browser = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = "C:\\Program Files\\Google\\Chrome\\Application";
            dialog.FileName = "chrome.exe";
            if (!File.Exists(browser))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    browser = dialog.FileName;
                }
            }

            string userdata = textUserdata.Text;
            string[] files = Directory.GetFiles(textSave.Text, "*.json", SearchOption.TopDirectoryOnly);

            foreach (var backup in files)
            {
                string json = File.ReadAllText(backup);
                ChromeProfile chrome = JsonConvert.DeserializeObject<ChromeProfile>(json);
                string profile = chrome.Profile;
                string name = chrome.Name;
                List<Account> accounts = chrome.ListAccount;
                List<Cookies> cookies = chrome.ListCookies;

                Process process = new Process();
                process.StartInfo.FileName = browser;
                process.StartInfo.Arguments = $"--profile-directory=\"{profile}\"";
                process.Start();
                Thread.Sleep(1000);
                AutoIt.AutoItX.WinWaitActive("[CLASS:Chrome_WidgetWin_1]", "", 10);
                IntPtr handle = AutoIt.AutoItX.WinGetHandle("[CLASS:Chrome_WidgetWin_1]", "");
                Thread.Sleep(1000);

                int width = Screen.PrimaryScreen.Bounds.Width;
                int height = Screen.PrimaryScreen.Bounds.Height;
                AutoIt.AutoItX.WinMove(handle, 0, 0, width, height);
                //Rectangle rectangle = AutoIt.AutoItX.WinGetPos(handle);
                AutoIt.AutoItX.WinActivate(handle);
                AutoIt.AutoItX.MouseClick("LEFT", width - 145, height - 40); // click popup
                Thread.Sleep(1000);
                handle = AutoIt.AutoItX.WinGetHandle("[CLASS:Chrome_WidgetWin_1]", "");
                AutoIt.AutoItX.WinSetState(handle, AutoIt.AutoItX.SW_MAXIMIZE);
                Thread.Sleep(1000);
                AutoIt.AutoItX.WinClose(handle);
                Thread.Sleep(1000);

                string localstate = Path.Combine(textUserdata.Text, "Local State");
                json = File.ReadAllText(localstate);
                JObject jobj = JObject.Parse(json);
                jobj["profile"]["info_cache"][profile]["name"] = name;
                jobj["profile"]["info_cache"][profile]["shortcut_name"] = name;
                json = JsonConvert.SerializeObject(jobj);
                File.WriteAllText(localstate, json);
                Thread.Sleep(10);

                string preference = Path.Combine(textUserdata.Text, profile, "Preferences");
                json = File.ReadAllText(preference);
                jobj = JObject.Parse(json);
                jobj["profile"]["name"] = name;
                json = JsonConvert.SerializeObject(jobj);
                File.WriteAllText(preference, json);
                Thread.Sleep(10);

                // import cookie
                OpenChrome(cookies, userdata, profile);
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

        public string FormatCookie(Cookies cCookie)
        {
            return string.Format("{0}\tTRUE\t{1}\tFALSE\t{2}\t{3}\t{4}\r", (object)cCookie.HostKey, (object)cCookie.Path, (object)cCookie.ExpiresUtc, (object)cCookie.Name, (object)cCookie.Value);
        }

        public void KillChrome()
        {
            Process[] processes = Process.GetProcessesByName("chrome");
            foreach (var item in processes)
            {
                item.CloseMainWindow();
            }
        }

        public async void OpenChrome(List<Cookies> cookies, string userdata, string profile)
        {
            await new BrowserFetcher().DownloadAsync();

            List<string> args = new List<string>();
            args.Add("--start-maximized");
            args.Add("--disable-notifications");
            args.Add($"--profile-directory=\"{profile}\"");

            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;

            ViewPortOptions viewPortOptions = new ViewPortOptions();
            IBrowser chromium = null;
            IPage page = null;
            try
            {
                chromium = await PuppeteerSharp.Puppeteer.LaunchAsync(new LaunchOptions
                {
                    Headless = false,
                    UserDataDir = userdata,
                    Args = args.ToArray()
                });
                IPage[] pages = await chromium.PagesAsync();
                if (pages.Count() > 0)
                {
                    page = pages[0];
                }
                viewPortOptions = new ViewPortOptions()
                {
                    IsMobile = false,
                    Width = width,
                    Height = height
                };
                await page.SetViewportAsync(viewPortOptions);

                Loading loadingForm = new Loading(cookies.Count);
                loadingForm.Show();

                int success = 0;
                int fail = 0;

                foreach (var cookie in cookies)
                {
                    try
                    {
                        await page.SetCookieAsync(new CookieParam()
                        {
                            Domain = cookie.HostKey,
                            Name = cookie.Name,
                            Value = cookie.Value,
                            Expires = (double)DateTimeOffset.Now.AddYears(1).ToUnixTimeSeconds()
                        });
                        success++;
                        await Task.Delay(5);
                    }
                    catch (Exception)
                    {
                        fail++;
                    }
                    loadingForm.updateLoading(success, fail);
                }

                loadingForm.close();
                Thread.Sleep(500);

                await page.GoToAsync("chrome://newtab");
                Thread.Sleep(1000);

                await chromium.CloseAsync();
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }

    }
}
