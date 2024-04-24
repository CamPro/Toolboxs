using System.Windows.Forms;

namespace ToolLeechTruyenFull
{
    partial class fSetup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        private Label label1;

        private TextBox txbHost;

        private Label label2;

        private TextBox txbName;

        private Label label3;

        private TextBox txbUser;

        private Label label4;

        private TextBox txbPass;

        private Label label5;

        private TextBox txbIdUser;

        private Button btnConnect;

        private Label label6;

        private TextBox txbSource;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolLeechTruyenFull.fSetup));
            this.label1 = new System.Windows.Forms.Label();
            this.txbHost = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbPass = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbIdUser = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txbSource = new System.Windows.Forms.TextBox();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "DB_HOST:";
            this.txbHost.Location = new System.Drawing.Point(12, 31);
            this.txbHost.Name = "txbHost";
            this.txbHost.Size = new System.Drawing.Size(284, 26);
            this.txbHost.TabIndex = 0;
            this.txbHost.Text = "localhost";
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "DB_NAME:";
            this.txbName.Location = new System.Drawing.Point(12, 82);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(284, 26);
            this.txbName.TabIndex = 1;
            this.txbName.Text = "metruyenchu_3";
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "DB_USER:";
            this.txbUser.Location = new System.Drawing.Point(12, 133);
            this.txbUser.Name = "txbUser";
            this.txbUser.Size = new System.Drawing.Size(284, 26);
            this.txbUser.TabIndex = 2;
            this.txbUser.Text = "root";
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "DB_PASS:";
            this.txbPass.Location = new System.Drawing.Point(12, 184);
            this.txbPass.Name = "txbPass";
            this.txbPass.Size = new System.Drawing.Size(284, 26);
            this.txbPass.TabIndex = 3;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 264);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "ID_USER:";
            this.txbIdUser.Location = new System.Drawing.Point(12, 286);
            this.txbIdUser.Name = "txbIdUser";
            this.txbIdUser.Size = new System.Drawing.Size(284, 26);
            this.txbIdUser.TabIndex = 5;
            this.txbIdUser.Text = "1";
            this.btnConnect.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnConnect.FlatAppearance.BorderSize = 0;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Location = new System.Drawing.Point(89, 340);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(131, 39);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Kết nối...";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(btnConnect_Click);
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "NGUỒN TRUYỆN:";
            this.txbSource.Location = new System.Drawing.Point(12, 235);
            this.txbSource.Name = "txbSource";
            this.txbSource.Size = new System.Drawing.Size(284, 26);
            this.txbSource.TabIndex = 4;
            this.txbSource.Text = "metruyenchu.epizy.com";
            base.AcceptButton = this.btnConnect;
            base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 19f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new System.Drawing.Size(308, 393);
            base.Controls.Add(this.btnConnect);
            base.Controls.Add(this.txbIdUser);
            base.Controls.Add(this.txbSource);
            base.Controls.Add(this.txbPass);
            base.Controls.Add(this.txbUser);
            base.Controls.Add(this.txbName);
            base.Controls.Add(this.label6);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.txbHost);
            base.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            base.Margin = new System.Windows.Forms.Padding(4);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "fSetup";
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thiết lập";
            base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(fSetup_FormClosing);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion
    }
}