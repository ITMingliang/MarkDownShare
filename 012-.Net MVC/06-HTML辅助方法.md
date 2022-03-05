# HTML辅助方法

## 一、Html.ActionLink

输出超链接使用的HTML辅助方法是Html.ActionLink，常见有以下几种写法：

```
<p>@Html.ActionLink("课程内容", "WelcomeForm")</p>
<p>@Html.ActionLink("课程内容", "WelcomeForm", "Home")</p>
<p>@Html.ActionLink("课程内容", "WelcomeForm", new {name="刘德华",sex="男" })</p>
<p>@Html.ActionLink("课程内容", "WelcomeForm", "Home",new { name = "刘亦菲", sex = "女" },null)</p>
<p>@Html.ActionLink("课程内容", "WelcomeForm", "Home", new { name = "刘亦菲", sex = "女" },new { target="_blank" })</p>
```

## 二、输出表单

输出表单相关标签的方法如下表：

| HTML辅助方法        | 说明                             |
| ------------------- | -------------------------------- |
| Html.BeginForm()    | 输出<form>标签                   |
| Html.CheckBox()     | 输出<input  type="checkbox">标签 |
| Html.DropDownList() | 输出<select>标签                 |
| Html.Password()     | 输出<input  type="password">标签 |
| Html.RadioButton()  | 输出<input  type="radio">标签    |
| Html.TextArea()     | 输出<textarea/>标签              |
| Html.TextBox()      | 输出<input  type="text">标签     |

**用户注册代码如下：**

```
<div> 
    <h1>用户注册</h1>
    @using (Html.BeginForm("Demo02Save","Home",FormMethod.Post))
    {
        <p>账用户名: @Html.TextBox("txtAccount")</p>
        <p>密码: @Html.Password("txtPwd")</p>
        <p>密码确认: @Html.Password("txtPwdConfirm")</p>
        <p>
            所学专业: @Html.DropDownList("selPro",new List<SelectListItem>() {
                    new SelectListItem() { Value="",Text="--请选择--" },
                    new SelectListItem() { Value="1",Text="计算机技术" },
                    new SelectListItem() { Value="2",Text="电子商务" },
                    new SelectListItem() { Value="3",Text="国际贸易" },
                    new SelectListItem() { Value="4",Text="工商管理" },
                })
        </p>
        <p>
            性别:
            @(Html.RadioButton("sex","男",new { id="boy"})) 男
            @(Html.RadioButton("sex","女",new { id="girl"})) 女
        </p>
        <p>
            爱好:
            @(Html.CheckBox("hobby", new { value= "抽烟" })) 抽烟
            @(Html.CheckBox("hobby", new { value = "喝酒" })) 喝酒
            @(Html.CheckBox("hobby", new { value = "烫头发" })) 烫头发
            @(Html.CheckBox("hobby", new { value = "足球" })) 足球
        </p>
        <p>
            自我介绍:
            @Html.TextArea("aboutme", new { rows=10,cols=100 })
        </p>
        <p>
            <input type="submit" value="注册" />
        </p>
    }
</div>
```

## 三、创建自定义辅助方法

本案例实现一个UL+LI的自定义列表辅助方法，即在视图上直接输入如下代码，可以自动生成UL+LI的列表：

```
@Html.UL(new string[] { "谷歌","苹果","阿里巴巴","华为","腾讯"})
```

步骤如下：

（1）在项目中创建Helpers文件夹，文件夹中创建MyHtmlHelper类，并将类修改成静态类，类代码如下：

```
public static class ULHelper
{
    public static MvcHtmlString UL(this HtmlHelper htmlHelper, string[] arrLi)
    {
        TagBuilder tagUL = new TagBuilder("ul");
        foreach (string item in arrLi)
        {
            TagBuilder tagLI = new TagBuilder("li");
            tagLI.SetInnerText(item);
            tagUL.InnerHtml += tagLI.ToString();
        }
        return new MvcHtmlString(tagUL.ToString());
    }    
}
```

（2）在需要使用此辅助方法的地方引入命名空间，编写代码实现列表。

```
@Html.UL(new string[] { "谷歌","苹果","阿里巴巴","华为","腾讯"})
```

## 四、分布视图

### （1）Partial和RenderPartial

网页结构如果是上中下结构，上和下为分布视图，中间为普通视图内容，引入上和下，代码如下：

Top.cshtml：

```
<h1>我是网页顶部</h1>
```

Foot.cshtml:

```
<h1>我是网页底部</h1>
```

Demo01.cshtml

```
@Html.Partial("~/Views/Home/Top.cshtml")
<div style="height:100px;"> 
    Demo01
</div>
@Html.Partial("~/Views/Home/Foot.cshtml")
```

或

```
@{ 
    Html.RenderPartial("~/Views/Home/Top.cshtml");
}
<div style="height:100px;"> 
    Demo01
</div>
@{
    Html.RenderPartial("~/Views/Home/Foot.cshtml");
}
```

其中Partial和RenderPartial区别如下：

（1）Partial是将视图内容直接生成一个字符串并返回（相当于有个转义的过程），直接使用@输出。

（2）RenderPartial方法是直接输出至当前 HttpContext（因为是直接输出，所以性能好），需要编写在@{}代码中。

### （2）Action和RenderAction

网页结构如果是上中中下结构，上和下为分布视图，中间第一块内容为普通视图内容，中间第二块为Action返回的超级链接集合，使用普通视图引入其他三块分布视图，代码如下：

Top.cshtml：

```
<h1>我是网页顶部</h1>
```

Foot.cshtml:

```
<h1>我是网页底部</h1>
```

友情链接类：

```
public class FrindLink
{
    public FrindLink() { }
    public FrindLink(string txt, string address)
    {
        this.Txt = txt;
        this.Address = address;
    }
    public string Txt { get; set; }  //文本
    public string Address { get; set; } //链接地址
}
```

友情链接Action:

```
public ActionResult FrindLinkForm()
{
    List<FrindLink> list = new List<FrindLink>();
    list.Add(new FrindLink("百度", "http://www.baidu.com"));
    list.Add(new FrindLink("Google", "http://g.cn"));
    list.Add(new FrindLink("必应", "http://bing.com"));
    list.Add(new FrindLink("搜狗", "http://www.sougou.com"));
    ViewBag.List = list;
    return View();
}
```

友情链接View:

```
<p>
    @foreach (var item in ViewBag.List)
    {
        <a href="@item.Address">@item.Txt</a> @:&nbsp;
    }
</p>
```

Demo02.cshtml:

```
@Html.Partial("~/Views/Home/Top.cshtml")
<div style="height:100px;">
	Demo02
</div>
@Html.Action("FrindLinkForm")
@Html.Partial("~/Views/Home/Foot.cshtml")
```

或

```
@Html.Partial("~/Views/Home/Top.cshtml")
<div style="height:100px;">
    Demo02
</div>
@{ 
    Html.RenderAction("FrindLinkForm");
}
@Html.Partial("~/Views/Home/Foot.cshtml")
```

其中Action和RenderAction的区别如下：

Action是执行单独的控制器并且显示结果，Action与RenderAction不同的是，Action返回的是字符串,而RenderAction是写入响应流，因此RenderAction是要写在代码中。

