using DroneDeliveryService.BusinessLogic;
using DroneDeliveryService.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DroneDeliveryService
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read input data
            string[] input = System.IO.File.ReadAllLines(@"Input.txt");
            List<Drone> drones = new List<Drone>();
            List<Location> locations = new List<Location>();

            for (int i = 0; i < input.Length; i++)
            {
                if (i == 0)
                {
                    //Read drones data
                    for (int j = 0; j < input[i].Split(',').Length; j += 2)
                    {
                        string droneName = input[i].Split(',')[j].Trim();
                        int Maxweight = int.Parse(input[i].Split(',')[j + 1].Trim().Replace("[", "").Replace("]", ""));
                        drones.Add(new Drone(droneName, Maxweight));
                    }
                }
                else
                {
                    //Read locations data
                    string locationName = input[i].Split(',')[0].Trim();
                    int packageWeight = int.Parse(input[i].Split(',')[1].Trim().Replace("[", "").Replace("]", ""));
                    locations.Add(new Location(locationName, packageWeight));
                }
            }

            DeliveryScheduler scheduler = new DeliveryScheduler();
            scheduler.ScheduleDeliveries(drones,locations);
        }
    }
}
