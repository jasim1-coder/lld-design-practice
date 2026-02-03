using ElevatorSystem_LLD.src.ElevatorSystem.Domain.Entities;
using ElevatorSystem_LLD.src.ElevatorSystem.Domain.Interfaces;


namespace ElevatorSystem_LLD.src.ElevatorSystem.Strategies
{
    public class NearestElevatorStrategy : IElevatorSelectionStrategy
    {
        public Elevator SelectElevator(List<Elevator> elevators, int requestedFloor)
        {
            return elevators
                .OrderBy(e => Math.Abs(e.CurrentFloor - requestedFloor)).First();
        }

    }
}
