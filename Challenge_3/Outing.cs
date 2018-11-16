using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    public class Outing
    {
        public string EventType { get; set; }
        public int EventAttendance { get; set; }
        public DateTime EventDate { get; set; }
        public decimal EventCostPerPerson { get; set; }
        public decimal EventCost { get; set; }

        public Outing(string eventType, int eventAttendance, DateTime eventDate, decimal eventCostPerPerson, decimal eventCost)
        {
            EventType = eventType;
            EventAttendance = eventAttendance;
            EventDate = eventDate;
            EventCostPerPerson = eventCostPerPerson;
            EventCost = eventCost;
        }

        public Outing()
        {

        }
    }
}
