using DroneDeliveryService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneDeliveryService.BusinessLogic
{
    class DeliveryScheduler
    {
        public void ScheduleDeliveries(List<Drone> drones, List<Location> locations)
        {
            List<Dictionary<string, object>> schedule = new List<Dictionary<string, object>>();
            List<Location> locationsLeft = locations.ToList();
            while (drones.Count > 0 && locationsLeft.Count > 0)
            {
                schedule = drones.Select(drone => {
                    List<List<Location>> tripsForDrone = GetScheduledTripsForDrone(drone, schedule);
                    List<Location> locationsPicked = PickLocationsForCapacity(drone.MaxWeight, locationsLeft);

                    if (locationsPicked.Count > 0)
                    {
                        locationsLeft = locationsLeft.Where(
                            location => !locationsPicked.Any(picked => picked == location)
                        ).ToList();
                        tripsForDrone.Add(locationsPicked);
                    }

                    Dictionary<string, object> droneSchedule = new Dictionary<string, object>();
                    droneSchedule.Add("drone", drone);
                    droneSchedule.Add("trips", tripsForDrone);
                    return droneSchedule;
                }).ToList();
            }

            foreach(var drone in schedule)
            {
                Console.WriteLine($"{((Drone)drone["drone"]).Name}");

                List<List<Location>> trips = ((List<List<Location>>)drone["trips"]).ToList();

                for (var i = 0; i < trips.Count; i++)
                {
                    Console.WriteLine($"Trip #{i + 1}");
                    string summarized = string.Empty;

                    foreach(var trip in trips[i])
                    {
                        summarized += trip.Name +", ";
                    }
                    Console.WriteLine(summarized);
                }

                Console.WriteLine();
            }
        }

        List<List<Location>> GetScheduledTripsForDrone(Drone drone, List<Dictionary<string, object>> schedule)
        {
            return schedule.Aggregate(new List<List<Location>>(), (trips, droneSchedule) => {
                return droneSchedule.ContainsKey("drone") && (Drone)droneSchedule["drone"] == drone ? (List<List<Location>>)droneSchedule["trips"] : trips;
            });
        }

        List<Location> PickLocationsForCapacity(float capacity, List<Location> locations)
        {
            return locations.Aggregate(new List<Location>(), (locationsPicked, currentLocation) => {
                float currentLoad = CalculateLoadForLocations(locationsPicked);
                float remainingCapacity = capacity - currentLoad;
                if (currentLocation.Weight < remainingCapacity && locations.Count > 1)
                {
                    List<Location> found = PickLocationsForCapacity(
                        remainingCapacity - currentLocation.Weight,
                        locations.SkipWhile(location => !location.Equals(currentLocation)).Skip(1).ToList()
                    );
                    if (found.Count > 0)
                    {
                        return locationsPicked.Concat(new List<Location>() { currentLocation }).Concat(found).ToList();
                    }
                }
                else if (currentLocation.Weight <= remainingCapacity)
                {
                    return locationsPicked.Concat(new List<Location>() { currentLocation }).ToList();
                }
                return locationsPicked;
            });
        }

        float CalculateLoadForLocations(List<Location> locations)
        {
            return locations.Aggregate(0.0f, (weight, loc) => {
                return weight + loc.Weight;
            });
        }
    }
}

