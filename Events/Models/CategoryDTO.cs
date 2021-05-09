using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsCore.Entities;

namespace Events.Models
{
    public class CategoryDTO
    {
        public string CategoryName { get; set; }
        public int Id { get; set; }

        //public double Tax { get; set; }
        //public double Total { get; set; }
        //public ICollection<Event> Events { get; set; } = new HashSet<Event>();
    }
}
