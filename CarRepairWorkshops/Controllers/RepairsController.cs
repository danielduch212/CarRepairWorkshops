using CarRepairWorkshops.Application.Repairs.Commands.AddReplacedCarPart;
using CarRepairWorkshops.Application.Repairs.Commands.AddService;
using CarRepairWorkshops.Application.Repairs.Commands.CreateRepair;
using CarRepairWorkshops.Application.Repairs.Commands.DeleteRepair;
using CarRepairWorkshops.Application.Repairs.Queries.GetAllForCar;
using CarRepairWorkshops.Domain.Constants;
using CarRepairWorkshops.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CarRepairWorkshops.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/carRepairWorkshops/{workshopId}/cars/{carId}/repairs")]
    
    public class RepairsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<Repair>> GetAllRepairsForCar([FromRoute] int workshopId, [FromRoute] int carId)
        {
            var result = await mediator.Send(new GetAllForCarQuery(workshopId, carId));
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRepair(CreateRepairCommand command, [FromRoute] int carId)
        {
            command.CarId = carId;
            await mediator.Send(command);
            return NoContent();
        }

        [HttpPost("addService")]     
        public async Task<ActionResult> AddServiceToRepair(AddServiceToRepairCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        [HttpPost("addReplacedCarPart")]
        public async Task<ActionResult> AddReplacedCarPartToRepair(AddReplacedCarPartCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteRepair(DeleteRepairCommand command)
        {
            
            await mediator.Send(command);
            return NoContent();
        }


    }
}
