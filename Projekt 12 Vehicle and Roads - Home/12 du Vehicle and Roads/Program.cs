namespace _12_du_Vehicle_and_Roads
{
    using GpsMapLibP3Agr2Library;
    using GpsMapLibP3Agr2Library.BusinessObjects;
    using GpsMapLibP3Agr2Library.Interfaces;
    using System.Net.Http.Headers;

    public class Program
    {
        static void Main(string[] args)
        {
            
            SimulationManager sm = new SimulationManager();

            Car car1 = new Car(100, 50, "Audi", 80,200, sm.IniStartTown(), sm.IniFinallTown());           
            Car car2 = new Car(100, 100, "Škoda", 59,180, sm.IniStartTown(), sm.IniFinallTown());
            Motorcycle motorcycle = new Motorcycle(100, "Yamaha", 100,120, sm.IniStartTown(), sm.IniFinallTown());
            Truck truck = new Truck(100, "Truck", 80, 100, sm.IniStartTown(), sm.IniFinallTown());
            Bicycle bicycle = new Bicycle(100, "Kolooo", 30, 80, sm.IniStartTown(), sm.IniFinallTown());

            sm.StartSimulation( new List<Vehicle> { car1, car2, motorcycle, truck, bicycle });

        }
    }
}