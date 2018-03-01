using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashCode2018.IO
{
    public class Vehichle
    {
        public int x { get; set; }

        public int y { get; set; }

        public int distanceIfBusy { get; set; }

        public bool busy { get; set; }

        public Vehichle()
        {
            x = 0;
            y = 0;
            busy = false;
            history = new List<int>();
        }

        public List<int> history { get; set; }

        public Ride dest { get; set; }
        
    }
}
