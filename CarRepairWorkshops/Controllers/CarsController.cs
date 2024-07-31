using CarRepairWorkshops.Application.Cars.Commands.ChangeOwnerTelephone;
using CarRepairWorkshops.Application.Cars.Commands.CreateCar;
using CarRepairWorkshops.Application.Cars.Commands.DeleteCar;
using CarRepairWorkshops.Application.Cars.Queries.GetAllForWorkshop;
using CarRepairWorkshops.Application.Cars.Queries.GetCarById;
using CarRepairWorkshops.Domain.Constants;
using CarRepairWorkshops.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRepairWorkshops.API.Controllers
{
    [ApiController]
    [Route("api/carRepairWorkshops/{WorkshopId}/cars")]
    public class CarsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = UserRoles.Mechanic)]
        public async Task<ActionResult<IEnumerable<Car>>> GetAllCarsForWorkshopAsync([FromRoute] int WorkshopId)
        {
            var result = await mediator.Send(new GetAllForWorkshopQuery(WorkshopId));
            return Ok(result);
        }

        [HttpGet("{CarId}")]
        [Authorize]
        public async Task<ActionResult<Car>> GetCarById([FromRoute] int CarId)
        {
            var car = await mediator.Send(new GetCarByIdQuery(CarId));
            return Ok(car);
        }
        
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateCar(CreateCarCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }
        //Only owner can create a car - it is in command handler

        [HttpPatch]
        [Authorize]
        public async Task<ActionResult> ChangeOwnerTelephone(ChangeOwnerTelephoneCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }
        //only owner of workshop that car belongs to can change owner telephone number

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult> DeleteCar(DeleteCarCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }
        //only owner can delete car from workshop - logic is in handler
    }
}
