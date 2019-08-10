﻿using System;
using System.Threading;
using System.Collections;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {                        
            Console.Write("Enter number of cashiers: ");
            int userInput = Int32.Parse(Console.ReadLine());
            int counter = 0;
            Supermarket threadWork = new Supermarket();
            Thread queueThread = new Thread(new ThreadStart(threadWork.QueueManager));
            queueThread.Start();

            while (userInput > counter)
            {
                counter++;
                Thread.Sleep(1000);
                Thread cashier = new Thread(new ThreadStart(threadWork.SupermarketWork));
                cashier.Name = counter.ToString();
                cashier.Start();
            }            
        }
    }
}
