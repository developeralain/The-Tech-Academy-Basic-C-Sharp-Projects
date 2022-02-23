using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new SchoolContext())
            {
                var stud = new Student() { StudentName = "Bill", StudentID = 123, Height = 123, Weight = 173 };

                ctx.Students.Add(stud);
                ctx.SaveChanges();

            }
            Console.WriteLine("Done.");
            Console.Read();
        }
    }
}
