using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GpsMapLibP3Agr2Library.BusinessObjects;
using GpsMapLibP3Agr2Library.Interfaces;
using GpsMapLibP3Agr2Library.Helper;



namespace GpsMapLibP3Agr2Library.BusinessLogic
{



    public class TestRoadMap : IRoadMap
    {



        // If two numbers (A and B) are "so close" that their difference (A - B)
        // in absolute value |A - B| is less than this epsilon,
        // then you can consider A and B to e equal.
        private const decimal Epsilon = 0.000000001m;



        // Towns on the map.
        private List<Town> towns;

        // Roads on the map.
        private List<Road> roads;



        public TestRoadMap()
        {
            CreateTestTowns();
            CreateTestRoads();
        }



        // ***************************************************************************
        // ***************************************************************************
        // Interface methods - IMPLEMENTATION - Begin
        // ***************************************************************************
        // ***************************************************************************



        public List<Town> GetTowns()
        {
            //List<Town> towns = CreateTestTowns();
            //return towns;
            return this.towns;
        }



        //public List<Road> GetTownDirections(Town town)
        public List<Road> GetTownDirections(string townCode)
        {
            //List<Town> towns = CreateTestTowns();
            Town town = null;
            //foreach (Town t in towns)
            foreach (Town t in this.towns)
            {
                if (t.Code == townCode)
                {
                    town = t;
                    break;
                }
            }
            if (town == null)
            {
                throw new InvalidOperationException($"Town \'{townCode}\' not found.");
            }


            //List<Road> roads = CreateTestRoads();

            List<Road> directions = new List<Road>();
            //foreach (Road road in roads)
            foreach (Road road in this.roads)
            {
                if ( (road.LocationA.Code == townCode) || (road.LocationB.Code == townCode) )
                {
                    directions.Add(road);
                }
            }

            return directions;
        }



        public Gps MoveOnRoad(Gps currentLocation, string roadNo, bool fromAToB, decimal velocity, decimal timePeriod)
        {

            // Check that the given road exists.
            Road road = FindRoadByRoadNo(roadNo);

            // Determine which location is A and which is B for this particular case.
            Gps a;
            Gps b;
            if (fromAToB)
            {
                // Going from location A to location B.
                a = road.LocationA.Gps;
                b = road.LocationB.Gps;
            }
            else
            {
                // Going the other way around.
                a = road.LocationB.Gps;
                b = road.LocationA.Gps;
            }

            // Go!
            Gps newLocation = TryMove(currentLocation, a, b, velocity, timePeriod);
            return newLocation;

        }



        // There are 3 options:
        // Either town != null and road == null: You're in a town! :-)
        // Or town == null and road != null: You're on a road! :-)
        // Or town == null and road == null: You're lost! :-(
        // ***
        // If this method returns town == null, that means you're out of any town on the map.
        // If the method returns road == null, that means you're off any road on the map.
        public void WhereAmI(Gps currentLocation, out Town town, out Road road)
        {

            // Initialize the "out" parameters.
            town = null;
            road = null;

            // Check towns first.
            foreach (Town t in this.towns)
            {
                if (t.Gps == currentLocation)
                {
                    town = t;
                    return;
                }
            }

            // Check roads second.
            // We assume the roads are (segments of) straight lines.
            foreach (Road r in this.roads)
            {
                if (IsOnLineSegment(currentLocation, r.LocationA.Gps, r.LocationB.Gps))
                {
                    road = r;
                    return;
                }
            }

            // Return (no good - you're off road, off towns).
            return;
        }



        // ***************************************************************************
        // ***************************************************************************
        // Interface methods - IMPLEMENTATION - End
        // ***************************************************************************
        // ***************************************************************************



        //private List<Town> CreateTestTowns()
        private void CreateTestTowns()
        {
            //Town praha = new Town { Name = "Praha", Code = "Prg", Gps = new Gps(50.0885808m, 14.4167369m) };
            Town praha = new Town { Name = "Praha", Code = "Prg", Gps = new Gps("50.0784469N, 14.4582789E") };
            Town plzen = new Town { Name = "Plzeň", Code = "Pls", Gps = new Gps("49.7494842N, 13.3871119E") };
            Town brno = new Town { Name = "Brno", Code = "Brn", Gps = new Gps("49.1998086N, 16.5882533E") };

            Town jihlava = new Town { Name = "Jihlava", Code = "Jih", Gps = new Gps("49.3892322N, 15.5854075E") };

            Town hradecKralove = new Town { Name = "Hradec Králové", Code = "HrK", Gps = new Gps("50.2065036N, 15.8229869E") };
            Town liberec = new Town { Name = "Liberec", Code = "Lib", Gps = new Gps("50.7587633N, 15.0683636E") };
            Town ustiNadLabem = new Town { Name = "Ústí nad Labem", Code = "UnL", Gps = new Gps("50.6683286N, 14.0088694E") };

            Town karlovyVary = new Town { Name = "Karlovy Vary", Code = "KaV", Gps = new Gps("50.2223219N, 12.8717844E") };
            Town ceskeBudejovice = new Town { Name = "České Budějovice", Code = "CBd", Gps = new Gps("48.9763169N, 14.4812817E") };
            Town pardubice = new Town { Name = "Pardubice", Code = "Par", Gps = new Gps("50.0286281N, 15.7666819E") };

            Town olomouc = new Town { Name = "Olomouc", Code = "Olm", Gps = new Gps("49.5854964N, 17.2388500E") };
            Town ostrava = new Town { Name = "Ostrava", Code = "Ost", Gps = new Gps("49.8483203N, 18.2605783E") };
            Town zlin = new Town { Name = "Zlín", Code = "Zln", Gps = new Gps("49.2316542N, 17.6508372E") };

            //return new List<Town> {
            this.towns = new List<Town> {
                praha, plzen, brno,
                jihlava,
                hradecKralove, liberec,
                ustiNadLabem, karlovyVary,
                ceskeBudejovice, pardubice,
                olomouc, ostrava, zlin
            };
        }



        //private List<Road> CreateTestRoads()
        private void CreateTestRoads()
        {
            //List<Road> roads = new List<Road>();
            this.roads = new List<Road>();

            //List<Town> towns = CreateTestTowns();

            // Prg, Pls, Brn, Jih, HrK, Lib, UnL, KaV, CBd, Par, Olm, Ost, Zln

            //AddRoad(roads, towns, "Prg-KaV", "Prg", "KaV", 40, 90, 6 * 20);
            //AddRoad(roads, towns, "Prg-Pls", "Prg", "Pls", 70, 130, 3.5m * 20);
            //AddRoad(roads, towns, "Prg-CBd", "Prg", "CBd", 40, 90, 7 * 20);
            //AddRoad(roads, towns, "Prg-Jih", "Prg", "Jih", 70, 130, 6.5m * 20);
            //AddRoad(roads, towns, "Prg-Par", "Prg", "Par", 40, 100, 4 * 20);
            //AddRoad(roads, towns, "Prg-HrK", "Prg", "HrK", 70, 130, 5.5m * 20);
            //AddRoad(roads, towns, "Prg-Lib", "Prg", "Lib", 40, 100, 4.5m * 20);
            //AddRoad(roads, towns, "Prg-UnL", "Prg", "UnL", 70, 130, 4 * 20);
            //AddRoad(roads, towns, "KaV-Pls", "KaV", "Pls", 40, 100, 5 * 20);
            //AddRoad(roads, towns, "Pls-CBd", "Pls", "CBd", 40, 100, 8 * 20);
            //AddRoad(roads, towns, "CBd-Jih", "CBd", "Jih", 40, 100, 6 * 20);
            //AddRoad(roads, towns, "Jih-Par", "Jih", "Par", 40, 100, 5.5m * 20);
            //AddRoad(roads, towns, "Par-HrK", "Par", "HrK", 40, 100, 1.0m * 20);
            ////AddRoad(roads, towns, "HrK-Lib", "HrK", "Lib", 40, 100, 7 * 20);
            //AddRoad(roads, towns, "Lib-UnL", "Lib", "UnL", 40, 100, 5 * 20);
            ////AddRoad(roads, towns, "UnL-KaV", "UnL", "KaV", 40, 100, 9 * 20);
            //AddRoad(roads, towns, "Par-Olm", "Par", "Olm", 40, 100, 7.5m * 20);
            //AddRoad(roads, towns, "HrK-Olm", "HrK", "Olm", 40, 100, 8.0m * 20);
            //AddRoad(roads, towns, "Olm-Ost", "Olm", "Ost", 70, 130, 4 * 20);
            //AddRoad(roads, towns, "Olm-Zln", "Olm", "Zln", 40, 100, 3.5m * 20);
            //AddRoad(roads, towns, "Olm-Brn", "Olm", "Brn", 70, 130, 3 * 20);
            //AddRoad(roads, towns, "Jih-Brn", "Jih", "Brn", 70, 130, 4 * 20);
            //AddRoad(roads, towns, "Jih-Olm", "Jih", "Olm", 40, 100, 7 * 20);
            //AddRoad(roads, towns, "Brn-Zln", "Brn", "Zln", 40, 100, 5 * 20);

            AddRoad("Prg-KaV", "Prg", "KaV", 40, 90, 6 * 20);
            AddRoad("Prg-Pls", "Prg", "Pls", 70, 130, 3.5m * 20);
            AddRoad("Prg-CBd", "Prg", "CBd", 40, 90, 7 * 20);
            AddRoad("Prg-Jih", "Prg", "Jih", 70, 130, 6.5m * 20);
            AddRoad("Prg-Par", "Prg", "Par", 40, 100, 4 * 20);
            AddRoad("Prg-HrK", "Prg", "HrK", 70, 130, 5.5m * 20);
            AddRoad("Prg-Lib", "Prg", "Lib", 40, 100, 4.5m * 20);
            AddRoad("Prg-UnL", "Prg", "UnL", 70, 130, 4 * 20);
            AddRoad("KaV-Pls", "KaV", "Pls", 40, 100, 5 * 20);
            AddRoad("Pls-CBd", "Pls", "CBd", 40, 100, 8 * 20);
            AddRoad("CBd-Jih", "CBd", "Jih", 40, 100, 6 * 20);
            AddRoad("Jih-Par", "Jih", "Par", 40, 100, 5.5m * 20);
            AddRoad("Par-HrK", "Par", "HrK", 40, 100, 1.0m * 20);
            //AddRoad("HrK-Lib", "HrK", "Lib", 40, 100, 7 * 20);
            AddRoad("Lib-UnL", "Lib", "UnL", 40, 100, 5 * 20);
            //AddRoad("UnL-KaV", "UnL", "KaV", 40, 100, 9 * 20);
            AddRoad("Par-Olm", "Par", "Olm", 40, 100, 7.5m * 20);
            AddRoad("HrK-Olm", "HrK", "Olm", 40, 100, 8.0m * 20);
            AddRoad("Olm-Ost", "Olm", "Ost", 70, 130, 4 * 20);
            AddRoad("Olm-Zln", "Olm", "Zln", 40, 100, 3.5m * 20);
            AddRoad("Olm-Brn", "Olm", "Brn", 70, 130, 3 * 20);
            AddRoad("Jih-Brn", "Jih", "Brn", 70, 130, 4 * 20);
            AddRoad("Jih-Olm", "Jih", "Olm", 40, 100, 7 * 20);
            AddRoad("Brn-Zln", "Brn", "Zln", 40, 100, 5 * 20);

            //return roads;
        }



        private void AddRoad(
            //List<Road> roads,
            //List<Town> towns,
            string roadNo, string townCodeA, string townCodeB, decimal minVelocity, decimal maxVelocity, decimal distance
            )
        {
            //Town locationA = FindTownByCode(towns, townCodeA);
            //Town locationB = FindTownByCode(towns, townCodeB);
            Town locationA = FindTownByCode(townCodeA);
            Town locationB = FindTownByCode(townCodeB);

            TestRoad testRoad = new TestRoad {
                RoadNo = roadNo,
                LocationA = locationA,
                LocationB = locationB,
                MinVelocity = minVelocity,
                MaxVelocity = maxVelocity,
                Distance = distance
            };

            //roads.Add(testRoad);
            this.roads.Add(testRoad);
        }



        //private Town FindTownByCode(List<Town> towns, string townCode)
        private Town FindTownByCode(string townCode)
        {
            //foreach (Town town in towns)
            foreach (Town town in this.towns)
            {
                if (town.Code == townCode)
                {
                    return town;
                }
            }

            throw new Exception($"Town \'{townCode}\' not found.");
        }



        private Road FindRoadByRoadNo(string roadNo)
        {
            foreach (Road road in this.roads)
            {
                if (road.RoadNo == roadNo)
                {
                    return road;
                }
            }

            throw new InvalidOperationException($"Road \'{roadNo}\' not found.");
        }



        // Gets true :-: the given point is BETWEEN lineStart and lineEnd, false :-: the point is elsewhere.
        // (Excluding the limits/edges of the line segment.)
        private bool IsOnLineSegment(Gps point, Gps lineStart, Gps lineEnd)
        {
            // Assumption:
            // X-coord is Longitude.
            // Y-coord is Latitude.
            // ***
            // We have 2 points:
            // A = [xa, ya] = lineStart
            // B = [xb, yb] = lineEnd
            // ***
            // We need to get the simple line formula:
            // y = kx + t
            // ***
            // k = (yb - ya) / (xb - xa)
            // t = (xb * ya - xa * yb) / (xb - xa)

            // Transform GPS into LPS.
            //Gps a = lineStart;
            //Gps b = lineEnd;
            Lps a = new Lps(lineStart);
            Lps b = new Lps(lineEnd);
            decimal k = (b.Y - a.Y) / (b.X - a.X);
            decimal t = (b.X * a.Y - a.X * b.Y) / (b.X - a.X);

            // Do the transformation for the given point as well.
            Lps p = new Lps(point);

            // If point lies on a line segment <lineStart, lineEnd>, then:
            // (a) It must lie on the straight line going through lineStart and lineEnd.
            // (b) Its coords must go BETWEEN lineStart and lineEnd coords.

            // Check the condition (a):
            //bool condAMet = (k * point.X + t == point.Y);
            //bool condAMet = (AreEqual(k * point.X + t, point.Y));
            bool condAMet = (AreEqual(k * p.X + t, p.Y));

            // If (a) is not met, there is no need to check (b).
            if (condAMet)
            {
                bool condBMet = false;

                bool condBMetForX = false;
                bool condBMetForY = false;

                // Check X coords.
                if (a.X < b.X)
                {
                    //condBMetForX = ((a.X < point.X) && (point.X < b.X));
                    condBMetForX = ((a.X < p.X) && (p.X < b.X));
                }
                else
                {
                    //condBMetForX = ((b.X < point.X) && (point.X < a.X));
                    condBMetForX = ((b.X < p.X) && (p.X < a.X));
                }

                // Check Y coords.
                if (a.Y < b.Y)
                {
                    //condBMetForY = ((a.Y < point.Y) && (point.Y < b.Y));
                    condBMetForY = ((a.Y < p.Y) && (p.Y < b.Y));
                }
                else
                {
                    //condBMetForY = ((b.Y < point.Y) && (point.Y < a.Y));
                    condBMetForY = ((b.Y < p.Y) && (p.Y < a.Y));
                }

                condBMet = condBMetForX && condBMetForY;
                // return condAMet && condBMet;
                return condBMet;
            }
            else
            {
                // (a) is not met:
                // The given point LIES NOT on the line segment given by lineStart and lineEnd.
                return false;
            }
        }



        // LocationA - start town.
        // LocationB - end town.
        private Gps TryMove(Gps currentLocation, Gps locationA, Gps locationB, decimal velocity, decimal timePeriod)
        {
            //Gps newLocation;
            Gps newLocation = new Gps();

            // There are 4 options for the current location:
            // (1) You're in A (at the start).
            // (2) You're in B (you've finished moving already).
            // (3) You're somewhere between A and B (on the line segment AB).
            // (4) You're lost (somewhere else) - this is illegal for this method.

            // Check B first. If in B, don't move any further.
            if (currentLocation == locationB)
            {
                return currentLocation;
            }

            // Check A or between A and B.
            if ((currentLocation == locationA) || (IsOnLineSegment(currentLocation, locationA, locationB)))
            {
                // Alright - let's keep moving!

                // First of all - you need to transform the GPS coords into LPS coords.
                Lps a = new Lps(locationA);
                Lps b = new Lps(locationB);

                Lps cur = new Lps(currentLocation);

                // First:
                // Get X and Y of the distance between A and B.
                //decimal xDist = locationB.X - locationA.X;
                //decimal yDist = locationB.Y - locationA.Y;
                decimal xDist = b.X - a.X;
                decimal yDist = b.Y - a.Y;

                // Second:
                // Get the real distance between A and B.
                //decimal dist = Convert.ToDecimal(Math.Sqrt(Convert.ToDouble(xDist * xDist + yDist * yDist)));
                decimal dist = MathD.Sqrt(xDist * xDist + yDist * yDist);

                // Third:
                // Get X and Y of the velocity using "cross-multiplication" (proportionality).
                decimal xVelo = xDist * velocity / dist;
                decimal yVelo = yDist * velocity / dist;

                //// Three and half-th:
                //// Adjust the velocity according to the average latitude/longitude degree length.
                //decimal xVeloAdjusted = xVelo / LongitudeDegreeLength;
                //decimal yVeloAdjusted = yVelo / LatitudeDegreeLength;

                // Fourth:
                // Calculate the new coords.
                //decimal newX = currentLocation.X + xVelo * timePeriod;
                //decimal newY = currentLocation.Y + yVelo * timePeriod;
                // ***
                decimal newX = cur.X + xVelo * timePeriod;
                decimal newY = cur.Y + yVelo * timePeriod;
                // ***
                //decimal newX = currentLocation.X + xVeloAdjusted * timePeriod;
                //decimal newY = currentLocation.Y + yVeloAdjusted * timePeriod;
                //Gps newPoint = new Gps(newY, newX);
                //Gps newPoint = new Gps(new Lps(newY, newX));
                //Gps newPoint = new Gps(new Lps(newX, newY));
                Gps newPoint = (new Lps(newX, newY)).ToGps();

                // Fifth:
                // Check whether the new point is BETWEEN A and B:
                // If so, then return that new point.
                // If NOT, then return B rather than a point beyond B.
                if (IsOnLineSegment(newPoint, locationA, locationB))
                {
                    // Still BETWEEN the edges (between A and B).
                    // OK - let's go up there.
                    newLocation = newPoint;
                }
                else
                {
                    // The new location would already be BEYOND the location B.
                    // Therefore we return B rather than the actual new point.
                    newLocation = locationB;
                }

                return newLocation;
            }

            //return newLocation;
            throw new InvalidOperationException($"{currentLocation} is off any roads/towns!");
        }



        private bool AreEqual(decimal a, decimal b)
        {
            return ((a < b) ? (b - a < Epsilon) : (a - b < Epsilon));
        }



    }



}
