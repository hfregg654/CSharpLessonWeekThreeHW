<%@ Page Title="" Language="C#" MasterPageFile="~/MCut.Master" AutoEventWireup="true" CodeBehind="WeekThreeHW.aspx.cs" Inherits="CSharpLessonWeekThreeHW.WeekThreeHW" %>

<%@ Register Src="~/Twotable.ascx" TagPrefix="uc1" TagName="Twotable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Twotable runat="server" id="Twotable" />
</asp:Content>
