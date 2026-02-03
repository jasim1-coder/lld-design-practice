using ElevatorSystem_LLD.src.ElevatorSystem.Domain.Entities;
using ElevatorSystem_LLD.src.ElevatorSystem.Domain.Enums;
using ElevatorSystem_LLD.src.ElevatorSystem.Services;
using ElevatorSystem_LLD.src.ElevatorSystem.Strategies;


namespace ElevatorSystem.Tests
{
    public class ElevatorControllerTests
    {
        [Fact]
        public void Elevator_Moves_Up_To_Target_Floor()
        {
            // Arrange
            var elevators = new List<Elevator>
    {
        new Elevator(1)
    };
            var strategy = new NearestElevatorStrategy();
            var controller = new ElevatorController(elevators, strategy);

            controller.RequestElevator(3, Direction.Up);

            bool doorOpened = false;

            // Act
            for (int i = 0; i < 10; i++)
            {
                controller.Step();

                if (elevators[0].Door.State == DoorState.Open)
                    doorOpened = true;

                if (elevators[0].CurrentFloor == 3 && doorOpened)
                    break;
            }

            // Assert
            Assert.Equal(3, elevators[0].CurrentFloor);
            Assert.True(doorOpened);
        }

    }

}
