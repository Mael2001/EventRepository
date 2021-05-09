using System.Collections.Generic;
using System.Linq;
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

            //no esta mal escrito , event es una variable reservada de .NET
            var eventt = _eventRepository.Get(id);
            if(eventt == null)
            {
                return ServiceResult<Event>.NotFoundResult($"No se encontro evento con el id {id}");
            }

            return ServiceResult<Event>.SuccessResult(eventt);

        }

        public ServiceResult<IReadOnlyList<Event>> FilterEventByCategoryId(int categoryId)
        {
            var category = _categoryRepository.Get(categoryId);
            
            if(category == null)
            {
                return ServiceResult<IReadOnlyList<Event>>.NotFoundResult($"No se encontro una categoria con el id {categoryId}");
            }

            if(!category.Events.Any())
            {
                return ServiceResult<IReadOnlyList<Event>>.NotFoundResult($"No hay eventos para la categoria de id {categoryId}");
            }

            return ServiceResult<IReadOnlyList<Event>>.SuccessResult(category.Events.ToList());

            
        }

        public ServiceResult<Event> CreateEvent(Event entity)
        {
            var category = _categoryRepository.Get(entity.CategoryId);

            if(category == null)
            {
                return ServiceResult<Event>.NotFoundResult($"No se encontro categoria con el id {entity.CategoryId}");
            }

            var eventt = _eventRepository.Get(entity.Id);

            if(eventt == null)
            {
                return ServiceResult<Event>.NotFoundResult($"No se encontro evento con el id {entity.Id}");
            }

            return ServiceResult<Event>.SuccessResult(eventt);
        }


    }
}