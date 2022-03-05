# WebAPI & EF

本章节主要介绍使用WebAPI和EF框架结合，实现数据的基本操作功能。

## 一、资料准备

数据库脚本：

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

## 二、数据列表

**API接口：**

```
[HttpGet]
public IHttpActionResult Get()
{
    var data = from emp in db.Employee
                join dept in db.Dept on emp.DeptId equals dept.DeptId
                select new
                {
                    EmpId = emp.EmpId,
                    DeptId = emp.DeptId,
                    EmpName = emp.EmpName,
                    EmpPhone = emp.EmpPhone,
                    EmpArea = emp.EmpArea,
                    EmpSalary = emp.EmpSalary,
                    DeptName = dept.DeptName
                };
    return Json(new { res = 1, msg = "", data = data });
}
```

**接口测试地址：**

```
http://localhost:1894/api/Employee
```

## 三、组合条件搜索

**接受搜索条件的实体：**

```
public class SearchDto
{
	public int DeptId { get; set; } //部门编号
	public string EmpName { get; set; } //部门名称
}
```

**API接口：**

```
[HttpGet]
[Route("api/Employee/Search")]
public IHttpActionResult Get([FromUri] SearchDto searchDto)
{
    var data = from emp in db.Employee
                join dept in db.Dept on emp.DeptId equals dept.DeptId
                select new
                {
                    EmpId = emp.EmpId,
                    DeptId = emp.DeptId,
                    EmpName = emp.EmpName,
                    EmpPhone = emp.EmpPhone,
                    EmpArea = emp.EmpArea,
                    EmpSalary = emp.EmpSalary,
                    DeptName = dept.DeptName
                };
    if (searchDto.DeptId > 0)
        data = data.Where(p => p.DeptId == searchDto.DeptId);
    if (!string.IsNullOrEmpty(searchDto.EmpName))
        data = data.Where(p => p.EmpName.Contains(searchDto.EmpName));
    return Json(new { res = 1, msg = "", data = data });
}
```

**接口测试：**

![016](img\016.PNG)

## 四、组合条件搜索加分页

**接受搜索条件的实体：**

```
public class SearchDto
{
	public int DeptId { get; set; } //部门编号
	public string EmpName { get; set; } //部门名称
}
```

**API接口：**

```
[HttpGet]
[Route("api/Employee/SearchPage")]
public IHttpActionResult Get(int page,int pagesize,[FromUri] SearchDto searchDto)
{

    var query = from emp in db.Employee
                join dept in db.Dept on emp.DeptId equals dept.DeptId
                select new
                {
                    EmpId = emp.EmpId,
                    DeptId = emp.DeptId,
                    EmpName = emp.EmpName,
                    EmpPhone = emp.EmpPhone,
                    EmpArea = emp.EmpArea,
                    EmpSalary = emp.EmpSalary,
                    DeptName = dept.DeptName
                };
    if (searchDto.DeptId > 0)
        query = query.Where(p => p.DeptId == searchDto.DeptId);
    if (!string.IsNullOrEmpty(searchDto.EmpName))
        query = query.Where(p => p.EmpName.Contains(searchDto.EmpName));
    var data = query.OrderByDescending(p => p.EmpId).ToPagedList(page, pagesize);
    return Json(new { res = 1, msg = "",total=data.TotalItemCount, data = data });
}
```

**接口测试：**

![0017](img\0017.PNG)

## 五、数据的新增

**API接口方案一：**（直接使用EF中实体接受新增的数据）

```
[HttpPost]
//此处为降低前端和EF框架实体的耦合性，也可以重新定义Dto类，然后将Dto数据通过映射,赋值到EF中Employee对象中
public IHttpActionResult Add(Employee emp) 
{
    db.Employee.Add(emp);
    int r = db.SaveChanges();
    if (r == 1)
        return Json(new { res = 1, msg = "添加成功" });
    else
        return Json(new { res = 1, msg = "添加失败" });
}
```

**API接口方案二：**（使用Dto接受数据，直接通过属性赋值实现Dto对象向EF实体的转换）

```
public class EmpAddDto
{
    public int EmpId { get; set; }
    public int DeptId { get; set; }
    public string EmpName { get; set; }
    public string EmpPhone { get; set; }
    public string EmpArea { get; set; }
    public decimal EmpSalary { get; set; }
}

[HttpPost]
public IHttpActionResult Add(EmpAddDto dto)
{
    //属性依次赋值实现Dto对象向EF实体对象的转换
    Employee emp = new Employee();
    emp.DeptId = dto.DeptId;
    emp.EmpName = dto.EmpName;
    emp.EmpPhone = dto.EmpPhone;
    emp.EmpArea = dto.EmpArea;
    emp.EmpSalary = dto.EmpSalary;
    db.Employee.Add(emp);
    int r = db.SaveChanges();
    if (r == 1)
        return Json(new { res = 1, msg = "添加成功" });
    else
        return Json(new { res = 1, msg = "添加失败" });
}
```

**API接口方案三：**（通过AutoMapper组件进行映射）

AutoMapper组件可以在NuGet中进行安装，经过测试在framework4.5中无法使用，在framework4.7.1中可以正常使用。

如果没有安装framework4.7.1,可以在官网下载 .NET Framework 4.7.1 Developer Pack。

如果通过项目的属性面板中修改了目标框架为framework4.7.1，程序可能会编译错误，需要修改配置文件：

```
compilerOptions="/langversion:6 /nowarn:1659;1699;1701"
```

修改成：

```
compilerOptions="/langversion:Default /nowarn:1659;1699;1701"
```

API接口代码：（两种类型属性名称完全相同的时候）

```
public class EmpAddDto
{
    public int EmpId { get; set; }
    public int DeptId { get; set; }
    public string EmpName { get; set; }
    public string EmpPhone { get; set; }
    public string EmpArea { get; set; }
    public decimal EmpSalary { get; set; }
}
[HttpPost]
public IHttpActionResult Add(EmpAddDto dto)
{
    //两种类型属性名称相同自动映射
    var config = new MapperConfiguration(cfg => cfg.CreateMap<EmpAddDto, Employee>());
    var mapper = config.CreateMapper();
    Employee emp = mapper.Map<Employee>(dto);
    db.Employee.Add(emp);
    int r = db.SaveChanges();
    if (r == 1)
        return Json(new { res = 1, msg = "添加成功" });
    else
        return Json(new { res = 1, msg = "添加失败" });
}
```

API接口代码：（两种类型属性名称不一致的时候）

```
public class EmpAddDto
{
    public int EmpId { get; set; }
    public int DeptId { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string EmpArea { get; set; }
    public decimal EmpSalary { get; set; }
}
[HttpPost]
public IHttpActionResult Add(EmpAddDto dto)
{
    //两种类型名属性相同自动映射
    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<EmpAddDto, Employee>()
        .ForMember("EmpName", opt => opt.MapFrom(src => src.Name))
        .ForMember(dest => dest.EmpPhone, opt => opt.MapFrom(src => src.Phone));
        //.ForMember(dest => dest.EmpId, opt => opt.MapFrom(src => src.EmpId))
        //.ForMember(dest => dest.DeptId, opt => opt.MapFrom(src => src.DeptId))
        //.ForMember(dest => dest.EmpName, opt => opt.MapFrom(src => src.Name))
        //.ForMember(dest => dest.EmpPhone, opt => opt.MapFrom(src => src.Phone))
        //.ForMember(dest => dest.EmpArea, opt => opt.MapFrom(src => src.EmpArea))
        //.ForMember(dest => dest.EmpSalary, opt => opt.MapFrom(src => src.EmpSalary));
    });
    var mapper = config.CreateMapper();
    Employee emp = mapper.Map<Employee>(dto);
    db.Employee.Add(emp);
    int r = db.SaveChanges();
    if (r == 1)
        return Json(new { res = 1, msg = "添加成功" });
    else
        return Json(new { res = 1, msg = "添加失败" });
}
```

**接口测试：**（使用EmpAddDto接受数据的时候注意参数名称需要和EmpAddDto的属性名相同）

![0018](img\0018.PNG)

























