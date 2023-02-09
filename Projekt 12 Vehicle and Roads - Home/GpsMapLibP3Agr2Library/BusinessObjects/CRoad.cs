using System;
using System.Collections.Generic;
using System.Text;



namespace GpsMapLibP3Agr2Library.BusinessObjects
{



    /// <summary>
    /// Represents a lower-quality road (a C-road).
    /// </summary>
    public class CRoad : Road
    {



        public CRoad(Town locationA, Town locationB) : base(locationA, locationB, CRoadMinVelocity, CRoadMaxVelocity)
        {
        }



        public CRoad(string roadNo, Town locationA, Town locationB, decimal minVelocity, decimal maxVelocity) : base(roadNo, locationA, locationB, minVelocity, maxVelocity)
        {
        }



        public CRoad(Road road) : base(road)
        {
        }



        public override string ToString()
        {
            return $"Silnice 3. třídy \'{this.RoadNo}\': z {this.LocationA.Name} do {this.LocationB.Name}";
        }



    }



}
