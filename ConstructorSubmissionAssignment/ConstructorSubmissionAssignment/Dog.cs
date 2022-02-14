using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorSubmissionAssignment
{
    public class Dog
    {
        public Dog(string prefix, string name)//constructor constructs a pet name upon instantiation of class object (e.g. Mr Scruffy)
        {
            Prefix = prefix;
            Name = name;
        }
        public Dog(string name) : this("Mr. ", name) //here we have name as the 2nd parameter, but for the 1st parameter he have set prefix to "Mr. " by default
        {
        }
        public string Prefix { get; set; }//prefix property
        public string Name { get; set; }//nbame property
    }
}
