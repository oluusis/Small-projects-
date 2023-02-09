using GpsMapLibP3Agr2Library.BusinessObjects;
using GpsMapLibP3Agr2Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_du_Vehicle_and_Roads
{
    public class Trailer : NonMotorVehicle , IMovable
    {
        public Gps location;
        public Trailer(string name, int speed, int maxSpeed, int stamina, Town startTown, Town finalTown) : base(stamina,name,speed, maxSpeed,startTown, finalTown)
        {
            this.location = startTown.Gps;
        }
    }
}
