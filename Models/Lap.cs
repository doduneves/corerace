using System;

namespace corerace.Models
{
    public class Lap
    {        
        public TimeSpan Time { get; set; }
        public int LapNumber { get; set; }
        public TimeSpan LapTime { get; set; }
        public decimal AvgSpeed { get; set; }

        public Lap(){
            this.Time = new TimeSpan();
            this.LapNumber = 0;
            this.LapTime = new TimeSpan();
            this.AvgSpeed = 0;
        }
        public Lap(string time, string lapNumber, string lapTime, string avgSpeed)
        {
            this.Time = TimeSpan.Parse(time);
            this.LapNumber = int.Parse(lapNumber);
            this.LapTime = TimeSpan.Parse("0:"+lapTime);
            this.AvgSpeed = decimal.Parse(avgSpeed);
        }
        

    }
}