using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace CSharpLessonWeekTwoHW
{
    public partial class WebFormHW : System.Web.UI.Page
    {
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
            string[] readcol = { "Account", "Name", "Phone", "Mail", "LineID", "License", "Privilege", "CreateDate", "WhoCreate" };
            GridView1.DataSource = DBTool.readTable("Users", readcol);
            GridView1.DataBind();
            
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            string[] readcol = { "ProjectID","ProjectName", "TeamID", "TeamName", "DeadLine", "CreateDate", "WhoCreate" };
            GridView1.DataSource = DBTool.readTable("Projects", readcol);
            GridView1.DataBind();
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
                    Text1.Visible = true;
                    Labell.Text = "授權碼: ";
                    Text2.Visible = true;
                    Label2.Text = "權限: ";
                    Text3.Visible = true;
                    Label3.Text = "建立時間: ";
                    Text4.Visible = true;
                    Label4.Text = "建立者: ";
                    Text5.Visible = false;
                    Label5.Text = "";
                    Text6.Visible = false;
                    Label6.Text = "";
                    RadioButtonList1.Visible = false;
                }
                else if (DropDownList1.SelectedValue == "Projects")
                {
                    Text1.Visible = true;
                    Labell.Text = "專案名: ";
                    Text2.Visible = true;
                    Label2.Text = "小組組別: ";
                    Text3.Visible = true;
                    Label3.Text = "小組名稱: ";
                    Text4.Visible = true;
                    Label4.Text = "時程期限: ";
                    Text5.Visible = true;
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
                    Text1.Visible = true;
                    Labell.Text = "帳號: ";
                    Text2.Visible = true;
                    Label2.Text = "姓名: ";
                    Text3.Visible = true;
                    Label3.Text = "電話號碼: ";
                    Text4.Visible = true;
                    Label4.Text = "電子郵件: ";
                    Text5.Visible = true;
                    Label5.Text = "LineID";
                    Text6.Visible = true;
                    Label6.Text = "欲更改之資料授權碼";
                    RadioButtonList1.Visible = false;
                }
                else if (DropDownList1.SelectedValue == "Projects")
                {
                    Text1.Visible = true;
                    Labell.Text = "專案名: ";
                    Text2.Visible = true;
                    Label2.Text = "小組組別: ";
                    Text3.Visible = true;
                    Label3.Text = "小組名稱: ";
                    Text4.Visible = true;
                    Label4.Text = "時程期限: ";
                    Text5.Visible = true;
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
                    string[] readcol = { "Account", "Name", "Phone", "Mail", "LineID", "License", "Privilege", "CreateDate", "WhoCreate" };
                    GridView1.DataSource = DBTool.readTable("Users", readcol);
                    GridView1.DataBind();

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
                    GridView1.DataSource = DBTool.readTable("Projects", readcol);
                    GridView1.DataBind();
                }
            }
            else if (DropDownList2.SelectedValue == "Update")
            {
                if (DropDownList1.SelectedValue == "Users")
                {
                    string[] updatecol = { "Account=@Account", "Name=@Name", "Phone=@Phone", "Mail=@Mail", "LineID=@LineID"};
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
                    string[] readcol = { "Account", "Name", "Phone", "Mail", "LineID", "License", "Privilege", "CreateDate", "WhoCreate" };
                    GridView1.DataSource = DBTool.readTable("Users", readcol);
                    GridView1.DataBind();
                }
                else if (DropDownList1.SelectedValue == "Projects")
                {
                    string[] updatecol = { "ProjectName=@ProjectName", "TeamID=@TeamID", "TeamName=@TeamName", "DeadLine=@DeadLine" };
                    string wherep = "ProjectID=@ProjectID";
                    string[] updatecolp = { "@ProjectName", "@TeamID", "@TeamName", "@DeadLine", "@ProjectID"};
                    List<string> userupdate = new List<string>();
                    userupdate.Add(Text1.Text);
                    userupdate.Add(Text2.Text);
                    userupdate.Add(Text3.Text);
                    userupdate.Add(Text4.Text);
                    userupdate.Add(Text5.Text);
                    DBTool.UpdateTable("Projects", updatecol, wherep, updatecolp, userupdate);
                    Label7.Text = "更新資料完成";
                    string[] readcol = { "ProjectID", "ProjectName", "TeamID", "TeamName", "DeadLine", "CreateDate", "WhoCreate" };
                    GridView1.DataSource = DBTool.readTable("Projects", readcol);
                    GridView1.DataBind();
                }
            }
            else if (DropDownList2.SelectedValue == "Delete")
            {
                if (DropDownList1.SelectedValue == "Users")
                {
                    string rdbVal = this.RadioButtonList1.SelectedValue;
                    DBTool.DeleteTable("Users", "UserID", "@UserID", rdbVal);
                    string[] readcol = { "Account", "Name", "Phone", "Mail", "LineID", "License", "Privilege", "CreateDate", "WhoCreate" };
                    GridView1.DataSource = DBTool.readTable("Users", readcol);
                    GridView1.DataBind();
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
                    GridView1.DataSource = DBTool.readTable("Projects", readcol);
                    GridView1.DataBind();
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