using CarRepairWorkshops.Application.CarRepairWorkshops.Commands.AssignMechanic;
using CarRepairWorkshops.Application.CarRepairWorkshops.Commands.CreateWorkshop;
using CarRepairWorkshops.Application.CarRepairWorkshops.Commands.DeleteWorkshop;
using CarRepairWorkshops.Application.CarRepairWorkshops.Commands.UnassignMechanic;
using CarRepairWorkshops.Application.CarRepairWorkshops.Commands.UploadWorkshopLogo;
using CarRepairWorkshops.Application.CarRepairWorkshops.Queries.GetAll;
using CarRepairWorkshops.Application.Users.Commands.AssignUserRole;
using CarRepairWorkshops.Application.Users.Commands.UnassignUserRole;
using CarRepairWorkshops.Domain.Constants;
using CarRepairWorkshops.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRepairWorkshops.API.Controllers
{

    [ApiController]
    [Route("api/carRepairWorkshops")]
    [Authorize]

    public class CarRepairWorkshopsController(IMediator mediator ) : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<IEnumerable<CarRepairWorkshop>>> GetAllWorkshopsAsync
            ([FromQuery] GetAllWorkshopsQuery query)
        {
            var workshops = await mediator.Send(query);
            return Ok(workshops);
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
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

        [HttpPost("{id}/logo")]
        public async Task<ActionResult> UploadLogo([FromRoute] int id, IFormFile file)
        {
            using var stream = file.OpenReadStream();

            var command = new UploadWorkshopLogoCommand()
            {
                WorkshopId = id,
                Filename = $"{id}-{file.FileName}",
                File = stream,
            };

            await mediator.Send(command);
            return NoContent();
        }

        [HttpPost("assignMechanic")]
        public async Task<IActionResult> AssignMechanic(AssignMechanicCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("unassignMechanic")]
        public async Task<IActionResult> UnassignMechanic(UnassignMechanicCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

    }
}
