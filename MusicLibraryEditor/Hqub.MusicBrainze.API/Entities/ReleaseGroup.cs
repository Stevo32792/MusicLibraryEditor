using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Hqub.MusicBrainze.API.Entities.Collections;

namespace Hqub.MusicBrainze.API.Entities
{
    [XmlType(Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    [XmlRoot("release-group", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class ReleaseGroup : Entity
    {
        [XmlAttribute("score", Namespace = "http://musicbrainz.org/ns/ext#-2.0")]
        public int Score { get; set; }

        [XmlAttribute("type")]
        public string ReleaseGroupType { get; set; }

        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("first-release-date")]
        public string FirstReleaseDate { get; set; }

        [XmlElement("primary-type")]
        public string PrimaryType { get; set; }

        [XmlElement("rating")]
        public Rating Rating { get; set; }

        [XmlArray("tag-list")]
        [XmlArrayItem("tag")]
        public TagList Tags { get; set; }

        [XmlArray("release-list")]
        [XmlArrayItem("release")]
        public ReleaseList Releases { get; set; }

        [XmlArray("artist-credit")]
        [XmlArrayItem("name-credit")]
        public List<NameCredit> Credits { get; set; }

        #region Static Methods

        public static ReleaseGroup Get(string id, params string[] inc)
        {
            return Get<ReleaseGroup>(id, WebRequestHelper.CreatLookupUrl(Localization.Constants.ReleaseGroup, id, CreateIncludeQuery(inc)));
        }

        public static Collections.ReleaseGroupList Search(string query, int limit = 25, int offset = 0, params string[] inc)
        {
            return Search<Metadata.ReleaseGroupMetadataWrapper>(Localization.Constants.ReleaseGroup, query, limit, offset, inc).Collection;
        }

        #endregion
    }
}
