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
            this.lblComposers = new System.Windows.Forms.Label();
            this.txtComposers = new System.Windows.Forms.TextBox();
            this.lblGenre = new System.Windows.Forms.Label();
            this.txtGenre = new System.Windows.Forms.TextBox();
            this.numDiscCount = new System.Windows.Forms.NumericUpDown();
            this.numDisc = new System.Windows.Forms.NumericUpDown();
            this.lblDiscCount = new System.Windows.Forms.Label();
            this.lblDisc = new System.Windows.Forms.Label();
            this.numTrackCount = new System.Windows.Forms.NumericUpDown();
            this.numTrack = new System.Windows.Forms.NumericUpDown();
            this.lblTrackCount = new System.Windows.Forms.Label();
            this.lblTrack = new System.Windows.Forms.Label();
            this.txtPerformers = new System.Windows.Forms.TextBox();
            this.lblPerformers = new System.Windows.Forms.Label();
            this.txtArtists = new System.Windows.Forms.TextBox();
            this.lblArtists = new System.Windows.Forms.Label();
            this.txtAlbum = new System.Windows.Forms.TextBox();
            this.lblAlbum = new System.Windows.Forms.Label();
            this.picAlbumArt = new System.Windows.Forms.PictureBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setLibraryFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileBrowser = new System.Windows.Forms.OpenFileDialog();
            this.folderWatcher = new System.IO.FileSystemWatcher();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpEditor = new System.Windows.Forms.TabPage();
            this.tpConsole = new System.Windows.Forms.TabPage();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.saveTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbFileList.SuspendLayout();
            this.gbMetadata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDisc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTrackCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAlbumArt)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.folderWatcher)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tpEditor.SuspendLayout();
            this.tpConsole.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFileList
            // 
            this.gbFileList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbFileList.Controls.Add(this.lstFileLIst);
            this.gbFileList.Location = new System.Drawing.Point(8, 6);
            this.gbFileList.Name = "gbFileList";
            this.gbFileList.Size = new System.Drawing.Size(381, 376);
            this.gbFileList.TabIndex = 0;
            this.gbFileList.TabStop = false;
            this.gbFileList.Text = "File List";
            // 
            // lstFileLIst
            // 
            this.lstFileLIst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFileLIst.FormattingEnabled = true;
            this.lstFileLIst.IntegralHeight = false;
            this.lstFileLIst.Location = new System.Drawing.Point(0, 16);
            this.lstFileLIst.Name = "lstFileLIst";
            this.lstFileLIst.Size = new System.Drawing.Size(381, 360);
            this.lstFileLIst.TabIndex = 0;
            this.lstFileLIst.SelectedIndexChanged += new System.EventHandler(this.lstFileLIst_SelectedIndexChanged);
            this.lstFileLIst.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstFileLIst_KeyDown);
            this.lstFileLIst.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstFileLIst_MouseUp);
            // 
            // gbMetadata
            // 
            this.gbMetadata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMetadata.Controls.Add(this.lblComposers);
            this.gbMetadata.Controls.Add(this.txtComposers);
            this.gbMetadata.Controls.Add(this.lblGenre);
            this.gbMetadata.Controls.Add(this.txtGenre);
            this.gbMetadata.Controls.Add(this.numDiscCount);
            this.gbMetadata.Controls.Add(this.numDisc);
            this.gbMetadata.Controls.Add(this.lblDiscCount);
            this.gbMetadata.Controls.Add(this.lblDisc);
            this.gbMetadata.Controls.Add(this.numTrackCount);
            this.gbMetadata.Controls.Add(this.numTrack);
            this.gbMetadata.Controls.Add(this.lblTrackCount);
            this.gbMetadata.Controls.Add(this.lblTrack);
            this.gbMetadata.Controls.Add(this.txtPerformers);
            this.gbMetadata.Controls.Add(this.lblPerformers);
            this.gbMetadata.Controls.Add(this.txtArtists);
            this.gbMetadata.Controls.Add(this.lblArtists);
            this.gbMetadata.Controls.Add(this.txtAlbum);
            this.gbMetadata.Controls.Add(this.lblAlbum);
            this.gbMetadata.Controls.Add(this.picAlbumArt);
            this.gbMetadata.Controls.Add(this.txtTitle);
            this.gbMetadata.Controls.Add(this.lblTitle);
            this.gbMetadata.Location = new System.Drawing.Point(392, 6);
            this.gbMetadata.Name = "gbMetadata";
            this.gbMetadata.Size = new System.Drawing.Size(447, 376);
            this.gbMetadata.TabIndex = 1;
            this.gbMetadata.TabStop = false;
            this.gbMetadata.Text = "Metadata";
            // 
            // lblComposers
            // 
            this.lblComposers.AutoSize = true;
            this.lblComposers.Location = new System.Drawing.Point(6, 126);
            this.lblComposers.Name = "lblComposers";
            this.lblComposers.Size = new System.Drawing.Size(62, 13);
            this.lblComposers.TabIndex = 20;
            this.lblComposers.Text = "Composers:";
            // 
            // txtComposers
            // 
            this.txtComposers.Location = new System.Drawing.Point(72, 123);
            this.txtComposers.Name = "txtComposers";
            this.txtComposers.Size = new System.Drawing.Size(253, 20);
            this.txtComposers.TabIndex = 19;
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(6, 152);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(39, 13);
            this.lblGenre.TabIndex = 18;
            this.lblGenre.Text = "Genre:";
            // 
            // txtGenre
            // 
            this.txtGenre.Location = new System.Drawing.Point(72, 149);
            this.txtGenre.Name = "txtGenre";
            this.txtGenre.Size = new System.Drawing.Size(253, 20);
            this.txtGenre.TabIndex = 17;
            // 
            // numDiscCount
            // 
            this.numDiscCount.Location = new System.Drawing.Point(370, 339);
            this.numDiscCount.Name = "numDiscCount";
            this.numDiscCount.Size = new System.Drawing.Size(54, 20);
            this.numDiscCount.TabIndex = 16;
            // 
            // numDisc
            // 
            this.numDisc.Location = new System.Drawing.Point(253, 339);
            this.numDisc.Name = "numDisc";
            this.numDisc.Size = new System.Drawing.Size(54, 20);
            this.numDisc.TabIndex = 15;
            // 
            // lblDiscCount
            // 
            this.lblDiscCount.AutoSize = true;
            this.lblDiscCount.Location = new System.Drawing.Point(309, 341);
            this.lblDiscCount.Name = "lblDiscCount";
            this.lblDiscCount.Size = new System.Drawing.Size(62, 13);
            this.lblDiscCount.TabIndex = 14;
            this.lblDiscCount.Text = "Disc Count:";
            // 
            // lblDisc
            // 
            this.lblDisc.AutoSize = true;
            this.lblDisc.Location = new System.Drawing.Point(223, 341);
            this.lblDisc.Name = "lblDisc";
            this.lblDisc.Size = new System.Drawing.Size(31, 13);
            this.lblDisc.TabIndex = 13;
            this.lblDisc.Text = "Disc:";
            // 
            // numTrackCount
            // 
            this.numTrackCount.Location = new System.Drawing.Point(167, 339);
            this.numTrackCount.Name = "numTrackCount";
            this.numTrackCount.Size = new System.Drawing.Size(54, 20);
            this.numTrackCount.TabIndex = 12;
            // 
            // numTrack
            // 
            this.numTrack.Location = new System.Drawing.Point(43, 339);
            this.numTrack.Name = "numTrack";
            this.numTrack.Size = new System.Drawing.Size(54, 20);
            this.numTrack.TabIndex = 11;
            // 
            // lblTrackCount
            // 
            this.lblTrackCount.AutoSize = true;
            this.lblTrackCount.Location = new System.Drawing.Point(99, 341);
            this.lblTrackCount.Name = "lblTrackCount";
            this.lblTrackCount.Size = new System.Drawing.Size(69, 13);
            this.lblTrackCount.TabIndex = 10;
            this.lblTrackCount.Text = "Track Count:";
            // 
            // lblTrack
            // 
            this.lblTrack.AutoSize = true;
            this.lblTrack.Location = new System.Drawing.Point(6, 341);
            this.lblTrack.Name = "lblTrack";
            this.lblTrack.Size = new System.Drawing.Size(38, 13);
            this.lblTrack.TabIndex = 8;
            this.lblTrack.Text = "Track:";
            // 
            // txtPerformers
            // 
            this.txtPerformers.Location = new System.Drawing.Point(72, 97);
            this.txtPerformers.Name = "txtPerformers";
            this.txtPerformers.Size = new System.Drawing.Size(253, 20);
            this.txtPerformers.TabIndex = 7;
            // 
            // lblPerformers
            // 
            this.lblPerformers.AutoSize = true;
            this.lblPerformers.Location = new System.Drawing.Point(6, 100);
            this.lblPerformers.Name = "lblPerformers";
            this.lblPerformers.Size = new System.Drawing.Size(60, 13);
            this.lblPerformers.TabIndex = 6;
            this.lblPerformers.Text = "Performers:";
            // 
            // txtArtists
            // 
            this.txtArtists.Location = new System.Drawing.Point(72, 71);
            this.txtArtists.Name = "txtArtists";
            this.txtArtists.Size = new System.Drawing.Size(253, 20);
            this.txtArtists.TabIndex = 5;
            // 
            // lblArtists
            // 
            this.lblArtists.AutoSize = true;
            this.lblArtists.Location = new System.Drawing.Point(6, 74);
            this.lblArtists.Name = "lblArtists";
            this.lblArtists.Size = new System.Drawing.Size(38, 13);
            this.lblArtists.TabIndex = 4;
            this.lblArtists.Text = "Artists:";
            // 
            // txtAlbum
            // 
            this.txtAlbum.Location = new System.Drawing.Point(72, 45);
            this.txtAlbum.Name = "txtAlbum";
            this.txtAlbum.Size = new System.Drawing.Size(253, 20);
            this.txtAlbum.TabIndex = 3;
            // 
            // lblAlbum
            // 
            this.lblAlbum.AutoSize = true;
            this.lblAlbum.Location = new System.Drawing.Point(6, 48);
            this.lblAlbum.Name = "lblAlbum";
            this.lblAlbum.Size = new System.Drawing.Size(39, 13);
            this.lblAlbum.TabIndex = 2;
            this.lblAlbum.Text = "Album:";
            // 
            // picAlbumArt
            // 
            this.picAlbumArt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picAlbumArt.BackColor = System.Drawing.Color.White;
            this.picAlbumArt.Location = new System.Drawing.Point(331, 19);
            this.picAlbumArt.Name = "picAlbumArt";
            this.picAlbumArt.Size = new System.Drawing.Size(110, 107);
            this.picAlbumArt.TabIndex = 0;
            this.picAlbumArt.TabStop = false;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(72, 19);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(253, 20);
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
            this.fileToolStripMenuItem,
            this.saveTagToolStripMenuItem,
            this.sortFilesToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(853, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFolderToolStripMenuItem,
            this.openFileToolStripMenuItem,
            this.setLibraryFolderToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.openFolderToolStripMenuItem.Text = "Open Folder";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.openFolderToolStripMenuItem_Click);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.openFileToolStripMenuItem.Text = "Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // setLibraryFolderToolStripMenuItem
            // 
            this.setLibraryFolderToolStripMenuItem.Name = "setLibraryFolderToolStripMenuItem";
            this.setLibraryFolderToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.setLibraryFolderToolStripMenuItem.Text = "Set Library Folder";
            this.setLibraryFolderToolStripMenuItem.Click += new System.EventHandler(this.setLibraryFolderToolStripMenuItem_Click);
            // 
            // sortFilesToolStripMenuItem
            // 
            this.sortFilesToolStripMenuItem.Name = "sortFilesToolStripMenuItem";
            this.sortFilesToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.sortFilesToolStripMenuItem.Text = "Sort Files";
            this.sortFilesToolStripMenuItem.Click += new System.EventHandler(this.sortFilesToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // FileBrowser
            // 
            this.FileBrowser.FileName = "openFileDialog1";
            this.FileBrowser.Filter = "MP3 File (*.mp3)|*.mp3";
            // 
            // folderWatcher
            // 
            this.folderWatcher.EnableRaisingEvents = true;
            this.folderWatcher.IncludeSubdirectories = true;
            this.folderWatcher.SynchronizingObject = this;
            this.folderWatcher.Changed += new System.IO.FileSystemEventHandler(this.folderWatcher_Changed);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpEditor);
            this.tabControl1.Controls.Add(this.tpConsole);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(853, 416);
            this.tabControl1.TabIndex = 3;
            // 
            // tpEditor
            // 
            this.tpEditor.Controls.Add(this.gbFileList);
            this.tpEditor.Controls.Add(this.gbMetadata);
            this.tpEditor.Location = new System.Drawing.Point(4, 22);
            this.tpEditor.Name = "tpEditor";
            this.tpEditor.Padding = new System.Windows.Forms.Padding(3);
            this.tpEditor.Size = new System.Drawing.Size(845, 390);
            this.tpEditor.TabIndex = 0;
            this.tpEditor.Text = "Editor";
            this.tpEditor.UseVisualStyleBackColor = true;
            // 
            // tpConsole
            // 
            this.tpConsole.Controls.Add(this.txtConsole);
            this.tpConsole.Location = new System.Drawing.Point(4, 22);
            this.tpConsole.Name = "tpConsole";
            this.tpConsole.Padding = new System.Windows.Forms.Padding(3);
            this.tpConsole.Size = new System.Drawing.Size(845, 390);
            this.tpConsole.TabIndex = 1;
            this.tpConsole.Text = "Console";
            this.tpConsole.UseVisualStyleBackColor = true;
            // 
            // txtConsole
            // 
            this.txtConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConsole.Location = new System.Drawing.Point(3, 3);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConsole.Size = new System.Drawing.Size(839, 384);
            this.txtConsole.TabIndex = 0;
            // 
            // saveTagToolStripMenuItem
            // 
            this.saveTagToolStripMenuItem.Name = "saveTagToolStripMenuItem";
            this.saveTagToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.saveTagToolStripMenuItem.Text = "Save Tag";
            this.saveTagToolStripMenuItem.Click += new System.EventHandler(this.saveTagToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 440);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Music Library Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbFileList.ResumeLayout(false);
            this.gbMetadata.ResumeLayout(false);
            this.gbMetadata.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDisc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTrackCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAlbumArt)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.folderWatcher)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tpEditor.ResumeLayout(false);
            this.tpConsole.ResumeLayout(false);
            this.tpConsole.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFileList;
        private System.Windows.Forms.GroupBox gbMetadata;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox picAlbumArt;
        private System.Windows.Forms.ListBox lstFileLIst;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog FileBrowser;
        private System.Windows.Forms.ToolStripMenuItem setLibraryFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortFilesToolStripMenuItem;
        private System.IO.FileSystemWatcher folderWatcher;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpEditor;
        private System.Windows.Forms.TabPage tpConsole;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.NumericUpDown numDiscCount;
        private System.Windows.Forms.NumericUpDown numDisc;
        private System.Windows.Forms.Label lblDiscCount;
        private System.Windows.Forms.Label lblDisc;
        private System.Windows.Forms.NumericUpDown numTrackCount;
        private System.Windows.Forms.NumericUpDown numTrack;
        private System.Windows.Forms.Label lblTrackCount;
        private System.Windows.Forms.Label lblTrack;
        private System.Windows.Forms.TextBox txtPerformers;
        private System.Windows.Forms.Label lblPerformers;
        private System.Windows.Forms.TextBox txtArtists;
        private System.Windows.Forms.Label lblArtists;
        private System.Windows.Forms.TextBox txtAlbum;
        private System.Windows.Forms.Label lblAlbum;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.TextBox txtGenre;
        private System.Windows.Forms.Label lblComposers;
        private System.Windows.Forms.TextBox txtComposers;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveTagToolStripMenuItem;
    }
}

