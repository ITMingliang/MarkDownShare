# MVC基础

MVC的组成：Model（模型）, View（视图）, Controller（控制器）

MVC的作用：其主要设计目标是将用户接口和逻辑层相分离，以便开发人员更好关注逻辑层的设计和测试，并使整个程序具备清晰的架构。

![001](img\001.png)

## 一、MVC主要概念

### Model

模型对象是实现应用程序数据域逻辑的应用程序组件，通常被称为“数据模型”。模型对象会检索模型状态并将其存储在数据库中。

例如，Product（商品）对象可能会从数据库中检索信息，操作该信息，然后将更新的信息写回到 SQL Server 数据库内的 Products（商品信息） 表中。

### Controller

控制器是处理用户交互、使用模型并选择视图来显示界面的组件。在 MVC 应用程序中，视图仅显示界面；控制器则用于处理和响应用户输入和交互。

例如，控制器处理查询字符串值，并将这些值传递给模型，而模型可能会使用这些值来查询数据库。

### View

视图是显示应用程序用户界面 (UI) 的组件。 通常，此 UI 由模型数据创建。 

例如，Products（商品信息）表的编辑视图便是一个视图，该视图基于 Product（商品）对象的当前状态显示文本框、下拉列表和复选框等控件。

ASP.NET MVC 支持Razor视图引擎，所以视图更多的采用CSHTML页面。

## 二、创建.NET MVC项目

在VS开发环境中，创建 .NET MVC项目由两种形式：

（1）创建MVC项目：其中自动集成了Jquery,Bootstrap，以及微软提供了一个Demo示例。

（2）创建空MVC项目：其中只有Model，View，Controller等最主要的文件夹和文件内容。

**ASP.NET MVC应用程序目录说明：**

| 目录       | 说明                                                       |
| ---------- | ---------------------------------------------------------- |
| App_Start  | 包含多个静态配置类，执行应用程序的初始化任务               |
| Content    | 放置应用程序的静态内容，如：CSS、可下载的文件、音乐文件、… |
| Controller | 放置控制器文件。控制器文件是后缀名.cs或.vb的类文件         |
| Models     | 放置数据模型对象的文件，例如：.cs、.vb、.edmx、.dbml、…    |
| Views      | 放置视图文件，文件后缀名为.cshtml或.aspx                   |
| Scripts    | 放置JavaScript、jQuery文件                                 |

## 三、Hello,World

**下面我们利用控制器和视图，编写第一个.NET MVC项目，在页面显示Hello,World**

（1）在Controller文件夹中创建一个空控制器，命名为"HomeController"，（控制器的命名规则要求以Controller结尾）。

```
namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}
```

（2）在Index()函数里面点击右键--》添加视图，系统会在View文件夹创建Home文件夹，Home文件夹中创建index.cshtml,如下：

```
@{
    Layout = null;
}

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>
</head>
<body>
    <div> 
    </div>
</body>
</html>
```

（3）在body的div中插入文本，然后浏览此文件，浏览地址为：http://域名:端口/控制器名字(Home)/Action名字(Index)  

## 四、控制器向视图共享数据

控制器向视图传递少量数据，常见三种为：

ViewData：字典类型，存放的是键/值对数据。ViewData只在一次HTTP请求中有效，当这次请求结束后，会自动清空其值。

ViewBag：相当于ViewData，但是内在的实现却完全不一样。 ViewBag存放的不是键值对数据，而是dynamic动态类型数据。

TempData：默认保存在Session中，控制器每次请求从Session中获取TempData，然后清除Session。基于这样的事实，在每次请求结束后，TempData的生命周

期同时结束。

### 1、ViewData共享数据

自定义类支持代码：

```
public class Employee
{
	public int EmpId { get; set; }
	public string EmpName { get; set; }
	public string EmpPhone { get; set; }
}
```

控制器代码如下：

```
public ActionResult Index()
{
	//ViewData，字典类型，存放的是键/值对数据。
	//ViewData只在一次HTTP请求中有效，当这次请求结束后，会自动清空其值。
	Employee emp = new Employee();
	emp.EmpId = 1;
	emp.EmpName = "孙悟空";
	emp.EmpPhone = "13558969651";
	ViewData["Emp"] = emp;
	ViewData["Info"] = "这是我的第一个MVC程序！";
	return View();
}
```

视图展示数据：

```
<div> 
    <h1>
    	@ViewData["Info"].ToString()
    </h1>
    <h2>员工基本信息如下:</h2>
    @{  
    	Employee emp = (Employee)ViewData["Emp"];
    }
    <p>编号：@emp.EmpId</p>
    <p>姓名：@emp.EmpName</p>
    <p>电话：@emp.EmpPhone</p>
</div>
```

### 2、ViewBag共享数据

自定义类支持代码：

```
public class Employee
{
	public int EmpId { get; set; }
	public string EmpName { get; set; }
	public string EmpPhone { get; set; }
}
```

控制器代码如下：

```
public ActionResult Default()
{
    //ViewBag，相当于ViewData，但是内在的实现却完全不一样。 
    //ViewBag存放的不是键值对数据，而是dynamic动态类型数据。
    Employee emp = new Employee();
    emp.EmpId = 1;
    emp.EmpName = "孙悟空";
    emp.EmpPhone = "13558969651";
    ViewBag.Emp = emp;
    ViewBag.Info = "这是我的第一个MVC程序！";
    return View();
}
```

视图展示数据：

```
<div>
    <h1>
    	@ViewBag.Info
    </h1>
    <h2>员工基本信息如下:</h2>
    <p>编号：@ViewBag.Emp.EmpId</p>
    <p>姓名：@ViewBag.Emp.EmpName</p>
    <p>电话：@ViewBag.Emp.EmpPhone</p>
</div>
```

### 3、TempData的使用

以下代码模拟一个登录请求，使用TempData保存提示数据，因为TempData在一次跳转后仍然可以保存数据。

用户登录页面对应的Action:

```
//TempData，默认保存在Session中，控制器每次请求从Session中获取TempData，然后清除Session。
//基于这样的事实，在每次请求结束后，TempData的生命周期同时结束。
public ActionResult LoginForm()
{
    return View();
}
```

用户登录页面的视图：

```
<!DOCTYPE html>
<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>LoginForm</title>
    <style type="text/css">
        div, table, tr, td { margin:0px; padding:0px;}
        .myTable { width:800px; margin:20px auto;  border-collapse:collapse; }
            .myTable td { height:30px; line-height:30px; padding:6px;
            } 
    </style>
</head>
<body>
    <form method="post" action="~/Home/Login">
        <div style="text-align:center;">
            <table width="800" class="myTable" border="1">
                <tr>
                    <td colspan="2" align="center" style="font-weight:bold;">用户登录</td>
                </tr>
                <tr>
                    <td width="200" align="right">用户名：</td>
                    <td width="600" align="left"><input type="text" name="txtAccount" /></td>
                </tr>
                <tr>
                    <td width="200" align="right">密码：</td>
                    <td width="600" align="left"><input type="password" name="txtPwd" /></td>
                </tr>
                <tr>
                    <td width="200" align="right"></td>
                    <td width="600" align="left">
                        <input type="submit" value="登录" />
                        @TempData["ErrInfo"]
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
```

用户登录请求的Action:

```
public ActionResult Login()
{
    //假设用户名 admin,密码 admin 才能登录成功，其它登录失败
    string acc = Request["txtAccount"].ToString();
    string pwd = Request["txtPwd"].ToString();
    if (acc.Equals("admin") && pwd.Equals("admin"))
    {
        return RedirectToAction("WelComeForm");
    }
    else
    {
        TempData["ErrInfo"] = "用户名或密码错误"; //TempData可以在跳转后保存接受数据，但只会在一次跳转中保存。
        return RedirectToAction("LoginForm");
    }         
}
```

登录成功跳转的欢迎页面Action:

```
public ActionResult WelComeForm()
{
    return View();
}
```

登录成功跳转的欢迎页面视图:

```
<div> 
	<h1>欢迎来到********公司OA管理系统！</h1>
</div>
```

## 五、同名Action

同样去实现上面的模拟登录的功能，在上面的例子中，我们编写了两个Action，分别是LoginForm和Login用来打开登录的页面和接受处理登录的请求。

我们也可以编写两个同名的Action，两个Action名字都叫Login，我们使用请求方式的不同进行区分两个Action。

用户登录页面对应的Action:

```
//TempData，默认保存在Session中，控制器每次请求从Session中获取TempData，然后清除Session。
//基于这样的事实，在每次请求结束后，TempData的生命周期同时结束。
public ActionResult Login()
{
    return View();
}
```

用户登录页面的视图：

```
<!DOCTYPE html>
<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>LoginForm</title>
    <style type="text/css">
        div, table, tr, td { margin:0px; padding:0px;}
        .myTable { width:800px; margin:20px auto;  border-collapse:collapse; }
            .myTable td { height:30px; line-height:30px; padding:6px;
            } 
    </style>
</head>
<body>
    <form method="post" action="~/Home/Login">
        <div style="text-align:center;">
            <table width="800" class="myTable" border="1">
                <tr>
                    <td colspan="2" align="center" style="font-weight:bold;">用户登录</td>
                </tr>
                <tr>
                    <td width="200" align="right">用户名：</td>
                    <td width="600" align="left"><input type="text" name="txtAccount" /></td>
                </tr>
                <tr>
                    <td width="200" align="right">密码：</td>
                    <td width="600" align="left"><input type="password" name="txtPwd" /></td>
                </tr>
                <tr>
                    <td width="200" align="right"></td>
                    <td width="600" align="left">
                        <input type="submit" value="登录" />
                        @TempData["ErrInfo"]
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
```

用户登录请求的Action:

```
[HttpPost]
public ActionResult Login()
{
    //假设用户名 admin,密码 admin 才能登录成功，其它登录失败
    string acc = Request["txtAccount"].ToString();
    string pwd = Request["txtPwd"].ToString();
    if (acc.Equals("admin") && pwd.Equals("admin"))
    {
        return RedirectToAction("WelComeForm");
    }
    else
    {
        TempData["ErrInfo"] = "用户名或密码错误"; //TempData可以在跳转后保存接受数据，但只会在一次跳转中保存。
        return RedirectToAction("Login");
    }         
}
```

登录成功跳转的欢迎页面Action:

```
public ActionResult WelComeForm()
{
    return View();
}
```

登录成功跳转的欢迎页面视图:

```
<div> 
	<h1>欢迎来到********公司OA管理系统！</h1>
</div>
```

