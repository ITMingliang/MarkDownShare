# WebService

WebService就是一种跨编程语言和跨操作系统平台的远程调用技术。

## 一、资料准备

此文下面的内容需要对Json格式数据进行处理，Json处理类如下：

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

此文下面的内容需要模拟Post请求和Get请求，模拟请求的类如下：

```
public class HttpHelper
{
    #region 模拟Post请求
    public static string HttpPost(string Url, string postDataStr)
    {
        Encoding encoding = System.Text.Encoding.GetEncoding("UTF-8");
        byte[] data = encoding.GetBytes(postDataStr);

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = data.Length;

        //Encoding encoding = System.Text.Encoding.GetEncoding("UTF-8");
        //byte[] data = encoding.GetBytes(postDataStr);
        //request.ContentLength = data.Length;

        //request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);

        CookieContainer cookieContainer = new CookieContainer();
        request.CookieContainer = cookieContainer;
        Stream myRequestStream = request.GetRequestStream();

        myRequestStream.Write(data, 0, data.Length);
        //myStreamWriter.Write(data, 0, data.Length);
        myRequestStream.Close();


        //    //发送请求并获取相应回应数据
        //    response = request.GetResponse() as HttpWebResponse;
        //    //直到request.GetResponse()程序才开始向目标网页发送Post请求
        //    instream = response.GetResponseStream();
        //    sr = new StreamReader(instream, encoding);
        //    //返回结果网页（html）代码
        //    string content = sr.ReadToEnd();
        //    string err = string.Empty;
        //    return content;
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    string err = ex.Message;
        //    //    return string.Empty;
        //    //}


        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        response.Cookies = cookieContainer.GetCookies(response.ResponseUri);
        Stream myResponseStream = response.GetResponseStream();

        StreamReader myStreamReader = new StreamReader(myResponseStream, encoding);
        string retString = myStreamReader.ReadToEnd();
        myStreamReader.Close();
        myResponseStream.Close();

        return retString;
    }
    #endregion

    #region 模拟Get请求
    public static string HttpGet(string Url, string postDataStr)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
        request.Method = "GET";
        request.ContentType = "text/html;charset=UTF-8";
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream myResponseStream = response.GetResponseStream();
        StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
        string retString = myStreamReader.ReadToEnd();
        myStreamReader.Close();
        myResponseStream.Close();
        return retString;
    }
    #endregion

    #region 智能教室的Post版本
    //public string HttpPost(string posturl, string postData)
    //{
    //    Stream outstream = null;
    //    Stream instream = null;
    //    StreamReader sr = null;
    //    HttpWebResponse response = null;
    //    HttpWebRequest request = null;
    //    Encoding encoding = System.Text.Encoding.GetEncoding("UTF-8");
    //    byte[] data = encoding.GetBytes(postData);
    //    // 准备请求...
    //    //try
    //    //{
    //    // 设置参数
    //    request = WebRequest.Create(posturl) as HttpWebRequest;
    //    CookieContainer cookieContainer = new CookieContainer();
    //    request.CookieContainer = cookieContainer;
    //    request.AllowAutoRedirect = true;
    //    request.Method = "POST";
    //    request.ContentType = "application/x-www-form-urlencoded";
    //    request.ContentLength = data.Length;
    //    outstream = request.GetRequestStream();
    //    outstream.Write(data, 0, data.Length);
    //    outstream.Close();
    //    //发送请求并获取相应回应数据
    //    response = request.GetResponse() as HttpWebResponse;
    //    //直到request.GetResponse()程序才开始向目标网页发送Post请求
    //    instream = response.GetResponseStream();
    //    sr = new StreamReader(instream, encoding);
    //    //返回结果网页（html）代码
    //    string content = sr.ReadToEnd();
    //    string err = string.Empty;
    //    return content;
    //    //}
    //    //catch (Exception ex)
    //    //{
    //    //    string err = ex.Message;
    //    //    return string.Empty;
    //    //}
    //}
    #endregion
}
```

## 二、调用外部公开服务

火车时刻表 WEB 服务:

http://www.webxml.com.cn/WebServices/TrainTimeWebService.asmx

### （1）添加Web引用调用

步骤一：在项目中"添加Web引用"。

步骤二：编写测试代码：

```
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>调用火车时刻表 WEB 服务</title>
</head>
<body>
    <h2>
    火车时刻表 WEB 服务:
    http://www.webxml.com.cn/WebServices/TrainTimeWebService.asmx
    </h2>
    <form id="form1" runat="server">
    <div>
        <p>
            出发地：<asp:TextBox ID="txtStart" runat="server"></asp:TextBox>
            到达地：<asp:TextBox ID="txtEnd" runat="server"></asp:TextBox>
            <asp:Button ID="btSelect" runat="server" Text="查询列车" onclick="btSelect_Click" />       
        </p>
        <p>
            <asp:GridView ID="gvTrain" runat="server" AutoGenerateColumns="false" 
                Width="980px">
                <Columns>
                    <asp:BoundField DataField="TrainCode" HeaderText="车次" />
                    <asp:BoundField DataField="FirstStation" HeaderText="起点" />
                    <asp:BoundField DataField="LastStation" HeaderText="终点" />
                    <asp:BoundField DataField="StartStation" HeaderText="出发站" />
                    <asp:BoundField DataField="StartTime" HeaderText="出发时间" />
                    <asp:BoundField DataField="ArriveStation" HeaderText="到达站" />
                    <asp:BoundField DataField="ArriveTime" HeaderText="到达时间" />
                    <asp:BoundField DataField="UseDate" HeaderText="时长" />
                </Columns>
            </asp:GridView>
        </p>
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

    }

    protected void btSelect_Click(object sender, EventArgs e)
    {    
        TrainTimeWebService service = new TrainTimeWebService();
        DataTable dt = new DataTable();
        dt = service.getStationAndTimeByStationName(this.txtStart.Text, this.txtEnd.Text, "").Tables[0];
        this.gvTrain.DataSource = dt;
        this.gvTrain.DataBind();
    }
}
```

### （2）Post调用

```
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h2>
    火车时刻表 WEB 服务:
    http://www.webxml.com.cn/WebServices/TrainTimeWebService.asmx
    </h2>
    <form id="form1" runat="server">
    <div>
        <p>
            出发地：<asp:TextBox ID="txtStart" runat="server"></asp:TextBox>
            到达地：<asp:TextBox ID="txtEnd" runat="server"></asp:TextBox>
            <asp:Button ID="btSelect" runat="server" Text="查询列车" onclick="btSelect_Click" />       
        </p>
        <p>
            <asp:GridView ID="gvTrain" runat="server" AutoGenerateColumns="false" 
                Width="980px">
                <Columns>
                    <asp:BoundField DataField="TrainCode" HeaderText="车次" />
                    <asp:BoundField DataField="FirstStation" HeaderText="起点" />
                    <asp:BoundField DataField="LastStation" HeaderText="终点" />
                    <asp:BoundField DataField="StartStation" HeaderText="出发站" />
                    <asp:BoundField DataField="StartTime" HeaderText="出发时间" />
                    <asp:BoundField DataField="ArriveStation" HeaderText="到达站" />
                    <asp:BoundField DataField="ArriveTime" HeaderText="到达时间" />
                    <asp:BoundField DataField="UseDate" HeaderText="时长" />
                </Columns>
            </asp:GridView>
        </p>
    </div>
    </form>
</body>
</html>
```

```
public partial class Demo02 : System.Web.UI.Page
{
    private string serviceUrl = "http://www.webxml.com.cn/WebServices/TrainTimeWebService.asmx/";
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btSelect_Click(object sender, EventArgs e)
    {
        string url = serviceUrl + "getStationAndTimeByStationName";
        string xmlResult = HttpHelper.HttpPost(url, string.Format("StartStation={0}&ArriveStation={1}&UserID=",this.txtStart.Text,this.txtEnd.Text));

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xmlResult);
        //XmlNamespaceManager namespaceManager = new XmlNamespaceManager(xmlDoc.NameTable);
        //namespaceManager.AddNamespace("ns", "http://tempuri.org/");
        //namespaceManager.AddNamespace("diffgr", "urn:schemas-microsoft-com:xml-diffgram-v1");
        //XmlNodeList nodeList = xmlDoc.SelectNodes("/ns:DataTable/diffgr:diffgram/DocumentElement/ns:stuInfo", namespaceManager);
        XmlNodeList tableNodeList = xmlDoc.DocumentElement.ChildNodes[1].ChildNodes[0].ChildNodes;
        DataTable dt = new DataTable();
        dt.Columns.Add("TrainCode");
        dt.Columns.Add("FirstStation");
        dt.Columns.Add("LastStation");
        dt.Columns.Add("StartStation");
        dt.Columns.Add("StartTime");
        dt.Columns.Add("ArriveStation");
        dt.Columns.Add("ArriveTime");
        dt.Columns.Add("UseDate");
        for (int i = 0; i < tableNodeList.Count; i++)
        {
            DataRow dr = dt.NewRow();
            dr["TrainCode"] = tableNodeList[i].ChildNodes[0].InnerText;
            dr["FirstStation"] = tableNodeList[i].ChildNodes[1].InnerText;
            dr["LastStation"] = tableNodeList[i].ChildNodes[2].InnerText;
            dr["StartStation"] = tableNodeList[i].ChildNodes[3].InnerText;
            dr["StartTime"] = tableNodeList[i].ChildNodes[4].InnerText;
            dr["ArriveStation"] = tableNodeList[i].ChildNodes[5].InnerText;
            dr["ArriveTime"] = tableNodeList[i].ChildNodes[6].InnerText;
            dr["UseDate"] = tableNodeList[i].ChildNodes[8].InnerText;
            dt.Rows.Add(dr);
        }
        this.gvTrain.DataSource = dt;
        this.gvTrain.DataBind();


        //TrainTimeWebService service = new TrainTimeWebService();
        //DataTable dt = new DataTable();
        //dt = service.getStationAndTimeByStationName(this.txtStart.Text, this.txtEnd.Text, "").Tables[0];
        //this.gvTrain.DataSource = dt;
        //this.gvTrain.DataBind();
    }
}
```

## 三、编写WebService

创建一个新的网站，在新网站中创建Web 服务“WebService.asmx”。Web服务创建成功之后会生成两个文件：

（1）WebService.cs：在此文件中编写自己的Web服务方法。

（2）WebService.asmx：web服务文件，可以通过浏览此文件得到服务地址以及服务的描述文件。

**WebService.cs代码如下：**

```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.IO;
using System.Xml;

/// <summary>
///WebService 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService 
{
    private List<StudentEntity> listStu = new List<StudentEntity>();
    public WebService () {
        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
        listStu.Add(new StudentEntity(1, "刘备", "男", "13556878546", "liubei@163.com"));
        listStu.Add(new StudentEntity(2, "关羽", "男", "13698754521", "guanyu@163.com"));
        listStu.Add(new StudentEntity(3, "张飞", "男", "13512365412", "zhangfei@163.com"));
        listStu.Add(new StudentEntity(4, "赵云", "男", "13998986547", "zhaoyun@163.com"));
        listStu.Add(new StudentEntity(5, "马超", "男", "13458745232", "machao@163.com"));
        listStu.Add(new StudentEntity(7, "大乔", "女", "13532234512", "zhangfei@163.com"));
        listStu.Add(new StudentEntity(8, "小乔", "女", "1391434579", "zhaoyun@163.com"));
        listStu.Add(new StudentEntity(9, "孙尚香", "女", "1347895159", "machao@163.com"));
    }

    #region 返回字符串
    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
    #endregion

    #region 返回字符串
    [WebMethod]
    public string Add(int a,int b)
    {
        return (a + b).ToString();
    }
    #endregion

    #region 返回字符串数组(根据性别求学生姓名，性别输入空字符串代表所有学生姓名)
    [WebMethod]
    public string[] GetAllStuName(string sex)
    {
        if (!sex.Equals(""))
            listStu = listStu.Where(p => p.StudentSex.Equals(sex)).ToList();
        string[] arrName = new string[listStu.Count];
        for (int i = 0; i < listStu.Count; i++)
        {
            if (sex.Equals("") || sex.Equals(listStu[i].StudentSex))
                arrName[i] = listStu[i].StudentName;
        }
        return arrName;
        //return new string[3] { sex, sex, sex };
    }
    #endregion

    #region 返回学生类型泛型集合
    [WebMethod]
    public List<StudentEntity> GetAllStuInfo(string sex)
    {
        if (!sex.Equals(""))
            listStu = listStu.Where(p => p.StudentSex.Equals(sex)).ToList();
        return listStu;
    }
    #endregion

    #region 返回存储学生的DataTable
    [WebMethod]
    public DataTable GetAllStuDataTable(string sex)
    {
        DataTable dt = new DataTable("stuInfo");
        dt.Columns.Add("StudentId");
        dt.Columns.Add("StudentName");
        dt.Columns.Add("StudentSex");
        dt.Columns.Add("StudentPhone");
        dt.Columns.Add("StudentMail");
        if (!sex.Equals(""))
            listStu = listStu.Where(p => p.StudentSex.Equals(sex)).ToList();
        foreach (StudentEntity item in listStu)
        {
            dt.Rows.Add(new object[] { item.StudentId, item.StudentName, item.StudentSex, item.StudentPhone, item.StudentMail });
        }
        return dt;
    }
    #endregion

    #region 复杂参数的传递-传递一个实体对象
    [WebMethod]
    public List<StudentEntity> AddOneStu(StudentEntity entity)
    {
        listStu.Add(entity);
        return listStu;
    }
    #endregion

    #region 复杂对象的传递-传递一个泛型集合
    [WebMethod]
     public List<StudentEntity> AddManyStu(List<StudentEntity> list)
     {
         listStu = listStu.Union(list).ToList();
         return listStu;
     }
    #endregion

    #region 接受一个Json字符串，返回Json数组
    [WebMethod]
    public string AddJsonString(string jsonString)
    {
        StudentEntity entity = MyJson.FromJsonTo<StudentEntity>(jsonString);
        listStu.Add(entity);
        return MyJson.ToJsJson(listStu);
    }
    #endregion

    #region 接受一个Json数组，返回Json数组
    [WebMethod]
    public string AddJsonArrString(string jsonString)
    {
        List<StudentEntity> list = MyJson.FromJsonTo<List<StudentEntity>>(jsonString);
        listStu = listStu.Union(list).ToList();
        return MyJson.ToJsJson(listStu);
    }
    #endregion

    public enum FileExtension
    {
        JPG = 255216,
        GIF = 7173,
        BMP = 6677,
        PNG = 13780,
        RAR = 8297,
        jpg = 255216,
        exe = 7790,
        xml = 6063,
        html = 6033,
        aspx = 239187,
        cs = 117115,
        js = 119105,
        txt = 210187,
        sql = 255254
    }

    [WebMethod]
    #region 接受上传图片的接口(Base64转码上传)
    public string[] UploadImage(string image)
    {
        FileStream fsOut = null;
        image = image.Trim().Replace("%", "").Replace(",", "").Replace(" ", "+");
        byte[] bs = Convert.FromBase64String(image);
        #region 判断文件类型
        MemoryStream ms = new MemoryStream(bs);
        System.IO.BinaryReader br = new System.IO.BinaryReader(ms);
        string fileclass = "";
        byte buffer;
        try
        {
            buffer = br.ReadByte();
            fileclass = buffer.ToString();
            buffer = br.ReadByte();
            fileclass += buffer.ToString();
        }
        catch
        {
        }
        br.Close();
        ms.Close();
        FileExtension[] fileEx = { FileExtension.GIF, FileExtension.JPG, FileExtension.PNG ,FileExtension.RAR};
        string fileFix = "";
        foreach (FileExtension fe in fileEx)
        {
            if (Int32.Parse(fileclass) == (int)fe)
                fileFix = fe.ToString();
        }
        if (fileFix.Equals(""))
            return (new string[] { "不支持此文件类型上传" });
        #endregion
        string directory = "~/uploadimg/";
        //判断目录是否存在
        if (!Directory.Exists(HttpContext.Current.Server.MapPath(directory)))
            return (new string[]{ "上传目录有问题"});
        //判断文件是否存在
        //if (File.Exists(HttpContext.Current.Server.MapPath(directory + "\\" + filename)))
        //    File.Delete(HttpContext.Current.Server.MapPath(directory) + "\\" + filename);

        //String path = String.Format("{0:yyyyMMdd_hhmmss}_{1}", DateTime.Now, filename);
        string uploadFileName = DateTime.Now.ToString("yyyyMMddhhmmssfff") + "." + fileFix;
        String newFile = HttpContext.Current.Server.MapPath(directory + uploadFileName);     // 上传文件存放路径
        fsOut = new FileStream(newFile, FileMode.CreateNew, FileAccess.Write);
        try
        {
            fsOut.Write(bs, 0, bs.Length);
        }
        catch (IOException)
        {
            //  TODO Auto-generated catch block 
            return (new string[] { "上传文件失败" });
        }
        fsOut.Close();
        return (new string[] { "上传成功", uploadFileName });
    }
    #endregion
}
```

## 四、添加Web引用方式调用WebService

本示例实现对前面我们自己编写的WebService的调用。

步骤一：在项目中"添加Web引用"。

步骤二：编写测试代码：

**ASPX代码：**

```
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WebService调用测试</title>
</head>
<body>
    <form id="form1" runat="server">
    <p> 
        <h3>引用Web引用的方式调用Webservice</h3>
        <asp:Button ID="Button1" runat="server" Text="调用HelloWorld返回字符串" 
        onclick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="调用Add返回字符串" 
        onclick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" Text="调用GetAllStuName返回字符串数组" 
        onclick="Button3_Click"  />        
    </p>
    <p>
        <asp:Button ID="Button4" runat="server" Text="调用GetAllStuInfo返回泛型集合" 
            onclick="Button4_Click" />
    </p>
    <p>
        <asp:GridView ID="gvStudent1" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="StudentId" HeaderText="学生编号" />
                <asp:BoundField DataField="StudentName" HeaderText="学生姓名" />
                <asp:BoundField DataField="StudentSex" HeaderText="学生性别" />
                <asp:BoundField DataField="StudentPhone" HeaderText="学生电话" />
                <asp:BoundField DataField="StudentMail" HeaderText="学生邮箱" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        <asp:Button ID="Button5" runat="server" Text="调用GetAllStuDataTable返回DataTable" 
            onclick="Button5_Click" />
    </p>
    <p>
        <asp:GridView ID="gvStudent2" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="StudentId" HeaderText="学生编号" />
                <asp:BoundField DataField="StudentName" HeaderText="学生姓名" />
                <asp:BoundField DataField="StudentSex" HeaderText="学生性别" />
                <asp:BoundField DataField="StudentPhone" HeaderText="学生电话" />
                <asp:BoundField DataField="StudentMail" HeaderText="学生邮箱" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        <asp:Button ID="Button6" runat="server" Text="调用AddOneStu进行实体对象的传递" 
            onclick="Button6_Click" />
    </p>
    <p>
        <asp:GridView ID="gvStudent3" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="StudentId" HeaderText="学生编号" />
                <asp:BoundField DataField="StudentName" HeaderText="学生姓名" />
                <asp:BoundField DataField="StudentSex" HeaderText="学生性别" />
                <asp:BoundField DataField="StudentPhone" HeaderText="学生电话" />
                <asp:BoundField DataField="StudentMail" HeaderText="学生邮箱" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        <asp:Button ID="Button7" runat="server" Text="调用AddManyStu进行泛型集合的传递" 
            onclick="Button7_Click"  />
    </p>
    <p>
        <asp:GridView ID="gvStudent4" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="StudentId" HeaderText="学生编号" />
                <asp:BoundField DataField="StudentName" HeaderText="学生姓名" />
                <asp:BoundField DataField="StudentSex" HeaderText="学生性别" />
                <asp:BoundField DataField="StudentPhone" HeaderText="学生电话" />
                <asp:BoundField DataField="StudentMail" HeaderText="学生邮箱" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        <asp:Button ID="Button8" runat="server" Text="调用AddJsonString传递一个Json字符串表示一个实体" 
            onclick="Button8_Click"   />
    </p>
    <p>
        <asp:GridView ID="gvStudent5" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="StudentId" HeaderText="学生编号" />
                <asp:BoundField DataField="StudentName" HeaderText="学生姓名" />
                <asp:BoundField DataField="StudentSex" HeaderText="学生性别" />
                <asp:BoundField DataField="StudentPhone" HeaderText="学生电话" />
                <asp:BoundField DataField="StudentMail" HeaderText="学生邮箱" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        <asp:Button ID="Button9" runat="server" 
            Text="调用AddJsonArrString传递一个Json数组表示一个集合" onclick="Button9_Click"  />
    </p>
    <p>
        <asp:GridView ID="gvStudent6" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="StudentId" HeaderText="学生编号" />
                <asp:BoundField DataField="StudentName" HeaderText="学生姓名" />
                <asp:BoundField DataField="StudentSex" HeaderText="学生性别" />
                <asp:BoundField DataField="StudentPhone" HeaderText="学生电话" />
                <asp:BoundField DataField="StudentMail" HeaderText="学生邮箱" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
    <asp:FileUpload ID="fileImg" runat="server" />
    <asp:Button ID="btUpload" runat="server" Text="调用上传图片服务" 
            onclick="btUpload_Click" /></p>
    <p>
        <span id="spanUplodFile" runat="server" clientidmode="Static"></span>
        <asp:Image ID="imgUpload" runat="server" />
    </p>
    </form>
</body>
</html>
```

**C#代码：**

```
//添加web引用，输入webservice地址
//如需修改地址，到web.config文件中进行修改
public partial class Demo01 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region 调用HelloWorld
    protected void Button1_Click(object sender, EventArgs e)
    {
        WebService service = new WebService();
        string str = service.HelloWorld();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "js", "<script>alert('"+str+"');</script>");
    }
    #endregion

    #region 调用Add
    protected void Button2_Click(object sender, EventArgs e)
    {
        WebService service = new WebService();
        string str = service.Add(2, 4);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "js", "<script>alert('" + str + "');</script>");
    }
    #endregion

    #region 调用GetAllStuName返回字符串数组
    protected void Button3_Click(object sender, EventArgs e)
    {
        WebService service = new WebService();
        string[] arrName = service.GetAllStuName("男");
        Page.ClientScript.RegisterStartupScript(this.GetType(), "js", "<script>alert('" + String.Join(",",arrName) + "');</script>");
    }
    #endregion

    #region 调用GetAllStuInfo返回集合，使用对象数组接受
    protected void Button4_Click(object sender, EventArgs e)
    {
        WebService service = new WebService();
        StudentEntity[] arrStu = service.GetAllStuInfo("男");
        this.gvStudent1.DataSource = arrStu;
        this.gvStudent1.DataBind();
    }
    #endregion

    #region 调用GetAllStuDataTable返回DataTable
    protected void Button5_Click(object sender, EventArgs e)
    {
        WebService service = new WebService();
        DataTable dt = service.GetAllStuDataTable("");
        this.gvStudent2.DataSource = dt;
        this.gvStudent2.DataBind();
    }
    #endregion

    #region 调用AddOneStu进行实体对象的传递
    protected void Button6_Click(object sender, EventArgs e)
    {
        WebService service = new WebService();
        StudentEntity entity = new StudentEntity();
        entity.StudentId = 10;
        entity.StudentName = "吕布";
        entity.StudentSex = "男";
        entity.StudentPhone = "15365878563";
        entity.StudentMail = "lvbu@163.com";
        StudentEntity[] arrStu = service.AddOneStu(entity);
        this.gvStudent3.DataSource = arrStu;
        this.gvStudent3.DataBind();
    }
    #endregion

    #region 调用AddManyStu复杂对象的传递-传递一个泛型集合
    protected void Button7_Click(object sender, EventArgs e)
    {
        List<StudentEntity> listStu = new List<StudentEntity>();
        StudentEntity entity1 = new StudentEntity();
        entity1.StudentId = 10;
        entity1.StudentName = "吕布";
        entity1.StudentSex = "男";
        entity1.StudentPhone = "15365878563";
        entity1.StudentMail = "lvbu@163.com";
        listStu.Add(entity1);
        StudentEntity entity2 = new StudentEntity();
        entity2.StudentId = 11;
        entity2.StudentName = "曹操";
        entity2.StudentSex = "男";
        entity2.StudentPhone = "15334534578";
        entity2.StudentMail = "caocao@163.com";
        listStu.Add(entity2);
        WebService service = new WebService();
        StudentEntity[] arrStu = service.AddManyStu(listStu.ToArray());
        this.gvStudent4.DataSource = arrStu;
        this.gvStudent4.DataBind();
    }
    #endregion

    #region 调用AddJsonString传递一个Json字符串表示一个实体
    protected void Button8_Click(object sender, EventArgs e)
    {
        //StudentEntity已经被序列化，所以这里转Json后的字段名会发生改变
        StudentEntity entity = new StudentEntity();
        entity.StudentId = 10;
        entity.StudentName = "吕布";
        entity.StudentSex = "男";
        entity.StudentPhone = "15365878563";
        entity.StudentMail = "lvbu@163.com";

        //Object Student = new { StudentId = 10,
        //    StudentName = "吕布",
        //    StudentSex = "男",
        //    StudentPhone = "15365878563",
        //    StudentMail = "lvbu@163.com"};

        string jsonStr = MyJson.ToJsJson(entity);

        WebService service = new WebService();
        string jsonResult = service.AddJsonString(jsonStr);
        List<StudentEntity> list = new List<StudentEntity>();
        list = MyJson.FromJsonTo<List<StudentEntity>>(jsonResult);
        this.gvStudent5.DataSource = list;
        this.gvStudent5.DataBind();

    }

    //如果不想使用StudentEntity强数据类型接受返回的数组，可以使用List<object>接受
    //接受之后每一行为一个dictionary键值对，从键值对取值到匿名类集合中
    //protected void Button8_Click(object sender, EventArgs e)
    //{
    //    //StudentEntity已经被序列化，所以这里转Json后的字段名会发生改变
    //    StudentEntity entity = new StudentEntity();
    //    entity.StudentId = 10;
    //    entity.StudentName = "吕布";
    //    entity.StudentSex = "男";
    //    entity.StudentPhone = "15365878563";
    //    entity.StudentMail = "lvbu@163.com";

    //    string jsonStr = MyJson.ToJsJson(entity);

    //    WebService service = new WebService();
    //    string jsonResult = service.AddJsonString(jsonStr);

    //    List<object> listObj = MyJson.FromJsonTo<List<object>>(jsonResult); //Json转object集合
    //    List<object> listResult = new List<object>();
    //    foreach (Dictionary<string, object> item in listObj)
    //    {
    //        listResult.Add(new {
    //            StudentId = item["StudentId"].ToString(),
    //            StudentName = item["StudentName"].ToString(),
    //            StudentSex = item["StudentSex"].ToString(),
    //            StudentPhone = item["StudentPhone"].ToString(),
    //            StudentMail = item["StudentMail"].ToString()
    //        });
    //    }

    //    this.gvStudent5.DataSource = listResult;
    //    this.gvStudent5.DataBind();

    //}
    #endregion

    #region 调用AddJsonArrString传递一个Json数组表示一个集合
    protected void Button9_Click(object sender, EventArgs e)
    {
        List<StudentEntity> listStu = new List<StudentEntity>();
        StudentEntity entity1 = new StudentEntity();
        entity1.StudentId = 10;
        entity1.StudentName = "吕布";
        entity1.StudentSex = "男";
        entity1.StudentPhone = "15365878563";
        entity1.StudentMail = "lvbu@163.com";
        listStu.Add(entity1);
        StudentEntity entity2 = new StudentEntity();
        entity2.StudentId = 11;
        entity2.StudentName = "曹操";
        entity2.StudentSex = "男";
        entity2.StudentPhone = "15334534578";
        entity2.StudentMail = "caocao@163.com";
        listStu.Add(entity2);
        string jsonStr = MyJson.ToJsJson(listStu);

        WebService service = new WebService();
        string jsonResult = service.AddJsonArrString(jsonStr);
        List<StudentEntity> list = new List<StudentEntity>();
        list = MyJson.FromJsonTo<List<StudentEntity>>(jsonResult);
        this.gvStudent6.DataSource = list;
        this.gvStudent6.DataBind();
    }
    #endregion

    #region 调用上传图片的服务
    protected void btUpload_Click(object sender, EventArgs e)
    {
        int fileLen = this.fileImg.PostedFile.ContentLength;
        byte[] imgArray = new byte[fileLen];
        this.fileImg.PostedFile.InputStream.Read(imgArray, 0, fileLen);
        string base64Str = Convert.ToBase64String(imgArray);
        //由于网页传递参数时，会将加号编码成空格，但是在解码时却不会解码空格
        //base64Str = base64Str.Replace("+", "%2B");
        WebService service = new WebService();
        string[] arrResult = service.UploadImage(base64Str);
        this.spanUplodFile.InnerHtml = arrResult[0];
        if (arrResult[0].Equals("上传成功"))
        {
            this.imgUpload.ImageUrl = "http://localhost:2352/MyService/uploadimg/" + arrResult[1];
        }
    }
    #endregion
}
```

## 五、Post调用WebService

本示例实现对前面我们自己编写的WebService的调用。

**ASPX代码：**

```
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <p> 
        <h3>引用Web引用的方式调用Webservice</h3>
        <asp:Button ID="Button1" runat="server" Text="调用HelloWorld返回字符串" 
        onclick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="调用Add返回字符串" 
        onclick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" Text="调用GetAllStuName返回字符串数组" 
        onclick="Button3_Click"  />        
    </p>
    <p>
        <asp:Button ID="Button4" runat="server" Text="调用GetAllStuInfo返回泛型集合" 
            onclick="Button4_Click" />
    </p>
    <p>
        <asp:GridView ID="gvStudent1" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="StudentId" HeaderText="学生编号" />
                <asp:BoundField DataField="StudentName" HeaderText="学生姓名" />
                <asp:BoundField DataField="StudentSex" HeaderText="学生性别" />
                <asp:BoundField DataField="StudentPhone" HeaderText="学生电话" />
                <asp:BoundField DataField="StudentMail" HeaderText="学生邮箱" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        <asp:Button ID="Button5" runat="server" Text="调用GetAllStuDataTable返回DataTable" 
            onclick="Button5_Click" />
    </p>
    <p>
        <asp:GridView ID="gvStudent2" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="StudentId" HeaderText="学生编号" />
                <asp:BoundField DataField="StudentName" HeaderText="学生姓名" />
                <asp:BoundField DataField="StudentSex" HeaderText="学生性别" />
                <asp:BoundField DataField="StudentPhone" HeaderText="学生电话" />
                <asp:BoundField DataField="StudentMail" HeaderText="学生邮箱" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        <asp:Button ID="Button6" runat="server" Text="调用AddOneStu进行实体对象的传递" 
            onclick="Button6_Click" />
    </p>
    <p>
        <asp:GridView ID="gvStudent3" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="StudentId" HeaderText="学生编号" />
                <asp:BoundField DataField="StudentName" HeaderText="学生姓名" />
                <asp:BoundField DataField="StudentSex" HeaderText="学生性别" />
                <asp:BoundField DataField="StudentPhone" HeaderText="学生电话" />
                <asp:BoundField DataField="StudentMail" HeaderText="学生邮箱" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        <asp:Button ID="Button7" runat="server" Text="调用AddManyStu进行泛型集合的传递" 
            onclick="Button7_Click"  />
    </p>
    <p>
        <asp:GridView ID="gvStudent4" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="StudentId" HeaderText="学生编号" />
                <asp:BoundField DataField="StudentName" HeaderText="学生姓名" />
                <asp:BoundField DataField="StudentSex" HeaderText="学生性别" />
                <asp:BoundField DataField="StudentPhone" HeaderText="学生电话" />
                <asp:BoundField DataField="StudentMail" HeaderText="学生邮箱" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        <asp:Button ID="Button8" runat="server" Text="调用AddJsonString传递一个Json字符串表示一个实体" 
            onclick="Button8_Click"   />
    </p>
    <p>
        <asp:GridView ID="gvStudent5" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="StudentId" HeaderText="学生编号" />
                <asp:BoundField DataField="StudentName" HeaderText="学生姓名" />
                <asp:BoundField DataField="StudentSex" HeaderText="学生性别" />
                <asp:BoundField DataField="StudentPhone" HeaderText="学生电话" />
                <asp:BoundField DataField="StudentMail" HeaderText="学生邮箱" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        <asp:Button ID="Button9" runat="server" 
            Text="调用AddJsonArrString传递一个Json数组表示一个集合" onclick="Button9_Click"  />
    </p>
    <p>
        <asp:GridView ID="gvStudent6" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="StudentId" HeaderText="学生编号" />
                <asp:BoundField DataField="StudentName" HeaderText="学生姓名" />
                <asp:BoundField DataField="StudentSex" HeaderText="学生性别" />
                <asp:BoundField DataField="StudentPhone" HeaderText="学生电话" />
                <asp:BoundField DataField="StudentMail" HeaderText="学生邮箱" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
    <asp:FileUpload ID="fileImg" runat="server" />
    <asp:Button ID="btUpload" runat="server" Text="调用上传图片服务" 
            onclick="btUpload_Click" /></p>
    <p>
        <span id="spanUplodFile" runat="server" clientidmode="Static"></span>
        <asp:Image ID="imgUpload" runat="server" />
    </p>
    
    </form>
</body>
</html>
```

**C#代码：**

```
public partial class Demo01 : System.Web.UI.Page
{
    public class StudentEntity
    {
        public int StudentId { get; set; } //编号

        public string StudentName { get; set; } //学生性别

        public string StudentSex { get; set; } //学生性别

        public string StudentPhone { get; set; } //学生电话

        public string StudentMail { get; set; } //学生邮箱
    }

    private string serviceUrl = "http://localhost:2352/MyService/WebService.asmx/";

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region 调用HelloWorld
    protected void Button1_Click(object sender, EventArgs e)
    {
        string url = serviceUrl + "HelloWorld";
        string xmlResult = HttpHelper.HttpPost(url, string.Empty);
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xmlResult);
        string strResult = xmlDoc.GetElementsByTagName("string")[0].InnerText;
        Page.ClientScript.RegisterStartupScript(this.GetType(), "js", "<script>alert('" + strResult + "');</script>");
    }
    #endregion

    #region 调用Add
    protected void Button2_Click(object sender, EventArgs e)
    {
        string url = serviceUrl + "Add";
        string xmlResult = HttpHelper.HttpPost(url, "a=2&b=4");
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xmlResult);
        string strResult = xmlDoc.GetElementsByTagName("string")[0].InnerText;
        Page.ClientScript.RegisterStartupScript(this.GetType(), "js", "<script>alert('" + strResult + "');</script>");
    }
    #endregion

    #region 调用GetAllStuName返回字符串数组
    protected void Button3_Click(object sender, EventArgs e)
    {
        string url = serviceUrl + "GetAllStuName";
        string xmlResult = HttpHelper.HttpPost(url, "sex=男");
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xmlResult);
        XmlNodeList nodeList = xmlDoc.DocumentElement.GetElementsByTagName("string");
        string[] arrName = new string[nodeList.Count];
        for (int i = 0; i < nodeList.Count; i++)
        {
            arrName[i] = nodeList[i].InnerText;
        }
        Page.ClientScript.RegisterStartupScript(this.GetType(), "js", "<script>alert('" + String.Join(",", arrName) + "');</script>");

        //XmlElement root = xmlDoc.DocumentElement; //根
        //string nameSpace = root.NamespaceURI;
        //XmlNamespaceManager namespaceManager = new XmlNamespaceManager(xmlDoc.NameTable);
        //namespaceManager.AddNamespace("ns",nameSpace);
        //string xPath = "/ArrayOfString/ns:string[1]";
        //XmlNode nodeList = root.SelectSingleNode(xPath, namespaceManager);
        //string str = "aaa";
        //XmlNamespaceManager namespaceManager = new XmlNamespaceManager(xmlDoc.NameTable); //namespace 
        //namespaceManager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
        //namespaceManager.AddNamespace("xsd", "http://www.w3.org/2001/XMLSchema");
        //namespaceManager.AddNamespace("ddd", "http://tempuri.org/");
        //XmlNode node = xmlDoc.SelectSingleNode(@"/ddd:ArrayOfString", namespaceManager);
        //bool b = node.HasChildNodes;
        //XmlNodeList nodeList = node.SelectSingleNode;
        //string[] arrName = new string[nodeList.Count];
        //for (int i = 0; i < nodeList.Count; i++)
        //{
        //    arrName[i] = nodeList[i].InnerText;
        //}
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "js", "<script>alert('" + String.Join(",", arrName) + "');</script>");
        
    }
    #endregion

    #region 调用GetAllStuInfo返回集合，使用对象数组接受
    protected void Button4_Click(object sender, EventArgs e)
    {
        string url = serviceUrl + "GetAllStuInfo";
        string xmlResult = HttpHelper.HttpPost(url, "sex=男");
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xmlResult);
        XmlNodeList nodeList = xmlDoc.DocumentElement.GetElementsByTagName("StudentEntity");
        ArrayList stuList = new ArrayList();
        for (int i = 0; i < nodeList.Count; i++)
        {
            var stu = new { StudentId = nodeList[i].ChildNodes[0].InnerText,
                            StudentName = nodeList[i].ChildNodes[1].InnerText,
                            StudentSex = nodeList[i].ChildNodes[2].InnerText,
                            StudentPhone = nodeList[i].ChildNodes[3].InnerText,
                            StudentMail = nodeList[i].ChildNodes[4].InnerText
            };
            stuList.Add(stu);
        }
        this.gvStudent1.DataSource = stuList;
        this.gvStudent1.DataBind();

        //WebService service = new WebService();
        //StudentEntity[] arrStu = service.GetAllStuInfo("男");
        //this.gvStudent1.DataSource = arrStu;
        //this.gvStudent1.DataBind();

    }
    #endregion

    #region 调用GetAllStuDataTable返回DataTable
    protected void Button5_Click(object sender, EventArgs e)
    {
        string url = serviceUrl + "GetAllStuDataTable";
        string xmlResult = HttpHelper.HttpPost(url, "sex=男");
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xmlResult);
        //XmlNamespaceManager namespaceManager = new XmlNamespaceManager(xmlDoc.NameTable);
        //namespaceManager.AddNamespace("ns", "http://tempuri.org/");
        //namespaceManager.AddNamespace("diffgr", "urn:schemas-microsoft-com:xml-diffgram-v1");
        //XmlNodeList nodeList = xmlDoc.SelectNodes("/ns:DataTable/diffgr:diffgram/DocumentElement/ns:stuInfo", namespaceManager);
        XmlNodeList tableNodeList = xmlDoc.DocumentElement.ChildNodes[1].ChildNodes[0].ChildNodes;
        DataTable dt = new DataTable();
        dt.Columns.Add("StudentId");
        dt.Columns.Add("StudentName");
        dt.Columns.Add("StudentSex");
        dt.Columns.Add("StudentPhone");
        dt.Columns.Add("StudentMail");
        for (int i = 0; i < tableNodeList.Count; i++)
        {
            DataRow dr = dt.NewRow();
            dr["StudentId"] = tableNodeList[i].ChildNodes[0].InnerText;
            dr["StudentName"] = tableNodeList[i].ChildNodes[1].InnerText;
            dr["StudentSex"] = tableNodeList[i].ChildNodes[2].InnerText;
            dr["StudentPhone"] = tableNodeList[i].ChildNodes[3].InnerText;
            dr["StudentMail"] = tableNodeList[i].ChildNodes[4].InnerText;
            dt.Rows.Add(dr);
        }
        this.gvStudent2.DataSource = dt;
        this.gvStudent2.DataBind();

        //WebService service = new WebService();
        //DataTable dt = service.GetAllStuDataTable("");
        //this.gvStudent2.DataSource = dt;
        //this.gvStudent2.DataBind();
    }
    #endregion

    #region 调用AddOneStu进行实体对象的传递
    protected void Button6_Click(object sender, EventArgs e)
    {
        //AddOneStu需要传递一个实体
        //此接口无法传递参数，只能修改webservice接受字符串，然后将字符串转换成xml进行处理
    }
    #endregion

    #region 调用AddManyStu复杂对象的传递-传递一个泛型集合
    protected void Button7_Click(object sender, EventArgs e)
    {
        //AddManyStu需要传递一个实体
        //此接口无法传递参数，只能修改webservice接受字符串，然后将字符串转换成xml进行处理
    }
    #endregion

    #region 调用AddJsonString传递一个Json字符串表示一个实体
    protected void Button8_Click(object sender, EventArgs e)
    {
        //将实体转换成Json字符串
        Object Student = new
        {
            StudentId = 10,
            StudentName = "吕布",
            StudentSex = "男",
            StudentPhone = "15365878563",
            StudentMail = "lvbu@163.com"
        };
        string jsonStr = MyJson.ToJsJson(Student);
        string url = serviceUrl + "AddJsonString";
        string xmlResult = HttpHelper.HttpPost(url, "jsonString="+jsonStr);
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xmlResult);
        string jsonResult = xmlDoc.GetElementsByTagName("string")[0].InnerText;
        List<StudentEntity> list = new List<StudentEntity>();
        list = MyJson.FromJsonTo<List<StudentEntity>>(jsonResult);
        this.gvStudent5.DataSource = list;
        this.gvStudent5.DataBind();

        //StudentEntity已经被序列化，所以这里转Json后的字段名会发生改变
        //StudentEntity entity = new StudentEntity();
        //entity.StudentId = 10;
        //entity.StudentName = "吕布";
        //entity.StudentSex = "男";
        //entity.StudentPhone = "15365878563";
        //entity.StudentMail = "lvbu@163.com";

        //Object Student = new { StudentId = 10,
        //    StudentName = "吕布",
        //    StudentSex = "男",
        //    StudentPhone = "15365878563",
        //    StudentMail = "lvbu@163.com"};

        //string jsonStr = MyJson.ToJsJson(entity);

        //WebService service = new WebService();
        //StudentEntity[] arrStu = service.AddJsonString(jsonStr);
        //this.gvStudent5.DataSource = arrStu;
        //this.gvStudent5.DataBind();

    }
    #endregion

    #region 调用AddJsonArrString传递一个Json数组表示一个集合
    protected void Button9_Click(object sender, EventArgs e)
    {
        //将泛型集合转换成Json字符串
        List<StudentEntity> listStu = new List<StudentEntity>();
        StudentEntity entity1 = new StudentEntity();
        entity1.StudentId = 10;
        entity1.StudentName = "吕布";
        entity1.StudentSex = "男";
        entity1.StudentPhone = "15365878563";
        entity1.StudentMail = "lvbu@163.com";
        listStu.Add(entity1);
        StudentEntity entity2 = new StudentEntity();
        entity2.StudentId = 11;
        entity2.StudentName = "曹操";
        entity2.StudentSex = "男";
        entity2.StudentPhone = "15334534578";
        entity2.StudentMail = "caocao@163.com";
        listStu.Add(entity2);
        string jsonStr = MyJson.ToJsJson(listStu);

        string url = serviceUrl + "AddJsonArrString";
        string xmlResult = HttpHelper.HttpPost(url, "jsonString=" + jsonStr);
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xmlResult);
        string jsonResult = xmlDoc.GetElementsByTagName("string")[0].InnerText;
        List<StudentEntity> list = new List<StudentEntity>();
        list = MyJson.FromJsonTo<List<StudentEntity>>(jsonResult);
        this.gvStudent6.DataSource = list;
        this.gvStudent6.DataBind();


        //List<StudentEntity> listStu = new List<StudentEntity>();
        //StudentEntity entity1 = new StudentEntity();
        //entity1.StudentId = 10;
        //entity1.StudentName = "吕布";
        //entity1.StudentSex = "男";
        //entity1.StudentPhone = "15365878563";
        //entity1.StudentMail = "lvbu@163.com";
        //listStu.Add(entity1);
        //StudentEntity entity2 = new StudentEntity();
        //entity2.StudentId = 11;
        //entity2.StudentName = "曹操";
        //entity2.StudentSex = "男";
        //entity2.StudentPhone = "15334534578";
        //entity2.StudentMail = "caocao@163.com";
        //listStu.Add(entity2);
        //string jsonStr = MyJson.ToJsJson(listStu);

        //WebService service = new WebService();
        //StudentEntity[] arrStu = service.AddJsonArrString(jsonStr);
        //this.gvStudent6.DataSource = arrStu;
        //this.gvStudent6.DataBind();
    }
    #endregion

    #region 调用上传图片的服务
    protected void btUpload_Click(object sender, EventArgs e)
    {
        int fileLen = this.fileImg.PostedFile.ContentLength;
        byte[] imgArray = new byte[fileLen];
        this.fileImg.PostedFile.InputStream.Read(imgArray, 0, fileLen);
        string base64Str = Convert.ToBase64String(imgArray);
        //由于网页传递参数时，会将加号编码成空格，但是在解码时却不会解码空格
        base64Str = base64Str.Replace("+", "%2B");

        string url = serviceUrl + "UploadImage";
        string xmlResult = HttpHelper.HttpPost(url, "image=" + base64Str);
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xmlResult);
        XmlNodeList nodeList = xmlDoc.DocumentElement.GetElementsByTagName("string");
        this.spanUplodFile.InnerHtml = nodeList[0].InnerText;
        if (nodeList[0].InnerText.Equals("上传成功"))
        {
            this.imgUpload.ImageUrl = "http://localhost:2352/MyService/uploadimg/" + nodeList[1].InnerText;
        }


        //int fileLen = this.fileImg.PostedFile.ContentLength;
        //byte[] imgArray = new byte[fileLen];
        //this.fileImg.PostedFile.InputStream.Read(imgArray, 0, fileLen);
        //string base64Str = Convert.ToBase64String(imgArray);
        //由于网页传递参数时，会将加号编码成空格，但是在解码时却不会解码空格
        //base64Str = base64Str.Replace("+", "%2B");
        //WebService service = new WebService();
        //string[] arrResult = service.UploadImage(base64Str);
        //this.spanUplodFile.InnerHtml = arrResult[0];
        //if (arrResult[0].Equals("上传成功"))
        //{
        //    this.imgUpload.ImageUrl = "http://localhost:2352/MyService/uploadimg/" + arrResult[1];
        //}
    }
    #endregion
}
```

