using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolLeechTruyenFull
{
    public partial class fSetup : Form
    {
        private bool _check_click;
        public fSetup()
        {
            InitializeComponent();
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            _check_click = true;
            string text = txbHost.Text.Trim();
            string text2 = txbName.Text.Trim();
            string text3 = txbUser.Text.Trim();
            string text4 = txbPass.Text.Trim();
            string sOURCE = txbSource.Text.Trim();
            int num = (SystemFiles._USER_ID = int.Parse(txbIdUser.Text));
            SystemFiles._SOURCE = sOURCE;
            SystemFiles._CONECTION_STRING = "Server=" + text + ";Database=" + text2 + ";UId=" + text3 + ";Pwd=" + text4 + ";port=3306;Pooling=false;Character Set=utf8;";
            try
            {
                if (DataProvider.ExecuteQuery($"select id from users where id = {num}").Rows.Count > 0)
                {
                    SystemFiles._CHECK = true;
                    Close();
                }
                else
                {
                    SystemFiles._CHECK = false;
                    MessageBox.Show("Không thể kết nối tới máy chủ...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            catch
            {
                SystemFiles._CHECK = false;
                MessageBox.Show("Không thể kết nối tới máy chủ...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void fSetup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_check_click)
            {
                SystemFiles._CHECK = false;
            }
        }

    }
}
