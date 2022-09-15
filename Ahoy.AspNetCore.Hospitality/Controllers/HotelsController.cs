using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ahoy.AspNetCore.Hospitality.Features.ProductFeature.Commands;
using Ahoy.AspNetCore.Hospitality.Features.ProductFeature.Queries.HotelQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Ahoy.AspNetCore.Hospitality.Filter;
using Ahoy.AspNetCore.Hospitality.Wrappers;
using Ahoy.AspNetCore.Hospitality.Models;
using Ahoy.AspNetCore.Hospitality.Contracts;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ahoy.AspNetCore.Hospitality.Controllers
{
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        private readonly IHotelService _service;
        public HotelsController(IHotelService service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateHotelCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]PaginationFilter filter)
        {
            var response = await Mediator.Send(new GetAllHotels(filter)) ;
            return Ok(new Response<IEnumerable<Hotel>>(response));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await Mediator.Send(new GetHotelByIdQuery { Id = id });
            return Ok(new Response<Hotel>(response));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteHotelByIdCommand { Id = id }));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateHotelCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
