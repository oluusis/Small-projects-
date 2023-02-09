using System;
using System.Collections.Generic;
using System.Text;



namespace GpsMapLibP3Agr2Library.BusinessObjects
{



    /// <summary>
    /// Represents a motorway (a highway).
    /// </summary>
    public class Highway : Road 
    {



        public static HighwayCityCouple[] HighwayCityCouples = new HighwayCityCouple[] {
            new HighwayCityCouple("Prg", "KaV"),
            new HighwayCityCouple("Prg", "Pls"),
            new HighwayCityCouple("Prg", "CBd"),
            new HighwayCityCouple("Prg", "Jih"),
            new HighwayCityCouple("Prg", "Par"),
            new HighwayCityCouple("Prg", "HrK"),
            new HighwayCityCouple("Prg", "Lib"),
            new HighwayCityCouple("Prg", "UnL"),
            new HighwayCityCouple("KaV", "Pls"),
            new HighwayCityCouple("Pls", "CBd"),
            new HighwayCityCouple("CBd", "Jih"),
            new HighwayCityCouple("Jih", "Par"),
            new HighwayCityCouple("Par", "HrK"),
            //new HighwayCityCouple("HrK", "Lib"),
            new HighwayCityCouple("Lib", "UnL"),
            //new HighwayCityCouple("UnL", "KaV"),
            new HighwayCityCouple("Par", "Olm"),
            new HighwayCityCouple("HrK", "Olm"),
            new HighwayCityCouple("Olm", "Ost"),
            new HighwayCityCouple("Olm", "Zln"),
            new HighwayCityCouple("Olm", "Brn"),
            new HighwayCityCouple("Jih", "Brn"),
            new HighwayCityCouple("Jih", "Olm"),
            new HighwayCityCouple("Brn", "Zln")
        };



        public Highway(Town locationA, Town locationB) : base(locationA, locationB, HighwayMinVelocity, HighwayMaxVelocity)
        {
        }



        public Highway(string roadNo, Town locationA, Town locationB, decimal minVelocity, decimal maxVelocity) : base(roadNo, locationA, locationB, minVelocity, maxVelocity)
        {
        }



        public Highway(Road road) : base(road)
        {
        }



        public override string ToString()
        {
            return $"Dálnice \'{this.RoadNo}\': z {this.LocationA.Name} do {this.LocationB.Name}";
        }



    }



}
