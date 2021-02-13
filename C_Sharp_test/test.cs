using System;

namespace test_namespace 
{
    internal class father
    {
        protected string pt = "Protected member";
        internal string it = "Internal member";
        protected internal string pt_it = "Protected internal member";
    }

    internal class son : father
    {
        public string s_pt = "son_public";
        public void f()
        {
            s_pt = pt;
        }
    }
}
