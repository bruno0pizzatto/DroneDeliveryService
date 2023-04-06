using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneDeliveryService.Model
{
    class Location
    {
        public string Name { get; set; }
        public int Weight { get; set; }

        public Location(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }
    }
}
