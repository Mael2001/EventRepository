using System.Collections.Generic;
using EventsCore.Entities;
using EventsCore.Interfaces;

namespace EventsCore.Services
{
    public class EventService: IEventService
    {
        private readonly IRepository<Event> _eventRepository;
        private readonly IRepository<Category> _categoryRepository;

        public EventService(IRepository<Event> eventRepository,IRepository<Category> categoryRepository)
        {
            _eventRepository = eventRepository;
            _categoryRepository = categoryRepository;
        }
        public ServiceResult<IReadOnlyList<Event>> GetEvents()
        {
            var events = _eventRepository.Get();
            return ServiceResult<IReadOnlyList<Event>>.SuccessResult(events);
        }

        public ServiceResult<Event> GetEventById(int id)
        {
            var eventt = _eventRepository.Get(id);
            if(eventt == null)
            {
                return ServiceResult<Event>.NotFoundResult($"No se encontro evento con el id {id}");
            }

            return ServiceResult<Event>.SuccessResult(eventt);

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