using System.Collections.Generic;
using EventsCore.Entities;

namespace EventsCore.Interfaces
{
    public interface IEventService
    {
        ServiceResult<IReadOnlyList<Event>> GetEvents();
        ServiceResult<Event> GetEvent(int id);
        ServiceResult<IReadOnlyList<Event>> FilterEventByCategoryId(int categoryId);
        ServiceResult<Event> CreateEvent(Event entity);
        
    }
}