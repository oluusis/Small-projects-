using GpsMapLibP3Agr2Library.BusinessObjects;
using GpsMapLibP3Agr2Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_du_Vehicle_and_Roads
{
    public class Car : MotorVehicle , IMovable
    {
        public int sizeTrunk;
        public Gps location;

        public Car(int sizeTrunk, int fuel, string name, int speed, int maxSpeed,  Town startTown, Town finalTown) :base(fuel,name,speed,maxSpeed,startTown, finalTown)
        {
            this.sizeTrunk = sizeTrunk;
            this.location = startTown.Gps;
        }

    }
}
