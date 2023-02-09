using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GpsMapLibP3Agr2Library;
using GpsMapLibP3Agr2Library.BusinessObjects;
using GpsMapLibP3Agr2Library.Interfaces;

namespace _12_du_Vehicle_and_Roads
{
    public class Vehicle : IMovable
    {
        public Town startTown;
        public string name;
        public int speed;
        public int maxSpeed;
        public Town finalTown;
        public Gps location;

        public Vehicle(string name, int speed, int maxSpeed, Town finalTown, Town startTown)
        {
            this.name = name;
            this.speed = speed;
            this.maxSpeed = maxSpeed;
            this.finalTown = finalTown;
            this.startTown = startTown;
            this.location = startTown.Gps;
        }

        public void MoveBy(Town endTown,Road road, bool fromAtoB) // možná to budu volat z choose way takže tam nebude muset byt endTownGps
        {
            IRoadMap roadMap = RoadMapFactory.GetRoadMap();
            while (this.location != endTown.Gps)
            {
                //1sec = 15 min
                location = roadMap.MoveOnRoad(location, road.RoadNo, fromAtoB, speed, 15 / 60m);
                Console.WriteLine(name + " " + location);
                //Thread.Sleep(1000);
            }
        }

        public void ChooseWay()
        {
            IRoadMap roadMap = RoadMapFactory.GetRoadMap();

            Road road = new Road();
            bool fromAtoB = true;
            Random random = new Random();
            Town endTown = new Town();
            int counter = 0;

            while (this.location != finalTown.Gps)
            {
                List<Road> roadsFromStartT = roadMap.GetTownDirections(this.startTown.Code);
                road = roadsFromStartT[random.Next(0, roadsFromStartT.Count)];
                if (road.MaxVelocity > this.speed && road.MinVelocity < this.speed)
                {
                    if (road.MaxVelocity > this.speed)
                    {
                        if (maxSpeed > road.MaxVelocity)
                        {
                            this.speed = Convert.ToInt32(road.MaxVelocity) - 1;
                        }
                        else
                        {
                            this.speed = maxSpeed;
                        }
                    }
                    if (this.startTown == road.LocationA)
                    {
                        fromAtoB = true;
                        endTown = road.LocationB;                       
                    }
                    else
                    {
                        fromAtoB = false;
                        endTown = road.LocationA;
                    }
                    MoveBy(endTown, road, fromAtoB);
                    this.startTown = endTown;
                    Console.WriteLine($"Vozidlo {name} je v {startTown.Name}");
                    counter = 0;
                }
                else
                {
                    if (road.MaxVelocity < this.speed)
                    {
                        this.speed = Convert.ToInt32(road.MaxVelocity)-1;
                        //MoveBy(endTown, road, fromAtoB);
                        //this.startTown = endTown;
                    }
                    else if (road.MinVelocity > this.speed)
                    {
                        this.speed = this.maxSpeed;
                        counter++;
                        if (counter > 500)
                        {                            
                            Console.WriteLine($"Vozidlo: {name} nemůže odjet z {startTown.Name}, protože má příliš malou rychlost.");
                            break;
                        }
                        
                    }                              
                }
            }
            if(counter < 500)
            {
                Console.WriteLine($"Vozidlo: {this.name} dojelo do {this.finalTown.Name}...................");
            }           
        }
    }
}
