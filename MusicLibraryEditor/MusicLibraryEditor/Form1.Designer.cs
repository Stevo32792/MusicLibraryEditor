namespace MusicLibraryEditor
{
    partial class Form1
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
            this.gbFileList = new System.Windows.Forms.GroupBox();
            this.lstFileLIst = new System.Windows.Forms.ListBox();
            this.gbMetadata = new System.Windows.Forms.GroupBox();
            this.picAlbumArt = new System.Windows.Forms.PictureBox();
            this.lstTagList = new System.Windows.Forms.ListBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileBrowser = new System.Windows.Forms.OpenFileDialog();
            this.gbFileList.SuspendLayout();
            this.gbMetadata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAlbumArt)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFileList
            // 
            this.gbFileList.Controls.Add(this.lstFileLIst);
            this.gbFileList.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbFileList.Location = new System.Drawing.Point(0, 24);
            this.gbFileList.Name = "gbFileList";
            this.gbFileList.Size = new System.Drawing.Size(370, 416);
            this.gbFileList.TabIndex = 0;
            this.gbFileList.TabStop = false;
            this.gbFileList.Text = "File List";
            // 
            // lstFileLIst
            // 
            this.lstFileLIst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFileLIst.FormattingEnabled = true;
            this.lstFileLIst.Location = new System.Drawing.Point(3, 16);
            this.lstFileLIst.Name = "lstFileLIst";
            this.lstFileLIst.Size = new System.Drawing.Size(364, 397);
            this.lstFileLIst.TabIndex = 0;
            this.lstFileLIst.SelectedIndexChanged += new System.EventHandler(this.lstFileLIst_SelectedIndexChanged);
            // 
            // gbMetadata
            // 
            this.gbMetadata.Controls.Add(this.picAlbumArt);
            this.gbMetadata.Controls.Add(this.lstTagList);
            this.gbMetadata.Controls.Add(this.txtTitle);
            this.gbMetadata.Controls.Add(this.lblTitle);
            this.gbMetadata.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbMetadata.Location = new System.Drawing.Point(376, 24);
            this.gbMetadata.Name = "gbMetadata";
            this.gbMetadata.Size = new System.Drawing.Size(415, 416);
            this.gbMetadata.TabIndex = 1;
            this.gbMetadata.TabStop = false;
            this.gbMetadata.Text = "Metadata";
            // 
            // picAlbumArt
            // 
            this.picAlbumArt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picAlbumArt.BackColor = System.Drawing.Color.White;
            this.picAlbumArt.Location = new System.Drawing.Point(264, 53);
            this.picAlbumArt.Name = "picAlbumArt";
            this.picAlbumArt.Size = new System.Drawing.Size(110, 107);
            this.picAlbumArt.TabIndex = 0;
            this.picAlbumArt.TabStop = false;
            // 
            // lstTagList
            // 
            this.lstTagList.FormattingEnabled = true;
            this.lstTagList.Location = new System.Drawing.Point(6, 45);
            this.lstTagList.Name = "lstTagList";
            this.lstTagList.Size = new System.Drawing.Size(403, 394);
            this.lstTagList.TabIndex = 2;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(42, 19);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(367, 20);
            this.txtTitle.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(6, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(30, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(791, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFolderToolStripMenuItem,
            this.openFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openFolderToolStripMenuItem.Text = "Open Folder";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.openFolderToolStripMenuItem_Click);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openFileToolStripMenuItem.Text = "Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // FileBrowser
            // 
            this.FileBrowser.FileName = "openFileDialog1";
            this.FileBrowser.Filter = "MP3 File (*.mp3)|*.mp3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 440);
            this.Controls.Add(this.gbMetadata);
            this.Controls.Add(this.gbFileList);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Music Library Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbFileList.ResumeLayout(false);
            this.gbMetadata.ResumeLayout(false);
            this.gbMetadata.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAlbumArt)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFileList;
        private System.Windows.Forms.GroupBox gbMetadata;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListBox lstTagList;
        private System.Windows.Forms.PictureBox picAlbumArt;
        private System.Windows.Forms.ListBox lstFileLIst;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog FileBrowser;
    }
}

