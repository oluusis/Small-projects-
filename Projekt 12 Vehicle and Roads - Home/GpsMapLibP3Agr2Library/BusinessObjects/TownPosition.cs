using System;
using System.Collections.Generic;
using System.Text;



namespace GpsMapLibP3Agr2Library.BusinessObjects
{



    public class TownPosition
    {



        // The town associated with this instance.
        private Town town;

        // The town's GPS coords.
        private Gps gps;

        // The town's LPS (cartesian) coords (absolute).
        private Lps lps;

        // The town's Polar coords (absolute).
        private Polar polar;



        // Reference point for the relative coords (both cartesian and polar).
        // Reference point is considered to have relative coords of [0, 0].
        private Lps referencePoint;

        // The town's cartesian coords (relative to the reference point).
        private Lps lpsRelative;

        // The town's polar coords (relative to the reference point).
        private Polar polarRelative;



        public TownPosition(Town town) : this(town, new Lps(0, 0))
        {
        }



        public TownPosition(Town town, Lps referencePoint)
        {
            this.town = town;
            this.gps = this.town.Gps;
            this.lps = new Lps(this.gps);
            this.polar = new Polar(this.lps);

            this.referencePoint = referencePoint;
            this.lpsRelative = new Lps(this.lps.X - this.referencePoint.X, this.lps.Y - this.referencePoint.Y);
            this.polarRelative = new Polar(this.lpsRelative);
        }



        public Town Town
        {
            get { return this.town; }
        }

        public Gps Gps
        {
            get { return this.gps; }
        }

        public Lps Lps
        {
            get { return this.lps; }
        }

        public Polar Polar
        {
            get { return this.polar; }
        }



        public Lps ReferencePoint
        {
            get
            {
                return this.referencePoint;
            }
            //set
            //{
            //    this.referencePoint = value;
            //    this.lpsRelative = new Lps(this.lps.X - this.referencePoint.X, this.lps.Y - this.referencePoint.Y);
            //    this.polarRelative = new Polar(this.lpsRelative);
            //}
        }

        public Lps LpsRelative
        {
            get { return this.lpsRelative; }
        }

        public Polar PolarRelative
        {
            get { return this.polarRelative; }
        }



        public void ChangeReferencePoint(Lps newReferencePoint)
        {
            this.referencePoint = newReferencePoint;
            this.lpsRelative = new Lps(this.lps.X - this.referencePoint.X, this.lps.Y - this.referencePoint.Y);
            this.polarRelative = new Polar(this.lpsRelative);
        }



    }



}
