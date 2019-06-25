namespace corerace.Models
{
    public class Lap
    {
        
        public string Time { get; set; }
        public string LapTime { get; set; }
        public int LapNumber { get; set; }
        public string AvgSpeed { get; set; }

        public Lap(string time, string lapTime, int lapNumber, string avgSpeed)
        {
            this.Time = time;
            this.LapTime = lapTime;
            this.LapNumber = lapNumber;
            this.AvgSpeed = avgSpeed;
        }
        

    }
}