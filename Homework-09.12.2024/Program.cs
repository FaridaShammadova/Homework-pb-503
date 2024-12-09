namespace Homework_09._12._2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee? employee=null;
            bool check = false;

            while(!check)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1 - Add new employee");
                Console.WriteLine("2 - Add hours worked by the employee");
                Console.WriteLine("3 - Calculate and show total salary");
                Console.WriteLine("0 - Exit");

                string? choose=Console.ReadLine();

                try
                {
                    CheckInvalidProcess(choose);
                }
                catch (NotInvalidProcessException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                switch (choose)
                {
                    case "1":
                        Console.WriteLine("Enter fullname:");
                        string? fullname=null;
                        bool check1 = false;
                        while (!check1)
                        {
                            try
                            {
                                fullname = Console.ReadLine();
                                if(string.IsNullOrEmpty(fullname) || string.IsNullOrWhiteSpace(fullname))
                                {
                                    Console.WriteLine("Fullname cannot be null or empty! Please enter coorect fullname:");
                                    continue;
                                }
                            }
                            catch (NullReferenceException)
                            {
                                Console.WriteLine("Invalid fullname! Please enter fullname again:");
                                continue;
                            }
                            check1 = true;
                        }

                        Console.WriteLine("Enter hourly rate:");
                        double hourlyRate = 0;
                        bool check2 = false;
                        while (!check2)
                        {
                            try
                            {
                                hourlyRate = Convert.ToDouble(Console.ReadLine());
                                if (hourlyRate <= 0)
                                {
                                    Console.WriteLine("Hourly rate cannot be negative or zero! Please enter positive number:");
                                    continue;
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Invalid hourly rate! Please enter hourly rate again:");
                                continue;
                            }
                            check2 = true;
                        }

                        employee = new Employee()
                        {
                            Fullname = fullname,
                            HourlyRate = hourlyRate
                        };

                        Console.WriteLine("New employee added.");
                        break;

                    case "2":
                        if (employee == null)
                        {
                            Console.WriteLine("Please add an employee.");
                            continue;
                        }

                        Console.WriteLine("Enter hourly worked by the employee:");
                        double hoursWorked = 0;
                        bool check3 = false;

                        while (!check3)
                        {
                            try
                            {
                                hoursWorked = Convert.ToDouble(Console.ReadLine());

                                if (hoursWorked <= 0)
                                {
                                    Console.WriteLine("Hours worked cannot be negative or zero! Please enter positive number:");
                                    continue;
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Invalid hours worked! Please enter hours worked again:");
                                continue;
                            }
                            check3 = true;
                        }

                        employee.HoursWorked = hoursWorked;

                        Console.WriteLine("The hourly worked added.");

                        break;

                    case "3":
                        if (employee == null)
                        {
                            Console.WriteLine("Please add an employee.");
                            continue;
                        }

                        double totalSalary = employee.CalculateTotalSalary();

                        Console.WriteLine($"Total salary is {totalSalary}");
                        break;

                    case "0":
                        check = true;
                        Console.WriteLine("Process has ended.");
                        break;
                }
            }
        }

        static void CheckInvalidProcess(string? value)
        {
            if(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new NotInvalidProcessException("Invalid option!");
            }

            foreach(char chr in value)
            {
                if (!char.IsDigit(chr))
                {
                    throw new NotInvalidProcessException("Invalid option!");
                }
            }

            int number = Convert.ToInt32(value);

            if(number<0 || number > 3)
            {
                throw new NotInvalidProcessException("Invalid option!");
            }
        }    
    }
}
