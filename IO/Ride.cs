﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashCode2018.IO
{
    public class Ride:ICloneable
    {
        public int a { get; set; }
        public int b { get; set; }

        public int x { get; set; }
        public int y { get; set; }

        public int s { get; set; }
        public int f { get; set; }

        public int ID { get; set; }

        public int bonus { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public int GetDistance()
        {
            return Math.Abs(x - a) + Math.Abs(y - b);
        }


        public override string ToString()
        {
            return $"ride from [{a}, {b}] to [{x}, {y}], earliest start {s}, latest finish {f}";
        }
    }
}
