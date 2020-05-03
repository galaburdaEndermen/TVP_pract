using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace site
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlGenericControl sas = new HtmlGenericControl("div");
            sas.Attributes["class"] = "myCssClass";

        //https://issue.life/questions/36741781
        //https://progi.pro/aspnet-htmlgenericcontrol-div-obnovit-10253159
        }
    }
}