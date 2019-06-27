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
                IList<Driver> drivers = new List<Driver>();

                if(!string.IsNullOrEmpty(laps)){
                    var lapList = laps.Split("\n");

                    drivers = PopulateDrivers(lapList);

                    foreach(Driver d in drivers){
                        d.SetBestLap();
                        d.SetDriverAvgSpeed();
                        d.SetCompletedLaps();
                        d.SetTotalTime();
                    }

                    drivers = SetScore(drivers);

                }

                PrintScore(drivers);
                
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
            
            try{
                
                foreach(var lap in laps.Skip(1)){
                    string[] lapProps = lap.Split("\t");
                    string[] driverProps = lapProps[1].Split(" – ");              

                    Lap l = new Lap(lapProps[0],lapProps[2], lapProps[3], lapProps[4]);
                    Driver d = new Driver(driverProps[0], driverProps[1]);               
                    if(!drivers.Exists(x => x.Id == int.Parse(driverProps[0]))){
                        d.Laps = new List<Lap>();
                        d.Laps.Add(l);
                        drivers.Add(d);
                    }else{
                        Driver existingDriver = drivers.First(x => x.Id == int.Parse(driverProps[0]));
                        existingDriver.Laps.Add(l);
                    }

                }

                return drivers;

            }catch (Exception e){
                Console.WriteLine("Problem to get drivers properties");
                Console.WriteLine(e.Message);

                return drivers;
            }

        }

        static IList<Driver> SetScore(IList<Driver> drivers){
            return drivers.OrderBy(x => x.TotalTime).ToList();
        }

        static void PrintScore(IList<Driver> drivers){
            Console.WriteLine("**** SCORE ****");
            Console.WriteLine("[Posição Chegada/Código Piloto/Nome Piloto/Qtde Voltas Completadas/Tempo Total de Prova]");

            foreach(Driver d in drivers){
                Console.Write(drivers.IndexOf(d)+1);
                Console.Write(" - ");
                Console.Write(d.Id);
                Console.Write(" - ");
                Console.Write(d.Name);
                Console.Write(" - ");
                Console.Write(d.CompletedLaps);
                Console.Write(" - ");
                Console.Write(d.TotalTime);

                Console.Write(" (Melhor volta: ");
                Console.Write(d.BestLap.LapTime);
                Console.Write("; ");

                Console.Write("Velocidade Média: ");
                Console.Write(d.DriverAvgSpeed);
                Console.Write(")");

                Console.Write("\n");
            }
            


        }

    }
}
