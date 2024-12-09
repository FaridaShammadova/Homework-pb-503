using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_09._12._2024
{
    public class Employee
    {
        public string? Fullname { get; set; }
        public double HourlyRate { get; set; }
        public double HoursWorked { get; set; }

        public double CalculateTotalSalary()
        {
            if (HourlyRate > 0 && HoursWorked > 0)
            {
                return HourlyRate * HoursWorked;
            }
            return 0;
        }
    }
}
