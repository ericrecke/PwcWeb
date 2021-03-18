using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PwcWeb.Models
{

    //This Models are going to be used to get Json Info bringed by The Api
    public class HeaderGTFS
    {
        public int timestamp { get; set; }
    }

    public class Arrival
    {
        public int time { get; set; }
        public DateTime Fecha { get; set; }
        public int delay { get; set; }
    }

    public class Departure
    {
        public int time { get; set; }
        public DateTime Fecha { get; set; }
        public int delay { get; set; }
    }

    public class Stations
    {
        public string stop_id { get; set; }
        public string stop_name { get; set; }
        public string id { get; set; }
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
        public List<Stations> Estaciones { get; set; }
        //public IList<Stations> Estaciones { get; set; }
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

    //This Models are going to be used on the Instance of Angular
    public class SubwayGtfs
    {
        public string Id { get; set; }
        public string Id_Route { get; set; }
        public string Line { get; set; }
        public string Time_Start { get; set; }
        public string Date_Start { get; set; }
        public List<Stations> Stations { get; set; }
        public List<Direction> Directions { get; set; }
        public SubwayGtfs()
        {
            Stations = new List<Stations>();
            Directions = new List<Direction>();
        }
    }
    public class Direction
    {
        public int Id_Direction { get; set; }
        public string NameDirection { get; set; }
    }

    public class SubwayMain
    {
        public List<SubwayGtfs> GTFS { get; set; }
        public SubwayGtfs SearchValue { get; set; }
        public SubwayMain()
        {
            GTFS = new List<SubwayGtfs>();
        }
    }

}
