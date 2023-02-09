using System;
using System.Collections.Generic;
using System.Text;



// Convenience class for mathematical functions with arguments and values in decimal.
namespace GpsMapLibP3Agr2Library.Helper
{



    public static class MathD
    {



        //public const decimal PI = Convert.ToDecimal(Math.PI);
        public static readonly decimal PI = Convert.ToDecimal(Math.PI);



        public static decimal Abs(decimal val)
        {
            if (val >= 0.0m)
            {
                return val;
            }
            return (-val);
        }



        public static decimal Round(decimal val, int fractionalDigits)
        {
            return Math.Round(val, fractionalDigits);
        }



        public static decimal Floor(decimal val)
        {
            return Math.Floor(val);
        }



        public static decimal Ceiling(decimal val)
        {
            return Math.Ceiling(val);
        }



        public static decimal Truncate(decimal val)
        {
            return Math.Truncate(val);
        }



        public static decimal TruncateAbs(decimal val)
        {
            return Math.Truncate(MathD.Abs(val));
        }



        public static int IntVal(decimal val)
        {
            return Convert.ToInt32(Math.Truncate(val));
        }



        public static decimal FracVal(decimal val)
        {
            return val - Math.Truncate(val);
        }



        public static int IntAbsVal(decimal val)
        {
            return Convert.ToInt32(Math.Truncate(MathD.Abs(val)));
        }



        public static decimal FracAbsVal(decimal val)
        {
            return MathD.Abs(val) - Math.Truncate(MathD.Abs(val));
        }



        public static decimal Sqrt(decimal val)
        {
            return Convert.ToDecimal(Math.Sqrt(Convert.ToDouble(val)));
        }



        public static decimal Asin(decimal val)
        {
            return Convert.ToDecimal(Math.Asin(Convert.ToDouble(val)));
        }



        public static decimal Acos(decimal val)
        {
            return Convert.ToDecimal(Math.Acos(Convert.ToDouble(val)));
        }



        public static decimal Sin(decimal val)
        {
            return Convert.ToDecimal(Math.Sin(Convert.ToDouble(val)));
        }



        public static decimal Cos(decimal val)
        {
            return Convert.ToDecimal(Math.Cos(Convert.ToDouble(val)));
        }



    }



}
