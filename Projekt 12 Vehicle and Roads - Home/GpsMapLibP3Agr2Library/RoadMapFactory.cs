using GpsMapLibP3Agr2Library.BusinessLogic;
using GpsMapLibP3Agr2Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpsMapLibP3Agr2Library
{
    public static class RoadMapFactory
    {

        public static IRoadMap GetRoadMap()
        {
            return new CzechRepublicRoadMap();
            //return new TestRoadMap();
        }

    }
}
