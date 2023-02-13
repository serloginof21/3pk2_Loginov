using System;
using System.Collections;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System.Drawing;

namespace PZ_1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[,] M = new bool[5, 5]{
                {false, true, true, false, false},
                {false, false, false,true, false},
                {false, true, false, false, true},
                {false, false, true, false, false},
                {false, false, false, true, false}};

            Graph graph = new Graph(5, M);
            graph.Depth(1);
            bool vertices = true;
            for (int i = 0; i < graph.Size; i++)
            {
                if (!graph.Vector[i])
                {
                    vertices = false;
                    break;
                }
                if (vertices) Console.WriteLine("Данный граф будет связным");
                break;
            }
        }

        public class Graph
        {
            public int Size { get; set; }
            public bool[,] Adjacency { get; set; }
            public bool[] Vector { get; set; }
            public Graph(int size, bool[,] G)
            {
                Adjacency = new bool[size, size];
                Adjacency = G;
                Vector = new bool[size];
                for (int i = 0; i < size; i++)
                    Vector[i] = false;
                Size = size;
            }
            public void Depth(int i)
            {
                Vector[i] = true;
                Console.Write("{0}" + ' ', i);
                for (int k = 0; k < Size; k++)
                    
            if (Adjacency[i, k] && !(Vector[k]))
                    Depth(k);
            }
        }
    }
}