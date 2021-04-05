<%@ Page Title="" Language="C#" MasterPageFile="~/W3HW.Master" AutoEventWireup="true" CodeBehind="W3HWUserAndProject.aspx.cs" Inherits="CSharpLessonWeekThreeHW.W3HWUserAndProject" %>

<%@ Register Src="~/Twotable.ascx" TagPrefix="uc1" TagName="Twotable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Twotable runat="server" ID="Twotable" />
</asp:Content>
