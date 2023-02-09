using GpsMapLibP3Agr2Library.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_du_Vehicle_and_Roads
{
    public class NonMotorVehicle : Vehicle
    {       
        public int stamina;
        public Gps location;

        public NonMotorVehicle(int stamina,string name, int speed, int maxSpeed, Town startTown, Town finalTown) : base(name,speed,maxSpeed, finalTown,startTown)
        {
            this.stamina = stamina;
            this.location = startTown.Gps;
        }   
    }
}
