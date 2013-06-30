using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using TagLib;
using System.Threading;

namespace MusicLibraryEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.libraryLocation == "" || !Directory.Exists(Properties.Settings.Default.libraryLocation))
            {
                FolderBrowser.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                folderWatcher.Path = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                Properties.Settings.Default.libraryLocation = FolderBrowser.SelectedPath;
                Properties.Settings.Default.Save();
            }
            else
            {
                FolderBrowser.SelectedPath = Properties.Settings.Default.libraryLocation;
                folderWatcher.Path = Properties.Settings.Default.libraryLocation;
            }
            load_directory();
            //Directory.CreateDirectory("C:\\test");
            //if (!System.IO.File.Exists("C:\\test\\hello.mp3"))
            //{
            //    System.IO.File.Copy("C:\\test.mp3", "C:\\test\\hello.mp3");
            //    System.IO.File.Delete("C:\\test.mp3");
            //}
            //else
            //{
            //    MessageBox.Show("File Exists");
            //}
        }

        /* LoadTags will load every tag from the file in filename and add it to lstTagList*/
        private void LoadTags(string filename)
        {
            //lstTagList.Items.Clear();
            //try
            //{
            //    TagLib.File track = TagLib.File.Create(filename);
            //    lstTagList.Items.Add("Album: " + track.Tag.Album);
            //    loadTagArray("AlbumArtist: ", track.Tag.AlbumArtists);
            //    loadTagArray("AlbumArtistSort: ", track.Tag.AlbumArtistsSort);
            //    lstTagList.Items.Add("AlbumSort: " + track.Tag.AlbumSort);
            //    lstTagList.Items.Add("AmazonId: " + track.Tag.AmazonId);
            //    lstTagList.Items.Add("BeatsPerMinute: " + track.Tag.BeatsPerMinute);
            //    lstTagList.Items.Add("Comment: " + track.Tag.Comment);
            //    loadTagArray("Composers: ", track.Tag.Composers);
            //    loadTagArray("ComposersSort: ", track.Tag.ComposersSort);
            //    lstTagList.Items.Add("Conductor: " + track.Tag.Conductor);
            //    lstTagList.Items.Add("Copyright: " + track.Tag.Copyright);
            //    lstTagList.Items.Add("Disc: " + track.Tag.Disc);
            //    lstTagList.Items.Add("DiscCount: " + track.Tag.DiscCount);
            //    loadTagArray("Genres: ", track.Tag.Genres);
            //    lstTagList.Items.Add("Grouping: " + track.Tag.Grouping);
            //    lstTagList.Items.Add("IsEmpty: " + track.Tag.IsEmpty);
            //    lstTagList.Items.Add("Lyrics: " + track.Tag.Lyrics);
            //    lstTagList.Items.Add("MusicBrainzArtistId: " + track.Tag.MusicBrainzArtistId);
            //    lstTagList.Items.Add("MusicBrainzDiscId: " + track.Tag.MusicBrainzDiscId);
            //    lstTagList.Items.Add("MusicBrainzReleaseArtistId: " + track.Tag.MusicBrainzReleaseArtistId);
            //    lstTagList.Items.Add("MusicBrainzReleaseCountry: " + track.Tag.MusicBrainzReleaseCountry);
            //    lstTagList.Items.Add("MusicBrainzReleaseId: " + track.Tag.MusicBrainzReleaseId);
            //    lstTagList.Items.Add("MusicBrainzReleaseStatus: " + track.Tag.MusicBrainzReleaseStatus);
            //    lstTagList.Items.Add("MusicBrainzReleaseType: " + track.Tag.MusicBrainzReleaseType);
            //    lstTagList.Items.Add("MusicBrainzReackId: " + track.Tag.MusicBrainzTrackId);
            //    lstTagList.Items.Add("MusicIpId: " + track.Tag.MusicIpId);
            //    loadTagArray("Performers: ", track.Tag.Performers);
            //    loadTagArray("PerformersSort: ", track.Tag.PerformersSort);
            //    lstTagList.Items.Add("TagTypes: " + track.Tag.TagTypes);
            //    lstTagList.Items.Add("Title: " + track.Tag.Title);
            //    lstTagList.Items.Add("TitleSort: " + track.Tag.TitleSort);
            //    lstTagList.Items.Add("Track: " + track.Tag.Track);
            //    lstTagList.Items.Add("TrackCount: " + track.Tag.TrackCount);
            //    lstTagList.Items.Add("Year: " + track.Tag.Year);

            //    // Global to all methods
            //    System.Drawing.Image currentImage = null;

            //    // In method onclick of the listbox showing all mp3's
            //    if (track.Tag.Pictures.Length > 0)
            //    {
            //        TagLib.IPicture pic = track.Tag.Pictures[0];
            //        MemoryStream ms = new MemoryStream(pic.Data.Data);
            //        if (ms != null && ms.Length > 4096)
            //        {
            //            currentImage = System.Drawing.Image.FromStream(ms);
            //            // Load thumbnail into PictureBox
            //            picAlbumArt.Image = currentImage.GetThumbnailImage(100, 100, null, System.IntPtr.Zero);
            //        }
            //        ms.Close();
            //    }
            //    else
            //    {
            //        picAlbumArt.Image = null;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    lstTagList.Items.Add(ex);
            //}
        }

        private void loadTagArray(string tag, String[] collection)
        {
            string tagString = "";
            foreach (string element in collection)
            {
                tagString += element + "; ";
            }
            tagString = tagString.Trim(new char[] {';', ' '});
        }

        /* Loads files from FolderBrowser into lstFileLIst */
        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = FolderBrowser.ShowDialog();
            if (result == DialogResult.OK)
            {
                load_directory();
            }
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = FileBrowser.ShowDialog();
            if (result == DialogResult.OK)
            {
                load_file();
            }
        }

        /* When file in lstFileLIst is selected, the information from that file is loaded with LoadTags */
        private void lstFileLIst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFileLIst.SelectedItem == null)
            {
            }
            else if (Regex.Match(lstFileLIst.SelectedItem.ToString(), @"File").Groups[0].Value == "File") 
            {
                LoadTags(FolderBrowser.SelectedPath.ToString() + "\\" + lstFileLIst.SelectedItem.ToString().Substring(6));
            }
            else if (Regex.Match(lstFileLIst.SelectedItem.ToString(), @"Folder").Groups[0].Value == "Folder")
            {
                FolderBrowser.SelectedPath = (FolderBrowser.SelectedPath.ToString() + "\\" + lstFileLIst.SelectedItem.ToString().Substring(8));
                load_directory();
            }
            else if (lstFileLIst.SelectedItem.ToString() == "...")
            {
                FolderBrowser.SelectedPath = Directory.GetParent(FolderBrowser.SelectedPath.ToString()).ToString();
                load_directory();
            }
        }

        private void load_directory()
        {
            folderWatcher.Path = FolderBrowser.SelectedPath;
            if (FolderBrowser.SelectedPath.ToString() != "")
            {
                string[] filenames = Directory.GetFiles(FolderBrowser.SelectedPath.ToString());
                string[] folders = Directory.GetDirectories(FolderBrowser.SelectedPath.ToString());
                lstFileLIst.Items.Clear();
                if (Regex.Match(FolderBrowser.SelectedPath.ToString(), @".*\\([^\\]+$)").Groups[1].Value == "")
                {
                }
                else
                {
                    lstFileLIst.Items.Add("...");
                }
                foreach (string folder in folders)
                {
                    lstFileLIst.Items.Add("Folder: " + Regex.Match(folder, @".*\\([^\\]+$)").Groups[1].Value);
                }
                foreach (string filename in filenames)
                {
                    lstFileLIst.Items.Add("File: " + Regex.Match(filename, @".*\\([^\\]+$)").Groups[1].Value);
                }
            }
        }

        private void load_file()
        {

        }

        private void setLibraryFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowser.SelectedPath = Properties.Settings.Default.libraryLocation;
            DialogResult result = FolderBrowser.ShowDialog();
            if (result == DialogResult.OK)
            {
                Properties.Settings.Default.libraryLocation = FolderBrowser.SelectedPath;
            }
            load_directory();
            getLibrary();
        }

        private void getLibrary()
        {
            string[] files = Directory.GetFiles(Properties.Settings.Default.libraryLocation, "*.*", SearchOption.AllDirectories);
            Properties.Settings.Default.libraryFiles.Clear();
            foreach (string element in files)
            {
                Properties.Settings.Default.libraryFiles.Add(element);
            }
            Properties.Settings.Default.Save();
        }

        private void sortMusic()
        {
            folderWatcher.EnableRaisingEvents = false;
            getLibrary();
            int i = Properties.Settings.Default.libraryFiles.Count;
            this.Invoke((MethodInvoker)delegate { formTitleChange("Music Library Editor" + i.ToString()); });
            foreach (string file in Properties.Settings.Default.libraryFiles)
            {
                try
                {
                    if (file.EndsWith(".mp3"))
                    {
                        TagLib.File track = TagLib.File.Create(file);
                        string artists = track.Tag.FirstAlbumArtist;
                        if (artists == "" || artists == null)
                        {
                            artists = "Unknown Artist";
                            this.Invoke((MethodInvoker)delegate { txtConsole.Text = "No Artist for " + file + Environment.NewLine + txtConsole.Text; });
                        }

                        string album = track.Tag.Album;
                        if (album == "" || album == null)
                        {
                            album = "Unknown Album";
                            this.Invoke((MethodInvoker)delegate { txtConsole.Text = "No Album Name for " + file + Environment.NewLine + txtConsole.Text; });
                        }

                        string artistFolder = artists;
                        string albumFolder = album;
                        if (track.Tag.Year.ToString() != "0" && track.Tag.Year.ToString() != "" && track.Tag.Year != null)
                        {
                            albumFolder = album + " (" + track.Tag.Year + ")";
                        }
                        else
                        {
                            this.Invoke((MethodInvoker)delegate { txtConsole.Text = "No Album Year for " + file + Environment.NewLine + txtConsole.Text; });
                        }

                        string fileName = Path.GetFileName(track.Name);
                        if ((track.Tag.Track.ToString() != "0" && track.Tag.Track.ToString() != "" && track.Tag.Track != null) && (track.Tag.Title != "" && track.Tag.Title != null))
                        {
                            fileName = track.Tag.Track.ToString("000") + " - " + track.Tag.Title + ".mp3";
                        }
                        else if (track.Tag.Track.ToString() != "0" && track.Tag.Track.ToString() != "" && track.Tag.Track != null)
                        {
                            fileName = track.Tag.Title + ".mp3";
                            this.Invoke((MethodInvoker)delegate { txtConsole.Text = "No Track Number " + file + Environment.NewLine + txtConsole.Text; });
                        }
                        else
                        {
                            this.Invoke((MethodInvoker)delegate { txtConsole.Text = "No Track Title/Number for " + file + Environment.NewLine + txtConsole.Text; });
                        }

                        string illegal = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());

                        foreach (char c in @illegal)
                        {
                            artistFolder = artistFolder.Replace(c.ToString(), "");
                            albumFolder = albumFolder.Replace(c.ToString(), "");
                            fileName = fileName.Replace(c.ToString(), "");
                        }

                        Directory.CreateDirectory(Properties.Settings.Default.libraryLocation + "\\" + artistFolder);
                        Directory.CreateDirectory(Properties.Settings.Default.libraryLocation + "\\" + artistFolder + "\\" + albumFolder);
                        if (!System.IO.File.Exists(Properties.Settings.Default.libraryLocation + "\\" + artistFolder + "\\" + albumFolder + "\\" + fileName))
                        {
                            System.IO.File.Move(file, Properties.Settings.Default.libraryLocation + "\\" + artistFolder + "\\" + albumFolder + "\\" + fileName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.Invoke((MethodInvoker)delegate { txtConsole.Text = ex + Environment.NewLine + txtConsole.Text; });
                    this.Invoke((MethodInvoker)delegate { txtConsole.Text = "Error moving " + file + Environment.NewLine + txtConsole.Text; });
                }
                i--;
                this.Invoke((MethodInvoker)delegate { formTitleChange("Music Library Editor" + i.ToString()); });
            }
            folderWatcher.EnableRaisingEvents = true;
            this.Invoke((MethodInvoker)delegate { sortFilesToolStripMenuItem.Enabled = true; });
            this.Invoke((MethodInvoker)delegate { setLibraryFolderToolStripMenuItem.Enabled = true; });
            this.Invoke((MethodInvoker)delegate { formTitleChange("Music Library Editor"); });
        }

        private void formTitleChange(string title)
        {
            this.Text = title;
        }

        private void deleteEmptyFolders()
        {
            string[] mp3Folders = Directory.GetDirectories(Properties.Settings.Default.libraryLocation, "*.mp3", SearchOption.AllDirectories);
            string[] allFolders = Directory.GetDirectories(Properties.Settings.Default.libraryLocation, "*.*", SearchOption.AllDirectories);
            ArrayList emptyFolders = new ArrayList();
            foreach (string allFolder in allFolders)
            {
                bool found = false;
                foreach (string mp3Folder in mp3Folders)
                {
                    if (mp3Folder == allFolder)
                    {
                        found = true;
                    }
                }
                if (!found)
                {
                    emptyFolders.Add(allFolder);
                }
            }
            foreach (string emptyFolder in emptyFolders)
            {
                System.IO.Directory.Delete(emptyFolder);
            }
        }

        private void sortFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Sorting Music will Permanently Change Folder Structers, it is Recommended to Backup your Music Before Running this for the First Time!", "Warning!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Cancel || result == DialogResult.No)
            {
                return;
            }
            sortFilesToolStripMenuItem.Enabled = false;
            setLibraryFolderToolStripMenuItem.Enabled = false;
            Thread MusicSort = new Thread(sortMusic);
            MusicSort.Start();
            //deleteEmptyFolders();
            load_directory();
        }

        private void folderWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            load_directory();
        }
    }
}
