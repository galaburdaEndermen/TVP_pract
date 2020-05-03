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

        private Control FindControlRecursive(Control rootControl, string controlID)
        {
            if (rootControl.ID == controlID) return rootControl;

            foreach (Control controlToSearch in rootControl.Controls)
            {
                Control controlToReturn = FindControlRecursive(controlToSearch, controlID);
                if (controlToReturn != null) return controlToReturn;
            }
            return null;

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlGenericControl testCard = new HtmlGenericControl("div"); // сама карточка для теста, чи добавиться вона на сторінку 
            testCard.Attributes["class"] = "card";

            HtmlGenericControl face1 = new HtmlGenericControl("div");
            face1.Attributes["class"] = "face face1";
            HtmlGenericControl face1Content = new HtmlGenericControl("div");
            face1Content.Attributes["class"] = "content";

            //HtmlGenericControl face1Img = new HtmlGenericControl("img");
            //face1Img.Attributes["src"] = "pictures\test3.jpg";
            Image face1Img = new Image();
            face1Img.ID = "img";
            face1Img.ImageUrl = @"pictures\test3.jpg";
 

            face1Content.Controls.Add(face1Img);
            face1.Controls.Add(face1Content);



            HtmlGenericControl face2 = new HtmlGenericControl("div");
            face2.Attributes["class"] = "face face2";
            HtmlGenericControl face2Content = new HtmlGenericControl("div");
            face2Content.Attributes["class"] = "content";
            HtmlGenericControl face2Text = new HtmlGenericControl("p");
            face2Text.InnerText = "testing test just for test, you know, test is realy important";
            HtmlGenericControl face2Link = new HtmlGenericControl("a");
            face2Link.Attributes["href"] = "#";
            face2Link.InnerText = "LINK";

            face2Content.Controls.Add(face2Text);
            face2Content.Controls.Add(face2Link);
            face2.Controls.Add(face2Content);


            testCard.Controls.Add(face1);
            testCard.Controls.Add(face2);


            //var sas = Page.FindControl("kek");
            
            var sas = FindControlRecursive(Page, "kek");


            HtmlGenericControl maincontainer = (HtmlGenericControl)sas;
            maincontainer.Controls.Add(testCard);
        //maincontainer.Controls.Add()



        //https://issue.life/questions/36741781
        //https://progi.pro/aspnet-htmlgenericcontrol-div-obnovit-10253159
        //https://docs.microsoft.com/en-us/dotnet/api/system.web.ui.page.findcontrol?view=netframework-4.8
        }
    }
}