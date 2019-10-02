using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HealthConsoleReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            //Foo f = new Foo();
            //f.Bar();

            //string s = "hello";
            //s.Bar();

            dynamic s = "hello";
            //string s1 = "hello";

         

            Console.WriteLine(s.Length);

            s = 1;
            Console.WriteLine(s);

            s = new Foo();

            Console.WriteLine(s.Bar());


            Foo foo = new Foo();
            foo.Baz(new Greeting());

            Console.ReadLine();
            
        }



        private static void Reflection()
        {
            Assembly assembly = Assembly.LoadFrom(@"C:\test\csharpclass\HealthReflection\bin\Release\HealthReflection.dll");
            var types = assembly.GetTypes();
            foreach (var t in types)
            {
                var p = Activator.CreateInstance(t);

                var method = t.GetMethod("Age");
                var propDOB = t.GetProperty("DOB");
                propDOB.SetValue(p, new DateTime(1980, 4, 4));
                var age = method.Invoke(p, new object[] { });
            }
        }
    }

    public class Foo
    {
        public string Bar()
        {
            return "bar";
        }

        public void Baz(dynamic d)
        {
            d.Hello();
        }
    }

    public class Greeting {
        public void Hello()
        {
            Console.WriteLine("Good morning");
        }
    }

}
