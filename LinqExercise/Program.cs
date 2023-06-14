using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            var sum = numbers.Sum();
            Console.WriteLine(sum);
            //TODO: Print the Average of numbers
            var avarage = numbers.Average();
            Console.WriteLine(avarage);
            //TODO: Order numbers in ascending order and print to the console
            var Ascend = numbers.OrderBy(n => n);
            foreach(var num in Ascend)
            {
                Console.WriteLine(num);
            }
            //TODO: Order numbers in descending order and print to the console
            var Decrease = numbers.OrderByDescending(n => n);
            foreach (var num in Decrease)
            {
                Console.WriteLine(num);
            }
            //TODO: Print to the console only the numbers greater than 6
            var MoreThan = numbers.Where(n => n >= 6);
            foreach (var num in MoreThan)
            {
                Console.WriteLine(num);
            }
            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            var orderedNumbers = numbers.OrderBy(n => n); 

            int count = 0;
            foreach (var number in orderedNumbers)
            {
                if (count < 4)
                {
                    Console.WriteLine(number);
                    count++;
                }
                else
                {
                    break;
                }
            }
            //TODO: Change the value at index 4 to your age, then print the numbers in descending order

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            var filteredEmployees = employees.Where(person => person.FirstName.StartsWith('C') || person.FirstName.StartsWith('S')).OrderBy(person => person.FirstName);
            
            foreach( var employee in filteredEmployees)
            {
                Console.WriteLine(employee.FullName);
            }

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var AgeList = employees.Where(person => person.Age > 26)
                .OrderBy(person => person.Age).ThenBy(person => person.FirstName);
            Console.WriteLine("over 26");
            foreach (var item in AgeList)
            {
                Console.WriteLine($"Full name: {item.FullName} persons Age: {item.Age}");
            }
            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var SumandAvg = employees.Where(emp => emp.YearsOfExperience <= 10 && emp.Age > 35);
            Console.WriteLine($"Sum: {SumandAvg.Sum(emp => emp.YearsOfExperience)} \naverage: {SumandAvg.Average(emp => emp.YearsOfExperience)}");
            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("John", "Wall", 45, 23)).ToList();
            foreach (var emp in employees)
            {
                Console.WriteLine($" {emp.FirstName} {emp.Age}");
            }
            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
