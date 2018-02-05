﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using log4net;
using log4net.Core;


namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the TacoBells
    /// </summary>
    public class TacoParser
    {
        public TacoParser()
        {

        }

        private static readonly ILog Logger =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ITrackable Parse(string line)
        {
            //DO not fail if one record parsing fails, return null
            //TODO Implement

            var cells = line.Split(',');

            if (cells.Length < 3)
            {
                Logger.Error("Less then 3 cells filled");
                return null;
            }

            Logger.Info("About to initialize object to get name and location of tacobell.");
            try
            {
                var tacoBell = new TacoBell
                {
                    Name = cells[2],
                    Location = new Point(double.Parse(cells[0]), double.Parse(cells[1]))
                };
                return tacoBell;
            }
            catch (Exception e)
            {
                Logger.Error("Check to see if cells.Length < 3");
                return null;
            }


        }





        // grab the long from your array at index 0
        // grab the lat from your array at index 1
        // grab the name from your array at index 2

        // Your going to need to parse your string as a `double`
        // which is similar to parse a string as an `int`

        // You'll need to create a TacoBell class
        // that conforms to ITrackable

        // Then, you'll need an instance of the TacoBell class
        // With the name and point set correctly

        // Then, return the instance of your TacoBell class
        // Since it conforms to ITrackable


    }
}