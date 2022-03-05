# AJAX

AJAX 是一种与服务器交换数据的技术，可以在不重新载入整个页面的情况下去访问服务器后端的数据。

## 一、ASP.NET AJAX

### （1）ScriptManager

 ScriptManager 控件管理用于 Microsoft ASP.NET AJAX 页面的客户端脚本。 

示例实现AJAX登录判断是否登录成功。使用两套方案来实现：

【1】ScriptManager实现页面调用后端方法。

【2】ScriptManager实现页面调用WebService。

**方案一：调用后端方法**

在页面有一个后端方法如下：

```
[WebMethod]
public static string Login(string strAccount, string strPwd)
{ 
    //假设用户名"liudehua",密码"123456"成功，其它登录失败
    if (strAccount.Equals("liudehua") && strPwd.Equals("123456"))
    {
    	return "1";
    }
    else
    {
    	return "0";
    }
}
```

页面代码如下：

```
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ScriptManager使用</title>
    <style type="text/css">
        #container{ text-align:center;}
        .righttd
        {
            width: 460px;
        }
        .lefted
        {
            width: 196px;
        }
        .mytitle{ font-size:18px; font-weight:bold;}
    </style>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
    $(function () {
        $("#btLogin").click(function () {
        //调用页面方法（必须静态，必须将ScriptManager的EnablePageMethods设置成true）
            PageMethods.Login($("#txtAccount").val(), $("#txtPwd").val(), function (r) {
            	//alert(r);
                if (r == "1") {
                    alert('登录成功');
                    //return false;
                }
                else {
                    alert('登录失败');
                    //return false;
                }
            }) 

        })
	})
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <%--如果母版页使用了ScriptManager，那么在此使用ScriptManagerProxy--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <div id="container">
        <table>
            <tr>
                <td align="center" height="30" class="mytitle" colspan="2">用户登录</td>
            </tr>
            <tr>
                <td align="right" class="lefted" height="30">用户名:</td>
                <td align="left" class="righttd" height="30">
                    <asp:TextBox ID="txtAccount" runat="server" ClientIDMode="Static"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="lefted" height="30">密码:</td>
                <td align="left" class="righttd" height="30">
                    <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" ClientIDMode="Static"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="lefted" height="30"></td>
                <td align="left" class="righttd" height="30">
                    <input type="button" id="btLogin" value="登 录" />
                    <%--<asp:Button ID="btLogin" runat="server" Text="登  录" ClientIDMode="Static" />--%>
                </td>
            </tr>
            <tr>
                <td align="right" class="lefted" height="30"></td>
                <td align="left" class="righttd" height="30">
                    <asp:Label ID="lblErrInfo" runat="server" ForeColor="Red" ClientIDMode="Static"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
```

**方案二：调用Webservice**

有一个webservice，代码如下：

```
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {
    public WebService () {
        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    [WebMethod]
    public string Login(string strAccount, string strPwd)
    {
        //假设用户名"liudehua",密码"123456"成功，其它登录失败
        if (strAccount.Equals("liudehua") && strPwd.Equals("123456"))
        {
            return "1";
        }
        else
        {
            return "0";
        }
    }    
}
```

页面代码如下：

```
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ScriptManager使用</title>
    <style type="text/css">
        #container{ text-align:center;}
        .righttd
        {
            width: 460px;
        }
        .lefted
        {
            width: 196px;
        }
        .mytitle{ font-size:18px; font-weight:bold;}
    </style>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#btLogin").click(function () { 
                //调用web服务的方法（必须将服务中允许asp.net ajax调用的注释去掉）
                WebService.Login($("#txtAccount").val(), $("#txtPwd").val(), function (r) 				  {
                    //alert(r);
                    if (r == "1") {
                        alert('登录成功');
                        //return false;
                    }
                    else {
                        alert('登录失败');
                        //return false;
                    }
                })

            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <%--如果母版页使用了ScriptManager，那么在此使用ScriptManagerProxy--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        <Services>
            <asp:ServiceReference Path="~/WebService.asmx" />
        </Services>
    </asp:ScriptManager>
    <div id="container">
        <table>
            <tr>
                <td align="center" height="30" class="mytitle" colspan="2">用户登录</td>
            </tr>
            <tr>
                <td align="right" class="lefted" height="30">用户名:</td>
                <td align="left" class="righttd" height="30">
                    <asp:TextBox ID="txtAccount" runat="server" ClientIDMode="Static"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="lefted" height="30">密码:</td>
                <td align="left" class="righttd" height="30">
                    <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" ClientIDMode="Static"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="lefted" height="30"></td>
                <td align="left" class="righttd" height="30">
                    <input type="button" id="btLogin" value="登 录" />
                    <%--<asp:Button ID="btLogin" runat="server" Text="登  录" ClientIDMode="Static" />--%>
                </td>
            </tr>
            <tr>
                <td align="right" class="lefted" height="30"></td>
                <td align="left" class="righttd" height="30">
                    <asp:Label ID="lblErrInfo" runat="server" ForeColor="Red" ClientIDMode="Static"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
```

### （2）UpdatePanel控件

UpdatePanel是一个容器，可以实现容器内局部刷新的效果。

示例实现AJAX登录判断是否登录成功。

**ASPX代码：**

```
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>UpdatePanel控件的使用</title>
    <style type="text/css">
        #container{ text-align:center;}
        .righttd
        {
            width: 460px;
        }
        .lefted
        {
            width: 196px;
        }
        .mytitle{ font-size:18px; font-weight:bold;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <table>
            <tr>
                <td align="center" height="30" class="mytitle" colspan="2">用户登录</td>
            </tr>
            <tr>
                <td align="right" class="lefted" height="30">用户名:</td>
                <td align="left" class="righttd" height="30">
                    <asp:TextBox ID="txtAccount" runat="server" ClientIDMode="Static"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="lefted" height="30">密码:</td>
                <td align="left" class="righttd" height="30">
                    <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" ClientIDMode="Static"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="lefted" height="30"></td>
                <td align="left" class="righttd" height="30">
                    <asp:Button ID="btLogin" runat="server" Text="登  录" ClientIDMode="Static" 
                        onclick="btLogin_Click" />
                </td>
            </tr>
            <tr>
                <td align="right" class="lefted" height="30"></td>
                <td align="left" class="righttd" height="30">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblErrInfo" runat="server" ForeColor="Red" ClientIDMode="Static"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btLogin" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                    
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
```

**C#代码：**

```
public partial class Demo02 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btLogin_Click(object sender, EventArgs e)
    {
        //假设用户名"liudehua",密码"123456"成功，其它登录失败
        if (this.txtAccount.Text.Equals("liudehua") && this.txtPwd.Text.Equals("123456"))
        {
            this.lblErrInfo.Text = "登录成功!";
        }
        else
        {
            this.lblErrInfo.Text = "用户名或密码错误!";
        }
    }
}
```

### （3）UpdateProgress控件

UpdateProgress控件可以实现在结果没有显示之前出来给出相应提示。

本示例演示一个耗时比较长的计算，在计算结果出来之前给出相应提示。

**ASPX代码：**

```
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>UpdateProgress使用</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div> 
        <asp:Button ID="btCompute" runat="server" Text="计算1+2+3+。。。。+1000000000的和" 
            onclick="btCompute_Click" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <p><asp:Label ID="lblSum" runat="server" Text=""></asp:Label></p>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btCompute" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>

        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <h3 style=" color:Red;"><img src="img/wait.gif" />主人，我正在努力计算，请稍等。。。</h3>
            </ProgressTemplate>
        </asp:UpdateProgress>

    </div>
    </form>
</body>
</html>
```

如果页面需要多个UpdateProgress，则可以将UpdateProgress放到UpdatePanel里面表示其关联对应关系。

**C#代码：**

```
public partial class Demo03 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void btCompute_Click(object sender, EventArgs e)
    {
        //System.Threading.Thread.Sleep(5000);
        long sum = 0;
        for (long i = 0; i <=1000000000  ; i++)
        {
            sum += i;
        }
        this.lblSum.Text = sum.ToString();
    }
}
```

### （4）Timer控件的使用

Timer控件可以实现定时不停的执行代码。

示例演示一个时钟效果，在页面不刷新的情况下，实时更新页面时间。

**ASPX代码：**

```
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Timer控件的使用</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Timer ID="Timer1" runat="server" Interval="1000" ontick="Timer1_Tick">
    </asp:Timer>
    <div>
        <h1>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Label ID="lblTime" runat="server" Text="Label"></asp:Label>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                </Triggers>
            </asp:UpdatePanel>
        </h1>
    </div>
    </form>
</body>
</html>
```

```
public partial class Demo04 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.lblTime.Text = DateTime.Now.ToString("yyyy年MM月dd日 hh时mm分ss秒");
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        this.lblTime.Text = DateTime.Now.ToString("yyyy年MM月dd日 hh时mm分ss秒");
    }
}
```

### （5）篮球文字直播间

本示例两个部分组成：

（1）管理人员进行信息发布。

（2）游客球迷在页面不刷新的情况下观看比分和文字直播。

**存储直播信息的类：**

```
public class BasketBall
{
    public static List<string> listContent = new List<string>(); //直播文字内容
    public static string strScore; //比分
}
```

**管理人员发布文字信息：**

```
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>火箭VS勇士-比分
        <asp:TextBox ID="txtHoujian" runat="server"></asp:TextBox>
        -
        <asp:TextBox ID="txtYongshi" runat="server"></asp:TextBox>
        </h1>
        <p>
            <asp:TextBox ID="txtContent" runat="server" Height="273px" TextMode="MultiLine" 
            Width="598px"></asp:TextBox>       
        </p>
        <p>
            <asp:Button ID="btSubmit" runat="server" Text="提交" onclick="btSubmit_Click" />      
        </p>
    </div>
    </form>
</body>
</html>
```

```
public partial class Demo05_01 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void btSubmit_Click(object sender, EventArgs e)
    {
        BasketBall.strScore = this.txtHoujian.Text + ":" + this.txtYongshi.Text;
        BasketBall.listContent.Add(this.txtContent.Text.Replace("\n", "<br>").Replace("\r\n", "<br>").Replace(" ", "&nbsp;"));
    }
}
```

**游客观看直播内容：**

```
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>篮球文字直播间</title>
</head>
<body>
    <h2>管理员可以在Demo05_01页面进行文字直播！</h2>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Timer ID="Timer1" runat="server" Interval="10000" ontick="Timer1_Tick">
    </asp:Timer>
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <h1>火箭VS勇士-比分（<asp:Label ID="lblScore" runat="server" Text=""></asp:Label>）</h1>
                <asp:Label ID="lblContent" runat="server" Text=""></asp:Label>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
```

```
public partial class Demo05 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindData();
    }

    private void BindData()
    {
        this.lblScore.Text = BasketBall.strScore;
        string str = "";
        foreach (string item in BasketBall.listContent)
        {
            str += "<p>" + item + "</p>";
        }
        this.lblContent.Text = str;
        
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        BindData();
    }
}
```

## 二、Jquery AJAX

### （1）后端数据模拟

```
public partial class AjaxResponse : System.Web.UI.Page
{
    private static List<StudentEntity> listStu = new List<StudentEntity>();
    protected void Page_Load(object sender, EventArgs e)
    {
        #region 添加测试初始化数据
        if (listStu.Count == 0)
        {
            listStu.Add(new StudentEntity(1, "刘备", "男", "13556878546", "liubei@163.com"));
            listStu.Add(new StudentEntity(2, "关羽", "男", "13698754521", "guanyu@163.com"));
            listStu.Add(new StudentEntity(3, "张飞", "男", "13512365412", "zhangfei@163.com"));
            listStu.Add(new StudentEntity(4, "赵云", "男", "13998986547", "zhaoyun@163.com"));
            listStu.Add(new StudentEntity(5, "马超", "男", "13458745232", "machao@163.com"));
            listStu.Add(new StudentEntity(7, "大乔", "女", "13532234512", "zhangfei@163.com"));
            listStu.Add(new StudentEntity(8, "小乔", "女", "1391434579", "zhaoyun@163.com"));
            listStu.Add(new StudentEntity(9, "孙尚香", "女", "1347895159", "machao@163.com"));
        }
        #endregion

        string act = Request["act"];
        switch (act)
        {
            case "HelloWorld":
                HelloWorld(); break;
            case "AddNum":
                AddNum(); break;
            case "Select":
                Select(); break;
            case "AddAndSelect":
                AddAndSelect(); break;
            case "Detail":
                Detail(); break;
            case "UpdateAndSelect":
                UpdateAndSelect(); break;
            case "DeleteAndSelect":
                DeleteAndSelect(); break;
            default:
                break;
        }
    }

    #region 返回字符串
    private void HelloWorld()
    {
        Response.Write("Hello World");
        Response.End();
    }
    #endregion

    #region 返回字符串
    private void AddNum()
    {
        int a = int.Parse(Request["a"]);
        int b = int.Parse(Request["b"]);
        Response.Write((a + b).ToString());
        Response.End();
    }
    #endregion

    #region 返回Json数组字符串
    private void Select()
    {
        Response.Write(MyJson.ToJsJson(listStu));
        Response.End();
    }
    #endregion

    #region 返回Json数组字符串
    private void AddAndSelect()
    {
        StudentEntity entity = new StudentEntity();
        entity.StudentId = 10;
        entity.StudentName = Request["StudentName"];
        entity.StudentSex = Request["StudentSex"];
        entity.StudentPhone = Request["StudentPhone"];
        entity.StudentMail = Request["StudentMail"];
        listStu.Add(entity);
        Response.Write(MyJson.ToJsJson(listStu));
        Response.End();
    }
    #endregion

    #region 返回Json对象
    private void Detail()
    {
        int stuId = int.Parse(Request["StudentId"].ToString());
        StudentEntity entity = new StudentEntity();
        entity = listStu.Where(p => p.StudentId == stuId).ToList()[0];
        Response.Write(MyJson.ToJsJson(entity));
        Response.End();
    }
    #endregion

    #region 返回Json数组字符串
    private void UpdateAndSelect()
    {
        int stuId = int.Parse(Request["StudentId"].ToString());
        StudentEntity entity = new StudentEntity();
        entity = listStu.Where(p => p.StudentId == stuId).ToList()[0];
        entity.StudentName = Request["StudentName"];
        entity.StudentSex = Request["StudentSex"];
        entity.StudentPhone = Request["StudentPhone"];
        entity.StudentMail = Request["StudentMail"];
        Response.Write(MyJson.ToJsJson(listStu));
        Response.End();
    }
    #endregion

    #region 返回Json数组字符串
    private void DeleteAndSelect()
    {
        int stuId = int.Parse(Request["StudentId"].ToString());
        int delIndex = -1;
        for (int i = 0; i <= listStu.Count-1 ; i++)
        {
            if (listStu[i].StudentId == stuId)
            {
                delIndex = i;
            }
        }
        listStu.RemoveAt(delIndex);
        Response.Write(MyJson.ToJsJson(listStu));
        Response.End();
    }
    #endregion
}
```

### （2）接收字符串

```
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>获取HelloWorld数据</title>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#bt1").click(function () {
//                $.ajax({
//                    type: "post",
//                    //async: true,
//                    url: "AjaxResponse.aspx",
//                    data: "act=HelloWorld",
//                    type: "text",
//                    success: function (msg) {
//                        //$("#spanInfo").html(msg);
//                        alert(msg);
//                    },
//                    error: function (msg) {
//                        alert('调用失败：' + msg);
//                    }
//                });


                //post-get请求个参数
                //url:发送请求地址。
                //data:待发送 Key/value 参数。
                //callback:发送成功时回调函数。
                //type:返回内容格式，xml, html, script, json, text, _default。
//                $.get("AjaxResponse.aspx", { act: "HelloWorld" },
//                    function (msg) {
//                        alert(msg);
//                    },
//                    "text"
//                );
                $.post("AjaxResponse.aspx", { act: "HelloWorld" },
                    function (msg) {
                        alert(msg);
                    },
                    "text"
                );
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input type="button" value="获取HelloWorld数据" id="bt1" />
    </div>
    </form>
</body>
</html>
```

### （2）传递参数，接收字符串

```
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>获取Add数据</title>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#myButton").click(function () {
                var num1 = parseInt($("#txt1").val());
                var num2 = parseInt($("#txt2").val());
//                $.ajax({
//                    type: "post",
//                    //async: true,
//                    url: "AjaxResponse.aspx",
//                    data: "act=AddNum&a="+num1+"&b="+num2,
//                    //data: { act: "AddNum", a: num1, b: num2 },
//                    type: "text",
//                    success: function (msg) {
//                        //$("#spanInfo").html(msg);
//                        alert(msg);
//                    },
//                    error: function (msg) {
//                        alert('调用失败：' + msg);
//                    }
//                });

                //post-get请求个参数
                //url:发送请求地址。
                //data:待发送 Key/value 参数。
                //callback:发送成功时回调函数。
                //type:返回内容格式，xml, html, script, json, text, _default。
//                $.get("AjaxResponse.aspx", { act: "AddNum",a:num1,b:num2 },
//                    function (msg) {
//                        alert(msg);
//                    },
//                    "text"
//                );

                $.post("AjaxResponse.aspx", { act: "AddNum", a: num1, b: num2 },
                    function (msg) {
                        alert(msg);
                    },
                    "text"
                ); 
            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        请输入第一个整数:<input type="text" id="txt1" />
        请输入第二个整数:<input type="text" id="txt2" />
        <input type="button" value="求和" id="myButton" />
    </div>
    </form>
</body>
</html>
```

### （3）实现学生信息管理

```
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>进行学生信息的基本操作</title>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        //jquery的json对象与字符串之间转换
        //json对象----- >>字符串
        //JSON.stringify(obj)
        //json字符串------>>json对象
        //JSON.parse(string)
        //eval('(' + msg + ')');

        function ShowStudent(jsonStr)
        {
            $("#stuInfo").html("");
            var strTable = "<table border='1'>";
            strTable += "<tr><th>编号</th><th>姓名</th><th>性别</th><th>电话</th><th>邮箱</th><th>操作</th></tr>";
            //字符串转json
            var jsonArr = JSON.parse(jsonStr);
            $.each(jsonArr, function (i, date) {
                strTable += "<tr>";
                strTable += "<td>" + jsonArr[i].StudentId + "</td>";
                strTable += "<td>" + jsonArr[i].StudentName + "</td>";
                strTable += "<td>" + jsonArr[i].StudentSex + "</td>";
                strTable += "<td>" + jsonArr[i].StudentPhone + "</td>";
                strTable += "<td>" + jsonArr[i].StudentMail + "</td>";
                strTable += "<td>";
                strTable += "<a class='aEdit' href='javascript:void(0);' id='edit_" + jsonArr[i].StudentId + "'>编辑</a> ";
                strTable += "<a class='aDel' href='javascript:void(0);' id='del_" + jsonArr[i].StudentId + "'>删除</a> ";
                strTable += "</td>";
                strTable += "</tr>";
            })
            strTable += "</table>";
            $("#stuInfo").append(strTable);
        }
        $(function () {
            $("#btSelect").click(function () {
                $.post("AjaxResponse.aspx", { act: "Select" },
                    function (msg) {
                        //Json转字符串
                        ShowStudent(JSON.stringify(msg));
                    },
                    "json"
                );
            });
            $("#btAdd").click(function () {
                var StudentName = $("#txtName").val();
                var StudentSex = $("#pSex :radio:checked").val();
                var StudentPhone = $("#txtPhone").val();
                var StudentMail = $("#txtMail").val();
                $.post("AjaxResponse.aspx", { act: "AddAndSelect", StudentName: StudentName, StudentSex: StudentSex, StudentPhone: StudentPhone, StudentMail: StudentMail },
                    function (msg) {
                        //Json转字符串
                        ShowStudent(JSON.stringify(msg));
                    },
                    "json"
                );
            });

            $("#stuInfo").on("click", ".aEdit", function () {
                //alert($(this).prop("id"));
                var id = $(this).prop("id").split('_')[1];
                $.post("AjaxResponse.aspx", { act: "Detail", StudentId: id },
                    function (jsonObj) {
                        $("#hdUpdateStudentId").val(jsonObj.StudentId);
                        $("#txtUpdateName").val(jsonObj.StudentName);
                        $("#txtUpdatePhone").val(jsonObj.StudentPhone);
                        $("#txtUpdateMail").val(jsonObj.StudentMail);
                        if (jsonObj.StudentSex == "男")
                            $("#updateBoy").prop("checked", true);
                        if (jsonObj.StudentSex == "女")
                            $("#updateGirl").prop("checked", true);
                    },
                    "json"
                );
            })

            $("#stuInfo").on("click", ".aDel", function () {
                //alert($(this).prop("id"));
                var id = $(this).prop("id").split('_')[1];
                $.post("AjaxResponse.aspx", { act: "DeleteAndSelect", StudentId: id },
                    function (jsonObj) {
                        ShowStudent(JSON.stringify(jsonObj));
                    },
                    "json"
                );
            })

            $("#btUpdate").click(function () {
                var StudentId = $("#hdUpdateStudentId").val();
                var StudentName = $("#txtUpdateName").val();
                var StudentSex = $("#pUpdateSex :radio:checked").val();
                var StudentPhone = $("#txtUpdatePhone").val();
                var StudentMail = $("#txtUpdateMail").val();
                $.post("AjaxResponse.aspx", { act: "UpdateAndSelect", StudentId: StudentId, StudentName: StudentName, StudentSex: StudentSex, StudentPhone: StudentPhone, StudentMail: StudentMail },
                    function (msg) {
                        //Json转字符串
                        ShowStudent(JSON.stringify(msg));
                    },
                    "json"
                );
            })

        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <p>
        <input type="button" id="btSelect" value="查询"  />
    </p>
    <p id="stuInfo">
        
    </p>
    <div style=" width:50%; float:left">
        <h3>用户添加</h3>
        <p>姓名：<input type="text" id="txtName" /></p>
        <p id="pSex">
            性别：
            <input type="radio" value="男" checked="checked" name="sex" />男 
            <input type="radio" value="女" name="sex" />女
        </p>
        <p>电话：<input type="text" id="txtPhone" /></p>
        <p>邮箱：<input type="text" id="txtMail" /></p>
        <p>
            <input type="button" value="添加" id="btAdd" /> 
        </p>
    </div>
    <div style=" width:50%; float:left">
        <h3>用户修改</h3>
        <input type="hidden" id="hdUpdateStudentId" />
        <p>姓名：<input type="text" id="txtUpdateName" /></p>
        <p id="pUpdateSex">
            性别：
            <input type="radio" value="男" checked="checked" id="updateBoy" name="updateSex" />男 
            <input type="radio" value="女" name="updateSex" id="updateGirl" />女
        </p>
        <p>电话：<input type="text" id="txtUpdatePhone" /></p>
        <p>邮箱：<input type="text" id="txtUpdateMail" /></p>
        <p>
            <input type="button" value="修改" id="btUpdate" /> 
        </p>
    </div>
    </form>
</body>
</html>
```

## 三、AJAX实例

### （1）资料准备

**数据库代码：**

```
create table Member
(
	MemberId int primary key identity(1,1),
	Account varchar(50) not null,
	Pwd varchar(50) not null,
	Phone varchar(50) not null
)
insert into Member(Account,Pwd,Phone) values('liubei','123456','13558745825')
insert into Member(Account,Pwd,Phone) values('guanyu','123456','13875845214')
```

```
create table Student
(
	StuId int primary key identity(1,1),
	StuName varchar(50) not null,
	StuSex varchar(10) not null,
	StuPhone varchar(20) not null,
	StuMail varchar(50) not null
)
insert into Student(StuName,StuSex,StuPhone,StuMail)
values('刘备','男','13558745874','liubei@163.com')
insert into Student(StuName,StuSex,StuPhone,StuMail)
values('关羽','男','13589658785','guanyu@163.com')
insert into Student(StuName,StuSex,StuPhone,StuMail)
values('张飞','男','13478965478','zhangfei@163.com')
insert into Student(StuName,StuSex,StuPhone,StuMail)
values('貂蝉','女','13985456321','diaocan@163.com')
insert into Student(StuName,StuSex,StuPhone,StuMail)
values('小乔','女','13878547412','xiaoqiao@163.com')
insert into Student(StuName,StuSex,StuPhone,StuMail)
values('马超','男','13356856565','machao@163.com')
```

还有一个中国地区信息（三级）数据文件太大，请参考项目文件夹。

**JSON处理类：**

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

**实体类：**

```
public class MemberEntity
{
    public int MemberId { get; set; }
    public string Account { get; set; }
    public string Pwd { get; set; }
    public string Phone { get; set; }
}
```

```
public class StudentEntity
{
    public int StuId { get; set; }
    public string StuName { get; set; }
    public string StuSex { get; set; }
    public string StuPhone { get; set; }
    public string StuMail { get; set; }
}
```

```
public class AreaEntity
{
    public string AreaId { get; set; }  //地区编号
    public string AreaName { get; set; } //地区名称
}
```

**数据访问代码（DBHelper参考第一章）：**

```
public class MemberDAL
{
    DBHelper db = new DBHelper();
	public MemberDAL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public bool IsAccCanUse(string acc)
    {
        string sql = "select count(*) from Member where Account = @Account";
        db.PrepareSql(sql);
        db.SetParameter("Account", acc);
        int count = (int)db.ExecScalar();
        if (count == 0)
            return true;
        else
            return false;
    }
}
```

```
public class StudentDAL
{
    DBHelper db = new DBHelper();

    #region 添加
    public int Add(StudentEntity entity)
    {
        string sql = "insert into Student(StuName,StuSex,StuPhone,StuMail) values(@StuName,@StuSex,@StuPhone,@StuMail)";
        db.PrepareSql(sql);
        db.SetParameter("StuName",entity.StuName);
        db.SetParameter("StuSex",entity.StuSex);
        db.SetParameter("StuPhone",entity.StuPhone);
        db.SetParameter("StuMail",entity.StuMail);
        return db.ExecNonQuery();
    }
    #endregion

    #region 删除
    public int Delete(int stuId)
    {
        string sql = "delete from Student where StuId=@StuId";
        db.PrepareSql(sql);
        db.SetParameter("StuId", stuId);
        return db.ExecNonQuery();
    }
    #endregion

    #region 修改
    public int Update(StudentEntity entity)
    {
        string sql = "update Student set StuName=@StuName,StuSex=@StuSex,StuPhone=@StuPhone,StuMail=@StuMail where StuId=@StuId";
        db.PrepareSql(sql);
        db.SetParameter("StuName", entity.StuName);
        db.SetParameter("StuSex", entity.StuSex);
        db.SetParameter("StuPhone", entity.StuPhone);
        db.SetParameter("StuMail", entity.StuMail);
        db.SetParameter("StuId", entity.StuId);
        return db.ExecNonQuery();
    }
    #endregion

    #region 查询列表
    public List<StudentEntity> List()
    {
        string sql = "select * from Student";
        db.PrepareSql(sql);
        DataTable dt = new DataTable();
        dt = db.ExecQuery();
        List<StudentEntity> list = new List<StudentEntity>();
        foreach (DataRow dr in dt.Rows)
        {
            StudentEntity entity = new StudentEntity();
            entity.StuId = int.Parse(dr["StuId"].ToString());
            entity.StuName = dr["StuName"].ToString();
            entity.StuSex = dr["StuSex"].ToString();
            entity.StuPhone = dr["StuPhone"].ToString();
            entity.StuMail = dr["StuMail"].ToString();
            list.Add(entity);
        }
        return list;
    }
    #endregion

    #region 详情
    public StudentEntity Detail(int stuId)
    {
        string sql = "select * from Student where StuId=@StuId";
        db.PrepareSql(sql);
        db.SetParameter("StuId", stuId);
        DataTable dt = new DataTable();
        dt = db.ExecQuery();
        if (dt.Rows.Count == 0)
            return null;
        StudentEntity entity = new StudentEntity();
        entity.StuId = int.Parse(dt.Rows[0]["StuId"].ToString());
        entity.StuName = dt.Rows[0]["StuName"].ToString();
        entity.StuSex = dt.Rows[0]["StuSex"].ToString();
        entity.StuPhone = dt.Rows[0]["StuPhone"].ToString();
        entity.StuMail = dt.Rows[0]["StuMail"].ToString();
        return entity;
    }
    #endregion
}
```

```
public class AreaDAL
{
    DBHelper db = new DBHelper();
    public List<AreaEntity> GetSon(string dad)
    {
        string sql = "select * from YJ_Area where AreaId like '"+dad+"___'";
        db.PrepareSql(sql);
        DataTable dt  = new DataTable();
        List<AreaEntity> list = new List<AreaEntity>();
        dt = db.ExecQuery();
        foreach (DataRow item in dt.Rows)
        {
            AreaEntity entity = new AreaEntity();
            entity.AreaId = item["AreaId"].ToString();
            entity.AreaName = item["AreaName"].ToString();
            list.Add(entity);
        }
        return list;
    }
}
```

### （2）后端数据模拟

```
public partial class MyResponse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //act
        //check:检查用户名是否可用
        //getson:获取下级区域
        //select:获取所有学生信息
        //add:添加一个学生并且显示
        //edit:编辑学生
        //update:修改
        //delete:删除
        if (Request["act"].Equals("check"))
        {
            ChekcAccount();
        }
        if (Request["act"].Equals("getson"))
        {
            GetSon();
        }
        if (Request["act"].Equals("select"))
        {
            Select();
        }
        if (Request["act"].Equals("add"))
        {
            Add();
        }
        if (Request["act"].Equals("edit"))
        {
            Edit();
        }
        if (Request["act"].Equals("update"))
        {
            Update();
        }
        if (Request["act"].Equals("delete"))
        {
            Delete();
        }
    }

    public void ChekcAccount()
    {
        MemberDAL dal  = new MemberDAL();
        string acc = Request["acc"].ToString();
        bool flag = dal.IsAccCanUse(acc);
        if (flag == true)
            Response.Write("1");
        else
            Response.Write("0");
        Response.End();
    }

    public void GetSon()
    {
        string dad = Request["dad"].ToString();
        AreaDAL dal = new AreaDAL();
        List<AreaEntity> list = new List<AreaEntity>();
        list = dal.GetSon(dad);
        string result = MyJson.ToJsJson(list);
        Response.Write(result);
        Response.End();
    }

    public void Select()
    {
        StudentDAL dal = new StudentDAL();
        List<StudentEntity> list = new List<StudentEntity>();
        list = dal.List();
        Response.Write(MyJson.ToJsJson(list));
        Response.End();
    }

    public void Add()
    {
        StudentDAL dal = new StudentDAL();
        StudentEntity entity = new StudentEntity();
        entity.StuName = Request["StuName"].ToString();
        entity.StuSex = Request["StuSex"].ToString();
        entity.StuPhone = Request["StuPhone"].ToString();
        entity.StuMail = Request["StuMail"].ToString();
        dal.Add(entity);
        Select();
    }

    public void Edit()
    {
        int StuId = int.Parse(Request["StuId"].ToString());
        StudentDAL dal = new StudentDAL();
        StudentEntity entity = new StudentEntity();
        entity = dal.Detail(StuId);
        Response.Write(MyJson.ToJsJson(entity));
        Response.End();
    }

    public void Update()
    {
        StudentEntity entity = new StudentEntity();
        entity.StuId = int.Parse(Request["StuId"].ToString());
        entity.StuName = Request["StuName"].ToString();
        entity.StuSex = Request["StuSex"].ToString();
        entity.StuPhone = Request["StuPhone"].ToString();
        entity.StuMail = Request["StuMail"].ToString();
        StudentDAL dal = new StudentDAL();
        dal.Update(entity);
        Select();
    }

    public void Delete()
    {
        int StuId = int.Parse(Request["StuId"].ToString());
        StudentDAL dal = new StudentDAL();
        dal.Delete(StuId);
        Select();
    }
}
```

### （3）检查用户名是否可用

```
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#check").click(function () {
                var acc = $("#txtAccount").val();
                $.post("MyResponse.aspx", { act: "check", acc: acc },
                    function (result) {
                        if (result == "1") {
                            $("#spanInfo").html("恭喜您，用户名可以使用!");
                        }
                        else {
                            $("#spanInfo").html("对不起，用户名被占用!");
                        }
                    }
                );

            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>用户注册</h1>
        用户名：<asp:TextBox ID="txtAccount" runat="server"></asp:TextBox> 
        <input type="button" id="check" value="检查用户名是否可用" />
        <span id="spanInfo" style=" color:Red"></span>
        <br /><br />
        密码：<asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>  <br /><br />
        电话：<asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>  <br /><br />
        <asp:Button ID="btReg" runat="server" Text="注  册" />

    </div>
    </form>
</body>
</html>
```

### （4）下拉框三级联动

```
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //            $.post("MyResponse.aspx", { act: "getson", dad: "" },
            //               function (data) {
            //                   alert(data.length);
            //               }, "json");

            $("#province").append("<option value='0'>--请选择--</option>");
            $("#city").append("<option value='0'>--请选择--</option>");
            $("#qu").append("<option value='0'>--请选择--</option>");
            //绑定省份
            $("#province").html("");
            $("#province").append("<option value='0'>--请选择--</option>");
            $.getJSON("MyResponse.aspx", { act: "getson", dad: "" },
                    function (arr) {
                        for (var i = 0; i < arr.length; i++) {
                            $("#province").append("<option value='" + arr[i].AreaId + "'>" + arr[i].AreaName + "</option>");
                        }
                    }
                );

            $("#province").change(function () {
                $("#city").html("");
                $("#city").append("<option value=''>--请选择--</option>");
                $("#qu").html("");
                $("#qu").append("<option value=''>--请选择--</option>");
                $.getJSON("MyResponse.aspx", { act: "getson", dad: $("#province").val() },
                    function (arr) {
                        for (var i = 0; i < arr.length; i++) {
                            $("#city").append("<option value='" + arr[i].AreaId + "'>" + arr[i].AreaName + "</option>");
                        }
                    }
                );
            })

            $("#city").change(function () {
                    $("#qu").html("");
                    $("#qu").append("<option value=''>--请选择--</option>");
                    $.getJSON("MyResponse.aspx", { act: "getson", dad: $("#city").val() },
                    function (arr) {
                        for (var i = 0; i < arr.length; i++) {
                            $("#qu").append("<option value='" + arr[i].AreaId + "'>" + arr[i].AreaName + "</option>");
                        }
                    }
                );
            })


        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <select id="province"></select>
        <select id="city"></select>
        <select id="qu"></select>
    </div>
    </form>
</body>
</html>
```

### （5）实现学生信息管理

```
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        div{ line-height:30px;}
    </style>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ShowTable(arrJson) {
            var strTable = "<table width='1000' border='1' id='myTable'>";
            strTable += "<tr><th>编号</th><th>姓名</th><th>性别</th><th>电话</th><th>邮箱</th><th>操作</th></tr>"
            for (var i = 0; i < arrJson.length; i++) {
                strTable += "<tr>";
                strTable += "<td>" + arrJson[i].StuId + "</td>";
                strTable += "<td>" + arrJson[i].StuName + "</td>";
                strTable += "<td>" + arrJson[i].StuSex + "</td>";
                strTable += "<td>" + arrJson[i].StuPhone + "</td>";
                strTable += "<td>" + arrJson[i].StuMail + "</td>";
                strTable += "<td><a href='javascript:void(0);' class='myedit' id='edit_" + arrJson[i].StuId + "'>编辑</a> <a href='javascript:void(0);' class='mydel' id='del_" + arrJson[i].StuId + "'>删除</a></td>";

                strTable += "</tr>";
            }
            strTable += "</table>";
            $("#gvStudent").html(strTable);
        }
        $(function () {
            //查询
            $("#btSearch").click(function () {
                $.getJSON("MyResponse.aspx", { act: "select" }, function (arrJson) {
                    ShowTable(arrJson);
                });
            })
            //添加
            $("#btAdd").click(function () {
                var stuName = $("#txtName").val();
                var stuSex = $("input:radio[name='sex']").val();
                var stuPhone = $("#txtPhone").val();
                var stuMail = $("#txtMail").val();
                $.getJSON("MyResponse.aspx", { act: "add", StuName: stuName, StuSex: stuSex, StuPhone: stuPhone, StuMail: stuMail }, function (arrJson) {
                    ShowTable(arrJson);
                });
            })
            //编辑
            $("#gvStudent").on("click", ".myedit", function () {
                var stuid = $(this).prop("id").split('_')[1];
                $.getJSON("MyResponse.aspx", { act: "edit", StuId: stuid }, function (objJson) {
                    $("#hdId").val(objJson.StuId);
                    $("#txtName2").val(objJson.StuName);
                    $("#txtPhone2").val(objJson.StuPhone);
                    $("#txtMail2").val(objJson.StuMail);
                    if (objJson.StuSex == "男") {
                        $("#rbBoy").prop("checked", true);
                    }
                    else {
                        $("#rbGirl").prop("checked", true);
                    }
                });
            })
            //修改
            $("#btUpdate").click(function () {
                var stuId = $("#hdId").val();
                var stuName = $("#txtName2").val();
                var stuSex = $("input:radio[name='sex2']").val();
                var stuPhone = $("#txtPhone2").val();
                var stuMail = $("#txtMail2").val();
                $.getJSON("MyResponse.aspx", { act: "update", StuId: stuId, StuName:stuName, StuSex: stuSex, StuPhone: stuPhone, StuMail: stuMail }, function (arrJson) {
                    ShowTable(arrJson);
                });
            })
            //删除
            $("#gvStudent").on("click", ".mydel", function () {
                var stuid = $(this).prop("id").split('_')[1];
                $.getJSON("MyResponse.aspx", { act: "delete", StuId: stuid }, function (arrJson) {
                    ShowTable(arrJson);
                });
            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input type="button" value="查询" id="btSearch" />
    </div>
    <div id="gvStudent">
    
    </div>
    <div style=" width:1200px;">
        <div style=" width:600px; float:left;">
            <h2>用户添加</h2>
            <p>姓名：<input type="text" id="txtName" /></p>
            <p>性别：<input type="radio" value="男" name="sex" />男 <input type="radio" value="女" name="sex" />女</p>
            <p>电话：<input type="text" id="txtPhone" /></p>
            <p>邮箱：<input type="text" id="txtMail" /></p>
            <p><input type="button" value="添加" id="btAdd"></p>
        </div>
        <div style=" width:600px; float:left;">
            <input type="hidden" id="hdId" value="0" />
            <h2>用户修改</h2>
            <p>姓名：<input type="text" id="txtName2" /></p>
            <p>性别：<input type="radio" value="男" name="sex2" id="rbBoy" />男 <input type="radio" value="女" name="sex2" id="rbGirl" />女</p>
            <p>电话：<input type="text" id="txtPhone2" /></p>
            <p>邮箱：<input type="text" id="txtMail2" /></p>
            <p><input type="button" value="修改" id="btUpdate"></p>
        </div>
    </div>
    </form>
</body>
</html>
```

