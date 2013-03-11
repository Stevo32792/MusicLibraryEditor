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
            this.gbMetadata = new System.Windows.Forms.GroupBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lstTagList = new System.Windows.Forms.ListBox();
            this.picAlbumArt = new System.Windows.Forms.PictureBox();
            this.gbFileList.SuspendLayout();
            this.gbMetadata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAlbumArt)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFileList
            // 
            this.gbFileList.Controls.Add(this.picAlbumArt);
            this.gbFileList.Location = new System.Drawing.Point(12, 12);
            this.gbFileList.Name = "gbFileList";
            this.gbFileList.Size = new System.Drawing.Size(178, 416);
            this.gbFileList.TabIndex = 0;
            this.gbFileList.TabStop = false;
            this.gbFileList.Text = "File List";
            // 
            // gbMetadata
            // 
            this.gbMetadata.Controls.Add(this.lstTagList);
            this.gbMetadata.Controls.Add(this.txtTitle);
            this.gbMetadata.Controls.Add(this.lblTitle);
            this.gbMetadata.Location = new System.Drawing.Point(196, 12);
            this.gbMetadata.Name = "gbMetadata";
            this.gbMetadata.Size = new System.Drawing.Size(415, 416);
            this.gbMetadata.TabIndex = 1;
            this.gbMetadata.TabStop = false;
            this.gbMetadata.Text = "Metadata";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(42, 27);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(367, 20);
            this.txtTitle.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(6, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(30, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title:";
            // 
            // lstTagList
            // 
            this.lstTagList.FormattingEnabled = true;
            this.lstTagList.Location = new System.Drawing.Point(6, 53);
            this.lstTagList.Name = "lstTagList";
            this.lstTagList.Size = new System.Drawing.Size(403, 368);
            this.lstTagList.TabIndex = 2;
            // 
            // picAlbumArt
            // 
            this.picAlbumArt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picAlbumArt.Location = new System.Drawing.Point(6, 231);
            this.picAlbumArt.Name = "picAlbumArt";
            this.picAlbumArt.Size = new System.Drawing.Size(166, 179);
            this.picAlbumArt.TabIndex = 0;
            this.picAlbumArt.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 440);
            this.Controls.Add(this.gbMetadata);
            this.Controls.Add(this.gbFileList);
            this.Name = "Form1";
            this.Text = "Music Library Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbFileList.ResumeLayout(false);
            this.gbMetadata.ResumeLayout(false);
            this.gbMetadata.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAlbumArt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFileList;
        private System.Windows.Forms.GroupBox gbMetadata;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListBox lstTagList;
        private System.Windows.Forms.PictureBox picAlbumArt;
    }
}

