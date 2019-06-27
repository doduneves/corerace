using System;
using System.Collections.Generic;

namespace corerace.Models
{
    public class Driver
    {
        #region atributes
        public int Id {get;set;}
        public string Name {get;set;}
        public IList<Lap> Laps {get;set;}
        public Lap BestLap {get; private set;}
        public decimal DriverAvgSpeed { get; private set; }
        public int CompletedLaps { get; private set; }
        public TimeSpan TotalTime { get; set; }


        #endregion

        #region construct
        public Driver(string id, string name){
            this.Id = int.Parse(id);
            this.Name = name;
        }
        #endregion

        #region methods
        public void SetBestLap(){
            TimeSpan bestLapTime = new TimeSpan();
            Lap bestLap = new Lap();

            foreach(var lap in Laps){
                if(bestLapTime.Minutes.Equals(0)){
                    bestLap = lap;
                }else if(lap.LapTime.CompareTo(bestLapTime) < 0){
                    bestLap = lap;
                }
                bestLapTime = bestLap.LapTime;
            }

            BestLap = bestLap;
        }
        
        public void SetDriverAvgSpeed(){
            decimal avgSpeedSum = 0;

            foreach(var lap in Laps){
                avgSpeedSum += lap.AvgSpeed;                
            }

            DriverAvgSpeed = (avgSpeedSum / Laps.Count);
        }

        public void SetCompletedLaps(){
            CompletedLaps = Laps.Count;
        }

        public void SetTotalTime(){
            TimeSpan totalTime = new TimeSpan();

            foreach(var lap in Laps){
                totalTime = totalTime.Add(lap.LapTime);    
            }

            TotalTime = totalTime;
        }
        
        #endregion

    }
}