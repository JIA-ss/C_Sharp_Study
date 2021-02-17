using System;
using System.Threading;

namespace Thread_Study
{
    public class signal_study
    {
        private ManualResetEvent signal_ = new ManualResetEvent(false);
        public void block_And_Wait_Signal()
        {
            new Thread(() =>
            {
                Console.WriteLine("Waiting for Signal...");
                signal_.WaitOne();
                //signal_.Dispose();  //如果这里使用了Dispose，那么signal_这个信号就会被释放掉，以后就无法再次使用了。
                Console.WriteLine("Got signal");
            }).Start();
        }

        public void send_Signal()
        {
            signal_.Set();
        }
    }
}