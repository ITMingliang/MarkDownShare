# Linq和Lambda

后续课程中我们需要学习Entity Framework课程，在EF课程中对数据的操作会频繁使用Linq和Lambda的语法，所以我们提前学习Linq和Lambda。

本课程通过具体实例来学习Linq和Lambda语法。

## 一、资料准备

本课程数据采用模拟的形式，并非从数据库直接读取数据，所以需要有一些支持代码，如下：

**部门类**

```
public class Dept
{
    public Dept()
    {; }
    public Dept(int deptId, string deptName)
    {
        this.DeptId = deptId;
        this.DeptName = deptName;
    }
    public int DeptId { get; set; }  //部门编号
    public string DeptName { get; set; } //部门名称
}
```

**员工类**

```
public class Employee
{
    public Employee()
    {; }
    public Employee(int empId,int deptId,string empName,string empPhone,double empSalary)
    {
        this.EmpId = empId;
        this.DeptId = deptId;
        this.EmpName = empName;
        this.EmpPhone = empPhone;
        this.EmpSalary = empSalary;
    }
    public int EmpId { get; set; }   //员工编号
    public int DeptId { get; set; }   //部门编号
    public string EmpName { get; set; }  //员工姓名
    public string EmpPhone { get; set; }  //员工电话
    public double EmpSalary { get; set; }  //员工工资

}
```

**初始化部门和员工数据的函数**

```
public List<Dept> LoadDept()
{
    List<Dept> list = new List<Dept>();
    list.Add(new Dept(1, "开发部"));
    list.Add(new Dept(2, "测试部"));
    list.Add(new Dept(3, "实施部"));
    return list;
}
public List<Employee> LoadEmployee()
{
    List<Employee> list = new List<Employee>();
    list.Add(new Employee(1, 1, "刘备", "13587457458", 6000));
    list.Add(new Employee(2, 2, "关羽", "13698547412", 8000));
    list.Add(new Employee(3, 3, "张飞", "13245785412", 9000));
    list.Add(new Employee(4, 1, "赵云", "13666669856", 3000));
    list.Add(new Employee(5, 2, "马超", "13224245785", 7000));
    list.Add(new Employee(6, 3, "魏延", "15325254545", 4000));
    list.Add(new Employee(7, 1, "周仓", "13855566624", 2000));
    list.Add(new Employee(8, 2, "廖化", "13999955558", 5000));
    list.Add(new Employee(9, 3, "曹操", "13002025458", 9000));
    return list;
}
```

## 二、linq和lambda筛选数组

Action代码如下：

```
public ActionResult Index()
{
    int[] arr = new int[10] { 55, 85, 35, 69, 74, 12, 85, 47, 95, 32 };
    //使用linq筛选数组中50-80之间的数据元素
    var linqResult = from v in arr
                        where v >= 50 && v <= 80
                        select v;
    ViewBag.linqResult = linqResult;

    //使用lambda筛选数组中50-80之间的数据元素
    var lambdaResult = arr.Where(p => (p >= 50 && p <= 80));
    ViewBag.lambdaResult = lambdaResult;
    return View();
}
```

视图代码如下：

```
<div> 
    <h2>使用linq筛选数组中50-80之间的数据元素</h2>
    <p>
        @foreach (var item in ViewBag.linqResult)
        {
            <span>@item&nbsp;</span>
        }
    </p>

    <h2>使用lambda筛选数组中50-80之间的数据元素</h2>
    <p>
        @foreach (var item in ViewBag.lambdaResult)
        {
            <span>@item&nbsp;</span>
        }
    </p>
</div>
```

## 三、linq和lambda进行条件查询

Action代码如下：

```
#region 查询工资在5000及以上，电话以132开头的员工信息
public ActionResult Demo02()
{
    List<Employee> list = new List<Employee>();
    list = LoadEmployee();
    //linq查询工资在5000及以上，电话以132开头的员工信息
    //(1)判断是否为空或者null:string.IsNullOrEmpty(emp.EmpPhone)
    //(2)以某字符串开头的模糊查询:emp.EmpPhone.StartsWith("138")
    //(3)以某字符串结尾的模糊查询:emp.EmpPhone.EndsWith("138")
    //(4)包含某字符串的模糊查询:emp.EmpPhone.Contains("138")
    //(5)精确到字符串对应位数字符的模糊查询:SqlFunctions.PatIndex("_3__1%", emp.EmpPhone) > 0,相当于like '_3__1%'
    //备注：需要使用SqlFunctions,需要添加引用和using命名空间，如下：
    //Namespace:System.Data.Objects.SqlClient
    //Assembly:System.Data.Entity(in System.Data.Entity.dll)
    var listLinq = from emp in list
                    where emp.EmpSalary >= 5000 && emp.EmpPhone.StartsWith("132")
                    select emp;
    ViewBag.listLinq = listLinq;
    //lambda表达式查询工资在5000及以上，电话以132开头的员工信息
    var listLambda = list.Where(p => p.EmpSalary >= 5000 && p.EmpPhone.StartsWith("132"));
    ViewBag.listLambda = listLambda;
    return View();
}
#endregion
```

视图代码如下：

```
<div>
    <h2>查询工资在5000及以上，电话以132开头的员工信息</h2>
    <table width="1000" border="1" class="MyTable">
        <tr>
            <td>员工编号</td>
            <td>部门编号</td>
            <td>员工姓名</td>
            <td>员工电话</td>
            <td>员工工资</td>
        </tr>
        @foreach (var item in ViewBag.listLinq)
        {
        <tr>
            <td>@item.EmpId</td>
            <td>@item.DeptId</td>
            <td>@item.EmpName</td>
            <td>@item.EmpPhone</td>
            <td>@item.EmpSalary</td>
        </tr>
        }
    </table>
</div>
```

## 四、linq和lambda进行排序

Action代码如下：

```
#region 查询员工信息,先按照工资降序,后按照编号的降序进行排列
public ActionResult Demo03()
{
    List<Employee> list = new List<Employee>();
    list = LoadEmployee();
    //linq(ascending:正序; descending:倒序)
    var listLinq = from emp in list
                    orderby emp.EmpSalary descending, emp.EmpId descending
                    select emp;
    ViewBag.listLinq = listLinq;
    //lambda(OrderBy:正序; OrderByDescending:倒序; 第二次排序使用ThenBy)
    var listLambda = list.OrderByDescending(p => p.EmpSalary).ThenByDescending(p => p.EmpId);
    ViewBag.listLambda = listLambda;
    return View();
}
#endregion
```

视图代码：

```
<div>
    <h2>先按照工资降序,后按照编号的降序进行排列</h2>
    <table width="1000" border="1" class="MyTable">
        <tr>
            <td>员工编号</td>
            <td>部门编号</td>
            <td>员工姓名</td>
            <td>员工电话</td>
            <td>员工工资</td>
        </tr>
        @foreach (var item in ViewBag.listLinq)
        {
            <tr>
                <td>@item.EmpId</td>
                <td>@item.DeptId</td>
                <td>@item.EmpName</td>
                <td>@item.EmpPhone</td>
                <td>@item.EmpSalary</td>
            </tr>
        }
    </table>
    <br /><br />
    <table width="1000" border="1" class="MyTable">
        <tr>
            <td>员工编号</td>
            <td>部门编号</td>
            <td>员工姓名</td>
            <td>员工电话</td>
            <td>员工工资</td>
        </tr>
        @foreach (var item in ViewBag.listLambda)
        {
            <tr>
                <td>@item.EmpId</td>
                <td>@item.DeptId</td>
                <td>@item.EmpName</td>
                <td>@item.EmpPhone</td>
                <td>@item.EmpSalary</td>
            </tr>
        }
    </table>
</div>
```

## 五、linq和lambda进行分组

Action代码：

```
#region 按照部门编号分组显示员工信息
public ActionResult Demo04()
{
    List<Employee> list = new List<Employee>();
    list = LoadEmployee();
    var listLinq = from emp in list
                    group emp by emp.DeptId;
    ViewBag.listLinq = listLinq;
    var listLambda = list.GroupBy(p => p.DeptId);
    ViewBag.listLambda = listLambda;
    return View();
}
#endregion
```

视图代码：

```
<h1>按照部门编号分组显示员工信息</h1>
<div>
    @foreach (var myList in ViewBag.listLinq)
    {
        @*foreach (var item in myList)
        {
            <h3>部门编号: @item.DeptId</h3>
            break;
        }*@
    <table width="1000" border="1" class="MyTable">
        <tr>
            <td>员工编号</td>
            <td>部门编号</td>
            <td>员工姓名</td>
            <td>员工电话</td>
            <td>员工工资</td>
        </tr>
        @foreach (var item in myList)
        {
            <tr>
                <td>@item.EmpId</td>
                <td>@item.DeptId</td>
                <td>@item.EmpName</td>
                <td>@item.EmpPhone</td>
                <td>@item.EmpSalary</td>
            </tr>
        }
    </table>
    <br />
    }
</div>
```

## 六、linq和lambda分组加聚合条件

Action代码：

```
#region 按照部门编号分组显示员工信息(只查询平均工资在5000及以上的)
public ActionResult Demo05()
{
    List<Employee> list = new List<Employee>();
    list = LoadEmployee();
    var listLinq = from emp in list
                    group emp by emp.DeptId
                    into g
                    where g.Average(p => p.EmpSalary) >= 5000
                    select g;
    ViewBag.listLinq = listLinq;

    var listLambda = list.GroupBy(p => p.DeptId).Where(p => p.Average(avg => avg.EmpSalary) >= 5000);
    ViewBag.listLambda = listLambda;
    return View();
}
#endregion
```

视图代码：

```
<h1>按照部门编号分组显示员工信息(只查询平均工资在5000及以上的)</h1>
<div>
    @foreach (var myList in ViewBag.listLambda)
    {
        @*foreach (var item in myList)
            {
                <h3>部门编号: @item.DeptId</h3>
                break;
            }*@
        <table width="1000" border="1" class="MyTable">
            <tr>
                <td>员工编号</td>
                <td>部门编号</td>
                <td>员工姓名</td>
                <td>员工电话</td>
                <td>员工工资</td>
            </tr>
            @foreach (var item in myList)
            {
                <tr>
                    <td>@item.EmpId</td>
                    <td>@item.DeptId</td>
                    <td>@item.EmpName</td>
                    <td>@item.EmpPhone</td>
                    <td>@item.EmpSalary</td>
                </tr>
            }
        </table>
        <br />
    }
</div>
```

## 七、匿名类集合的显示

查询员工信息，添加实发工资列，实发工资的计算公式如下：

（1）实发工资 = 工资-保险-税金

（2）保险为1200元;税金 =（工资-保险-3500）* 0.03，税金如果小于0则税金为0。

Asp.Net MVC的视图中无法直接解析匿名类集合，需要实现循环遍历显示有如下几种方案：

### （1）视图中反射

求实发工资的函数：

```
//求实发工资的方法
public double ComputeSfgz(double salary)
{
    //计算税金
    double sj = (salary - 1200 - 3500) * 0.03;
    double sfgz = salary - 1200 - (sj > 0 ? sj : 0);
    return sfgz;
}
```

Action代码：

```
List<Employee> list = new List<Employee>();
list = LoadEmployee();
//匿名类集合在View中使用反射值
//var list1 = from emp in list
//               let sj = (emp.EmpSalary - 1200 - 3500) * 0.03
//               let sfgz = emp.EmpSalary - 1200 - (sj > 0 ? sj : 0)
//               select new
//               {
//                   EmpId = emp.EmpId,
//                   DeptId = emp.DeptId,
//                   EmpName = emp.EmpName,
//                   EmpPhone = emp.EmpPhone,
//                   EmpSalary = emp.EmpSalary,
//                   EmpSFGZ = sfgz
//               };
var list1 = list.Select(emp => new {
    EmpId = emp.EmpId,
    DeptId = emp.DeptId,
    EmpName = emp.EmpName,
    EmpPhone = emp.EmpPhone,
    EmpSalary = emp.EmpSalary,
    EmpSFGZ = ComputeSfgz(emp.EmpSalary)
});
ViewBag.list1 = list1;
```

视图代码：

```
<h2>利用反射获取内容</h2>
<table width="1000" border="1" class="MyTable">
    <tr>
        <td>员工编号</td>
        <td>部门编号</td>
        <td>员工姓名</td>
        <td>员工电话</td>
        <td>员工工资</td>
        <td>实发工资</td>
    </tr>
    @foreach (var item in ViewBag.list1)
    {
        Type type = item.GetType();
        <tr>
            <td>@type.GetProperty("EmpId").GetValue(item, null)</td>
            <td>@type.GetProperty("DeptId").GetValue(item, null)</td>
            <td>@type.GetProperty("EmpName").GetValue(item, null)</td>
            <td>@type.GetProperty("EmpPhone").GetValue(item, null)</td>
            <td>@type.GetProperty("EmpSalary").GetValue(item, null)</td>
            <td>@type.GetProperty("EmpSFGZ").GetValue(item, null)</td>
        </tr>
    }
</table>
```

### （2）自定义类模型

自定义类代码：

```
public class MyEmp
{
    public int EmpId { get; set; }
    public int DeptId { get; set; }
    public string EmpName { get; set; }
    public string EmpPhone { get; set; }
    public double EmpSalary { get; set; }
    public double EmpSFGZ { get; set; }
}
```

或

```
public class MyEmp:Employee
{
    public double EmpSFGZ { get; set; }
}
```

求实发工资的函数：

```
//求实发工资的方法
public double ComputeSfgz(double salary)
{
    //计算税金
    double sj = (salary - 1200 - 3500) * 0.03;
    double sfgz = salary - 1200 - (sj > 0 ? sj : 0);
    return sfgz;
}
```

Action代码：

```
//利用自定义类模型
//var list2 = from emp in list
//            let sj = (emp.EmpSalary - 1200 - 3500) * 0.03
//            let sfgz = emp.EmpSalary - 1200 - (sj > 0 ? sj : 0)
//            select new MyEmp()
//            {
//                EmpId = emp.EmpId,
//                DeptId = emp.DeptId,
//                EmpName = emp.EmpName,
//                EmpPhone = emp.EmpPhone,
//                EmpSalary = emp.EmpSalary,
//                EmpSFGZ = sfgz
//            };
var list2 = list.Select(emp => new MyEmp()
{
    EmpId = emp.EmpId,
    DeptId = emp.DeptId,
    EmpName = emp.EmpName,
    EmpPhone = emp.EmpPhone,
    EmpSalary = emp.EmpSalary,
    EmpSFGZ = ComputeSfgz(emp.EmpSalary)
});
ViewBag.list2 = list2;
```

视图代码：

```
<h2>利用自定义类模型获取内容</h2>
<table width="1000" border="1" class="MyTable">
    <tr>
        <td>员工编号</td>
        <td>部门编号</td>
        <td>员工姓名</td>
        <td>员工电话</td>
        <td>员工工资</td>
        <td>实发工资</td>
    </tr>
    @foreach (var item in ViewBag.list2)
    {
        <tr>
            <td>@item.EmpId</td>
            <td>@item.DeptId</td>
            <td>@item.EmpName</td>
            <td>@item.EmpPhone</td>
            <td>@item.EmpSalary</td>
            <td>@item.EmpSFGZ</td>
        </tr>
    }
</table>
```

### （3）使用Tuple元组

求实发工资的函数：

```
//求实发工资的方法
public double ComputeSfgz(double salary)
{
    //计算税金
    double sj = (salary - 1200 - 3500) * 0.03;
    double sfgz = salary - 1200 - (sj > 0 ? sj : 0);
    return sfgz;
}
```

Action代码：

```
//使用Tuple元组
//var list3 = from emp in list
//            let sj = (emp.EmpSalary - 1200 - 3500) * 0.03
//            let sfgz = emp.EmpSalary - 1200 - (sj > 0 ? sj : 0)
//            select new
//            {
//                EmpId = emp.EmpId,
//                DeptId = emp.DeptId,
//                EmpName = emp.EmpName,
//                EmpPhone = emp.EmpPhone,
//                EmpSalary = emp.EmpSalary,
//                EmpSFGZ = sfgz
//            };
//ViewBag.list3 = list3.ToList().Select(x=>Tuple.Create(x.EmpId,x.DeptId,x.EmpName,x.EmpPhone,x.EmpSalary,x.EmpSFGZ));
var list3 = list.Select(x => Tuple.Create(x.EmpId,
    x.DeptId,
    x.EmpName,
    x.EmpPhone,
    x.EmpSalary,
    ComputeSfgz(x.EmpSalary)));
ViewBag.list3 = list3;
```

视图代码：

```
<h2>利用Tuple元组获取内容</h2>
<table width="1000" border="1" class="MyTable">
    <tr>
        <td>员工编号</td>
        <td>部门编号</td>
        <td>员工姓名</td>
        <td>员工电话</td>
        <td>员工工资</td>
        <td>实发工资</td>
    </tr>
    @foreach (var item in ViewBag.list3)
    {
        <tr>
            <td>@item.Item1</td>
            <td>@item.Item2</td>
            <td>@item.Item3</td>
            <td>@item.Item4</td>
            <td>@item.Item5</td>
            <td>@item.Item6</td>
        </tr>
    }
</table>
```

### （4）动态属性实现

匿名类集合转动态属性的类：

```
public class MyDynamic
{
    public static List<ExpandoObject> ToExpandoList(object query)
    {
        List<ExpandoObject> listExpando = new List<ExpandoObject>();
        foreach (var entity in (IEnumerable)query)
        {
            Type type = entity.GetType();
            dynamic dyEntity = new ExpandoObject();
            IDictionary<string, object> dict = new Dictionary<string, object>();
            dict = dyEntity as ExpandoObject;
            PropertyInfo[] arrProperty = type.GetProperties();
            foreach (PropertyInfo prop in arrProperty)
            {
                string a = prop.Name;
                string b = prop.GetValue(entity, null).ToString();
                dict.Add(prop.Name, prop.GetValue(entity, null));
            }
            listExpando.Add(dict as dynamic);
        }
        return listExpando;
    }
}
```

Action代码：

```
//匿名类集合转动态类型展示数据
var list4 = from emp in list
            let sj = (emp.EmpSalary - 1200 - 3500) * 0.03
            let sfgz = emp.EmpSalary - 1200 - (sj > 0 ? sj : 0)
            select new
            {
                EmpId = emp.EmpId,
                DeptId = emp.DeptId,
                EmpName = emp.EmpName,
                EmpPhone = emp.EmpPhone,
                EmpSalary = emp.EmpSalary,
                EmpSFGZ = sfgz
            };
//List<ExpandoObject> listObject = new List<ExpandoObject>();
//foreach (var item in list4)
//{
//    dynamic dyEntity = new ExpandoObject();
//    dyEntity.EmpId = item.EmpId;
//    dyEntity.DeptId = item.DeptId;
//    dyEntity.EmpName = item.EmpName;
//    dyEntity.EmpPhone = item.EmpPhone;
//    dyEntity.EmpSalary = item.EmpSalary;
//    dyEntity.EmpSFGZ = item.EmpSFGZ;
//    listObject.Add(dyEntity);
//}
//ViewBag.list4 = listObject;
//上面的注释代码也可以用通用方法来实现
ViewBag.list4 = MyDynamic.ToExpandoList(list4);
```

视图代码：

```
<h2>匿名类集合转动态类型展示数据</h2>
<table width="1000" border="1" class="MyTable">
    <tr>
        <td>员工编号</td>
        <td>部门编号</td>
        <td>员工姓名</td>
        <td>员工电话</td>
        <td>员工工资</td>
        <td>实发工资</td>
    </tr>
    @foreach (var item in ViewBag.list4)
    {
        <tr>
            <td>@item.EmpId</td>
            <td>@item.DeptId</td>
            <td>@item.EmpName</td>
            <td>@item.EmpPhone</td>
            <td>@item.EmpSalary</td>
            <td>@item.EmpSFGZ</td>
        </tr>
    }
</table>
```

### （5）JSON格式实现

在NuGet程序包管理中，下载安装Newtonsoft.Json。

Action代码：

using Newtonsoft.Json;

```
//借助Newtonsoft.Net转换Json格式
var list5 = from emp in list
            let sj = (emp.EmpSalary - 1200 - 3500) * 0.03
            let sfgz = emp.EmpSalary - 1200 - (sj > 0 ? sj : 0)
            select new
            {
                EmpId = emp.EmpId,
                DeptId = emp.DeptId,
                EmpName = emp.EmpName,
                EmpPhone = emp.EmpPhone,
                EmpSalary = emp.EmpSalary,
                EmpSFGZ = sfgz
            };
ViewBag.list5 = JsonConvert.SerializeObject(list5);
```

视图代码：

@using Newtonsoft.Json.Linq;
@using Newtonsoft.Json;

```
<h2>借助Newtonsoft.Net转换Json格式</h2>
<table width="1000" border="1" class="MyTable">
    <tr>
        <td>员工编号</td>
        <td>部门编号</td>
        <td>员工姓名</td>
        <td>员工电话</td>
        <td>员工工资</td>
        <td>实发工资</td>
    </tr>
    @{ 
        JArray arr = JsonConvert.DeserializeObject(ViewBag.list5);
    }
    @foreach (var item in arr)
    {
        <tr>
            <td>@item["EmpId"]</td>
            <td>@item["DeptId"]</td>
            <td>@item["EmpName"]</td>
            <td>@item["EmpPhone"]</td>
            <td>@item["EmpSalary"]</td>
            <td>@item["EmpSFGZ"]</td>
        </tr>
    }
</table>
```

## 八、联表查询

联表查询如果在EF框架中存在表关系，可以直接使用单表查询引出关联数据，本实例假设两个集合没有关联关系。

联表查询出的结果为匿名类集合，在视图中的解析可以使用N中方式实现，此处使用动态属性来实现。

Action代码：

```
#region 查询员工信息，要求显示员工的部门名称，而不是部门编号
public ActionResult Demo07()
{
    List<Dept> listDept = new List<Dept>();
    listDept = LoadDept();
    List<Employee> listEmp = new List<Employee>();
    listEmp = LoadEmployee();
    //如果需要使用linq进行左联，右联，全外联参照chp06_Linq补充“009_ASP.NET_WebForm\chp06_Linq补充”
    //var listView = from emp in listEmp
    //               join dept in listDept on emp.DeptId equals dept.DeptId
    //               select new
    //               {
    //                   EmpId = emp.EmpId,
    //                   DeptName = dept.DeptName,
    //                   EmpName = emp.EmpName,
    //                   EmpPhone = emp.EmpPhone,
    //                   EmpSalary = emp.EmpSalary
    //               };
    var listView = listEmp.Join(listDept, emp => emp.DeptId, dept => dept.DeptId,
        (emp, dept) => new {
            EmpId = emp.EmpId,
            DeptName = dept.DeptName,
            EmpName = emp.EmpName,
            EmpPhone = emp.EmpPhone,
            EmpSalary = emp.EmpSalary
        });
    ViewBag.listView = MyDynamic.ToExpandoList(listView);
    return View();
}
#endregion
```

视图代码：

```
<div>
    <h1>查询员工信息，要求显示员工的部门名称，而不是部门编号</h1>
    <table width="1000" border="1" class="MyTable">
        <tr>
            <td>员工编号</td>
            <td>部门名称</td>
            <td>员工姓名</td>
            <td>员工电话</td>
            <td>员工工资</td>
        </tr>
        @foreach (var item in ViewBag.listView)
        {
            <tr>
                <td>@item.EmpId</td>
                <td>@item.DeptName</td>
                <td>@item.EmpName</td>
                <td>@item.EmpPhone</td>
                <td>@item.EmpSalary</td>
            </tr>
        }
    </table>         
</div>
```

## 九、分组加聚合

分组加聚合的结果为匿名类集合，在视图中的解析可以使用N中方式实现，此处使用动态属性来实现。

Action代码：

```
#region 分组和聚合函数
public ActionResult Demo08()
{
    List<Dept> listDept = new List<Dept>();
    listDept = LoadDept();
    List<Employee> listEmp = new List<Employee>();
    listEmp = LoadEmployee();
    //var listView = from emp in listEmp
    //               join dept in listDept on emp.DeptId equals dept.DeptId
    //               group emp by new { dept.DeptId, dept.DeptName } into g
    //               select new
    //               {
    //                   部门编号 = g.Key.DeptId,
    //                   部门名称 = g.Key.DeptName,
    //                   部门人数 = g.Count(),
    //                   工资总和 = g.Sum(p => p.EmpSalary),
    //                   平均工资 = g.Average(p => p.EmpSalary),
    //                   最高工资 = g.Max(p => p.EmpSalary),
    //                   最低工资 = g.Min(p => p.EmpSalary)
    //               };

    var listView = listEmp.Join(listDept, emp => emp.DeptId, dept => dept.DeptId, (emp, dept) => new
    {
        部门编号 = dept.DeptId,
        部门名称 = dept.DeptName,
        工资 = emp.EmpSalary
    }).GroupBy(p => new { p.部门编号, p.部门名称 }).Select(x => new {
        部门编号 = x.Key.部门编号,
        部门名称 = x.Key.部门名称,
        部门人数 = x.Count(),
        工资总和 = x.Sum(p => p.工资),
        平均工资 = x.Average(p => p.工资),
        最高工资 = x.Max(p => p.工资),
        最低工资 = x.Min(p => p.工资)
    });
    ViewBag.listView = MyDynamic.ToExpandoList(listView);
    return View();
}
#endregion
```

视图代码：

```
<div> 
    <h1>分组和聚合函数</h1>
    <table width="1000" border="1" class="MyTable">
        <tr>
            <td>部门名称</td>
            <td>部门人数</td>
            <td>工资总和</td>
            <td>平均工资</td>
            <td>最高工资</td>
            <td>最低工资</td>
        </tr>
        @foreach (var item in ViewBag.listView)
        {
            <tr>
                <td>@item.部门名称</td>
                <td>@item.部门人数</td>
                <td>@item.工资总和</td>
                <td>@item.平均工资</td>
                <td>@item.最高工资</td>
                <td>@item.最低工资</td>
            </tr>
        }
    </table> 
</div>
```

