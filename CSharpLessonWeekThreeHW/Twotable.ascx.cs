using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using CSharpLessonWeekTwoHW;
using System.Web.UI.HtmlControls;

namespace CSharpLessonWeekThreeHW
{
    public partial class Twotable : System.Web.UI.UserControl
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HiddenField1.Value = "User";
                string[] readcol = { "UserID", "Account", "Name", "Phone", "Mail", "LineID", "License", "Privilege", "CreateDate", "WhoCreate" };
                this.Repeater1.DataSource = DBTool.readTable("Users", readcol);
                this.Repeater1.DataBind();
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1.SelectedValue = "Users";
                DropDownList2.SelectedValue = "Insert";
                Button2.Text = "插入";
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            HiddenField1.Value = "User";
            string[] readcol = { "UserID", "Account", "Name", "Phone", "Mail", "LineID", "License", "Privilege", "CreateDate", "WhoCreate" };
            this.Repeater1.DataSource = DBTool.readTable("Users", readcol);
            this.Repeater1.DataBind();
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            HiddenField1.Value = "Project";
            string[] readcol = { "ProjectID", "ProjectName", "TeamID", "TeamName", "DeadLine", "CreateDate", "WhoCreate" };
            this.Repeater1.DataSource = DBTool.readTable("Projects", readcol);
            this.Repeater1.DataBind();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //HtmlGenericControl ctUser = Repeater1.FindControl("divUser") as HtmlGenericControl;
                //HtmlGenericControl ctProject = Repeater1.FindControl("divProject") as HtmlGenericControl;
                Literal lt1 = e.Item.FindControl("Literal1") as Literal;
                Literal lt2 = e.Item.FindControl("Literal2") as Literal;
                Literal lt3 = e.Item.FindControl("Literal3") as Literal;
                Literal lt4 = e.Item.FindControl("Literal4") as Literal;
                Literal lt5 = e.Item.FindControl("Literal5") as Literal;
                Literal lt6 = e.Item.FindControl("Literal6") as Literal;
                Literal lt7 = e.Item.FindControl("Literal7") as Literal;
                Literal lt8 = e.Item.FindControl("Literal8") as Literal;
                Literal lt9 = e.Item.FindControl("Literal9") as Literal;
                DataRowView drv = e.Item.DataItem as DataRowView;


                if (HiddenField1.Value == "User")
                {
                    lt1.Text = "使用者編號: ";
                    lt2.Text = "帳號: ";
                    lt3.Text = "名字: ";
                    lt4.Text = "電話號碼: ";
                    lt5.Text = "電子郵件: ";
                    lt6.Text = "LineID: ";
                    lt7.Text = "身分權限: ";
                    lt8.Visible = true;
                    lt9.Visible = true;
                    lt8.Text = "建立日期: ";
                    lt9.Text = "建立者: ";
                }
                else if (HiddenField1.Value == "Project")
                {
                    lt1.Text = "專案編號: ";
                    lt2.Text = "專案名: ";
                    lt3.Text = "負責組別: ";
                    lt4.Text = "小組名稱: ";
                    lt5.Text = "專案期限: ";
                    lt6.Text = "建立日期: ";
                    lt7.Text = "建立者: ";
                    lt8.Visible = false;
                    lt9.Visible = false;

                }
            }
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string cmdName = e.CommandName;
            string cmdArgu = e.CommandArgument.ToString();
            if (cmdName == "DeleteItem")
            {
                //刪~資~料~

            }
        }
        public void ClearTextBox()
        {
            Text1.Text = "";
            Text2.Text = "";
            Text3.Text = "";
            Text4.Text = "";
            Text5.Text = "";
            Text6.Text = "";
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Label7.Text = "";
            if (DropDownList2.SelectedValue == "Insert")
            {
                Button2.Text = "插入";
                Button2.Visible = true;
                if (DropDownList1.SelectedValue == "Users")
                {
                    ClearTextBox();
                    HiddenField1.Value = "User";
                    Text1.Visible = true;
                    Labell.Text = "授權碼: ";
                    Text2.Visible = true;
                    Label2.Text = "權限: ";
                    Text3.Visible = true;
                    Text3.TextMode = TextBoxMode.Date;
                    Label3.Text = "建立時間: ";
                    Text4.Visible = true;
                    Text5.TextMode = TextBoxMode.SingleLine;
                    Label4.Text = "建立者: ";
                    Text5.Visible = false;
                    Text5.TextMode = TextBoxMode.SingleLine;
                    Label5.Text = "";
                    Text6.Visible = false;
                    Label6.Text = "";
                    RadioButtonList1.Visible = false;
                }
                else if (DropDownList1.SelectedValue == "Projects")
                {
                    ClearTextBox();
                    HiddenField1.Value = "Project";
                    Text1.Visible = true;
                    Labell.Text = "專案名: ";
                    Text2.Visible = true;
                    Label2.Text = "小組組別: ";
                    Text3.Visible = true;
                    Text3.TextMode = TextBoxMode.SingleLine;
                    Label3.Text = "小組名稱: ";
                    Text4.Visible = true;
                    Text4.TextMode = TextBoxMode.Date;
                    Label4.Text = "時程期限: ";
                    Text5.Visible = true;
                    Text5.TextMode = TextBoxMode.Date;
                    Label5.Text = "建立時間: ";
                    Text6.Visible = true;
                    Label6.Text = "建立者: ";
                    RadioButtonList1.Visible = false;
                }
            }
            else if (DropDownList2.SelectedValue == "Update")
            {
                Button2.Text = "更新";
                Button2.Visible = true;
                if (DropDownList1.SelectedValue == "Users")
                {
                    ClearTextBox();
                    HiddenField1.Value = "User";
                    Text1.Visible = true;
                    Labell.Text = "帳號: ";
                    Text2.Visible = true;
                    Label2.Text = "姓名: ";
                    Text3.Visible = true;
                    Text3.TextMode = TextBoxMode.SingleLine;
                    Label3.Text = "電話號碼: ";
                    Text4.Visible = true;
                    Text4.TextMode = TextBoxMode.SingleLine;
                    Label4.Text = "電子郵件: ";
                    Text5.Visible = true;
                    Text5.TextMode = TextBoxMode.SingleLine;
                    Label5.Text = "LineID";
                    Text6.Visible = true;
                    Label6.Text = "欲更改之資料授權碼";
                    RadioButtonList1.Visible = false;
                }
                else if (DropDownList1.SelectedValue == "Projects")
                {
                    ClearTextBox();
                    HiddenField1.Value = "Project";
                    Text1.Visible = true;
                    Labell.Text = "專案名: ";
                    Text2.Visible = true;
                    Label2.Text = "小組組別: ";
                    Text3.Visible = true;
                    Text3.TextMode = TextBoxMode.SingleLine;
                    Label3.Text = "小組名稱: ";
                    Text4.Visible = true;
                    Text4.TextMode = TextBoxMode.Date;
                    Label4.Text = "時程期限: ";
                    Text5.Visible = true;
                    Text5.TextMode = TextBoxMode.SingleLine;
                    Label5.Text = "欲更改之專案ID";
                    Text6.Visible = false;
                    Label6.Text = "";
                    RadioButtonList1.Visible = false;
                }
            }
            else if (DropDownList2.SelectedValue == "Delete")
            {
                Button2.Text = "刪除";
                Button2.Visible = true;
                Text1.Visible = false;
                Labell.Text = "";
                Text2.Visible = false;
                Label2.Text = "";
                Text3.Visible = false;
                Label3.Text = "";
                Text4.Visible = false;
                Label4.Text = "";
                Text5.Visible = false;
                Label5.Text = "";
                Text6.Visible = false;
                Label6.Text = "";
                RadioButtonList1.Visible = true;
                this.RadioButtonList1.Items.Clear();
                if (DropDownList1.SelectedValue == "Users")
                {
                    HiddenField1.Value = "User";
                    string[] readcol = { "UserID", "Account", "Name" };
                    string wantdelete = "";
                    foreach (DataRow item in DBTool.readTable("Users", readcol).Rows)
                    {
                        wantdelete = $"ID:{item[0]}   帳號:{item[1]}    姓名:{item[2]}";
                        RadioButtonList1.Items.Add(new ListItem($"{wantdelete}", $"{item[0]}"));
                    }
                }
                else if (DropDownList1.SelectedValue == "Projects")
                {
                    HiddenField1.Value = "Project";
                    string[] readcol = { "ProjectID", "ProjectName", "TeamName" };
                    string wantdelete = "";
                    foreach (DataRow item in DBTool.readTable("Projects", readcol).Rows)
                    {
                        wantdelete = $"ID:{item[0]}   專案:{item[1]}   負責組:{item[2]}";
                        RadioButtonList1.Items.Add(new ListItem($"{wantdelete}", $"{item[0]}"));
                    }
                }
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedValue == "Insert")
            {
                if (DropDownList1.SelectedValue == "Users")
                {
                    string[] insertcol = { "License", "Privilege", "CreateDate", "WhoCreate" };
                    string[] insertcolp = { "@License", "@Privilege", "@CreateDate", "@WhoCreate" };
                    List<string> userinsert = new List<string>();
                    userinsert.Add(Text1.Text);
                    userinsert.Add(Text2.Text);
                    userinsert.Add(Text3.Text);
                    userinsert.Add(Text4.Text);
                    DBTool.InsertTable("Users", insertcol, insertcolp, userinsert);
                    Label7.Text = "插入資料完成";
                    string[] readcol = { "UserID", "Account", "Name", "Phone", "Mail", "LineID", "License", "Privilege", "CreateDate", "WhoCreate" };
                    this.Repeater1.DataSource = DBTool.readTable("Users", readcol);
                    this.Repeater1.DataBind();

                }
                else if (DropDownList1.SelectedValue == "Projects")
                {
                    string[] insertcol = { "ProjectName", "TeamID", "TeamName", "DeadLine", "CreateDate", "WhoCreate" };
                    string[] insertcolp = { "@ProjectName", "@TeamID", "@TeamName", "@DeadLine", "@CreateDate", "@WhoCreate" };
                    List<string> userinsert = new List<string>();
                    userinsert.Add(Text1.Text);
                    userinsert.Add(Text2.Text);
                    userinsert.Add(Text3.Text);
                    userinsert.Add(Text4.Text);
                    userinsert.Add(Text5.Text);
                    userinsert.Add(Text6.Text);
                    DBTool.InsertTable("Projects", insertcol, insertcolp, userinsert);
                    Label7.Text = "插入資料完成";
                    string[] readcol = { "ProjectID", "ProjectName", "TeamID", "TeamName", "DeadLine", "CreateDate", "WhoCreate" };
                    this.Repeater1.DataSource = DBTool.readTable("Projects", readcol);
                    this.Repeater1.DataBind();
                }
            }
            else if (DropDownList2.SelectedValue == "Update")
            {
                if (DropDownList1.SelectedValue == "Users")
                {
                    string[] updatecol = { "Account=@Account", "Name=@Name", "Phone=@Phone", "Mail=@Mail", "LineID=@LineID" };
                    string wherep = "License=@License";
                    string[] updatecolp = { "@Account", "@Name", "@Phone", "@Mail", "@LineID", "@License" };
                    List<string> userupdate = new List<string>();
                    userupdate.Add(Text1.Text);
                    userupdate.Add(Text2.Text);
                    userupdate.Add(Text3.Text);
                    userupdate.Add(Text4.Text);
                    userupdate.Add(Text5.Text);
                    userupdate.Add(Text6.Text);
                    DBTool.UpdateTable("Users", updatecol, wherep, updatecolp, userupdate);
                    Label7.Text = "更新資料完成";
                    string[] readcol = { "UserID", "Account", "Name", "Phone", "Mail", "LineID", "License", "Privilege", "CreateDate", "WhoCreate" };
                    this.Repeater1.DataSource = DBTool.readTable("Users", readcol);
                    this.Repeater1.DataBind();
                }
                else if (DropDownList1.SelectedValue == "Projects")
                {
                    string[] updatecol = { "ProjectName=@ProjectName", "TeamID=@TeamID", "TeamName=@TeamName", "DeadLine=@DeadLine" };
                    string wherep = "ProjectID=@ProjectID";
                    string[] updatecolp = { "@ProjectName", "@TeamID", "@TeamName", "@DeadLine", "@ProjectID" };
                    List<string> userupdate = new List<string>();
                    userupdate.Add(Text1.Text);
                    userupdate.Add(Text2.Text);
                    userupdate.Add(Text3.Text);
                    userupdate.Add(Text4.Text);
                    userupdate.Add(Text5.Text);
                    DBTool.UpdateTable("Projects", updatecol, wherep, updatecolp, userupdate);
                    Label7.Text = "更新資料完成";
                    string[] readcol = { "ProjectID", "ProjectName", "TeamID", "TeamName", "DeadLine", "CreateDate", "WhoCreate" };
                    this.Repeater1.DataSource = DBTool.readTable("Projects", readcol);
                    this.Repeater1.DataBind();
                }
            }
            else if (DropDownList2.SelectedValue == "Delete")
            {
                if (DropDownList1.SelectedValue == "Users")
                {
                    string rdbVal = this.RadioButtonList1.SelectedValue;
                    DBTool.DeleteTable("Users", "UserID", "@UserID", rdbVal);
                    string[] readcol = { "UserID", "Account", "Name", "Phone", "Mail", "LineID", "License", "Privilege", "CreateDate", "WhoCreate" };
                    this.Repeater1.DataSource = DBTool.readTable("Users", readcol);
                    this.Repeater1.DataBind();
                    this.RadioButtonList1.Items.Clear();
                    string[] readcol2 = { "UserID", "Account", "Name" };
                    string wantdelete = "";
                    foreach (DataRow item in DBTool.readTable("Users", readcol).Rows)
                    {
                        wantdelete = $"ID:{item[0]}   帳號:{item[1]}    姓名:{item[2]}";
                        RadioButtonList1.Items.Add(new ListItem($"{wantdelete}", $"{item[0]}"));
                    }

                }
                else if (DropDownList1.SelectedValue == "Projects")
                {
                    string rdbVal = this.RadioButtonList1.SelectedValue;
                    DBTool.DeleteTable("Projects", "ProjectID", "@ProjectID", rdbVal);
                    string[] readcol = { "ProjectID", "ProjectName", "TeamID", "TeamName", "DeadLine", "CreateDate", "WhoCreate" };
                    this.Repeater1.DataSource = DBTool.readTable("Projects", readcol);
                    this.Repeater1.DataBind();
                    this.RadioButtonList1.Items.Clear();
                    string[] readcol2 = { "ProjectID", "ProjectName", "TeamName" };
                    string wantdelete = "";
                    foreach (DataRow item in DBTool.readTable("Projects", readcol).Rows)
                    {
                        wantdelete = $"ID:{item[0]}   專案:{item[1]}   負責組:{item[2]}";
                        RadioButtonList1.Items.Add(new ListItem($"{wantdelete}", $"{item[0]}"));
                    }
                }
            }

        }


    }
}