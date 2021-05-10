using Events.Models;
using EventsCore.Entities;
using EventsCore.Enum;
using EventsCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICollection<Event> _shoppingCart;

        private readonly ICategoryService _categoryService;
        private readonly IEventService _eventService;

        public CategoriesController(ICategoryService categoryService, IEventService eventService)
        {
            _categoryService = categoryService;
            _eventService = eventService;
        }

        //gets all categories from system
        [HttpGet]
        public ActionResult<IEnumerable<CategoryDTO>> GetAllCategories()
        {
            var categories = _categoryService.GetCategories().Result.Select(x => new CategoryDTO
            {
                CategoryName = x.CategoryName,
                Id = x.Id,
            });

            return Ok(categories);
        }

        //get categories by Id

        [HttpGet("{id}")]

        public ActionResult<CategoryDTO> GetCategoryById(int id)
        {
            var categoryResult = _categoryService.GetCategoryById(id);
            if (categoryResult.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(categoryResult.Error);
            }

            return Ok(new CategoryDTO
            {
                CategoryName = categoryResult.Result.CategoryName,
                Id = categoryResult.Result.Id
            });
        }

        //listar todos los eventos

        [HttpGet("/events")]

        public ActionResult<IEnumerable<EventDTO>> GetAllEvents()
        {
            var events = _eventService.GetEvents().Result.Select(x => new EventDTO
            {
                Id = x.Id,
                EventName = x.EventName,
                Quantity = x.TicketQuantity,
                Price = x.Price,
                CategoryId = x.CategoryId
            });

            return Ok(events);
        }


        //listar eventos por id
        [HttpGet("/events/{eventId}")]

        public ActionResult<EventDTO> GetEventById(int eventId)
        {
            var eventResult = _eventService.GetEventById(eventId);

            if(eventResult.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(eventResult.Error);
            }

            return Ok(new EventDTO
            {
                Id = eventResult.Result.Id,
                EventName = eventResult.Result.EventName,
                Quantity = eventResult.Result.TicketQuantity,
                Price = eventResult.Result.Price,
                CategoryId = eventResult.Result.CategoryId
            });
        }

        //obtener eventos de una categoria en especifico

        [HttpGet("/{categoryId}/events")]

        public ActionResult<IEnumerable<EventDTO>> GetEventForCategory(int categoryId)
        {
            var result = _eventService.FilterEventByCategoryId(categoryId);

            if(result.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(result.Error);
            }

            return Ok(result.Result.Select(e => new EventDTO
            {
                EventName = e.EventName,
                Quantity  = e.TicketQuantity,
                Price = e.Price,
                CategoryId = e.CategoryId
            }));
        }


        //crear eventos por categoria
        //no esta mal escrito , event es una variable reservada de .NET

        [HttpPost("/{categoryId}/events")]

        public ActionResult<EventDTO> CreateEventForCategory(int categoryId,[FromBody] EventDTO eventt)
        {
            var eventEntity = new Event
            {

              EventName = eventt.EventName,
              TicketQuantity = eventt.Quantity,
              Price = eventt.Price,
              CategoryId = categoryId
            };

            var result = _eventService.CreateEvent(eventEntity);

            if(result.ResponseCode == ResponseCode.NotFound)
            {
                return NotFound(result.Error);
            }

            return Ok(eventt);
        }

        [HttpPost("/new/cart")]
        public ActionResult<bool> AddEventToCart([FromBody] EventDTO eventt)
        {
            var objectCart = _eventService.GetEventById(eventt.Id);
            if ( objectCart.ResponseCode != ResponseCode.NotFound)
            {
                _shoppingCart.Add(new Event
                {
                    Category = objectCart.Result.Category,
                    CategoryId = objectCart.Result.CategoryId,
                    EventName = objectCart.Result.EventName,
                    Id = objectCart.Result.Id,
                    Price = objectCart.Result.Price,
                    TicketQuantity = objectCart.Result.TicketQuantity
                });
                return Ok(true);
            }

            return NotFound(false);
        }

        [HttpGet("/factura")]
        public ActionResult<double> ReturnRecipe()
        {
            double total = 0;
            for (int i = 0; i < _shoppingCart.Count; i++)
            {
                double subTotal=0;
                subTotal += _shoppingCart.ElementAt(i).Price;
                subTotal *= _shoppingCart.ElementAt(i).TicketQuantity;
                total += subTotal;
            }

            return Ok($"El total de la compra es: {total}");
        }
        
    }
}
