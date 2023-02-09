using System;
using System.Collections.Generic;
using System.Text;



namespace GpsMapLibP3Agr2Library.BusinessObjects
{



    // GPS = Global Positioning System, i.e. on the Global (a sphere).
    // LPS = Local Positioning System, used locally in the Czech Republic - as if the area of Czech Republic was spread on a plane rather than on a sphere.
    // With LPS, we use km as a unit of distance.
    public struct Lps
    {



        // Length of a meridian in km.
        // (From a pole to the other one.)
        public const decimal MeridianLength = 20004.5765m;
        // Length of one latitude degree on a meridian (in km).
        public const decimal LatitudeDegreeLength = MeridianLength / 180;

        // Length of the 50th circle of latitude in km.
        public const decimal FiftiethCircleOfLatitudeLength = 25730.8995985m;
        // Length of one longitude degree on the 50th circle of latitude (in km).
        public const decimal LongitudeDegreeLength = FiftiethCircleOfLatitudeLength / 360;



        // X means longitude.
        private decimal x;

        // Y means latitude.
        private decimal y;



        public Lps(Gps location)
        {
            this.x = location.Longitude * LongitudeDegreeLength;
            this.y = location.Latitude * LatitudeDegreeLength;
        }



        public Lps(decimal x, decimal y)
        {
            this.x = x;
            this.y = y;
        }



        public decimal X
        {
            get { return this.x; }
        }

        public decimal Y
        {
            get { return this.y; }
        }



        public Gps ToGps()
        {
            //Gps location = new Gps(this.x / LongitudeDegreeLength, this.y / LatitudeDegreeLength);
            Gps location = new Gps(this.y / LatitudeDegreeLength, this.x / LongitudeDegreeLength);
            return location;
        }



        public override string ToString()
        {
            return $"x: {this.x:0.0000000}, y: {this.y:0.0000000}";
        }



        public override int GetHashCode()
        {
            return this.x.GetHashCode() ^ this.y.GetHashCode();
        }



        public bool Equals(Lps other)
        {
            if ((this.x == other.x) && (this.y == other.y))
            {
                return true;
            }

            return false;
        }



        public override bool Equals(object obj)
        {
            if (!(obj is Lps))
            {
                return false;
            }

            Lps other = (Lps) obj;

            return Equals(other);
        }



        public static bool operator ==(Lps lps1, Lps lps2)
        {
            // With a "struct" we needn't handle the "null" cases.
            return lps1.Equals(lps2);
        }



        public static bool operator !=(Lps lps1, Lps lps2)
        {
            // With a "struct" we needn't handle the "null" cases.
            return !(lps1.Equals(lps2));
        }



    }



}
