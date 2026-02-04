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
            var elevators = new List<Elevator> { new Elevator(1) };
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

        [Fact]
        public void Elevator_Does_Not_Move_When_No_Request()
        {
            //Arrange
            var elevators = new List<Elevator> { new Elevator(3) };
            var strategy = new NearestElevatorStrategy();
            var controller = new ElevatorController(elevators, strategy);

            //Act
            for(int i = 0; i < 5; i++)
            {
                controller.Step();
            }

            //Assert
            Assert.Equal(0,elevators[0].CurrentFloor);
            Assert.Equal(Direction.Idle, elevators[0].Direction);
            Assert.Equal(DoorState.Closed, elevators[0].Door.State);

        }

        [Fact]
        public void Door_Closes_Before_Elevator_Moves_Again()
        {
            // Arrange
            var elevator = new Elevator(1);
            var elevators = new List<Elevator> { elevator };

            var strategy = new NearestElevatorStrategy();
            var controller = new ElevatorController(elevators, strategy);

            controller.RequestElevator(1, Direction.Up);
            controller.RequestElevator(3, Direction.Up);

            bool doorOpened = false;
            bool doorClosedAfterOpen = false;

            // Act
            for (int i = 0; i < 10; i++)
            {
                controller.Step();

                if (elevator.Door.State == DoorState.Open)
                    doorOpened = true;

                if (doorOpened && elevator.Door.State == DoorState.Closed && elevator.CurrentFloor > 1)
                {
                    doorClosedAfterOpen = true;
                    break;
                }
            }

            // Assert
            Assert.True(doorOpened);
            Assert.True(doorClosedAfterOpen);
        }

    }

}
