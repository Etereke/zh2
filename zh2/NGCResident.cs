using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zh2
{
    public class NGCResident
    {
        public NGCResident()
        {
            Random r = new Random();
            // 0 - pessimist, 1 - average, 2 - optimist
            Type = r.Next(0, 3);
            switch (Type)
            {
                case 0:
                    Happiness = r.Next(0, 21);
                    break;
                case 1:
                    Happiness = r.Next(0, 101);
                    break;
                case 2:
                    Happiness = r.Next(60, 101);
                    break;
            }

        }
        public string getMarker()
        {
            string marker = "!";
            switch (Type)
            {
                case 0:
                    marker = "-";
                    break;
                case 1:
                    marker = "0";
                    break;
                case 2:
                    marker = "+";
                    break;
            }
            return marker;
        }
        public int Type { get; }
        public int Happiness { get; set; }
    }
}
