using System;//imports the system base library for use in our code


namespace StudentDailyReport 
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("The Tech Academy");
            Console.WriteLine("Student Daily Report");

            Console.WriteLine("What is your name?");//asks name and allows user to enter it
            string userName = Console.ReadLine();

            Console.WriteLine("What course are you on?");//asks course and allows user to enter it
            string userCourse = Console.ReadLine();

            Console.WriteLine("What page number?");//asks page number and allows user to enter it
            string onPageString = Console.ReadLine();
            ushort onPageShort = Convert.ToUInt16(onPageString);//converts to short data type as pages won't exceed even a thousand on these bootcamp courses

            Console.WriteLine("Do you need help with anything? Please answer \"true\" or \"false\"");//asks if help is needed and requests answers be restricted to true or false
            string needHelpString = Console.ReadLine();
            bool needHelpBool = Convert.ToBoolean(needHelpString);//converts the string into a boolean

            Console.WriteLine("Were there any positive experiences you'd like to share? Please give specifics");//solicits user feedback 
            string userExperience = Console.ReadLine();

            Console.WriteLine("How many hours did you study today?");//asks hours studied today
            string hoursStudiedString = Console.ReadLine();
            byte hoursStudiedShort = Convert.ToByte(hoursStudiedString);//converts to byte data type as hours studied is positive-only and there's only 24 hrs in a day
            

            Console.WriteLine("Thank you for your answers. An Instructor will respond to this shortly. Have a great day!");
            Console.ReadLine();//allows above message to persist
        }
    }
}
