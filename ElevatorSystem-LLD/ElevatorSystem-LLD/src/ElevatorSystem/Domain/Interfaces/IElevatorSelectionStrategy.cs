using ElevatorSystem_LLD.src.ElevatorSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem_LLD.src.ElevatorSystem.Domain.Interfaces
{
    public interface IElevatorSelectionStrategy
    {
        Elevator SelectElevator(List<Elevator> elevators, int requestedFloor);
    }
}
