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
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Net;

namespace MusicLibraryEditor
{
    public partial class Form1 : Form
    {
        string openFile = "";

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Triggers when form loads. Loads/sets the default library folder.
        /// </summary>
        /// <param name="sender"> Form1 </param>
        /// <param name="e"> Form Load </param>
        private void Form1_Load(object sender, EventArgs e)
        {
            /* If the libraryLocation is not set (value is blank string) or the location doesn't exist */
            if (Properties.Settings.Default.libraryLocation == "" || !Directory.Exists(Properties.Settings.Default.libraryLocation))
            {
                /* Change the folder browser to the default music path (Userfiles\My Music) */
                FolderBrowser.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

                /* Set the folder watcher to the default music path (Userfiles\My Music) */
                folderWatcher.Path = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

                /* Set the default library location to the selected path of the Folder Browser (Userfiles\My Music) */
                Properties.Settings.Default.libraryLocation = FolderBrowser.SelectedPath;

                /* Save the settings for the default music folder path */
                Properties.Settings.Default.Save();
            }
            
            /* If a default libraryLocation exists, set the folder browser and folder watcher for that path */
            else
            {
                FolderBrowser.SelectedPath = Properties.Settings.Default.libraryLocation;
                folderWatcher.Path = Properties.Settings.Default.libraryLocation;
            }

            /* Call the function to load the directory into the listbox */
            load_directory();
        }

        /// <summary>
        /// Loads the ID3 tags from the file into the metadata viewer.
        /// </summary>
        /// <param name="filename"> Filename to load the tags of </param>
        private void LoadTags(string filename)
        {
            /* Calls function to clear all of the textboxes/numberboxes on the metadata display */
            clearMetadataDisplay();

            /* CLears the open file's filepath as to not accidently overwrite another file's tags */
            openFile = "";

            /* Ensure that the file is an mp3 file */
            if (Path.GetExtension(filename) == ".mp3")
            {
                try
                {
                    /* Get the ID3 tag information from the selected file */
                    TagLib.File track = TagLib.File.Create(filename);

                    /* Set the metadata display information from information in the tag */
                    txtTitle.Text = track.Tag.Title;
                    txtAlbum.Text = track.Tag.Album;
                    txtArtists.Text = loadTagArray(track.Tag.AlbumArtists);
                    txtPerformers.Text = loadTagArray(track.Tag.Performers);
                    txtComposers.Text = loadTagArray(track.Tag.Composers);
                    txtGenre.Text = loadTagArray(track.Tag.Genres);
                    numTrack.Value = track.Tag.Track;
                    numTrackCount.Value = track.Tag.TrackCount;
                    numDisc.Value = track.Tag.Disc;
                    numDiscCount.Value = track.Tag.DiscCount;

                    //    lstTagList.Items.Add("BeatsPerMinute: " + track.Tag.BeatsPerMinute);

                    //    lstTagList.Items.Add("Comment: " + track.Tag.Comment);
                    //    lstTagList.Items.Add("Conductor: " + track.Tag.Conductor);
                    //    lstTagList.Items.Add("Copyright: " + track.Tag.Copyright);
                    //    lstTagList.Items.Add("Lyrics: " + track.Tag.Lyrics);
                    //    lstTagList.Items.Add("Year: " + track.Tag.Year);

                    /* Create a blank image for storing the album art metadata */
                    System.Drawing.Image currentImage = null;

                    /* Check for existance of an image in the tag */
                    if (track.Tag.Pictures.Length > 0)
                    {
                        /* Create a variable to hold the album art */
                        TagLib.IPicture pic = track.Tag.Pictures[0];

                        /* Create a memory stream to convert album art to image */
                        MemoryStream ms = new MemoryStream(pic.Data.Data);

                        if (ms != null && ms.Length > 4096)
                        {
                            /* Read image from memorystream into an image file */
                            currentImage = System.Drawing.Image.FromStream(ms);

                            /* Set the picture box's image to the image from the memory stream */
                            picAlbumArt.Image = currentImage.GetThumbnailImage(100, 100, null, System.IntPtr.Zero);
                        }
                        ms.Close();
                    }
                    else
                    {
                        /* If no image exists, set the image for the picture box as null */
                        picAlbumArt.Image = null;
                    }

                    /* Set the openFile variable so saving tags knows which file is currently open */
                    openFile = filename;
                }
                catch
                {
                    /* Throw an error in the console for the inability to read tags from the file */
                    txtConsole.Text = "Error loading tag info for " + filename + Environment.NewLine + txtConsole.Text;

                    /* Call function to clear the metadata display as information could not be retrieved from file */
                    clearMetadataDisplay();
                }
            }
        }

        /// <summary>
        /// Saves the information in the metadata display to the file's Tags
        /// </summary>
        /// <param name="filename"> Filepath + Filename of open file </param>
        private void saveTags(string filename)
        {
            /* Checks to ensure that the file is an mp3 file and not another file */
            if (Path.GetExtension(filename) == ".mp3")
            {
                try
                {
                    /* Create a taglib track from the passed in filename */
                    TagLib.File track = TagLib.File.Create(filename);

                    /* Modify the tags in the track with the metadata information */
                    /* todo NEED TO SAVE ALL TAG INFORMATION */
                    track.Tag.AlbumArtists = saveTagArray(txtArtists.Text);

                    /* Save the modified tags to the mp3 file */
                    track.Save();
                }
                catch
                {
                    /* If there is an error saving tag info, write it to the console */
                    txtConsole.Text = "Error saving tag info for " + filename + Environment.NewLine + txtConsole.Text;
                }
            }
        }

        /// <summary>
        /// Clears the controls inside of the metadata display
        /// </summary>
        private void clearMetadataDisplay()
        {
            /* Clears the album art display control by setting the value to null */
            picAlbumArt.Image = null;

            /* Cycles through each control in the metadata groupbox and handles each type of control */
            foreach (Control ctrl in gbMetadata.Controls)
            {
                /* If the control is a textbox, set its text to a blank string */
                if (ctrl is System.Windows.Forms.TextBox)
                {
                    ctrl.Text = "";
                }

                /* If the control is a numericUpDown, set its value to zero and set the text to a blank string */
                else if (ctrl is NumericUpDown)
                {
                    /* Create a reference to the numericUpDown to make the value property available */
                    NumericUpDown tempNum = (NumericUpDown)ctrl;
                    tempNum.Value = 0;
                    ctrl.Text = "";
                }
            }
        }

        /// <summary>
        /// Takes a string collection created from a tag and convert it to a single line string
        /// </summary>
        /// <param name="collection"> An array of strings (ex: A collection of album artists) </param>
        /// <returns> A String formatted as "data1; data2; data3" </returns>
        private string loadTagArray(String[] collection)
        {
            string tagString = "";
            /* Write each element in the string array to a string */
            foreach (string element in collection)
            {
                tagString += element + "; ";
            }

            /* Remove the trailing "; " from the string to be returned */
            tagString = tagString.Trim(new char[] { ';', ' ' });
            return tagString;
        }

        /// <summary>
        /// Takes a semicolon or comma separated string and converts it
        /// to a string array for saving to ID3 tags.
        /// </summary>
        /// <param name="items"> The individual items as a comma or semicolon separated string </param>
        /// <returns> String array with the separated values </returns>
        private String[] saveTagArray(string items)
        {
            /* Convert the input string to a string array */
            String[] tagArray = items.Split(new char[] { ';', ',' });
            foreach (string item in tagArray)
            {
                /* Remove the leading and trailing spaces from each item */
                item.Trim(new char[] { ' ' });
            }
            return tagArray;
        }

        /* Loads files from FolderBrowser into lstFileLIst */
        /// <summary>
        /// Triggers when the open folder button is clicked in the menu strip.
        /// Loads a directory into the listbox for browsing.
        /// </summary>
        /// <param name="sender"> openFolderToolStipMenuItem </param>
        /// <param name="e"> Menu Item Click </param>
        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* Ask user to select a folder with the FolderBrowser, get result of selection */
            DialogResult result = FolderBrowser.ShowDialog();

            /* If the user selected a valid folder */
            if (result == DialogResult.OK)
            {
                /* Load the folderBrower's folder into the listbox */
                load_directory();
            }
        }

        /// <summary>
        /// Triggers when the open file button is clicked in the menu strip.
        /// Loads the file's ID3 tags into the metadata display for viewing/editing.
        /// </summary>
        /// <param name="sender"> openFileToolStripMenuItem </param>
        /// <param name="e"> Menu Item Click </param>
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* Ask user to select a file with the FileBrowser, get result of selection */
            DialogResult result = FileBrowser.ShowDialog();

            /* If the user selected a valid file */
            if (result == DialogResult.OK)
            {
                /* Load the fileBrowser's folder into the metadata display */
                load_file();
            }
        }

        /// <summary>
        /// Loads the selected item in the listBox.
        /// If the item is a file, load the file into the metadata viewer.
        /// If the item is a folder, load the folder into the listbox.
        /// If the item is the string "...", load the directory above the 
        ///     currently displayed into the listbox.
        /// </summary>
        private void loadSelectedItem()
        {
            /* Do not do anything if no item is selected */
            if (lstFileLIst.SelectedItem == null)
            {
            }

            /* If the selected item starts with the text "File" */
            else if (Regex.Match(lstFileLIst.SelectedItem.ToString(), @"File").Groups[0].Value == "File")
            {
                /* Load the tags of the selected file. Passes in the path for the file and the filename. */
                LoadTags(FolderBrowser.SelectedPath.ToString() + "\\" + lstFileLIst.SelectedItem.ToString().Substring(6));
            }

            /* If the selected item starts with the text "Folder" */
            else if (Regex.Match(lstFileLIst.SelectedItem.ToString(), @"Folder").Groups[0].Value == "Folder")
            {
                /* Change the FolderBrowser's selected path to the current path + the selected folder */
                FolderBrowser.SelectedPath = (FolderBrowser.SelectedPath.ToString() + "\\" + lstFileLIst.SelectedItem.ToString().Substring(8));

                /* Load the new selected path for the FolderBrowser into the listbox */
                load_directory();
            }

            /* If the selected item is the string "..." */
            else if (lstFileLIst.SelectedItem.ToString() == "...")
            {
                /* Sets the FolderBrowser's selected path to the parent folder of the currently selected path */
                FolderBrowser.SelectedPath = Directory.GetParent(FolderBrowser.SelectedPath.ToString()).ToString();

                /* Load hte new selected path for the FolderBrowserinto the listbox */
                load_directory();
            }
        }

        /// <summary>
        /// Loads the FolderBrowser
        /// </summary>
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
                            if (track.Tag.FirstPerformer == "" || track.Tag.FirstPerformer == null)
                            {
                                artists = track.Tag.FirstPerformer;
                                this.Invoke((MethodInvoker)delegate { txtConsole.Text = "Performer was used for artist for " + file + Environment.NewLine + txtConsole.Text; });
                            }
                            else
                            {
                                artists = "Unknown Artist";
                                this.Invoke((MethodInvoker)delegate { txtConsole.Text = "No Artist for " + file + Environment.NewLine + txtConsole.Text; });
                            }
                        }

                        string album = track.Tag.Album;
                        if (album == "" || album == null)
                        {
                            album = "Unknown Album";
                            this.Invoke((MethodInvoker)delegate { txtConsole.Text = "No Album Name for " + file + Environment.NewLine + txtConsole.Text; });
                        }

                        string artistFolder = artists;
                        string albumFolder = album;
                        if (track.Tag.Year.ToString() != "0" && track.Tag.Year.ToString() != "")
                        {
                            albumFolder = album + " (" + track.Tag.Year + ")";
                        }
                        else
                        {
                            this.Invoke((MethodInvoker)delegate { txtConsole.Text = "No Album Year for " + file + Environment.NewLine + txtConsole.Text; });
                        }

                        string fileName = Path.GetFileName(track.Name);
                        if ((track.Tag.Track.ToString() != "0" && track.Tag.Track.ToString() != "") && (track.Tag.Title != "" && track.Tag.Title != null))
                        {
                            fileName = track.Tag.Track.ToString("000") + " - " + track.Tag.Title + ".mp3";
                        }
                        else if (track.Tag.Track.ToString() != "0" && track.Tag.Track.ToString() != "")
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

        private void saveTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveTags(openFile);
            LoadTags(openFile);
        }

        private void lstFileLIst_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (lstFileLIst.SelectedIndex == -1)
                {
                    lstFileLIst.SelectedIndex = 1;
                    e.SuppressKeyPress = true;
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                loadSelectedItem();
            }
        }

        private void lstFileLIst_MouseUp(object sender, MouseEventArgs e)
        {
            loadSelectedItem();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmAlbumSearch frmAlbumSearch = new frmAlbumSearch();
            frmAlbumSearch.txtArtist.Text = txtArtists.Text;
            frmAlbumSearch.txtAlbum.Text = txtAlbum.Text;
            frmAlbumSearch.Show();
        }
    }
}