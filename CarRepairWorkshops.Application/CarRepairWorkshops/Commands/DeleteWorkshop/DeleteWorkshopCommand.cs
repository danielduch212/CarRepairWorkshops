using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairWorkshops.Application.CarRepairWorkshops.Commands.DeleteWorkshop
{
    public class DeleteWorkshopCommand : IRequest
    { 
        public int WorkshopId { get; set; }

    }
}
