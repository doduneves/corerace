namespace corerace.Models
{
    public class Lap
    {
        
        public string Time { get; set; }
        public int LapNumber { get; set; }
        public string LapTime { get; set; }
        public string AvgSpeed { get; set; }

        public Lap(string time, string lapNumber, string lapTime, string avgSpeed)
        {
            this.Time = time;
            this.LapNumber = int.Parse(lapNumber);
            this.LapTime = lapTime;
            this.AvgSpeed = avgSpeed;
        }
        

    }
}