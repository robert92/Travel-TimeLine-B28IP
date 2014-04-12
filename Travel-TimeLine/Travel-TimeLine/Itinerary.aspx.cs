using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Travel_TimeLine
{
    public partial class Intinerary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String itineraryId = Request.QueryString["id"];

            if (itineraryId == null || itineraryId == "")
                HttpContext.Current.Response.Redirect("Default.aspx");

            SqlConnection dbCon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Travel-TimeLine-Database.mdf;Integrated Security=True");
            SqlConnection dbCon2 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Travel-TimeLine-Database.mdf;Integrated Security=True");
            SqlConnection dbCon3 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Travel-TimeLine-Database.mdf;Integrated Security=True");
            dbCon.Open();
            dbCon2.Open();
            dbCon3.Open();

            SqlCommand sqlCom = new SqlCommand("select * from Itineraries where itinerary_id=" + Int32.Parse(itineraryId), dbCon);
            SqlDataReader reader = sqlCom.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                Logo.ImageUrl = "Images/" + reader.GetString(4);
                String start = "" + reader.GetDateTime(2).Day + "." + reader.GetDateTime(2).Month + "." + reader.GetDateTime(2).Year;
                String end = "" + reader.GetDateTime(3).Day + "." + reader.GetDateTime(3).Month + "." + reader.GetDateTime(3).Year;
                itineraryDate.Text = start + "|" + end;
                double score = (double)reader.GetValue(5);
                if (score < 1)
                {
                    Image1.Visible = true;
                    Image1.ImageUrl = "Images/stars_half.png";
                }
                if (score >= 1 && score < 1.5)
                    Image1.Visible = true;
                if (score >= 1.5 && score < 2)
                {
                    Image1.Visible = true;
                    Image2.Visible = true;
                    Image2.ImageUrl = "Images/stars_half.png";
                }
                if (score >= 2 && score < 2.5)
                {
                    Image1.Visible = true;
                    Image2.Visible = true;
                }
                if (score >= 2.5 && score < 3)
                {
                    Image1.Visible = true;
                    Image2.Visible = true;
                    Image3.Visible = true;
                    Image3.ImageUrl = "Images/stars_half.png";
                }
                if (score >= 3 && score < 3.5)
                {
                    Image1.Visible = true;
                    Image2.Visible = true;
                    Image3.Visible = true;
                }
                if (score >= 3.5 && score < 4)
                {
                    Image1.Visible = true;
                    Image2.Visible = true;
                    Image3.Visible = true;
                    Image4.Visible = true;
                    Image4.ImageUrl = "Images/stars_half.png";
                }
                if (score >= 4 && score < 4.5)
                {
                    Image1.Visible = true;
                    Image2.Visible = true;
                    Image3.Visible = true;
                    Image4.Visible = true;
                }
                if (score >= 4.5 && score < 5)
                {
                    Image1.Visible = true;
                    Image2.Visible = true;
                    Image3.Visible = true;
                    Image4.Visible = true;
                    Image5.Visible = true;
                    Image5.ImageUrl = "Images/stars_half.png";
                }
                if (score == 5)
                {
                    Image1.Visible = true;
                    Image2.Visible = true;
                    Image3.Visible = true;
                    Image4.Visible = true;
                    Image5.Visible = true;
                }
            }

            reader.Close();
            sqlCom = new SqlCommand("select Tags.name from Itineraries join Itinerarytags on Itineraries.itinerary_id=Itinerarytags.itinerary_id join Tags on Itinerarytags.tag_id=Tags.tag_id", dbCon);
            reader = sqlCom.ExecuteReader();

            if (reader.HasRows)
            {
                tagsList.Text = "";

                while (reader.Read())
                {
                    tagsList.Text += " " + reader.GetString(0);
                }
            }

            reader.Close();
            sqlCom = new SqlCommand("select * from Commentlink join Comments on Commentlink.comment_id=Comments.comment_id where Commentlink.itinerary_id=" + Int32.Parse(itineraryId) + " and Commentlink.reply=" + 0, dbCon);
            reader = sqlCom.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    SqlCommand sqlCom3 = new SqlCommand("select avatar from Users where user_name='" + reader.GetString(1) + "'", dbCon3);
                    SqlDataReader reader3 = sqlCom3.ExecuteReader();
                    Image avatar = new Image();
                    if (reader3.HasRows)
                    {
                        reader3.Read();
                        avatar.ImageUrl = "Images/" + reader3.GetString(0);
                    }
                    else
                        avatar.ImageUrl = "Images/default/def.png";
                    reader3.Close();
                    avatar.Width = 100;
                    avatar.Height = 100;
                    PanelComments.Controls.Add(avatar);

                    TextBox comment = new TextBox();
                    comment.Text = reader.GetString(6);
                    comment.ReadOnly = true;
                    comment.Width = 450;
                    comment.Height = 100;
                    comment.TextMode = TextBoxMode.MultiLine;
                    PanelComments.Controls.Add(comment);

                    Panel replyPanel = new Panel();
                    replyPanel.HorizontalAlign = HorizontalAlign.Right;
                    replyPanel.Width = 500;

                    int idComm = reader.GetInt32(5);
                    SqlCommand sqlCom2 = new SqlCommand("select * from Commentlink join Comments on Commentlink.comment_id=Comments.comment_id where Commentlink.reply=" + idComm, dbCon2);
                    SqlDataReader reader2 = sqlCom2.ExecuteReader();
                    if (reader2.HasRows)
                    {
                        while (reader2.Read())
                        {
                            sqlCom3 = new SqlCommand("select avatar from Users where user_name='" + reader.GetString(1) + "'", dbCon3);
                            reader3 = sqlCom3.ExecuteReader();
                            Image avatar2 = new Image();
                            if (reader3.HasRows)
                            {
                                reader3.Read();
                                avatar2.ImageUrl = "Images/" + reader3.GetString(0);
                            }
                            else
                                avatar2.ImageUrl = "Images/default/def.png";
                            reader3.Close();
                            avatar2.Width = 50;
                            avatar2.Height = 50;
                            replyPanel.Controls.Add(avatar2);

                            TextBox reply = new TextBox();
                            reply.Text = reader2.GetString(6);
                            reply.Width = 350;
                            reply.Height = 50;
                            reply.ReadOnly = true;
                            reply.TextMode = TextBoxMode.MultiLine;
                            replyPanel.Controls.Add(reply);
                            reader3.Close();
                        }
                    }
                    reader2.Close();

                    TextBox addReplyTB = new TextBox();
                    addReplyTB.Width = 350;
                    addReplyTB.Height = 50;
                    Button buttonReply = new Button();
                    buttonReply.Text = "Add";
                    buttonReply.Width = 50;
                    buttonReply.OnClientClick = "addReply(" + idComm + ")";
                    replyPanel.Controls.Add(addReplyTB);
                    replyPanel.Controls.Add(buttonReply);

                    PanelComments.Controls.Add(replyPanel);
                }
            }

            reader.Close();
            sqlCom = new SqlCommand("select * from Events join Itineraryevents on Events.event_id = Itineraryevents.event_id where Itineraryevents.itinerary_id=" + Int32.Parse(itineraryId), dbCon);
            reader = sqlCom.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    eventsHidden.Text += "" + reader.GetInt32(0) + "|" + reader.GetString(1) + "|" + reader.GetString(2) + "|" + (reader.GetDateTime(3).Day + "." + reader.GetDateTime(3).Month + "." + reader.GetDateTime(3).Year) + "|" + reader.GetString(4) + "|" + reader.GetString(5) + "||";
                }

                eventsHidden.Text = eventsHidden.Text.Substring(0, eventsHidden.Text.Length - 1);
            }

            reader.Close();
            dbCon.Close();
            dbCon2.Close();
            dbCon3.Close();
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

                HttpContext.Current.Response.Redirect("Itinerary.aspx");
            }
            else
            {
                Literal1.Visible = true;
            }
            sqlReader.Close();
            sqlSource.Close();
        }

        protected void register(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Redirect("Inregistrare.aspx");
        }

        protected void addTagPanel(object sender, EventArgs e)
        {
            PanelTag.Visible = true;
        }

        protected void addTag(object sender, EventArgs e)
        {
            String itineraryId = Request.QueryString["id"];
            int idTag = 0;
            SqlConnection dbCon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Travel-TimeLine-Database.mdf;Integrated Security=True");
            dbCon.Open();
            SqlCommand sqlCom = new SqlCommand("select * from Tags where name='" + tagName.Text + "'", dbCon);
            SqlDataReader reader = sqlCom.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                idTag = reader.GetInt32(0);
            }
            reader.Close();
            if (idTag == 0)
            {
                sqlCom = new SqlCommand("insert into Tags(name) values('" + tagName.Text + "')", dbCon);
                sqlCom.ExecuteNonQuery();

                sqlCom = new SqlCommand("select * from Tags where name='" + tagName.Text +"'", dbCon);
                reader = sqlCom.ExecuteReader();
                reader.Read();
                idTag = reader.GetInt32(0);
                reader.Close();
            }
                
            sqlCom = new SqlCommand("insert into Itinerarytags(itinerary_id, tag_id) values(" + itineraryId + ", " + idTag + ")", dbCon);
            sqlCom.ExecuteNonQuery(); 
            dbCon.Close();
            tagsList.Text += " " + tagName.Text;
            PanelTag.Visible = false;
        }

        protected void addReply(int p)
        {
            int c = p;
        }

        protected void addComment(object sender, EventArgs e)
        {
            SqlConnection dbCon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Travel-TimeLine-Database.mdf;Integrated Security=True");
            dbCon.Open();

            SqlCommand sqlCom = new SqlCommand("insert into Comments (content) output Inserted.comment_id values ( '" + addCommentTextbox.Text + "' )", dbCon);
            SqlDataReader reader = sqlCom.ExecuteReader();

            reader.Read();
            int idCom = reader.GetInt32(0);
            reader.Close();
            String itineraryId = Request.QueryString["id"];

            sqlCom = new SqlCommand("insert into Commentlink(user_name, itinerary_id, comment_id, reply) values('" + (String)Page.Session["username"] + "', " + Int32.Parse(itineraryId) + ", " + idCom + ", 0)", dbCon);
            sqlCom.ExecuteNonQuery();

            sqlCom = new SqlCommand("select avatar from Users where user_name='" + (String)Page.Session["username"] + "'", dbCon);
            SqlDataReader reader3 = sqlCom.ExecuteReader();
            Image avatar = new Image();
            if (reader3.HasRows)
            {
                reader3.Read();
                avatar.ImageUrl = "Images/" + reader3.GetString(0);
            }
            else
                avatar.ImageUrl = "Images/default/def.png";
            reader3.Close();
            PanelComments.Controls.AddAt(0, avatar);

            TextBox comment = new TextBox();
            comment.Text = addCommentTextbox.Text;
            comment.ReadOnly = true;
            comment.Width = 450;
            comment.Height = 100;
            comment.TextMode = TextBoxMode.MultiLine;
            PanelComments.Controls.AddAt(1, comment);

            dbCon.Close();
        }
    }
}