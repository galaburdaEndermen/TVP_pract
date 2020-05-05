﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using site.Extentions;
using site.Models;

namespace site
{
    public partial class Default : System.Web.UI.Page
    {
        public Default()
        {
            this.PreLoad += Default_PreLoad;
        }


        private const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "\"" + @"C:\Users\Anton\Desktop\практика веб\proj\TVP_pract\site\site\App_Data\Database1.mdf" + "\"" + @";Integrated Security=True";
        private void Default_PreLoad(object sender, EventArgs e)
        {
            List<PictureModel> images = new List<PictureModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Images";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string filename = reader.GetString(1);
                    string picturename = reader.GetString(2);
                    string desc = reader.GetString(3);
                    byte[] data = (byte[])reader.GetValue(4);

                    PictureModel image = new PictureModel(id, data, filename, picturename, desc);
                    images.Add(image);
                }
            }


            HtmlGenericControl maindiv = (HtmlGenericControl)(FindControlRecursive(Page, "maindiv"));

            for (int i = 0; i < images.Count; i+= 3)
            {
                HtmlGenericControl container = new HtmlGenericControl("div");
                container.Attributes["class"] = "container";

                container.Controls.Add(MakeNewHoverCard(images[i]));
                container.Controls.Add(MakeNewHoverCard(images[i+1]));
                container.Controls.Add(MakeNewHoverCard(images[i+2]));
                maindiv.Controls.Add(container);
            }



            //HtmlGenericControl container = new HtmlGenericControl("div");
            //container.Attributes["class"] = "container";

            //container.Controls.Add(MakeNewHoverCard(@"pictures\test3.jpg", "testing test just for test, you know, test is realy important"));
            //container.Controls.Add(MakeNewHoverCard(@"pictures\test3.jpg", "testing test just for test, you know, test is realy important"));
            //container.Controls.Add(MakeNewHoverCard(@"pictures\test3.jpg", "testing test just for test, you know, test is realy important"));



            //HtmlGenericControl container2 = new HtmlGenericControl("div");
            //container2.Attributes["class"] = "container";

            //container2.Controls.Add(MakeNewHoverCard(@"pictures\test3.jpg", "testing test just for test, you know, test is realy important"));
            //container2.Controls.Add(MakeNewHoverCard(@"pictures\test3.jpg", "testing test just for test, you know, test is realy important"));
            //container2.Controls.Add(MakeNewHoverCard(@"pictures\test3.jpg", "testing test just for test, you know, test is realy important"));




            //maindiv.Controls.Add(container);
            //maindiv.Controls.Add(container2);

        }

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

        private Control MakeNewHoverCard(string pictureUrl, string description)
        {
            HtmlGenericControl newCard = new HtmlGenericControl("div"); // сама карточка для теста, чи добавиться вона на сторінку 
            newCard.Attributes["class"] = "card";

            HtmlGenericControl face1 = new HtmlGenericControl("div");
            face1.Attributes["class"] = "face face1";
            HtmlGenericControl face1Content = new HtmlGenericControl("div");
            face1Content.Attributes["class"] = "content";


            Image face1Img = new Image();
            face1Img.ID = "img";
            face1Img.ImageUrl = @pictureUrl;


            face1Content.Controls.Add(face1Img);
            face1.Controls.Add(face1Content);



            HtmlGenericControl face2 = new HtmlGenericControl("div");
            face2.Attributes["class"] = "face face2";
            HtmlGenericControl face2Content = new HtmlGenericControl("div");
            face2Content.Attributes["class"] = "content";
            HtmlGenericControl face2Text = new HtmlGenericControl("p");
            face2Text.InnerText = description;
            HtmlGenericControl face2Link = new HtmlGenericControl("a");
            face2Link.Attributes["href"] = "#";
            face2Link.InnerText = "Дізнатись більше";

            face2Content.Controls.Add(face2Text);
            face2Content.Controls.Add(face2Link);
            face2.Controls.Add(face2Content);


            newCard.Controls.Add(face1);
            newCard.Controls.Add(face2);

            return newCard;

        }

        private Control MakeNewHoverCard(PictureModel pic)
        {
            HtmlGenericControl newCard = new HtmlGenericControl("div");
            newCard.Attributes["class"] = "card";

            HtmlGenericControl face1 = new HtmlGenericControl("div");
            face1.Attributes["class"] = "face face1";
            HtmlGenericControl face1Content = new HtmlGenericControl("div");
            face1Content.Attributes["class"] = "content";


            //HtmlGenericControl face1Img = new HtmlGenericControl("img");



            //string fileType = pic.FileName.Substring(pic.FileName.IndexOf('.')).Filtre(' ');
            //string src = "data:image/" + fileType + ";base64," + Convert.ToBase64String(pic.ImageData);
            //face1Content.Attributes["src"] = src;

            
            try
            {
                using (System.IO.FileStream fs = new System.IO.FileStream(@"F:\" + pic.FileName, FileMode.OpenOrCreate))
                {
                    fs.Write(pic.ImageData, 0, pic.ImageData.Length);
                }
            }
            catch (Exception e)
            {

               
            }

            Image face1Img = new Image();
            face1Img.ID = "img";
            face1Img.ImageUrl = @"F:\" + pic.FileName;


            face1Content.Controls.Add(face1Img);
            face1.Controls.Add(face1Content);



            HtmlGenericControl face2 = new HtmlGenericControl("div");
            face2.Attributes["class"] = "face face2";
            HtmlGenericControl face2Content = new HtmlGenericControl("div");
            face2Content.Attributes["class"] = "content";
            HtmlGenericControl face2Text = new HtmlGenericControl("p");
            face2Text.InnerText = pic.Description;
            HtmlGenericControl face2Link = new HtmlGenericControl("a");
            face2Link.Attributes["href"] = "#";
            face2Link.InnerText = "Дізнатись більше";

            face2Content.Controls.Add(face2Text);
            face2Content.Controls.Add(face2Link);
            face2.Controls.Add(face2Content);


            newCard.Controls.Add(face1);
            newCard.Controls.Add(face2);

            return newCard;

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            //HtmlGenericControl maindiv = (HtmlGenericControl)(FindControlRecursive(Page, "maindiv"));

            //HtmlGenericControl container = new HtmlGenericControl("div");
            //container.Attributes["class"] = "container";

            //container.Controls.Add(MakeNewHoverCard(@"pictures\test3.jpg", "testing test just for test, you know, test is realy important"));
            //container.Controls.Add(MakeNewHoverCard(@"pictures\test3.jpg", "testing test just for test, you know, test is realy important"));
            //container.Controls.Add(MakeNewHoverCard(@"pictures\test3.jpg", "testing test just for test, you know, test is realy important"));



            //HtmlGenericControl container2 = new HtmlGenericControl("div");
            //container2.Attributes["class"] = "container";

            //container2.Controls.Add(MakeNewHoverCard(@"pictures\test3.jpg", "testing test just for test, you know, test is realy important"));
            //container2.Controls.Add(MakeNewHoverCard(@"pictures\test3.jpg", "testing test just for test, you know, test is realy important"));
            //container2.Controls.Add(MakeNewHoverCard(@"pictures\test3.jpg", "testing test just for test, you know, test is realy important"));




            //maindiv.Controls.Add(container);
            //maindiv.Controls.Add(container2);
           




            //HtmlGenericControl maindiv = (HtmlGenericControl)(FindControlRecursive(Page, "maindiv"));
            //maindiv.Controls.Add(MakeNewHoverCard(@"pictures\test3.jpg", "testing test just for test, you know, test is realy important"));
            //maindiv.Controls.Add(MakeNewHoverCard(@"pictures\test3.jpg", "testing test just for test, you know, test is realy important"));
            //maindiv.Controls.Add(MakeNewHoverCard(@"pictures\test3.jpg", "testing test just for test, you know, test is realy important"));
            //maindiv.Controls.Add(MakeNewHoverCard(@"pictures\test3.jpg", "testing test just for test, you know, test is realy important"));
            //maindiv.Controls.Add(MakeNewHoverCard(@"pictures\test3.jpg", "testing test just for test, you know, test is realy important"));
            //maindiv.Controls.Add(MakeNewHoverCard(@"pictures\test3.jpg", "testing test just for test, you know, test is realy important"));
            //maindiv.Controls.Add(MakeNewHoverCard(@"pictures\test3.jpg", "testing test just for test, you know, test is realy important"));
            //maindiv.Controls.Add(MakeNewHoverCard(@"pictures\test3.jpg", "testing test just for test, you know, test is realy important"));





            //maincontainer.Controls.Add(MakeNewHoverCard(@"pictures\test3.jpg", "testing test just for test, you know, test is realy important"));//поладить баг з багатьма ховерами


            //https://issue.life/questions/36741781
            //https://progi.pro/aspnet-htmlgenericcontrol-div-obnovit-10253159
            //https://docs.microsoft.com/en-us/dotnet/api/system.web.ui.page.findcontrol?view=netframework-4.8
        }
    }
}