using System.Collections.Generic;
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
            throw new System.NotImplementedException();
        }

        public override IReadOnlyList<Event> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public override Event Get(int categoryId, int eventId)
        {
            throw new System.NotImplementedException();
        }
    }
}