# 借助DBHelper实现学生管理

## 一、案例功能的实现

**数据：**

```
--专业
create table ProfessionInfo
(
	ProfessionID int primary key identity(1,1), --专业编号
	professionName varchar(50) not null unique --专业名称
)
--学生
create table StudentInfo
(
	StuID varchar(20) primary key,  --学生学号
	StuName varchar(50) not null,		--学生姓名
	StuAge int not null check(StuAge > 0 and StuAge < 130), --学生年龄
	StuSex char(2) not null check(StuSex in('男','女')),  --学生性别
	StuHobby nvarchar(100), --爱好
	ProfessionID int not null references ProfessionInfo(ProfessionID), --所属专业编号
)
--添加专业信息
insert into ProfessionInfo(professionName) values('电子竞技')
insert into ProfessionInfo(professionName) values('软件开发')
insert into ProfessionInfo(professionName) values('医疗护理')
--插入学生信息
insert into StudentInfo(StuID,StuName,StuAge,StuSex,StuHobby,ProfessionID)
values('001','刘备',18,'男','',1)
insert into StudentInfo(StuID,StuName,StuAge,StuSex,StuHobby,ProfessionID)
values('002','关羽',20,'男','',2)
insert into StudentInfo(StuID,StuName,StuAge,StuSex,StuHobby,ProfessionID)
values('003','张飞',19,'男','',2)
insert into StudentInfo(StuID,StuName,StuAge,StuSex,StuHobby,ProfessionID)
values('004','孙尚香',17,'女','',3)
```

**业务需求：**

![0041](img\0041.PNG)

（1）专业下拉框绑定专业表数据，网格控件绑定学生数据，并且点击"搜索"按钮可以多条件组合查询。

（2）选中某一行，右键可以弹出"删除"菜单，点击"删除"菜单可以删除学生数据。

（3）点击"新增"按钮，弹出新增窗体，在此窗体中完成学生的新增操作。

![0042](img\0042.PNG)

（4）选中某一行，点击"编辑"按钮，弹出编辑窗体，在此窗体中完成数据的修改。

![0043](img\0043.PNG)

备注：其中性别的单选框，以及爱好的多选框分别用两个Pannel容器包含。

**实现代码：**

（1）查询窗体绑定专业信息、绑定学生信息以及搜索功能代码：

```
#region 绑定专业信息到下拉框
private void BindProfession()
{
    DataTable dt = new DataTable();
    DBHelper.PrepareSql("select * from ProfessionInfo");
    dt = DBHelper.ExecQuery();
    DataRow dr = dt.NewRow();
    dr["ProfessionID"] = 0;
    dr["professionName"] = "--请选择--";
    dt.Rows.InsertAt(dr, 0);
    this.cmbPro.DataSource = dt;
    this.cmbPro.DisplayMember = "professionName";
    this.cmbPro.ValueMember = "ProfessionID";
}
#endregion

#region 绑定学生数据
private void BindData()
{
    string sql = "select * from StudentInfo inner join ProfessionInfo on StudentInfo.ProfessionID=ProfessionInfo.ProfessionID  where 1 = 1 ";
    if(!this.cmbPro.SelectedValue.ToString().Equals("0"))
        sql += " and StudentInfo.ProfessionID = " + this.cmbPro.SelectedValue.ToString();
    if(!this.txtName.Text.Equals(""))
        sql += " and StuName like '%" + this.txtName.Text + "%'";
    this.dataGridView1.AutoGenerateColumns = false;
    DBHelper.PrepareSql(sql);
    this.dataGridView1.DataSource = DBHelper.ExecQuery();
}
#endregion

private void Form1_Load(object sender, EventArgs e)
{
    BindProfession();
    BindData();
}

private void btSearch_Click(object sender, EventArgs e)
{
	BindData();
}
```

（2）删除菜单代码：

```
private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
{
    //添加是否确定删除的对话框
    DialogResult result = MessageBox.Show("确定要删除数据吗，删除之后无法恢复！", "提示框",
        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
    if (result == DialogResult.Cancel)
        return;
    string stuid = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
    string sql = "delete from StudentInfo where StuID = @StuID";
    DBHelper.PrepareSql(sql);
    DBHelper.SetParameter("StuID", stuid);
    int rowCount = DBHelper.ExecNonQuery();
    if (rowCount == 1)
        MessageBox.Show("删除成功!");
    else
        MessageBox.Show("删除失败!");
    BindData();
}
```

（3）添加学生信息窗体代码：

```
#region 绑定专业信息到下拉框
private void BindProfession()
{
    DataTable dt = new DataTable();
    DBHelper.PrepareSql("select * from ProfessionInfo");
    dt = DBHelper.ExecQuery();
    DataRow dr = dt.NewRow();
    dr["ProfessionID"] = 0;
    dr["professionName"] = "--请选择--";
    dt.Rows.InsertAt(dr, 0);
    this.cmbPro.DataSource = dt;
    this.cmbPro.DisplayMember = "professionName";
    this.cmbPro.ValueMember = "ProfessionID";
}
#endregion
private void FrmAdd_Load(object sender, EventArgs e)
{
    BindProfession();
}

private void btAdd_Click(object sender, EventArgs e)
{
    string sql = "insert into StudentInfo(StuID,StuName,StuAge,StuSex,StuHobby,ProfessionID) values(@StuID,@StuName,@StuAge,@StuSex,@StuHobby,@ProfessionID)";
    DBHelper.PrepareSql(sql);
    DBHelper.SetParameter("StuID", this.txtId.Text);
    DBHelper.SetParameter("StuName",this.txtName.Text);
    DBHelper.SetParameter("StuAge",this.txtAge.Text);
    //性别处理
    string sex = "";
    if (this.rbBoy.Checked == true) sex = this.rbBoy.Text;
    if (this.rbGirl.Checked == true) sex = this.rbGirl.Text;
    DBHelper.SetParameter("StuSex", sex);
    //爱好处理
    string hobby = "";
    foreach (CheckBox ck in this.panel2.Controls)
    {
        if (ck.Checked == true)
        {
            if (!hobby.Equals(""))
                hobby += ",";
            hobby += ck.Text;
        }
    }
    DBHelper.SetParameter("StuHobby", hobby);
    DBHelper.SetParameter("ProfessionID",this.cmbPro.SelectedValue.ToString());
    int rowCount = DBHelper.ExecNonQuery();
    if (rowCount == 1)
    {
        MessageBox.Show("新增成功!");
        this.Close();
    }
    else
    {
        MessageBox.Show("新增失败!");
    }
}
```

（4）编辑学生信息窗体代码：

```
public string StuID { get; set; } //学生编号
#region 绑定专业信息到下拉框
private void BindProfession()
{
    DataTable dt = new DataTable();
    DBHelper.PrepareSql("select * from ProfessionInfo");
    dt = DBHelper.ExecQuery();
    DataRow dr = dt.NewRow();
    dr["ProfessionID"] = 0;
    dr["professionName"] = "--请选择--";
    dt.Rows.InsertAt(dr, 0);
    this.cmbPro.DataSource = dt;
    this.cmbPro.DisplayMember = "professionName";
    this.cmbPro.ValueMember = "ProfessionID";
}
#endregion
private void BindDetail()
{
    string sql = "select * from StudentInfo where StuID = " + this.StuID;
    DBHelper.PrepareSql(sql);
    DataTable dt = new DataTable();
    dt = DBHelper.ExecQuery();
    this.txtId.Text = dt.Rows[0]["StuID"].ToString();
    this.txtName.Text = dt.Rows[0]["StuName"].ToString();
    this.txtAge.Text = dt.Rows[0]["StuAge"].ToString();
    this.cmbPro.SelectedValue = dt.Rows[0]["ProfessionID"].ToString();
    //性别处理
    if (dt.Rows[0]["StuSex"].ToString().Equals("男"))
        this.rbBoy.Checked = true;
    else
        this.rbGirl.Checked = true;
    //爱好处理
    string[] arrHobby = dt.Rows[0]["StuHobby"].ToString().Split(',');
    foreach (string hobby in arrHobby)
    {
        foreach (CheckBox ck in this.panel2.Controls)
        {
            if (ck.Text.Equals(hobby))
                ck.Checked = true;
        }
    }

}
private void FrmEdit_Load(object sender, EventArgs e)
{
    BindProfession();
    BindDetail();
}

private void btUpdate_Click(object sender, EventArgs e)
{
    string sql = "update StudentInfo set StuName=@StuName,StuAge=@StuAge,StuSex=@StuSex,StuHobby=@StuHobby,ProfessionID=@ProfessionID where StuID=@StuID";
    DBHelper.PrepareSql(sql);
    DBHelper.SetParameter("StuName", this.txtName.Text);
    DBHelper.SetParameter("StuAge", this.txtAge.Text);
    //性别处理
    string sex = "";
    if (this.rbBoy.Checked == true) sex = this.rbBoy.Text;
    if (this.rbGirl.Checked == true) sex = this.rbGirl.Text;
    DBHelper.SetParameter("StuSex", sex);
    //爱好处理
    string hobby = "";
    foreach (CheckBox ck in this.panel2.Controls)
    {
        if (ck.Checked == true)
        {
            if (!hobby.Equals(""))
                hobby += ",";
            hobby += ck.Text;
        }
    }
    DBHelper.SetParameter("StuHobby", hobby);
    DBHelper.SetParameter("ProfessionID", this.cmbPro.SelectedValue.ToString());
    DBHelper.SetParameter("StuID", this.StuID);
    int rowCount = DBHelper.ExecNonQuery();
    if (rowCount == 1)
    {
        MessageBox.Show("修改成功!");
        this.Close();
    }
    else
    {
        MessageBox.Show("修改失败!");
    }
}
```

（5）查询窗体中"新增"和"编辑"按钮代码：

```
private void btAdd_Click(object sender, EventArgs e)
{
    FrmAdd frm = new FrmAdd();
    //frm.Owner = this;
    frm.Show();
}
private void btEdit_Click(object sender, EventArgs e)
{
    string stuid = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
    FrmEdit frm = new FrmEdit();
    frm.StuID = stuid;
    frm.Show();
}
```

## 二、补充：连接字符串配置

将数据库连接字符串直接写在C#代码中，如果连接字符串需要发生改变，必须在C#代码中修改，并且重新进行编译的操作，给软件实施带来了麻烦。

解决此问题，可以将数据库连接字符串存放在配置文件中。

（1）在项目中找到App.config文件，如果没有此文件可以添加一个应用程序配置文件，在此配置文件的configuration节点内部添加如下配置：

```
<connectionStrings>
	<add name="DefaultConn" connectionString="server=.;database=DBTEST;uid=sa;pwd=123456;"/>
</connectionStrings>
```

（2）给项目添加引用"System.Configuration"，并且将C#中连接字符串的赋值修改如下：

```
public static string connStr = ConfigurationManager.ConnectionStrings["DefaultConn"].ConnectionString;
```

