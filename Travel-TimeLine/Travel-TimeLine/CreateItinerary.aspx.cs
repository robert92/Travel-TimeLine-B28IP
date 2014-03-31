using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Travel_TimeLine
{
    public partial class CreateItinerary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

                HttpContext.Current.Response.Redirect("CreateItinerary.aspx");
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

        protected void Button_Upload_Click(object sender, EventArgs e)
        {
            
        }



     
        protected void Button_Add_Click(object sender, EventArgs e)
        {
            SqlConnection sqlSource1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Travel-TimeLine-Database.mdf;Integrated Security=True");
          
            SqlCommand sqlCommand = new SqlCommand("insert into Itineraries (name, start_date, end_date, logo, score ) values ('" + TextBoxName.Text + "' , '" + TextBoxStartDate.Text + "' , '" + TextBoxEndDate.Text + "' , '/Images/poza.png', " + float.Parse("0.0") + " ) ", sqlSource1);
            sqlSource1.Open();

            sqlCommand.ExecuteNonQuery();

            sqlSource1.Close();

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

            String luna;
            String zi;
            String an;
            String data_noua;
            

            String data1 = DateTime.Parse(Calendar1.SelectedDate.ToString()).ToString();
          
            String dataParsataStartDate = data1.Substring(0, data1.IndexOf(' '));
            zi = dataParsataStartDate.Substring(0 , 2);
            luna = dataParsataStartDate.Substring(3, 2);
            an = dataParsataStartDate.Substring(6, 4);
            data_noua = luna + '.' + zi + '.' + an;

            TextBoxStartDate.Text = "" + data_noua;
        }
        
        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            String luna;
            String zi;
            String an;
            String data_noua;

            String data2 = DateTime.Parse(Calendar2.SelectedDate.ToString()).ToString();
            String dataParsataEndDate = data2.Substring(0, data2.IndexOf(' '));
            zi = dataParsataEndDate.Substring(0, 2);
            luna = dataParsataEndDate.Substring(3, 2);
            an = dataParsataEndDate.Substring(6, 4);
            data_noua = luna + '.' + zi + '.' + an;
            TextBoxEndDate.Text = "" + data_noua;
        }

        
       
    }
}