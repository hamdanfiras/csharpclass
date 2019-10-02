using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var book = new Book { Id = 1, Title = "jldkd", Foo = "xyz" };
            var chapter = new Chapter { Id = 2, Title = "something" };

            List<object> objects = new List<object> { book, chapter };

            foreach (var o in objects)
            {
                bool doNotTouch = false;
                Type t = o.GetType();

                foreach (HighSensitiveAttribute att
                    in t.GetCustomAttributes(typeof(HighSensitiveAttribute), false))
                {
                    if (!att.AllowJson)
                    {
                        doNotTouch = true;
                    }
                }

                if (!doNotTouch)
                {
                    var json = JsonConvert.SerializeObject(o);
                    Console.WriteLine(json);
                }
            }



            Console.ReadLine();
        }
    }



    [HighSensitive(AllowJson = false)]
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [JsonIgnore]

        public string Foo { get; set; }
    }

    [HighSensitive(AllowJson = true)]
    public class Chapter
    {
        public int Id { get; set; }

        public string Title { get; set; }

    }
    
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class)]
    public class HighSensitiveAttribute : Attribute
    {
        public bool AllowJson { get; set; }
    }
}
