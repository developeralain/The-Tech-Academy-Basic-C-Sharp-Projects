using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathAndComparisonOperatorAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Anonymous Income Comparison Program");

            //This code takes and stores user input for hourly rate and hours worked per week for Person 1
            Console.WriteLine("Person 1\nPlease Enter Person 1 Hourly Rate");
            string person1HourlyRateString = Console.ReadLine();
            double person1HourlyRateDouble = Convert.ToDouble(person1HourlyRateString);
            Console.WriteLine("Please Enter Person 1 Hours worked per week");
            string person1HoursWorkedString = Console.ReadLine();
            double person1HoursWorkedDouble = Convert.ToDouble(person1HoursWorkedString);

            //This code takes and stores user input for hourly rate and hours worked per week for Person 2
            Console.WriteLine("Person 2\nPlease Enter Person 2 Hourly Rate");
            string person2HourlyRateString = Console.ReadLine();
            double person2HourlyRateDouble = Convert.ToDouble(person2HourlyRateString);
            Console.WriteLine("Please Enter Person 2 Hours worked per week");
            string person2HoursWorkedString = Console.ReadLine();
            double person2HoursWorkedDouble = Convert.ToDouble(person2HoursWorkedString);

            //This code calculates annual salary for both persons 1 and 2 and stores these seperately
            double person1AnnualSalary = 52 * person1HoursWorkedDouble * person1HourlyRateDouble;
            double person2AnnualSalary = 52 * person2HoursWorkedDouble * person2HourlyRateDouble;

            //This code prints out person 1 and person 2's annual salaries and determines if person 1 makes more than person 2
            Console.WriteLine("Annual Salary of Person 1:\n" + person1AnnualSalary);
            Console.WriteLine("Annual Salary of Person 2:\n" + person2AnnualSalary);
            bool salaryComparison = person1AnnualSalary > person2AnnualSalary;
            Console.WriteLine("Does Person 1 make more money than Person 2?\n" + salaryComparison);
            Console.ReadLine();







        }
    }
}
