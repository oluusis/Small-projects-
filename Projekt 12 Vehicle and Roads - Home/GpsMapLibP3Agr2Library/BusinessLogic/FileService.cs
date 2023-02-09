using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

using GpsMapLibP3Agr2Library.BusinessObjects;



namespace GpsMapLibP3Agr2Library.BusinessLogic
{



    public class FileService
    {



        private IFormatProvider formatProvider = null;



        public FileService()
        {
            //this.formatProvider = new CultureInfo("en-US");
            this.formatProvider = CultureInfo.InvariantCulture;
        }





        public void SaveRoads(List<Road> roads, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                // File structure line.
                writer.WriteLine("Type,RoadNo,LocationACode,LocationBCode,MinVelocity,MaxVelocity");

                foreach (Road road in roads)
                {
                    // Data line.
                    string line = ToString(road);
                    writer.WriteLine(line);
                }
            }
        }



        private string ToString(Road road)
        {
            string line = string.Format(
                this.formatProvider,
                "{0},{1},{2},{3},{4:0.0000000},{5:0.0000000}",
                road.GetType().Name,
                road.RoadNo,
                road.LocationA.Code,
                road.LocationB.Code,
                road.MinVelocity,
                road.MaxVelocity
                );
            return line;
        }





        public List<Road> LoadRoads(string fileName, List<Town> towns)
        {
            List<Road> roads = new List<Road>();

            using (StreamReader reader = new StreamReader(fileName))
            {

                // Skip 1st line.
                // Type,RoadNo,LocationACode,LocationBCode,MinVelocity,MaxVelocity
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    Road road = ToRoad(line, towns);

                    roads.Add(road);
                }
            }

            return roads;
        }



        private Road ToRoad(string line, List<Town> towns)
        {
            Road road = null;
            Road roadRaw = new Road();

            // Type,RoadNo,LocationACode,LocationBCode,MinVelocity,MaxVelocity
            string[] values = line.Split(',');

            roadRaw.RoadNo = values[1];

            roadRaw.LocationA = TownCodeToTown(values[2], towns);
            roadRaw.LocationB = TownCodeToTown(values[3], towns);

            roadRaw.MinVelocity = Convert.ToDecimal(values[4], this.formatProvider);
            roadRaw.MaxVelocity = Convert.ToDecimal(values[5], this.formatProvider);


            switch (values[0])
            {
                case "ARoad":
                    road = new ARoad(roadRaw);
                    break;

                case "Highway":
                    road = new Highway(roadRaw);
                    break;

                case "CRoad":
                    road = new CRoad(roadRaw);
                    break;

                default:
                    throw new NotSupportedException($"This road type is not supported here: {values[0]}");
            }

            return road;
        }



        private Town TownCodeToTown(string townCode, List<Town> towns)
        {
            foreach (Town town in towns)
            {
                if (town.Code == townCode)
                {
                    return town;
                }
            }
            //return null;
            throw new Exception($"Town not found: {townCode}");
        }





        public List<Town> LoadTownsAndCities(string fileName)
        {
            List<Town> towns = new List<Town>();

            using (StreamReader reader = new StreamReader(fileName))
            {

                // Skip 1st line.
                // IsCity,Name,Code,MunicipalityName,MunicipalityCode,DistrictName,DistrictCode,RegionName,RegionCode,ZipCode,Latitude,Longitude,TotalPopulation,MalePopulation,FemalePopulation,AverageAge,MaleAverageAge,FemaleAverageAge
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    Town town = ToTownOrCity(line);

                    towns.Add(town);
                }
            }

            return towns;
        }



        private Town ToTownOrCity(string line)
        {
            //Town town = new Town();
            Town town;

            // IsCity,Name,Code,MunicipalityName,MunicipalityCode,DistrictName,DistrictCode,RegionName,RegionCode,ZipCode,Latitude,Longitude,TotalPopulation,MalePopulation,FemalePopulation,AverageAge,MaleAverageAge,FemaleAverageAge
            string[] values = line.Split(',');

            bool isCity = Convert.ToBoolean(values[0]);
            if (isCity)
            {
                town = new City();
            }
            else
            {
                town = new Town();
            }

            town.Name = values[1];
            town.Code = values[2];

            town.MunicipalityName = values[3];
            town.MunicipalityCode = values[4];

            town.DistrictName = values[5];
            town.DistrictCode = values[6];

            town.RegionName = values[7];
            town.RegionCode = values[8];

            town.ZipCode = values[9];

            town.Latitude = Convert.ToDecimal(values[10], this.formatProvider);
            town.Longitude = Convert.ToDecimal(values[11], this.formatProvider);

            town.TotalPopulation = Convert.ToInt32(values[12]);
            town.MalePopulation = Convert.ToInt32(values[13]);
            town.FemalePopulation = Convert.ToInt32(values[14]);

            town.AverageAge = Convert.ToDouble(values[15], this.formatProvider);
            town.MaleAverageAge = Convert.ToDouble(values[16], this.formatProvider);
            town.FemaleAverageAge = Convert.ToDouble(values[17], this.formatProvider);

            // Populate the Gps field as well.
            town.Gps = new Gps(town.Latitude, town.Longitude);

            return town;
        }





        public void SaveTownsAndCities(List<Town> townsAndCities, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                // File structure line.
                writer.WriteLine("IsCity,Name,Code,MunicipalityName,MunicipalityCode,DistrictName,DistrictCode,RegionName,RegionCode,ZipCode,Latitude,Longitude,TotalPopulation,MalePopulation,FemalePopulation,AverageAge,MaleAverageAge,FemaleAverageAge");

                foreach (Town town in townsAndCities)
                {
                    // Data line.
                    string line = TownOrCityToString(town);
                    writer.WriteLine(line);
                }
            }
        }



        private string TownOrCityToString(Town town)
        {
            string line = string.Format(
                this.formatProvider,
                "{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10:0.0000000},{11:0.0000000},{12},{13},{14},{15:0.0},{16:0.0},{17:0.0}",
                (town is City),
                town.Name, town.Code,
                town.MunicipalityName, town.MunicipalityCode,
                town.DistrictName, town.DistrictCode,
                town.RegionName, town.RegionCode,
                town.ZipCode,
                town.Latitude, town.Longitude,
                town.TotalPopulation, town.MalePopulation, town.FemalePopulation,
                town.AverageAge, town.MaleAverageAge, town.FemaleAverageAge
                );
            return line;
        }





        public List<Town> LoadTowns(string fileName)
        {
            List<Town> towns = new List<Town>();

            using (StreamReader reader = new StreamReader(fileName))
            {

                // Skip 1st line.
                // Name,Code,MunicipalityName,MunicipalityCode,DistrictName,DistrictCode,RegionName,RegionCode,ZipCode,Latitude,Longitude,TotalPopulation,MalePopulation,FemalePopulation,AverageAge,MaleAverageAge,FemaleAverageAge
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    Town town = ToTown(line);

                    towns.Add(town);
                }
            }

            return towns;
        }



        private Town ToTown(string line)
        {
            Town town = new Town();

            // Name,Code,MunicipalityName,MunicipalityCode,DistrictName,DistrictCode,RegionName,RegionCode,ZipCode,Latitude,Longitude,TotalPopulation,MalePopulation,FemalePopulation,AverageAge,MaleAverageAge,FemaleAverageAge
            string[] values = line.Split(',');

            town.Name = values[0];
            town.Code = values[1];

            town.MunicipalityName = values[2];
            town.MunicipalityCode = values[3];

            town.DistrictName = values[4];
            town.DistrictCode = values[5];

            town.RegionName = values[6];
            town.RegionCode = values[7];

            town.ZipCode = values[8];

            town.Latitude = Convert.ToDecimal(values[9], this.formatProvider);
            town.Longitude = Convert.ToDecimal(values[10], this.formatProvider);

            town.TotalPopulation = Convert.ToInt32(values[11]);
            town.MalePopulation = Convert.ToInt32(values[12]);
            town.FemalePopulation = Convert.ToInt32(values[13]);

            town.AverageAge = Convert.ToDouble(values[14], this.formatProvider);
            town.MaleAverageAge = Convert.ToDouble(values[15], this.formatProvider);
            town.FemaleAverageAge = Convert.ToDouble(values[16], this.formatProvider);

            // Populate the Gps field as well.
            town.Gps = new Gps(town.Latitude, town.Longitude);

            return town;
        }





        public void SaveTowns(List<Town> towns, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                // File structure line.
                writer.WriteLine("Name,Code,MunicipalityName,MunicipalityCode,DistrictName,DistrictCode,RegionName,RegionCode,ZipCode,Latitude,Longitude,TotalPopulation,MalePopulation,FemalePopulation,AverageAge,MaleAverageAge,FemaleAverageAge");

                foreach (Town town in towns)
                {
                    // Data line.
                    string line = ToString(town);
                    writer.WriteLine(line);
                }
            }
        }



        private string ToString(Town town)
        {
            string line = string.Format(
                this.formatProvider,
                "{0},{1},{2},{3},{4},{5},{6},{7},{8},{9:0.0000000},{10:0.0000000},{11},{12},{13},{14:0.0},{15:0.0},{16:0.0}",
                town.Name, town.Code,
                town.MunicipalityName, town.MunicipalityCode,
                town.DistrictName, town.DistrictCode,
                town.RegionName, town.RegionCode,
                town.ZipCode,
                town.Latitude, town.Longitude,
                town.TotalPopulation, town.MalePopulation, town.FemalePopulation,
                town.AverageAge, town.MaleAverageAge, town.FemaleAverageAge
                );
            return line;
        }





        public List<Municipality> LoadMunicipalityData(string fileName)
        {
            List<Municipality> municipalities = new List<Municipality>();

            using (StreamReader reader = new StreamReader(fileName))
            {

                // Skip 1st line.
                // MunicipalityName,MunicipalityCode,DistrictName,DistrictCode,RegionName,RegionCode,ZipCode,Latitude,Longitude,TotalPopulation,MalePopulation,FemalePopulation,AverageAge,MaleAverageAge,FemaleAverageAge
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    Municipality municipality = ToMunicipality(line);

                    municipalities.Add(municipality);
                }
            }

            return municipalities;
        }



        private Municipality ToMunicipality(string line)
        {
            Municipality municipality = new Municipality();

            // MunicipalityName,MunicipalityCode,DistrictName,DistrictCode,RegionName,RegionCode,ZipCode,Latitude,Longitude,TotalPopulation,MalePopulation,FemalePopulation,AverageAge,MaleAverageAge,FemaleAverageAge
            string[] values = line.Split(',');

            municipality.MunicipalityName = values[0];
            municipality.MunicipalityCode = values[1];

            municipality.DistrictName = values[2];
            municipality.DistrictCode = values[3];

            municipality.RegionName = values[4];
            municipality.RegionCode = values[5];

            municipality.ZipCode = values[6];

            municipality.Latitude = Convert.ToDecimal(values[7], this.formatProvider);
            municipality.Longitude = Convert.ToDecimal(values[8], this.formatProvider);

            municipality.TotalPopulation = Convert.ToInt32(values[9]);
            municipality.MalePopulation = Convert.ToInt32(values[10]);
            municipality.FemalePopulation = Convert.ToInt32(values[11]);

            municipality.AverageAge = Convert.ToDouble(values[12], this.formatProvider);
            municipality.MaleAverageAge = Convert.ToDouble(values[13], this.formatProvider);
            municipality.FemaleAverageAge = Convert.ToDouble(values[14], this.formatProvider);

            return municipality;
        }





        public void SaveMunicipalityData(List<Municipality> municipalities, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                // File structure line.
                writer.WriteLine("MunicipalityName,MunicipalityCode,DistrictName,DistrictCode,RegionName,RegionCode,ZipCode,Latitude,Longitude,TotalPopulation,MalePopulation,FemalePopulation,AverageAge,MaleAverageAge,FemaleAverageAge");

                foreach (Municipality municipality in municipalities)
                {
                    // Data line.
                    string line = ToString(municipality);
                    writer.WriteLine(line);
                }
            }
        }



        private string ToString(Municipality municipality)
        {
            string line = string.Format(
                this.formatProvider,
                //"{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15}",
                //"{0},{1},{2},{3},{4},{5},{6},{7:0.0000000},{8:0.0000000},{9},{10},{11},{12},{13},{14},{15}",
                "{0},{1},{2},{3},{4},{5},{6},{7:0.0000000},{8:0.0000000},{9},{10},{11},{12:0.0},{13:0.0},{14:0.0}",
                municipality.MunicipalityName, municipality.MunicipalityCode,
                municipality.DistrictName, municipality.DistrictCode,
                municipality.RegionName, municipality.RegionCode,
                municipality.ZipCode,
                municipality.Latitude, municipality.Longitude,
                municipality.TotalPopulation, municipality.MalePopulation, municipality.FemalePopulation,
                municipality.AverageAge, municipality.MaleAverageAge, municipality.FemaleAverageAge
                );
            return line;
        }





        public List<MunicipalityCsu> LoadPopulation(string fileName)
        {
            List<MunicipalityCsu> municipalities = new List<MunicipalityCsu>();

            using (StreamReader reader = new StreamReader(fileName))
            {

                // Skip 1st line.
                // DistrictCode,MunicipalityCode,MunicipalityName,TotalPopulation,MalePopulation,FemalePopulation,AverageAge,MaleAverageAge,FemaleAverageAge
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    MunicipalityCsu municipalityCsu = ToMunicipalityCsu(line);

                    municipalities.Add(municipalityCsu);
                }
            }

            return municipalities;
        }



        private MunicipalityCsu ToMunicipalityCsu(string line)
        {
            MunicipalityCsu municipalityCsu = new MunicipalityCsu();

            // DistrictCode,MunicipalityCode,MunicipalityName,TotalPopulation,MalePopulation,FemalePopulation,AverageAge,MaleAverageAge,FemaleAverageAge
            string[] values = line.Split(',');

            municipalityCsu.DistrictCode = values[0];
            municipalityCsu.MunicipalityCode = values[1];
            municipalityCsu.MunicipalityName = values[2];

            municipalityCsu.TotalPopulation = Convert.ToInt32(values[3]);
            municipalityCsu.MalePopulation = Convert.ToInt32(values[4]);
            municipalityCsu.FemalePopulation = Convert.ToInt32(values[5]);

            //municipalityCsu.AverageAge = Convert.ToDouble(values[6]);
            //municipalityCsu.MaleAverageAge = Convert.ToDouble(values[7]);
            //municipalityCsu.FemaleAverageAge = Convert.ToDouble(values[8]);
            municipalityCsu.AverageAge = Convert.ToDouble(values[6], this.formatProvider);
            municipalityCsu.MaleAverageAge = Convert.ToDouble(values[7], this.formatProvider);
            municipalityCsu.FemaleAverageAge = Convert.ToDouble(values[8], this.formatProvider);

            return municipalityCsu;
        }





        public List<MunicipalityGitHub> LoadGpsCoords(string fileName)
        {
            List<MunicipalityGitHub> municipalities = new List<MunicipalityGitHub>();

            using (StreamReader reader = new StreamReader(fileName))
            {

                // Skip 1st line.
                // Obec,Kód obce,Okres,Kód okresu,Kraj,Kód kraje,PSČ,Latitude,Longitude
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    MunicipalityGitHub municipalityGitHub = ToMunicipalityGitHub(line);

                    municipalities.Add(municipalityGitHub);
                }
            }

            return municipalities;
        }



        private MunicipalityGitHub ToMunicipalityGitHub(string line)
        {
            MunicipalityGitHub municipalityGitHub = new MunicipalityGitHub();

            // Obec,Kód obce,Okres,Kód okresu,Kraj,Kód kraje,PSČ,Latitude,Longitude
            string[] values = line.Split(',');

            municipalityGitHub.MunicipalityName = values[0];
            municipalityGitHub.MunicipalityCode = values[1];

            municipalityGitHub.DistrictName = values[2];
            municipalityGitHub.DistrictCode = values[3];

            municipalityGitHub.RegionName = values[4];
            municipalityGitHub.RegionCode = values[5];

            municipalityGitHub.ZipCode = values[6];

            //municipalityGitHub.Latitude = Convert.ToDecimal(values[7]);
            //municipalityGitHub.Longitude = Convert.ToDecimal(values[8]);
            municipalityGitHub.Latitude = Convert.ToDecimal(values[7], this.formatProvider);
            municipalityGitHub.Longitude = Convert.ToDecimal(values[8], this.formatProvider);

            return municipalityGitHub;
        }



    }



}
