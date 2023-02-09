using GpsMapLibP3Agr2Library.BusinessObjects;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_du_Vehicle_and_Roads
{
     
    public class Bicycle : NonMotorVehicle
    {
        public Gps location;
        public Bicycle( int stamina, string name, int speed, int maxSpeed, Town startTown, Town finalTown) : base(stamina,name,speed,maxSpeed, startTown, finalTown)
        {
            this.location = startTown.Gps;
        }
    }
}
