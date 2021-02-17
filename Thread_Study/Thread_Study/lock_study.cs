using System;

namespace Thread_Study
{
    public class lock_study
    {
        private object locker_ = new object();

        public void f()
        {
            lock (locker_)
            {
                Console.WriteLine("这里就可以实现加锁做事了");
            }
        }
    }
}