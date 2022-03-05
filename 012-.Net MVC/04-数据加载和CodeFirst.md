# 数据加载和CodeFirst

## 一、资料准备

数据库：

```
create table Dept --部门信息
(
	DeptId int primary key identity(1,1),
	DeptName varchar(50) not null
)

create table Employee	--员工信息
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

## 二、加载关联表的方式

EF框架提供了三种加载关联表的方式：

（1）延迟加载；		（2）贪婪加载；		（3）显示加载；

延迟加载：只在需要的时候加载数据，当对象使用的时候，再去数据库中加载。

贪婪加载：一次性把数据组织好，加载到内存。

显示加载：这种方式类似于延迟加载，除非需要在代码中显式获取数据，在你访问导航属性时，不会出现自动加载。

**备注：**此处的加载数据方式，是在EF框架中的应用，并且EF框架中主表和从表之间是由主外键关系的，如果没有关系，是不能自动关联出关联数据的。

### （1）延迟加载

EF默认支持延迟加载：

**案例演示：**

Action:

```
//关联表延迟加载
public ActionResult Demo01()
{
    MyDbContext db = new MyDbContext();
    var empDetail = (from emp in db.Employee
                        where emp.EmpId == 1
                        select emp).SingleOrDefault();
    ViewBag.EmpName = empDetail.EmpName;
    ViewBag.EmpPhone = empDetail.EmpPhone;
    //以上代码是没有加载部门信息的，只有下面要用到才会延迟加载
    ViewBag.DeptName = empDetail.Dept.DeptName;
    return View();
}
```

View:

```
<div> 
    <h2>基本信息如下:</h2>
    <h3>姓名:@ViewBag.EmpName</h3>
    <h3>电话:@ViewBag.EmpPhone</h3>
    <h3>部门:@ViewBag.DeptName</h3>
</div>
```

### （2）关闭延迟加载

关闭延迟加载有以下几种方案：

【1】直接在数据库上下文中关闭延迟加载，此方法将EF中所有具有主从关系的模型进行了关闭延迟加载。

在数据库上下文类的构造函数中添加如下代码：

```
//关闭主从表延时加载
public MyDbContext()
{
	Configuration.LazyLoadingEnabled = false;
}
```

【2】在功能需要的地方关闭延迟加载，此方法只在主动编写关闭的地方进行关闭了延迟加载，例如：

```
public ActionResult Demo02()
{
    MyDbContext db = new MyDbContext();
    db.Configuration.LazyLoadingEnabled = false;
    //.......
    //.......
    return View();
}
```

【3】直接在模型类中去掉virtual关键字，此方法只关闭了特定的主从表获取数据时候的延迟加载，例如：

```
public class Employee
{
    //......
    //......
    //......
    public virtual Dept Dept { get; set; }
}
```

将此处的Virtual去掉,变成如下：

```
public class Employee
{
    //......
    //......
    //......
    public Dept Dept { get; set; }
}
```

### （3）贪婪加载

使用贪婪加载模式，需要先关闭延迟加载，关闭延迟加载的方法在上面已经进行了介绍。

**案例演示：**

Action:

```
//关联表贪婪加载(需要先关闭延迟加载)
public ActionResult Demo02()
{
    MyDbContext db = new MyDbContext();
    var empList = db.Employee.Include("Dept");
    //var empList = db.Employee;
    //此时查询员工信息会将部门信息一起查询出来
    var empDetail = (from emp in empList
                        where emp.EmpId == 1
                        select emp).SingleOrDefault();
    ViewBag.EmpName = empDetail.EmpName;
    ViewBag.EmpPhone = empDetail.EmpPhone;
    ViewBag.DeptName = empDetail.Dept.DeptName;
    return View();
}
```

View:

```
<div>
    <h2>基本信息如下:</h2>
    <h3>姓名:@ViewBag.EmpName</h3>
    <h3>电话:@ViewBag.EmpPhone</h3>
    <h3>部门:@ViewBag.DeptName</h3>
</div>
```

### （4）显示加载

关闭延迟加载后,单纯查询主表的数据,后面又想再次查询从表,这个时候就需要用到显示加载了.

**案例演示：**

Action:

```
//显示加载（关闭延迟加载后，已经取出主表数据，此时无法取出从表数据，这里就需要显示加载来读取数据）
public ActionResult Demo03()
{
    MyDbContext db = new MyDbContext();
    var empDetail = (from emp in db.Employee
                        where emp.EmpId == 1
                        select emp).SingleOrDefault();
    //如果关闭了延迟加载，则此时已经取出了员工信息，后面默认无法取出部门信息
    //下列第三行代码会报错
    //ViewBag.EmpName = empDetail.EmpName;
    //ViewBag.EmpPhone = empDetail.EmpPhone;
    //ViewBag.DeptName = empDetail.Dept.DeptName;

    //此时可以使用显示加载解决此问题
    db.Entry(empDetail).Reference("Dept").Load();
    ViewBag.EmpName = empDetail.EmpName;
    ViewBag.EmpPhone = empDetail.EmpPhone;
    ViewBag.DeptName = empDetail.Dept.DeptName;
    return View();
}
```

View:

```
<div>
    <h2>基本信息如下:</h2>
    <h3>姓名:@ViewBag.EmpName</h3>
    <h3>电话:@ViewBag.EmpPhone</h3>
    <h3>部门:@ViewBag.DeptName</h3>
</div>
```

## 三、Code First

Code First指“代码优先”，编写代码后系统将自动创建模型和数据库。

Code First 开发模式打破了服务器程序开发的基本规则：“如果数据库没有准备就绪，不要轻举妄动”。Code First 允许开发人员重点关注业务领域并根据类来为该

领域建模。

**Code First演示：**

【1】在nuget中安装EntityFramework。

【2】在Models中编写实体类（参照代码Dept.cs和Employee.cs）

```
public class Dept
{
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public int DeptId { get; set; }
    public string DeptName { get; set; }
}
```

```
public class Employee
{
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public int EmpId { get; set; }
    public string EmpName { get; set; }
    public string EmpPhone { get; set; }
    public string EmpArea { get; set; }
    public decimal EmpSalary { get; set; }
}
```

【3】在Models中编写数据库上下文（参照代码MyDbContext.cs）

```
//DbContext:需要在nuget中安装EntityFramework,并且using System.Data.Entity;
public class MyDbContext:DbContext
{
    public DbSet<Dept> Dept { get; set; }
    public DbSet<Employee> Employee { get; set; }
    //关闭主从表延时加载
    //public MyDbContext()
    //{
    //    Configuration.LazyLoadingEnabled = false;
    //}
}
```

【4】在配置文件configuration根节点中添加数据库连接字符串（参照web.config文件）

注意：

（1）连接字符串的名字要和数据库上下文的类名相同。

（2）providerName不能设置为EntityClient，需要修改为SqlClient

```
<connectionStrings>
  <!--此处的名字要和数据库上下文的类名相同-->
  <add name="MyDbContext" connectionString="Server=.;Database=DBTEST;uid=sa;pwd=123456;MultipleActiveResultSets=true;" providerName="System.Data.SqlClient" />
</connectionStrings>
```

【5】添加控制器和视图，进行数据库的初始化操作（参照Home控制器中的InstallForm）

Action:

```
public ActionResult InstallForm()
{
    MyDbContext db = new MyDbContext();
    //创建数据库
    db.Database.CreateIfNotExists();

    //数据库中添加测试数据(如果不添加数据，此处代码可以注释)
    Dept dept1 = new Dept();
    dept1.DeptName = "开发部";
    Dept dept2 = new Dept();
    dept2.DeptName = "测试部";
    db.Dept.Add(dept1);
    db.Dept.Add(dept2);
    Employee emp1 = new Employee();
    emp1.EmpName = "刘德华";
    emp1.EmpPhone = "13558785454";
    emp1.EmpArea = "武汉";
    emp1.EmpSalary = 5000;
    emp1.Dept = dept1;
    Employee emp2 = new Employee();
    emp2.EmpName = "周杰伦";
    emp2.EmpPhone = "13885858695";
    emp2.EmpArea = "武汉";
    emp2.EmpSalary = 6000;
    emp2.Dept = dept2;
    db.Employee.Add(emp1);
    db.Employee.Add(emp2);
    db.SaveChanges();
            
    return View();
}
```

View:

```
<div> 
    <h1>数据初始化成功！</h1>
</div>
```

【6】执行InstallForm进行数据库的创建初始化。

