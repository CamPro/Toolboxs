namespace ActiveSublime
{
    partial class frmMain
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
            this.buttonForBuild4169 = new System.Windows.Forms.Button();
            this.buttonForBuild4180 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonForBuild4169
            // 
            this.buttonForBuild4169.Location = new System.Drawing.Point(13, 61);
            this.buttonForBuild4169.Margin = new System.Windows.Forms.Padding(4);
            this.buttonForBuild4169.Name = "buttonForBuild4169";
            this.buttonForBuild4169.Size = new System.Drawing.Size(176, 40);
            this.buttonForBuild4169.TabIndex = 1;
            this.buttonForBuild4169.Text = "for Build 4169 to lower";
            this.buttonForBuild4169.UseVisualStyleBackColor = true;
            this.buttonForBuild4169.Click += new System.EventHandler(this.buttonForBuild4169_Click);
            // 
            // buttonForBuild4180
            // 
            this.buttonForBuild4180.Location = new System.Drawing.Point(13, 13);
            this.buttonForBuild4180.Margin = new System.Windows.Forms.Padding(4);
            this.buttonForBuild4180.Name = "buttonForBuild4180";
            this.buttonForBuild4180.Size = new System.Drawing.Size(176, 40);
            this.buttonForBuild4180.TabIndex = 0;
            this.buttonForBuild4180.Text = "for Build 4180 to 4192";
            this.buttonForBuild4180.UseVisualStyleBackColor = true;
            this.buttonForBuild4180.Click += new System.EventHandler(this.buttonForBuild4180_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 106);
            this.Controls.Add(this.buttonForBuild4180);
            this.Controls.Add(this.buttonForBuild4169);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "Active SublimeText";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonForBuild4169;
        private System.Windows.Forms.Button buttonForBuild4180;
    }
}

