using System;
using test_namespace;
using test2;
namespace C_Sharp_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Student stu = new Student("Joshua");
            Student cp = stu;
            stu.Name = "New Name";
            Console.WriteLine("{0}:{1}",cp.GetHashCode(),cp.Name);
            Console.WriteLine("{0}:{1}",stu.GetHashCode(),stu.Name);
        }
        static void test_ref_Value(Student s)
        {
            s.Name = "New Name";
            s = new Student("New Name2");
        }
    }

    class Student
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public Student(string Name)
        {
            this.Name = Name;
        }
    }
}
