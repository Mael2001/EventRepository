using System.Collections.Generic;
using System.Linq;
using EventsCore.Entities;
using EventsInfraestructure.Data.Contexts;

namespace EventsInfraestructure.Data.Repositories
{
    public class EventRepository: BaseRepository<Event>
    {
        private readonly EventsDbContext _context;

        public EventRepository(EventsDbContext context) : base(context)
        {
            _context = context;
        }

        public override IReadOnlyList<Event> Get()
        {
            return _context.Events.ToList();
        }

        public override Event Get(int id)
        {
            return _context.Events.FirstOrDefault(x => x.Id == id);
        }

        public override Event Get(int categoryId, int eventId)
        {
            throw new System.NotImplementedException();
        }
    }
}