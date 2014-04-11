using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Travel_TimeLine
{
    public partial class WriteMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Session["autentificat"] == null)
                return;
            else
            {
                string recv = Request.QueryString["receiver"];
                TextBoxRecv.Text = recv;
            }

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

                HttpContext.Current.Response.Redirect("WriteMessage.aspx");
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

        protected void Button_Send_Message_Click(object sender, EventArgs e)
        {
            string send = Request.QueryString["sender"];
            string recv = Request.QueryString["receiver"];
            TextBoxRecv.Text = recv;

            SqlConnection sqlSource = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Travel-TimeLine-Database.mdf;Integrated Security=True");
            sqlSource.Open();
            SqlCommand sqlCommand = new SqlCommand("insert into Messages(title, content, status) output Inserted.message_id values ('" + TextBoxTitle.Text + "' , '"+TextBoxContent.Text+"' , 0) ", sqlSource);
            SqlDataReader read = sqlCommand.ExecuteReader();
            read.Read();
            int id_message = read.GetInt32(0);
            read.Close();


            SqlCommand sqlCommand1 = new SqlCommand("insert into Messageslink(sender, receiver, message_id) values('" + send +"' , '"+ recv +"', " + id_message+ ") " ,sqlSource );
           

            sqlCommand1.ExecuteNonQuery();

            sqlSource.Close();

        }
    }
}