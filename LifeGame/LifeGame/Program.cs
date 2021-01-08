using System;
using System.Threading;
using System.Threading.Tasks;

namespace LifeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialisation du plateau de jeu
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
            //Démarrage de la partie
            int somme = 1;
            int count = 0;
            int prev_somme = 100;
            while (somme != 0 && somme != longue*large && count != 5)
            {
                
                somme = 0;
                for (var i = 0; i < longue; i++)
                {
                    for (int j = 0; j < large; j++)
                    {
                        somme += plateau[i, j];
                    }
                }

                if (somme == prev_somme)
                {
                    count += 1;
                }
                else
                {
                    prev_somme = somme;
                    count = 0;
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine('\n' + "Population : " +somme,Console.ForegroundColor);
                for (int s = 0; s < longue; s++)
                {
                    for (int r = 0; r < large; r++)
                    {
                        switch (plateau[s, r])
                        {
                            case 1:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("X ");
                                break;
                            case 0:
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("O ");
                                break;
                        } 

                    }
                    Console.WriteLine();
                }
                
                Thread.Sleep(200);
                
                for (int x = 0; x < longue; x++)
                {
                    int xafter, xbefore;
                    if (x - 1 < 0)
                    {
                        xbefore = longue-1;
                    }
                    else
                    {
                        xbefore = x - 1;
                    }

                    if (x + 1 > longue-1)
                    {
                        xafter = 0;
                    }
                    else
                    {
                        xafter = x + 1;
                    }

                    for (int y = 0; y < large; y++)
                    {
                        int ybefore;
                        int yafter;

                        if (y - 1 < 0)
                        {
                            ybefore = large-1;
                        }
                        else
                        {
                            ybefore = y - 1;
                        }

                        if (y + 1 > large-1)
                        {
                            yafter = 0;
                        }
                        else
                        {
                            yafter = y + 1;
                        }

                        int tLeftcorner = plateau[xbefore, ybefore],
                            top = plateau[xbefore, y],
                            tRightcorner = plateau[xafter, yafter],
                            left = plateau[x, ybefore],
                            right = plateau[x, yafter],
                            bLeftcorner = plateau[xafter, ybefore],
                            bottom = plateau[xafter, y],
                            bRightcorner = plateau[xbefore, yafter];


                        int total = tLeftcorner + top + tRightcorner + left + right + bRightcorner + bottom +
                                    bLeftcorner;

                        switch (plateau[x, y])
                        {
                            case 1 when total == 2 || total == 3:
                                tampon[x, y] = 1;
                                break;
                            case 1:
                                tampon[x, y] = 0;
                                break;
                            case 0 when total == 3:
                                tampon[x, y] = 1;
                                break;
                            case 0:
                                tampon[x, y] = 0;
                                break;
                        }
                    }
                }
                plateau = tampon;
            }

            Console.ReadLine();
        }
    }
}
