using System.Collections.Generic;
using EventsCore.Entities;
using EventsInfraestructure.Data.Contexts;

namespace EventsInfraestructure.Data.Repositories
{
    public class CategoryRepository: BaseRepository<Category>
    {
        private readonly EventsDbContext _context;

        public CategoryRepository(EventsDbContext context) : base(context)
        {
            _context = context;
        }

        public override IReadOnlyList<Category> Get()
        {
            throw new System.NotImplementedException();
        }

        public override IReadOnlyList<Category> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public override Category Get(int categoryId, int eventId)
        {
            throw new System.NotImplementedException();
        }
    }
}