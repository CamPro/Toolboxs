using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolLeechTruyenFull
{
    public partial class fMain : Form
    {
        private bool _check_start;

        private int _current_page = 1;

        private List<DTO_Truyen> listLink;

        private string _URL = "https://truyenfull.vn/danh-sach/truyen-moi/";

        public fMain()
        {
            InitializeComponent();
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            new fSetup().ShowDialog();
            if (SystemFiles._CHECK)
            {
                btnStart.Enabled = true;
            }
            else
            {
                btnStart.Enabled = false;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "Start")
            {
                btnStart.Text = "Stop";
                _check_start = true;
                rtxbContent.Focus();
                ScanStories();
            }
            else
            {
                btnStart.Text = "Start";
                _check_start = false;
            }
        }

        private void ScanStories()
        {
            try
            {
                Thread thread = new Thread((ThreadStart)delegate
                {
                    //IL_003c: Unknown result type (might be due to invalid IL or missing references)
                    //IL_0042: Expected O, but got Unknown
                    //IL_04e1: Unknown result type (might be due to invalid IL or missing references)
                    string text = "";
                    for (int story_page = _current_page; story_page <= 1150; story_page++)
                    {
                        if (!_check_start)
                        {
                            break;
                        }
                        HtmlWeb val = new HtmlWeb();
                        listLink = new List<DTO_Truyen>();
                        string _link_page = _URL + "trang-" + story_page + "/";
                        _current_page = story_page;
                        txbLink.Invoke((Action)delegate
                        {
                            txbLink.Text = _link_page;
                        });
                        dgvStories.Invoke((Action)delegate
                        {
                            dgvStories.Rows.Clear();
                        });
                        lbStatus.Invoke((Action)delegate
                        {
                            lbStatus.Text = "Trạng thái: get truyện";
                        });
                        lbPage.Invoke((Action)delegate
                        {
                            lbPage.Text = $"Trang: {story_page}/1150";
                        });
                        try
                        {
                            HtmlAgilityPack.HtmlDocument val2 = val.Load(_link_page);
                            if (val2 == null)
                            {
                                break;
                            }
                            bool flag = true;
                            int _num_stories = 1;
                            for (int j = 1; j <= 28; j++)
                            {
                                if (!_check_start)
                                {
                                    return;
                                }
                                try
                                {
                                    string text2 = "//*[@id='list-page']/div[1]/div[2]/div[" + j + "]/div[2]/div/h3/a";
                                    HtmlNode val3 = val2.DocumentNode.SelectSingleNode(text2);
                                    if (val3 != null)
                                    {
                                        string name = val3.InnerText;
                                        if (flag)
                                        {
                                            if (!(name.Trim() != text.Trim()))
                                            {
                                                _check_start = false;
                                                btnStart.Invoke((Action)delegate
                                                {
                                                    btnStart.Text = "Start";
                                                    _check_start = false;
                                                });
                                                break;
                                            }
                                            text = name;
                                            flag = false;
                                        }
                                        string link = val3.Attributes["href"].Value.ToString();
                                        string text3 = "//*[@id='list-page']/div[1]/div[2]/div[ " + j + " ]/div[3]/div/a/text()";
                                        string chap = "";
                                        try
                                        {
                                            chap = val2.DocumentNode.SelectSingleNode(text3).InnerText + "C";
                                        }
                                        catch
                                        {
                                            chap = "0C";
                                        }
                                        chap = "Khoảng " + chap;
                                        DTO_Truyen item = new DTO_Truyen(name, link);
                                        listLink.Add(item);
                                        lbProcess.Invoke((Action)delegate
                                        {
                                            lbProcess.Text = $"Tìm thấy: {_num_stories} truyện";
                                        });
                                        dgvStories.Invoke((Action)delegate
                                        {
                                            dgvStories.Rows.Add(_num_stories, name, chap, link);
                                        });
                                        int num = _num_stories;
                                        _num_stories = num + 1;
                                    }
                                }
                                catch
                                {
                                    continue;
                                }
                                Thread.Sleep(100);
                            }
                            flag = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        for (int i = 0; i < listLink.Count; i++)
                        {
                            int num2 = 0;
                            string[] infoStory = getTruyen.getInfoStory(listLink[i].Link);
                            if (infoStory != null)
                            {
                                txbLink.Invoke((Action)delegate
                                {
                                    txbLink.Text = listLink[i].Link;
                                });
                                lbStatus.Invoke((Action)delegate
                                {
                                    lbStatus.Text = "Trạng thái: duyệt truyện";
                                });
                                if (DAO_Truyen.Check(listLink[i].Name, infoStory[0]))
                                {
                                    num2 = DAO_Truyen.getId(listLink[i].Name, infoStory[0]);
                                    DAO_Truyen.updateStatus(infoStory[4], num2);
                                }
                                else
                                {
                                    string[] tags = infoStory[3].Split(',');
                                    num2 = DAO_Truyen.insertTruyen(listLink[i].Name, infoStory[0], infoStory[1], infoStory[4], infoStory[2], tags);
                                }
                                List<string> list = new List<string>();
                                bool flag2 = true;
                                int num3 = 1;
                                string text4 = "";
                                int _countChapter = 1;
                                while (flag2)
                                {
                                    if (!_check_start)
                                    {
                                        return;
                                    }
                                    string text5 = listLink[i].Link + "trang-" + num3 + "/";
                                    lbStatus.Invoke((Action)delegate
                                    {
                                        lbStatus.Text = "Trạng thái: quét chương";
                                    });
                                    try
                                    {
                                        HtmlAgilityPack.HtmlDocument val4 = new HtmlWeb().Load(text5);
                                        string text6 = "//*[@id='list-chapter']/div[2]/div[1]/ul/li";
                                        HtmlNodeCollection val5 = val4.DocumentNode.SelectNodes(text6);
                                        if (val5 == null)
                                        {
                                            flag2 = false;
                                            break;
                                        }
                                        string text7 = "//*[@id='list-chapter']/div[2]/div[1]/ul/li[1]/a";
                                        text4 = val4.DocumentNode.SelectSingleNode(text7).Attributes["href"].Value.ToString();
                                        if (list.Contains(text4))
                                        {
                                            flag2 = false;
                                            break;
                                        }
                                        for (int k = 1; k <= val5.Count; k++)
                                        {
                                            if (!_check_start || !flag2)
                                            {
                                                return;
                                            }
                                            string text8 = "//*[@id='list-chapter']/div[2]/div[1]/ul/li[" + k + "]/a";
                                            HtmlNode val6 = val4.DocumentNode.SelectSingleNode(text8);
                                            if (val6 == null)
                                            {
                                                flag2 = false;
                                                break;
                                            }
                                            string value = val6.Attributes["href"].Value;
                                            list.Add(value.ToString());
                                            lbProcess.Invoke((Action)delegate
                                            {
                                                lbProcess.Text = $"Tìm thấy: {_countChapter} chương";
                                            });
                                            _countChapter++;
                                            Thread.Sleep(50);
                                        }
                                        string text9 = "//*[@id='list-chapter']/div[2]/div[2]/ul/li";
                                        HtmlNodeCollection val7 = val4.DocumentNode.SelectNodes(text9);
                                        if (val7 == null)
                                        {
                                            flag2 = false;
                                            break;
                                        }
                                        for (int l = 1; l <= val7.Count; l++)
                                        {
                                            if (!_check_start || !flag2)
                                            {
                                                return;
                                            }
                                            string text10 = "//*[@id='list-chapter']/div[2]/div[2]/ul/li[" + l + "]/a";
                                            HtmlNode val8 = val4.DocumentNode.SelectSingleNode(text10);
                                            if (val8 == null)
                                            {
                                                flag2 = false;
                                                break;
                                            }
                                            string value2 = val8.Attributes["href"].Value;
                                            list.Add(value2.ToString());
                                            lbProcess.Invoke((Action)delegate
                                            {
                                                lbProcess.Text = $"Tìm thấy: {_countChapter} chương";
                                            });
                                            _countChapter++;
                                            Thread.Sleep(50);
                                        }
                                        Thread.Sleep(50);
                                        num3++;
                                    }
                                    catch (Exception ex2)
                                    {
                                        MessageBox.Show(ex2.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    }
                                }
                                int numchap = DAO_Truyen.getNumchap(num2);
                                if (DAO_Truyen.getStatus(num2) == "Hoàn thành" && numchap == list.Count)
                                {
                                    dgvStories.Invoke((Action)delegate
                                    {
                                        dgvStories.Rows.RemoveAt(0);
                                    });
                                }
                                else
                                {
                                    lbStatus.Invoke((Action)delegate
                                    {
                                        lbStatus.Text = "Trạng thái: thêm chương";
                                    });
                                    int insert_chap = numchap;
                                    int num4 = 0;
                                    if (insert_chap == 0)
                                    {
                                        insert_chap = 1;
                                    }
                                    for (int m = numchap; m < list.Count; m++)
                                    {
                                        if (!_check_start)
                                        {
                                            return;
                                        }
                                        string[] chapter = getTruyen.getChapter(list[m]);
                                        if (chapter == null)
                                        {
                                            int num = insert_chap;
                                            insert_chap = num + 1;
                                        }
                                        else
                                        {
                                            int num5 = SystemFiles.WK(chapter[1]);
                                            num4 += num5;
                                            rtxbContent.Invoke((Action)delegate
                                            {
                                                rtxbContent.Text = $"Chương {insert_chap}: {chapter[0]}\n{chapter[1]}";
                                            });
                                            if (!DAO_Truyen.checkChapter(insert_chap, num2))
                                            {
                                                DAO_Truyen.insertChapter(insert_chap, chapter[0], chapter[1], num5, num2);
                                            }
                                            int num = insert_chap;
                                            insert_chap = num + 1;
                                            Thread.Sleep(100);
                                        }
                                    }
                                    rtxbContent.Invoke((Action)delegate
                                    {
                                        rtxbContent.Clear();
                                    });
                                    lbStatus.Invoke((Action)delegate
                                    {
                                        lbStatus.Text = "Trạng thái: update word count";
                                    });
                                    DAO_Truyen.updateWK(num4, num2);
                                    dgvStories.Invoke((Action)delegate
                                    {
                                        dgvStories.Rows.RemoveAt(0);
                                    });
                                    Thread.Sleep(1000);
                                }
                            }
                        }
                        Thread.Sleep(1000);
                    }
                });
                thread.IsBackground = true;
                thread.Start();
            }
            catch
            {
                MessageBox.Show("Mất kết nối...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }
}
