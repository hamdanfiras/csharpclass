using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Class9
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fs = File.OpenRead(@"c:\test\stream1.txt"))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    string text = reader.ReadToEnd();
                    Console.WriteLine(text);
                }
            }

            using (FileStream fs = File.OpenWrite(@"c:\test\stream1.txt"))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.WriteLine("hello again q");
                 
                }
            }

            using (MemoryStream ms = new MemoryStream())
            {

            }
        }

        private static void ReturnValueTask()
        {
            Task<int> t = Task.Factory.StartNew<int>(ToMuchTimeToJustAddNumbers);
            t.Wait();
            var i = t.Result;
            Console.WriteLine(i);

            Task<int> c = TooMuchTimeToJustAddNumbersAsync();

            var r = c.Result;

            Task main2 = Main2();
            t.Wait();
        }

        static async Task Main2()
        {
            int c1 = await TooMuchTimeToJustAddNumbersAsync2();

        }

        private static void PassingDataToTask()
        {
            Task[] tasks = new Task[10];
            for (int i = 0; i < 10; i++)
            {
                //Task t = Task.Factory.StartNew(SayHelloFromAnotherThread, i);
                Task t = Task.Factory.StartNew(o =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("Another thread! {0}, {1}",
                        Thread.CurrentThread.ManagedThreadId,
                        o);
                }, i);
                tasks[i] = t;
            }

            Task.WaitAll(tasks);
        }

        static int ToMuchTimeToJustAddNumbers()
        {
            Thread.Sleep(1000);
            return DateTime.Now.Millisecond;
        }

        static Task<int> TooMuchTimeToJustAddNumbersAsync()
        {
            Thread.Sleep(1000);
            int m = DateTime.Now.Millisecond;
            return Task.FromResult<int>(m);
        }

        static async Task<int> TooMuchTimeToJustAddNumbersAsync2()
        {
            Thread.Sleep(1000);
            int m = DateTime.Now.Millisecond;
            return m;
        }

        static void SayHelloFromAnotherThread(object n)
        {
            Thread.Sleep(3000);
            Console.WriteLine("Another thread! {0}, {1}",
                Thread.CurrentThread.ManagedThreadId,
                n);
        }

        private static void WithLambda()
        {
            Task t = new Task(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("Another thread! {0}", Thread.CurrentThread.ManagedThreadId);
            });
            t.Start();
            Console.WriteLine("something");
            t.Wait();
            Console.WriteLine("after wait");
        }

        private static void SimpleTask()
        {
            Task t = new Task(SayHelloFromAnotherThread);
            t.Start();
            Console.WriteLine("something");
            t.Wait();
            Console.WriteLine("after wait");
        }

        static void SayHelloFromAnotherThread()
        {
            Thread.Sleep(3000);
            Console.WriteLine("Another thread! {0}", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
