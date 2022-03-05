# HttpModule

ASP.NET请求处理过程是基于管道模型的，这个管道模型是由多个HttpModule和HttpHandler组成，当请求到达

HttpModule的时候，系统还没有对这个请求真正处理，但是我们可以在这个请求传递到处理中（HttpHandler）

之前附加一些其它信息，或者截获的这个请求并做一些额外的工作 。

**本教程主要使用httpModule判断是否登录以及角色权限：**

（1）未登录用户不能访问Admin文件夹下所有文件（跳转到登录页面）。

（2）登录用户，角色为super可以访问Admin下所有文件。

（3）登录用户，角色为common只能访问Admin下Book以及Order文件夹下资源，不能访问SysManage文件夹

下资源。如果访问SysManage文件夹下资源，跳转到Admin下的Index，后台管理首页。

## 一、资料准备

本示例程序没有用到数据库，使用一个泛型集合保存系统用户信息。

网站目录结构如下：

![](img/0014.png)



实体类如下：

```
public class UserEntity
{
    public UserEntity()
    {
        ;
    }
    public UserEntity(string account, string pwd, string role)
    {
        this.Account = account;
        this.Pwd = pwd;
        this.Role = role;
    }

    public string Account { get; set; } //用户名
    public string Pwd { get; set; } //密码
    public string Role { get; set; } //角色（super-超级管理员,common-普通管理员）
}
```

## 二、编写HttpModule

创建一个UserLoginModule.cs文件，代码如下:

```
//必须实现Init和Dispose方法
public class UserLoginModule:IHttpModule
{
	public UserLoginModule()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public void Init(HttpApplication context)
    {
        //throw new NotImplementedException();
        //context.PreRequestHandlerExecute += Context_PreRequestHandlerExecute;
        context.AcquireRequestState += Context_PreRequestHandlerExecute;
    }

    private void Context_PreRequestHandlerExecute(object sender, EventArgs e)
    {
        HttpApplication application = (HttpApplication)sender;
        HttpContext context = application.Context;
        Uri url = context.Request.Url;

        if (url.AbsolutePath.ToLower().Contains("/admin"))
        {
            if (context.Session != null && context.Session["User"] == null)
            {
                context.Response.Redirect("~/Login.aspx?myurl=" + url.AbsolutePath);
            }
        }
        if (url.AbsolutePath.ToLower().Contains("/sysmanage"))
        {
            UserEntity User = new UserEntity();
            User = (UserEntity)context.Session["User"];
            if (User.Role.Equals("super") == false)
            {
                context.Response.Redirect("~/Admin/Index.aspx");
            }
        }
    }
}
```

## 三、配置文件配置

根目录下的web.config如下：

```
<?xml version="1.0"?>
<!--
  有关如何配置 ASP.NET 应用程序的详细信息，请访问
  http://go.microsoft.com/fwlink/?LinkId=169433
  -->
<configuration>
	<system.web>
		<compilation debug="true" targetFramework="4.0"/>
    <!--IIS6配置-->
		<httpModules>
      		<add name="LoginModule" type="UserLoginModule"/>
		</httpModules>
    
	</system.web>
  
  <!--IIS7配置-->
  <!--<system.webServer>
    <modules>
      <add name="asldkfj" type="LgcValidataUser"/>
    </modules>
  </system.webServer>-->
  
</configuration>
```

## 四、用户登录

```
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>登录</h1>
        <p>
            账号：<asp:TextBox ID="txtAccount" runat="server"></asp:TextBox>
        </p>
        <p>
            密码：<asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btnLogin" runat="server" Text="登录" onclick="btnLogin_Click"/>
            <asp:Label ID="lblInfo" runat="server" Text="" ForeColor="Red"></asp:Label>
        </p>
    </div>
    </form>
</body>
</html>
```

```
public partial class Login : System.Web.UI.Page
{
    public List<UserEntity> listUser = new List<UserEntity>();
    protected void Page_Load(object sender, EventArgs e)
    {
        listUser.Add(new UserEntity("admin", "admin", "super"));
        listUser.Add(new UserEntity("liudehua", "123456", "common"));
        listUser.Add(new UserEntity("zhoujielun", "123456", "common"));
    }

    #region 登录
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        List<UserEntity> listTemp = new List<UserEntity>();
        listTemp = listUser.Where(p => p.Account.Equals(this.txtAccount.Text) && p.Pwd.Equals(this.txtPwd.Text)).ToList();
        if (listTemp.Count != 1)
        {
            this.lblInfo.Text = "用户名或密码错误!";
            return;
        }
        else
        {
            Session["User"] = listTemp[0];
            if (Request["myurl"] == null || Request["myurl"].Equals(""))
                Response.Redirect("~/Admin/Index.aspx");
            else
                Response.Redirect(Request["myurl"]);
        }
    }
    #endregion
}
```

