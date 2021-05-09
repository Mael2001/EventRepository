using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsCore.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public int TicketQuantity { get; set; }
        public double Price { get; set; }
    
        //public double Total { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
