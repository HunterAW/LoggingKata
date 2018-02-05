using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var myFile = Environment.CurrentDirectory + "\\Taco_Bell-US-AssemblyLoadEventArgs-Alabama.csv";

            if (args.Length == 0)
            {
                Console.WriteLine("You must provide a filename as an argument");
                Logger.Fatal("Cannot import without filename specified as an argument");
                return;
            }

            if (args.Length == 1)
            {
                Console.WriteLine("You must provide a filename as an argument");
                Logger.Fatal("Cannot import without filename specified as an argument");
                return;
            }

            Logger.Info("Log initialized");
            var lines = File.ReadAllLines(myFile);
            var parser = new TacoParser();
            var locations = lines.Select(line => parser.Parse(line));

            ITrackable firstLocation = null;
            ITrackable secondLocation = null;

            double distanceApart = 0;


            /*
                        foreach (var firstLlocation in locations)
                        {
                            var firstLocation = new Coordinate
                            {
                                Long
                                Longitute = location 
                            }
                        }
                        */
        }


    }

}