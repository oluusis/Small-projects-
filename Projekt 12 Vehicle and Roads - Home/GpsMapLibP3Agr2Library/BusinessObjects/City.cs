using System;
using System.Collections.Generic;
using System.Text;



namespace GpsMapLibP3Agr2Library.BusinessObjects
{



    public class City : Town
    {



        public const string CodeOfPraha = "Prg";



        public static CityCode[] CityCodes = new CityCode[] {
            //new CityCode { Name = "Praha", Code = "Prg" },
            new CityCode { Name = "Praha", Code = CodeOfPraha },
            new CityCode { Name = "Plzeň", Code = "Pls" },
            new CityCode { Name = "Brno", Code = "Brn" },

            new CityCode { Name = "Jihlava", Code = "Jih" },

            new CityCode { Name = "Hradec Králové", Code = "HrK" },
            new CityCode { Name = "Liberec", Code = "Lib" },
            new CityCode { Name = "Ústí nad Labem", Code = "UnL" },

            new CityCode { Name = "Karlovy Vary", Code = "KaV" },
            new CityCode { Name = "České Budějovice", Code = "CBd" },
            new CityCode { Name = "Pardubice", Code = "Par" },

            new CityCode { Name = "Olomouc", Code = "Olm" },
            new CityCode { Name = "Ostrava", Code = "Ost" },
            new CityCode { Name = "Zlín", Code = "Zln" }
        };



        public City()
        {
        }



        public City(Town town) : base((Municipality) town, false)
        {
            this.Name = town.Name;
            this.Code = town.Code;
            this.Gps = town.Gps;
        }



    }



}
