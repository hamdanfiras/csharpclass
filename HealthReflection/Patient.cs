using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthReflection
{
    public class Patient
    {
        public string Number { get; set; }
        public string FirstName { get; set; }
        public DateTime DOB { get; set; }

        public int Age()
        {
            return DateTime.Now.Year - DOB.Year;
        }
    }
}
