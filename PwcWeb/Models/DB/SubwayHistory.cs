using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PwcWeb.Models
{
    public class SubwayHistory
    {
        public int Id { get; set; }
        public string Line { get; set; }
        public string Result { get; set; }
        public DateTime Date { get; set; }
    }

    public class LineName
    {
        public string Id { get; set; }
    }
    public class HistoryViewModel {
        public List<SubwayHistory> Histories { get; set; }
        public List<LineName> Lines { get; set; }
        public HistoryViewModel()
        {
            Histories = new List<SubwayHistory>();
            Lines = new List<LineName>();
        }
    }
}
