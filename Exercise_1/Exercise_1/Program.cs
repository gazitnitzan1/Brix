using System;
using System.Threading;
using System.Collections;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {            
            Supermarket threadWork = new Supermarket();

            Thread queueThread = new Thread(new ThreadStart(threadWork.QueueManager));
            queueThread.Start();
            Thread.Sleep(1000);
            Thread cashiers1 = new Thread(new ThreadStart(threadWork.SupermarketWork));
            cashiers1.Start();
            Thread.Sleep(1000);
            Thread cashiers2 = new Thread(new ThreadStart(threadWork.SupermarketWork));
            cashiers2.Start();
            Thread.Sleep(1000);
            Thread cashiers3 = new Thread(new ThreadStart(threadWork.SupermarketWork));
            cashiers3.Start();
            Thread.Sleep(1000);
            Thread cashiers4 = new Thread(new ThreadStart(threadWork.SupermarketWork));
            cashiers4.Start();
            Thread.Sleep(1000);
            Thread cashiers5 = new Thread(new ThreadStart(threadWork.SupermarketWork));
            cashiers5.Start();
        }
    }
}
