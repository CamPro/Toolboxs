namespace ExifTools
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
            this.dataGridImage = new System.Windows.Forms.DataGridView();
            this.img_filename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.img_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.img_filepath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonChoseImages = new System.Windows.Forms.Button();
            this.buttonExifCleaner = new System.Windows.Forms.Button();
            this.buttonExifExport = new System.Windows.Forms.Button();
            this.buttonExifImport = new System.Windows.Forms.Button();
            this.buttonOpenFolder = new System.Windows.Forms.Button();
            this.textImportJson = new System.Windows.Forms.TextBox();
            this.buttonOpenExifJson = new System.Windows.Forms.Button();
            this.buttonExifCopyOpen = new System.Windows.Forms.Button();
            this.textExifCopy = new System.Windows.Forms.TextBox();
            this.buttonExifCopy = new System.Windows.Forms.Button();
            this.checkEnable = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridImage)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridImage
            // 
            this.dataGridImage.AllowUserToAddRows = false;
            this.dataGridImage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridImage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.img_filename,
            this.img_status,
            this.img_filepath});
            this.dataGridImage.Location = new System.Drawing.Point(5, 154);
            this.dataGridImage.Name = "dataGridImage";
            this.dataGridImage.ReadOnly = true;
            this.dataGridImage.RowHeadersWidth = 24;
            this.dataGridImage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridImage.Size = new System.Drawing.Size(675, 302);
            this.dataGridImage.TabIndex = 0;
            this.dataGridImage.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridImage_CellDoubleClick);
            // 
            // img_filename
            // 
            this.img_filename.DataPropertyName = "img_filename";
            this.img_filename.HeaderText = "Image Name";
            this.img_filename.Name = "img_filename";
            this.img_filename.ReadOnly = true;
            this.img_filename.Width = 350;
            // 
            // img_status
            // 
            this.img_status.DataPropertyName = "img_status";
            this.img_status.HeaderText = "Status";
            this.img_status.Name = "img_status";
            this.img_status.ReadOnly = true;
            this.img_status.Width = 200;
            // 
            // img_filepath
            // 
            this.img_filepath.DataPropertyName = "img_filepath";
            this.img_filepath.HeaderText = "Filepath";
            this.img_filepath.Name = "img_filepath";
            this.img_filepath.ReadOnly = true;
            this.img_filepath.Width = 500;
            // 
            // buttonChoseImages
            // 
            this.buttonChoseImages.Location = new System.Drawing.Point(5, 5);
            this.buttonChoseImages.Name = "buttonChoseImages";
            this.buttonChoseImages.Size = new System.Drawing.Size(100, 30);
            this.buttonChoseImages.TabIndex = 1;
            this.buttonChoseImages.Text = "Chose images";
            this.buttonChoseImages.UseVisualStyleBackColor = true;
            this.buttonChoseImages.Click += new System.EventHandler(this.buttonChoseImages_Click);
            // 
            // buttonExifCleaner
            // 
            this.buttonExifCleaner.Location = new System.Drawing.Point(5, 41);
            this.buttonExifCleaner.Name = "buttonExifCleaner";
            this.buttonExifCleaner.Size = new System.Drawing.Size(100, 30);
            this.buttonExifCleaner.TabIndex = 2;
            this.buttonExifCleaner.Text = "Exif Cleaner";
            this.buttonExifCleaner.UseVisualStyleBackColor = true;
            this.buttonExifCleaner.Click += new System.EventHandler(this.buttonExifCleaner_Click);
            // 
            // buttonExifExport
            // 
            this.buttonExifExport.Enabled = false;
            this.buttonExifExport.Location = new System.Drawing.Point(111, 41);
            this.buttonExifExport.Name = "buttonExifExport";
            this.buttonExifExport.Size = new System.Drawing.Size(100, 30);
            this.buttonExifExport.TabIndex = 3;
            this.buttonExifExport.Text = "Exif Export";
            this.buttonExifExport.UseVisualStyleBackColor = true;
            this.buttonExifExport.Click += new System.EventHandler(this.buttonExifExport_Click);
            // 
            // buttonExifImport
            // 
            this.buttonExifImport.Enabled = false;
            this.buttonExifImport.Location = new System.Drawing.Point(5, 77);
            this.buttonExifImport.Name = "buttonExifImport";
            this.buttonExifImport.Size = new System.Drawing.Size(100, 30);
            this.buttonExifImport.TabIndex = 4;
            this.buttonExifImport.Text = "Exif Import";
            this.buttonExifImport.UseVisualStyleBackColor = true;
            this.buttonExifImport.Click += new System.EventHandler(this.buttonExifImport_Click);
            // 
            // buttonOpenFolder
            // 
            this.buttonOpenFolder.Location = new System.Drawing.Point(580, 5);
            this.buttonOpenFolder.Name = "buttonOpenFolder";
            this.buttonOpenFolder.Size = new System.Drawing.Size(100, 30);
            this.buttonOpenFolder.TabIndex = 5;
            this.buttonOpenFolder.Text = "Metadatas";
            this.buttonOpenFolder.UseVisualStyleBackColor = true;
            this.buttonOpenFolder.Click += new System.EventHandler(this.buttonOpenFolder_Click);
            // 
            // textImportJson
            // 
            this.textImportJson.Enabled = false;
            this.textImportJson.Location = new System.Drawing.Point(111, 82);
            this.textImportJson.Name = "textImportJson";
            this.textImportJson.Size = new System.Drawing.Size(523, 21);
            this.textImportJson.TabIndex = 6;
            // 
            // buttonOpenExifJson
            // 
            this.buttonOpenExifJson.Enabled = false;
            this.buttonOpenExifJson.Location = new System.Drawing.Point(640, 80);
            this.buttonOpenExifJson.Name = "buttonOpenExifJson";
            this.buttonOpenExifJson.Size = new System.Drawing.Size(40, 24);
            this.buttonOpenExifJson.TabIndex = 8;
            this.buttonOpenExifJson.Text = "...";
            this.buttonOpenExifJson.UseVisualStyleBackColor = true;
            this.buttonOpenExifJson.Click += new System.EventHandler(this.buttonOpenExifJson_Click);
            // 
            // buttonExifCopyOpen
            // 
            this.buttonExifCopyOpen.Location = new System.Drawing.Point(640, 116);
            this.buttonExifCopyOpen.Name = "buttonExifCopyOpen";
            this.buttonExifCopyOpen.Size = new System.Drawing.Size(40, 24);
            this.buttonExifCopyOpen.TabIndex = 11;
            this.buttonExifCopyOpen.Text = "...";
            this.buttonExifCopyOpen.UseVisualStyleBackColor = true;
            this.buttonExifCopyOpen.Click += new System.EventHandler(this.buttonExifCopyOpen_Click);
            // 
            // textExifCopy
            // 
            this.textExifCopy.Location = new System.Drawing.Point(111, 118);
            this.textExifCopy.Name = "textExifCopy";
            this.textExifCopy.Size = new System.Drawing.Size(523, 21);
            this.textExifCopy.TabIndex = 10;
            // 
            // buttonExifCopy
            // 
            this.buttonExifCopy.Location = new System.Drawing.Point(5, 113);
            this.buttonExifCopy.Name = "buttonExifCopy";
            this.buttonExifCopy.Size = new System.Drawing.Size(100, 30);
            this.buttonExifCopy.TabIndex = 9;
            this.buttonExifCopy.Text = "Exif Copy";
            this.buttonExifCopy.UseVisualStyleBackColor = true;
            this.buttonExifCopy.Click += new System.EventHandler(this.buttonExifCopy_Click);
            // 
            // checkEnable
            // 
            this.checkEnable.AutoSize = true;
            this.checkEnable.Location = new System.Drawing.Point(615, 41);
            this.checkEnable.Name = "checkEnable";
            this.checkEnable.Size = new System.Drawing.Size(65, 19);
            this.checkEnable.TabIndex = 12;
            this.checkEnable.Text = "Enable";
            this.checkEnable.UseVisualStyleBackColor = true;
            this.checkEnable.CheckedChanged += new System.EventHandler(this.checkEnable_CheckedChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.checkEnable);
            this.Controls.Add(this.buttonExifCopyOpen);
            this.Controls.Add(this.textExifCopy);
            this.Controls.Add(this.buttonExifCopy);
            this.Controls.Add(this.buttonOpenExifJson);
            this.Controls.Add(this.textImportJson);
            this.Controls.Add(this.buttonOpenFolder);
            this.Controls.Add(this.buttonExifImport);
            this.Controls.Add(this.buttonExifExport);
            this.Controls.Add(this.buttonExifCleaner);
            this.Controls.Add(this.buttonChoseImages);
            this.Controls.Add(this.dataGridImage);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmMain";
            this.Text = "Exif Tools";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridImage;
        private System.Windows.Forms.Button buttonChoseImages;
        private System.Windows.Forms.Button buttonExifCleaner;
        private System.Windows.Forms.DataGridViewTextBoxColumn img_filename;
        private System.Windows.Forms.DataGridViewTextBoxColumn img_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn img_filepath;
        private System.Windows.Forms.Button buttonExifExport;
        private System.Windows.Forms.Button buttonExifImport;
        private System.Windows.Forms.Button buttonOpenFolder;
        private System.Windows.Forms.TextBox textImportJson;
        private System.Windows.Forms.Button buttonOpenExifJson;
        private System.Windows.Forms.Button buttonExifCopyOpen;
        private System.Windows.Forms.TextBox textExifCopy;
        private System.Windows.Forms.Button buttonExifCopy;
        private System.Windows.Forms.CheckBox checkEnable;
    }
}

