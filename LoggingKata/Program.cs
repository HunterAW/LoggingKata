using System;
using System.Linq;
using log4net;
using System.IO;
using Geolocation;

namespace LoggingKata
{
    class Program
    {
        private static readonly ILog Logger =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            var myFile = Environment.CurrentDirectory + "\\Taco_Bell-US-AL-Alabama.csv";

            var lines = File.ReadAllLines(myFile);

            if (lines.Length == 0)
            {
                Console.WriteLine("You must provide a filename as an argument args.Length == 0");
                Logger.Fatal("Cannot import without filename specified as an argument");
                return;
            }

            if (lines.Length == 1)
            {
                Console.WriteLine("You must provide a filename as an argument args.Length == 1");
                Logger.Fatal("Cannot import without filename specified as an argument");
                return;
            }

            Logger.Info("Log initialized");
            var parser = new TacoParser();
            var locations = lines.Select(line => parser.Parse(line)).ToList();

            ITrackable tBellA = null;
            ITrackable tBellB = null;

            var distanceGreatest = 0.0;

            foreach (var a in locations)
            {
                var origin = new Coordinate { Latitude = a.Location.Latitude, Longitude = a.Location.Longitude };

                foreach (var b in locations)
                {
                    var destination = new Coordinate { Latitude = b.Location.Latitude, Longitude = b.Location.Longitude };

                    var distance = GeoCalculator.GetDistance(origin, destination);

                    if (distance <= distanceGreatest) { continue; }

                    distanceGreatest = distance;
                    tBellA = a;
                    tBellB = b;
                }
            }

            Console.WriteLine($"The two Taco Bell's that are furthest from each are {distanceGreatest} apart!");
            Console.ReadLine();
        }

    }
}