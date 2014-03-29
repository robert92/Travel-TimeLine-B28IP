using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Travel_TimeLine
{
    public partial class Inregistrare : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlSource = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\an3 sem 2\IP\Proiect\Travel-TimeLine\Travel-TimeLine\App_Data\Travel-TimeLine-Database.mdf;Integrated Security=True");
            String data = DateTime.Parse(TextBoxBirthdate.Text).ToString();
            String dataParsata = data.Substring(0, data.IndexOf(' '));
            SqlCommand sqlCommand = new SqlCommand("insert into Users values ('" + TextBoxUsername.Text + "', '" + TextBoxPassword.Text + "' , '" + TextBoxEmail.Text + "', " + float.Parse("0.0") + ", '" + TextBoxFirstName.Text + "' , '" + TextBoxLastname.Text + "', '" + dataParsata  + "', '" + DropDownListCountry.SelectedValue + "' , '/default/poza.png' ) ", sqlSource);
            sqlSource.Open();
            
            sqlCommand.ExecuteNonQuery();

            sqlSource.Close();


        }
    }
}