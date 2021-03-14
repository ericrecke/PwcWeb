using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PwcWeb.Models
{
    public class Header
    {
        public string gtfs_realtime_version { get; set; }
        public int incrementality { get; set; }
        public int timestamp { get; set; }
    }

    public class InformedEntity
    {
        public string agency_id { get; set; }
        public string route_id { get; set; }
        public int route_type { get; set; }
        public object trip { get; set; }
        public string stop_id { get; set; }
    }

    public class Translation
    {
        public string text { get; set; }
        public string language { get; set; }
    }

    public class HeaderText
    {
        public IList<Translation> translation { get; set; }
    }

    public class DescriptionText
    {
        public IList<Translation> translation { get; set; }
    }

    public class Alert
    {
        public IList<object> active_period { get; set; }
        public IList<InformedEntity> informed_entity { get; set; }
        public int cause { get; set; }
        public int effect { get; set; }
        public object url { get; set; }
        public HeaderText header_text { get; set; }
        public DescriptionText description_text { get; set; }
    }

    public class Entity
    {
        public string id { get; set; }
        public bool is_deleted { get; set; }
        public object trip_update { get; set; }
        public object vehicle { get; set; }
        public Alert alert { get; set; }
    }

    public class Subtes
    {
        public Header header { get; set; }
        public IList<Entity> entity { get; set; }
    }
    public class SubtesReturn
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Letra { get; set; }
        public string HeaderInfo { get; set; }
        public string DescriptionInfo { get; set; }
        public DateTime Fecha { get; set; }
    }
}
