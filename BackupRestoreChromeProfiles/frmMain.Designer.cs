namespace BackupRestoreChromeProfiles
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
            this.buttonBackup = new System.Windows.Forms.Button();
            this.buttonRestore = new System.Windows.Forms.Button();
            this.dataGridProfile = new System.Windows.Forms.DataGridView();
            this._stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._profile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._fullpath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textUserdata = new System.Windows.Forms.TextBox();
            this.buttonOpenUserdata = new System.Windows.Forms.Button();
            this.buttonOpenSave = new System.Windows.Forms.Button();
            this.textSave = new System.Windows.Forms.TextBox();
            this.buttonOpenUserdataFolder = new System.Windows.Forms.Button();
            this.buttonOpenSaveFolder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBackup
            // 
            this.buttonBackup.Location = new System.Drawing.Point(12, 12);
            this.buttonBackup.Name = "buttonBackup";
            this.buttonBackup.Size = new System.Drawing.Size(150, 40);
            this.buttonBackup.TabIndex = 6;
            this.buttonBackup.Text = "Backup";
            this.buttonBackup.UseVisualStyleBackColor = true;
            this.buttonBackup.Click += new System.EventHandler(this.buttonBackup_Click);
            // 
            // buttonRestore
            // 
            this.buttonRestore.Location = new System.Drawing.Point(522, 12);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(150, 40);
            this.buttonRestore.TabIndex = 7;
            this.buttonRestore.Text = "Restore";
            this.buttonRestore.UseVisualStyleBackColor = true;
            this.buttonRestore.Click += new System.EventHandler(this.buttonRestore_Click);
            // 
            // dataGridProfile
            // 
            this.dataGridProfile.AllowUserToAddRows = false;
            this.dataGridProfile.AllowUserToDeleteRows = false;
            this.dataGridProfile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProfile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._stt,
            this._profile,
            this._fullpath});
            this.dataGridProfile.Location = new System.Drawing.Point(12, 112);
            this.dataGridProfile.Name = "dataGridProfile";
            this.dataGridProfile.ReadOnly = true;
            this.dataGridProfile.RowHeadersWidth = 24;
            this.dataGridProfile.Size = new System.Drawing.Size(660, 337);
            this.dataGridProfile.TabIndex = 8;
            // 
            // _stt
            // 
            this._stt.DataPropertyName = "_stt";
            this._stt.HeaderText = "STT";
            this._stt.Name = "_stt";
            this._stt.ReadOnly = true;
            this._stt.Width = 50;
            // 
            // _profile
            // 
            this._profile.DataPropertyName = "_profile";
            this._profile.HeaderText = "Profile";
            this._profile.Name = "_profile";
            this._profile.ReadOnly = true;
            this._profile.Width = 150;
            // 
            // _fullpath
            // 
            this._fullpath.DataPropertyName = "_fullpath";
            this._fullpath.HeaderText = "Path";
            this._fullpath.Name = "_fullpath";
            this._fullpath.ReadOnly = true;
            this._fullpath.Width = 425;
            // 
            // textUserdata
            // 
            this.textUserdata.Location = new System.Drawing.Point(12, 58);
            this.textUserdata.Name = "textUserdata";
            this.textUserdata.Size = new System.Drawing.Size(558, 21);
            this.textUserdata.TabIndex = 0;
            // 
            // buttonOpenUserdata
            // 
            this.buttonOpenUserdata.Location = new System.Drawing.Point(632, 57);
            this.buttonOpenUserdata.Name = "buttonOpenUserdata";
            this.buttonOpenUserdata.Size = new System.Drawing.Size(40, 22);
            this.buttonOpenUserdata.TabIndex = 2;
            this.buttonOpenUserdata.Text = ". . .";
            this.buttonOpenUserdata.UseVisualStyleBackColor = true;
            this.buttonOpenUserdata.Click += new System.EventHandler(this.buttonOpenUserdata_Click);
            // 
            // buttonOpenSave
            // 
            this.buttonOpenSave.Location = new System.Drawing.Point(632, 84);
            this.buttonOpenSave.Name = "buttonOpenSave";
            this.buttonOpenSave.Size = new System.Drawing.Size(40, 22);
            this.buttonOpenSave.TabIndex = 5;
            this.buttonOpenSave.Text = ". . .";
            this.buttonOpenSave.UseVisualStyleBackColor = true;
            this.buttonOpenSave.Click += new System.EventHandler(this.buttonOpenSave_Click);
            // 
            // textSave
            // 
            this.textSave.Location = new System.Drawing.Point(12, 85);
            this.textSave.Name = "textSave";
            this.textSave.Size = new System.Drawing.Size(558, 21);
            this.textSave.TabIndex = 3;
            // 
            // buttonOpenUserdataFolder
            // 
            this.buttonOpenUserdataFolder.Location = new System.Drawing.Point(576, 57);
            this.buttonOpenUserdataFolder.Name = "buttonOpenUserdataFolder";
            this.buttonOpenUserdataFolder.Size = new System.Drawing.Size(50, 22);
            this.buttonOpenUserdataFolder.TabIndex = 1;
            this.buttonOpenUserdataFolder.Text = "Open";
            this.buttonOpenUserdataFolder.UseVisualStyleBackColor = true;
            this.buttonOpenUserdataFolder.Click += new System.EventHandler(this.buttonOpenUserdataFolder_Click);
            // 
            // buttonOpenSaveFolder
            // 
            this.buttonOpenSaveFolder.Location = new System.Drawing.Point(576, 84);
            this.buttonOpenSaveFolder.Name = "buttonOpenSaveFolder";
            this.buttonOpenSaveFolder.Size = new System.Drawing.Size(50, 22);
            this.buttonOpenSaveFolder.TabIndex = 4;
            this.buttonOpenSaveFolder.Text = "Open";
            this.buttonOpenSaveFolder.UseVisualStyleBackColor = true;
            this.buttonOpenSaveFolder.Click += new System.EventHandler(this.buttonOpenSaveFolder_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.buttonOpenSaveFolder);
            this.Controls.Add(this.buttonOpenUserdataFolder);
            this.Controls.Add(this.buttonOpenSave);
            this.Controls.Add(this.textSave);
            this.Controls.Add(this.buttonOpenUserdata);
            this.Controls.Add(this.textUserdata);
            this.Controls.Add(this.dataGridProfile);
            this.Controls.Add(this.buttonRestore);
            this.Controls.Add(this.buttonBackup);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmMain";
            this.Text = "Backup and Restore Chrome Profiles";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBackup;
        private System.Windows.Forms.Button buttonRestore;
        private System.Windows.Forms.DataGridView dataGridProfile;
        private System.Windows.Forms.TextBox textUserdata;
        private System.Windows.Forms.Button buttonOpenUserdata;
        private System.Windows.Forms.DataGridViewTextBoxColumn _stt;
        private System.Windows.Forms.DataGridViewTextBoxColumn _profile;
        private System.Windows.Forms.DataGridViewTextBoxColumn _fullpath;
        private System.Windows.Forms.Button buttonOpenSave;
        private System.Windows.Forms.TextBox textSave;
        private System.Windows.Forms.Button buttonOpenUserdataFolder;
        private System.Windows.Forms.Button buttonOpenSaveFolder;
    }
}

