using ElevatorSystem_LLD.src.ElevatorSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem_LLD.src.ElevatorSystem.Domain.Entities
{
    public class Door
    {
        public DoorState State { get; set; }

        public Door()
        {
            State = DoorState.Closed;
        }

        public void Open()
        {
            State = DoorState.Open;
        }

        public void Close() 
        {
            State = DoorState.Closed;
        }
    }
}
