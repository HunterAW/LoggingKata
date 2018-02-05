using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using log4net;
using log4net.Core;


namespace LoggingKata
{
    public class TacoParser
    {
        public TacoParser()
        {

        }

        private static readonly ILog Logger =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ITrackable Parse(string line)
        {

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

    }
}