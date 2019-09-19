using System;
using System.Collections.Generic;
using System.Text;

namespace Class6
{
    // definition
    public class ApiResult<T1>
    {
        public string ErrorCode { get; set; }
        public T1 Data { get; set; }
    }

    //public class TeacherApiResult
    //{
    //    public string ErrorCode { get; set; }
    //    public Teacher Student { get; set; }


    //}
}
