using System.Linq;
using System;
using System.IO;
using System.Collections.Generic;


using corerace.Models;

namespace corerace
{
    class Program
    {
        const string filename = "race.txt";

        static void Main(string[] args)
        {
            try
            {
                string laps = ReadFile(filename);

                if(!string.IsNullOrEmpty(laps)){
                    var lapList = laps.Split("\n");

                    IList<Driver> drivers = PopulateDrivers(lapList);


                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static string ReadFile(string file)
        {
            try
            {
                string line = string.Empty;

                using (StreamReader sr = new StreamReader(file))
                {               
                    line = sr.ReadToEnd();
                }
                return line;
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return "";
            }
        }
        
        static IList<Driver> PopulateDrivers(string[] laps){
            List<Driver> drivers = new List<Driver>();
            
            foreach(var lap in laps.Skip(1)){
                string[] lapProps = lap.Split("\t");
                string[] driverProps = lapProps[1].Split(" – ");              

                Driver d = new Driver(driverProps[0], driverProps[1]);               
                if(!drivers.Exists(x => x.Id == int.Parse(driverProps[0]))){
                    drivers.Add(d);
                }

            }

            return drivers;
        }

    }
}
