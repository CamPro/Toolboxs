namespace BackupRestoreChromeProfiles
{
    partial class Loading
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.labelError = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.progressBarStatus = new System.Windows.Forms.ProgressBar();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(297, 38);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(13, 13);
            this.labelError.TabIndex = 8;
            this.labelError.Text = "0";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.ForeColor = System.Drawing.Color.Blue;
            this.labelStatus.Location = new System.Drawing.Point(10, 38);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(24, 13);
            this.labelStatus.TabIndex = 7;
            this.labelStatus.Text = "0/0";
            // 
            // progressBarStatus
            // 
            this.progressBarStatus.Location = new System.Drawing.Point(13, 9);
            this.progressBarStatus.Name = "progressBarStatus";
            this.progressBarStatus.Size = new System.Drawing.Size(312, 23);
            this.progressBarStatus.TabIndex = 6;
            // 
            // timerRefresh
            // 
            this.timerRefresh.Interval = 1000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 61);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.progressBarStatus);
            this.Name = "Loading";
            this.Text = "Loading";
            this.Load += new System.EventHandler(this.Loading_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ProgressBar progressBarStatus;
        private System.Windows.Forms.Timer timerRefresh;
    }
}