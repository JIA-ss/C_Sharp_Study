using System;
using System.Threading;

namespace Thread_Study
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var sig = new signal_study();
            sig.block_And_Wait_Signal();
            Thread.Sleep(2000);
            sig.send_Signal();
            Thread.Sleep(2000);
            sig.block_And_Wait_Signal();
            sig.send_Signal();
        }


    }


}