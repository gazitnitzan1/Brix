using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Exercise_1
{
    class Supermarket
    {
        public Queue<Client> supermarketQueue;
        public SpinLock spinLock = new SpinLock();
        Random random = new Random();

        public Supermarket()
        {
            this.supermarketQueue = new Queue<Client>();
        }

        public void QueueManager()
        {
            int clientNum = 1;
            while (supermarketQueue.Count < 100)
            {
                Thread.Sleep(1000);                
                Client enteringClient = new Client(clientNum);
                supermarketQueue.Enqueue(enteringClient);
                Console.WriteLine("Client no " + clientNum + " has entered the queue at "+ enteringClient.enterTime);
                clientNum++;
            }
        }

        public void SupermarketWork()
        {
            while (true) {
                if (supermarketQueue.Count + 4 >= Thread.CurrentThread.ManagedThreadId 
                    && supermarketQueue.Count > 0) {
                    Client currentClient = supermarketQueue.Dequeue();
                    Console.WriteLine("supermarketQueue.Count -> " + supermarketQueue.Count);
                    int cashierProcessingTime = random.Next(1000, 5000);
                    Thread.BeginThreadAffinity();
                    Thread.Sleep(cashierProcessingTime);
                    Thread.EndThreadAffinity();
                    double totalWaitingTime = DateTime.Now.Subtract(currentClient.enterTime).TotalSeconds;
                    Console.WriteLine("Client " + currentClient.id
                        + " has left the cashier with total waiting time: " + totalWaitingTime + " seconds");
                }                
            }
        }
    }
}

