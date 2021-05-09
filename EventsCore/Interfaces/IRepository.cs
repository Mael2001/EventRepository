using System.Collections.Generic;

namespace EventsCore.Interfaces
{
    public interface IRepository<TEntity>
    {
        IReadOnlyList<TEntity> Get();
        TEntity Get(int id);
        TEntity Get(int categoryId, int eventId);
        TEntity Create(TEntity entity);
    }
}