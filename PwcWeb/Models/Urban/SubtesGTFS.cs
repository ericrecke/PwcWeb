using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PwcWeb.Models
{
    public class HeaderGTFS
    {
        public int timestamp { get; set; }
    }

    public class Arrival
    {
        public int time { get; set; }
        public int delay { get; set; }
    }

    public class Departure
    {
        public int time { get; set; }
        public int delay { get; set; }
    }

    public class Estacione
    {
        public string stop_id { get; set; }
        public string stop_name { get; set; }
        public Arrival arrival { get; set; }
        public Departure departure { get; set; }
    }

    public class Linea
    {
        public string Trip_Id { get; set; }
        public string Route_Id { get; set; }
        public int Direction_ID { get; set; }
        public string start_time { get; set; }
        public string start_date { get; set; }
        public IList<Estacione> Estaciones { get; set; }
    }

    public class EntityGTFS
    {
        public string ID { get; set; }
        public Linea Linea { get; set; }
    }

    public class SubtesGTFS
    {
        public HeaderGTFS Header { get; set; }
        public IList<EntityGTFS> Entity { get; set; }
    }
}
