using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise_LLD.Domain.Entities
{
    public class User
    {
        public string Id { get; }

        public string Name { get; }

        public User(string id, string name)
        {
            Id = id;
            Name = name;
        }   
    }
}
