using ElevatorSystem_LLD.src.ElevatorSystem.Domain.Entities;
using ElevatorSystem_LLD.src.ElevatorSystem.Domain.Enums;
using ElevatorSystem_LLD.src.ElevatorSystem.Services;
using ElevatorSystem_LLD.src.ElevatorSystem.Strategies;
using System;


class Program
{
    static void Main()
    {
        var elevators = new List<Elevator>
        {
            new Elevator(1),
            new Elevator(2)
        };

        var strategy = new NearestElevatorStrategy();
        var controller = new ElevatorController(elevators, strategy);

        controller.RequestElevator(3, Direction.Up);
        controller.RequestElevator(5, Direction.Up);
        controller.RequestElevator(2, Direction.Down);


        controller.RequestElevator(1, Direction.Up);
        controller.RequestElevator(8, Direction.Up);


        Console.WriteLine();

        for(int step = 0; step <= 10; step++)
        {
            Console.WriteLine($"⏱ Time Step {step}");
            controller.Step();

            foreach(var elevator in elevators)
            {
                Console.WriteLine(
                                  $"Elevator {elevator.ElevatorId} | " +
                                  $"Floor: {elevator.CurrentFloor} | " +
                                  $"Direction: {elevator.Direction} | " +
                                  $"Door: {elevator.Door.State}"
                              );
            }
            Console.WriteLine();
            Thread.Sleep(700);
        }

        Console.WriteLine("🛑 Simulation Ended");

    }
}