﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Hqub.MusicBrainze.API.Entities
{
    [XmlType(Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    [XmlRoot("release", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class Release : Entity
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("status")]
        public string Status { get; set; }

        [XmlElement("quality")]
        public string Quality { get; set; }

        [XmlElement("text-representation")]
        public TextRepresentation TextRepresentation { get; set; }

        [XmlElement("date")]
        public string Date { get; set; }

        [XmlElement("country")]
        public string Country { get; set; }

        [XmlAttribute("score", Namespace = "http://musicbrainz.org/ns/ext#-2.0")]
        public int Score { get; set; }

        [XmlElement("barcode")]
        public string Barcode { get; set; }

        [XmlElement("release-group")]
        public ReleaseGroup ReleaseGroup { get; set; }

        [XmlElement("cover-art-archive")]
        public CoverArtArchive CoverArtArchive { get; set; }

        #region Subqueries

        [XmlArray("artist-credit")]
        [XmlArrayItem("name-credit")]
        public List<NameCredit> Credits { get; set; }

        [XmlArray("label-info-list")]
        [XmlArrayItem("label-info")]
        public List<LabelInfo> Labels { get; set; }

        [XmlArray("medium-list")]
        [XmlArrayItem("medium")]
        public Collections.MediumList MediumList { get; set; }

        #endregion

        #region Static Methods

        public  static Release Get(string id, params string[] inc)
        {
            return Get<Release>(id, WebRequestHelper.CreatLookupUrl(Localization.Constants.Release, id, CreateIncludeQuery(inc)));
        }

        public static Collections.ReleaseList Search(string query, int limit = 25, int offset = 0, params string[] inc)
        {
            return Search<Metadata.ReleaseMetadataWrapper>(Localization.Constants.Release, query, limit, offset, inc).Collection;
        }

        #endregion
    }

    [XmlType(Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    [XmlRoot("text-representation", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class TextRepresentation
    {
        [XmlElement("language")]
        public string Language { get; set; }

        [XmlElement("Latn")]
        public string Script { get; set; }
    }
}
