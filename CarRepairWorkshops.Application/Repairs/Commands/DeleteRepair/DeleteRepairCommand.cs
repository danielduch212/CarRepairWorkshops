using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairWorkshops.Application.Repairs.Commands.DeleteRepair
{
    public class DeleteRepairCommand : IRequest
    {
        public int RepairId { get; set; }
    }
}
