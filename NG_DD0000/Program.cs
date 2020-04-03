using System;
using System.Diagnostics;

namespace NG_DD0000
{
    public class Program
    {
        static void Main()
        {
            int ticks = Convert.ToInt32(DateTime.Now.Second);
            Random rand = new Random(ticks);
            draw(rand, 100,100);
        }

        static void draw(Random random, int width, int hight)
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            double[,] map = new double[width, hight];
            double[,] newmap = new double[width, hight];
            //0<i0<40  41<=i1<=100
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    map[i, j] = 0;
                    newmap[i, j] = 0;
                }
            }

            int randCount = Convert.ToInt32(map.GetLength(0) * map.GetLength(0) * 0.3);

            for (int i = 0; i < randCount; i++)
            {
                int randi = random.Next(0, map.GetLength(0));
                int randj = random.Next(0, map.GetLength(1));

                map[randi, randj] = 1;
            }


            //Print(map);
            //Console.ForegroundColor = ConsoleColor.Black;
            //Console.WriteLine();


           

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 1)
                    {
                        if (i != 0 && j != 0)
                        {
                            newmap[i, j - 1] = 1;
                            newmap[i - 1, j - 1] = 1;
                            newmap[i - 1, j] = 1;
                        }
                        if (i != map.GetLength(0) - 1 && j != map.GetLength(1) - 1)
                        {
                            newmap[i, j + 1] = 1;
                            newmap[i + 1, j + 1] = 1;
                            newmap[i + 1, j] = 1;
                        }
                    }
                }
            }

            Console.WriteLine();
            int koifPizd = Convert.ToInt32( newmap.GetLength(1) * 0.01);
            int koifnomal = 5;

            
            for (int i = 0; i < newmap.GetLength(0); i++)
            {


                int prev = random.Next(1, Convert.ToInt32(newmap.GetLength(0) * 0.5));
                int prevj = random.Next(1, Convert.ToInt32(newmap.GetLength(1) * 0.5));

                for (int j = 0; j < newmap.GetLength(1); j++)
                {
                    if (!(i == 0 && j == 0 || i == newmap.GetLength(0) + 1 && j == newmap.GetLength(1) + 1 || i == newmap.GetLength(0) - 1 && j == newmap.GetLength(1) - 1))
                    {

                        if (i == 0 && j >= 0)
                        {
                            int randStor = random.Next(prev - koifnomal < 0 ? prev : prev - koifnomal, prev + koifnomal > newmap.GetLength(0) ? newmap.GetLength(0) : prev + koifnomal);
                            for (int i0 = 0; i0 < randStor; i0++)
                            {
                                newmap[i0, j] = 0;
                            }
                            prev = randStor;
                        }
                        else if (i >= 0 && j == newmap.GetLength(1) - 1)
                        {
                            int randStorj = random.Next(prevj - koifnomal < 0 ? prevj : prevj - koifnomal, prevj + koifnomal > newmap.GetLength(1) ? newmap.GetLength(1) :  prevj + koifnomal );
                            for (int j0 = j; j0 > j - randStorj; j0--)
                            {
                                newmap[i, j0] = 0;
                            }
                            prevj = randStorj;
                        }
                        else if (i == newmap.GetLength(0)-1 && j >= 0)
                        {
                            int randStor = random.Next(prev - koifnomal < 0? prev : prev - koifnomal, prev + koifnomal > newmap.GetLength(0) ? newmap.GetLength(0) : prev + koifnomal);
                            for (int i0 = i; i0 > i - randStor; i0--)
                            {
                                newmap[i0, j] = 0;
                            }
                            prev = randStor;
                        }
                        else if (i >= 0 && j == 0)
                        {
                            int randStorj = random.Next(prevj - koifnomal < 0 ? prevj : prevj - koifnomal, prevj + koifnomal > newmap.GetLength(1) ? newmap.GetLength(1) : prevj + koifnomal);
                            for (int j0 = 0; j0 < randStorj; j0++)
                            {
                                newmap[i, j0] = 0;
                            }
                            prevj = randStorj;
                        }


                    }

                }
            }




            //Print(newmap);
            //Console.ForegroundColor = ConsoleColor.Black;
            //Console.WriteLine();
  
            for (int i = 0; i < newmap.GetLength(0); i++)
            {
                for (int j = 0; j < newmap.GetLength(1); j++)
                {
                    if (i != 0 && j != 0 && i!= newmap.GetLength(0)+1 && j != newmap.GetLength(1)+1 && i != newmap.GetLength(0) - 1 && j != newmap.GetLength(1) - 1)
                    {
                        if (newmap[i, j] == 0 && 
                                (newmap[i - 1, j] != 0 &&  newmap[i + 1, j] != 0 || 
                                newmap[i, j - 1] != 0 && newmap[i, j + 1] != 0 || 
                                newmap[i - 1, j] != 0 && newmap[i + 1, j] != 0 && newmap[i, j - 1] != 0 && newmap[i, j + 1] != 0
                            ))
                        {
                            newmap[i, j] = 1;
                        }
                    }
                    else
                    {
                        newmap[i, j] = 0;
                    }
                }
            }

            time.Stop();

            Print(newmap);
            Console.WriteLine("Elapsed time: " + time.ElapsedMilliseconds / 1e3);
            Console.ReadKey();
        }




        static void Print(double[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    switch (map[i, j])
                    {
                        case 0:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                    Console.Write(map[i, j] + " ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }
        }
    }
}
