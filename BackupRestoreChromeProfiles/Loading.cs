using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackupRestoreChromeProfiles
{
    public partial class Loading : Form
    {
        private int maxValue = 100;
        private int newValue = 0;
        private int errorValue = 0;

        private delegate void DelegateUpdateProgress();

        public Loading(int max)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            progressBarStatus.Maximum = max;
            progressBarStatus.Minimum = 0;
            maxValue = max;
            this.TopMost = true;
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            timerRefresh.Enabled = true;
        }

        public void close()
        {
            if (this.InvokeRequired)
            {
                DelegateUpdateProgress d = new DelegateUpdateProgress(close);
                this.Invoke(d);
            }
            else
            {
                this.Close();
            }
        }

        public void updateLoading(int value, int error = 0)
        {
            this.newValue = value;
            this.errorValue = error;
            updateProgress();
        }

        public void updateProgress()
        {
            if (progressBarStatus.InvokeRequired)
            {
                DelegateUpdateProgress d = new DelegateUpdateProgress(updateProgress);
                this.Invoke(d);
            }
            else
            {
                progressBarStatus.Value = newValue;
                labelStatus.Text = newValue + "/" + maxValue;
                labelError.Text = errorValue.ToString();
            }
            if (newValue > maxValue)
            {
                this.Close();
            }
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            int max = progressBarStatus.Maximum;
            int value = progressBarStatus.Value;
            int percent = (int)Math.Round(Convert.ToDouble(value) * 100 / Convert.ToDouble(max));
            this.Text = $"{percent}%";
        }
    }
}
