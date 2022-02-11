using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaSubmissionAssignment
{
    public class Employee : Person
    {
        public int Id { get; set; }//property 1 (it also inherits, though not explicitly written, Person parent Class properties FirstName and LastName)

    }
}
