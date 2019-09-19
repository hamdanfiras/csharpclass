using System;
using System.Collections.Generic;
using System.Text;

namespace Class6
{
    public class Foo<T1, T2, T3, Y> where T2 : IComparable where T3 : class where Y : struct
        where T1 : Student
    {
        public Foo()
        {

        }
        public Y Why { get; set; }
        public int Bar(T2 t2)
        {
            return t2.CompareTo(8);
        }
    }
}
