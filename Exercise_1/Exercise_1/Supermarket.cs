using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Exercise_1
{
    class Supermarket
    {
        public ConcurrentQueue<Client> supermarketQueue;
        Random random = new Random();

        public Supermarket()
        {
            this.supermarketQueue = new ConcurrentQueue<Client>();
        }

        public void QueueManager()
        {
            int clientNum = 1;
            while (true)
            {
                Thread.Sleep(1000);
                Client enteringClient = new Client(clientNum);
                supermarketQueue.Enqueue(enteringClient);
                Console.WriteLine("Client " + clientNum + " has entered the queue at " + enteringClient.enterTime);
                clientNum++;
            }
        }

        public void SupermarketWork()
        {
            Client currentClient;
            while (true)
            {
                if (supermarketQueue.TryDequeue(out currentClient))
                {
                    Console.WriteLine("supermarketQueue.Count -> " + supermarketQueue.Count);
                    int cashierProcessingTime = random.Next(1000, 5000);
                    Thread.Sleep(cashierProcessingTime);
                    double totalWaitingTime = DateTime.Now.Subtract(currentClient.enterTime).TotalSeconds;
                    Console.WriteLine("Client " + currentClient.id + " served by cashier " + Thread.CurrentThread.Name
                        + " has left the cashier with total waiting time: " + totalWaitingTime + " seconds");
                }
            }
        }
    }
}
