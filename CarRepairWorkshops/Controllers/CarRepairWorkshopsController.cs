using CarRepairWorkshops.Application.CarRepairWorkshops.Commands.CreateWorkshop;
using CarRepairWorkshops.Application.CarRepairWorkshops.Commands.DeleteWorkshop;
using CarRepairWorkshops.Application.CarRepairWorkshops.Queries.GetAll;
using CarRepairWorkshops.Domain.Constants;
using CarRepairWorkshops.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRepairWorkshops.API.Controllers
{

    [ApiController]
    [Route("api/carRepairWorkshops")]
    [Authorize(Roles = UserRoles.Admin)]

    public class CarRepairWorkshopsController(IMediator mediator ) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarRepairWorkshop>>> GetAllWorkshopsAsync
            ([FromQuery] GetAllWorkshopsQuery query)
        {
            var workshops = await mediator.Send(query);
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
