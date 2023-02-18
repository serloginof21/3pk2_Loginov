using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Deikstra
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] graph = new int[,]
            { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
              { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
              { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
              { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
              { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
              { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
              { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
              { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
              { 0, 0, 2, 0, 0, 0, 6, 7, 0 }
            };

            int startN = 0;
            int[] dist = Deikstra(graph, startN);

            Console.WriteLine("Узел:");
            for (int i = 0; i < dist.Length; i++)
            {
                Console.WriteLine("{0}", i);
            }
            Console.WriteLine("Расстояние от начального узла:");
            for (int z = 0; z < dist.Length; z++)
            {
                Console.WriteLine("{1}", z, dist[z]);
            }
            Console.WriteLine("Кратчайший путь:");
            int minV = dist[1];
            for (int h = 2; h < dist.Length; h++)
            {
                if (dist[h] < minV)
                {
                    minV = dist[h];
                }
            }
            Console.WriteLine(minV);

            static int[] Deikstra(int[,] graph, int startN)
            {
                int n = graph.GetLength(0);
                int[] distance = new int[n];
                bool[] used = new bool[n];

                for (int i = 0; i < n; i++)
                {
                    distance[i] = int.MaxValue;
                    used[i] = false;
                }

                distance[startN] = 0;

                for (int i = 0; i < n - 1; i++)
                {
                    int minDistance = int.MaxValue;
                    int minNode = 0;

                    for (int j = 0; j < n; j++)
                    {
                        if (!used[j] && distance[j] < minDistance)
                        {
                            minDistance = distance[j];
                            minNode = j;
                        }
                    }

                    used[minNode] = true;

                    for (int j = 0; j < n; j++)
                    {
                        if (!used[j] && graph[minNode, j] != 0 && distance[minNode] != int.MaxValue && distance[minNode] + graph[minNode, j] < distance[j])                                                                                                                                 //Он также проверяет, не является ли расстояние до узла с минимальным расстоянием большим значением и если сумма расстояния до узла с минимальным расстоянием и веса ребра меньше текущего расстояния до узла "j"
                        {
                            distance[j] = distance[minNode] + graph[minNode, j];
                        }
                    }
                }
                return distance;
            }
        }
    }
}