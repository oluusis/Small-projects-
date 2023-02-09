using System;
using System.Collections.Generic;
using System.Text;

using GpsMapLibP3Agr2Library.Helper;



namespace GpsMapLibP3Agr2Library.BusinessObjects
{



    // Coordinates of a point in the "polar coordinate system":
    // Radius r = distance from a reference point.
    // Angle fi = angle from X axis.
    public struct Polar
    {



        // R (radius). In km.
        private decimal radius;

        // Fi (angle). In radians.
        private decimal angle;



        public Polar(decimal radius, decimal angle)
        {
            this.radius = radius;
            this.angle = angle;
        }



        public Polar(Lps lps)
        {
            //this.radius = Convert.ToDecimal(Math.Sqrt(Convert.ToDouble(lps.X * lps.X + lps.Y * lps.Y)));
            this.radius = MathD.Sqrt(lps.X * lps.X + lps.Y * lps.Y);
            // Handle the "singularity" case (the coords are [0, 0]).
            if ((lps.X == 0) && (lps.Y == 0))
            {
                this.angle = 0;
                return;
            }
            // Now, it depends in which quadrant the given point is situated.
            if ((lps.X >= 0) && (lps.Y >= 0))
            {
                // Right, Top.
                // Use sine (directly) with +Y.
                decimal sine = lps.Y / this.radius;
                //this.angle = Convert.ToDecimal(Math.Asin(Convert.ToDouble(sine)));
                this.angle = MathD.Asin(sine);
            }
            else if ((lps.X < 0) && (lps.Y >= 0))
            {
                // Left, Top.
                // Use sine (indirectly) with +Y.
                // Indirectly means: Get the angle Fi' and subtract it from PI.
                decimal sine = lps.Y / this.radius;
                //this.angle = Convert.ToDecimal(Math.PI - Math.Asin(Convert.ToDouble(sine)));
                this.angle = MathD.PI - MathD.Asin(sine);
            }
            else if ((lps.X < 0) && (lps.Y < 0))
            {
                // Left, Bottom.
                // Use sine (directly) with -Y.
                // Add PI because Y is negative.
                decimal sine = (-lps.Y) / this.radius;
                //this.angle = Convert.ToDecimal(Math.PI + Math.Asin(Convert.ToDouble(sine)));
                this.angle = MathD.PI + MathD.Asin(sine);
            }
            else if ((lps.X >= 0) && (lps.Y < 0))
            {
                // Right, Bottom.
                // Use sine (indirectly) with -Y.
                // Indirectly means: Get the angle Fi' and subtract it from 2*PI because Y is negative.
                decimal sine = (-lps.Y) / this.radius;
                //this.angle = Convert.ToDecimal(Math.PI * 2 - Math.Asin(Convert.ToDouble(sine)));
                this.angle = MathD.PI * 2 - MathD.Asin(sine);
            }
            else
            {
                // This can't be.
                throw new Exception("A point must be either in the right-top quandrant, or in the left-top one, or in the left-bottom one, or in the right-bottom quadrant. The point [0, 0] is supposed to be located in right-top.");
            }
        }



        public decimal Radius
        {
            get { return this.radius; }
            set { this.radius = value; }
        }
        public decimal Angle
        {
            get { return this.angle; }
            set { this.angle = value; }
        }



        // To simplify math formulas
        public decimal R
        {
            get { return this.radius; }
        }
        public decimal Fi
        {
            get { return this.angle; }
        }



        public Lps ToLps()
        {
            //Lps cartesian = new Lps(this.radius * Convert.ToDecimal(Math.Cos(Convert.ToDouble(this.angle))), this.radius * Convert.ToDecimal(Math.Sin(Convert.ToDouble(this.angle))));
            Lps cartesian = new Lps(this.radius * MathD.Cos(this.angle), this.radius * MathD.Sin(this.angle));
            return cartesian;
        }



        public override string ToString()
        {
            return $"r: {this.radius:0.0000000} km, fi: {this.angle:0.0000000} rad";
        }



        public override int GetHashCode()
        {
            return this.radius.GetHashCode() ^ this.angle.GetHashCode();
        }



        public bool Equals(Polar other)
        {
            if ((this.radius == other.radius) && (this.angle == other.angle))
            {
                return true;
            }

            return false;
        }



        public override bool Equals(object obj)
        {
            if (!(obj is Polar))
            {
                return false;
            }

            Polar other = (Polar) obj;

            return Equals(other);
        }



        public static bool operator ==(Polar pol1, Polar pol2)
        {
            // With a "struct" we needn't handle the "null" cases.
            return pol1.Equals(pol2);
        }



        public static bool operator !=(Polar pol1, Polar pol2)
        {
            // With a "struct" we needn't handle the "null" cases.
            return !(pol1.Equals(pol2));
        }



    }



}
