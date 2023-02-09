using System;
using System.Collections.Generic;
using System.Text;



namespace GpsMapLibP3Agr2Library.BusinessObjects
{



    /// <summary>
    /// Represents a standard road (an A-road).
    /// </summary>
    public class ARoad : Road
    {



        public ARoad(Town locationA, Town locationB) : base(locationA, locationB, StandardMinVelocity, StandardMaxVelocity)
        {
        }



        public ARoad(string roadNo, Town locationA, Town locationB, decimal minVelocity, decimal maxVelocity) : base(roadNo, locationA, locationB, minVelocity, maxVelocity)
        {
        }



        public ARoad(Road road) : base(road)
        {
        }



        public override string ToString()
        {
            return $"Silnice 1. třídy \'{this.RoadNo}\': z {this.LocationA.Name} do {this.LocationB.Name}";
        }



    }



}
