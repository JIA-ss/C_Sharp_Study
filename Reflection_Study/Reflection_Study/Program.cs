using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Reflection_Study
{
    internal class Program
    { 
        public static void Main(string[] args)
        {
            AClass a = new AClass();
            Type t = a.GetType();
            object o = Activator.CreateInstance(t);
            MethodInfo nopara = t.GetMethod("NoPara");
            MethodInfo sum = t.GetMethod("Sum");
            nopara.Invoke(o, null);
            sum.Invoke(o, new object[2] {1,2});
            

        }
    }

    public class AClass
    {
        public void NoPara()
        {
            Console.WriteLine("NoPara()");
        }

        public int Sum(int a, int b)
        {
            Console.WriteLine("Sum({0},{1}):{0}+{1}={2}",a,b,a+b);
            return a + b;
        }
    }
}