using System;

namespace Exercise_1
{
    internal class Client
    {
        public int id;
        public DateTime enterTime;

        public Client(int id)
        {
            this.id = id;
            this.enterTime = DateTime.Now;
        }
    }
}