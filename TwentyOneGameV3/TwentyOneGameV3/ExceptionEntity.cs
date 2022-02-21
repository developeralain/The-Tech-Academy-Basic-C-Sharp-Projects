using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOneGameV3
{
    public class ExceptionEntity
    {
        public int Id { get; set; }
        public string ExceptionType { get; set; }
        public string ExceptionMessage { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
//Typically when you read or insert to a database you have classes that map exactly to your database: you have a class that has only properties and each property corresponds to a column in 
//*the database, that way when you read a database you end up with a collection of objects each of which represents a record (Row) in the database 
// You'd do this by creating a class, such as ExceptionEntity. Entity is a word used commonly to refer to a database object like we're creating. When you refer to a class as an entity, people
//assume that that class maps exactly to the database--each property of the class maps to a column in the database
//So each property in the above entity class maps exactly to a column within our Exceptions table of our database

//In program.cs we created a program called admin that you can call at the start of our application to create a log of exceptions 