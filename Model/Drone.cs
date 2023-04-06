using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneDeliveryService.Model
{
    class Drone
    {
        public string Name { get; set; }
        public int MaxWeight { get; set; }

        public Drone(string name, int maxWeight)
        {
            Name = name;
            MaxWeight = maxWeight;
        }
    }
}
