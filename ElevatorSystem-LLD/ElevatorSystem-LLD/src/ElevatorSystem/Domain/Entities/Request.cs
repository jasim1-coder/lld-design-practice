using ElevatorSystem_LLD.src.ElevatorSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem_LLD.src.ElevatorSystem.Domain.Entities
{
    public class Request
    {
        public int Floor {  get;}
        public Direction Direction { get;}

        public RequestType Type { get;}

        public Request (int floor, Direction direction, RequestType type )
        {
            Floor = floor;
            Direction = direction;
            Type = type;
        }
    }
}
