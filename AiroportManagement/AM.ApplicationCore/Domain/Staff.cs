using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Staff:Passenger
    {
        public DateTime EmploymentDate {  get; set; }

        public float Salary {  get; set; }

        public string Function {  get; set; }

    }
}
