using Microsoft.AspNetCore.Mvc;
using MediatR;
using CarRepairWorkshops.Domain.Entities;
using CarRepairWorkshops.Application.CarRepairWorkshops;
using CarRepairWorkshops.Application.CarRepairWorkshops.Queries.GetAll;
using CarRepairWorkshops.Application.CarRepairWorkshops.Commands.CreateWorkshop;
using CarRepairWorkshops.Application.CarRepairWorkshops.Commands.DeleteWorkshop;

namespace CarRepairWorkshops.API.Controllers
{

    [ApiController]
    [Route("api/carRepairWorkshops")]
    public class CarRepairWorkshopsController(IMediator mediator ) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarRepairWorkshop>>> GetAllWorkshopsAsync()
        {
            var workshops = await mediator.Send(new GetAllWorkshopsQuery());
            return Ok(workshops);
        }

        [HttpPost]
        public async Task<ActionResult> CreateWorkshop(CreateWorkshopCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }


        [HttpDelete]
        public async Task<ActionResult> DeleteWorkshop(DeleteWorkshopCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }


    }
}
