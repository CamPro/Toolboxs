namespace HashFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.buttonOpen1 = new System.Windows.Forms.Button();
            this.textHash1 = new System.Windows.Forms.TextBox();
            this.textHash2 = new System.Windows.Forms.TextBox();
            this.buttonOpen2 = new System.Windows.Forms.Button();
            this.textHash3 = new System.Windows.Forms.TextBox();
            this.buttonOpen3 = new System.Windows.Forms.Button();
            this.textHash4 = new System.Windows.Forms.TextBox();
            this.buttonOpen4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonOpen1
            // 
            this.buttonOpen1.Location = new System.Drawing.Point(13, 13);
            this.buttonOpen1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonOpen1.Name = "buttonOpen1";
            this.buttonOpen1.Size = new System.Drawing.Size(202, 30);
            this.buttonOpen1.TabIndex = 0;
            this.buttonOpen1.Text = "Open";
            this.buttonOpen1.UseVisualStyleBackColor = true;
            this.buttonOpen1.Click += new System.EventHandler(this.buttonOpen1_Click);
            // 
            // textHash1
            // 
            this.textHash1.Location = new System.Drawing.Point(222, 17);
            this.textHash1.Name = "textHash1";
            this.textHash1.Size = new System.Drawing.Size(350, 23);
            this.textHash1.TabIndex = 1;
            // 
            // textHash2
            // 
            this.textHash2.Location = new System.Drawing.Point(222, 55);
            this.textHash2.Name = "textHash2";
            this.textHash2.Size = new System.Drawing.Size(350, 23);
            this.textHash2.TabIndex = 3;
            // 
            // buttonOpen2
            // 
            this.buttonOpen2.Location = new System.Drawing.Point(13, 51);
            this.buttonOpen2.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOpen2.Name = "buttonOpen2";
            this.buttonOpen2.Size = new System.Drawing.Size(202, 30);
            this.buttonOpen2.TabIndex = 2;
            this.buttonOpen2.Text = "Open";
            this.buttonOpen2.UseVisualStyleBackColor = true;
            this.buttonOpen2.Click += new System.EventHandler(this.buttonOpen2_Click);
            // 
            // textHash3
            // 
            this.textHash3.Location = new System.Drawing.Point(222, 93);
            this.textHash3.Name = "textHash3";
            this.textHash3.Size = new System.Drawing.Size(350, 23);
            this.textHash3.TabIndex = 5;
            // 
            // buttonOpen3
            // 
            this.buttonOpen3.Location = new System.Drawing.Point(13, 89);
            this.buttonOpen3.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOpen3.Name = "buttonOpen3";
            this.buttonOpen3.Size = new System.Drawing.Size(202, 30);
            this.buttonOpen3.TabIndex = 4;
            this.buttonOpen3.Text = "Open";
            this.buttonOpen3.UseVisualStyleBackColor = true;
            this.buttonOpen3.Click += new System.EventHandler(this.buttonOpen3_Click);
            // 
            // textHash4
            // 
            this.textHash4.Location = new System.Drawing.Point(222, 131);
            this.textHash4.Name = "textHash4";
            this.textHash4.Size = new System.Drawing.Size(350, 23);
            this.textHash4.TabIndex = 7;
            // 
            // buttonOpen4
            // 
            this.buttonOpen4.Location = new System.Drawing.Point(13, 127);
            this.buttonOpen4.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOpen4.Name = "buttonOpen4";
            this.buttonOpen4.Size = new System.Drawing.Size(202, 30);
            this.buttonOpen4.TabIndex = 6;
            this.buttonOpen4.Text = "Open";
            this.buttonOpen4.UseVisualStyleBackColor = true;
            this.buttonOpen4.Click += new System.EventHandler(this.buttonOpen4_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 174);
            this.Controls.Add(this.textHash4);
            this.Controls.Add(this.buttonOpen4);
            this.Controls.Add(this.textHash3);
            this.Controls.Add(this.buttonOpen3);
            this.Controls.Add(this.textHash2);
            this.Controls.Add(this.buttonOpen2);
            this.Controls.Add(this.textHash1);
            this.Controls.Add(this.buttonOpen1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMain";
            this.Text = "Hash File";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmMain_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOpen1;
        private System.Windows.Forms.TextBox textHash1;
        private System.Windows.Forms.TextBox textHash2;
        private System.Windows.Forms.Button buttonOpen2;
        private System.Windows.Forms.TextBox textHash3;
        private System.Windows.Forms.Button buttonOpen3;
        private System.Windows.Forms.TextBox textHash4;
        private System.Windows.Forms.Button buttonOpen4;
    }
}

