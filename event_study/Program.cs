using System;

namespace event_study
{
    class MyEventSource
    {
        public EventHandler<EventArgs> On_Input;
        public void MyEvent_Start()
        {
            while(true)
            {
                if (Console.ReadLine() == "x")
                {
                    On_Input(this,new EventArgs());
                }
            }
        }
    }
    class MyEventSubscriber
    {
        static public void On_Input_Handler(object s, EventArgs ea)
        {
            Console.WriteLine("你按下了x！");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyEventSource myEventSource = new MyEventSource();
            MyEventSubscriber myEventSubscriber = new MyEventSubscriber();
            myEventSource.On_Input += MyEventSubscriber.On_Input_Handler;
            myEventSource.MyEvent_Start();
            //string a = Console.ReadLine();
            //Console.WriteLine(a);
        }
    }
}
