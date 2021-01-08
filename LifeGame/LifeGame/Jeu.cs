using System;
using System.Threading;

namespace LifeGame
{
    public class Jeu
    {
        public static void Plateau()
        {
            int longue = 10;
            int large = 10;
            Console.WriteLine("Saisissez la largeur du plateau");
            string height = Console.ReadLine();
            try
            {
                longue = Int32.Parse(height);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{height}'");
            }

            Console.WriteLine("Saisissez la largeur du plateau");
            string weight = Console.ReadLine();
            try
            {
                large = Int32.Parse(weight);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{weight}'");
            }

            Random random = new Random();
            int[,] plateau = new int[longue, large];
            int[,] tampon = new int[longue, large];
            for (int i = 0; i < longue; i++)
            {
                for (int j = 0; j < large; j++)
                {
                    int rand = random.Next(10);
                    if (rand < 6)
                        plateau[i, j] = 1;
                    else
                        plateau[i, j] = 0;
                }
            }
        }
    }
}