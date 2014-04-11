<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WriteMessage.aspx.cs" Inherits="Travel_TimeLine.WriteMessage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 47%;
        }
        .auto-style2 {
            width: 145px;
            text-align: left;
        }
        .auto-style3 {
            width: 327px;
        }
        .auto-style4 {
            width: 47%;
        }
        .auto-style5 {
            width: 50px;
        }
        .auto-style6 {
            width: 50px;
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <% if(Page.Session["autentificat"] == null || (bool) Page.Session["autentificat"] == false) { %>
        <h3>You are not logged in !</h3>

    <asp:Table ID="Table1" runat="server">
        <asp:TableRow ID="TableRow1" runat="server">
            <asp:TableCell ID="TableCell1" runat="server">
                Username:
            </asp:TableCell>
            <asp:TableCell ID="TableCell2" runat="server">
                <asp:TextBox ID="username" runat="server"></asp:TextBox> 
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow2" runat="server">
            <asp:TableCell ID="TableCell3" runat="server">
                Password:
            </asp:TableCell>
            <asp:TableCell ID="TableCell4" runat="server">
                <asp:TextBox ID="password" runat="server"></asp:TextBox> 
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow3" runat="server">
            <asp:TableCell ID="TableCell5" runat="server">
            </asp:TableCell>
            <asp:TableCell ID="TableCell6" runat="server">
                <asp:Button ID="Button1" runat="server" Text="Log In" OnClick="logIn"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <h3><asp:Literal ID="Literal1" runat="server" Text="Username/password invalid!" Visible="false"></asp:Literal></h3>

    <h3>Or join now!</h3>
        <asp:Button ID="Button2" runat="server" Text="Register" OnClick="register"/>
    <% } else { %>


            <table class="auto-style1">
                <tr>
                    <td class="auto-style2"><strong style="text-align: right">Send message to:</strong></td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBoxRecv" runat="server" Width="260px"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br />



            <table class="auto-style4">
                <tr>
                    <td class="auto-style6"><strong>Title:</strong></td>
                    <td>
                        <asp:TextBox ID="TextBoxTitle" runat="server" Width="260px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5"><strong>Content:</strong></td>
                    <td>
                        <asp:TextBox ID="TextBoxContent" runat="server" Height="180px" Width="260px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br />



 <asp:Button ID="Button_Send_Message" runat="server" OnClick="Button_Send_Message_Click" Text="Send message" Width="155px" />
    <% } %>
           
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
</asp:Content>
