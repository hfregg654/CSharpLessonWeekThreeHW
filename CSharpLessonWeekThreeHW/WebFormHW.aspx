<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormHW.aspx.cs" Inherits="CSharpLessonWeekTwoHW.WebFormHW" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList runat="server" ID="DropDownList1" >
                <asp:ListItem Text="Users資料表" Value="Users" />
                <asp:ListItem Text="Projects資料表" Value="Projects" />
            </asp:DropDownList>
             <asp:DropDownList runat="server" ID="DropDownList2"  >
                <asp:ListItem Text="插入" Value="Insert" />
                <asp:ListItem Text="更新" Value="Update" />
                <asp:ListItem Text="刪除" Value="Delete" />
            </asp:DropDownList><asp:Button Text="更換目標" runat="server" ID="Button1" OnClick="Button1_Click" /><br />
           <asp:RadioButtonList runat="server" ID="RadioButtonList1" Visible="false">
                
            </asp:RadioButtonList>
            <asp:Label Text="" runat="server" ID="Labell" /><asp:TextBox runat="server" ID="Text1" Visible="False" /><br />
            <asp:Label Text="" runat="server" ID="Label2" /><asp:TextBox runat="server" ID="Text2" Visible="False"/><br />
            <asp:Label Text="" runat="server" ID="Label3" /><asp:TextBox runat="server" ID="Text3" Visible="False"/><br />
            <asp:Label Text="" runat="server" ID="Label4" /><asp:TextBox runat="server" ID="Text4" Visible="False"/><br />
            <asp:Label Text="" runat="server" ID="Label5" /><asp:TextBox runat="server" ID="Text5" Visible="False"/><br />
            <asp:Label Text="" runat="server" ID="Label6" /><asp:TextBox runat="server" ID="Text6" Visible="False"/><br />
            
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button Text="text" runat="server" ID="Button2" Visible="false" OnClick="Button2_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button Text="查詢Users資料表" runat="server" OnClick="Unnamed1_Click" />
            <asp:Button Text="查詢Projects資料表" runat="server" OnClick="Unnamed2_Click" />


            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
