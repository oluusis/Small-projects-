using System;
using System.Collections.Generic;
using System.Text;



namespace GpsMapLibP3Agr2Library.BusinessObjects
{



    public class CityCode
    {



        public string Name { get; set; }
        public string Code { get; set; }



        public CityCode()
        {
        }



        public CityCode(string name, string code)
        {
            this.Name = name;
            this.Code = code;
        }



    }



}
