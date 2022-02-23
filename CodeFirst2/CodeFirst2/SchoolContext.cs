using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst2
{
    internal class SchoolContext : DbContext
    {
        public SchoolContext() : base()
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

    }
}
/*
  It derives from DBContext class and exposes DbSet properties for the types that you want to be part of the model, e.g. Student and Grade classes in this case. 
The DbSet is a collection of entity classes (aka entity set), so we have given the property name as the plural of entity name like Students and Grades.
 */