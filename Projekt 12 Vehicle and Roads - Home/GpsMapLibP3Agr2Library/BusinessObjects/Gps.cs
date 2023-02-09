using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

using GpsMapLibP3Agr2Library.Helper;



namespace GpsMapLibP3Agr2Library.BusinessObjects
{



    public struct Gps
    {

        // Zeměpisná šířka.
        // Severní šířka (N) ....... > 0
        // Jižní šířka (S) ......... < 0
        private decimal latitude;

        // Zeměpisná délka.
        // Východní délka (E) ...... > 0
        // Západní délka (W) ....... < 0
        private decimal longitude;


        //public Gps()
        //{
        //    this.latitude = 0.0m;
        //    this.longitude = 0.0m;
        //}

        public Gps(decimal latitude, decimal longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public Gps(string fromMapyCZ)
        {
            // 49.7494842N, 13.3871119E
            string[] parts = fromMapyCZ.Split(' ');

            string partLat = parts[0].Substring(0, parts[0].Length - 1);
            string partLon = parts[1];

            string absPartLat = partLat.Substring(0, partLat.Length - 1);
            CompassDirection latDir = (CompassDirection)Enum.Parse(typeof(CompassDirection), partLat[partLat.Length - 1].ToString());
            //this.latitude = decimal.Parse(absPartLat) * ((latDir == CompassDirection.N) ? (+1) : ((latDir == CompassDirection.S) ? (-1) : (0)));
            this.latitude = decimal.Parse(absPartLat, CultureInfo.InvariantCulture) * ((latDir == CompassDirection.N) ? (+1) : ((latDir == CompassDirection.S) ? (-1) : (0)));

            string absPartLon = partLon.Substring(0, partLon.Length - 1);
            CompassDirection lonDir = (CompassDirection)Enum.Parse(typeof(CompassDirection), partLon[partLon.Length - 1].ToString());
            //this.longitude = decimal.Parse(absPartLon) * ((lonDir == CompassDirection.E) ? (+1) : ((lonDir == CompassDirection.W) ? (-1) : (0)));
            this.longitude = decimal.Parse(absPartLon, CultureInfo.InvariantCulture) * ((lonDir == CompassDirection.E) ? (+1) : ((lonDir == CompassDirection.W) ? (-1) : (0)));
        }


        public decimal Latitude
        {
            get { return this.latitude; }
            set { this.latitude = value; }
        }



        public decimal Longitude
        {
            get { return this.longitude; }
            set { this.longitude = value; }
        }



        public int LatDeg
        {
            //get { return Convert.ToInt32(this.latitude); }
            //get { return MathD.IntVal(this.latitude); }
            get { return MathD.IntAbsVal(this.latitude); }
        }
        public int LatMin
        {
            //get { return MathD.IntVal((this.latitude - MathD.IntVal(this.latitude)) * 60); }
            get { return MathD.IntVal(MathD.FracAbsVal(this.latitude) * 60); }
        }
        public int LatSec
        {
            //get { return Convert.ToInt32((((this.latitude - Convert.ToInt32(this.latitude)) * 60) - Convert.ToInt32((this.latitude - Convert.ToInt32(this.latitude)) * 60)) * 60); }
            get { return MathD.IntVal(MathD.FracVal(MathD.FracAbsVal(this.latitude) * 60) * 60); }
        }
        public CompassDirection LatDir
        {
            //get { return ((this.latitude > 0) ? (CompassDirection.N) : (CompassDirection.S)); }
            get { return ((this.latitude >= 0) ? (CompassDirection.N) : (CompassDirection.S)); }
        }



        public int LonDeg
        {
            //get { return Convert.ToInt32(this.longitude); }
            get { return MathD.IntAbsVal(this.longitude); }
        }
        public int LonMin
        {
            //get { return Convert.ToInt32((this.longitude - Convert.ToInt32(this.longitude)) * 60); }
            get { return MathD.IntVal(MathD.FracAbsVal(this.longitude) * 60); }
        }
        public int LonSec
        {
            //get { return Convert.ToInt32((((this.longitude - Convert.ToInt32(this.longitude)) * 60) - Convert.ToInt32((this.longitude - Convert.ToInt32(this.longitude)) * 60)) * 60); }
            get { return MathD.IntVal(MathD.FracVal(MathD.FracAbsVal(this.longitude) * 60) * 60); }
        }
        public CompassDirection LonDir
        {
            //get { return ((this.longitude > 0) ? (CompassDirection.E) : (CompassDirection.W)); }
            get { return ((this.longitude >= 0) ? (CompassDirection.E) : (CompassDirection.W)); }
        }



        // To simplify math formulas
        public decimal X
        {
            get { return this.longitude; }
        }
        public decimal Y
        {
            get { return this.latitude; }
        }



        public override string ToString()
        {
            // Use mapy.cz notation:
            // 49.7494842N, 13.3871119E
            //return $"{Math.Abs(this.latitude):0.0000000}{this.LatDir}, {Math.Abs(this.longitude):0.0000000}{this.LonDir}";
            return $"{MathD.Abs(this.latitude):0.0000000}{this.LatDir}, {MathD.Abs(this.longitude):0.0000000}{this.LonDir}";
        }



        public override int GetHashCode()
        {
            return this.latitude.GetHashCode() ^ this.longitude.GetHashCode();
        }



        public bool Equals(Gps other)
        {
            if ((this.latitude == other.latitude) && (this.longitude == other.longitude))
            {
                return true;
            }

            return false;
        }



        public override bool Equals(object obj)
        {
            if (!(obj is Gps))
            {
                return false;
            }

            Gps other = (Gps)obj;

            //if ((this.latitude == other.latitude) && (this.longitude == other.longitude))
            //{
            //    return true;
            //}

            //return false;
            return Equals(other);
        }



        public static bool operator ==(Gps gps1, Gps gps2)
        {
            // With a "struct" we needn't handle the "null" cases.
            return gps1.Equals(gps2);
        }



        public static bool operator !=(Gps gps1, Gps gps2)
        {
            // With a "struct" we needn't handle the "null" cases.
            return !(gps1.Equals(gps2));
        }



    }



}
