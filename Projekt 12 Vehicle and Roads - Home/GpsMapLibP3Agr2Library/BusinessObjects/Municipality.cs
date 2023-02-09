using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace GpsMapLibP3Agr2Library.BusinessObjects
{



    public class Municipality : IComparable<Municipality>
    {



        public string MunicipalityName { get; set; }
        public string MunicipalityCode { get; set; }

        public string DistrictName { get; set; }
        public string DistrictCode { get; set; }

        public string RegionName { get; set; }
        public string RegionCode { get; set; }

        public string ZipCode { get; set; }

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public int TotalPopulation { get; set; }
        public int MalePopulation { get; set; }
        public int FemalePopulation { get; set; }

        public double AverageAge { get; set; }
        public double MaleAverageAge { get; set; }
        public double FemaleAverageAge { get; set; }



        public int CompareTo(Municipality other)
        {
            return this.MunicipalityCode.CompareTo(other.MunicipalityCode);
        }



        public override string ToString()
        {
            return $"{this.MunicipalityCode} {this.MunicipalityName}";
        }



        public override bool Equals(object? obj)
        {

            Municipality other = obj as Municipality;

            if (other == null)
            {
                return false;
            }

            return (this.MunicipalityCode == other.MunicipalityCode);

        }



        public override int GetHashCode()
        {
            return this.MunicipalityCode.GetHashCode();
        }



    }



}
