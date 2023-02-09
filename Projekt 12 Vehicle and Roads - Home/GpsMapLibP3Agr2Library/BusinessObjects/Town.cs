using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace GpsMapLibP3Agr2Library.BusinessObjects
{



    public class Town : Municipality, IComparable<Town>
    {



        // Name of the town.
        public string Name { get; set; }

        // Unique identifier of the town.
        public string Code { get; set; }

        // Location of the town.
        public Gps Gps { get; set; }



        public Town()
        {
        }



        public Town(Municipality municipality) : this(municipality, false)
        {
        }



        public Town(Municipality municipality, bool doInitializeAllProperties)
        {
            this.MunicipalityName = municipality.MunicipalityName;
            this.MunicipalityCode = municipality.MunicipalityCode;

            this.DistrictName = municipality.DistrictName;
            this.DistrictCode = municipality.DistrictCode;

            this.RegionName = municipality.RegionName;
            this.RegionCode = municipality.RegionCode;

            this.ZipCode = municipality.ZipCode;

            this.Latitude = municipality.Latitude;
            this.Longitude = municipality.Longitude;

            this.TotalPopulation = municipality.TotalPopulation;
            this.MalePopulation = municipality.MalePopulation;
            this.FemalePopulation = municipality.FemalePopulation;

            this.AverageAge = municipality.AverageAge;
            this.MaleAverageAge = municipality.MaleAverageAge;
            this.FemaleAverageAge = municipality.FemaleAverageAge;

            // Initialize the properties specific to a town.
            if (doInitializeAllProperties)
            {
                this.Name = this.MunicipalityName;
                this.Code = this.MunicipalityCode;
                this.Gps = new Gps(this.Latitude, this.Longitude);
            }
        }



        public int CompareTo(Town other)
        {
            return this.Code.CompareTo(other.Code);
        }



        public override string ToString()
        {
            return $"{this.Code} {this.Name}";
        }



        public override bool Equals(object? obj)
        {

            Town other = obj as Town;

            if (other == null)
            {
                return false;
            }

            return (this.Code == other.Code);

        }



        public override int GetHashCode()
        {
            return this.Code.GetHashCode();
        }



    }



}
