using System;
using System.Collections.Generic;
using System.Net;

namespace Redux_sort
{
    class Program
    {
        static List<List<int>> reduxes = new List<List<int>>();
        static List<int> primary = new List<int>();
        static void SortRedux(int redux)
        {
            RefreshReduxesList();
            int cathes = 0;
            for (int i = 0; i < primary.Count; i++)
            {
                try
                {
                    reduxes[(primary[i] / redux - primary[i] / (redux * 10) * 10)].Add(primary[i]);
                }
                catch
                {
                    reduxes[0].Add(primary[i]);
                    cathes++;
                }
            }
            if(cathes<primary.Count)
            {
                primary.Clear();
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < reduxes[i].Count; j++)
                    {
                        primary.Add(reduxes[i][j]);
                    }
                }
                SortRedux(redux * 10);
            }
            else
            {
                for (int i = 0; i < primary.Count; i++)
                {
                    Console.Write(primary[i] + " ");
                }
            }    
        }

        static void RefreshReduxesList()
        {
            reduxes.Clear();
            for (int i = 0; i < 10; i++)
            {
                reduxes.Add(new List<int>());
            }
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();

            for (int i = 0; i < 30; i++)
            {
                primary.Add(rnd.Next(0, 101));
                Console.Write(primary[i] + " ");
            }

            Console.WriteLine();

            SortRedux(1);
        }
    }
}
