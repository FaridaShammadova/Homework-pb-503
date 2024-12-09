using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_09._12._2024
{
    public class NotInvalidProcessException:Exception
    {
        public NotInvalidProcessException()
        { 
        }

        public NotInvalidProcessException(string? message):base(message)
        {
        }
    }
}
