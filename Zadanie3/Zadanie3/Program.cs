using System;
using System.Threading;
using System.Collections.Generic;

namespace ConsoleApp12
{
    static class Program
    {
        static bool flag = true;
        static void Main(string[] args)
        {
            Thread threadConsumerOne = new Thread(new ThreadStart(Consumer));
            Thread threadConsumerTwo = new Thread(new ThreadStart(Consumer));
            Thread threadManufacturerOne = new Thread(new ThreadStart(Manufacturer));
            Thread threadManufacturerTwo = new Thread(new ThreadStart(Manufacturer));
            Thread threadManufacturerThree = new Thread(new ThreadStart(Manufacturer));
            threadConsumerOne.Start();
            threadConsumerTwo.Start();
            threadManufacturerOne.Start();
            threadManufacturerTwo.Start();
            threadManufacturerThree.Start();
            while (true)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        Console.WriteLine(ProductsQueue.products.Count);
                        break;
                    case ConsoleKey.Q:
                        flag = false;
                        return;
                }
            }
        }
        static void Consumer()
        {
            while (flag)
            {

                if (ProductsQueue.products.Count == 0)
                {
                    while (ProductsQueue.products.Count == 0 && flag)
                    {
                        Thread.Sleep(100);
                    }
                }
                else
                {
                    if (ProductsQueue.products.Count != 0)
                    {
                        ProductsQueue.products.Pop();
                        Console.WriteLine("Эл-т взят");
                        Thread.Sleep(1000);
                    }
                }
            }
        }
        static void Manufacturer()
        {
            while (flag)
            {
                if (ProductsQueue.products.Count >= 100)
                {
                    while (ProductsQueue.products.Count > 80 && flag)
                    {
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    ProductsQueue.products.Push("1");
                    Console.WriteLine("Эл-т добавлен");
                    Thread.Sleep(250);
                }
            }
        }
    }
    static class ProductsQueue
    {
        public static Stack<string> products = new Stack<string>();
    }
    static class GenerateRandom
    {
        public static int Random()
        {
            int number;
            Random rand = new Random();
            number = rand.Next(1, 100);
            return number;
        }
    }
}