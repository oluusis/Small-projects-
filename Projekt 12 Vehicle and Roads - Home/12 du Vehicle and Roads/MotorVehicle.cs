using GpsMapLibP3Agr2Library.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GpsMapLibP3Agr2Library;
using GpsMapLibP3Agr2Library.BusinessObjects;
using GpsMapLibP3Agr2Library.Interfaces;
using System.Net.Http.Headers;
using System.ComponentModel.DataAnnotations;

namespace _12_du_Vehicle_and_Roads
{
    public class MotorVehicle : Vehicle, IMovable
    {
        public int fuel;
        public Gps location;

        public MotorVehicle(int fuel, string name, int speed, int maxSpeed, Town startTown, Town finalTown) : base(name, speed,maxSpeed, finalTown,startTown)
        {
            this.fuel = fuel;
            this.location = startTown.Gps;
        }
    }
}
