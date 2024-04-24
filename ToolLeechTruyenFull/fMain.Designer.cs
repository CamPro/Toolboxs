using System.Windows.Forms;

namespace ToolLeechTruyenFull
{
    partial class fMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private TextBox txbLink;

        private Button btnStart;

        private RichTextBox rtxbContent;

        private DataGridView dgvStories;

        private Panel panel1;

        private Label lbStatus;

        private Label lbProcess;

        private DataGridViewTextBoxColumn Column1;

        private DataGridViewTextBoxColumn Column2;

        private DataGridViewTextBoxColumn Column3;

        private DataGridViewTextBoxColumn Column4;

        private Label lbPage;
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
            this.txbLink = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.rtxbContent = new System.Windows.Forms.RichTextBox();
            this.dgvStories = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbPage = new System.Windows.Forms.Label();
            this.lbProcess = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStories)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txbLink
            // 
            this.txbLink.Location = new System.Drawing.Point(3, 3);
            this.txbLink.Margin = new System.Windows.Forms.Padding(4);
            this.txbLink.Name = "txbLink";
            this.txbLink.Size = new System.Drawing.Size(420, 26);
            this.txbLink.TabIndex = 0;
            this.txbLink.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Location = new System.Drawing.Point(430, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(61, 26);
            this.btnStart.TabIndex = 1;
            this.btnStart.TabStop = false;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // rtxbContent
            // 
            this.rtxbContent.DetectUrls = false;
            this.rtxbContent.Location = new System.Drawing.Point(2, 289);
            this.rtxbContent.Name = "rtxbContent";
            this.rtxbContent.ReadOnly = true;
            this.rtxbContent.Size = new System.Drawing.Size(488, 278);
            this.rtxbContent.TabIndex = 2;
            this.rtxbContent.TabStop = false;
            this.rtxbContent.Text = "";
            // 
            // dgvStories
            // 
            this.dgvStories.AllowUserToAddRows = false;
            this.dgvStories.AllowUserToDeleteRows = false;
            this.dgvStories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvStories.Location = new System.Drawing.Point(2, 36);
            this.dgvStories.MultiSelect = false;
            this.dgvStories.Name = "dgvStories";
            this.dgvStories.ReadOnly = true;
            this.dgvStories.RowHeadersVisible = false;
            this.dgvStories.RowTemplate.Height = 28;
            this.dgvStories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStories.Size = new System.Drawing.Size(489, 247);
            this.dgvStories.TabIndex = 3;
            this.dgvStories.TabStop = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "#";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 35;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "TÊN TRUYỆN";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "CHƯƠNG";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "ĐỊA CHỈ LIÊN KẾT";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 183;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbPage);
            this.panel1.Controls.Add(this.lbProcess);
            this.panel1.Controls.Add(this.lbStatus);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 571);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 24);
            this.panel1.TabIndex = 4;
            // 
            // lbPage
            // 
            this.lbPage.Location = new System.Drawing.Point(189, 2);
            this.lbPage.Name = "lbPage";
            this.lbPage.Size = new System.Drawing.Size(129, 19);
            this.lbPage.TabIndex = 2;
            this.lbPage.Text = "Trang: ???/???";
            this.lbPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbProcess
            // 
            this.lbProcess.AutoSize = true;
            this.lbProcess.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbProcess.Location = new System.Drawing.Point(409, 0);
            this.lbProcess.Name = "lbProcess";
            this.lbProcess.Size = new System.Drawing.Size(85, 19);
            this.lbProcess.TabIndex = 1;
            this.lbProcess.Text = "Tìm thấy:???";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbStatus.Location = new System.Drawing.Point(0, 0);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(92, 19);
            this.lbStatus.TabIndex = 0;
            this.lbStatus.Text = "Trạng thái:???";
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 595);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvStories);
            this.Controls.Add(this.rtxbContent);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txbLink);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "fMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[v3.0] Tool leech truyenfull.vn";
            this.Load += new System.EventHandler(this.fMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStories)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}

