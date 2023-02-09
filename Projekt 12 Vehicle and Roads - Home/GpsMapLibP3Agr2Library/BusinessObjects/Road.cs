using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace GpsMapLibP3Agr2Library.BusinessObjects
{



    public class Road
    {



        // Velocities outside towns. Standard.
        public const decimal StandardMinVelocity = 40.0m;
        public const decimal StandardMaxVelocity = 90.0m;

        // Velocities outside towns. On motorways.
        public const decimal HighwayMinVelocity = 70.0m;
        public const decimal HighwayMaxVelocity = 130.0m;

        // Velocities outside towns. On lower-quality roads.
        public const decimal CRoadMinVelocity = 20.0m;
        public const decimal CRoadMaxVelocity = 60.0m;



        // Unique identifier of the road.
        public string RoadNo { get; set; }

        // Location A ("start") of the road.
        public Town LocationA { get; set; }

        // Location B ("end") of the road.
        public Town LocationB { get; set; }

        // Minimum velocity (km/h) necessary to drive this road.
        public decimal MinVelocity { get; set; }

        // Maximum velocity (km/h) allowed for this road.
        public decimal MaxVelocity { get; set; }



        public Road()
        {
            this.MinVelocity = StandardMinVelocity;
            this.MaxVelocity = StandardMaxVelocity;
        }



        public Road(Town locationA, Town locationB) : this(locationA, locationB, StandardMinVelocity, StandardMaxVelocity)
        {
        }



        public Road(Town locationA, Town locationB, decimal minVelocity, decimal maxVelocity)
        {
            this.LocationA = locationA;
            this.LocationB = locationB;
            this.RoadNo = this.LocationA.Code + "-" + this.LocationB.Code;
            this.MinVelocity = minVelocity;
            this.MaxVelocity = maxVelocity;
        }



        public Road(string roadNo, Town locationA, Town locationB, decimal minVelocity, decimal maxVelocity)
        {
            this.RoadNo = roadNo;
            this.LocationA = locationA;
            this.LocationB = locationB;
            this.MinVelocity = minVelocity;
            this.MaxVelocity = maxVelocity;
        }



        public Road(Road road)
        {
            this.RoadNo = road.RoadNo;
            this.LocationA = road.LocationA;
            this.LocationB = road.LocationB;
            this.MinVelocity = road.MinVelocity;
            this.MaxVelocity = road.MaxVelocity;
        }



        public bool EqualsInLocationsAndDirection(Road other)
        {
            return ((this.LocationA.Code == other.LocationA.Code) && (this.LocationB.Code == other.LocationB.Code));
        }



        public bool EqualsInLocationsWithOppositeDirection(Road other)
        {
            return ((this.LocationA.Code == other.LocationB.Code) && (this.LocationB.Code == other.LocationA.Code));
        }



        public bool EqualsInLocationsRegardlessOfDirection(Road other)
        {
            return (this.EqualsInLocationsAndDirection(other) || this.EqualsInLocationsWithOppositeDirection(other));
        }



        public int CompareTo(Road other)
        {
            return this.RoadNo.CompareTo(other.RoadNo);
        }



        public override string ToString()
        {
            return $"Silnice \'{this.RoadNo}\': z {this.LocationA.Name} do {this.LocationB.Name}";
        }



        public override bool Equals(object? obj)
        {

            Road other = obj as Road;

            if (other == null)
            {
                return false;
            }

            return (this.RoadNo == other.RoadNo);

        }



        public override int GetHashCode()
        {
            return this.RoadNo.GetHashCode();
        }



    }



}
