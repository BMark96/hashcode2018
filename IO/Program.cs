using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IO
{


    class Program
    {
        static string filename = "input.txt";
        static int V, E, R, C, X;
        static string[] videos;

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
            V = int.Parse(firstLine[0]);
            E = int.Parse(firstLine[1]);
            R = int.Parse(firstLine[2]);
            C = int.Parse(firstLine[3]);
            X = int.Parse(firstLine[4]);

            #region ReadInTest
            Console.WriteLine($"{V} videos, {E} endpoints, {R} request descriptions, {C} caches {X}MB each.");

            #endregion
            videos = lines[1].Split();
            int currentLine = 2;
            #region ReadInTest
            Console.WriteLine("A videókhoz már nincs kedvem kiírni");
            #endregion

            //Végpontokon iterálás
            for (int i = 0; i < E; i++)
            {
                //Egy végpont adatai, nyilván kellene hozzá osztály
                string[] EndPointDatas = lines[currentLine++].Split();
                #region ReadInTest
                Console.WriteLine($"Endpoint {i} has {EndPointDatas[0]}ms datacenter latency and is connected to {EndPointDatas[1]} caches:");
                #endregion
                //Végigiterálás a végponthoz tartozó cache-eken
                for (int j = 0; j < int.Parse(EndPointDatas[1]); j++)
                {
                    //nyilván ehhez is osztály...
                    string[] CacheLatencys = lines[currentLine++].Split();

                    #region ReadInTest

                    Console.WriteLine($"The latency (of endpoint {i}) to cache {CacheLatencys[0]} is {CacheLatencys[1]} ms.");

                    #endregion
                }
            }
            //Kéréseken iterálás
            for (int i = 0; i < R; i++)
            {
                string[] requestDatas = lines[currentLine++].Split();

                #region ReadInTest
                Console.WriteLine($"{requestDatas[2]} requests for video {requestDatas[0]} coming from endpoint {requestDatas[1]}.");
                #endregion
            }

        }
    }
}
