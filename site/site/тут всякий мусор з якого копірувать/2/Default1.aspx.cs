using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Default1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["Login"] != null && Request.QueryString["Password"]  != null)
            {
                if (Request.QueryString["Login"].ToString() == "ADMIN" && Request.QueryString["Password"].ToString() == "123")
                {
                    result.Text = "КРАСАВА, ЗАЛОГІНИВСЯ";
                }
                else
                {
                    result.Text = "НЄ, ФІГНЯ";
                }
            }
            else
            {
                result.Text = "НЄ, ФІГНЯ";
            }
        }
    }
}