# Razor视图引擎

**Razor介绍：**

Razor不是一种代码语言，而是视图中使用的代码引擎。

它以简洁的类似客户端的语法结构，呈现网页服务端代码功能

它替代了ASPX页面的“<%...%>”代码块语法。

在编写时使用“@符号”开头，“@符号”是Razor的标志。

## 一、Razor基本语法

**视图中显示当前日期信息**

```
<div> 
    <h1>当前日期:</h1>
    <h2>@DateTime.Now.ToString("yyyy年MM月dd日")</h2>
</div>
```

**视图中显示变量和表达式的结果**

Action:

```
#region 视图中显示变量和表达式的结果
public ActionResult Demo02()
{
    ViewBag.RealName = "周杰伦";
    ViewBag.Sex = 1;  //1代表男，2代表女
    ViewBag.Phone = "13557856512";
    ViewBag.Salary = 8000;
    return View();
}
#endregion
```

View:

```
<div>
    <h1>个人基本信息如下:</h1>
    <h3>姓名:@ViewBag.RealName</h3> 
    <h3>性别:@(ViewBag.Sex == 1 ? "男" : "女")</h3> 
    <h3>电话:@ViewBag.Phone</h3> 
    <h3>月薪:@(ViewBag.Salary-2000)</h3> 
</div>
```

**在视图中定义变量并输出**

```
<div>
    @{ 
        var RealName = "周杰伦";
        var Sex = 1;
        var Phone = "13557856512";
        var Salary = 8000;
        <p>姓名:@RealName</p>
        <p>性别:@(Sex == 1 ? "男":"女" )</p>
        <p>电话:@Phone</p>
        <p>姓名:@(Salary-2000)</p>
    } 
</div>
```

**IF语句在视图中的使用**

Action:

```
#region IF语句在视图中的使用
public ActionResult Demo04()
{
    //在页面根据分数输出学生成绩
    //0-30(不包括30):重修
    //30-60(不包括60):补考
    //60-80(不包括80):良好
    //80-100:优秀
    ViewBag.Score = 77;
    return View();
}
#endregion
```

View:

```
<div>
    @*直接输出文字使用@:*@
    @*@if (ViewBag.Score < 30)
    {
        @:重修
    }
    else if (ViewBag.Score < 60)
    {
        @:补考
    }
    else if (ViewBag.Score < 80)
    {
        @:良好
    }
    else
    {
        @:优秀
    }*@

    @*输出HTML标签可以直接写,不需要处理*@
    @if (ViewBag.Score < 30)
    {
        <p>重修</p>
    }
    else if (ViewBag.Score < 60)
    {
        <p>补考</p>
    }
    else if (ViewBag.Score < 80)
    {
        <p>良好</p>
    }
    else
    {
        <p>优秀</p>
    }
</div>
```

**ForEach语句在视图中循环输出内容**

实体类：

```
//篮球队员类
public class Player
{
    public string RealName { get; set; } //姓名
    public string Num { get; set; } //球衣号码
    public string Pos { get; set; } //球场位置，角色
    public Player(string realname,string num,string pos)
    {
        this.RealName = realname;
        this.Num = num;
        this.Pos = pos;
    }
}
```

Action:

```
public ActionResult Demo05()
{
    //定义数组保存人名
    string[] arr = new string[5] { "哈登", "杜兰特", "詹姆斯", "库里", "加内特" };
    ViewBag.Arr = arr;
    //定义集合保存人员信息
    List<Player> listPlayer = new List<Player>();
    listPlayer.Add(new Player("姚明","13","中锋"));
    listPlayer.Add(new Player("易建联", "11", "大前锋"));
    listPlayer.Add(new Player("李根", "22", "小前锋"));
    listPlayer.Add(new Player("胡卫东", "8", "得分后卫"));
    listPlayer.Add(new Player("郭艾伦", "3", "组织后卫"));
    ViewBag.ListPlayer = listPlayer;
    return View();
}
```

View:

```
<div> 
    <h1>美国男子篮球梦之队阵容</h1>
    <ul>
        @foreach (var item in ViewBag.Arr)
        {
            <li>@item</li>
        }
    </ul>
    <h1>中国男子篮球梦之队阵容</h1>
    <table width="600" border="1" class="MyTable">
        <tr>
            <td>球员姓名</td>
            <td>球员号码</td>
            <td>球员位置</td>
        </tr>
        @foreach (var item in ViewBag.ListPlayer)
        {
            <tr>
                <td>@item.RealName</td>
                <td>@item.Num</td>
                <td>@item.Pos</td>
            </tr>
        }
    </table>
</div>
```

## 二、模板页的使用

利用控制器创建视图的时候，选择use a layout page，如果不存在模板，则会自动创建一个bootstrap框架下的模板页面和需要的其他文件。

**相关文件说明：**

```
Content文件夹：存放bootstrap对应的样式表文件。

scripts文件夹：存放Jquery,以及bootstrap对应的JS文件。

Views/_ViewStart.cshtml：视图的启动文件，只要在视图中没有设置Layout=null或者显示设置layout为指定模板文件，在启动视图的时候都会先执行此文件

Views/Shared/_Layout.cshtml：默认的模板文件（因为在_ViewStart.cshtml进行了设置），只要在视图中没有设置Layout=null或者显示的设置Layout为其他模
板文件，那么该视图的模板文件即为此文件。
```

### （1）RenderBody的使用

子页面所有内容会填充到模板@RenderBody()的位置，@RenderBody()只能放在body之间，该方法不需要参数，并且只能在视图中出现一次。

模板页 _Layout.cshtml:

```
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - My ASP.NET Application</title>
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="~/Scripts/modernizr-2.6.2.js"></script>
</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @Html.ActionLink("Application name", "Index", "Home", new { area = "" }, new { @class = "navbar-brand" })
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li class="active"><a href="#">Office</a></li>
                    <li><a href="#about">Windows</a></li>
                    <li><a href="#contact">Surface</a></li>
                    <li><a href="#contact">Xbox</a></li>
                    <li><a href="#contact">技术支持</a></li>
                </ul>
            </div>
        </div>
    </div>

    <div class="container body-content">
        @RenderBody()
        <hr />
        <footer>
            <p>&copy; @DateTime.Now.Year - My ASP.NET Application</p>
        </footer>
    </div>

    <script src="~/Scripts/jquery-1.10.2.min.js"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>
</body>
</html>
```

View:

```
@{
    ViewBag.Title = "Demo06";
    Layout = "~/Views/Shared/_Layout.cshtml";  //指定模板位置，如果不指定，默认_ViewStart.cshtml的设置
}
@*此处内容替换模板页_Layout.cshtml的@RenderBody()部分*@
<h2>Demo06</h2>

```

### （2）RenderSection的使用

有更多的子视图内容填入到_Layout.cshtml，需使用RenderSection，即“页面片段”技术。

如果新建的子视图没有定义“页面片段”，则会抛出异常。可以使用 @RenderSection("foot", false) 引用“页面片段”，参数false代表“foot页面片段”不是必须的，子视图页面不用强制定义。

模板页Layout.cshtml：

```
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - My ASP.NET Application</title>
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="~/Scripts/modernizr-2.6.2.js"></script>
</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @Html.ActionLink("Application name", "Index", "Home", new { area = "" }, new { @class = "navbar-brand" })
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li class="active"><a href="#">Office</a></li>
                    <li><a href="#about">Windows</a></li>
                    <li><a href="#contact">Surface</a></li>
                    <li><a href="#contact">Xbox</a></li>
                    <li><a href="#contact">技术支持</a></li>
                    @RenderSection("VIP", false)
                </ul>
            </div>
        </div>
    </div>

    <div class="container body-content">
        @RenderBody()
        <hr />
        <footer>
            <p>&copy; @DateTime.Now.Year - My ASP.NET Application</p>
        </footer>
    </div>

    <script src="~/Scripts/jquery-1.10.2.min.js"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>
</body>
</html>
```

View：

```
@{
    ViewBag.Title = "Demo06";
    Layout = "~/Views/Shared/_Layout.cshtml";  //指定模板位置，如果不指定，默认_ViewStart.cshtml的设置
}
@*此处内容替换模板页_Layout.cshtml的@RenderBody()部分*@
<h2>Demo06</h2>

@section VIP{
    <li><a href="#" style="color:gold;">VIP专享</a></li>    
}
```

### （3）嵌套模板

模板页Layout.cshtml：

```
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - My ASP.NET Application</title>
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="~/Scripts/modernizr-2.6.2.js"></script>
    @RenderSection("Head", false)
</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @Html.ActionLink("Application name", "Index", "Home", new { area = "" }, new { @class = "navbar-brand" })
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li class="active"><a href="#">Office</a></li>
                    <li><a href="#about">Windows</a></li>
                    <li><a href="#contact">Surface</a></li>
                    <li><a href="#contact">Xbox</a></li>
                    <li><a href="#contact">技术支持</a></li>
                    @RenderSection("VIP", false)
                </ul>
            </div>
        </div>
    </div>

    <div class="container body-content">
        @RenderBody()
        <hr />
        <footer style="clear:both; text-align:center;">
            <p>&copy; @DateTime.Now.Year - My ASP.NET Application</p>
        </footer>
    </div>

    <script src="~/Scripts/jquery-1.10.2.min.js"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>
</body>
</html>
```

嵌套模板LayoutTwo.cshtml:

```
@{
    ViewBag.Title = "_LayoutTwo";
    Layout = "~/Views/Shared/_Layout.cshtml";
}
@section Head{
    <style type="text/css">
        #main {
            width: 100%;
            clear: both;
        }
        #main_left {
            width: 20%;
            float: left;
            background-color: dodgerblue;
            padding-bottom: 20px;
        }

        #main_right {
            width: 80%;
            float: left;
        }

        #main_left div {
            height: 36px;
            line-height: 36px;
            color: white;
            font-size: 16px;
            font-weight: bold;
            padding: 10px;
        }
    </style>
}
<div id="main">
    <div id="main_left">
        <div>产品类别</div>
        <div>全新 Surface Studio 2</div>
        <div>Surface Headphones</div>
        <div>Surface Go</div>
        <div>Surface Pro 6</div>
        <div>Surface Laptop 2</div>
        <div>Surface Book 2</div>
        <div>认证翻新Surface</div>
        <div>Xbox+游戏</div>
        <div>Office</div>
        <div>Windows</div>
        <div>混合现实</div>
    </div>
    <div id="main_right">
        @RenderBody()
    </div>
</div>
```

View:

```
@{
    ViewBag.Title = "Demo08";
    Layout = "~/Views/Shared/_LayoutTwo.cshtml";
}

<h2>Demo08</h2>
```

