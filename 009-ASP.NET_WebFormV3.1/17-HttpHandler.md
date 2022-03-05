# HttpHandler

在一次ASP.NET请求处理过程中，HttpHandler和HttpModule一样都可以截获的这个请求并做一些额外的工作。

他们的区别在于：

（1）先后次序：先IHttpModule,后IHttpHandler. 注:Module要看你响应了哪个事件，一些事件是在Handler之前

运行的，一些是在Handler之后运行的。

（2）对请求的处理上：IHttpModule是属于大小通吃类型,无论客户端请求的是什么文件,都会调用到它;例如

aspx,rar,html的请求；IHttpHandler则属于挑食类型,只有ASP.net注册过的文件类型(例如aspx,asmx等等)才会轮

到调用它。

（3）IHttpHandler按照你的请求 生成响应的内容，IHttpModule对请求进行预处理，如验证、修改、过滤等等，

同时也可以对响应进行处理。

## 一、HttpHandler实现验证码

**在项目中创建一般处理程序文件“ValidateImageHandle.ashx”。**

```
<%@ WebHandler Language="C#" Class="ValidateImageHandle" %>
using System;
using System.Web;
using System.Drawing;
/*
HttpHandler中默认是不能使用Session的。
解决方法：
1、读取Session时：实现System.Web.SessionState.IReadOnlySessionState接口，无任何方法（只是一个标记作用）
2、保存Session时：实现System.Web.SessionState.IRequiresSessionState接口
 */
public class ValidateImageHandle : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    
    public void ProcessRequest (HttpContext context) {
        //context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        string strCode = CreateRnd();
        context.Session["validate"] = strCode;
        byte[] bytes = CreateImage(strCode);
        context.Response.ContentType = "image/gif";
        context.Response.BinaryWrite(bytes);
    }
    
    public bool IsReusable {
        get {
            return false;
        }
    }

    #region 生成随机验证码
    public string CreateRnd()
    {
        Random Rnd = new Random();
        string RndChars = "";
        char code;
        for (int i = 1; i <= 4; i++)
        {
            if (Rnd.Next() % 2 == 0) //偶数生成数字
            {
                code = (char)('0' + Rnd.Next(0, 10));
            }
            else //奇数生成字母
            {
                code = (char)('A' + Rnd.Next(0, 10));
            }
            RndChars = RndChars + code.ToString();
        }
        return RndChars;
    }
    #endregion

    #region 将验证码生成图片
    public byte[] CreateImage(string RndChars)
    {
        Random Rnd = new Random();
        System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(RndChars.Length * 15, 26);
        Graphics g = Graphics.FromImage(bitmap);
        g.Clear(Color.Gray); //清空图片，设置背景为灰色
        //画图片噪线
        for (int i = 1; i <= Rnd.Next(10, 30); i++)
        {
            int x1 = Rnd.Next(1, bitmap.Width);
            int x2 = Rnd.Next(1, bitmap.Width);
            int y1 = Rnd.Next(1, bitmap.Height);
            int y2 = Rnd.Next(1, bitmap.Height);
            g.DrawLine(new Pen(Color.Green), x1, y1, x2, y2);
        }
        //画验证码字符串
        Font font = new Font("微软雅黑", 12, (FontStyle.Bold | FontStyle.Italic));
        System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new RectangleF(0, 0, bitmap.Width, bitmap.Height), Color.Red, Color.Blue, 1.2f, true);
        g.DrawString(RndChars, font, brush, 2, 2);
        //画图片噪点
        for (int i = 0; i <= Rnd.Next(50, 100); i++)
        {
            int x = Rnd.Next(1, bitmap.Width);
            int y = Rnd.Next(1, bitmap.Height);
            bitmap.SetPixel(x, y, Color.Red);
        }
        //画图片边框线
        g.DrawRectangle(new Pen(Color.Black), 0, 0, bitmap.Width - 1, bitmap.Height - 1);
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
        return ms.ToArray();
    }
    #endregion
}
```

**用户登录使用验证码：**

```
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>httpHandler实现验证码</title>
    <script src="js/jquery.js" type="text/javascript"></script>
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
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript">
        //alert(new Date());
        $(function () {
            $("#Refresh").click(function () {
                $("#imgValidate").prop("src", "ValidateImageHandle.ashx?date=" + new Date());
            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>httpHandler实现验证码-先复习之前案例中验证码的实现</h1>
        <table>
            <tr>
                <td align="center" height="30" class="mytitle" colspan="2">用户登录</td>
            </tr>
            <tr>
                <td align="right" class="lefted" height="30">用户名:</td>
                <td align="left" class="righttd" height="30">
                    <asp:TextBox ID="txtAccount" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="lefted" height="30">密码:</td>
                <td align="left" class="righttd" height="30">
                    <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="lefted" height="30">验证码:</td>
                <td align="left" class="righttd" height="30">
                    <asp:TextBox ID="txtValidate" runat="server" Width="72px"></asp:TextBox>
                    <asp:Image ID="imgValidate" runat="server" ImageUrl="~/ValidateImageHandle.ashx" />
                        <a href="javascript:void(0);" id="Refresh">刷新</a>
                </td>
            </tr>
            <tr>
                <td align="right" class="lefted" height="30"></td>
                <td align="left" class="righttd" height="30">
                    <asp:Button ID="btLogin" runat="server" Text="登  录" onclick="btLogin_Click" />
                </td>
            </tr>
            <tr>
                <td align="right" class="lefted" height="30"></td>
                <td align="left" class="righttd" height="30">
                    <asp:Label ID="lblErrInfo" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
```

```
public partial class Demo01 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region 登录
    protected void btLogin_Click(object sender, EventArgs e)
    {
        if (Session["validate"] == null)
        {
            this.lblErrInfo.Text = "验证码过期";
            this.imgValidate.ImageUrl = "~/ValidateImageHandle.ashx"; //加载验证码
            return;
        }
        if (this.txtValidate.Text.Equals(Session["validate"].ToString()) == false)
        {
            this.lblErrInfo.Text = "验证码错误!";
        }
        else
        {
            this.lblErrInfo.Text = "验证码正确";
        }
    }
    #endregion
}
```

## 二、HttpHandler实现图片水印

HttpHandler实现图片水印在此文中有两种方式来实现：

（1）创建ashx文件进行二次绘图，C#程序中调用ashx文件实现水印添加。

（2）创建CS类文件进行二次绘图，通过配置文件配置路径规则给指定路径下的文件实现水印添加。

### 方案一

**在项目中创建一般处理程序文件“ImgHandler.ashx”。**

```
<%@ WebHandler Language="C#" Class="ImgHandler" %>
using System;
using System.Web;
using System.Drawing;
public class ImgHandler : IHttpHandler { 
    public void ProcessRequest (HttpContext context) {
        //context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        string vpath = context.Request.QueryString["ImageUrl"]; //虚拟路径
        string ppath = context.Server.MapPath(vpath); //根据虚拟路径获得物理路径
        Image img = Image.FromFile(ppath);   //根据绝对路径获取图片
        Graphics gh = Graphics.FromImage(img);  //绘画对象
        Image imgWaterMark = Image.FromFile(context.Server.MapPath("~/img/watermark.png"));
        float w = img.Width;
        float h = img.Height;
        float x = 6;
        float y = 6;
        gh.DrawImage(imgWaterMark, x, y, w, h);  //进行二次绘图
        context.Response.ContentType = "image/jpeg";
        img.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
}
```

**页面中实现图片水印：**

```
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>httpHandle给图片添加水印</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="pnlImages" runat="server">
            <asp:Image ID="Image2" runat="server" Width="200" Height="240" ImageUrl="~/img/book/5566e4b4Nb156fe14.jpg" />
            <asp:Image ID="Image3" runat="server" Width="200" Height="240" ImageUrl="~/img/book/5573e4b4Nb1561288.jpg" />
            <asp:Image ID="Image5" runat="server" Width="200" Height="240" ImageUrl="~/img/book/55b8a409N20918431.jpg" />
            <asp:Image ID="Image6" runat="server" Width="200" Height="240" ImageUrl="~/img/book/9787020096466.jpg" />
            <asp:Image ID="Image7" runat="server" Width="200" Height="240" ImageUrl="~/img/book/9787020096473.jpg" />
        </asp:Panel>        
    </div>
    </form>
</body>
</html>
```

```
public partial class Demo02 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        foreach (Control obj in pnlImages.Controls)
        {
            Image img = obj as Image;
            if (img != null)
            {
                string imgurl = img.ImageUrl;
                img.ImageUrl = "~/ImgHandler.ashx?ImageUrl=" + Server.UrlEncode(imgurl);
            }
        }
    }
}
```

### 方案二

**在App_Code文件夹创建“MyImgHandle.cs”文件。**

```
public class MyImgHandle:IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        //context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        string vpath = context.Request.Path; //获取配置文件中配置的路径
        string ppath = context.Server.MapPath(vpath); //根据虚拟路径获得物理路径
        Image img = Image.FromFile(ppath);   //根据绝对路径获取图片
        Graphics gh = Graphics.FromImage(img);  //绘画对象
        Image imgWaterMark = Image.FromFile(context.Server.MapPath("~/img/watermark.png"));
        float w = img.Width;
        float h = img.Height;
        float x = 6;
        float y = 6;
        gh.DrawImage(imgWaterMark, x, y, w, h);  //进行二次绘图
        //context.Response.ContentType = "image/jpeg";
        img.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}
```

**根目录web.config配置文件：**

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
		<httpHandlers>
			<add type="MyImgHandle" path="img/book/*.*" verb="*"/>
		</httpHandlers>
	</system.web>
	<!--IIS7配置-->
	<!--<system.webServer>
    <handlers>
      <add name="MyImgHandle" path="img/book/*.*" type="MyImgHandle" verb="*"/>
    </handlers>
  </system.webServer>-->
</configuration>
```

**页面测试水印效果：**

```
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>httpHandle给图片添加水印-将Handle写在类文件中用配置文件来调用</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <asp:Panel ID="pnlImages" runat="server">
            <asp:Image ID="Image2" runat="server" Width="200" Height="240" ImageUrl="~/img/book/5566e4b4Nb156fe14.jpg" />
            <asp:Image ID="Image3" runat="server" Width="200" Height="240" ImageUrl="~/img/book/5573e4b4Nb1561288.jpg" />
            <asp:Image ID="Image5" runat="server" Width="200" Height="240" ImageUrl="~/img/book/55b8a409N20918431.jpg" />
            <asp:Image ID="Image6" runat="server" Width="200" Height="240" ImageUrl="~/img/book/9787020096466.jpg" />
            <asp:Image ID="Image7" runat="server" Width="200" Height="240" ImageUrl="~/img/book/9787020096473.jpg" />
        </asp:Panel>       
    </div>
    <div>
        <asp:Image ID="Image1" runat="server" Width="200" Height="240" ImageUrl="~/img/nba/lunnade.jpg" />
        <asp:Image ID="Image4" runat="server" Width="200" Height="240" ImageUrl="~/img/nba/maidi.jpg" />
        <asp:Image ID="Image8" runat="server" Width="200" Height="240" ImageUrl="~/img/nba/nashi.jpg" />
    </div>
    </form>
</body>
</html>
```

