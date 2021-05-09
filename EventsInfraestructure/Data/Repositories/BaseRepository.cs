using System.Collections.Generic;
using EventsCore.Interfaces;
using EventsInfraestructure.Data.Contexts;

namespace EventsInfraestructure.Data.Repositories
{
    public abstract class BaseRepository<TEntity>: IRepository<TEntity>
    {
        private readonly EventsDbContext _context;

        public BaseRepository(EventsDbContext context)
        {
            _context = context;
        }
        public abstract IReadOnlyList<TEntity> Get();
        public abstract TEntity Get(int id);
        public abstract TEntity Get(int categoryId, int eventId);
        public TEntity Create(TEntity entity)
        {
            _context.AddAsync(entity);
            _context.SaveChangesAsync();
            return entity;
        }
    }
}