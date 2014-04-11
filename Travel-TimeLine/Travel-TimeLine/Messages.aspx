<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="Travel_TimeLine.Messages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
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

              <p>
        MY MESSAGES</p>
    <asp:Panel ID="Panel1" runat="server">
        Unread messages:<br />
        <br />
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server">
        Read messages:<br />
        <br />
    </asp:Panel>
        
    <% } %>
        </div>
    </section>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
  
</asp:Content>
