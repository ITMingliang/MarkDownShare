# JQuery事件

## 一、页面载入事件

页面载入事件的四种写法：

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="utf-8" />
		<title>页面载入事件:ready()</title>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			//写法一
//			$(document).ready(function(){
//				$("#mytitle").html("页面加载完成");
//			})
			//写法二
			$(function(){
				$("#mytitle").html("页面加载完成");
			})
			//写法三
//			jQuery(document).ready(function(){
//				$("#mytitle").html("页面加载完成");
//			})
			//写法四
//			jQuery(function(){
//				$("#mytitle").html("页面加载完成");
//			})
		</script>
	</head>
	<body>
		<h1 id="mytitle"></h1>
	</body>
</html>
```

## 二、鼠标常用事件

click：当鼠标点击元素的时候，会发生click事件。

mouseover：当鼠标指针位于元素上方时，会发生 mouseover 事件。

mouseout：当鼠标指针从元素上移开时，发生 mouseout 事件。

hover：当鼠标移动到一个匹配的元素上面时，会触发指定的第一个函数。当鼠标移出这个元素时，会触发指定的

第二个函数。

**mouseover和mouseout事件结合实现高亮导航菜单：**

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>鼠标事件</title>
		<style type="text/css">
			*{margin: 0px; padding: 0px;}
			#head{ width: 100%; height: 70px; background-color:darkgray;}
			#head ul{ list-style-type: none;}
			#head ul li{ float: left; text-align: center; height: 70px; line-height: 70px;}
			#head ul li a{ padding: 0px 20px; text-decoration: none; 
			font-size: 16px; color: white; height: 70px; line-height: 70px;
			display: block;}
			.select{ background-color: gray; font-weight: bold;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				//鼠标移动上去的时候
				$("#head ul li").mouseover(function(){
					$(this).addClass("select");
				})
				//鼠标离开的时候
				$("#head ul li").mouseout(function(){
					$(this).removeClass("select");
				})
			})
		</script>
	</head>
	<body>
		<div id="head">
		  <ul>
		    <li><a href="#">首页</a></li>
		    <li><a href="#">美食</a></li>
		    <li><a href="#">旅游</a></li>
		    <li><a href="#">酒店</a></li>
		    <li><a href="#">电影</a></li>
		    <li><a href="#">KTV</a></li>
		    <li><a href="#">时尚</a></li>
		    <li><a href="#">生活服务</a></li>
		  </ul>
		</div>	
	</body>
</html>
```

**hover事件实现高亮导航菜单：**

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>hover事件</title>
		<style type="text/css">
			*{margin: 0px; padding: 0px;}
			#head{ width: 100%; height: 70px; background-color:darkgray;}
			#head ul{ list-style-type: none;}
			#head ul li{ float: left; text-align: center; height: 70px; line-height: 70px;}
			#head ul li a{ padding: 0px 20px; text-decoration: none; 
			font-size: 16px; color: white; height: 70px; line-height: 70px;
			display: block;}
			.select{ background-color: gray; font-weight: bold;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				//调用jQuery中的hover()方法可以使元素在鼠标移入与鼠标移出的事件中进行切换
				$("#head ul li").hover
				(
					function()  //鼠标移入
					{
						$(this).addClass("select");
					},
					function()  //鼠标移出
					{
						$(this).removeClass("select");
					}				
				)
			})
		</script>
	</head>
	<body>
		<div id="head">
		  <ul>
		    <li><a href="#">首页</a></li>
		    <li><a href="#">美食</a></li>
		    <li><a href="#">旅游</a></li>
		    <li><a href="#">酒店</a></li>
		    <li><a href="#">电影</a></li>
		    <li><a href="#">KTV</a></li>
		    <li><a href="#">时尚</a></li>
		    <li><a href="#">生活服务</a></li>
		  </ul>
		</div>	
	</body>
</html>
```

## 三、绑定事件

**绑定事件基本写法：**

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>绑定事件介绍</title>	
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				$("#bt1").click(function(){
					alert("我被点击了!");
				})
				
				//Jquery3之后不推荐使用
				// $("#bt1").bind("click",function(){
				// 	alert("我被点击了!");
				// })
				
				//Jquery低版本使用的是live,高版本中使用on(on的效率明显提高)			
				// $("#bt1").on("click",function(){
				// 	alert("我被点击了!");
				// })
				
				<!--one()方法的功能是为所选择的元素绑定一个仅触发一次的处理函数-->
				// $("#bt1").one("click",function(){
				// 	alert("我被点击了,只能响应一次!");
				// })		
			})
		</script>
	</head>
	<body>
		<input id="bt1" type="button" value="点击我"  />
	</body>
</html>
```

**使用on绑定事件：**解决无法响应Jquery新添加元素的事件设置的问题。

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>使用on绑定事件详解</title>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				//第一个按钮可以响应，第二个按钮不能响应
				// $("input").click(function(){
				// 	alert("我被点击了!");
				// })
				//第一个按钮可以响应，第二个按钮不能响应
				// $("input").on("click",function(){
				// 	alert("我被点击了!");
				// })
				//第一个按钮可以响应，第二个按钮也可以响应
				//此方式支持Jquery新添加元素的事件设置
				$("body").on("click","input",function(){
					alert("我被点击了!");
				})					
				$("body").append("<input type=\"button\" value=\"点击我\"  />");
			})
		</script>
	</head>
	<body>
		<input type="button" value="点击我"  />		
	</body>
</html>
```

**深入理解各绑定事件方式的区别：**

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>深入理解各绑定事件方式的区别</title>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				//不能响应Jquery新增元素的事件响应
	            $("#divTest1 :button").click(function () {
	                $(this).after(" <input type='button' value='新按钮' />");
	            });	
	            //bind和直接click效果一样
	            $("#divTest2 :button").bind("click", function () {
	                $(this).after(" <input type='button' value='新按钮' />");
	            });
	            //事件仅触发一次
	            $("#divTest3 :button").one("click", function () {
	                $(this).after(" <input type='button' value='新按钮' />");
	            });
				//不能响应Jquery新增元素的事件响应
				$("#divTest4 :button").on("click", function () {
					$(this).after(" <input type='button' value='新按钮' />");
				});
				//可以响应Jquery新增元素的事件响应
	            $("#divTest5").on("click","input:button", function () {
	                $(this).after(" <input type='button' value='新按钮' />");
	            });
				//jquery1.9以下版本支持,新版本换成了on
				//$("#divTest6 :button").live("click", function () {
				//$(this).after(" <input type='button' value='新按钮' />");
				//});		
			})
		</script>	
	</head>
	<body>
	    <div id="divTest1">
	        <input type="button" value="点我这里click" />
	    </div>
	    <br />
	    <div id="divTest2">
	        <input type="button" value="点我这里bind" />
	    </div>
	    <br />
	    <div id="divTest3">
	        <input type="button" value="点我这里one" />
	    </div>
		<br />
	    <div id="divTest4">
	        <input type="button" value="点我这里on(1)" />
	    </div>
	    <br />
	    <div id="divTest5">
	        <input type="button" value="点我这里on(2)" />
	    </div>
	    <br />		
	    <div id="divTest6">
	        <input type="button" value="点我这里live" />
	    </div>
	    <br />

	</body>
</html>
```

**使用trigger实现在匹配的元素上主动触发事件：**

```
<!--jQuery对象.trigger(type);
其中参数type为触发事件的类型。trigger()方法的功能是在所选择的元素上触发指定类型的事件。-->
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>trigger()</title>
		<style type="text/css">
			#foot{ width: 900px; margin: 0px auto; }
			#myTable{ width: 900px; margin: 0px auto; 
			 border-collapse: collapse;}
			#myTable th,#myTable td{border:solid 1px green;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				$("#selAll").click(function(){
					//建议值为true或者false的属性(checked,selected,enabled)等使用prop
					//建议HTML标签中已经写上去的属性用attr,没有写上去的使用prop
					var $isChecked = $(this).prop("checked");
					$("input[name=stuItem]").prop("checked",$isChecked);
				})
				$("#myASelAll").click(function(){
					$("#selAll").trigger("click");
				})
			})
		</script>
		
	</head>
	<body>
		<table cellspacing="1" id="myTable">
			<tr>
				<th width="20"><input type="checkbox" id="selAll" /></th>
				<th width="200">姓名</th>
				<th width="200">性别</th>
				<th width="200">专业</th>
				<th width="200">爱好</th>
			</tr>
			<tr>
				<td><input type="checkbox" id="" name="stuItem" /></td>
				<td>刘备</td>
				<td>男</td>
				<td>软件开发</td>
				<td>抽烟</td>
			</tr>
			<tr>
				<td><input type="checkbox" name="stuItem" /></td>
				<td>关羽</td>
				<td>男</td>
				<td>国际贸易</td>
				<td>喝酒</td>
			</tr>
			<tr>
				<td><input type="checkbox" name="stuItem" /></td>
				<td>张飞</td>
				<td>男</td>
				<td>园林设计</td>
				<td>烫头发</td>
			</tr>
			<tr>
				<td><input type="checkbox" name="stuItem" /></td>
				<td>赵云</td>
				<td>男</td>
				<td>平面设计</td>
				<td>抽烟</td>
			</tr>
			<tr>
				<td><input type="checkbox" name="stuItem" /></td>
				<td>黄忠</td>
				<td>男</td>
				<td>影视制作</td>
				<td>玩游戏</td>
			</tr>
			<tr>
				<td><input type="checkbox" name="stuItem" /></td>
				<td>小乔</td>
				<td>女</td>
				<td>高级护理</td>
				<td>唱歌</td>
			</tr>
		</table>
		<div id="foot"><a id="myASelAll" href="javascript:void(0);">全选</a></div>
	</body>
</html>
```

## 四、事件的冒泡现象

以下代码会弹出三个对话框，分别为1，2，3 ；

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>事件机制-冒泡现象</title>
		<style type="text/css">
			html,body{ height:100%;}
			#content{ height: 40px; border: solid 2px red;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				var $count = 0;
				$("body,#content,#myButton").click(function(){
					$count++;
					alert($count + ",点击的是:" + $(this).attr("id"));
				})
			})
		</script>
	</head>
	<body>
		<div id="content">
			<input id="myButton" type="button" value="获取点击次数" />
		</div>
	</body>
</html>
```

解决冒泡现象：在事件函数代码最后 return false;

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>事件机制-冒泡现象</title>
		<style type="text/css">
			html,body{ height:100%;}
			#content{ height: 40px; border: solid 2px red;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				var $count = 0;
				$("body,#content,#myButton").click(function(){
					$count++;
					alert($count + ",点击的是:" + $(this).attr("id"));
					return false;
				})
			})
		</script>
	</head>
	<body>
		<div id="content">
			<input id="myButton" type="button" value="获取点击次数" />
		</div>
	</body>
</html>
```

## 五、Jquery表单验证

**邮箱验证：**(focus和blur事件)

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>验证邮箱</title>
		<style type="text/css">
			.errInfo{color: red; font-size: 12px;}
			.errInfo img{ vertical-align:middle;}
			#myDiv{ width: 500px; height: 30px; line-height: 30px; }
			#myDiv input{ color:gray;}
			.divFocus{ background-color: antiquewhite;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				$("#myTxt").focus(function(){
					$(this).parent("div").addClass("divFocus");
				})
				$("#myTxt").blur(function(){
					$(this).parent("div").removeClass("divFocus");
					var $emailReg=/^\w+@\w+(\.[a-zA-Z]{2,3}){1,2}$/;
					if(!$emailReg.test($(this).val()))
					{
						$("#mySpan").css("color","red");
						$("#mySpan").html("<img src='img/li_err.gif'> 邮箱地址输入错误!");
					}
					else
					{
						$("#mySpan").css("color","green");
						$("#mySpan").html("<img src='img/li_ok.gif'> 正确!");						
					}
				})
			})
		</script>		
	</head>
	<body>
		<div id="myDiv">
			邮箱:<input type="text" id="myTxt" placeholder="例如:example@qq.com" />
			<span id="mySpan" class="errInfo">邮箱地址必填</span>
		</div>
	</body>
</html>
```

**用户注册表单验证：**

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>表单验证</title>
		<style type="text/css">
			.errInfo{color: red; font-size: 12px;}
			.errInfo img{ vertical-align:middle;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
		$(function(){
			var $result = true;  //假设所有输入都符合条件
			//检查用户名
			$("#txtAccount").blur(function(){
				if($(this).val().length == 0)
				{
					$(this).next().html("<img src='img/li_err.gif'> 用户名不能为空!");
					$result = false;
				}
				else if($(this).val().length < 6 || $(this).val().length > 12)
				{
					$(this).next().html("<img src='img/li_err.gif'> 用户名长度必须在6-12位之间!");
					$result = false;					
				}
				else
				{
					$(this).next().html("<img src='img/li_ok.gif'>");
				}
			})
			
			//检查密码
			$("#txtPwd").blur(function(){
				if($(this).val().length == 0)
				{
					$(this).next().html("<img src='img/li_err.gif'> 密码不能为空!");
					$result = false;
				}
				else if($(this).val().length < 6 || $(this).val().length > 12)
				{
					$(this).next().html("<img src='img/li_err.gif'> 密码长度必须在6-12位之间!");
					$result = false;					
				}
				else
				{
					$(this).next().html("<img src='img/li_ok.gif'>");
				}
			})
			
			//检查密码确认
			$("#txtPwdOk").blur(function(){
				if($(this).val().length == 0)
				{
					$(this).next().html("<img src='img/li_err.gif'> 密码确认不能为空!");
					$result = false;
				}
				else if($(this).val() != $("#txtPwd").val())
				{
					$(this).next().html("<img src='img/li_err.gif'> 两次输入密码不一致!");
					$result = false;					
				}
				else
				{
					$(this).next().html("<img src='img/li_ok.gif'>");
				}
			})
			
			//检查邮箱
			$("#txtMail").blur(function(){
				var exp = /^\w+@\w+(\.[a-zA-Z]{2,3}){1,2}$/;
				if($(this).val().length == 0)
				{
					$(this).next().html("<img src='img/li_err.gif'> 邮箱不能不能为空!");
					$result = false;
				}
				else if(exp.test($(this).val()) == false)
				{
					$(this).next().html("<img src='img/li_err.gif'> 邮箱格式不正确!");
					$result = false;					
				}
				else
				{
					$(this).next().html("<img src='img/li_ok.gif'>");
				}
			})
			
			//检查电话
			$("#txtPhone").blur(function(){
				var exp = /^(13|15|18)\d{9}$/;
				if($(this).val().length == 0)
				{
					$(this).next().html("<img src='img/li_err.gif'> 电话不能不能为空!");
					$result = false;
				}
				else if(exp.test($(this).val()) == false)
				{
					$(this).next().html("<img src='img/li_err.gif'> 电话格式不正确!");
					$result = false;					
				}
				else
				{
					$(this).next().html("<img src='img/li_ok.gif'>");
				}
			})
			
			//检查性别
			$("input[name=sex]").blur(function(){
				var objs = $("input[name=sex]:checked");
				if(objs.length == 0)
				{
					$(this).parent().find("span").html("<img src='img/li_err.gif'> 请选择性别!");
					$result = false;
				}
				else
				{
					$(this).parent().find("span").html("<img src='img/li_ok.gif'>");					
				}
			})
			
			//检查专业
			$("#selProfessional").blur(function(){
				if($(this).val().length == 0)
				{
					$(this).next().html("<img src='img/li_err.gif'> 请选择专业!");
					$result = false;
				}
				else
				{
					$(this).next().html("<img src='img/li_ok.gif'>");
				}
			})
			
			//检查爱好
			$("input[name=hobby]").blur(function(){
				var objs = $("input[name=hobby]:checked");
				if(objs.length < 3)
				{
					$(this).parent().find("span").html("<img src='img/li_err.gif'> 爱好至少选择三项!");
					$result = false;
				}
				else
				{
					$(this).parent().find("span").html("<img src='img/li_ok.gif'>");					
				}
			})
			
			//注册表单提交
			$("#myForm").submit(function(){
				$result = true;
				$("#txtAccount").trigger("blur");
				$("#txtPwd").trigger("blur");
				$("#txtPwdOk").trigger("blur");
				$("#txtMail").trigger("blur");
				$("#txtPhone").trigger("blur");
				$("input[name=sex]").trigger("blur");
				$("#selProfessional").trigger("blur");
				$("input[name=hobby]").trigger("blur");
				return $result;
			})			
				
		})
		</script>
	</head>
	<body>
		<form id="myForm" action="Demo08_OK.html">
		<table width="1000" align="center">
			<caption>用户注册</caption>
			<tr>
				<td width="300" align="right" height="30">用户名:</td>
				<td width="700"><input type="text" id="txtAccount" name="txtAccount">
					<span class="errInfo"></span>
				</td>
			</tr>
			<tr>
				<td width="300" align="right" height="30">密码:</td>
				<td width="700"><input type="password" id="txtPwd" name="txtPwd">
					<span class="errInfo"></span>
				</td>
			</tr>
			<tr>
				<td width="300" align="right" height="30">密码确认:</td>
				<td width="700"><input type="password" id="txtPwdOk" name="txtPwdOk">
					<span class="errInfo"></span>
				</td>
			</tr>
			<tr>
				<td width="300" align="right" height="30">邮箱:</td>
				<td width="700"><input type="text" id="txtMail" name="txtMail">
					<span class="errInfo"></span>
				</td>
			</tr>
			<tr>
				<td width="300" align="right" height="30">联系电话:</td>
				<td width="700"><input type="text" id="txtPhone" name="txtPhone">
					<span class="errInfo"></span>
				</td>
			</tr>			
			<tr>
				<td width="300" align="right" height="30">性别:</td>
				<td width="700">
					<input type="radio" name="sex" id="rdBoy" value="男">男
					<input type="radio" name="sex" id="rdGirl" value="女">女	
					<span class="errInfo"></span>
				</td>
			</tr>
			<tr>
				<td width="300" align="right" height="30">专业:</td>
				<td width="700">
					<select id="selProfessional" name="selProfessional">
						<option value="">--请选择--</option>
						<option value="软件开发">软件开发</option>
						<option value="电子商务">电子商务</option>
						<option value="国际贸易">国际贸易</option>
						<option value="工商管理">工商管理</option>
						<option value="高级护理">高级护理</option>
					</select>
					<span class="errInfo"></span>
				</td>
			</tr>			
			<tr>
				<td width="300" align="right" height="30">爱好:</td>
				<td width="700" >
					<input type="checkbox" name="hobby" value="抽烟" />抽烟
					<input type="checkbox" name="hobby" value="喝酒" />喝酒
					<input type="checkbox" name="hobby" value="打游戏" />打游戏
					<input type="checkbox" name="hobby" value="烫头发" />烫头发
					<input type="checkbox" name="hobby" value="足球" />足球
					<input type="checkbox" name="hobby" value="篮球" />篮球
					<span class="errInfo"></span>
				</td>
			</tr>
			<tr>
				<td width="300" align="right" height="30">自我介绍:</td>
				<td width="700">
					<textarea id="mySelf" rows="10" cols="60" name="mySelf"></textarea>
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

## 六、实现样式切换的导航菜单

css.css：

```
*{margin: 0px; padding: 0px;}
#head ul{ list-style-type: none;}
#head{ width: 100%; height: 70px;}

#head #menu{width: 80%; float: left;}
#head #skin{ width: 20%; float: left; text-align: right;}
#head li{ float: left;}
#head #menu ul li{ text-align: center; height: 70px; line-height: 70px;}
#head #menu ul li a{ padding: 0px 20px; text-decoration: none; 
			font-size: 16px; height: 70px; line-height: 70px;
			display: block;}		
#head #skin ul{ margin-top: 25px;  float: right;}			
#skin li{ width: 15px; height: 15px; margin-right: 5px;
background-image: url(../img/theme.gif);}

#skin1{ background-position: 0px 0px;}
#skin2{ background-position: -20px 0px;}
#skin3{ background-position: -40px 0px;}
#skin4{ background-position: -60px 0px;}
#skin5{ background-position: -80px 0px;}
#skin6{ background-position: -100px 0px;}

#skin1.selected{ background-position: 0px -15px;}
#skin2.selected{ background-position: -20px -15px;}
#skin3.selected{ background-position: -40px -15px;}
#skin4.selected{ background-position: -60px -15px;}
#skin5.selected{ background-position: -80px -15px;}
#skin6.selected{ background-position: -100px -15px;}
```

skin1.css：

```
#head{background-color:darkgray;}
#head #menu ul li a{color: white; }
#head #menu li.select{ background-color: gray; font-weight: bold;}
```

skin2.css：

```
#head{background-color:green;}
#head #menu ul li a{color: white; }
#head #menu li.select{ background-color:greenyellow; font-weight: bold;}
```

skin3.css：

```
#head{background-color:goldenrod;}
#head #menu ul li a{color: white; }
#head #menu li.select{ background-color:gold; font-weight: bold;}
```

skin4.css：

```
#head{background-color:darkblue;}
#head #menu ul li a{color: white; }
#head #menu li.select{ background-color:blue; font-weight: bold;}
```

skin5.css：

```
#head{background-color:indianred;}
#head #menu ul li a{color: white; }
#head #menu li.select{ background-color:hotpink; font-weight: bold;}
```

skin6.css：

```
#head{background-color:purple;}
#head #menu ul li a{color: white; }
#head #menu li.select{ background-color:darkorchid; font-weight: bold;}
```

HTML部分：

```

<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>切换样式表实现样式切换</title>
		<link rel="stylesheet" href="css/css.css" />
		<link rel="stylesheet" href="css/skin1.css" id="skinFile" />
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				//鼠标移动上去的时候
				$("#head ul li").mouseover(function(){
					$(this).addClass("select");
				})
				//鼠标离开的时候
				$("#head ul li").mouseout(function(){
					$(this).removeClass("select");
				})
				$("#skin li").click(function(){
					$(this).siblings().removeClass("selected");
					$(this).addClass("selected");
					$("#skinFile").attr("href","css/" + $(this).attr("id") + ".css");
				})
			})
		</script>
	</head>
	<body>
		<div id="head">
			<div id="menu">
			  	<ul>
				    <li><a href="#">首页</a></li>
				    <li><a href="#">美食</a></li>
				    <li><a href="#">旅游</a></li>
				    <li><a href="#">酒店</a></li>
				    <li><a href="#">电影</a></li>
				    <li><a href="#">KTV</a></li>
				    <li><a href="#">时尚</a></li>
				    <li><a href="#">生活服务</a></li>
			  	</ul>				
			</div>
			<div id="skin">
			    <ul>
			        <li id="skin1" title="灰色" class="selected"></li>
			        <li id="skin2" title="紫色"></li>
			        <li id="skin3" title="红色"></li>
			        <li id="skin4" title="天蓝色"></li>
			        <li id="skin5" title="橙色"></li>
			        <li id="skin6" title="淡绿色"></li>
			    </ul>				
			</div>
		</div>	
	</body>
</html>
```

