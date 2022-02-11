using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaSubmissionAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            //Below 10 lines of code instantiate 10 employee objects and initialize them with First and Last names as well as Ids.
            Employee Joe = new Employee() { Id=23, FirstName="Joe", LastName="Dirt"  };
            Employee Joeseph = new Employee() { Id = 213, FirstName = "Joe", LastName = "Schwab" };
            Employee Bob = new Employee() { Id = 13, FirstName = "Bob", LastName = "Dyllon" };
            Employee Cob = new Employee() { Id = 43, FirstName = "Cob", LastName = "Simpson" };
            Employee Sob = new Employee() { Id = 3, FirstName = "Sob", LastName = "Jefferson" };
            Employee Dob = new Employee() { Id = 113, FirstName = "Dob", LastName = "Danza" };
            Employee Fob = new Employee() { Id = 253, FirstName = "Fob", LastName = "Schwarzenagger" };
            Employee Gob = new Employee() { Id = 263, FirstName = "Gob", LastName = "Lennon" };
            Employee Nob = new Employee() { Id = 283, FirstName = "Nob", LastName = "Humphries" };
            Employee Yob = new Employee() { Id = 1123, FirstName = "Yob", LastName = "Morgan" };


            List<Employee> employees = new List<Employee>() { Joe, Joeseph, Bob, Cob, Sob, Dob, Fob, Gob, Nob, Yob };//creates a list of the above 10 employee objects

            List<Employee> employeesJoe = new List<Employee>();//creates blank list intended to capture all employees with name 'Joe' using the below embedded loops

            //STAGE1: EMBEDDED LOOPS TO PUT ONLY EMPLOYEES NAMED 'JOE' IN A NEW LIST

            ////if loop embedded within a foreach loop intended to interate through each of the 10 employee objects in the list employees and add only those with employee.FirstName = "Joe" to the 
            ////blank employeesJoe list
            //foreach (Employee employee in employees)
            //{
            //    if (employee.FirstName == "Joe")
            //    {
            //        employeesJoe.Add(employee);
            //    }
            //}


            //foreach (Employee employeeJoe in employeesJoe)//iterates through our new list to print out the names and Ids of the contained employees to verify that our above embedded loop worked
            //{
            //    Console.WriteLine(employeeJoe.FirstName + " " + employeeJoe.Id);
            //}

            //Console.Read();//keeps console open...you should see only Joe with Id 23 and Joe with Id 213 (2 employees printed)

            //END STAGE 1 


            //LAMBDA EXPRESSION: do same as above, but using lambda instead
            //employeesJoe = employees.Where(x => x.FirstName == "Joe").ToList();//lambda method adds to empty employeesJoe list the employee object elements from employees list with first name = "Joe"
            ////TL;DR employees in the employees list with FirstName = "Joe" are transferred to the employeesJoe list via this lambda function and its methods

            //foreach (Employee employeeJoe in employeesJoe)//iterates through our new list to print out the names and Ids of the contained employees to verify that our above lambda function worked
            //{
            //    Console.WriteLine(employeeJoe.FirstName + " " + employeeJoe.Id);
            //}
            //Console.Read();//you should see only Joe with Id 23 and Joe with Id 213 (2 employees printed)


            //LAMBDA EXPRESSION: make a list of employees with ID > 5
            List<Employee> employeesOverFive = new List<Employee>();//instantiates an empty list named employeesOverFive
            employeesOverFive = employees.Where(x => x.Id > 5).ToList();//lambda method adds to empty employeesOverFive list the employee object elements from employees list with Id > 5

            foreach (Employee employeeOverFive in employeesOverFive)//iterates through our new list to print out the names and Ids of the contained employees to verify that our above lambda function worked
            {
                Console.WriteLine(employeeOverFive.FirstName + " " + employeeOverFive.Id);
            }
            Console.Read();//you should see 9 employees listed as all but one out of ten have an Id > 5



        }
    }
}
