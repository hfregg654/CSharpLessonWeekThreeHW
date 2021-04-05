<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucHeaderW3HW.ascx.cs" Inherits="CSharpLessonWeekThreeHW.ucHeaderW3HW" %>
<div class="BlockArea">
    <%--<div id="Logo">--%>
    <asp:ImageButton ID="ImageButton1" runat="server" src="images/geoglo.png" href="W3HWIndex.aspx" />
    <%-- </div>--%>
    <div id="WebName">
        <h1><a href="W3HWIndex.aspx"><span>WeekThreeHomeWork</span></a></h1>
    </div>

    <div class="LogIna">
        <span>
           <a href="W3HWLogIn.aspx">登入</a>
        </span>
    </div>
</div>
