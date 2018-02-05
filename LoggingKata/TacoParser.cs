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

        private static readonly ILog Logger =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ITrackable Parse(string line)
        {
            if (string.IsNullOrEmpty(line)) { return null; }

            var cells = line.Split(',');

            if (cells.Length < 2)
            {
                return null;
            }
            
            try
            {
                var lon = double.Parse(cells[0]);
                var lat = double.Parse(cells[1]);

                return new TacoBell
                {
                    Name = cells.Length > 2 ? cells[2] : null,
                    Location = new Point(lat, lon)
                };
            }
            catch (Exception e)
            
            {
                return null;
            }
        }
    }
}