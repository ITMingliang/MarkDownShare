# 原生JS实现Ajax

**JS中使用Ajax技术的作用：**

JS属于前端编程，例如我们需要判断界面上某一个文本框是否为空，此时的判断与后端无关，我们直接在前端使用

JS很好去判断；

但是如果一个注册表单中，需要判断用户名文本框中输入的用户名是否被占用，则必须访问后端才能够判断出结

果，那么Ajax就提供给我们了JS访问后端的功能。

现实开发中还存在很多前端代码去调用后端接口的场景，所以我们需要去了解Ajax技术。

由于可能一些小伙伴还没有学习后端（例如php,asp.net,java web）等的编程，所以在本教程中使用在线Mock平

台： [www.**fastmock**.site](http://www.baidu.com/link?url=wWwkRiVRs33HaAfEDSIAzQ1VCeeTJ_Zdus0gTH0V9gj1yDtmm4CjrqvlSqazWfV5) 来进行模拟后端数据。

## 一、GET请求Hello,World

后端返回数据格式：

```
{"result":"hello"}
```

前端代码：

```
<h1 id="result" style="margin: 30px; text-align: center;">			
</h1>
<script type="text/javascript">
	//get请求
	var ajax = new XMLHttpRequest(); //创建XMLHttpRequest对象
	//ajax.open("get","url?act=add"); 
	ajax.open("get","url"); //设置ajax请求参数
	ajax.send();//发送get请求
	//注册事件 onreadystatechange 状态改变就会调用
	ajax.onreadystatechange=function()
	{
		if(ajax.readyState==4 && ajax.status==200)
		{
			document.getElementById("result").innerHTML = ajax.responseText;
		}
	}			
</script>
```

## 二、Post请求Hello,World

后端返回数据格式：

```
{"result":"hello"}
```

前端代码：

```
<h1 id="result" style="margin: 30px; text-align: center;">			
</h1>
<script type="text/javascript">
	//post请求
	var ajax = new XMLHttpRequest();
	//设置请求的类型及url
	//post请求一定要添加请求头才行不然会报错			
	ajax.open('post','url');
	ajax.setRequestHeader("Content-type","application/x-www-form-urlencoded");
	//发送请求
	//ajax.send('name=fox&age=18');
	ajax.send();
	ajax.onreadystatechange = function () {
		// 这步为判断服务器是否正确响应
	  if (ajax.readyState == 4 && ajax.status == 200) {
		document.getElementById("result").innerHTML = ajax.responseText;
	  } 
	};			
</script>
```

## 三、GET请求判断用户名是否被占用

后端返回数据格式：

```
{
  "result":function({_req, Mock})
  {
	let body = _req.query;
	if(body.acc=="zhoujielun")
	  return "1";
	else
	  return "0";
  }
}
```

前端代码：

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="utf-8">
		<title>Ajax检查用户名是否存在-get方式</title>
		<script type="text/javascript">
			function CheckAcc()
			{
				//get请求
				var ajax = new XMLHttpRequest(); //创建异步对象
				//ajax.open("get","json.html?act=add"); 
				var acc = document.getElementById("txtAccount").value;
				ajax.open("get","url?acc="+acc); //设置ajax请求参数
				ajax.send();//发送get请求
				//注册事件 onreadystatechange 状态改变就会调用
				ajax.onreadystatechange=function()
				{
					if(ajax.readyState==4 && ajax.status==200)
					{
						var json = JSON.parse(ajax.responseText);
						if(json.result == "1")
							alert('恭喜您，用户名可以使用!');
						else
							alert('很遗憾，该用户名已经被占用!');
					}
				}
			}
		</script>
	</head>
	<body>
		<form action="#">
		<table width="1000" align="center">
			<caption>用户注册</caption>
			<tr>
				<td width="300" align="right" height="30">用户名:</td>
				<td width="700">
					<input type="text" id="txtAccount">
					<input type="button" value="检查用户名是否存在" onclick="CheckAcc();">
				</td>
			</tr>
			<tr>
				<td width="300" align="right" height="30">昵称:</td>
				<td width="700">
					<input type="text" id="txtNickName">
				</td>
			</tr>
			<tr>
				<td width="300" align="right" height="30">密码:</td>
				<td width="700">
					<input type="password" id="txtPwd">
				</td>
			</tr>
			<tr>
				<td width="300" align="right" height="30">密码确认:</td>
				<td width="700">
					<input type="password" id="txtPwdOk">
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

## 四、Post方式判断用户名是否被占用

后端返回数据格式：

```
{
  "result":function({_req, Mock})
  {
    let body = _req.body;
    if(body.acc=="zhoujielun")
      return "0";
    else
      return "1";
  }
}
```

前端代码：

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="utf-8">
		<title>Ajax检查用户名是否存在-post方式</title>
		<script type="text/javascript">
			function CheckAcc()
			{
				//post请求
				var ajax = new XMLHttpRequest();
				//设置请求的类型及url
				//post请求一定要添加请求头才行不然会报错
				ajax.open('post','https://www.fastmock.site/mock/06492f38e791d869ea222ba9698d7a5e/API/CheckAcc');
				ajax.setRequestHeader("Content-type","application/x-www-form-urlencoded");
				//发送请求
				var acc = document.getElementById("txtAccount").value;
				ajax.send('acc='+acc);
				ajax.onreadystatechange = function () {
					if(ajax.readyState==4 && ajax.status==200)
					{
						var json = JSON.parse(ajax.responseText);
						if(json.result == "1")
							alert('恭喜您，用户名可以使用!');
						else
							alert('很遗憾，该用户名已经被占用!');
					} 
				};
			}
		</script>
	</head>
	<body>
		<form action="#">
		<table width="1000" align="center">
			<caption>用户注册</caption>
			<tr>
				<td width="300" align="right" height="30">用户名:</td>
				<td width="700">
					<input type="text" id="txtAccount">
					<input type="button" value="检查用户名是否存在" onclick="CheckAcc();">
				</td>
			</tr>
			<tr>
				<td width="300" align="right" height="30">昵称:</td>
				<td width="700">
					<input type="text" id="txtNickName">
				</td>
			</tr>
			<tr>
				<td width="300" align="right" height="30">密码:</td>
				<td width="700">
					<input type="password" id="txtPwd">
				</td>
			</tr>
			<tr>
				<td width="300" align="right" height="30">密码确认:</td>
				<td width="700">
					<input type="password" id="txtPwdOk">
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

