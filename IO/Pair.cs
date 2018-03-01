using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashCode2018.IO
{
    public class Pair
    {
        public Vehichle vehichle { get; set; }

        public Ride ride { get; set; }

        public int travelDistance { get; set; }

        public int Bonus { get; set; }

        public int weight { get; set; }

        public double heuristic { get; set; }

        public double WorkRate { get; set; }

        public Pair(Ride r, Vehichle v)
        {
            weight = 5;
            ride = r;
            vehichle = v;
        }

        private void UpdateTravelDistance()
        {
            travelDistance= Math.Abs(ride.a - vehichle.x) + Math.Abs(ride.b - vehichle.y);
        }

        public void Update(int t)
        {
            UpdateTravelDistance();
            int shouldGoForBonus = ride.s - travelDistance - t;
            Bonus = shouldGoForBonus < 0 ? 0 : ride.bonus;

            int wait = ride.s - t - travelDistance;


            //0-val osztás lehet
            if(wait>0)
                WorkRate = (ride.GetDistance()+Bonus)/(ride.GetDistance()+travelDistance+wait);
            else
                WorkRate = (ride.GetDistance() + Bonus) / (ride.GetDistance() + travelDistance);

            //Lehet, hogy 0 lesz (waitFor++???)
            int waitFor = shouldGoForBonus < 0 ? 
                ride.f - travelDistance - ride.GetDistance() - t : 
                ride.s - travelDistance - t;
            waitFor++;
            heuristic = weight / waitFor + WorkRate;

        }

    }
}
