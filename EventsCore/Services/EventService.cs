using System.Collections.Generic;
using EventsCore.Entities;
using EventsCore.Interfaces;

namespace EventsCore.Services
{
    public class EventService: IEventService
    {
        public ServiceResult<IReadOnlyList<Event>> GetEvents()
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult<Event> GetEvent(int id)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult<IReadOnlyList<Event>> FilterEventByCategoryId(int categoryId)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult<Event> CreateEvent(Event entity)
        {
            throw new System.NotImplementedException();
        }
    }
}