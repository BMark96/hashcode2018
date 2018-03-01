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

        static void Main(string[] args)
        {
            ReadIn(filename);

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

            List<Ride> rides = new List<Ride>();

            int lineCounter = 1;

            for (int i = 0; i < N; i++)
            {
                string[] line = lines[lineCounter++].Split();
                rides.Add(new Ride()
                {
                    a = int.Parse(line[0]),
                    b = int.Parse(line[1]),
                    x = int.Parse(line[2]),
                    y = int.Parse(line[3]),
                    s = int.Parse(line[4]),
                    f = int.Parse(line[5])
                });
            }

            //Teszt
            rides.ForEach(x => Console.WriteLine(x));

            Console.ReadKey();

        }
    }
}
