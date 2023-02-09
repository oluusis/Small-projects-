using System;
using System.Collections.Generic;
using System.Text;



namespace GpsMapLibP3Agr2Library.BusinessObjects
{



    public class HighwayCityCouple
    {



        public string CityCodeFrom { get; set; }
        public string CityCodeTo { get; set; }



        public HighwayCityCouple()
        {
        }



        public HighwayCityCouple(string cityCodeFrom, string cityCodeTo)
        {
            this.CityCodeFrom = cityCodeFrom;
            this.CityCodeTo = cityCodeTo;
        }



    }



}
