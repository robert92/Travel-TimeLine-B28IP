<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Travel_TimeLine._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>Travel TimeLine</h1>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
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
                <asp:Button ID="Button1" runat="server" Text="Log In" OnClick="Button1_Click"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <h3><asp:Literal ID="Literal1" runat="server" Text="Username/password invalid!" Visible="false"></asp:Literal></h3>

    <h3>Or join now!</h3>
        <asp:Button ID="Button2" runat="server" Text="Register" OnClick="Button2_Click"/>
    <% } else { %>
        
    <% } %>
</asp:Content>
