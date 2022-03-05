# Linq

LINQ(Language Integrated Query)：语言集成查询，提供了强大的数据查询，排序，分组等功能。

LINQ的组件：

1、LINQ to Object：主要对数组、集合等操作(IEnumerable)。

2、LINQ to DataSet：主要对DataSet、DataTable操作。

3、LINQ to SQL：直接查询数据库(MS SQLServer)的操作(X)【EF】。

4、LINQ to XML：主要对XML文件操作。

```
LINQ必须以from开头，以slect或group by结尾
字句							功能
from ? in ?				     指定查询操作的数据源
select						 指定查询结果的类型和呈现方式
where						 查询条件
orderby						 排序
group by					 分组
into						 临时存储结果，后面直接使用
join						 联接
let							 范围变量
```

## 一、LinqToArray操作数组

```
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LinqToArray操作数组</title>
    <style type="text/css">
        #container div{ line-height:30px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <div>
            <asp:Button ID="btRnd" runat="server" Text="随机产生数组" onclick="btRnd_Click" />
            <asp:Button ID="btArr" runat="server" Text="使用数组本身方法筛选10-30之间数字" 
                onclick="btArr_Click" />
            <asp:Button ID="btList" runat="server" Text="使用集合筛选40-60之间数字" 
                onclick="btList_Click"   />
            <asp:Button ID="btLinq" runat="server" Text="使用linq筛选70-90之间数字" 
                onclick="btLinq_Click" />
        </div>
        <div>数组:</div>
        <div id="divArr" runat="server"></div>
        <div id="divTitle" runat="server"></div>
        <div id="divResult" runat="server"></div>
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

    #region 随机产生数组
    protected void btRnd_Click(object sender, EventArgs e)
    {
        int[] arr = new int[50];
        //随机产生数组元素值
        Random rd = new Random();
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = rd.Next(1, 100);
        }
        string str = string.Join(",", arr);
        this.divArr.InnerHtml = str;
    }
    #endregion

    #region 使用集合筛选数组数字
    protected void btList_Click(object sender, EventArgs e)
    {
        int[] arr = this.StrArrToIntArr(this.divArr.InnerHtml.Split(','));
        List<int> list = new List<int>();
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] >= 40 && arr[i] <= 60)
            {
                list.Add(arr[i]);
            }
        }
        this.divTitle.InnerHtml = "集合筛选:";
        this.divResult.InnerHtml = string.Join(",", list);
    }
    #endregion

    #region 使用数组本身方法筛选
    protected void btArr_Click(object sender, EventArgs e)
    {
        int[] arr = this.StrArrToIntArr(this.divArr.InnerHtml.Split(','));
        var resultArr = arr.Where<int>(p => (p >= 10 && p <= 30));
        this.divTitle.InnerHtml = "数组筛选:";
        this.divResult.InnerHtml = string.Join(",", resultArr);
    }
    #endregion

    #region 使用Linq筛选
    protected void btLinq_Click(object sender, EventArgs e)
    {
        int[] arr = this.StrArrToIntArr(this.divArr.InnerHtml.Split(','));
        var result = from int v in arr where (v >= 70 && v <= 90) select v;
        this.divTitle.InnerHtml = "Linq筛选:";
        this.divResult.InnerHtml = string.Join(",", result);
    }
    #endregion

    #region 字符串数组转整形数组
    private int[] StrArrToIntArr(string[] strArr)
    {
        int[] arr = new int[strArr.Length];
        for (int i = 0; i < strArr.Length; i++)
            arr[i] = int.Parse(strArr[i]);
        return arr;
    }
    #endregion

}
```

## 二、LinqToList操作集合

```
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LinqToList-Linq操作集合</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btAll" runat="server" Text="显示所有班级和学生信息" 
            onclick="btAll_Click" />
    </div>
    <br />
     <div>
        <asp:Button ID="Button1" runat="server" Text="where(LINQ)" 
             onclick="Button1_Click"  />
        <asp:Button ID="Button2" runat="server" Text="where(Lambda)" 
             onclick="Button2_Click"  />
        <asp:Button ID="Button3" runat="server" Text="order by(LINQ)" 
             onclick="Button3_Click"  />
        <asp:Button ID="Button4" runat="server" Text="order by(Lambda)" 
             onclick="Button4_Click"  />
        <asp:Button ID="Button5" runat="server" Text="group by(LINQ)" 
             onclick="Button5_Click"  />
        <asp:Button ID="Button6" runat="server" Text="group by(Lambda)" 
             onclick="Button6_Click"  />
        <asp:Button ID="Button7" runat="server" Text="into(LINQ)" 
             onclick="Button7_Click"  />
        <asp:Button ID="Button8" runat="server" Text="分组后条件(Lambda)" 
             onclick="Button8_Click"  />
        <asp:Button ID="Button9" runat="server" Text="join(LINQ)" 
             onclick="Button9_Click"  />
        <asp:Button ID="Button10" runat="server" Text="join(Lambda)" 
             onclick="Button10_Click"  />
        <asp:Button ID="Button11" runat="server" Text="let(LINQ)" 
             onclick="Button11_Click"  />
        <asp:Button ID="Button12" runat="server" Text="分组和聚合函数(LINQ)" 
             onclick="Button12_Click"  />
        <asp:Button ID="Button13" runat="server" Text="分组和聚合函数(Lambda)" 
             onclick="Button13_Click"   />
    </div>   
    <br />
    <div id="divGvResult" runat="server">
        
    </div>
    </form>
</body>
</html>
```

```
public partial class Demo02 : System.Web.UI.Page
{
    Random rd = new Random();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<ClassEntity> listClass = this.CreateClassList(2);
            ViewState["listClass"] = listClass;
            List<StudentEntity> listStudent = this.CreateStudentList(10, listClass);
            ViewState["listStudent"] = listStudent;

            PrintResult(ViewState["listClass"]);
            PrintResult(ViewState["listStudent"]);
        }
    }

    #region 初始化班级列表
    private List<ClassEntity> CreateClassList(int count)
    {
        List<ClassEntity> list = new List<ClassEntity>();
        for (int i = 0; i < count; i++)
        {
            ClassEntity entity = new ClassEntity();
            entity.ClassId = 1700 + i+1;
            entity.ClassName = "软件技术" + (i+1) + "班";
            entity.Teacher = "刘亦菲";
            list.Add(entity);
        }
        return list;
    }
    #endregion

    #region 随机产生学生信息
    private List<StudentEntity> CreateStudentList(int count, List<ClassEntity> listClass)
    {
        List<StudentEntity> listStu = new List<StudentEntity>();
        for (int i = 0; i < count; i++)
        {
            StudentEntity entity = new StudentEntity();
            entity.ClassId = listClass[rd.Next(0, listClass.Count)].ClassId;
            entity.StuNo = "flfa" + DateTime.Now.Year + (i+1).ToString("d5");
            entity.Name = this.CreateRndName();
            entity.Sex = "男女"[rd.Next(0, 2)]+"";
            entity.Age = rd.Next(16,25);
            listStu.Add(entity);
        }
        return listStu;
    }
    #endregion

    #region 产生随机名字
    private string CreateRndName()
    {
        string fullName = "";  //全名
        string familyName = "赵钱孙李周吴郑王沈韩杨孔曹严华苗凤花方金魏陶姜"; //姓
        string secondName = "娟程玥盼蝶雪雨嫣正兴明杰雄伟毓豪灿成义千波宇奇"; //名       
        fullName = familyName[rd.Next(0,familyName.Length)]+"";
        for (int i = 0; i < rd.Next(1,3); i++)
        {
            fullName += secondName[rd.Next(0, secondName.Length)] + "";
        }
        return fullName;
    }
    #endregion

    #region 打印信息
    private void PrintResult(object dataSourse)
    {
        GridView gv = new GridView();
        gv.Style[HtmlTextWriterStyle.MarginBottom] = "20px";
        gv.Style[HtmlTextWriterStyle.Width] = "800px";
        gv.Style[HtmlTextWriterStyle.TextAlign] = "center";
        gv.DataSource = dataSourse;
        gv.DataBind();
        this.divGvResult.Controls.Add(gv);
    }
    #endregion

    #region 显示所有班级和学生信息
    protected void btAll_Click(object sender, EventArgs e)
    {
        PrintResult(ViewState["listClass"]);
        PrintResult(ViewState["listStudent"]);
    }
    #endregion

    #region where(LINQ)--查询出年龄在20以上的男同学
    protected void Button1_Click(object sender, EventArgs e)
    {
        List<StudentEntity> list = ViewState["listStudent"] as List<StudentEntity>;
        var result = from StudentEntity entity in list
                     where entity.Sex.Equals("男") &&
                     entity.Age >= 20
                     select entity;
        this.divGvResult.InnerHtml = "查询出年龄在20以上的男同学";
        this.PrintResult(result);
    }
    #endregion

    #region where(Lambda)--查询出年龄在20以下的男同学
    protected void Button2_Click(object sender, EventArgs e)
    {
        List<StudentEntity> list = ViewState["listStudent"] as List<StudentEntity>;
        list = list.Where(p => p.Sex.Equals("男") && p.Age < 20).ToList();
        this.divGvResult.InnerHtml = "查询出年龄在20以下的男同学";
        this.PrintResult(list);
    }
    #endregion

    #region order by(LINQ)--按照班级升序排列，然后按照年龄倒序排列
    protected void Button3_Click(object sender, EventArgs e)
    {
        List<StudentEntity> list = ViewState["listStudent"] as List<StudentEntity>;
        var result = from StudentEntity entity in list
                     orderby entity.ClassId ascending,entity.Age descending
                     select entity;
        this.divGvResult.InnerHtml = "按照班级升序排列，然后按照年龄倒序排列";
        this.PrintResult(result);
    }
    #endregion

    #region order by(Lambda)-按照班级降序排列，然后按照年龄升序排列
    protected void Button4_Click(object sender, EventArgs e)
    {
        List<StudentEntity> list = ViewState["listStudent"] as List<StudentEntity>;
        list = list.OrderByDescending(p => p.ClassId).ThenBy(p => p.Age).ToList();
        this.divGvResult.InnerHtml = "按照班级降序排列，然后按照年龄升序排列";
        this.PrintResult(list);
    }
    #endregion

    #region group by(LINQ)--根据班级分组显示信息
    protected void Button5_Click(object sender, EventArgs e)
    {
        List<StudentEntity> list = ViewState["listStudent"] as List<StudentEntity>;
        var listResult = from StudentEntity entity in list
                         group entity by entity.ClassId;
        this.divGvResult.InnerHtml = "根据班级分组显示信息";
        PrintResult(listResult);
        foreach (var item in listResult) //分组后用多个集合存储信息，所以需要循环取出来
        {
            PrintResult(item);
        }
    }
    #endregion

    #region group by(Lambda)-根据性别分组显示学生信息
    protected void Button6_Click(object sender, EventArgs e)
    {
        List<StudentEntity> list = ViewState["listStudent"] as List<StudentEntity>;
        var result = list.GroupBy(p => p.Sex);
        this.divGvResult.InnerHtml = "根据性别分组显示学生信息";
        PrintResult(result);
        foreach (var item in result)
        {
            PrintResult(item);
        }
    }
    #endregion

    #region into(LINQ)--按班级分组，只查看班级中人数>=4的
    protected void Button7_Click(object sender, EventArgs e)
    {
        List<StudentEntity> list = ViewState["listStudent"] as List<StudentEntity>;
        var result = from StudentEntity entity in list
                     group entity by entity.ClassId
                         into newList
                         where newList.Count() >= 4
                         select newList;
        this.divGvResult.InnerHtml = "按班级分组，只查看班级中人数>=4的";
        PrintResult(result);
        foreach (var item in result) //分组后用多个集合存储信息，所以需要循环取出来
        {
            PrintResult(item);
        }
    }
    #endregion

    #region 分组后条件(Lambda),查看女生人数>=3的学生信息
    protected void Button8_Click(object sender, EventArgs e)
    {
        List<StudentEntity> list = ViewState["listStudent"] as List<StudentEntity>;
        var result = list.GroupBy(p => p.ClassId).Where(p => p.Count(s => s.Sex.Equals("女")) >= 3);
        this.divGvResult.InnerHtml = "查看女生人数>=3的学生信息";
        PrintResult(result);
        foreach (var item in result) //分组后用多个集合存储信息，所以需要循环取出来
        {
            PrintResult(item);
        }
    }
    #endregion

    #region join(LINQ)-将班级编号变成班级名称进行显示
    protected void Button9_Click(object sender, EventArgs e)
    {
        List<StudentEntity> listStudent = ViewState["listStudent"] as List<StudentEntity>;
        List<ClassEntity> listClass = ViewState["listClass"] as List<ClassEntity>;

        var result = from StudentEntity stu in listStudent
                     join ClassEntity cls in listClass on stu.ClassId equals cls.ClassId
                     select new
                     {
                         班级名称 = cls.ClassName,
                         学号 = stu.StuNo,
                         姓名 = stu.Name,
                         性别 = stu.Sex,
                         年龄 = stu.Age
                     };
        this.divGvResult.InnerHtml = "将班级编号变成班级名称进行显示";
        PrintResult(result);
    }
    #endregion

    #region join(Lambda)--将班级编号变成班级名称进行显示,并且显示班主任老师
    protected void Button10_Click(object sender, EventArgs e)
    {
        List<StudentEntity> listStudent = ViewState["listStudent"] as List<StudentEntity>;
        List<ClassEntity> listClass = ViewState["listClass"] as List<ClassEntity>;
        var result = listStudent.Join(listClass, stu => stu.ClassId, cls => cls.ClassId, (stu, cls) => new {
            班级名称 = cls.ClassName,
            班主任 = cls.Teacher,
            学号 = stu.StuNo,
            姓名 = stu.Name,
            性别 = stu.Sex,
            年龄 = stu.Age
        });
        this.divGvResult.InnerHtml = "将班级编号变成班级名称进行显示,并且显示班主任老师";
        PrintResult(result);
    }
    #endregion

    #region let(LINQ)-查询学号是偶数的学生信息
    protected void Button11_Click(object sender, EventArgs e)
    {
        List<StudentEntity> listStudent = ViewState["listStudent"] as List<StudentEntity>;
        var result = from StudentEntity stu in listStudent
                     let wh = stu.StuNo.Substring(stu.StuNo.Length - 1, 1)
                     where int.Parse(wh) % 2 == 0
                     select stu;
        this.divGvResult.InnerHtml = "查询学号是偶数的学生信息";
        PrintResult(result);
    }
    #endregion

    #region 分组和聚合函数(LINQ)
    protected void Button12_Click(object sender, EventArgs e)
    {
        //单表单字段分组
        //List<StudentEntity> listStudent = ViewState["listStudent"] as List<StudentEntity>;
        //List<ClassEntity> listClass = ViewState["listClass"] as List<ClassEntity>;
        //var result = from StudentEntity entity in listStudent
        //             group entity by entity.ClassId into g
        //             select new
        //             {
        //                 班级编号 = g.Key,
        //                 最大年龄 = g.Max(entity => entity.Age),
        //                 最小年龄 = g.Min(entity => entity.Age),
        //                 总和年龄 = g.Sum(entity => entity.Age),
        //                 平均年龄 = g.Average(entity => entity.Age),
        //                 班级人数 = g.Count()
        //             };
        //this.divGvResult.InnerHtml = "分组和聚合函数(LINQ)";
        //PrintResult(result);

        //多表多字段分组
        List<StudentEntity> listStudent = ViewState["listStudent"] as List<StudentEntity>;
        List<ClassEntity> listClass = ViewState["listClass"] as List<ClassEntity>;
        var result = from StudentEntity entity in listStudent
                     join ClassEntity cls in listClass on entity.ClassId equals cls.ClassId
                     group entity by new { cls.ClassId,cls.ClassName} into g
                     select new
                     {
                         班级编号 = g.Key.ClassId,
                         班级名称 = g.Key.ClassName,
                         最大年龄 = g.Max(entity => entity.Age),
                         最小年龄 = g.Min(entity => entity.Age),
                         总和年龄 = g.Sum(entity => entity.Age),
                         平均年龄 = g.Average(entity => entity.Age),
                         班级人数 = g.Count()
                     };
        this.divGvResult.InnerHtml = "分组和聚合函数(LINQ)";
        PrintResult(result);
    }
    #endregion

    #region 分组和聚合函数(Lambda)
    protected void Button13_Click(object sender, EventArgs e)
    {
        //单表单字段分组
        //List<StudentEntity> list = ViewState["listStudent"] as List<StudentEntity>;
        //var result = list.GroupBy(p => p.ClassId).Select(g => new { 
        //    班级编号 = g.Key ,
        //    最大年龄 = g.Max(entity => entity.Age),
        //    最小年龄 = g.Min(entity => entity.Age),
        //    总和年龄 = g.Sum(entity => entity.Age),
        //    平均年龄 = g.Average(entity => entity.Age),
        //    班级人数 = g.Count()
        //});
        //this.divGvResult.InnerHtml = "分组和聚合函数(Lambda)";
        //PrintResult(result);

        //多表多字段分组
        List<StudentEntity> listStudent = ViewState["listStudent"] as List<StudentEntity>;
        List<ClassEntity> listClass = ViewState["listClass"] as List<ClassEntity>;
        var result = listStudent.Join(listClass, stu => stu.ClassId, cls => cls.ClassId, (stu, cls) => new
        {
            班级编号 = cls.ClassId,
            班级名称 = cls.ClassName,
            班主任 = cls.Teacher,
            学号 = stu.StuNo,
            姓名 = stu.Name,
            性别 = stu.Sex,
            年龄 = stu.Age
        }).GroupBy(p => new { p.班级编号, p.班级名称 }).Select(p => new
        {
            班级编号 = p.Key.班级编号,
            班级名称 = p.Key.班级名称,
            最大年龄 = p.Max(entity => entity.年龄),
            最小年龄 = p.Min(entity => entity.年龄),
            总和年龄 = p.Sum(entity => entity.年龄),
            平均年龄 = p.Average(entity => entity.年龄),
            班级人数 = p.Count()
        });
        this.divGvResult.InnerHtml = "分组和聚合函数(Lambda)";
        PrintResult(result);

    }
    #endregion
}
```

## 三、LinqToDataSet

```
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LinqToDataSet</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btAll" runat="server" Text="显示所有数据(部门,职务,员工,工资)" 
            onclick="btAll_Click" />
    </div>
    <br />
     <div>
         <asp:Button ID="btEmp" runat="server" Text="查询员工信息" onclick="btEmp_Click" />
         <asp:Button ID="btSalary" runat="server" Text="查询工资" onclick="btSalary_Click" />
         <asp:Button ID="btDeptGroup" runat="server" Text="按部门分组查询" 
             onclick="btDeptGroup_Click" />
         <asp:Button ID="btDeptGroupFunc" runat="server" Text="按部门分组聚合函数统计" 
             onclick="btDeptGroupFunc_Click" />
    </div>   
    <br />
    <div id="divGvResult" runat="server">
        
    </div>
    </form>
</body>
</html>
```

```
/*
 部门(Dept)：部门编号(DeptId)    部门名称(DeptName)
 职务(Post)：编号(PostId)  名称(PostName)  底薪(PostBaseSalary)  绩效系数(PostRatio)
 员工(Emp)：员工编号(EmpId) 所属部门(DeptId) 职务(PostId)   姓名(EmpName)   性别(EmpSex)   生日(EmpBirthday)  
 工资(Salary)：编号(SalaryId)  员工(EmpId)  日期(SalaryDate)  绩效分数(WorkScore)  奖金(Bonus)  扣款(Penalty) 保险(Insurance)
绩效工资 = 底薪*绩效系数*(绩效分数/100)
应发工资 = 底薪+绩效工资+奖金-扣款
税金 = (应发工资-保险-起征点（3500）)*税点(0.03)    --起征点暂定3500，税点暂定0.03（但实际情况为分档式税点）
实发工资 = 应发工资 - 保险 - 税金
*/
public partial class Demo03 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet myDs = new DataSet("myCompany");
            myDs.Tables.Add(CreateDeptToTable());  //添加部门
            myDs.Tables.Add(CreatePostToTable()); //添加职务
            myDs.Tables.Add(CreateEmpToTable()); //添加员工
            myDs.Tables.Add(CreateSalaryToTable()); //添加工资
            ViewState["myCompany"] = myDs;
            //打印全部信息
            this.PrintResult(myDs.Tables["Dept"],"部门信息");
            this.PrintResult(myDs.Tables["Post"], "职务信息");
            this.PrintResult(myDs.Tables["Emp"], "人员信息");
            this.PrintResult(myDs.Tables["Salary"], "工资信息");
        }
    }

    #region gridview打印结果
    private void PrintResult(object datasource,string title)
    {
        GridView gv = new GridView();
        gv.Style[HtmlTextWriterStyle.MarginBottom] = "20px";
        gv.Style[HtmlTextWriterStyle.Width] = "1000px";
        gv.Style[HtmlTextWriterStyle.TextAlign] = "center";
        gv.Caption = title;
        gv.DataSource = datasource;
        gv.DataBind();
        this.divGvResult.Controls.Add(gv);
    }
    #endregion

    #region 创建部门信息
    private DataTable CreateDeptToTable()
    {
        // 部门(DeptInfo)：部门编号(DeptId)    部门名称(DeptName)
        DataTable dt = new DataTable("Dept");
        DataColumn col1 = new DataColumn("DeptId",typeof(int)); //部门编号
        DataColumn col2 = new DataColumn("DeptName",typeof(string));//部门名称
        dt.Columns.Add(col1); dt.Columns.Add(col2);
        DataRow dr = dt.NewRow();
        dr["DeptId"] = 1;
        dr["DeptName"] = "软件部";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr["DeptId"] = 2;
        dr["DeptName"] = "销售部";
        dt.Rows.Add(dr);
        return dt;
    }
    #endregion

    #region 创建职务信息
    private DataTable CreatePostToTable()
    {
        //职务(PostInfo)：编号(PostId)  名称(PostName)  底薪(PostBaseSalary)  绩效系数(PostRatio)
        DataTable dt = new DataTable("Post");
        DataColumn col1 = new DataColumn("PostId", typeof(int)); //职位编号
        DataColumn col2 = new DataColumn("PostName", typeof(string));//职位名称
        DataColumn col3 = new DataColumn("PostBaseSalary", typeof(double));//职位底薪
        DataColumn col4 = new DataColumn("PostRatio", typeof(double));//职位绩效比例
        dt.Columns.Add(col1); dt.Columns.Add(col2); dt.Columns.Add(col3); dt.Columns.Add(col4);
        dt.Rows.Add(1001, "1级经理", 44000, 1);
        dt.Rows.Add(1002, "1级主管", 5000, 0.8);

        dt.Rows.Add(2001, "1级程序猿", 2500, 0.3);
        dt.Rows.Add(2002, "2级程序猿", 3000, 0.4);
        dt.Rows.Add(2003, "3级程序猿", 4000, 0.5);
        dt.Rows.Add(2004, "4级程序猿", 5000, 0.6);

        dt.Rows.Add(3001, "1级销售", 1500, 0.3);
        dt.Rows.Add(3002, "2级销售", 2000, 0.3);
        dt.Rows.Add(3003, "3级销售", 2500, 0.4);

        return dt;
    }
    #endregion

    #region 创建员工信息
    private DataTable CreateEmpToTable()
    {
        // 员工(EmpInfo)：员工编号(EmpId) 所属部门(DeptId) 职务(PostId)   姓名(EmpName)   性别(EmpSex)   生日(EmpBirthday) 
        DataTable dt = new DataTable("Emp");
        dt.Columns.Add("EmpId", typeof(int)); //员工编号
        dt.Columns.Add("DeptId", typeof(int)); //所属部门
        dt.Columns.Add("PostId", typeof(int)); //所属职位
        dt.Columns.Add("EmpName", typeof(string)); //姓名
        dt.Columns.Add("EmpSex", typeof(string)); //性别
        dt.Columns.Add("EmpBirthday", typeof(DateTime)); //生日

        dt.Rows.Add(10001, 1, 1001, "秦总", "男", new DateTime(1985, 5, 5));
        dt.Rows.Add(10002, 1, 1002, "张老大", "男", new DateTime(1988, 8, 8));
        dt.Rows.Add(10003, 1, 2001, "小王", "女", new DateTime(1998, 8, 21));
        dt.Rows.Add(10004, 1, 2002, "小汪", "男", new DateTime(1997, 7, 15));
        dt.Rows.Add(10005, 1, 2003, "杨哥", "男", new DateTime(1995, 9, 5));
        dt.Rows.Add(10006, 1, 2004, "潘哥", "男", new DateTime(1990, 12, 8));
        //
        dt.Rows.Add(20001, 2, 1002, "华老大", "男", new DateTime(1995, 5, 9));
        dt.Rows.Add(20002, 2, 3003, "张姐", "女", new DateTime(1990, 6, 18));
        dt.Rows.Add(20003, 2, 3002, "小周", "女", new DateTime(1997, 2, 28));
        dt.Rows.Add(20005, 2, 3001, "小刘", "女", new DateTime(1999, 12, 8));
        dt.Rows.Add(20008, 2, 3001, "小杨", "男", new DateTime(2000, 1, 1));

        return dt;
    }
    #endregion

    #region 创建工资信息
    private DataTable CreateSalaryToTable()
    { 
         //工资(Salary)：编号(SalaryId)  员工(EmpId)  日期(SalaryDate)  绩效分数(WorkScore)  奖金(Bonus)  扣款(Penalty) 保险(Insurance)
        DataTable dt = new DataTable("Salary");
        dt.Columns.Add("SalaryId", typeof(int));
        dt.Columns.Add("EmpId", typeof(int));
        dt.Columns.Add("SalaryDate", typeof(string));
        dt.Columns.Add("WorkScore", typeof(double));
        dt.Columns.Add("Bonus", typeof(double));
        dt.Columns.Add("Penalty", typeof(double));
        dt.Columns.Add("Insurance", typeof(double));

        dt.Rows.Add(1, 10001, "201803", 75, 3210, 0, 1500);
        dt.Rows.Add(2, 10002, "201803", 80, 200, 30, 850);
        dt.Rows.Add(3, 10003, "201803", 95, 500, 30, 850);
        dt.Rows.Add(4, 10004, "201803", 90, 320, 200, 850);
        dt.Rows.Add(5, 10005, "201803", 85, 850, 300, 850);
        dt.Rows.Add(6, 10006, "201803", 80, 1105, 681.82, 850);

        dt.Rows.Add(7, 20001, "201803", 80, 5210, 227.27, 850);
        dt.Rows.Add(8, 20002, "201803", 95, 7200, 100, 850);
        dt.Rows.Add(9, 20003, "201803", 85, 4000, 0, 850);
        dt.Rows.Add(10, 20005, "201803", 90, 1320, 500, 850);
        dt.Rows.Add(11, 20008, "201803", 95, 2250, 0, 850);
        return dt;
    }
    #endregion

    #region 根据生日计算年龄
    private int GetAge(DateTime birthday)
    {
        int age = DateTime.Now.Year - birthday.Year;
        if (DateTime.Parse(DateTime.Now.ToString("2000-MM-dd")) < DateTime.Parse(birthday.ToString("2000-MM-dd")))
            age--;
        return age;
    }
    #endregion

    #region 显示所有数据(部门,职务,员工,工资)
    protected void btAll_Click(object sender, EventArgs e)
    {
        DataSet myDs = ViewState["myCompany"] as DataSet;
        //打印全部信息
        this.PrintResult(myDs.Tables["Dept"], "部门信息");
        this.PrintResult(myDs.Tables["Post"], "职务信息");
        this.PrintResult(myDs.Tables["Emp"], "人员信息");
        this.PrintResult(myDs.Tables["Salary"], "工资信息");
    }
    #endregion

    #region 查询员工信息
    protected void btEmp_Click(object sender, EventArgs e)
    {
        //查询员工信息：员工编号，部门名称，职务,姓名，性别，年龄，
        DataSet myDs = ViewState["myCompany"] as DataSet;
        var result = from emp in myDs.Tables["Emp"].AsEnumerable()
                     join dept in myDs.Tables["Dept"].AsEnumerable() on emp["DeptId"].ToString() equals dept["DeptId"].ToString()
                     join post in myDs.Tables["Post"].AsEnumerable() on emp["PostId"].ToString() equals post["PostId"].ToString()
                     //let age = new DateTime((DateTime.Now - DateTime.Parse(emp["EmpBirthday"].ToString())).Ticks).Year - 1
                     let age = this.GetAge(DateTime.Parse(emp["EmpBirthday"].ToString()))
                     select new
                     {
                         员工编号 = emp["EmpId"].ToString(),
                         部门名称 = dept["DeptName"].ToString(),
                         职务 = post["PostName"].ToString(),
                         姓名 = emp["EmpName"].ToString(),
                         性别 = emp["EmpSex"].ToString(),
                         年龄 = age                          
                     };
        this.PrintResult(result, "员工信息");
    }
    #endregion

    #region 查询工资情况
    protected void btSalary_Click(object sender, EventArgs e)
    {
        //员工编号，部门名称，职务，姓名，底薪，绩效，奖金，扣款，应发工资，保险，实发工资
        DataSet myDs = ViewState["myCompany"] as DataSet;
        var result = from emp in myDs.Tables["Emp"].AsEnumerable()
                     join dept in myDs.Tables["Dept"].AsEnumerable() on emp["DeptId"].ToString() equals dept["DeptId"].ToString()
                     join post in myDs.Tables["Post"].AsEnumerable() on emp["PostId"].ToString() equals post["PostId"].ToString()
                     join salary in myDs.Tables["Salary"].AsEnumerable() on emp["EmpId"].ToString() equals salary["EmpId"].ToString()
                     let jx = double.Parse(post["PostBaseSalary"].ToString()) * double.Parse(post["PostRatio"].ToString()) * (double.Parse(salary["WorkScore"].ToString()) / 100)  //绩效
                     let yfgz = double.Parse(post["PostBaseSalary"].ToString()) + jx + double.Parse(salary["Bonus"].ToString()) - double.Parse(salary["Penalty"].ToString()) //应发工资
                     let sj = (yfgz - double.Parse(salary["Insurance"].ToString())-3500)*0.03 //税金
                     let sfgz = yfgz - double.Parse(salary["Insurance"].ToString()) - sj //实发工资
                     select new
                     {
                         员工编号 = emp["EmpId"].ToString(),
                         部门名称 = dept["DeptName"].ToString(),
                         职务 = post["PostName"].ToString(),
                         姓名 = emp["EmpName"].ToString(),
                         底薪 = post["PostBaseSalary"].ToString(),
                         绩效 = jx,
                         奖金 = salary["Bonus"].ToString(),
                         扣款 = salary["Penalty"].ToString(),
                         应发工资 = yfgz,
                         保险 = salary["Insurance"].ToString(),
                         实发工资 = sfgz
                     };
        this.PrintResult(result, "员工工资信息");
    }
    #endregion

    #region 按照部门分组查询
    protected void btDeptGroup_Click(object sender, EventArgs e)
    {
        //员工编号，部门名称，职务，姓名，底薪，绩效，奖金，扣款，应发工资，保险，实发工资
        DataSet myDs = ViewState["myCompany"] as DataSet;
        var result = from emp in myDs.Tables["Emp"].AsEnumerable()
                     join dept in myDs.Tables["Dept"].AsEnumerable() on emp["DeptId"].ToString() equals dept["DeptId"].ToString()
                     join post in myDs.Tables["Post"].AsEnumerable() on emp["PostId"].ToString() equals post["PostId"].ToString()
                     join salary in myDs.Tables["Salary"].AsEnumerable() on emp["EmpId"].ToString() equals salary["EmpId"].ToString()
                     let jx = double.Parse(post["PostBaseSalary"].ToString()) * double.Parse(post["PostRatio"].ToString()) * (double.Parse(salary["WorkScore"].ToString()) / 100)  //绩效
                     let yfgz = double.Parse(post["PostBaseSalary"].ToString()) + jx + double.Parse(salary["Bonus"].ToString()) - double.Parse(salary["Penalty"].ToString()) //应发工资
                     let sj = (yfgz - double.Parse(salary["Insurance"].ToString()) - 3500) * 0.03 //税金
                     let sfgz = yfgz - double.Parse(salary["Insurance"].ToString()) - sj //实发工资
                     select new
                     {
                         员工编号 = emp["EmpId"].ToString(),
                         部门编号 = dept["DeptId"].ToString(),
                         部门名称 = dept["DeptName"].ToString(),
                         职务 = post["PostName"].ToString(),
                         姓名 = emp["EmpName"].ToString(),
                         底薪 = post["PostBaseSalary"].ToString(),
                         绩效 = jx,
                         奖金 = salary["Bonus"].ToString(),
                         扣款 = salary["Penalty"].ToString(),
                         应发工资 = yfgz,
                         保险 = salary["Insurance"].ToString(),
                         实发工资 = sfgz
                     }
                    into tempTable
                   group tempTable by new { tempTable.部门编号,tempTable.部门名称};
        foreach (var item in result)
        {
            this.PrintResult(item, item.Key.部门名称);
        }
    }
    #endregion

    #region 按部门分组聚合函数统计
    protected void btDeptGroupFunc_Click(object sender, EventArgs e)
    {
        //员工编号，部门名称，职务，姓名，底薪，绩效，奖金，扣款，应发工资，保险，实发工资
        DataSet myDs = ViewState["myCompany"] as DataSet;
        var result = from emp in myDs.Tables["Emp"].AsEnumerable()
                     join dept in myDs.Tables["Dept"].AsEnumerable() on emp["DeptId"].ToString() equals dept["DeptId"].ToString()
                     join post in myDs.Tables["Post"].AsEnumerable() on emp["PostId"].ToString() equals post["PostId"].ToString()
                     join salary in myDs.Tables["Salary"].AsEnumerable() on emp["EmpId"].ToString() equals salary["EmpId"].ToString()
                     let jx = double.Parse(post["PostBaseSalary"].ToString()) * double.Parse(post["PostRatio"].ToString()) * (double.Parse(salary["WorkScore"].ToString()) / 100)  //绩效
                     let yfgz = double.Parse(post["PostBaseSalary"].ToString()) + jx + double.Parse(salary["Bonus"].ToString()) - double.Parse(salary["Penalty"].ToString()) //应发工资
                     let sj = (yfgz - double.Parse(salary["Insurance"].ToString()) - 3500) * 0.03 //税金
                     let sfgz = yfgz - double.Parse(salary["Insurance"].ToString()) - sj //实发工资
                     select new
                     {
                         员工编号 = emp["EmpId"].ToString(),
                         部门编号 = dept["DeptId"].ToString(),
                         部门名称 = dept["DeptName"].ToString(),
                         职务 = post["PostName"].ToString(),
                         姓名 = emp["EmpName"].ToString(),
                         底薪 = post["PostBaseSalary"].ToString(),
                         绩效 = jx,
                         奖金 = salary["Bonus"].ToString(),
                         扣款 = salary["Penalty"].ToString(),
                         应发工资 = yfgz,
                         保险 = salary["Insurance"].ToString(),
                         实发工资 = sfgz
                     }
                    into tempTable
                    group tempTable by new { tempTable.部门编号, tempTable.部门名称 }
                    into resultGroup
                    select new { 
                         部门名称 = resultGroup.Key.部门名称,
                         员工人数 = resultGroup.Count(),
                         工资总和 = resultGroup.Sum(p=>p.实发工资),
                         平均工资 = resultGroup.Average(p => p.实发工资),
                         最高工资 = resultGroup.Max(p => p.实发工资),
                         最低工资 = resultGroup.Min(p => p.实发工资)
                    };
        this.PrintResult(result, "按部门工资统计");

    }
    #endregion
}
```

## 四、LinqToSQL

**数据库代码：**

```
--专业
create table Major
(
	MajorId int primary key identity(1,1), --编号
	MajorName varchar(50) not null --专业名称
)
insert into Major(MajorName) values('计算机科学与应用')
insert into Major(MajorName) values('建筑学')
insert into Major(MajorName) values('美术学')
insert into Major(MajorName) values('戏剧与影视学')

--学生
create table Student
(
	StudentId int primary key identity(1,1), --编号
	MajorId int not null, --专业编号
	StudentName varchar(50) not null, --学生姓名
	StudentSex varchar(50) not null, --学生性别
	StudentPhone varchar(50) not null, --电话
	StudentMail varchar(50) not null, --邮箱
	StudentImg varchar(50) not null --相片
)

insert into Student(MajorId,StudentName,StudentSex,StudentPhone,StudentMail,StudentImg)
values(1,'刘备','男','13554878965','liubei@qq.com','1.jpg')
insert into Student(MajorId,StudentName,StudentSex,StudentPhone,StudentMail,StudentImg)
values(1,'关羽','男','15389874521','guanyu@qq.com','2.jpg')
insert into Student(MajorId,StudentName,StudentSex,StudentPhone,StudentMail,StudentImg)
values(2,'张飞','男','18987542525','zhangfei@qq.com','3.jpg')
insert into Student(MajorId,StudentName,StudentSex,StudentPhone,StudentMail,StudentImg)
values(2,'赵云','男','13696896547','zhaoyun@qq.com','4.jpg')
insert into Student(MajorId,StudentName,StudentSex,StudentPhone,StudentMail,StudentImg)
values(3,'黄忠','男','13778777888','huangzhong@qq.com','5.jpg')
insert into Student(MajorId,StudentName,StudentSex,StudentPhone,StudentMail,StudentImg)
values(3,'马超','男','13221212325','machao@qq.com','6.jpg')
insert into Student(MajorId,StudentName,StudentSex,StudentPhone,StudentMail,StudentImg)
values(4,'魏延','男','13996147455','weiyan@qq.com','7.jpg')
insert into Student(MajorId,StudentName,StudentSex,StudentPhone,StudentMail,StudentImg)
values(4,'周仓','男','13437522241','zhoucang@qq.com','8.jpg')
insert into Student(MajorId,StudentName,StudentSex,StudentPhone,StudentMail,StudentImg)
values(4,'貂蝉','女','13554785478','diaochan@qq.com','9.jpg')
insert into Student(MajorId,StudentName,StudentSex,StudentPhone,StudentMail,StudentImg)
values(3,'孙尚香','女','13669989665','ssx@qq.com','10.jpg')
```

数据库创建完成之后使用开发工具创建LinqToSql类文件。

**功能实现代码：**

```
<form id="form1" runat="server">
<div>
    <asp:Button ID="Button1" runat="server" Text="显示原始专业信息" 
    onclick="Button1_Click" />
    <asp:Button ID="Button2" runat="server" Text="显示原始学生信息" 
    onclick="Button2_Click" />
    <asp:Button ID="Button3" runat="server" Text="SQL显示性别为男学生信息" 
    onclick="Button3_Click" />
    <asp:Button ID="Button4" runat="server" Text="LinQ显示性别为女学生信息" 
    onclick="Button4_Click" />
    <asp:Button ID="Button5" runat="server" Text="Lambda显示性别为女学生信息" 
    onclick="Button5_Click" />
    <asp:Button ID="Button6" runat="server" Text="学生信息导出Excel"                 		     OnClick="Button6_Click"  />
</div>   
<br />
    <div id="divGvResult">
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </div>
</form>
```

```
public partial class Demo04 : System.Web.UI.Page
{

    public override void VerifyRenderingInServerForm(Control control)
    {
        // Confirms that an HtmlForm control is rendered for
    }

    DataClassesDataContext linqdb = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region 显示原始专业信息
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.GridView1.AutoGenerateColumns = true;  //自动列
        this.GridView1.Columns.Clear();
        this.GridView1.DataSource = linqdb.Major;
        this.GridView1.Caption = "显示原始专业信息";
        this.GridView1.DataBind();
    }
    #endregion

    #region 显示原始学生信息
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.GridView1.AutoGenerateColumns = true;  //自动列
        this.GridView1.Columns.Clear();
        this.GridView1.DataSource = linqdb.Student;
        this.GridView1.Caption = "原始专业信息";
        this.GridView1.DataBind();
    }
    #endregion

    public class MyStu
    {
        public int StudentId { get; set; }
        public string MajorName { get; set; }
        public string StudentName { get; set; }
        public string StudentSex { get; set; }
        public string StudentPhone { get; set; }
        public string StudentMail { get; set; }
    }

    #region SQL显示性别为男学生信息(显示专业名称)
    protected void Button3_Click(object sender, EventArgs e)
    {
        //单表查询
        //string sql = "select * from Student where StudentSex = '男'";
        ////List<Student> list = linqdb.ExecuteQuery<Student>(sql).ToList();
        //var list = linqdb.ExecuteQuery<Student>(sql);
        //this.GridView1.AutoGenerateColumns = true;  //自动列
        //this.GridView1.Columns.Clear();
        //this.GridView1.DataSource = list;
        //this.GridView1.DataBind();

        //多表查询(当linq中没有表关系的时候)(自定义一个类)
        string sql = "select * from Student inner join Major on Student.MajorId = Major.MajorId where StudentSex = '男'";
        var list = linqdb.ExecuteQuery<MyStu>(sql);

        //多表查询(当linq中有表关系的时候)
        //string sql = "select * from Student  where StudentSex = '男'";
        //var list = linqdb.ExecuteQuery<Student>(sql);

        this.GridView1.AutoGenerateColumns = false;  //取消自动列
        this.GridView1.Columns.Clear();

        BoundField field1 = new BoundField();
        field1.HeaderText = "学生编号";
        field1.DataField = "StudentId";
        this.GridView1.Columns.Add(field1);

        BoundField field2 = new BoundField();
        field2.HeaderText = "专业名称";
        field2.DataField = "MajorName";  //当linq中没有表关系的时候
        //field2.DataField = "Major.MajorName";  //当linq中有表关系的时候
        this.GridView1.Columns.Add(field2);

        BoundField field3 = new BoundField();
        field3.HeaderText = "学生姓名";
        field3.DataField = "StudentName";
        this.GridView1.Columns.Add(field3);

        BoundField field4 = new BoundField();
        field4.HeaderText = "学生性别";
        field4.DataField = "StudentSex";
        this.GridView1.Columns.Add(field4);

        BoundField field5 = new BoundField();
        field5.HeaderText = "学生电话";
        field5.DataField = "StudentPhone";
        this.GridView1.Columns.Add(field5);

        BoundField field6 = new BoundField();
        field6.HeaderText = "学生邮箱";
        field6.DataField = "StudentMail";
        this.GridView1.Columns.Add(field6);

        this.GridView1.DataSource = list;
        this.GridView1.DataBind();

    }
    #endregion

    #region linq显示性别为女学生信息(显示专业名称)
    protected void Button4_Click(object sender, EventArgs e)
    {
        //linq文件中如果没有关系
        var result = from Student stu in linqdb.Student
                     join Major major in linqdb.Major on stu.MajorId equals major.MajorId
                     where stu.StudentSex.Equals("女")
                     select new
                     {
                         学生编号 = stu.StudentId,
                         专业名称 = major.MajorName,
                         学生姓名 = stu.StudentName,
                         学生性别 = stu.StudentSex,
                         学生电话 = stu.StudentPhone,
                         学生邮箱 = stu.StudentMail
                     };
        this.GridView1.AutoGenerateColumns = true;  //自动列
        this.GridView1.Columns.Clear();
        this.GridView1.DataSource = result;
        this.GridView1.DataBind();

        //linq文件中如果有关系
        //var result = from Student stu in linqdb.Student
        //             where stu.StudentSex.Equals("女")
        //             select new
        //             {
        //                 学生编号 = stu.StudentId,
        //                 专业名称 = stu.Major.MajorName,
        //                 学生姓名 = stu.StudentName,
        //                 学生性别 = stu.StudentSex,
        //                 学生电话 = stu.StudentPhone,
        //                 学生邮箱 = stu.StudentMail
        //             };
        //this.GridView1.AutoGenerateColumns = true;  //自动列
        //this.GridView1.Columns.Clear();
        //this.GridView1.DataSource = result;
        //this.GridView1.DataBind();

    }
    #endregion

    #region Lambda显示性别为女学生信息(显示专业名称)
    protected void Button5_Click(object sender, EventArgs e)
    {
        //linq文件中如果没有关系
        var result = linqdb.Student.Join(linqdb.Major, stu => stu.MajorId, major => major.MajorId, (stu, major) => new
        {
            学生编号 = stu.StudentId,
            专业名称 = major.MajorName,
            学生姓名 = stu.StudentName,
            学生性别 = stu.StudentSex,
            学生电话 = stu.StudentPhone,
            学生邮箱 = stu.StudentMail
        }).Where(p => p.学生性别.Equals("女"));
        this.GridView1.AutoGenerateColumns = true;  //自动列
        this.GridView1.Columns.Clear();
        this.GridView1.DataSource = result;
        this.GridView1.DataBind();

        //linq文件中如果有关系
        //var result = linqdb.Student.Where(p => p.StudentSex.Equals("女")).Select(p=>new { 
        //    学生编号 = p.StudentId,
        //    专业名称 = p.Major.MajorName,
        //    学生姓名 = p.StudentName,
        //    学生性别 = p.StudentSex,
        //    学生电话 = p.StudentPhone,
        //    学生邮箱 = p.StudentMail
        //});
        //this.GridView1.AutoGenerateColumns = true;  //自动列
        //this.GridView1.Columns.Clear();
        //this.GridView1.DataSource = result;
        //this.GridView1.DataBind();
    }
    #endregion

    #region 学生信息导出Excel
    protected void Button6_Click(object sender, EventArgs e)
    {
        Response.ClearContent(); //清空缓冲区所有内容的输出
        //Response.Charset = "UTF-8";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
        Response.ContentType = "application/ms-excel";
        Response.AppendHeader("content-disposition", "attachment;filename=test.xls");
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        this.GridView1.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
        /*
         此方法需要正常运行，需要重写page方法VerifyRenderingInServerForm
         * MSDN对该方法的解释如下：
            必须位于 <form runat=server> 标记中的控件可以在呈现之前调用此方法，以便在控件被置于标记外时显示错误信息。发送回或依赖于注册的脚本块的控件应该在 Control.Render 方法的重写中调用此方法。呈现服务器窗体元素的方式不同的页可以重写此方法以在不同的条件下引发异常。

            如果回发或使用客户端脚本的服务器控件没有包含在 HtmlForm 服务器控件 (<form runat="server">) 标记中，它们将无法正常工作。这些控件可以在呈现时调用该方法，以在它们没有包含在 HtmlForm 控件中时提供明确的错误信息。
         * 
         * 
         * 固定资产管理系统中有操作Excel，Word封装类
         */
    }
    #endregion
}
```

## 五、LinqToXML

**XML文件：**

```
<?xml version="1.0" encoding="utf-8" ?>
<StuInfo>
  <Student StuNo="001">
    <StuName>刘备</StuName>
    <StuSex>男</StuSex>
  </Student>
  <Student StuNo="002">
    <StuName>关羽</StuName>
    <StuSex>男</StuSex>
  </Student>
  <Student StuNo="003">
    <StuName>张飞</StuName>
    <StuSex>男</StuSex>
  </Student>
  <Student StuNo="004">
    <StuName>大乔</StuName>
    <StuSex>女</StuSex>
  </Student>
  <Student StuNo="005">
    <StuName>小乔</StuName>
    <StuSex>女</StuSex>
  </Student>
</StuInfo>
```

**功能实现代码：**

```
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LinqToXML</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btReadXML" runat="server" Text="读取XML文件" 
            onclick="btReadXML_Click" />
    </div>
    <div>
        <asp:GridView ID="gvStudent" runat="server" Width="883px">
        </asp:GridView>
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

    }

    #region 读取XML文件
    protected void btReadXML_Click(object sender, EventArgs e)
    {
        XDocument xDoc = XDocument.Load(Server.MapPath("Student.xml"));
        var r = xDoc.Descendants("Student").Select(p => new
        {
            学号 = p.Attribute("StuNo").Value,
            姓名 = p.Element("StuName").Value,
            性别 = p.Element("StuSex").Value
        });
        this.gvStudent.DataSource = r;
        this.gvStudent.DataBind();
    }
    #endregion
}
```

## 六、资料准备

下面章节例子都基于此章节提供的资料。

**数据库代码：**

```
--专业
create table Major
(
	MajorId int primary key identity(1,1), --编号
	MajorName varchar(50) not null --专业名称
)
insert into Major(MajorName) values('计算机科学与应用')
insert into Major(MajorName) values('建筑学')
insert into Major(MajorName) values('美术学')
insert into Major(MajorName) values('戏剧与影视学')
insert into Major(MajorName) values('国际贸易')

--学生
create table Student
(
	StudentId int primary key identity(1,1), --编号
	MajorId int not null, --专业编号
	StudentName varchar(50) not null, --学生姓名
	StudentSex varchar(50) not null, --学生性别
	StudentPhone varchar(50) not null, --电话
	StudentMail varchar(50) not null, --邮箱
)

insert into Student(MajorId,StudentName,StudentSex,StudentPhone,StudentMail)
values(1,'刘备','男','13554878965','liubei@qq.com')
insert into Student(MajorId,StudentName,StudentSex,StudentPhone,StudentMail)
values(1,'关羽','男','15389874521','guanyu@qq.com')
insert into Student(MajorId,StudentName,StudentSex,StudentPhone,StudentMail)
values(2,'张飞','男','18987542525','zhangfei@qq.com')
insert into Student(MajorId,StudentName,StudentSex,StudentPhone,StudentMail)
values(2,'赵云','男','13696896547','zhaoyun@qq.com')
insert into Student(MajorId,StudentName,StudentSex,StudentPhone,StudentMail)
values(3,'黄忠','男','13778777888','huangzhong@qq.com')
insert into Student(MajorId,StudentName,StudentSex,StudentPhone,StudentMail)
values(3,'马超','男','13221212325','machao@qq.com')
insert into Student(MajorId,StudentName,StudentSex,StudentPhone,StudentMail)
values(4,'魏延','男','13996147455','weiyan@qq.com')
insert into Student(MajorId,StudentName,StudentSex,StudentPhone,StudentMail)
values(4,'周仓','男','13437522241','zhoucang@qq.com')
insert into Student(MajorId,StudentName,StudentSex,StudentPhone,StudentMail)
values(99,'曹操','男','13437522241','zhoucang@qq.com')
--签到签退表
create table SignInOut
(
	SignId int primary key identity(1,1), --编号
	StudentId int not null, --学生编号
	SignTitle varchar(10) not null, --签到或签退
	SignTime datetime not null
)
insert into SignInOut(StudentId,SignTitle,SignTime)
values(1,'签到','2019-1-1 8:30:00')
insert into SignInOut(StudentId,SignTitle,SignTime)
values(1,'签退','2019-1-1 17:30:00')
insert into SignInOut(StudentId,SignTitle,SignTime)
values(2,'签到','2019-1-1 8:30:00')
insert into SignInOut(StudentId,SignTitle,SignTime)
values(2,'签退','2019-1-1 17:30:00')
insert into SignInOut(StudentId,SignTitle,SignTime)
values(3,'签到','2019-1-1 8:30:00')
insert into SignInOut(StudentId,SignTitle,SignTime)
values(3,'签退','2019-1-1 17:30:00')
insert into SignInOut(StudentId,SignTitle,SignTime)
values(100,'签到','2019-1-1 8:30:00')
insert into SignInOut(StudentId,SignTitle,SignTime)
values(100,'签退','2019-1-1 17:30:00')
```

## 七、使用LinqToSql插入，修改，删除数据

**学生信息列表和删除：**

```
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <p><a href="Demo01_Add.aspx" target="_blank">添加学生</a></p>
    <div>
        <asp:GridView ID="gvStudent" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" Width="802px" DataKeyNames="StudentId" onrowdeleting="gvStudent_RowDeleting">
            <Columns>
                <asp:BoundField DataField="StudentId" HeaderText="学生编号" />
                <asp:BoundField DataField="StudentName" HeaderText="学生姓名" />
                <asp:BoundField DataField="MajorName" HeaderText="专业名称" />
                <asp:BoundField DataField="StudentSex" HeaderText="学生性别" />
                <asp:BoundField DataField="StudentPhone" HeaderText="学生电话" />
                <asp:BoundField DataField="StudentMail" HeaderText="学生邮箱" />
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <a href="Demo01_Edit.aspx?stuid=<%#Eval("StudentId") %>" target="_blank">编辑</a>
                        <asp:LinkButton ID="lbDelete" runat="server" CommandName="delete">删除</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
```

```
public partial class Demo01 : System.Web.UI.Page
{
    DataClassesDataContext linqdb = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        var query = from stu in linqdb.Student
                    join ma in linqdb.Major on stu.MajorId equals ma.MajorId
                    select new
                    {
                        StudentId = stu.StudentId,
                        MajorId = stu.MajorId,
                        MajorName = ma.MajorName,
                        StudentName = stu.StudentName,
                        StudentSex = stu.StudentSex,
                        StudentPhone = stu.StudentPhone,
                        StudentMail = stu.StudentMail
                    };
        this.gvStudent.DataSource = query.ToList();
        this.gvStudent.DataBind();
    }

    protected void gvStudent_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int stuId = int.Parse(this.gvStudent.DataKeys[e.RowIndex].Value.ToString());
        Student stu = linqdb.Student.SingleOrDefault(p => p.StudentId == stuId);
        linqdb.Student.DeleteOnSubmit(stu);
        linqdb.SubmitChanges();
        Response.Redirect("Demo01.aspx");
    }
}
```

**学员信息添加：**

```
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h1>添加学生</h1>
    <div>
        <p>
            学生专业:<asp:DropDownList ID="ddlMajor" runat="server"></asp:DropDownList>
        </p>
        <p>
            学生姓名:<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        </p>
        <p>
            学生性别:
            <asp:RadioButton ID="rbBoy" runat="server" Text="男" GroupName="sex" Checked="true" /> 
            <asp:RadioButton ID="rbGirl" runat="server" Text="女" GroupName="sex" />
        </p>
        <p>
            学生电话:<asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
        </p>
        <p>
            学生邮箱:<asp:TextBox ID="txtMail" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btAdd" runat="server" Text="添加学生" onclick="btAdd_Click" />
        </p>
    </div>
    </form>
</body>
</html>
```

```
public partial class Demo01_Add : System.Web.UI.Page
{
    DataClassesDataContext linqdb = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindData();
    }

    private void BindData()
    {
        this.ddlMajor.DataValueField = "MajorId";
        this.ddlMajor.DataTextField = "MajorName";
        this.ddlMajor.DataSource = linqdb.Major.ToList();
        this.ddlMajor.DataBind();
        this.ddlMajor.Items.Insert(0,new ListItem("--请选择--",""));
    }

    protected void btAdd_Click(object sender, EventArgs e)
    {
        Student stu = new Student();
        stu.MajorId = int.Parse(this.ddlMajor.SelectedValue);
        stu.StudentName = this.txtName.Text;
        stu.StudentSex = this.rbBoy.Checked == true ? "男" : "女";
        stu.StudentPhone = this.txtPhone.Text;
        stu.StudentMail = this.txtMail.Text;
        linqdb.Student.InsertOnSubmit(stu);
        linqdb.SubmitChanges();
        Response.Redirect("Demo01.aspx");
    }
}
```

**学员信息的编辑修改：**

```
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h1>编辑学生</h1>
    <div>
        <p>
            学生专业:<asp:DropDownList ID="ddlMajor" runat="server"></asp:DropDownList>
        </p>
        <p>
            学生姓名:<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        </p>
        <p>
            学生性别:
            <asp:RadioButton ID="rbBoy" runat="server" Text="男" GroupName="sex" Checked="true" /> 
            <asp:RadioButton ID="rbGirl" runat="server" Text="女" GroupName="sex" />
        </p>
        <p>
            学生电话:<asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
        </p>
        <p>
            学生邮箱:<asp:TextBox ID="txtMail" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btEdit" runat="server" Text="编辑学生" onclick="btEdit_Click" />
        </p>
    </div>
    </form>
</body>
</html>
```

```
public partial class Demo01_Edit : System.Web.UI.Page
{
    DataClassesDataContext linqdb = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindData();
    }

    private void BindData()
    {
        //绑定下拉框选项
        this.ddlMajor.DataValueField = "MajorId";
        this.ddlMajor.DataTextField = "MajorName";
        this.ddlMajor.DataSource = linqdb.Major.ToList();
        this.ddlMajor.DataBind();
        this.ddlMajor.Items.Insert(0, new ListItem("--请选择--", ""));
        //绑定详情
        int stuId = int.Parse(Request["stuid"]);
        Student stu = linqdb.Student.SingleOrDefault(p => p.StudentId == stuId);
        this.ddlMajor.SelectedValue = stu.MajorId.ToString();
        this.txtName.Text = stu.StudentName;
        if (stu.StudentSex.Equals("男"))
            this.rbBoy.Checked = true;
        if (stu.StudentSex.Equals("女"))
            this.rbGirl.Checked = true;
        this.txtPhone.Text = stu.StudentPhone;
        this.txtMail.Text = stu.StudentMail;
    }

    protected void btEdit_Click(object sender, EventArgs e)
    {
        int stuId = int.Parse(Request["stuid"]);
        Student stu = linqdb.Student.SingleOrDefault(p => p.StudentId == stuId);
        stu.MajorId = int.Parse(this.ddlMajor.SelectedValue);
        stu.StudentName = this.txtName.Text;
        stu.StudentSex = this.rbBoy.Checked == true ? "男" : "女";
        stu.StudentPhone = this.txtPhone.Text;
        stu.StudentMail = this.txtMail.Text;
        linqdb.SubmitChanges();
        Response.Redirect("Demo01.aspx");
    }
}
```

## 八、inner join(内连接)

两表中不符合关系的数据不会显示。

```
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h2>inner join(内连接):两表中不符合关系的数据不会显示</h2>
    <div>
        <asp:GridView ID="gvStudent" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" Width="802px" >
            <Columns>
                <asp:BoundField DataField="StudentId" HeaderText="学生编号" />
                <asp:BoundField DataField="StudentName" HeaderText="学生姓名" />
                <asp:BoundField DataField="MajorName" HeaderText="专业名称" />
                <asp:BoundField DataField="StudentSex" HeaderText="学生性别" />
                <asp:BoundField DataField="StudentPhone" HeaderText="学生电话" />
                <asp:BoundField DataField="StudentMail" HeaderText="学生邮箱" />
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
```

```
public partial class Demo02_01InnerJoin : System.Web.UI.Page
{
    DataClassesDataContext linqdb = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        var query = from stu in linqdb.Student
                    join ma in linqdb.Major on stu.MajorId equals ma.MajorId
                    select new
                    {
                        StudentId = stu.StudentId,
                        MajorId = stu.MajorId,
                        MajorName = ma.MajorName,
                        StudentName = stu.StudentName,
                        StudentSex = stu.StudentSex,
                        StudentPhone = stu.StudentPhone,
                        StudentMail = stu.StudentMail
                    };
        this.gvStudent.DataSource = query.ToList();
        this.gvStudent.DataBind();
    }
}
```

## 九、left join(左外连接)

以左表（学生表）为主,左表所有数据显示,右表不符合关系的不显示。

以左表（专业表）为主,左表所有数据显示,右表不符合关系的不显示。

```
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h2>left join(左外连接):以左表（学生表）为主,左表所有数据显示,右表不符合关系的不显示</h2>
    <div>
        <asp:GridView ID="gvStudent1" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" Width="802px" >
            <Columns>
                <asp:BoundField DataField="StudentId" HeaderText="学生编号" />
                <asp:BoundField DataField="StudentName" HeaderText="学生姓名" />
                <asp:BoundField DataField="MajorName" HeaderText="专业名称" />
                <asp:BoundField DataField="StudentSex" HeaderText="学生性别" />
                <asp:BoundField DataField="StudentPhone" HeaderText="学生电话" />
                <asp:BoundField DataField="StudentMail" HeaderText="学生邮箱" />
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
    </div>

        <h2>left join(左外连接):以左表（专业表）为主,左表所有数据显示,右表不符合关系的不显示</h2>
    <div>
        <asp:GridView ID="gvStudent2" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" Width="802px" >
            <Columns>
                <asp:BoundField DataField="StudentId" HeaderText="学生编号" />
                <asp:BoundField DataField="StudentName" HeaderText="学生姓名" />
                <asp:BoundField DataField="MajorName" HeaderText="专业名称" />
                <asp:BoundField DataField="StudentSex" HeaderText="学生性别" />
                <asp:BoundField DataField="StudentPhone" HeaderText="学生电话" />
                <asp:BoundField DataField="StudentMail" HeaderText="学生邮箱" />
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
```

```
public partial class Demo02_02LeftJoin : System.Web.UI.Page
{
    DataClassesDataContext linqdb = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        var query1 = from stu in linqdb.Student
                    join ma in linqdb.Major on stu.MajorId equals ma.MajorId
                    into StuAndMajor
                    from stuAndMajor in StuAndMajor.DefaultIfEmpty()
                    select new
                    {
                        StudentId = stu.StudentId,
                        MajorId = stu.MajorId,
                        MajorName = stuAndMajor.MajorName,
                        StudentName = stu.StudentName,
                        StudentSex = stu.StudentSex,
                        StudentPhone = stu.StudentPhone,
                        StudentMail = stu.StudentMail
                    };
        this.gvStudent1.DataSource = query1.ToList();
        this.gvStudent1.DataBind();

        var query2 = from ma in linqdb.Major
                     join stu in linqdb.Student on ma.MajorId equals stu.MajorId
                     into StuAndMajor
                     from stuAndMajor in StuAndMajor.DefaultIfEmpty()
                     select new
                     {
                         StudentId = stuAndMajor.StudentId == null ? "" : stuAndMajor.StudentId.ToString(),
                         MajorId = ma.MajorId,
                         MajorName = ma.MajorName,
                         StudentName = stuAndMajor.StudentName,
                         StudentSex = stuAndMajor.StudentSex,
                         StudentPhone = stuAndMajor.StudentPhone,
                         StudentMail = stuAndMajor.StudentMail
                     };
        this.gvStudent2.DataSource = query2.ToList();
        this.gvStudent2.DataBind();
    }
}
```

## 十、full join(全外连接)

不管是否符合关系的两表数据都会显示。

```
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h2>full join(全外连接):不管是否符合关系的两表数据都会显示</h2>
    <div>
        <asp:GridView ID="gvStudent" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" Width="802px" >
            <Columns>
                <asp:BoundField DataField="StudentId" HeaderText="学生编号" />
                <asp:BoundField DataField="StudentName" HeaderText="学生姓名" />
                <asp:BoundField DataField="MajorName" HeaderText="专业名称" />
                <asp:BoundField DataField="StudentSex" HeaderText="学生性别" />
                <asp:BoundField DataField="StudentPhone" HeaderText="学生电话" />
                <asp:BoundField DataField="StudentMail" HeaderText="学生邮箱" />
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
```

```
public partial class Demo02_03FullJoin : System.Web.UI.Page
{
    DataClassesDataContext linqdb = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        var query1 = from stu in linqdb.Student
                     join ma in linqdb.Major on stu.MajorId equals ma.MajorId
                     into StuAndMajor
                     from stuAndMajor in StuAndMajor.DefaultIfEmpty()
                     select new
                     {
                         StudentId = stu.StudentId.ToString(),
                         MajorId = stu.MajorId,
                         MajorName = stuAndMajor.MajorName,
                         StudentName = stu.StudentName,
                         StudentSex = stu.StudentSex,
                         StudentPhone = stu.StudentPhone,
                         StudentMail = stu.StudentMail
                     };

        var query2 = from ma in linqdb.Major
                     join stu in linqdb.Student on ma.MajorId equals stu.MajorId
                     into StuAndMajor
                     from stuAndMajor in StuAndMajor.DefaultIfEmpty()
                     select new
                     {
                         StudentId = stuAndMajor.StudentId == null ? "" : stuAndMajor.StudentId.ToString(),
                         MajorId = ma.MajorId,
                         MajorName = ma.MajorName,
                         StudentName = stuAndMajor.StudentName,
                         StudentSex = stuAndMajor.StudentSex,
                         StudentPhone = stuAndMajor.StudentPhone,
                         StudentMail = stuAndMajor.StudentMail
                     };
        var query3 = query1.Concat(query2).Distinct();
        this.gvStudent.DataSource = query3;
        this.gvStudent.DataBind();
    }
}
```

## 十一、cross join(笛卡尔积)

把表A和表B的数据进行一个N*M的组合，即笛卡尔积。

```
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h2>cross join(笛卡尔积):把表A和表B的数据进行一个N*M的组合，即笛卡尔积</h2>
    <div>
        <asp:GridView ID="gvStudent" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" Width="802px" >
            <Columns>
                <asp:BoundField DataField="StudentId" HeaderText="学生编号" />
                <asp:BoundField DataField="StudentName" HeaderText="学生姓名" />
                <asp:BoundField DataField="MajorName" HeaderText="专业名称" />
                <asp:BoundField DataField="StudentSex" HeaderText="学生性别" />
                <asp:BoundField DataField="StudentPhone" HeaderText="学生电话" />
                <asp:BoundField DataField="StudentMail" HeaderText="学生邮箱" />
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
```

```
public partial class Demo02_04CrossJoin : System.Web.UI.Page
{
    DataClassesDataContext linqdb = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        var query = from stu in linqdb.Student
                    from ma in linqdb.Major 
                    select new
                    {
                        StudentId = stu.StudentId,
                        MajorId = stu.MajorId,
                        MajorName = ma.MajorName,
                        StudentName = stu.StudentName,
                        StudentSex = stu.StudentSex,
                        StudentPhone = stu.StudentPhone,
                        StudentMail = stu.StudentMail
                    };
        int a = query.Count();
        this.gvStudent.DataSource = query.ToList();
        this.gvStudent.DataBind();
    }
}
```

## 十二、三表left join

3张表Left join显示学生签到签退情况（不管学生是否有签到签退记录都显示全部的学生信息）。

```
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h2>3张表Left join显示学生签到签退情况（不管学生是否有签到签退记录都显示全部的学生信息）</h2>
    <div>
        <asp:GridView ID="gvStudent" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" Width="1000px" >
            <Columns>
                <asp:BoundField DataField="StudentId" HeaderText="学生编号" />
                <asp:BoundField DataField="StudentName" HeaderText="学生姓名" />
                <asp:BoundField DataField="MajorName" HeaderText="专业名称" />
                <asp:BoundField DataField="StudentSex" HeaderText="学生性别" />
                <asp:BoundField DataField="StudentPhone" HeaderText="学生电话" />
                <asp:BoundField DataField="StudentMail" HeaderText="学生邮箱" />
                <asp:BoundField DataField="SignTitle" HeaderText="行为" />
                <asp:BoundField DataField="SignTime" HeaderText="时间" />
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
```

```
public partial class Demo03 : System.Web.UI.Page
{
    DataClassesDataContext linqdb = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        var query = from stu in linqdb.Student
                     join ma in linqdb.Major on stu.MajorId equals ma.MajorId
                     into A from a in A.DefaultIfEmpty()
                     join sign in linqdb.SignInOut on stu.StudentId equals sign.StudentId
                     into B from b in B.DefaultIfEmpty()
                     select new
                     {
                         StudentId = stu.StudentId,
                         MajorId = stu.MajorId,
                         MajorName = a.MajorName,
                         StudentName = stu.StudentName,
                         StudentSex = stu.StudentSex,
                         StudentPhone = stu.StudentPhone,
                         StudentMail = stu.StudentMail,
                         SignTitle = b.SignTitle,
                         SignTime = b.SignTime == null ? "" : b.SignTime.ToString()
                     };
        this.gvStudent.DataSource = query.ToList();
        this.gvStudent.DataBind();
    }
}
```

## 十三、同时left join和right join

3张表同时Left Join和Right Join（显示所有的打卡记录，不管打卡记录中的学生编号是否正确）

```
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h2>3张表同时Left Join和Right Join（显示所有的打卡记录，不管打卡记录中的学生编号是否正确）</h2>
    <div>
        <asp:GridView ID="gvStudent" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" Width="1000px" >
            <Columns>
                <asp:BoundField DataField="StudentId" HeaderText="学生编号" />
                <asp:BoundField DataField="StudentName" HeaderText="学生姓名" />
                <asp:BoundField DataField="MajorName" HeaderText="专业名称" />
                <asp:BoundField DataField="StudentSex" HeaderText="学生性别" />
                <asp:BoundField DataField="StudentPhone" HeaderText="学生电话" />
                <asp:BoundField DataField="StudentMail" HeaderText="学生邮箱" />
                <asp:BoundField DataField="SignTitle" HeaderText="行为" />
                <asp:BoundField DataField="SignTime" HeaderText="时间" />
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
```

```
public partial class Demo04 : System.Web.UI.Page
{
    DataClassesDataContext linqdb = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        //var query = from sign in linqdb.SignInOut
        //                   join b in
        //                    (from stu in linqdb.Student
        //                     join ma in linqdb.Major on stu.MajorId equals ma.MajorId
        //                     into A
        //                     from a in A.DefaultIfEmpty()
        //                     select new{stu,a})
        //                   on sign.StudentId equals b.stu.StudentId into C
        //                   from c in C.DefaultIfEmpty()
        //            select new
        //            {
        //                StudentId = c.stu.StudentId == null ? "" : c.stu.StudentId.ToString(),
        //                MajorId = c.stu.MajorId == null ? "" : c.stu.MajorId.ToString(),
        //                MajorName = c.a.MajorName,
        //                StudentName = c.stu.StudentName,
        //                StudentSex = c.stu.StudentSex,
        //                StudentPhone = c.stu.StudentPhone,
        //                StudentMail = c.stu.StudentMail,
        //                SignTitle = sign.SignTitle,
        //                SignTime = sign.SignTime == null ? "" : sign.SignTime.ToString()
        //            };

        //如果感觉上述写法复杂，可读性不高，也可以分步骤实现
        //步骤一：先将学生表和专业表左联
        var query1 = from stu in linqdb.Student
                    join ma in linqdb.Major on stu.MajorId equals ma.MajorId
                    into A
                    from a in A.DefaultIfEmpty()
                    select new
                    {
                        StudentId = stu.StudentId,
                        MajorId = stu.MajorId,
                        MajorName = a.MajorName,
                        StudentName = stu.StudentName,
                        StudentSex = stu.StudentSex,
                        StudentPhone = stu.StudentPhone,
                        StudentMail = stu.StudentMail
                    };
        //步骤二：将签到表和上述结果进行左联
        var query2 = from sign in linqdb.SignInOut
                join q in query1 on sign.StudentId equals q.StudentId
                into A
                from a in A.DefaultIfEmpty()
                select new
                {
                    StudentId = a.StudentId == null ? "" : a.StudentId.ToString(),
                    MajorId = a.MajorId== null ? "" : a.MajorId.ToString(),
                    MajorName = a.MajorName,
                    StudentName = a.StudentName,
                    StudentSex = a.StudentSex,
                    StudentPhone = a.StudentPhone,
                    StudentMail = a.StudentMail,
                    SignTitle = sign.SignTitle,
                    SignTime = sign.SignTime == null ? "" : sign.SignTime.ToString()
                };

        this.gvStudent.DataSource = query2.ToList();
        this.gvStudent.DataBind();
    }
}
```

