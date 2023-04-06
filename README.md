# DroneDeliveryService
###Description

A squad of drones have been tasked with delivering packages for a major online reseller in a world where time and distance do not matter. Each drone can carry a specific weight, and can make multiple deliveries before returning to home base to pick up additional loads; however the goal is to make the fewest number of trips as each time the drone returns to home base it is extremely costly to refuel and reload the drone.

The purpose of the written software will be to accept input which will include the name of each drone and the maximum weight it can carry, along with a series of locations and the total weight needed to be delivered to that specific location. The software should highlight the most efficient deliveries for each drone to make on each trip.

Assume that time and distance to each drop off location do not matter, and that size of each package is also irrelevant. It is also assumed that the cost to refuel and restock each drone is a constant and does not vary between drones. The maximum number of drones in a squad is 100, and there is no maximum number of deliveries which are required.

###Given Input
```
Line 1: [Drone #1 Name], [#1 Maximum Weight], [Drone #2 Name], [#2 Maximum Weight]
Line 2: [Location #1 Name], [Location #1 Package Weight]
Line 3: [Location #2 Name], [Location #2 Package Weight]
Line 4: [Location #3 Name], [Location #3 Package Weight]
```
###Expected Output
```
[Drone #1 Name]
Trip #1
[Location #2 Name], [Location #3 Name]
Trip #2
[Location #1 Name]

[Drone #2 Name]
Trip #1
[Location #4 Name], [Location #7 Name]
Trip #2
[Location #5 Name], [Location #6 Name]
```

###Comments
```
Algorithm:
1.Parse the input file to create a list of drones and a list of locations.
2.While there are still drones and locations left, loop through each drone and create a dictionary with the drone and a list of scheduled trips.
3.Get the scheduled trips for the current drone by calling getScheduledTripsForDrone() with the drone and the schedule list.
4.Pick the locations for the current drone by calling pickLocationsForCapacity() with the drone's maxWeight and the locationsLeft list.
5.If there are any locations picked, remove them from the locationsLeft list and add them to the drone's scheduled trips.
6.Append the drone and its scheduled trips dictionary to the schedule list.
7.Return the schedule list.
```

Dependencies:
No external dependencies are needed for this solution. We only need a C# compiler such as Visual Studio or .NET Core to compile and execute the code.
