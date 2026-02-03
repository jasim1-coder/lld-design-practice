using ElevatorSystem_LLD.src.ElevatorSystem.Domain.Entities;
using ElevatorSystem_LLD.src.ElevatorSystem.Domain.Enums;
using ElevatorSystem_LLD.src.ElevatorSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem_LLD.src.ElevatorSystem.Services
{
    public class ElevatorController
    {
        private readonly List<Elevator> _elevators;
        private readonly IElevatorSelectionStrategy _selectionStrategy;

        public ElevatorController(List<Elevator> elevators, IElevatorSelectionStrategy selectionStrategy)
        {
            _elevators = elevators;
            _selectionStrategy = selectionStrategy;
        }

        public void RequestElevator(int floor, Direction direction)
        {
            var request = new Request(floor, direction, RequestType.External);
            var elevator = _selectionStrategy.SelectElevator(_elevators, floor);

            elevator.Requests.Enqueue(request);

            Console.WriteLine(
                $"External request for floor {floor} assigned to Elevator {elevator.ElevatorId}");
        }


        public void Step()
        {

            foreach (var elevator in _elevators)
            {
                // Rule 1: Close door before moving
                if (elevator.Door.State == DoorState.Open)
                {
                    elevator.Door.Close();
                    Console.WriteLine($"Elevator {elevator.ElevatorId} door closed");
                    continue;
                }

                if (elevator.Requests.Count == 0)
                {
                    elevator.Direction = Direction.Idle;
                    elevator.Status = ElevatorStatus.Stopped;
                    continue;
                }

                var request = elevator.Requests.Peek();
                var targetFloor = request.Floor;

                elevator.Status = ElevatorStatus.Moving;

                if (elevator.CurrentFloor > targetFloor)
                {
                    elevator.Direction = Direction.Down;
                    elevator.CurrentFloor--;
                }
                else if (elevator.CurrentFloor < targetFloor)
                {
                    elevator.Direction = Direction.Up;
                    elevator.CurrentFloor++;
                }
                else
                {
                    elevator.Requests.Dequeue();
                    elevator.Status = ElevatorStatus.Stopped;
                    elevator.Direction = Direction.Idle;
                    elevator.Door.Open();
                    Console.WriteLine($"Elevator {elevator.ElevatorId} stopped at floor {elevator.CurrentFloor} ");
                }
            }
        }
    }
}

