using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace GpsMapLibP3Agr2Library.BusinessObjects
{



    public class MunicipalityCsu : IComparable<MunicipalityCsu>
    {



        public string DistrictCode { get; set; }
        public string MunicipalityCode { get; set; }
        public string MunicipalityName { get; set; }

        public int TotalPopulation { get; set; }
        public int MalePopulation { get; set; }
        public int FemalePopulation { get; set; }

        public double AverageAge { get; set; }
        public double MaleAverageAge { get; set; }
        public double FemaleAverageAge { get; set; }



        public int CompareTo(MunicipalityCsu other)
        {
            return this.MunicipalityCode.CompareTo(other.MunicipalityCode);

            //if (this.MunicipalityCode < other.MunicipalityCode)
            //{
            //    return -1;
            //}

            //string thisCode = this.MunicipalityCode;
            //string otherCode = other.MunicipalityCode;
            ////int thisLength = this.MunicipalityCode.Length;
            ////int otherLength = other.MunicipalityCode.Length;
            //int thisLength = thisCode.Length;
            //int otherLength = otherCode.Length;
            //int minLength = ((thisLength <= otherLength) ? (thisLength) : (otherLength));
            //for (int i = 0; i < minLength; i++)
            //{
            //    char thisChar = thisCode[i];
            //    char otherChar = otherCode[i];
            //    if (thisChar != otherChar)
            //    {
            //        if (thisChar < otherChar)
            //        {
            //            return -1;
            //        }
            //        else if (thisChar > otherChar)
            //        {
            //            return +1;
            //        }
            //        else
            //        {
            //            throw new Exception("Problems in calculation logic. This can't be.");
            //        }
            //    }
            //}
            //// Either the strings are identical,
            //// or one is longer than the other, but the first minLength characters are also identical.
            //if (thisLength < otherLength)
            //{
            //    return -1;
            //}
            //else if (thisLength > otherLength)
            //{
            //    return +1;
            //}
            //else
            //{
            //    return 0;
            //}
        }



        public override string ToString()
        {
            return $"{this.MunicipalityCode} {this.MunicipalityName}";
        }



        public override bool Equals(object? obj)
        {

            MunicipalityCsu other = obj as MunicipalityCsu;
            
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
