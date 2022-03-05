# ADO.NET进阶

## 一、sql注入风险及解决方案

SQL注入是指在事先定义好的SQL语句中注入额外的SQL语句，从此来欺骗数据库服务器的行为。

**示例：制作会员登录功能。**

![0040](img\0040.PNG)

登录按钮代码如下：

```
private void btLogin_Click(object sender, EventArgs e)
{
    //1-定义连接字符串 
    string connStr = "server=.;database=DBTEST;uid=sa;pwd=123456";
    //2-定义连接对象，打开连接
    SqlConnection conn = new SqlConnection(connStr);
    conn.Open();
    //3-编写sql语句(此处如果用户名密码同时输入' or '1'='1 则可以造成注入)
    string sql = string.Format("select * from Member where MemberAccount='{0}' and MemberPwd='{1}'"
        ,this.txtAccount.Text,this.txtPwd.Text);
    //4-数据适配器抽取信息
    SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
    DataTable dt = new DataTable();  //数据表格
    adp.Fill(dt);
    conn.Close();
    if (dt.Rows.Count == 0)
        MessageBox.Show("用户名或密码错误！");
    else
        MessageBox.Show("登录成功！");
}
```

```
备注：如果在用户名和密码输入框中同时输入' or '1'='1 则可以造成注入，直接登录成功，因为已经改变了原来sql语句的含义，在查询条件中有 '1'='1' 的恒等条件。
```

**针对上述登录功能的问题风险有如下解决方案：**

**方案一：**

对危险字符进行判断，在登录代码之前加入如下代码进行判断。

```
if (this.txtAccount.Text.IndexOf("'") >= 0 || this.txtPwd.Text.IndexOf("'") >= 0)
{
    MessageBox.Show("非法登录!");
    return;
}
```

**方案二：**

优化SQL语句，先根据用户名查询，查询有记录在和密码文本框内容进行比对。

```
private void btLogin_Click(object sender, EventArgs e)
{
    //1-定义连接字符串
    string connStr = "server=.;database=DBTEST;uid=sa;pwd=123456";
    //2-定义连接对象，打开连接
    SqlConnection conn = new SqlConnection(connStr);
    conn.Open();
    //3-编写sql语句
    string sql = string.Format("select * from Member where MemberAccount='{0}'"
        , this.txtAccount.Text);
    //4-数据适配器抽取信息
    SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
    DataTable dt = new DataTable();  //数据表格
    adp.Fill(dt);
    conn.Close();
    if (dt.Rows.Count == 0)
        MessageBox.Show("用户名错误！");
    else
    {
        if (dt.Rows[0]["MemberPwd"].ToString().Equals(this.txtPwd.Text))
            MessageBox.Show("登录成功！");
        else
            MessageBox.Show("密码错误！");
    }
}
```

**方案三：**

使用参数化方式编写sql语句

```
private void btLogin_Click(object sender, EventArgs e)
{
    //1-定义连接字符串 
    //string connStr = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DBTEST;Data Source=.";
    //2-编写连接字符串（sql用户名密码方式连接）
    string connStr = "server=.;database=DBTEST;uid=sa;pwd=123456";
    //2-定义连接对象，打开连接
    SqlConnection conn = new SqlConnection(connStr);
    conn.Open();

    //3-编写sql语句
    string sql = "select * from Member where MemberAccount=@MemberAccount and MemberPwd=@MemberPwd";
    //4-数据适配器抽取信息
    SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
    adp.SelectCommand.Parameters.Add(new SqlParameter("@MemberAccount", this.txtAccount.Text));
    adp.SelectCommand.Parameters.Add(new SqlParameter("@MemberPwd",this.txtPwd.Text));
    DataTable dt = new DataTable();  //数据表格
    adp.Fill(dt);
    conn.Close();
    if (dt.Rows.Count == 0)
        MessageBox.Show("用户名或密码错误！");
    else
        MessageBox.Show("登录成功！");
}
```

## 二、参数化方式实现增删改查

![0037](E:/教学资料V3.0/KGExampleV3.0/006_WinForm技术应用/md/img/0037.PNG)

此示例在之前项目基础上进行修改，主要将添加数据和修改数据修改成参数化方式。

业务需求：

（1）窗体加载的时候显示数据。

（2）点击"添加数据"按钮，弹出新窗体，在新窗体中进行数据的添加，添加完成后自动刷新表格数据。

![0038](E:/教学资料V3.0/KGExampleV3.0/006_WinForm技术应用/md/img/0038.PNG)

（3）鼠标选中一行，右键弹出删除菜单，可以删除数据

（4）鼠标选中一行，点击"编辑数据"按钮，弹出新窗体，在新窗体中进行数据修改，修改后自动刷新表格数据。

![0039](E:/教学资料V3.0/KGExampleV3.0/006_WinForm技术应用/md/img/0039.PNG)

实现步骤如下：

（1）查询窗体显示数据代码：

```
//绑定数据的方法
public void BindData()
{
    //1-定义连接字符串 
    //string connStr = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DBTEST;Data Source=.";
    //2-编写连接字符串（sql用户名密码方式连接）
    string connStr = "server=.;database=DBTEST;uid=sa;pwd=123456";
    //2-定义连接对象，打开连接
    SqlConnection conn = new SqlConnection(connStr);
    conn.Open();
    //3-编写sql语句
    string sql = "select * from Member";
    //4-数据适配器抽取信息
    SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
    DataTable dt = new DataTable();  //数据表格
    adp.Fill(dt);
    this.dataGridView1.AutoGenerateColumns = false;   //自动列取消
    this.dataGridView1.DataSource = dt;
    conn.Close();
}
private void FrmSelect_Load(object sender, EventArgs e)
{
    BindData();
}
```

（2）删除菜单代码：

```
private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
{
    DialogResult r = MessageBox.Show("您确定要删除吗?", "****系统", MessageBoxButtons.YesNo);
    if (r == System.Windows.Forms.DialogResult.No)
    {
        return;
    }
    int memId = int.Parse(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
    string connStr = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DBTEST;Data Source=.";
    SqlConnection conn = new SqlConnection(connStr);
    conn.Open();
    string sql = "delete from Member where MemberId = " + memId;
    SqlCommand cmd = new SqlCommand(sql, conn);
    int rowCount = cmd.ExecuteNonQuery();
    conn.Close();
    if (rowCount == 1)
        MessageBox.Show("删除成功!");
    else
        MessageBox.Show("删除失败!");
    BindData();
}
```

（3）会员添加窗体代码：

```
private void btAdd_Click(object sender, EventArgs e)
{
    //1-编写连接字符串（windows方式连接）
    //string connStr = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DBTEST;Data Source=.";
    //2-编写连接字符串（sql用户名密码方式连接）
    string connStr = "server=.;database=DBTEST;uid=sa;pwd=123456";
    //2-创建连接对象，打开数据库连接
    SqlConnection conn = new SqlConnection(connStr);
    conn.Open();
    //3-编写sql语句
    string sql = string.Format("insert into Member(MemberAccount,MemberPwd,MemberName,MemberPhone)  values(@MemberAccount,@MemberPwd,@MemberName,@MemberPhone)"
            , this.txtAccount.Text, this.txtPwd.Text, this.txtNickName.Text, this.txtPhone.Text);
    //4-定义执行命令的对象执行命令
    SqlCommand cmd = new SqlCommand(sql, conn);
    cmd.Parameters.Add(new SqlParameter("@MemberAccount", this.txtAccount.Text));
    cmd.Parameters.Add(new SqlParameter("@MemberPwd", this.txtPwd.Text));
    cmd.Parameters.Add(new SqlParameter("@MemberName", this.txtNickName.Text));
    cmd.Parameters.Add(new SqlParameter("@MemberPhone", this.txtPhone.Text));
    int rowCount = cmd.ExecuteNonQuery();
    conn.Close();
    if (rowCount == 1)
        MessageBox.Show("添加成功!");
    else
        MessageBox.Show("添加失败!");
    //刷新查询窗体数据并关闭当前窗体
    ((FrmSelect)this.Owner).BindData();
    this.Close();
}
```

（4）会员编辑窗体代码：

```
public int MemId { get; set; }  //接受外部传递过来的会员编号
//绑定会员详情到文本框
private void BindDetail()
{
    //1-定义连接字符串 
    string connStr = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DBTEST;Data Source=.";
    //2-定义连接对象，打开连接
    SqlConnection conn = new SqlConnection(connStr);
    conn.Open();
    //3-编写sql语句
    string sql = "select * from Member where MemberId = " + this.MemId;
    //-抽取数据
    SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
    DataTable dt = new DataTable();
    adp.Fill(dt);
    conn.Close();
    this.txtAccount.Text = dt.Rows[0]["MemberAccount"].ToString();
    this.txtPwd.Text = dt.Rows[0]["MemberPwd"].ToString();
    this.txtNickName.Text = dt.Rows[0]["MemberName"].ToString();
    this.txtPhone.Text = dt.Rows[0]["MemberPhone"].ToString();
}
private void FrmEdit_Load(object sender, EventArgs e)
{
    BindDetail();
}
private void btUpdate_Click(object sender, EventArgs e)
{
    string connStr = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DBTEST;Data Source=.";
    SqlConnection conn = new SqlConnection(connStr);
    conn.Open();
    string sql = "update Member set MemberAccount=@MemberAccount,MemberPwd=@MemberPwd,MemberName=@MemberName,MemberPhone=@MemberPhone where MemberId=@MemberId";
    SqlCommand cmd = new SqlCommand(sql, conn);
    cmd.Parameters.Add(new SqlParameter("@MemberAccount", this.txtAccount.Text));
    cmd.Parameters.Add(new SqlParameter("@MemberPwd", this.txtPwd.Text));
    cmd.Parameters.Add(new SqlParameter("@MemberName", this.txtNickName.Text));
    cmd.Parameters.Add(new SqlParameter("@MemberPhone", this.txtPhone.Text));
    cmd.Parameters.Add(new SqlParameter("@MemberId", this.MemId));
    int rowCount = cmd.ExecuteNonQuery();
    conn.Close();
    if (rowCount == 1)
        MessageBox.Show("修改成功!");
    else
        MessageBox.Show("修改失败!");
    //刷新查询窗体数据并关闭当前窗体
    ((FrmSelect)this.Owner).BindData();
    this.Close();
}
```

（5）查询窗体"添加数据"和"编辑数据"按钮的代码：

```
private void btAdd_Click(object sender, EventArgs e)
{
    FrmAdd frm = new FrmAdd();
    frm.Owner = this;
    frm.Show();
}
private void btEdit_Click(object sender, EventArgs e)
{
    if (this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Equals(""))
    {
        MessageBox.Show("请正确选择!");
        return;
    }
    int memId = int.Parse(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
    FrmEdit frm = new FrmEdit();
    frm.MemId = memId;
    frm.Owner = this;
    frm.Show();
}
```

## 三、封装DBHelper类

```
class DBHelper
{
    //SQL连接字符串-SQL身份认证方式登录
    public static string connStr = "server=.;database=DBTEST;uid=sa;pwd=123456;";

    //SQL连接字符串-Windows身份认证方式登录
    //public static string connStr = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DBTEST;Data Source=.";

    //读取配置文件appSettings节点读取字符串(需要添加引用System.Configuration)
    //public static string connStr = ConfigurationManager.AppSettings["DefaultConn"].ToString();
    //对应的配置文件如下：
    //<appSettings>
    //  <add key="DefaultConn" value="Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DBTEST;Data Source=."/>
    //</appSettings>

    //读取配置文件ConnectionStrings节点读取字符串(需要添加引用System.Configuration)
    //public static string connStr = ConfigurationManager.ConnectionStrings["DefaultConn"].ConnectionString;
    //对应配置文件如下：
    //<connectionStrings>
    //    <add name="DefaultConn" connectionString="Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DBTEST;Data Source=."/>
    //</connectionStrings>

    public static SqlConnection conn = null;
    public static SqlDataAdapter adp = null;

    #region 连接数据库
    /// <summary>
    /// 连接数据库
    /// </summary>
    public static void OpenConn()
    {
        if (conn == null)
        {
            conn = new SqlConnection(connStr);
            conn.Open();
        }
        if (conn.State == System.Data.ConnectionState.Closed)
        {
            conn.Open();
        }
        if (conn.State == System.Data.ConnectionState.Broken)
        {
            conn.Close();
            conn.Open();
        }
    }
    #endregion

    #region 执行SQL语句前准备
    /// <summary>
    /// 准备执行一个SQL语句
    /// </summary>
    /// <param name="sql">需要执行的SQL语句</param>
    public static void PrepareSql(string sql)
    {
        OpenConn(); //打开数据库连接
        adp = new SqlDataAdapter(sql, conn);
    }
    #endregion

    #region 设置和获取sql语句的参数
    /// <summary>
    /// 设置传入参数
    /// </summary>
    /// <param name="parameterName">参数名称</param>
    /// <param name="parameterValue">参数值</param>
    public static void SetParameter(string parameterName, object parameterValue)
    {
        parameterName = "@" + parameterName.Trim();
        if (parameterValue == null)
            parameterValue = DBNull.Value;
        adp.SelectCommand.Parameters.Add(new SqlParameter(parameterName, parameterValue));
    }
    #endregion

    #region 执行SQL语句
    /// <summary>
    /// 执行非查询SQL语句
    /// </summary>
    /// <returns>受影响行数</returns>
    public static int ExecNonQuery()
    {
        int result = adp.SelectCommand.ExecuteNonQuery();
        conn.Close();
        return result;
    }
    /// <summary>
    /// 执行查询SQL语句
    /// </summary>
    /// <returns>DataTable类型查询结果</returns>
    public static DataTable ExecQuery()
    {
        DataTable dt = new DataTable();
        adp.Fill(dt);
        conn.Close();
        return dt;
    }
    /// <summary>
    /// 执行查询SQL语句
    /// </summary>
    /// <returns>SqlDataReader类型查询结果,SqlDataReader需要手动关闭</returns>
    public static SqlDataReader ExecDataReader()
    {
        return adp.SelectCommand.ExecuteReader(CommandBehavior.CloseConnection);
    }
    /// <summary>
    /// 执行查询SQL语句
    /// </summary>
    /// <returns>查询结果第一行第一列</returns>
    public static object ExecScalar()
    {
        object obj = adp.SelectCommand.ExecuteScalar();
        conn.Close();
        return obj;
    }
    #endregion
}
```

