using GpsMapLibP3Agr2Library;
using GpsMapLibP3Agr2Library.BusinessObjects;
using GpsMapLibP3Agr2Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_du_Vehicle_and_Roads
{
    internal class SimulationManager
    {
        private IRoadMap roadMap;
        private List<Town> towns;

        public SimulationManager()
        {
            roadMap = RoadMapFactory.GetRoadMap();
            towns = roadMap.GetTowns();
        }

        public Town IniStartTown()
        {
            WriteTowns();
            Console.Write("Zadejte start z města: ");
            string startTown = Console.ReadLine();
            Console.Clear();
            return towns.Find(t => t.Name == startTown);
        }


        public Town IniFinallTown()
        {
            WriteTowns();
            Console.Write("Zadejte do města: ");
            string finallTown = Console.ReadLine(); 
            Console.Clear();
            return towns.Find(t => t.Name == finallTown);         
        }


        private void WriteTowns()
        {
            foreach (var item in this.towns)
            {
                Console.WriteLine(item.Name);
            }
        }

        public void StartSimulation(List<Vehicle> v)
        {
            
            foreach (var item in v)
            {
                Thread t = new Thread(ProvestAsync);
                t.Start(item);
            }
        }

        private static void ProvestAsync(Object? obj)
        {
            Vehicle v = (Vehicle)obj;
            v.ChooseWay();
        }
    }
}
