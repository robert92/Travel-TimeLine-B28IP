using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Travel_TimeLine
{
    public partial class Profile : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string id_user = Request.QueryString["id"];
            if (Page.Session["autentificat"] == null || id_user == null || id_user=="")
                return;
            SqlConnection sqlSource = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Travel-TimeLine-Database.mdf;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand("select * from users where user_name='" + id_user + "'", sqlSource);
            sqlSource.Open();
            SqlDataReader read = sqlCommand.ExecuteReader();
            if (read.HasRows == true)
            {
                read.Read();
                TextBoxFirstName.Text = read.GetString(4);
                TextBoxLastName.Text = read.GetString(5);
                TextBoxBirthdate.Text = "" + read.GetDateTime(6);
                TextBoxCountry.Text = read.GetString(7);
                Image1.ImageUrl = read.GetString(8);
            }
            sqlSource.Close();
        }
        protected void logIn(object sender, EventArgs e)
        {
            SqlConnection sqlSource = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Travel-TimeLine-Database.mdf;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand("select * from users where user_name='" + username.Text + "' and password='" + password.Text + "'", sqlSource);
            sqlSource.Open();
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();
            if (sqlReader.HasRows == true)
            {
                Literal1.Visible = false;

                sqlReader.Read();

                Page.Session["autentificat"] = true;
                Page.Session["username"] = sqlReader.GetString(1);

                HttpContext.Current.Response.Redirect("Profile.aspx");
            }
            else
            {
                Literal1.Visible = true;
            }
            sqlSource.Close();
        }

        protected void register(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Redirect("Inregistrare.aspx");
        }
        protected void Button_Sendmessage_Click(object sender, EventArgs e)
        {

        }

       

         }
}