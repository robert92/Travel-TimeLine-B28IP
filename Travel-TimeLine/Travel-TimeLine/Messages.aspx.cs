using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Travel_TimeLine
{
    public partial class Messages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection sqlSource = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Travel-TimeLine-Database.mdf;Integrated Security=True");
            sqlSource.Open();
            SqlCommand sqlCommand;
            SqlDataReader read;
            sqlCommand = new SqlCommand("select * from Messages join Messageslink on Messages.message_id=Messageslink.message_id where Messageslink.receiver='" + (String)Page.Session["username"] + "' and Messages.status=1", sqlSource);
            read = sqlCommand.ExecuteReader();
            SqlConnection sqlSource2 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Travel-TimeLine-Database.mdf;Integrated Security=True");
            sqlSource2.Open();

            if (read.HasRows)
            {
                while (read.Read())
                {
                    SqlCommand sqlCommand2 = new SqlCommand("select * from Users where user_name='" + read.GetString(5) + "'", sqlSource2);
                    SqlDataReader read2 = sqlCommand2.ExecuteReader();
                    String cale = "";

                    if (read2.HasRows)
                    {
                        read2.Read();
                        cale = read2.GetString(8);

                    }
                    read2.Close();
                    TextBox tbt = new TextBox();
                    tbt.Text = "Title: " + read.GetString(1);
                    Panel2.Controls.Add(tbt);
                    Image img = new Image();
                    img.ImageUrl = cale;
                    Panel2.Controls.Add(img);
                    TextBox tb = new TextBox();
                    tb.Text = "Content: " + read.GetString(2);
                    Panel2.Controls.Add(tb);

                }

            }
            read.Close();


            sqlCommand = new SqlCommand("select * from Messages join Messageslink on Messages.message_id=Messageslink.message_id where Messageslink.receiver='" + (String)Page.Session["username"] + "' and Messages.status=0", sqlSource);            
            read = sqlCommand.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    SqlCommand sqlCommand2 = new SqlCommand("select * from Users where user_name='" + read.GetString(5) + "'", sqlSource2);
                    SqlDataReader read2 = sqlCommand2.ExecuteReader();
                    String cale = "";
                    
                    if (read2.HasRows)
                    {
                        read2.Read();
                        cale = read2.GetString(8);

                    }
                    read2.Close();
               TextBox tbt = new TextBox();
              tbt.Text ="Title: " + read.GetString(1);
              Panel1.Controls.Add(tbt);     
                    Image img = new Image();
                    img.ImageUrl = cale;
                    Panel1.Controls.Add(img);
                    TextBox tb = new TextBox();
                    tb.Text ="Content: " + read.GetString(2);
                    Panel1.Controls.Add(tb);

                    sqlCommand2 = new SqlCommand("update Messages set status =1 where message_id= " + read.GetInt32(0), sqlSource2);
                    sqlCommand2.ExecuteNonQuery();
                }
                    
            }
            read.Close();


            


            sqlSource2.Close();
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

                HttpContext.Current.Response.Redirect("Messages.aspx");
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
    }
}