namespace Class5
{
    public class MyMath : IMath, ICalc
    {
        public string Foo(int g, string y)
        {
            return "hello " + y + g.ToString();
        }

        public int Operation(int i, int j)
        {
            return i + j;
        }
    }

    public class CrazyMath : IMath
    {
        public string Foo(int x, string y)
        {
            return "hello";
        }

        public int Operation(int x, int y)
        {
            return x * y - 10;
        }
    }

    public class XYZ : IMath
    {
        string IMath.Foo(int x, string y)
        {
            throw new System.NotImplementedException();
        }

        void Foo()
        {

        }

        int IMath.Operation(int x, int y)
        {
            throw new System.NotImplementedException();
        }
    }
}
