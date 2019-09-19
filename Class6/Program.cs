using System;
using System.Collections.Generic;

namespace Class6
{
    public delegate bool IntToBool(int x);
    public delegate bool ValueToBool<T>(T x) where T : struct;
    public delegate bool ValueToBool<T1, T2>(T1 x, T2 y);

    public delegate TRet TheFunc<TRet, T1>(T1 x);
    public delegate TRet TheFunc<TRet, T1, T2>(T1 x, T2 y);
    public delegate TRet TheFunc<TRet, T1, T2, T3>(T1 x, T2 y, T3 z);

    public delegate void TheAction<T1>(T1 x);
    public delegate void TheAction<T1, T2>(T1 x, T2 y);
    public delegate void TheAction<T1, T2, T3>(T1 x, T2 y, T3 z);


    public class Bar
    {
        public bool Foo(int z)
        {
            return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Car c = new Car();
            c.Plate = "G646464";

            SpeedTicket speedTicket = new SpeedTicket(c);

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int toadd))
                {
                    c.IncreaseSpeed(toadd);
                }
            }

            Console.ReadLine();
        }

        private static void Chaining()
        {
            APIClient client = new APIClient();
            List<Student> filteredStudents =
                client
                .FilterStudents(s => s.Gender == "M" || s.Gender == "F")
                .FilterStudents(s => s.DOB.Year > 1996)
                .FilterStudents(s => s.Gender == "F");


            Console.ReadLine();
        }

        private static void SimpleExtension()
        {
            string s = "abc";
            string y = s.SayHelloToGeorges(3);
            string y2 = Extensions.SayHelloToGeorges(s, 3);
            Console.WriteLine(y);
        }

        private static void LambdaAndCo()
        {
            //Func<int, int> multiplyByTwo = delegate (int x)
            //{
            //    return x * 2;
            //};

            Func<Student, bool> maleFilter = delegate (Student s)
            {
                return s.Gender == "M";
            };

            Func<Student, bool> maleAndNew = (Student s) =>
            {
                return s.Gender == "M" && s.DOB.Year > 1996;
            };

            Func<Student, bool> maleAndNew2 = s =>
            {

                return s.Gender == "M" && s.DOB.Year > 1996;
            };

            Func<Student, bool> maleAndNew3 = s => s.Gender == "M" && s.DOB.Year > 1996;



            APIClient client = new APIClient();
            List<Student> filteredStudents =
                client.FilterStudents(s => s.Gender == "M" && s.DOB.Year > 1996);

            foreach (var student in filteredStudents)
            {
                Console.WriteLine(student.Name);
            }
        }

        private static void IntroToDelegates()
        {
            //var cc = CanDance;
            //IntToBool cc = new IntToBool(CanDance);
            //IntToBool cc = CanDance;
            Bar b = new Bar();
            // ValueToBool<int> cc = b.Foo;
            //  TheFunc<bool, int> cc = b.Foo;
            Func<int, bool> cc = b.Foo;
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                if (cc(n))
                {
                    Console.WriteLine("Yes we can dance");
                }
                else
                {
                    Console.WriteLine("Boooring");
                }
            }
        }

        static bool FemaleFilter(Student s)
        {
            return s.Gender == "F";
        }

        static bool FemaleFilter2(Student s)
        {
            return s.Gender == "F" && s.DOB.Year >= 1994;
        }

        public static bool CanDance(int x)
        {
            return x % 2 == 0;
        }

        private static void GenericDictionary()
        {
            Dictionary<string, Student> dict = new Dictionary<string, Student>();
            dict.Add("x", new Student { Id = 1 });

            Student s = dict["x"];
        }

        private static void ApiResultGenericExample()
        {
            APIClient client = new APIClient();
            Console.WriteLine("Student");

            if (int.TryParse(Console.ReadLine(), out int studentId))
            {
                ApiResult<Student> res = client.GetStudent(studentId);
                if (res.ErrorCode == "NOT_FOUND")
                {
                    Console.WriteLine("Sorry we do not have this student");
                }
                else
                {
                    Console.WriteLine("Student Name {0}", res.Data.Name);
                }

            }

            Console.WriteLine("TEacher");


            if (int.TryParse(Console.ReadLine(), out int teacherId))
            {
                ApiResult<Teacher> res = client.GetTeacher(teacherId);
                if (res.ErrorCode == "NOT_FOUND")
                {
                    Console.WriteLine("Sorry we do not have this teacher");
                }
                else
                {
                    Console.WriteLine("Teacher Name {0}", res.Data.Name);
                }

            }
        }
    }
}
