using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;
using Hqub.MusicBrainze.API.Entities;

namespace MusicLibraryEditor
{
    public partial class frmAlbumSearch : Form
    {
        public frmAlbumSearch()
        {
            InitializeComponent();
        }

        #region Event Handlers

        /// <summary>
        /// Starts a search for a release group using the searchReleaseGroups Function
        /// </summary>
        /// <param name="sender"> btnSearch </param>
        /// <param name="e"> Button Clicked </param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            /* Create new thread with searchReleaseGroups function */
            Thread releaseGroupSearch = new Thread(searchReleaseGroups);
            releaseGroupSearch.Start();
        }

        /// <summary>
        /// Trigge
        /// rs on selecting a new row in the data grid view.
        /// Selects first row if more than one row is selected.
        /// </summary>
        /// <param name="sender"> dataGridView1 </param>
        /// <param name="e"> Selection Changed </param>
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            /* If there is more than one row selected, select first row */
            if (dataGridView1.SelectedRows.Count > 1)
            {
                /* Get the index of the first row selected */
                int row = dataGridView1.SelectedRows[0].Index;

                /* Clear the selected rows so no row is selected */
                dataGridView1.ClearSelection();

                /* Select the row whose index was saved earlier */
                dataGridView1.Rows[row].Selected = true;
            }
        }

        /// <summary>
        /// Triggers when the select button is clicked.
        /// Starts a new thread to search for releases in the selected relese group.
        /// </summary>
        /// <param name="sender"> btnSelect </param>
        /// <param name="e"> Button Clicked </param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            /* hpbug MBRGID DOES NOT ALWAYS EXIST, MUST SELECT A ROW */

            /* Create a new thread with searchReleases function 
             * Passes in currently selected row's MusicBrainz Release Group ID */
            ThreadStart getReleases = delegate { searchReleases(dataGridView1.SelectedRows[0].Cells["colMBRGID"].Value.ToString()); };
            new Thread(getReleases).Start();
        }

        #endregion

        #region Search Functions

        /// <summary>
        /// Searches input text for release groups
        /// Displays results in dataGridView
        /// </summary>
        private void searchReleaseGroups()
        {
            /* Builds the search string */
            string searchString = buildSearchString();
            /* If there is no search string, stop performing the search */
            if (searchString == "") return;

            /*Call function to populate columns for displaying release groups */
            this.Invoke((MethodInvoker)delegate { setDGVForReleaseGroup(); });

            /* hpbug NEED TO HANDLE BAD REQUESTS */
            /* Perform search for release groups via MusicBrainzAPI */
            var releaseGroups = Hqub.MusicBrainze.API.Entities.ReleaseGroup.Search(searchString, 25, 0, Hqub.MusicBrainze.API.Entities.Include.ArtistIncludeEntityHelper.Recordings);

            /* Create variable for moving through row indexes */
            int row = 0;

            /* Perform code for each result in data from MusicBrainz */
            foreach (var releaseGroup in releaseGroups)
            {
                /* Checks the search score to be higher than a set value 
                 * This filters out bad results and only displays relevant ones */
                if ((int)releaseGroup.Score >= numMinScore.Value)
                {
                    /*hpbug ERRORS OUT IF CLOSED BEFORE OPERATION COMPLETES */

                    /* Adds a new row to the dataGrid View */
                    this.Invoke((MethodInvoker)delegate { dataGridView1.Rows.Add(); });

                    /* Sets row height to 100 to limit width of album art */
                    this.Invoke((MethodInvoker)delegate { dataGridView1.Rows[row].Height = 100; });

                    /* Adds the following pieces of release group information to the dataGridView:
                     *  Score
                     *  Art
                     *  Artist Name
                     *  Album Name
                     *  Music Brainz Release Group ID */
                    this.Invoke((MethodInvoker)delegate { dataGridView1["colScore", row].Value = releaseGroup.Score; });
                    this.Invoke((MethodInvoker)delegate { dataGridView1["colArt", row].Value = getImageFromReleaseGroupID(releaseGroup.Id); });
                    this.Invoke((MethodInvoker)delegate { dataGridView1["colArtist", row].Value = releaseGroup.Credits[0].Artist.Name; });
                    this.Invoke((MethodInvoker)delegate { dataGridView1["colAlbum", row].Value = releaseGroup.Title; });
                    this.Invoke((MethodInvoker)delegate { dataGridView1["colMBRGID", row].Value = releaseGroup.Id; });
                    row++;
                }
            }
        }

        /// <summary>
        /// Searches for release with passed Release Group ID
        /// Displays results in dataGridView
        /// </summary>
        /// <param name="RGID"> MusicBrainz Release Group ID </param>
        private void searchReleases(string RGID = "")
        {
            /* Builds the search string */
            string searchString = "";
            /* If no RGID, search using input boxes */
            if (RGID == "")
            {
                searchString = buildSearchString();
            }
            /* If a RGID exists, search using the RGID */
            else
            {
                searchString = buildSearchString(RGID);
            }
            /* If there is no search string, stop performing the search */
            if (searchString == "") return;

            /*Call function to populate columns for displaying releases */
            this.Invoke((MethodInvoker)delegate { setDGVForRelease(); });

            /* hpbug NEED TO HANDLE BAD REQUESTS */
            /* Perform search for releases via MusicBrainzAPI */
            var releases = Hqub.MusicBrainze.API.Entities.Release.Search(searchString);

            /* Create variable for moving through row indexes */
            int row = 0;

            /* Perform code for each result in data from MusicBrainz */
            foreach (var release in releases)
            {

                /* Checks the search score to be higher than a set value 
                 * This filters out bad results and only displays relevant ones */
                if ((int)release.Score >= numMinScore.Value)
                {

                    /*hpbug ERRORS OUT IF CLOSED BEFORE OPERATION COMPLETES */
                    /* Adds a new row to the dataGrid View */
                    this.Invoke((MethodInvoker)delegate { dataGridView1.Rows.Add(); });

                    /* Sets row height to 100 to limit width of album art */
                    this.Invoke((MethodInvoker)delegate { dataGridView1.Rows[row].Height = 100; });

                    /* Adds the following pieces of release group information to the dataGridView:
                     *  Score
                     *  Art
                     *  Artist Name
                     *  Album Name
                     *  Track Count
                     *  Release Date
                     *  Area of Release
                     *  Label Name
                     *  Format of Release */
                    this.Invoke((MethodInvoker)delegate { dataGridView1["colScore", row].Value = release.Score; });
                    this.Invoke((MethodInvoker)delegate { dataGridView1["colArt", row].Value = getImageFromReleaseID(release.Id); });
                    if (release.Credits.Count > 0)
                        this.Invoke((MethodInvoker)delegate { dataGridView1["colArtist", row].Value = release.Credits[0].Artist.Name; });
                    this.Invoke((MethodInvoker)delegate { dataGridView1["colAlbum", row].Value = release.Title; });
                    this.Invoke((MethodInvoker)delegate { dataGridView1["colDate", row].Value = release.Date; });
                    this.Invoke((MethodInvoker)delegate { dataGridView1["colArea", row].Value = release.Country; });
                    if (release.Labels.Count > 0)
                        this.Invoke((MethodInvoker)delegate { dataGridView1["colLabel", row].Value = release.Labels[0].Label.Name; });
                    /* hpbug NOT GETTING TRACK COUNT INFORMATION, NEEDS CHANGED IN MUSICBRAINZ API */
                    if (release.MediumList.Count > 0)
                    {
                        this.Invoke((MethodInvoker)delegate { dataGridView1["colFormat", row].Value = release.MediumList[0].Format; });
                        this.Invoke((MethodInvoker)delegate { dataGridView1["colTracks", row].Value = release.MediumList[0].Tracks.Count; });
                    }
                    row++;
                }
            }
        }

        /// <summary>
        /// Builds the search string with the input text boxes for querying 
        /// release/release group from artist name and/or release name
        /// </summary>
        /// <returns>
        ///     "release:{release_name}+artist{artist_name}" if given artist and release
        ///     "release:{release_name}" if given release
        ///     "artist:{artist_name}" if given artist
        /// </returns>
        string buildSearchString()
        {
            string searchString = "";

            /* If both an artist and album are entered */
            if (txtAlbum.Text != "" && txtArtist.Text != "")
            {
                /* Create search string which querys for artist and release */
                searchString += "release:" + txtAlbum.Text.Replace(" ", "_").Replace(":","");
                searchString += "+";
                searchString += "artist:" + txtArtist.Text.Replace(" ", "_").Replace(":", "");
            }
            /* If only a release is entered */
            else if (txtAlbum.Text != "" && txtArtist.Text == "")
            {
                /* Create search string which querys for release */
                searchString += "release:" + txtAlbum.Text.Replace(" ", "_").Replace(":", "");
            }
            /* If only an artist is entered */
            else if (txtAlbum.Text == "" && txtArtist.Text != "")
            {
                /* Create search string which querys for artist */
                searchString += "artist:" + txtArtist.Text.Replace(" ", "_").Replace(":", "");
            }
            else
            {
                /* Display an error if no artist nor release is entered */
                MessageBox.Show("Please enter either/both an album or/and artist to search");
                /* Return a blank string to be handled properly in calling function */
                return "";
            }
            return searchString;
        }

        /// <summary>
        /// Builds the search string with the input text boxes for querying 
        /// release from a MusicBrainz Release Group ID
        /// </summary>
        /// <param name="RGID"> MusicBrainz Release Group ID </param>
        /// <returns> "rgid:{release_group_id}" </returns>
        string buildSearchString(string RGID)
        {
            string searchString = "rgid:" + RGID;
            return searchString;
        }

        /// <summary>
        /// Gets the album art thumbnail from Cover Art Archive given MusicBrainz Release ID
        /// </summary>
        /// <param name="releaseID"> Music Brainz Release ID </param>
        /// <returns> 250px Front Album Art Image </returns>
        Image getImageFromReleaseID(string releaseID)
        {
            /* Base webaddress for release Cover Art Archive query */
            string requestBase = @"http://www.coverartarchive.org/release/";

            /* Tailing string for web address to get front cover art thumbnail */
            string requestEnd = @"/front-250.jpg";

            /* Create webrequest with the Request Base, Release ID, and Request End */
            HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(requestBase + releaseID + requestEnd);
            try
            {
                /* Gets response from the web request. Response should be an image */
                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    using (Stream stream = webResponse.GetResponseStream())
                    {
                        /* Returns the image grabbed from Cover Art Archive stream */
                        return Image.FromStream(stream);
                    }
                }
            }

            /* Throws Exception on a bad request response from Cover Art Archive */
            catch (WebException ex)
            {
                /* Returns a stock image from file for no cover art */
                return Image.FromFile("noart.png");
            }
        }

        /// <summary>
        /// Gets the album art thumbnail from Cover Art Archive given MusicBrainz Release Group ID
        /// </summary>
        /// <param name="releaseGroupID"> Music Brainz Release Group ID </param>
        /// <returns> 250px Front Album Art Image </returns>
        Image getImageFromReleaseGroupID(string releaseGroupID)
        {
            /* Base webaddress for release group Cover Art Archive query */
            string requestBase = @"http://www.coverartarchive.org/release-group/";

            /* Tailing string for web address to get front cover art thumbnail */
            string requestEnd = @"/front-250.jpg";

            /* Create webrequest with the Request Base, Release Group ID, and Request End */
            HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(requestBase + releaseGroupID + requestEnd);
            try
            {
                /* Gets response from the web request. Response should be an image */
                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    using (Stream stream = webResponse.GetResponseStream())
                    {
                        /* Returns the image grabbed from Cover Art Archive stream */
                        return Image.FromStream(stream);
                    }
                }
            }

            /* Throws Exception on a bad request response from Cover Art Archive */
            catch (WebException ex)
            {
                /* Returns a stock image from file for no cover art */
                return Image.FromFile("noart.png");
            }
        }

        #endregion

        #region Data Grid View Functions

        /// <summary>
        /// Changes the Data Grid View so that its columns reflect information for releases
        /// Has column for Score, Art, Artist, Album, Track Count, Date, Area, Label, and Format
        /// </summary>
        private void setDGVForRelease()
        {
            /* Clears all the data from the data grid view */
            dataGridView1.Rows.Clear(); 

            /* Deletes all the columns from the data grid view */
            while (dataGridView1.Columns.Count > 0)
            {
                /* Removes columns at index 0 (zero) as there will always be one there */
                dataGridView1.Columns.RemoveAt(0);
            }

            /* Adds the column for Score */
            dataGridView1.Columns.Add("colScore", "Score");

            /* Creates and adds a column for art. Sets the name, text, and image layout */
            DataGridViewImageColumn colArt = new DataGridViewImageColumn();
            colArt.Name = "colArt";
            colArt.HeaderText = "Art";
            colArt.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dataGridView1.Columns.Add(colArt);

            /* Adds the column for Artist */
            dataGridView1.Columns.Add("colArtist", "Artist");

            /* Adds the column for Album */
            dataGridView1.Columns.Add("colAlbum", "Album");

            /* Adds the column for Track Count */
            dataGridView1.Columns.Add("colTracks", "Tracks");

            /* Adds the column for Date */
            dataGridView1.Columns.Add("colDate", "Date");

            /* Adds the column for Area */
            dataGridView1.Columns.Add("colArea", "Area");

            /* Adds the column for Label */
            dataGridView1.Columns.Add("colLabel", "Label");

            /* Adds the column for Format */
            dataGridView1.Columns.Add("colFormat", "Format");

            /* Cycles through each column in the data grid view to change properties on each */
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                /* Sets columns autosize mode to all cells option */
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            /* Changes the autosize mode on the Art column to none as 250px is too large for the grid */
            dataGridView1.Columns["colArt"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
        }

        /// <summary>
        /// Changes the Data Grid View so that its columns reflect information for release groups
        /// Has column for Score, Art, Artist, Album, and MusicBrainz Release Group ID
        /// </summary>
        private void setDGVForReleaseGroup()
        {
            /* Clears all the data from the data grid view */
            dataGridView1.Rows.Clear();

            /* Deletes all the columns from the data grid view */
            while (dataGridView1.Columns.Count > 0)
            {
                /* Removes columns at index 0 (zero) as there will always be one there */
                dataGridView1.Columns.RemoveAt(0);
            }

            /* Adds the column for Score */
            dataGridView1.Columns.Add("colScore", "Score");

            /* Creates and adds a column for art. Sets the name, text, and image layout */
            DataGridViewImageColumn colArt = new DataGridViewImageColumn();
            colArt.Name = "colArt";
            colArt.HeaderText = "Art";
            colArt.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dataGridView1.Columns.Add(colArt);

            /* Adds the column for Artist */
            dataGridView1.Columns.Add("colArtist", "Artist");

            /* Adds the column for Album */
            dataGridView1.Columns.Add("colAlbum", "Album");

            /* Adds the column for MusicBrainz Release Group ID */
            dataGridView1.Columns.Add("colMBRGID", "MusicBrainz ID");

            /* Sets the MusicBrainz Release Group ID column width to 100 to keep the header for expanding */
            dataGridView1.Columns["colMBRGID"].Width = 100;

            /* Cycles through each column in the data grid view to change properties on each */
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                /* Sets columns autosize mode to all cells option */
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            /* Changes the autosize mode on the Art column to none as 250px is too large for the grid */
            dataGridView1.Columns["colArt"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
        }

        #endregion
    }
}