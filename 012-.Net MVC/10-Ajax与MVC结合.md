# Ajax与MVC结合

AJAX 是一种在无需重新加载整个网页的情况下，能够更新部分网页的技术，是一种在不刷新页面的前提下实现前端和后端交互的技术。

在前面的JavaScript和Jquery课程中也有介绍过Ajax技术的应用。

## 一、Ajax辅助方法

AJax辅助方法：

- 可以用于创建表单和指向控制器操作方法的链接，但不同的是，它们与服务器采用的是Ajax（异步交互）方式.
- 当使用Ajax辅助方法时，无须编写任何脚本代码即可实现程序的异步性。
- 使用Ajax辅助方法必须先引入jQuery.unobtrusive-ajax.js，此文件默认包含在ASP.NET MVC应用程序模板中。

--------------------------------

### （1）Ajax.ActionLink

Ajax.ActionLink方法:

- 可以创建一个具有异步行为的超链接。
- ActionLink方法的第一个参数是超链接的文本，第二个参数是操作方法的名称。
- ActionLink方法可以通过设置AjaxOptions对象的属性值来调整Ajax请求的行为

AjaxOptions属性和作用：

| 属性             | 作用                                                         |
| ---------------- | ------------------------------------------------------------ |
| Confirm          | 获取或设置提交请求之前，显示于确认窗口中的消息。             |
| HttpMethod       | 获取或设置  HTTP 请求方法（“GET”或“POST”）。                 |
| InsertionMode    | 获取或设置指定如何将响应结果插入到目标 DOM 元素的模式。      |
| LoadingElementId | 获取或设置加载时要显示的 HTML 元素的 id 属性值。             |
| OnBegin          | 获取或设置更新页面之前调用的 JavaScript 函数的名称。         |
| OnComplete       | 获取或设置数据响应之后，更新页面之前，调用的 JavaScript 函数。 |
| OnFailure        | 获取或设置页面更新失败时调用的 JavaScript 函数。             |
| OnSuccess        | 获取或设置页面更新成功之后调用的 JavaScript 函数。           |
| UpdateTargetId   | 获取或设置要使用服务器响应来更新的 DOM 元素的 ID。           |
| Url              | 获取或设置要向其发送请求的 URL。                             |

#### 案例一：

**使用Ajax.ActionLink实现超级链接，并且点击超级链接之后异步显示动态Action内容**

超级链接所在Action：

```
public ActionResult Demo01()
{
	return View();
}
```

超级链接所在的View：

```
<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Demo01</title>
    <script src="~/Script/Jquery/jquery-1.7.1.js"></script>
    <script src="~/Script/Jquery/jquery.unobtrusive-ajax.js"></script>
</head>
<body>
    <h1>
        @*在访问控制器方法的时候如果需要传递参数，可以在AjaxOptions中重新设置访问url*@
        @Ajax.ActionLink("显示名单", "Demo01PartialView", new AjaxOptions { UpdateTargetId = "div1", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }) 
    </h1>
    <div id="div1">        
    </div>
</body>
</html>
```

动态内容的Action：

```
public ActionResult Demo01PartialView()
{
    ViewBag.Items = new string[] { "Jimmy", "Susan", "Tomas", "Helen", "Jessica" };
    return View();
}
```

动态内容的View（没有html,head,body等html结构代码）：

```
<div style="font:bold 20px; color:blue;">
    <ul>
        @foreach (var item in ViewBag.Items)
            {
            <li>@item</li>
        }
    </ul>
</div>
```

#### 案例二：

**使用Ajax.ActionLink实现超级链接，并且点击超级链接之后异步显示当前日期**

超级链接所在Action：

```
public ActionResult Demo02()
{
	return View();
}
```

超级链接所在的View：

```
<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Demo02</title>
    <script src="~/Script/Jquery/jquery-1.7.1.js"></script>
    <script src="~/Script/Jquery/jquery.unobtrusive-ajax.js"></script>
</head>
<body>
    <h1>
        @Ajax.ActionLink("获取当前日期", "Demo02GetDate", new AjaxOptions { UpdateTargetId = "div1", InsertionMode=InsertionMode.Replace, HttpMethod="Post" })
    </h1>
    <div id="div1">
    </div>
</body>
</html>
```

动态内容的Action：

```
public ActionResult Demo02GetDate()
{
    string time = DateTime.Now.ToString("yyyy年MM月dd日");
    return Content(time, "text/html");
}
```

### （2）Ajax.BeginForm

#### 案例一：

**使用Ajax.BeginForm实现用户登录表单**

登录相关Action：

```
public ActionResult Demo03()
{
    return View();
}
[HttpPost]
public ActionResult Demo03(string txtAccount,string txtPwd)
{
    string acc = txtAccount;
    string pwd = txtPwd;
    if (acc.Equals("") || pwd.Equals(""))
    {
        return Content("用户名或密码不能为空", "text/html");
    }
    if (acc.Equals("admin") && pwd.Equals("admin"))
    {
        return Content("<script>window.location.href='Demo03WelCome';</script>", "text/html");
    }
    else
    {
        return Content("用户名或密码错误", "text/html");
    }
}
```

登录页面View：

```
<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Demo03</title>
    <script src="~/Script/Jquery/jquery-1.7.1.js"></script>
    <script src="~/Script/Jquery/jquery.unobtrusive-ajax.js"></script>
    <style type="text/css">
        div, table, tr, td {margin: 0px;padding: 0px;}
        .myTable {width: 800px;margin: 20px auto;border-collapse: collapse;}
        .myTable td {height: 30px;line-height: 30px;padding: 6px;}
    </style>
</head>
<body>
    @*@using (Ajax.BeginForm("Demo03Login", "Home", new AjaxOptions
    {     
        InsertionMode = InsertionMode.Replace,
        HttpMethod = "post",
        UpdateTargetId = "ErrInfo"
    }))*@
    @using (Ajax.BeginForm(new AjaxOptions
    {
        //InsertionMode = InsertionMode.Replace,
        HttpMethod = "post",
        UpdateTargetId = "ErrInfo"      
    }))
    {
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
                        <span id="ErrInfo"></span>
                    </td>
                </tr>
            </table>
        </div>
    }
</body>
</html>
```

登录成功之后的Action和VIew：

```
public ActionResult Demo03WelCome()
{
	return View();
}
```

```
<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Demo03WelCome</title>
</head>
<body>
    <div> 
        <h1>欢迎来到*****系统</h1>
    </div>
</body>
</html>
```

#### 案例二：

**使用Ajax.BeginForm实现员工查询功能**

数据表（将数据表生成EF框架内容）：

```
create table Dept
(
	DeptId int primary key identity(1,1),
	DeptName varchar(50) not null
)

create table Employee
(
	EmpId int primary key identity(1,1),
	DeptId int not null,
	EmpName varchar(50) not null,
	EmpPhone varchar(50) not null,
	EmpArea varchar(50) not null,
	EmpSalary decimal(18,2) not null
)

insert into Dept(DeptName) values('开发部')
insert into Dept(DeptName) values('测试部')
insert into Dept(DeptName) values('实施部')

insert into Employee(DeptId,EmpName,EmpPhone,EmpArea,EmpSalary)
values(1,'刘德华','13887855552','武汉',6500)
insert into Employee(DeptId,EmpName,EmpPhone,EmpArea,EmpSalary)
values(2,'张学友','13556528634','深圳',6500)
insert into Employee(DeptId,EmpName,EmpPhone,EmpArea,EmpSalary)
values(3,'刘亦菲','13448494546','广州',6500)
insert into Employee(DeptId,EmpName,EmpPhone,EmpArea,EmpSalary)
values(1,'周杰伦','13888666855','北京',6500)
insert into Employee(DeptId,EmpName,EmpPhone,EmpArea,EmpSalary)
values(2,'许巍','13868654219','上海',6500)
insert into Employee(DeptId,EmpName,EmpPhone,EmpArea,EmpSalary)
values(3,'孙燕姿','13895133572','成都',6500)
insert into Employee(DeptId,EmpName,EmpPhone,EmpArea,EmpSalary)
values(1,'朴树','13458788896','武汉',6500)
insert into Employee(DeptId,EmpName,EmpPhone,EmpArea,EmpSalary)
values(2,'周润发','13554588745','南京',6500)
insert into Employee(DeptId,EmpName,EmpPhone,EmpArea,EmpSalary)
values(3,'李连杰','13998759654','上海',6500)

select * from Dept
select * from Employee
```

Action：

```
public ActionResult Demo04()
{
    return View();
}
[HttpPost]
public ActionResult Demo04PartialView()
{
    DBTESTEntities db = new DBTESTEntities();
    var listEmp = from emp in db.Employee select emp;
    if (!string.IsNullOrEmpty(Request["txtName"]))
    {
        string empName = Request["txtName"].ToString();
        listEmp = listEmp.Where(p => p.EmpName.Contains(empName));
    }
    ViewBag.listEmp = listEmp;
    return View();
}
```

View：

```
<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Demo04</title>
    <script src="~/Script/Jquery/jquery-1.7.1.js"></script>
    <script src="~/Script/Jquery/jquery.unobtrusive-ajax.js"></script>
    <script type="text/javascript">
        function searchFail()
        {
            $("#ajaxResult").html("查询出错！");
        }
    </script>
</head>
<body>
    <div>
        @using (Ajax.BeginForm("Demo04PartialView", "Home", new AjaxOptions
        {
            InsertionMode = InsertionMode.Replace,
            HttpMethod = "post",
            OnFailure = "searchFail",
            LoadingElementId = "ajaxLoading",
            UpdateTargetId = "ajaxResult"
        }))
        {
            <input type="text" name="txtName" />
            <input type="submit" value="搜 索" />
            <img id="ajaxLoading" src="~/Img/ajax-loader.gif" style="display:none;" />
        }
    </div>
    <div id="ajaxResult">
        
    </div>
</body>
</html>
```

```
<style type="text/css">
    div, table, tr, td {margin: 0px;padding: 0px;}
    .myTable {width: 800px;margin: 20px;border-collapse: collapse;}
    .myTable td, .myTable th {height: 30px;line-height: 30px;padding: 6px;}
</style>
<table width="1000" border="1" class="myTable">
    <tr>
        <th>员工编号</th>
        <th>员工姓名</th>
        <th>员工电话</th>
        <th>所在地区</th>
        <th>员工工资</th>
    </tr>
    @foreach (var item in ViewBag.listEmp)
            {
        <tr>
            <td>@item.EmpId</td>
            <td>@item.EmpName</td>
            <td>@item.EmpPhone</td>
            <td>@item.EmpArea</td>
            <td>@item.EmpSalary.ToString("F2")</td>
        </tr>
    }
</table>
```

## 二、Jquery Ajax和MVC结合

以下很多案例中需要数据库支持，数据表资料如下：

```
create table Dept
(
	DeptId int primary key identity(1,1),
	DeptName varchar(50) not null
)

create table Employee
(
	EmpId int primary key identity(1,1),
	DeptId int not null,
	EmpName varchar(50) not null,
	EmpPhone varchar(50) not null,
	EmpArea varchar(50) not null,
	EmpSalary decimal(18,2) not null
)

insert into Dept(DeptName) values('开发部')
insert into Dept(DeptName) values('测试部')
insert into Dept(DeptName) values('实施部')

insert into Employee(DeptId,EmpName,EmpPhone,EmpArea,EmpSalary)
values(1,'刘德华','13887855552','武汉',6500)
insert into Employee(DeptId,EmpName,EmpPhone,EmpArea,EmpSalary)
values(2,'张学友','13556528634','深圳',6500)
insert into Employee(DeptId,EmpName,EmpPhone,EmpArea,EmpSalary)
values(3,'刘亦菲','13448494546','广州',6500)
insert into Employee(DeptId,EmpName,EmpPhone,EmpArea,EmpSalary)
values(1,'周杰伦','13888666855','北京',6500)
insert into Employee(DeptId,EmpName,EmpPhone,EmpArea,EmpSalary)
values(2,'许巍','13868654219','上海',6500)
insert into Employee(DeptId,EmpName,EmpPhone,EmpArea,EmpSalary)
values(3,'孙燕姿','13895133572','成都',6500)
insert into Employee(DeptId,EmpName,EmpPhone,EmpArea,EmpSalary)
values(1,'朴树','13458788896','武汉',6500)
insert into Employee(DeptId,EmpName,EmpPhone,EmpArea,EmpSalary)
values(2,'周润发','13554588745','南京',6500)
insert into Employee(DeptId,EmpName,EmpPhone,EmpArea,EmpSalary)
values(3,'李连杰','13998759654','上海',6500)

select * from Dept;
select * from Employee;
```

一下案例中部分功能可以用到Json处理类，如下：

```
public class MyJson
{
    #region 将对象转换为Json(支持实体、集合)
    public static string ToJsJson(object item)
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        string output = serializer.Serialize(item);
        return output;
    }
    #endregion

    #region 将Json字符串转换为实体或集合
    public static T FromJsonTo<T>(string jsonString)
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        T jsonObject = serializer.Deserialize<T>(jsonString);
        return jsonObject;
    }
    #endregion

    #region 将DataTable转换成Json字符串
    public static string DataTableToJson(DataTable dt)
    {
        StringBuilder jsonBuilder = new StringBuilder();
        //jsonBuilder.Append("{\"");
        //jsonBuilder.Append(dt.TableName.ToString());
        //jsonBuilder.Append("\":[");

        jsonBuilder.Append("[");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            jsonBuilder.Append("{");
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                jsonBuilder.Append("\"");
                jsonBuilder.Append(dt.Columns[j].ColumnName);
                jsonBuilder.Append("\":\"");
                jsonBuilder.Append(dt.Rows[i][j].ToString());
                jsonBuilder.Append("\",");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("},");
        }
        jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
        jsonBuilder.Append("]");

        //jsonBuilder.Append("]");
        //jsonBuilder.Append("}");
        return jsonBuilder.ToString();
    }
    #endregion

    #region 将DataRow转换成Json数据
    public static string DataRowToJson(DataTable dt)
    {
        StringBuilder jsonBuilder = new StringBuilder();
        jsonBuilder.Append("{");
        for (int j = 0; j < dt.Columns.Count; j++)
        {
            jsonBuilder.Append("\"");
            jsonBuilder.Append(dt.Columns[j].ColumnName);
            jsonBuilder.Append("\":\"");
            jsonBuilder.Append(dt.Rows[0][j].ToString());
            jsonBuilder.Append("\",");
        }
        jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
        jsonBuilder.Append("},");
        jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
        return jsonBuilder.ToString();
    }
    #endregion
}
```

### （1）检查用户名是否可用

Action：

```
public ActionResult Demo05()
{
    return View();
}
public ActionResult Demo05Check()
{
    //假设liubei,guanyu,zhangfei三个用户名已经被注册过
    string acc = Request["acc"].ToString();
    if (acc.Equals(""))
        return Content("用户名不能为空!", "text/html");
    if (acc.Equals("liubei") || acc.Equals("guanyu") || acc.Equals("zhangfei"))
    {
        return Content("用户名已经被注册!", "text/html");
    }
    else
    {
        return Content("恭喜,用户名可以使用!", "text/html");
    }
}
```

View：

```
<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Demo05</title>
    <script src="~/Script/Jquery/jquery-1.7.1.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#btCheck").click(function () {
                var acc = $("#acc").val();
                $.ajax({
                    type: "POST",
                    url: "Demo05Check",
                    data: { acc: acc },
                    success: function (msg) {
                        $("#spanInfo").html(msg);
                    }
                });
            })
        })
    </script>
</head>
<body>
    <div> 
        <h1>用户名验证</h1>
        <form method="post">
            用户名:<input type="text" name="acc" id="acc" />
            <input type="button" value="验证" id="btCheck" />
            <span id="spanInfo" style="color:red;"></span>
        </form>
    </div>
</body>
</html>
```

### （2）查询数据列表

Action：

```
public ActionResult Demo06()
{
    return View();
}
//使用JsonResult返回查询数据(不需要Json工具类)
public JsonResult Demo06Search()
{
    DBTESTEntities db = new DBTESTEntities();
    var listView = from emp in db.Employee
                    join dept in db.Dept on emp.DeptId equals dept.DeptId
                    select new
                    {
                        EmpId = emp.EmpId,
                        DeptId = emp.DeptId,
                        DeptName = dept.DeptName,
                        EmpName = emp.EmpName,
                        EmpPhone = emp.EmpPhone,
                        EmpArea = emp.EmpArea,
                        EmpSalary = emp.EmpSalary
                    };
    if (!string.IsNullOrEmpty(Request["txtName"]))
    {
        //linq to entity,不能在lambda里面进行int.parse,或者其它的显示隐式的转换
        string txtName = Request["txtName"].ToString();
        listView = listView.Where(p => p.EmpName.Contains(txtName));
    }
    return Json(listView, JsonRequestBehavior.AllowGet);
}
```

View：

```
<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Demo06</title>
    <style type="text/css">
        div, table, tr, td { margin: 0px; padding: 0px;}
        .myTable { width: 800px;margin: 20px; border-collapse: collapse; }
        .myTable td, .myTable th {height: 30px;line-height: 30px; padding: 6px; }
    </style>
    <script src="~/Script/Jquery/jquery-1.7.1.js"></script>
    <script type="text/javascript">
        function ShowTable(arrJson) {
            var strTable = "<table width='1000' border='1' id='myTable' class='myTable'>";
            strTable += "<tr><th>员工编号</th><th>员工姓名</th><th>部门名称</th><th>员工电话</th><th>所在地区</th><th>员工工资</th></tr>";
            for (var i = 0; i < arrJson.length; i++) {
                strTable += "<tr>";
                strTable += "<td>" + arrJson[i].EmpId + "</td>";
                strTable += "<td>" + arrJson[i].EmpName + "</td>";
                strTable += "<td>" + arrJson[i].DeptName + "</td>";
                strTable += "<td>" + arrJson[i].EmpPhone + "</td>";
                strTable += "<td>" + arrJson[i].EmpArea + "</td>";
                strTable += "<td>" + arrJson[i].EmpSalary + "</td>";
                //strTable += "<td><a href='javascript:void(0);' class='myedit' id='edit_" + arrJson[i].StuId + "'>编辑</a> <a href='javascript:void(0);' class='mydel' id='del_" + arrJson[i].StuId + "'>删除</a></td>";
                strTable += "</tr>";
            }
            strTable += "</table>";
            $("#divResult").html(strTable);
        }
        $(function () {
            
            $("#selectEmp").click(function () {
                var txtName = $("#txtName").val();
                //使用getJson获取数据
                //$.getJSON("Demo06Search", { txtName: txtName }, function (arrJson) {
                //    ShowTable(arrJson);
                //});

                //使用ajax获取数据
                $.ajax({
                    type: "POST",
                    url: "Demo06Search",
                    data: { txtName: txtName },
                    success: function (arrJson) {
                        ShowTable(arrJson);
                    },
                    dataType:"json"
                });

                //使用post获取数据
                //$.post("Demo06Search", { txtName: txtName },
                //    function (arrJson) {
                //        ShowTable(arrJson);
                //    },
                //    "json"
                //);

            })
        })
    </script>
</head>
<body>
    <div>
        <input type="text" name="txtName" id="txtName" />
        <input id="selectEmp" type="button" value="搜 索" />
    </div>
    <div id="divResult">

    </div>
</body>
</html>
```

### （3）返回多个表数据

组合类：

```
public class DeptAndEmp
{
    public List<Dept> ListDept { get; set; }
    public List<Employee> ListEmp { get; set; }
}
```

Action：

```
public ActionResult Demo07()
{
    return View();
}

public ActionResult Demo07Search()
{
    DBTESTEntities db = new DBTESTEntities();
    var listDept = from dept in db.Dept select dept;
    var listEmp = from emp in db.Employee select emp;

    DeptAndEmp deptEmp = new DeptAndEmp();
    deptEmp.ListDept = listDept.ToList();
    deptEmp.ListEmp = listEmp.ToList();

    //方案一: 使用工具类返回数据
    //string jsonResult = MyJson.ToJsJson(deptEmp);
    //return Content(jsonResult);

    //方案二:使用Json.NET - Newtonsoft，第三方工具返回数据
    //string jsonResult = JsonConvert.SerializeObject(deptEmp);
    //return Content(jsonResult);

    //方案三:使用MVC中Json进行返回数据
    return Json(deptEmp, JsonRequestBehavior.AllowGet);
}
```

View：

```
<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Demo07</title>
    <style type="text/css">
        div, table, tr, td {margin: 0px;padding: 0px;}
        .myTable {width: 800px;margin: 20px;border-collapse: collapse;}
        .myTable td, .myTable th {height: 30px;line-height: 30px;padding: 6px;}
    </style>
    <script src="~/Script/Jquery/jquery-1.7.1.js"></script>
    <script type="text/javascript">
        function ShowDept(arrJson) {
            var strTable = "<table width='1000' border='1' id='myTable' class='myTable'>";
            strTable += "<tr><th>部门编号</th><th>部门名称</th>";
            for (var i = 0; i < arrJson.ListDept.length; i++) {
                strTable += "<tr>";
                strTable += "<td>" + arrJson.ListDept[i].DeptId + "</td>";
                strTable += "<td>" + arrJson.ListDept[i].DeptName + "</td>";
                strTable += "</tr>";
            }
            strTable += "</table>";
            $("#divDept").html(strTable);
        }
        function ShowEmp(arrJson)
        {
            var strTable = "<table width='1000' border='1' id='myTable' class='myTable'>";
            strTable += "<tr><th>员工编号</th><th>员工姓名</th><th>部门编号</th><th>员工电话</th><th>所在地区</th><th>员工工资</th></tr>";
            for (var i = 0; i < arrJson.ListEmp.length; i++) {
                strTable += "<tr>";
                strTable += "<td>" + arrJson.ListEmp[i].EmpId + "</td>";
                strTable += "<td>" + arrJson.ListEmp[i].EmpName + "</td>";
                strTable += "<td>" + arrJson.ListEmp[i].DeptId + "</td>";
                strTable += "<td>" + arrJson.ListEmp[i].EmpPhone + "</td>";
                strTable += "<td>" + arrJson.ListEmp[i].EmpArea + "</td>";
                strTable += "<td>" + arrJson.ListEmp[i].EmpSalary + "</td>";
                //strTable += "<td><a href='javascript:void(0);' class='myedit' id='edit_" + arrJson[i].StuId + "'>编辑</a> <a href='javascript:void(0);' class='mydel' id='del_" + arrJson[i].StuId + "'>删除</a></td>";

                strTable += "</tr>";
            }
            strTable += "</table>";
            $("#divEmp").html(strTable);
        }

        $(function () {
            //使用ajax获取数据
            $.ajax({
                type: "POST",
                url: "Demo07Search",
                //data: { txtName: txtName },
                success: function (arrJson) {
                    ShowDept(arrJson);
                    ShowEmp(arrJson);
                },
                dataType: "json"
            });
        })

    </script>
</head>
<body>
    <div id="divDept">

    </div>
    <br /><br />
    <div id="divEmp">

    </div>
</body>
</html>
```

### （4）自定义Json格式

Action：

```
public ActionResult Demo08()
{
    return View();
}
public ActionResult Demo08Search()
{
    //完全自定义Json格式
    DBTESTEntities db = new DBTESTEntities();
    var listDept = from dept in db.Dept select dept;
    var listEmp = from emp in db.Employee select emp;
    JArray jArrDept = new JArray();
    foreach (var item in listDept)
    {
        JObject obj = new JObject();
        obj.Add("DeptId", item.DeptId);
        obj.Add("DeptName", item.DeptName);
        jArrDept.Add(obj);
    }
    JArray jArrEmp = new JArray();
    foreach (var item in listEmp)
    {
        JObject obj = new JObject();
        obj.Add("EmpId", item.EmpId);
        obj.Add("DeptId", item.DeptId);
        obj.Add("EmpName", item.EmpName);
        obj.Add("EmpPhone", item.EmpPhone);
        obj.Add("EmpArea", item.EmpArea);
        obj.Add("EmpSalary", item.EmpSalary);
        jArrEmp.Add(obj);
    }
    JObject jObj = new JObject();
    jObj.Add("Dept", jArrDept);
    jObj.Add("Emp", jArrEmp);
    string jsonResult = JsonConvert.SerializeObject(jObj);
    return Content(jsonResult);
	
    //部分自定义Json格式
    //DBTESTEntities db = new DBTESTEntities();
    //var listDept = from dept in db.Dept select dept;
    //var listEmp = from emp in db.Employee select emp;
    //JObject jObj = new JObject();
    ////jObj.Add("Dept", (JArray)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(listDept)));
    ////jObj.Add("Emp", (JArray)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(listEmp)));
    //jObj.Add("Dept", JArray.Parse(JsonConvert.SerializeObject(listDept)));
    //jObj.Add("Emp", JArray.Parse(JsonConvert.SerializeObject(listEmp)));
    //string jsonResult = JsonConvert.SerializeObject(jObj);
    //return Content(jsonResult);
}
```

View：

```
<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Demo08</title>
    <style type="text/css">
        div, table, tr, td { margin: 0px; padding: 0px; }
        .myTable { width: 800px; margin: 20px; border-collapse: collapse;}
        .myTable td, .myTable th {height: 30px;line-height: 30px; padding: 6px;}
    </style>
    <script src="~/Script/Jquery/jquery-1.7.1.js"></script>
    <script type="text/javascript">
        function ShowDept(arrJson) {
            var strTable = "<table width='1000' border='1' id='myTable' class='myTable'>";
            strTable += "<tr><th>部门编号</th><th>部门名称</th>";
            for (var i = 0; i < arrJson.Dept.length; i++) {
                strTable += "<tr>";
                strTable += "<td>" + arrJson.Dept[i].DeptId + "</td>";
                strTable += "<td>" + arrJson.Dept[i].DeptName + "</td>";
                strTable += "</tr>";
            }
            strTable += "</table>";
            $("#divDept").html(strTable);
        }
        function ShowEmp(arrJson)
        {
            var strTable = "<table width='1000' border='1' id='myTable' class='myTable'>";
            strTable += "<tr><th>员工编号</th><th>员工姓名</th><th>部门编号</th><th>员工电话</th><th>所在地区</th><th>员工工资</th></tr>";
            for (var i = 0; i < arrJson.Emp.length; i++) {
                strTable += "<tr>";
                strTable += "<td>" + arrJson.Emp[i].EmpId + "</td>";
                strTable += "<td>" + arrJson.Emp[i].EmpName + "</td>";
                strTable += "<td>" + arrJson.Emp[i].DeptId + "</td>";
                strTable += "<td>" + arrJson.Emp[i].EmpPhone + "</td>";
                strTable += "<td>" + arrJson.Emp[i].EmpArea + "</td>";
                strTable += "<td>" + arrJson.Emp[i].EmpSalary + "</td>";
                //strTable += "<td><a href='javascript:void(0);' class='myedit' id='edit_" + arrJson[i].StuId + "'>编辑</a> <a href='javascript:void(0);' class='mydel' id='del_" + arrJson[i].StuId + "'>删除</a></td>";

                strTable += "</tr>";
            }
            strTable += "</table>";
            $("#divEmp").html(strTable);
        }

        $(function () {
            //使用ajax获取数据
            $.ajax({
                type: "POST",
                url: "Demo08Search",
                //data: { txtName: txtName },
                success: function (arrJson) {
                    ShowDept(arrJson);
                    ShowEmp(arrJson);
                },
                dataType: "json"
            });
        })
        
    </script>
</head>
<body>
    <div id="divDept">

    </div>
    <br /><br />
    <div id="divEmp">

    </div>
</body>
</html>
```

