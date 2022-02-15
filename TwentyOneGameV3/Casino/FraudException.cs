using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class FraudException : Exception
    {
        /*We will have 2 methods in this class, both constructors and will both inherit exact same constructor from Exception
          The only reason we're creating our own exception is to catch this specific fraud-type exception : we won't do anything differently but when we catch it we know we have a fraud exception
          and we can therefore handle it differently
        */

        public FraudException()//constructor for FraudException class
            : base() { }//we'll have this constructor inherit from Exception's base() constructor (so our exception will respond to neg integer attempts the same as Exception class would)
        public FraudException(string message)//takes one argument, a string message
            : base(message) { }//inheriting from Exception's base constructor, which also takes one argument a string message

        //WHAT ARE WE DOING IN ABOVE CODE?
        /*
         We're creating two overloaded constructors that are carrying out the exact same implementation (handling of) for our FraudException as would occur if an Exception was thrown.
         You can see we are inheriting from Exception's base constructor, which carries out Exception's implementation--we are inheriting it and using it for our own FraudException class.
         What we want is to handle our very specific exception type in the exact same way Exception would; difference being that we will know it was a fraud attempt due to the name of this exception
         */
    }
}


//EXCEPTION CLASS IN C#
/*
 Exception catches ANY exception that's thrown: it is a catch-all and is an example of polymorphism as all deriving class exceptions would be caught by Exception as well.
 It is the base class for all exceptions, which all other exception classes inherit from 
 
 */
