using System.Collections.Generic;
using System.Linq;
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
            return _context.Categories.ToList();
        }

        public override Category Get(int id)
        {
            return _context.Categories.FirstOrDefault(x => x.Id == id);
        }

        //not used ?
        public override Category Get(int categoryId, int eventId)
        {
            throw new System.NotImplementedException();
        }
    }
}