using site.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace site
{
    public partial class Gallery : System.Web.UI.Page
    {

        private const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "\"" + @"C:\Users\Anton\Desktop\практика веб\proj\TVP_pract\site\site\App_Data\Database1.mdf" + "\"" + @";Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Picture"] != null)
            {
                //тут реалізувать загрузку бд і показ картінки

                List<PictureModel> images = new List<PictureModel>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    //string sql = "SELECT * FROM Images WHERE PictureName = ’" + Request.QueryString["Picture"].ToString() +  "’";
                    string sql = "SELECT * FROM Images WHERE PictureName = @PictureName";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.Add("@PictureName", SqlDbType.NVarChar, 50).Value = Request.QueryString["Picture"].ToString();
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

                    HtmlGenericControl maindiv = (HtmlGenericControl)(FindControlRecursive(Page, "maindiv"));

                    HtmlGenericControl container = new HtmlGenericControl("div");
                    HtmlGenericControl container = new HtmlGenericControl("div");
                    container.Attributes["class"] = "container";

                    foreach (PictureModel item in images)
                    {
                        container.Controls.Add(MakeNewHoverCard(item));
                    }
                    maindiv.Controls.Add(container);
                    


                }

            }
            else
            {
                //тут чо робить, єслі нема такого
            }
        }


        private Control MakeNewHoverCard(PictureModel pic)
        {
            HtmlGenericControl newCard = new HtmlGenericControl("div");
            newCard.Attributes["class"] = "card";

            HtmlGenericControl face1 = new HtmlGenericControl("div");
            face1.Attributes["class"] = "face face1";
            HtmlGenericControl face1Content = new HtmlGenericControl("div");
            face1Content.Attributes["class"] = "content";
            try
            {
                using (System.IO.FileStream fs = new System.IO.FileStream(@"C:\Users\Anton\Desktop\практика веб\proj\TVP_pract\site\site\pictures\" + pic.FileName, FileMode.OpenOrCreate))
                {
                    fs.Write(pic.ImageData, 0, pic.ImageData.Length);
                }
            }
            catch (Exception e)
            {


            }

            Image face1Img = new Image();
            face1Img.ID = "img";
            face1Img.ImageUrl = @"pictures\" + pic.FileName;


            face1Content.Controls.Add(face1Img);
            face1.Controls.Add(face1Content);



            HtmlGenericControl face2 = new HtmlGenericControl("div");
            face2.Attributes["class"] = "face face2";
            HtmlGenericControl face2Content = new HtmlGenericControl("div");
            face2Content.Attributes["class"] = "content";
            HtmlGenericControl face2Text = new HtmlGenericControl("p");
            face2Text.InnerText = pic.PictureName;
            //face2Text.InnerText = "testing test just for test, you know, test is realy important";
            HtmlGenericControl face2Link = new HtmlGenericControl("a");
            face2Link.Attributes["href"] = "Gallery.aspx?Picture=" + pic.PictureName;
            //"Default1.aspx?Login=" + Login.Text + "&Password=" + Password.Text //приклад
            face2Link.InnerText = "Дізнатись більше";

            face2Content.Controls.Add(face2Text);
            face2Content.Controls.Add(face2Link);
            face2.Controls.Add(face2Content);


            newCard.Controls.Add(face1);
            newCard.Controls.Add(face2);

            return newCard;

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

    }
}