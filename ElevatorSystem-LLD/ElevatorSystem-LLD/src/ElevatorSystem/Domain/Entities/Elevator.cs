using ElevatorSystem_LLD.src.ElevatorSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem_LLD.src.ElevatorSystem.Domain.Entities
{
    public class Elevator
    {
        public int ElevatorId { get; }
        public int CurrentFloor { get; set; }
        public Direction Direction { get; set; }

        public ElevatorStatus Status { get; set; }

        public Door Door { get; }

        public Queue<Request> Requests { get; }

        public Elevator(int elevatorId)
        {
            ElevatorId = elevatorId;
            CurrentFloor = 0;
            Direction = Direction.Idle;
            Status = ElevatorStatus.Stopped;
            Requests = new Queue<Request>();
        }
    }
}
