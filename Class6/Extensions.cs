using System;
using System.Collections.Generic;
using System.Text;

namespace Class6
{
    public static class Extensions
    {
        public static string SayHelloToGeorges(this string sdsd, int x)
        {
            return sdsd + ", Hello Georges " + x;
        }

        public static List<Student> FilterStudents(this List<Student> students, Func<Student, bool> filter)
        {
            List<Student> filteredStudents = new List<Student>();
            foreach (var student in students)
            {
                if (filter(student))
                {
                    filteredStudents.Add(student);
                }
            }
            return filteredStudents;
        }
    }
}
