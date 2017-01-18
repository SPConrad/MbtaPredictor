using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MbtaPredictor.Entities
{
    
    public class Vehicle
    {
        public string id { get; set; }

        public List<String> lat { get; set; }

        public List<String> lon { get; set; }

        public List<int> bearing { get; set; }

        public List<string> timestamp { get; set; }

        public int label { get; set; }
    }
}
