using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //accepts two parameters: one of type object, a generic type that covers most anything, and a special datatype object called EventArgs
        //EventArgs: arguments include webpage info being submitted and other details re: page (WebForms handles a lot of this already) 
        protected void Button1_Click(object sender, EventArgs e)//double clicking the button in Design takes you to this
        {
            Label1.Text = TextBox1.Text;
        }
    }
}