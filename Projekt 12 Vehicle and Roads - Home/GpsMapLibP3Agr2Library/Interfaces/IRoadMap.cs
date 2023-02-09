using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GpsMapLibP3Agr2Library.BusinessObjects;



namespace GpsMapLibP3Agr2Library.Interfaces
{



    public interface IRoadMap
    {



        // Gets a list of all towns available in the map.
        List<Town> GetTowns();



        // Gets a list of directions that you can take from a particular town.
        //List<Road> GetTownDirections(Town town);
        List<Road> GetTownDirections(string townCode);



        /// <summary>
        /// Tries to move on a given road. Returns the new position depending on other parameters.
        /// </summary>
        /// <param name="currentLocation">Point on the map that the vehicle is located at the moment.</param>
        /// <param name="roadNo">Road the vehicle is going on.</param>
        /// <param name="fromAToB">True :-: the vehicle goes from location A to location B, false :-: the vehicle goes from B to A.</param>
        /// <param name="velocity">Vehicle speed in km/h.</param>
        /// <param name="timePeriod">Amount of time (in hours) that the vehicle shall be going from the current position (with the same velocity).</param>
        /// <returns>Returns new point where the vehicle gets after the given amount of time.</returns>
        Gps MoveOnRoad(Gps currentLocation, string roadNo, bool fromAToB, decimal velocity, decimal timePeriod);



        // Checks where the given position is - in a town, or on a road, or off any roads/towns.
        void WhereAmI(Gps currentLocation, out Town town, out Road road);



    }



}
