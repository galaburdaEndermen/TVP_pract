using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBfiller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static byte[] imageData;
        private static string shortFileName;
        private static string description;
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            fileNameTB.Text = filename;

            shortFileName = filename.Substring(filename.LastIndexOf('\\') + 1);


            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                imageData = new byte[fs.Length];
                fs.Read(imageData, 0, imageData.Length);
            }

            description = pictureNameTB.Text;

            //string data = "";
            //foreach (byte item in imageData)
            //{
            //    data += item;
            //}
            //var sas = Convert.ToBase64String(imageData);
            //MessageBox.Show(Convert.ToBase64String(imageData));
        }

        private const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + "\"" + @"C:\Users\Anton\Desktop\практика веб\proj\TVP_pract\site\site\App_Data\Database1.mdf" + "\"" + @";Integrated Security=True";
        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = @"INSERT INTO Images VALUES (@FileName, @FileDesc, @Image)";
                command.Parameters.Add("@FileName", SqlDbType.NVarChar, 50);
                command.Parameters.Add("@FileDesc", SqlDbType.NVarChar, 50);
                command.Parameters.Add("@Image", SqlDbType.Image, 1000000);

               
                // передаем данные в команду через параметры
                command.Parameters["@FileName"].Value = shortFileName;
                command.Parameters["@FileDesc"].Value = description;
                command.Parameters["@Image"].Value = imageData;

                command.ExecuteNonQuery();
            }
        }
    }
}
