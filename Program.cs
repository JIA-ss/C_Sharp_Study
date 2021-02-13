using System;

namespace C_Sharp_Study
{
    class Program
    {
        static void Main(string[] args)
        {
            son a = new son();
            Console.WriteLine(a.a);
            a.f();
            Console.WriteLine(a.a);
            
        }
    }
    public class father
    {
        protected string Pt = "Protect";
        internal string It = "Internal";
    }
    class son : father
    {
        public string a = "iii";
        public void f()
        {
            a = Pt;
        }
    }
}
