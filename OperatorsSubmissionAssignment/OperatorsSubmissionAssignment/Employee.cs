using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorsSubmissionAssignment
{
    public class Employee : Person//this class, Employee, inherits from parent class Person: it will have all of Person's methods and properties.
    {

        public int Id { get; set; }//a property peculiar to the Employee class

        //OVERLOADING == REQUIRES 4 OVERLOADS / CODE BLOCK STEPS: 1) == overload, 2) != overload, 3) Equals overload, 4) GetHashCode overload

        //1
        public static bool operator ==(Employee employee1, Employee employee2)//we're adding a game and we're adding a player, and it's returning a game with that player added
        {
            bool isEqual = employee1.Id == employee2.Id;//compares the Id attributes of two employees for equality and returns True or False boolean values
            return isEqual;//returns a boolean
        }
        //2
        public static bool operator !=(Employee employee1, Employee employee2)//C# required that I create a counterpart overload operator method to '==', meaning I had to make one for '!='
        {
            bool isEqual = employee1.Id != employee2.Id;//compares the Id attributes of two employees for inequality and returns True or False boolean values
            return isEqual;//returns a boolean
        }
        //3
        public override bool Equals(object o)//overloading == also requires you to overload Equals
        {
            if (!(o is Employee))//if object is not of Employee class then comparison would be false
                return false;
            return this == (Employee)o;//seems to say if object being compared to Employee class is of Employee class then comparison would be true (my deduction)
        }
        //4
        public override int GetHashCode()//this line of code was necessary as well to implement overloading the == operator
        {
            return 0;//this tells this hash function to always return 0, indicating that two objects compared are the same (this is my deduction) when using our overloaded == or !=
            //because by default this hash method is run on objects when they're compared to see if the hash values match (i.e. the location pointers are equal)...we don't want that
        }
    }
}

//WHY 4 Steps just to overload == ?
/*When you overload == so you can compare object attributes, you fundamentally change how == operates within .Net framework.
 By default, == compares pointers to memory locations such that if you compare 2 == 2, both are identical objects and point to the same memory location and so are equal.
 Overload leads .Net to be told to compare values within objects rather than compare their memory locations. 
 If you made two employees with identical attributes, they would not normally be == because they are stored in different memory locations and this is what the == operator looks at
 Thus, to put it simply, overloading == requires a 'major overhaul' in how .Net behaves and 4 total code blocks must be written to basically tell .Net to look at object values and not pointers.

 Sources: http://www.blackwasp.co.uk/csharprelationaloverload.aspx 
https://docs.microsoft.com/en-us/dotnet/api/system.object.gethashcode?view=net-6.0
https://docs.microsoft.com/en-us/dotnet/csharp/misc/cs0661?f1url=%3FappId%3Droslyn%26k%3Dk(CS0661)
*/



