using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zh2
{
    class NGC
    {
        protected NGCResident[,] galaxy = new NGCResident[10, 10];
        public NGC()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    galaxy[i, j] = new NGCResident();
                }
            }
            draw();
        }
        
        private void draw()
        {
            for(int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(galaxy[i, j].getMarker());
                }
                Console.WriteLine();
            }
            Console.WriteLine("Total Galaxy Happiness: " + getGalaxyHappiness());
        }
        public void getNextStep()
        {
            NGCResident[,] galaxyPrevState = galaxy.Clone() as NGCResident[,];
            // Shuffle old array
            for (int i = galaxy.Length - 1; i > 0; i--)
            {
                int i0 = i / 10;
                int i1 = i % 10;
                Random r = new Random();
                int j = r.Next(i + 1);
                int j0 = j / 10;
                int j1 = j % 10;

                NGCResident temp = galaxy[i0, i1];
                galaxy[i0, i1] = galaxy[j0, j1];
                galaxy[j0, j1] = temp;
            }
            // calculate new happiness based on previous state
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    switch (galaxy[i, j].Type)
                    {
                        case 0:
                            if (galaxyPrevState[i, j].Type == 2)
                            {
                                galaxy[i, j].Happiness /= 2;
                            }
                            break;
                        case 1:
                            galaxy[i, j].Happiness += galaxyPrevState[i, j].Happiness;
                            galaxy[i, j].Happiness /= 2;
                            break;
                    }
                }
            }
            draw();
        }

        private int getGalaxyHappiness()
        {
            int happinessTotal = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    happinessTotal += galaxy[i, j].Happiness;
                }
            }
            return happinessTotal;
        }
    }
}
