using Newtonsoft.Json;
using System;
using System.IO;

namespace Class5
{
    class Program
    {
      

        static void Main(string[] args)
        {
            string json = File.ReadAllText("c:\\class5\\hello.json");
            Model model = JsonConvert.DeserializeObject<Model>(json);
            Console.WriteLine(model.Id);
            Console.WriteLine(model.Make);
            Console.WriteLine(model.Number);
            Console.ReadLine();
        }

        private static void SerializeJson()
        {
            Model m = new Model { Id = "1", Make = "BMW", Number = "X3" };
            string json = JsonConvert.SerializeObject(m);
            File.WriteAllText("c:\\class5\\hello.json", json);
        }

        private static void SimpleSave()
        {
            string greeting = "Hello world " + DateTime.Now + Environment.NewLine;
            Directory.CreateDirectory("c:\\class5");
            File.AppendAllText("c:\\class5\\hello.txt", greeting);
        }

        private static void Comparable()
        {
            Car c = new Car();
            c.Year = 2018;
            c.Model = new Model { Id = "1", Make = "BMW", Number = "M3" };

            Car c1 = new Car() { Year = 2017 };

            int res = c.CompareTo(c1);
        }

        private static void Math()
        {
            MyMath math = new MyMath();
            MathUI mathUI = new MathUI(math);
            mathUI.Start();
            mathUI.SayFoo();

            CrazyMath math2 = new CrazyMath();
            MathUI mathUI2 = new MathUI(math2);
            mathUI2.Start();
            mathUI2.SayFoo();

            Console.ReadLine();
        }
    }

    public class Car : IComparable
    {
        public int Year { get; set; }
        public Model Model { get; set; }

        public int CompareTo(object obj)
        {
            Car c = obj as Car;
            if (c != null)
            {
                if (c.Year == Year)
                {
                    return 0;
                }
                else if (c.Year < this.Year)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            return -1;
        }
    }

    public class Model
    {
        public string Id { get; set; }
        public string Make { get; set; }
        public string Number { get; set; }
    }
}

// Create another implementation of IMath, call the class whatever u like, 
// then implement it in Main

// Advanced: Based on user input, choose the implentation
// Create a static class called MathFactory, a function called 
// GetMath that accepts a string and 
// returns the relevant implentation of IMathh


