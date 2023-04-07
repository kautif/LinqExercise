using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

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
            int sum = 0;
            numbers.Sum(x => {
                sum += x;
                Console.WriteLine($"Sum: {sum}");
                return sum;
            });

            //TODO: Print the Average of numbers
            double average = numbers.Average();
            Console.WriteLine($"Average: {average}");

            //TODO: Order numbers in ascending order and print to the console
            Array.Sort(numbers);
            foreach (int n in numbers) { 
                Console.WriteLine($"Ascending: {n}");
            }
            //TODO: Order numbers in decsending order and print to the console
            int[] revArray = numbers.OrderByDescending(x => x).ToArray();
            foreach (int n in revArray) {
                Console.WriteLine($"Descending: {n}");
            }

            //TODO: Print to the console only the numbers greater than 6
            var greaterThan6 = numbers.Where(n => n > 6);
            foreach (int n in greaterThan6) {
                Console.WriteLine($"nums greater than 6: {n}");
            }

            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Array.Sort(numbers);
            int count = 0;
            foreach (int n in numbers)
            {
                if (count < 4)
                {
                    Console.WriteLine($"first four: {n}");

                }
                else {
                    break;
                }
                count++;
            }


            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 36;
            int[] revAgeArr = numbers.OrderByDescending (x => x).ToArray();
            foreach (int n in revAgeArr) {
                Console.WriteLine($"revAgeArr descending: {n}");
            }

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S
            // and order this in ascending order by FirstName.
            foreach (Employee employee in employees) {
                if (employee.FirstName[0].ToString() == "C" || employee.FirstName[0].ToString() == "S") {
                    Console.WriteLine($"Starts with a C or an S?: {employee.FullName}");
                }
            }

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first
            // and then by FirstName in the same result.

            var seniorityArr = employees.Where(a => a.Age > 26).OrderByDescending(x => x.Age).ThenBy(x => x.FirstName);
            foreach (Employee employee in seniorityArr) {
                Console.WriteLine($"Oldest to Youngest employees by first name: {employee.FullName}");
            } 
            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            Employee[] yearsArr = employees.Where(a => a.YearsOfExperience <= 10 && a.Age > 35).ToArray();
            yearsArr.Sum(y => y.YearsOfExperience);
            yearsArr.Average(y => y.YearsOfExperience);
            //TODO: Add an employee to the end of the list without using employees.Add()
            Employee autif = new Employee("Autif", "Kamal", 36, 5);
            employees = employees.Append(autif).ToList();

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
