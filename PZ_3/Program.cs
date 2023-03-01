using PZ_3;
using System;
using System.Drawing;

namespace PZ_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeRoot = 5;
            Node root = new Node();
            BynaryTree tree = new BynaryTree(sizeRoot);
            root = tree.Root;

            Console.WriteLine("Все значения древа: ");
            BynaryTree.GetTreeData(tree.Root);

            //Задание 1
            Console.WriteLine("Среднее значение древа: " + Math.Round(root.GetAverage(sizeRoot), 0));
            //Задание 2
            Console.WriteLine("Кол-во положительных корней в древе: " + root.CountTRoot);
            Console.WriteLine("Кол-во отрицательных корней в древе: " + root.CountFRoot);
            //Задание 3
            Console.Write("Узнать кол-во повторений числа в древе:");
            int FindRoot = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Число корней содержащих " + FindRoot + " : " + root.FindNumberRoot(root, FindRoot));
        }
    }
}