using Microsoft.AspNetCore.Mvc;
using MediatR;
using CarRepairWorkshops.Domain.Entities;
using CarRepairWorkshops.Application.CarRepairWorkshops;
using CarRepairWorkshops.Application.CarRepairWorkshops.Queries.GetAll;

namespace CarRepairWorkshops.API.Controllers
{

    [ApiController]
    [Route("carRepairWorkshops")]
    public class CarRepairWorkshopsController(IMediator mediator ) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarRepairWorkshop>>> GetAllWorkshopsAsync()
        {
            var workshops = await mediator.Send(new GetAllWorkshopsQuery());
            return Ok(workshops);
        } 
    }
}
