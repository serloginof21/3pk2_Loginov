using System;
using System.Collections;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace PZ_1
{
    class Program
    {
        internal class Timing
        {
            TimeSpan duration;
            TimeSpan[] threads;
            public Timing()
            {
                duration = new TimeSpan(0);
                threads = new TimeSpan[Process.GetCurrentProcess().
                Threads.Count];
            }
            public void StartTime()
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                for (int i = 0; i < threads.Length; i++)
                    threads[i] = Process.GetCurrentProcess().Threads[i].
                    UserProcessorTime;
            }
            public void StopTime()
            { //предыдущего
                TimeSpan tmp;
                for (int i = 0; i < threads.Length; i++)
                {
                    tmp = Process.GetCurrentProcess().Threads[i].
                    UserProcessorTime.Subtract(threads[i]);
                    if (tmp > TimeSpan.Zero)
                        duration = tmp;
                }
            }
            public TimeSpan Result()
            {
                return duration;
            }
        }


        static void Main(string[] args)
        {
            Timing timing = new Timing();
            Stopwatch sw = new Stopwatch();

            int z = -1;
            int v = -1;

            int[] array = new int[5000];
            Random rnd = new Random();
            for (int q = 0; q < array.Length; q++)
            {
                array[q] = rnd.Next(1, 50);
            }

            Random rand = new Random();
            List<int> num = new List<int>(5000);
            for (int j = 0; j < 5000; j++)
            {
                num.Add(rand.Next(1, 50));
            }

            Console.WriteLine("Задание с массивами");
            sw.Start();
            timing.StartTime();
            z = SimpleSearch(array, 1);
            sw.Stop();
            timing.StopTime();
            Console.WriteLine("Прямой поиск: " + $"Stopwatch: {sw.ElapsedTicks} " + $"Timing: {timing.Result()}");
            sw.Reset();

            sw.Start();
            timing.StartTime();
            v = SearchBinary(array, 1);
            sw.Stop();
            timing.StopTime();
            Console.WriteLine("Бинарный поиск: " + $"Stopwatch: {sw.ElapsedTicks} " + $"Timing: {timing.Result()}");
            sw.Reset();

            //
            //Вывод: Stopwatch будет быстрее при работе с масисивами при прямом поиске. (Тайминг почему-то не работает, не смог починить, выводилось ноль)
            //

            Console.WriteLine(" ");
            Console.WriteLine("Задание с списками");
            sw.Start();
            timing.StartTime();
            z = SimpleSearch2(num, 1);
            sw.Stop();
            timing.StopTime();
            Console.WriteLine("Прямой поиск: " + $"Stopwatch: {sw.ElapsedTicks} " + $"Timing: {timing.Result()}");
            sw.Reset();

            sw.Start();
            timing.StartTime();
            v = SearchBinary2(num, 1);
            sw.Stop();
            timing.StopTime();
            Console.WriteLine("Бинарный поиск: " + $"Stopwatch: {sw.ElapsedTicks} " + $"Timing: {timing.Result()}");
            sw.Reset();

            //
            //Вывод: Stopwatch будет быстрее при работе с списками при бинарном поиске. (Тайминг почему-то не работает, не смог починить, выводилось ноль)
            //

            Hashtable htb = new Hashtable();

            for (int i = 0; i < 5000; i++)
            {
                htb.Add(i, rnd.Next(1, 50));
            }

            Console.WriteLine(" ");
            Console.WriteLine("Задание с хэш-таблицей");
            sw.Start();
            timing.StartTime();
            z = SimpleSearch3(htb, 1);
            sw.Stop();
            timing.StopTime();
            Console.WriteLine("Прямой поиск: " + $"Stopwatch: {sw.ElapsedTicks} " + $"Timing: {timing.Result()}");
            sw.Reset();

            sw.Start();
            timing.StartTime();
            z = SearchBinary3(htb, 1);
            sw.Stop();
            timing.StopTime();
            Console.WriteLine("Бинарный поиск: " + $"Stopwatch: {sw.ElapsedTicks} " + $"Timing: {timing.Result()}");
            sw.Reset();

            //
            //Вывод: Stopwatch будет быстрее при работе с хеш-таблицами при бинарном поиске. (Тайминг почему-то не работает, не смог починить, выводилось ноль)
            //
        }

        //ДЛЯ МАССИВА
        static int SimpleSearch(int[] a, int x)
        {
            int i = 0;
            while (i < a.Length && a[i] != x) i++;
            if (i < a.Length)
            {
                return i;
            }
            else
            {
                return -1;
            }
        }


        static int SearchBinary(int[] a, int x)
        {
            int middle, left = 0, right = a.Length - 1;
            do
            {
                middle = (left + right) / 2;
                if (x > a.Length)
                    left = middle + 1;
                else
                    right = middle - 1;
            }
            while ((a[middle] != x) && (left <= right));
            if (a[middle] == x)
                return middle;

            else
                return -1;
        }

        //ДЛЯ СПИСКА
        static int SimpleSearch2(List<int> a, int x)
        {
            int i = 0;
            while (i < a.Count && a[i] != x) i++;
            if (i < a.Count)
            {
                return i;
            }
            else
            {
                return -1;
            }
        }
        static int SearchBinary2(List<int> a, int x)
        {
            int middle, left = 0, right = a.Count - 1;
            do
            {
                middle = (left + right) / 2;
                if (x > a.Count)
                    left = middle + 1;
                else
                    right = middle - 1;
            }
            while ((a[middle] != x) && (left <= right));
            if (a[middle] == x)
                return middle;

            else
                return -1;
        }

        //ДЛЯ ХЕШ-ТАБЛИЦЫ
        static int SimpleSearch3(Hashtable a, int x)
        {
            int i = 0;
            while (i < a.Count && Convert.ToInt32(a[i]) != x) i++;
            if (i < a.Count)
            {
                return i;
            }
            else
            {
                return -1;
            }
        }
        static int SearchBinary3(Hashtable a, int x)
        {
            int middle, left = 0, right = a.Count - 1;
            do
            {
                middle = (left + right) / 2;
                if (x > a.Count)
                    left = middle + 1;
                else
                    right = middle - 1;
            }
            while ((Convert.ToInt32(a[middle]) != x) && (left <= right));
            if (Convert.ToInt32(a[middle]) == x)
                return middle;

            else
                return -1;
        }


    }
}