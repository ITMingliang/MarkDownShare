# Jquery-Ajax

 AJAX 是一种与服务器交换数据的技术，可以在不重新载入整个页面的情况下去访问服务器后端的数据。

## 一、Json格式介绍

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="utf-8">
		<title>Json格式介绍</title>
		<script type="text/javascript">
			//json对象
			// var json = {"stuno":"001","stuname":"张三","stusex":"男"};
			// alert(json.stuname);
			
			//json数组
			// var json = [{"stuno":"001","stuname":"张三","stusex":"男"},
			// 	{"stuno":"002","stuname":"李四","stusex":"男"},
			// 	{"stuno":"003","stuname":"王五","stusex":"男"}];
			// alert(json[1].stuname);
			
			//json中既包含对象也包含数组
			// var json = {teacher:{"name":"孔子","sex":"男"},
			// 	student:[{"stuno":"001","stuname":"张三","stusex":"男"},
			// 	{"stuno":"002","stuname":"李四","stusex":"男"},
			// 	{"stuno":"003","stuname":"王五","stusex":"男"}]};
			// alert(json.teacher.name); //获取老师姓名
			// alert(json.student[1].stuname); //获取第二个学生姓名
			
			//json对象中包含数组
			// var json = 
			// 	[{"code":"XZB","name":"行政部",
			// 		"Emp":[{"no":"001","name":"刘德华","sex":"男"},
			// 		{"no":"002","name":"张学友","sex":"男"},
			// 		{"no":"003","name":"蔡依林","sex":"女"}]},
			// 	{"code":"KFB","name":"开发部",
			// 		"Emp":[{"no":"004","name":"周杰伦","sex":"男"},
			// 		{"no":"005","name":"王珞丹","sex":"女"},
			// 		{"no":"006","name":"蔡徐坤","sex":"男"},
			// 	]}]
			// alert(json[1].name); //公司的第二个部门名称
			// alert(json[1].Emp[1].name);//公司第二个部门第二个员工姓名
			
		</script>
	</head>
	<body>
	</body>
</html>
```

 ## 二、Ajax获取Hello,world

```
<!-- 
模拟后端数据：www.fastmock.site
返回数据为：{"result":"hello"}
 -->
<!DOCTYPE html>
<html>
	<head>
		<meta charset="utf-8">
		<title>Ajax基本使用</title>
		<script src="js/jquery.js"></script>
		<script>
			$(function(){
				$("#myButton").click(function(){
				   //ajax获取文本
				   // $.ajax({
					  //  url: "https://www.fastmock.site/mock/06492f38e791d869ea222ba9698d7a5e/API/Hello",
					  //  type: "post", 
					  //  //async: true,  //默认为true，异步请求 
					  //  //data: "act=HelloWorld",
					  //  dataType: "text",
					  //  success: function (msg) {
						 //   $("#result").text(msg);
					  //  },
					  //  error: function (msg) {
						 //   alert('调用失败：' + msg);
					  //  }
				   // });
				   
				   //ajax获取json
				   // $.ajax({
					  //  url: "https://www.fastmock.site/mock/06492f38e791d869ea222ba9698d7a5e/API/Hello",
					  //  type: "post", 
					  //  //async: true,  //默认为true，异步请求 
					  //  //data: "act=HelloWorld",
					  //  dataType: "json",
					  //  success: function (msg) {
						 //   $("#result").text(msg.result);
					  //  },
					  //  error: function (msg) {
						 //   alert('调用失败：' + msg);
					  //  }
				   // });
				   
				   //post-get请求个参数
				   //url:发送请求地址。
				   //data:待发送 Key/value 参数。
				   //callback:发送成功时回调函数。
				   //type:返回内容格式，xml, html, script, json, text, _default。
					
					// $.get("https://www.fastmock.site/mock/06492f38e791d869ea222ba9698d7a5e/API/Hello",
					//   function (msg) {
					// 	  $("#result").text(msg.result);
					//   },
					//   "json"
					// );
				   
					$.post("https://www.fastmock.site/mock/06492f38e791d869ea222ba9698d7a5e/API/Hello",
						function (msg) {
							$("#result").text(msg.result);
						},
						"json"
					);				   
									  
				});
			});
		</script>
	</head>
	<body>
		<input id="myButton" type="button" value="模拟调用后端数据">
		<br /><br />
		<h2 id="result"></h2>
	</body>
</html>
```

## 三、Ajax检查用户名是否存在

```
<!--
模拟后端数据：www.fastmock.site
返回数据为：
{
  "result":function({_req, Mock})
  {
	let body = _req.query;
	if(body.acc=="zhoujielun")
	  return "0";
	else
	  return "1";
  }
}
-->
<!DOCTYPE html>
<html>
	<head>
		<meta charset="utf-8">
		<title>Ajax检查用户名是否存在</title>
		<script src="js/jquery.js"></script>
		<script>
			$(function(){
				$("#btCheck").click(function(){
				   //ajax获取json
				   var acc=$("#txtAccount").val();
				   //以下两行序列化表单值提供给序列化方式参数参数data使用。
				   var data = $('#myForm').serialize(); //序列化表单值
				   data = decodeURIComponent(data, true); //如果有中文,需要此操作解码
				   $.ajax({
					   url: "https://www.fastmock.site/mock/06492f38e791d869ea222ba9698d7a5e/API/ck2",
					   type: "post", 
					   //async: true,  //默认为true，异步请求
					   //多个参数用&连接，例如acc=abc&pwd=123
					   //data: "acc="+acc, 
					   //多个参数用逗号连接,例如{"acc":"abc","pwd":"123"}
					   //data:{"acc":acc},
					   //序列化方式传递数据,要求表单元素name和后端参数同名
					   data:data,
					   dataType: "json",
					   success: function (json) {
						if(json.result == "1")
							alert('恭喜您，用户名可以使用!');
						else
							alert('很遗憾，该用户名已经被占用!');
					   },
					   error: function (msg) {
						   alert('调用失败：' + msg);
					   }
				   });
				
				  //  var acc=$("#txtAccount").val();
				  //  $.get("https://www.fastmock.site/mock/06492f38e791d869ea222ba9698d7a5e/API/ck1",
					 // {"acc":acc},
				  //    function (json) {
						// if(json.result == "1")
						// 	alert('恭喜您，用户名可以使用!');
						// else
						// 	alert('很遗憾，该用户名已经被占用!');
				  //    },
				  //    "json"
				  //  );
				  
				 //   var acc=$("#txtAccount").val();			   
				 //   $.post("https://www.fastmock.site/mock/06492f38e791d869ea222ba9698d7a5e/API/ck2",
				 //   	{"acc":acc},
					// function (json) {
					// 	if(json.result == "1")
					// 		alert('恭喜您，用户名可以使用!');
					// 	else
					// 		alert('很遗憾，该用户名已经被占用!');
				 //   	},
				 //   	"json"
				 //   );
					
				});
			});
		</script>
	</head>
	<body>
		<form action="#" id="myForm">
		<table width="1000" align="center">
			<caption>用户注册</caption>
			<tr>
				<td width="300" align="right" height="30">用户名:</td>
				<td width="700">
					<input type="text" id="txtAccount" name="acc">
					<input id="btCheck" type="button" value="检查用户名是否存在">
				</td>
			</tr>
			<tr>
				<td width="300" align="right" height="30">密码:</td>
				<td width="700">
					<input type="password" id="txtPwd">
				</td>
			</tr>
			<tr>
				<td width="300" align="right" height="30">&nbsp;</td>
				<td width="700">
					<input type="submit" value="注册" />
					<input type="reset" value="取消" />
				</td>
			</tr>
		</table>
		
		</form>			
	</body>
</html>
```

## 四、Ajax加载学生信息

```
<!--
模拟后端数据：www.fastmock.site
返回数据为：
{
  "list|20": [{
    "name": "@name",
    "age": "@integer(10,22)",
    "email":"@email"
  }],
} 
-->
<!DOCTYPE html>
<html>
	<head>
		<meta charset="utf-8">
		<title>Ajax加载学生信息</title>
		<script src="js/jquery.js"></script>
		<script>
			$(function(){
				$("#myButton").click(function(){
				   $.ajax({
					   url: "https://www.fastmock.site/mock/06492f38e791d869ea222ba9698d7a5e/API/stu",
					   type: "post", 
					   //async: true,  //默认为true，异步请求
					   dataType: "json",
					   success: function (json) {
						   for(var i = 0;i<json.list.length;i++)
						   {
							   var stu = json.list[i];
							   var tr="<tr><td>"+stu.name+"</td><td>"+stu.age+"</td><td>"+stu.email+"</td></tr>";
							   $("#myTable").append(tr);
						   }
					   },
					   error: function (msg) {
						   alert('调用失败：' + msg);
					   }
				   });
				})
			})
		</script>
	</head>
	<body>
		<input id="myButton" type="button" value="加载学生信息">
		<br /><br />
		<table id="myTable" width="1000" border="1">
			<tr>
				<th>姓名</th>
				<th>年龄</th>
				<th>邮箱</th>
			</tr>
		</table>
	</body>
</html>
```

