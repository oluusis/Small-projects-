using GpsMapLibP3Agr2Library.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_du_Vehicle_and_Roads
{
    public class Motorcycle : MotorVehicle
    {
        public Gps location;
        public Motorcycle(int fuel, string name, int speed, int maxSpeed, Town startTown, Town finalTown) : base(fuel,name,speed,maxSpeed,startTown, finalTown)
        {
            this.location = startTown.Gps;
        }
    }
}
