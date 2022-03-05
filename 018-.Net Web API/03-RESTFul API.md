# RESTFul API

RESTful API 是基于HTTP协议产生的一种相对简单的API设计方案；

RESTful 的核心是 everything is a “resource”，所有的HTTP action，都应该是相应resource上可以被操作和处理的，而API 就是对资源的管理操作，而这个具体操作是由 HTTP action 指定的。

使用HTTP的GET、POST、DELETE、PUT来表示对于资源的增删改查。

- GET：读取（Read）
- POST：新建（Create）
- PUT：更新（Update）
- DELETE：删除（Delete）

学习资料准备：

（1）用于测试的实体类：

```
public class Student
{
    public string StuNo { get; set; }    //学号
    public string StuName { get; set; }  //姓名
    public string StuSex { get; set; }   //性别
}
```

（2）模拟的测试数据（编写在webapi类的构造函数中）：

```
public static List<Student> StuList { get; set; }
public ServerController()
{
    StuList = new List<Student>();
    StuList.Add(new Student { StuNo = "001", StuName = "孙悟空", StuSex = "男" });
    StuList.Add(new Student { StuNo = "002", StuName = "猪八戒", StuSex = "男" });
    StuList.Add(new Student { StuNo = "003", StuName = "白骨精", StuSex = "女" });
}
```

## 一、获取所有数据

**API接口：**

```
[HttpGet]
public List<Student> GetList([FromBody]dynamic obj)
{
	return StuList;
}
```

**接口测试：**

![011](img\011.PNG)



## 二、获取详情

**API接口：**

```
[HttpGet]
public Student GetDetail(string id)
{
	Student stu = StuList.SingleOrDefault(p => p.StuNo.Equals(id));
	return stu;
}
```

**接口测试：**

![011](img\012.PNG)

## 三、新增数据

**API接口：**

```
[HttpPost]
public IHttpActionResult Add([FromBody] Student stu)
{
    StuList.Add(stu);
    return Json(new { msg = "添加成功!",data=StuList });
}
```

**接口测试：**

![013](img\013.PNG)

## 四、修改数据

**API接口：**

```
[HttpPut]
public IHttpActionResult Update(string id, [FromBody] Student stu)
{
    Student model = StuList.SingleOrDefault(p => p.StuNo.Equals(id));
    if (model == null)
    	return Json(new { msg = "修改的数据不存在!" });
    model.StuNo = stu.StuNo;
    model.StuName = stu.StuName;
    model.StuSex = stu.StuSex;
    return Json(new { msg = "修改成功!", data = model });
}
```

**接口测试：**

![014](img\014.PNG)

## 五、删除数据

**API接口：**

```
[HttpDelete]
public IHttpActionResult Delete(string id)
{
    Student model = StuList.SingleOrDefault(p => p.StuNo.Equals(id));
    if (model == null)
    	return Json(new { msg = "删除的数据不存在!" });
    StuList.Remove(model);
    return Json(new { msg = "删除成功!", data = StuList });
}
```

**接口测试：**

![015](img\015.PNG)

## 六、特性路由

### (1) 基本路由映射

**API接口：**

```
[HttpGet]
[Route("api/Route/Basic")]
public IHttpActionResult GetBasic()
{
	return Json(new { msg = "测试基本的特性路由!" });
}
```

**接口访问地址：**

```
http://localhost:60650/api/Route/Basic
```

### (2) 路由映射参数

**API接口：**

```
[HttpGet]
[Route("api/Route/Param/{id}/{name}")]
public IHttpActionResult Get2(string id,string name)
{
	return Json(new { msg = "测试路由映射参数!",data = new { id= id,name=name } });
}
```

**接口访问地址：**

```
http://localhost:60650/api/Route/Param/001/孙悟空
```

### (3) 多重特性路由

**API接口：**

```
[HttpGet]
[Route("api/Route/Multiple1/{id}/{name}")]
[Route("api/Route/Multiple2/{id}/{name}")]
public IHttpActionResult Get3(string id,string name)
{
	return Json(new { msg = "测试多重特性路由!",data = new { id= id,name=name } });
}
```

**接口访问地址：**

```
http://localhost:60650/api/Route/Multiple1/001/孙悟空
```

或

```
http://localhost:60650/api/Route/Multiple2/001/孙悟空
```

### (4) 缺省参数路由

**API接口：**

```
[HttpGet]
[Route("api/Route/Default/{id}/{name?}")]
public IHttpActionResult Get4(string id, string name="孙悟空")
{
    return Json(new { msg = "测试缺省参数路由!", data = new { id = id, name = name } });
}
```

或

```
[HttpGet]
[Route("api/Route/Default/{id}/{name=孙悟空}")]
public IHttpActionResult Get4(string id, string name)
{
	return Json(new { msg = "测试缺省参数路由!", data = new { id = id, name = name } });
}
```

**接口访问地址：**

```
http://localhost:60650/api/Route/Default/001
```

### (5) 参数约束路由

ASP.NET Web API内置约束有下面这些：

```
{x:alpha} 约束大小写英文字母
{x:bool}
{x:datetime}
{x:decimal}
{x:double}
{x:float}
{x:guid}
{x:int}
{x:length(6)}
{x:length(1,20)} 约束长度范围
{x:long}
{x:maxlength(10)}
{x:min(10)}
{x:range(10,50)}
{x:regex(正则表达式)}
```

可以设置多个约束：

```
[Route("api/Route/orders/{id:int:min(1)}")]
```

**API接口：**

```
[HttpGet]
[Route("api/Route/Check/{id:range(1,100)}/{name}")]
public IHttpActionResult Get5(int id, string name)
{
	return Json(new { msg = "测试参数约束路由!", data = new { id = id, name = name } });
}
```

**接口访问地址：**（以下地址可以正常访问接口）

```
http://localhost:60650/api/Route/Check/11/孙悟空
```

**接口访问地址：**（以下地址无法访问接口）

```
http://localhost:60650/api/Route/Check/101/孙悟空
```

### (6) 通配符(*)路由变量

**API接口：**

```
[HttpGet]
[Route("api/Route/Date/{id:range(1,100)}/{name}/{*birthday}")]
public IHttpActionResult Get6(int id, string name,DateTime birthday)
{
	return Json(new { msg = "*使用!", data = new { id = id, name = name,birthday = birthday.ToString("yyyy年MM月dd日") } });
}
```

**接口访问地址：**

```
http://localhost:60650/api/Route/Date/1/jack/1988-8-8
```

**接口访问地址：**（此地址如果在路由中没有*则无法访问，因为程序会认为“1988/8/8”是三个参数，而不是一个参数）

```
http://localhost:60650/api/Route/Date/1/jack/1988/8/8
```

### (7) 路由映射复杂参数

**给实体类添加特性使其支持绑定：**

```
[ModelBinder]
public class Student
{
	public string StuNo { get; set; }    //学号
	public string StuName { get; set; }  //姓名
	public string StuSex { get; set; }   //性别
}
```

**方案一API接口：**

```
[HttpGet]
[Route("api/Route/Class/{stu.StuNo}/{stu.StuName}/{stu.StuSex}")]
public IHttpActionResult Get7(Student stu)
{
	return Json(new { msg = "路由映射复杂参数!", data = stu });
}
```

**方案一接口访问地址：**

```
http://localhost:60650/api/Route/Class/001/jack/man
```

**方案二API接口：**

```
[HttpGet]
[Route("api/Route/Class")]
public IHttpActionResult Get7(Student stu)
{
	return Json(new { msg = "路由映射复杂参数!", data = stu });
}
```

**方案二接口访问地址：**

```
http://localhost:60650/api/Route/Class?stu.StuNo=001&stu.StuName=jack&stu.StuSex=man
```

### (8) 路由前缀

**在控制器类上定义路由前缀：**

```
[RoutePrefix("api/Prefix")]
public class PrefixController : ApiController
{

}
```

**路由前缀API接口：**

```
[Route("Basic")]
public IHttpActionResult Get1()
{
	return Json(new { msg = "测试路由前缀!" });
}
```

**接口访问地址：**

```
http://localhost:60650/api/Prefix/Basic
```

**取消路由前缀API接口：**

```
[Route("~/api/Cancel/Basic")]  //通过~/取消路由前缀
public IHttpActionResult Get2()
{
	return Json(new { msg = "取消路由前缀!" });
}
```

**接口访问地址：**

```
http://localhost:60650/api/Cancel/Basic
```













