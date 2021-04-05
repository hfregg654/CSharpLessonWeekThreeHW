<%@ Page Title="" Language="C#" MasterPageFile="~/W3HW.Master" AutoEventWireup="true" CodeBehind="W3HWLogIn.aspx.cs" Inherits="CSharpLessonWeekThreeHW.W3HWLogIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Literal ID="Literal1" runat="server" Text="帳號: "></asp:Literal>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
    <asp:Literal ID="Literal2" runat="server" Text="密碼: "></asp:Literal>
    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox><br />
    <asp:Button ID="Button1" runat="server" Text="登入" /><br />
    <asp:Button ID="Button2" runat="server" Text="註冊" /><br />
</asp:Content>
