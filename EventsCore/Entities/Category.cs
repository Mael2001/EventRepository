using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsCore.Entities
{
    public class Category
    {
        public string CategoryName { get; set; }
        public int Id { get; set; }
        public double Tax { get; set; }
        public double Total { get; set; }
        public ICollection<Event> Events { get; set; } = new HashSet<Event>();

    }
}
