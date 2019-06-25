using System.Collections.Generic;

namespace corerace.Models
{
    public class Driver
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public IList<Lap> Laps {get;set;}

        public Driver(string id, string name){
            this.Id = int.Parse(id);
            this.Name = name;
        }
    }
}