using System;

namespace Class5
{
    public class MathUI
    {
        private IMath _math;
        public MathUI(IMath math)
        {
            _math = math;
        }

        public void Start()
        {
            int.TryParse(Console.ReadLine(), out int first);
            int.TryParse(Console.ReadLine(), out int second);
            int res = _math.Operation(first, second);
            Console.WriteLine(res);
        }

        public void SayFoo()
        {
            string s = _math.Foo(DateTime.Now.Millisecond, "yey");
            Console.WriteLine(s);
        }
    }
}


