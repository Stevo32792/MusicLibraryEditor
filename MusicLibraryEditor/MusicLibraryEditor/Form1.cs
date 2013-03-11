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
using TagLib;

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
            LoadTags();
        }
        private void LoadTags()
        {
            TagLib.File track = TagLib.File.Create("test.mp3");
            lstTagList.Items.Add("Album: " + track.Tag.Album);
            lstTagList.Items.Add("AlbumArtist: " + track.Tag.AlbumArtists);
            lstTagList.Items.Add("AlbumArtistSort: " + track.Tag.AlbumArtistsSort);
            lstTagList.Items.Add("AlbumSort: " + track.Tag.AlbumSort);
            lstTagList.Items.Add("AmazonId: " + track.Tag.AmazonId);
            lstTagList.Items.Add("BeatsPerMinute: " + track.Tag.BeatsPerMinute);
            lstTagList.Items.Add("Comment: " + track.Tag.Comment);
            lstTagList.Items.Add("Composers: " + track.Tag.Composers);
            lstTagList.Items.Add("ComposersSort: " + track.Tag.ComposersSort);
            lstTagList.Items.Add("Conductor: " + track.Tag.Conductor);
            lstTagList.Items.Add("Copyright: " + track.Tag.Copyright);
            lstTagList.Items.Add("Disc: " + track.Tag.Disc);
            lstTagList.Items.Add("DiscCount: " + track.Tag.DiscCount);
            lstTagList.Items.Add("FirstAlbumArtist: " + track.Tag.FirstAlbumArtist);
            lstTagList.Items.Add("FirstAlbumArtistSort: " + track.Tag.FirstAlbumArtistSort);
            lstTagList.Items.Add("FirstComposer: " + track.Tag.FirstComposer);
            lstTagList.Items.Add("FirstComposerSort: " + track.Tag.FirstComposerSort);
            lstTagList.Items.Add("FirstGenre: " + track.Tag.FirstGenre);
            lstTagList.Items.Add("FirstPerformer: " + track.Tag.FirstPerformer);
            lstTagList.Items.Add("FirstPerformerSort: " + track.Tag.FirstPerformerSort);
            lstTagList.Items.Add("Genres: " + track.Tag.Genres);
            lstTagList.Items.Add("Grouping: " + track.Tag.Grouping);
            lstTagList.Items.Add("IsEmpty: " + track.Tag.IsEmpty);
            lstTagList.Items.Add("JoinedAlbumArtists: " + track.Tag.JoinedAlbumArtists);
            lstTagList.Items.Add("JoinedComposers: " + track.Tag.JoinedComposers);
            lstTagList.Items.Add("JoinedGenres: " + track.Tag.JoinedGenres);
            lstTagList.Items.Add("JoinedPerformers: " + track.Tag.JoinedPerformers);
            lstTagList.Items.Add("JoinedPerformersSort: " + track.Tag.JoinedPerformersSort);
            lstTagList.Items.Add("Lyrics: " + track.Tag.Lyrics);
            lstTagList.Items.Add("MusicBrainzArtistId: " + track.Tag.MusicBrainzArtistId);
            lstTagList.Items.Add("MusicBrainzDiscId: " + track.Tag.MusicBrainzDiscId);
            lstTagList.Items.Add("MusicBrainzReleaseArtistId: " + track.Tag.MusicBrainzReleaseArtistId);
            lstTagList.Items.Add("MusicBrainzReleaseCountry: " + track.Tag.MusicBrainzReleaseCountry);
            lstTagList.Items.Add("MusicBrainzReleaseId: " + track.Tag.MusicBrainzReleaseId);
            lstTagList.Items.Add("MusicBrainzReleaseStatus: " + track.Tag.MusicBrainzReleaseStatus);
            lstTagList.Items.Add("MusicBrainzReleaseType: " + track.Tag.MusicBrainzReleaseType);
            lstTagList.Items.Add("MusicBrainzReackId: " + track.Tag.MusicBrainzTrackId);
            lstTagList.Items.Add("MusicIpId: " + track.Tag.MusicIpId);
            lstTagList.Items.Add("Performers: " + track.Tag.Performers);
            lstTagList.Items.Add("PerformersSort: " + track.Tag.PerformersSort);
            lstTagList.Items.Add("TagTypes: " + track.Tag.TagTypes);
            lstTagList.Items.Add("Title: " + track.Tag.Title);
            lstTagList.Items.Add("TitleSort: " + track.Tag.TitleSort);
            lstTagList.Items.Add("Track: " + track.Tag.Track);
            lstTagList.Items.Add("TrackCount: " + track.Tag.TrackCount);
            lstTagList.Items.Add("Year: " + track.Tag.Year);

            // Global to all methods
            System.Drawing.Image currentImage = null;

            // In method onclick of the listbox showing all mp3's
            if (track.Tag.Pictures.Length > 0)
            {
                TagLib.IPicture pic = track.Tag.Pictures[0];
                MemoryStream ms = new MemoryStream(pic.Data.Data);
                if (ms != null && ms.Length > 4096)
                {
                    currentImage = System.Drawing.Image.FromStream(ms);
                    // Load thumbnail into PictureBox
                    picAlbumArt.Image = currentImage.GetThumbnailImage(100, 100, null, System.IntPtr.Zero);
                }
                ms.Close();
            }
        }
    }
}
