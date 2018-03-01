using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HashCode2018.IO;

namespace IO
{


    class Program
    {
        static string filename = "input.in";
        static int R, C, F, N, B, T;

        static List<Ride> rides = new List<Ride>();

        static List<Vehichle> vehicles;

        static void Main(string[] args)
        {
            ReadIn(filename);

            vehicles = new List<Vehichle>();

            for (int i = 0; i < F; i++)
            {
                vehicles.Add(new Vehichle());
            }

            //vehicles.ForEach(x => Console.WriteLine(x));

            List<Pair> pairs;
            for (int t = 0; t < T; t++)
            {
                //ami ride-ban van, út teljesíthető, autó ne legyen párosítva
                foreach (var vehicle in vehicles)
                {
                    pairs = new List<Pair>();
                    foreach (var ride in rides)
                    {
                        int travelDistance = Math.Abs(ride.a - vehicle.x) + Math.Abs(ride.b - vehicle.y);
                        bool isPairable = !vehicle.busy && ride.f - travelDistance - ride.GetDistance() - t >= 0;
                        if (isPairable)
                        {
                            Pair p = new Pair(ride, vehicle);
                            pairs.Add(p);
                            p.Update(t);
                        }
                    }
                    pairs.Sort((pair1, pair2) => pair2.heuristic.CompareTo(pair1.heuristic));
                    if (pairs.Count > 0)
                    {
                        Pair best = pairs[0];

                        //step
                        if (best.vehichle.x > best.ride.a) best.vehichle.x--;
                        else if (best.vehichle.x == best.ride.a)
                        {
                            if (best.vehichle.y > best.ride.b) best.vehichle.y--;
                            else if (best.vehichle.y == best.ride.b)
                            {
                                //itt majd kivesszük
                                best.vehichle.busy = true;
                                best.vehichle.dest = best.ride;
                                best.vehichle.distanceIfBusy = best.vehichle.dest.GetDistance();
                                rides.Remove(best.ride);
                            }
                            else
                            {
                                best.vehichle.y++;
                            }
                        }
                        else
                        {
                            best.vehichle.x++;
                        }
                    }
                    Console.WriteLine(t);
                }

                foreach (var vehicle in vehicles)
                {

                    if (vehicle.busy)
                    {
                        vehicle.distanceIfBusy--;
                        if (vehicle.distanceIfBusy == 0)
                        {
                            //TODO
                            vehicle.busy = false;
                            vehicle.x = vehicle.dest.x;
                            vehicle.y = vehicle.dest.y;
                            vehicle.history.Add(vehicle.dest.ID);
                            vehicle.dest = null;
                        }
                    }
                }
            }
            StreamWriter sw = new StreamWriter("output.out");
            foreach (var vehicle in vehicles)
            {
                Console.Write(vehicle.history.Count +" ");
                sw.Write(vehicle.history.Count + " ");

                for (int i = 0; i < vehicle.history.Count; i++)
                {
                    if (i == vehicle.history.Count - 1)
                    {
                        Console.Write(vehicle.history[i]);
                        sw.Write(vehicle.history[i]);

                    }
                    else
                    {
                        Console.Write(vehicle.history[i] + " ");
                        sw.Write(vehicle.history[i] + " ");

                    }
                }
                Console.WriteLine();
            }
            

            Console.ReadKey();
        }

        private static void ReadIn(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);

            //Kezdeti változó beolvasása
            string[] firstLine = lines[0].Split();
            R = int.Parse(firstLine[0]);
            C = int.Parse(firstLine[1]);
            F = int.Parse(firstLine[2]);
            N = int.Parse(firstLine[3]);
            B = int.Parse(firstLine[4]);
            T = int.Parse(firstLine[5]);



            int lineCounter = 1;

            for (int i = 0; i < N; i++)
            {
                string[] line = lines[lineCounter++].Split();
                rides.Add(new Ride()
                {
                    ID=i,
                    a = int.Parse(line[0]),
                    b = int.Parse(line[1]),
                    x = int.Parse(line[2]),
                    y = int.Parse(line[3]),
                    s = int.Parse(line[4]),
                    f = int.Parse(line[5]),
                    bonus = B
                });
            }

            //Teszt
            //rides.ForEach(x => Console.WriteLine(x));


        }
    }
}
