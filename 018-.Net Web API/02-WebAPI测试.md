# WebAPI测试

如果项目采取前后端分离的模式进行开发，那么我们的WebAPI最终是需要提供给前端页面来进行调用的。

那么在进行对接之前必须要保证我们的WebAPI没有Bug，在这种情况下作为开发者对API的自行测试就显得尤为重要。

WebAPI的测试推荐两种方式进行：

（1）使用PostMan测试WebAPI；		（2）在WebAPI中集成Swagger；

## 一、利用PostMan测试WebAPI

**PostMan的安装和基本使用：**

1.官方下载地址：https://www.postman.com/downloads/

2.启动后可以跳过输入账号步骤

![002](img\002.png)

3.点击+号或者“新建请求”来创建一个新的请求

![003](img\003.png)

4.PostMan的工作界面

![004](img\004.png)

### （1）测试Get接口

**实体类：**

```
public class Student
{
    public string StuNo { get; set; }    //学号
    public string StuName { get; set; }  //姓名
    public string StuSex { get; set; }   //性别
    public Student(string no, string name, string sex)
    {
   		this.StuNo = no;    this.StuName = name;    this.StuSex = sex;
    }
}
```

**API接口：**

```
public List<Student> Get()
{
    List<Student> list = new List<Student>();
    list.Add(new Student("001", "孙悟空", "男"));
    list.Add(new Student("002", "猪八戒", "男"));
    list.Add(new Student("003", "白骨精", "女"));
    return list;
}
```

**接口测试：**

【1】输入API地址；

【2】请求方法选择GET；

![005](img\005.PNG)

### （2）测试POST接口

【1】输入API地址；

【2】请求方法选择POST；

【3】在Body中输入请求体中的参数名和值；

**实体类：**

```
public class Student
{
    public string StuNo { get; set; }    //学号
    public string StuName { get; set; }  //姓名
    public string StuSex { get; set; }   //性别
    public Student(string no, string name, string sex)
    {
   		this.StuNo = no;    this.StuName = name;    this.StuSex = sex;
    }
}
```

**API接口：**

```
public IHttpActionResult Post([FromBody] Student stu)
{
    string str = string.Format("Post类型获取的数据(学号:{0},姓名:{1},性别:{2})", stu.StuNo, stu.StuName, stu.StuSex);
    return Json(new { Msg = str });
}
```

**接口测试：**

![006](img\006.PNG)

### （3）其它接口测试

常见的接口类型有GET,POST,PUT,DELETE类型，其中PUT类型和DELETE类型的测试在学习后面的RESTFul API中可进行。



## 二、在WebAPI中集成Swagger

在使用WebAPI开发完接口之后，编写API说明文档是一件繁琐的事情，但是有了Swagger，就可以快速地自动生成API说明。

Swagger 是一个规范和完整的框架，用于可视化地生成、描述、调用WebAPI文档。

【1】打开Nuget 包管理软件，查找 swagger，进行Swashbuckle 组件的安装

![007](img\007.png)

【2】开启项目的XML注释位置（选中项目，右键-->属性-->生成-->输出-->XML文档文件）

![008](img\008.png)

【3】在App_Start中中会自动生成SwaggerConfig配置文件，对此文件进行修改。

找到如下代码，修改版本号及标题：

```
c.SingleApiVersion("v1", "Chp02-项目测试");
```

找到如下代码，将注释进行打开:

```
//c.IncludeXmlComments(GetXmlCommentsPath());
```

添加GetXmlCommentsPath()函数，函数中的路径填写步骤2中设置的路径

```
public static string GetXmlCommentsPath()
{
	return $@"{System.AppDomain.CurrentDomain.BaseDirectory}\bin\WebApplication1.XML";
}
```

【4】访问Swagger UI，通过如下地址访问：

```
http://localhost:65075/swagger
```

如果Swagger UI中中文显示乱码，则可以选中SwaggerConfig文件，选择文件-->高级保存选项，将编码设置为UTF-8。

![009](img\009.PNG)

【5】利用Swagger UI进行API接口的测试：

![010](img\010.PNG)













