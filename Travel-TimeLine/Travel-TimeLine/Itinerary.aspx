<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Intinerary.aspx.cs" Inherits="Travel_TimeLine.Intinerary" %>
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

        <asp:Table ID="Table2" runat="server" HorizontalAlign="Center" Width="800">
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell ColumnSpan="3">
                    <asp:Image ID="Logo" runat="server" ImageUrl="Images/cover.png" ImageAlign="Middle"/>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    Tags:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Literal ID="tagsList" runat="server" Text="empty"></asp:Literal>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Image ID="Image1" runat="server" ImageUrl="Images/stars.png" Visible="false"/>
                    &nbsp<asp:Image ID="Image2" runat="server" ImageUrl="Images/stars.png" Visible="false"/>
                    &nbsp<asp:Image ID="Image3" runat="server" ImageUrl="Images/stars.png" Visible="false"/>
                    &nbsp<asp:Image ID="Image4" runat="server" ImageUrl="Images/stars.png" Visible="false"/>
                    &nbsp<asp:Image ID="Image5" runat="server" ImageUrl="Images/stars.png" Visible="false"/>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="3">
                    <asp:Button ID="Button3" runat="server" Text="+" OnClick="addTagPanel" CausesValidation="False" Width="50"/>
                    <asp:Panel ID="PanelTag" runat="server" ScrollBars="Auto" Visible="false" Width="100%" Height="45px" BackColor="Black">
                        Add tag: <asp:TextBox ID="tagName" runat="server"></asp:TextBox>&nbsp<asp:Button ID="Button4" runat="server" Text="Add tag" OnClick="addTag"/></asp:Panel>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell ColumnSpan="3">
                    <asp:Literal ID="itineraryDate" runat="server" Visible="false"></asp:Literal>
                    <asp:Literal ID="eventsHidden" runat="server" Visible="false"></asp:Literal>
                    <canvas id="timeline" width="650" height="100" onload="init" onclick="detectClick(event)"></canvas>
                    <script type="text/javascript">
                        var canvas;
                        var draw;
                        var startDate;
                        var endDate;
                        var eventsList;

                        init();

                        function detectClick(e)
                        {
                            alert((e.pageX - canvas.offsetLeft) + " " + (e.pageY - canvas.offsetTop));
                        }

                        function drawPoint(x, y)
                        {
                            draw.arc(x, y, 4, 0, 2 * Math.PI);
                            draw.arc(x, y, 3, 0, 2 * Math.PI);
                            draw.arc(x, y, 2, 0, 2 * Math.PI);
                            draw.arc(x, y, 1, 0, 2 * Math.PI);
                        }

                        function drawPointColor(x, y)
                        {
                            draw.fillStyle = "red";
                            draw.arc(x, y, 4, 0, 2 * Math.PI);
                            draw.arc(x, y, 3, 0, 2 * Math.PI);
                            draw.arc(x, y, 2, 0, 2 * Math.PI);
                            draw.arc(x, y, 1, 0, 2 * Math.PI);
                        }

                        function init()
                        {
                            canvas = document.getElementById("timeline");
                            draw = canvas.getContext("2d");

                            draw.moveTo(10, 50);
                            draw.lineTo(640, 50);
                            drawPoint(10, 50);
                            drawPoint(640, 50);
                            
                            var getEventDate = '<%= itineraryDate.Text %>';
                            var listDateEvent = getEventDate.split("|");
                            startDate = listDateEvent[0];
                            endDate = listDateEvent[1];
                            draw.fillText(startDate, 10, 25, 50);
                            draw.fillText(endDate, 590, 25, 50);

                            var getEventsList = '<%= eventsHidden.Text %>';
                            eventsList = getEventsList.split("||");
                            for (var i = 0; i < eventsList.length; i++)
                            {
                                var event = eventsList[i].split("|");
                                //alert(event);

                                var startDateInt = parseInt(startDate.substring(0, 2));
                                var endDateInt = parseInt(endDate.substring(0, 2));
                                var eventNodeDateInt = parseInt(event[3].substring(0, 2));
                                var numberPixels = (630 / (endDateInt - startDateInt));

                                drawPointColor(10 + (numberPixels * (eventNodeDateInt - startDateInt)), 50);
                            }

                            draw.stroke();
                        }
                    </script>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell ColumnSpan="3">
                    <asp:TextBox ID="addCommentTextbox" runat="server" Width="450" Height="100" TextMode="MultiLine"></asp:TextBox>
                    <br /><asp:Button ID="Button6" runat="server" Text="Add" OnClick="addComment"/>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell ColumnSpan="3">
                    <asp:Panel ID="PanelComments" runat="server" Width="600">
                    </asp:Panel>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

    <% } %>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
</asp:Content>
