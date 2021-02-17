using System;
using System.Threading;

namespace Thread_Study
{
    public class para_pass
    {
        void f()
        {
            //通过lambda函数来进行参数传递。
            for (int i = 0; i < 10; i++)
            {
                //这里不直接使用i，因为lambda是传地址
                //声明temp，会令每次传递给lambda都分配一个地址，而直接使用i，是在原有地址上修改数值，导致将0-9全部输出
                int temp = i;
                new Thread(() =>
                {
                    Console.WriteLine(temp);
                }).Start();
            }
        }
    }
}