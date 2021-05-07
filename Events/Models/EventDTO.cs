using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsCore.Entities;

namespace Events.Models
{
    public class EventDTO
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
