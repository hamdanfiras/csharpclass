using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Class6
{
    public class APIClient
    {
        private List<Student> _students;

        public APIClient()
        {
            _students = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    Name = "Kohar",
                    Gender = "F",
                    DOB = new DateTime(1990, 1, 4)
                },
                new Student
                {
                    Id = 2,
                    Name = "Georges",
                    Gender = "M",
                    DOB = new DateTime(1995,4, 4)
                },
                new Student
                {
                    Id = 3,
                    Name = "Adam",
                    Gender = "M",
                    DOB = new DateTime(1997,4, 4)
                },
                new Student
                {
                    Id = 4,
                    Name = "Jess",
                    Gender = "F",
                    DOB = new DateTime(1995, 1, 8)
                },
            };
        }

        // usage of the generic type we specified the type as Student
        public ApiResult<Student> GetStudent(int studentId)
        {
            foreach (Student o in _students)
            {
                if (o.Id == studentId)
                {
                    return new ApiResult<Student> { Data = o };
                }
            }

            return new ApiResult<Student> { ErrorCode = "NOT_FOUND" };
        }


        public ApiResult<Teacher> GetTeacher(int teacherId)
        {
            return new ApiResult<Teacher> { Data = new Teacher { Id = teacherId, Name = "Candle" } };
        }

        public List<Student> FilterStudents(Func<Student, bool> filter)
        {
            List<Student> filteredStudents = new List<Student>();
            foreach (var student in _students)
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
