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

                List<int> ids = new List<int>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    //string sql = "SELECT * FROM Images WHERE PictureName = ’" + Request.QueryString["Picture"].ToString() +  "’";
                    //string sql = "SELECT * FROM Images WHERE Id = @id";
                    string sql = "SELECT Id FROM Images ORDER BY Id";
                    SqlCommand command = new SqlCommand(sql, connection);
                    //command.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = Request.QueryString["Picture"].ToString();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        //string filename = reader.GetString(1);
                        //string picturename = reader.GetString(2);
                        //string desc = reader.GetString(3);
                        //byte[] data = (byte[])reader.GetValue(4);

                        //PictureModel image = new PictureModel(id, data, filename, picturename, desc);
                        ids.Add(id);
                    }
                    reader.Close();

                    int currentId = int.Parse(Request.QueryString["Picture"].ToString());

                    int leftId = 0;
                    if (currentId != ids[0])
                    {
                        leftId = ids[ids.IndexOf(currentId) - 1];
                    }
                    else
                    {
                        leftId = currentId;
                    }

                    int rightId = 0;
                    if (currentId != ids[ids.Count - 1])
                    {
                        rightId = ids[ids.IndexOf(currentId) + 1];
                    }
                    else
                    {
                        rightId = currentId;
                    }

                    //получаю відкритий
                    string currentSql = "SELECT * FROM Images WHERE Id = @id";
                    SqlCommand currentCommand = new SqlCommand(currentSql, connection);
                    currentCommand.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = currentId;
                    SqlDataReader currentReader = currentCommand.ExecuteReader();


                    PictureModel image = null;
                    while (currentReader.Read())
                    {
                        int id = currentReader.GetInt32(0);
                        string filename = currentReader.GetString(1);
                        string picturename = currentReader.GetString(2);
                        string desc = currentReader.GetString(3);
                        byte[] data = (byte[])currentReader.GetValue(4);

                        image = new PictureModel(id, data, filename, picturename, desc);
                    }
                    //

                    HtmlGenericControl maindiv = (HtmlGenericControl)(FindControlRecursive(Page, "maindiv"));

                    HtmlGenericControl container = new HtmlGenericControl("div");
                    container.Attributes["class"] = "container";

                   
                    container.Controls.Add(MakeNewHoverCard(image));
                    
                    maindiv.Controls.Add(container);



                    //розпихать їх по місцям
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