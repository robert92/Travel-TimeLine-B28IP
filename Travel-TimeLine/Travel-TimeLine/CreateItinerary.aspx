<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateItinerary.aspx.cs" Inherits="Travel_TimeLine.CreateItinerary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            margin-bottom: 0px;
        }
        .auto-style2 {
            font-size: large;
        }
        .auto-style3 {
            width: 70px;
            text-align: right;
        }
        .auto-style4 {
            color: #000000;
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
         <span class="auto-style2">
    <br />
    <span class="auto-style4"><strong>Create New Itinerary:</strong></span></span><br />
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">Name:</td>
                <td>
                    <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Start date:</td>
                <td>
                    <asp:TextBox ID="TextBoxStartDate" runat="server"></asp:TextBox>
                    <br />
                    <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">End date:</td>
                <td>
                    <asp:TextBox ID="TextBoxEndDate" runat="server"></asp:TextBox>
                    <br />
                    <asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Logo:</td>
                <td>&nbsp;<asp:Image ID="Image1" runat="server" Height="100px" style="margin-top: 0px; text-align: justify;" Width="100px" ImageUrl="Images/poza1.png"/>
&nbsp;<asp:Button ID="Button_Upload" runat="server" Height="34px" Text="Upload" Width="114px" OnClick="Button_Upload_Click" />
                    <br />
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="Button_Add_Newitinerary" runat="server" Text="Add" Width="200px" OnClick="Button_Add_Click" />
    
    <% } %>
            
        </div>
    </section>
    
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
</asp:Content>

       
