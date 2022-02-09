using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsAndObjectsAssignment
{
    public class Employee : Person//this class, Employee, inherits from parent class Person: it will have all of Person's methods and properties.
    {
        public int Id { get; set; }//a property peculiar to the Employee class
    }
}
