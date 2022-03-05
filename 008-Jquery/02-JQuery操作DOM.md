# JQuery操作DOM

## 一、JS获取DOM元素和JQuery获取DOM元素的区别

JavaScript获取的是DOM对象，而Jquery获取的是Jquery对象，他们的语法区别如下：

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="utf-8" />
		<title>JavaScript获取DOM元素和JQuery获取DOM元素的区别</title>
		<style type="text/css">
			#one,#two{width: 200px; height: 200px; line-height: 200px; background-color:deeppink;
			margin: 20px; text-align: center;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			function UpdateDivOne()
			{
				//JavaScript获取的是DOM对象
				var obj = document.getElementById("one");
				obj.style.backgroundColor = "green";
				obj.innerHTML = "JavaScript";
			}
			$(function(){
				$("#bt2").click(function(){
					//Jquery获取的是Jquery对象
					var $obj = $("#two");
					$obj.css("backgroundColor","green");
					$obj.html("JQuery");
				})
			})
		</script>
	</head>
	<body>
		<div>
			<input id="bt1" type="button" value="使用JavaScript修改第一个DIV背景颜色,并修改DIV内部文本内容" onclick="UpdateDivOne();" />
			<input id="bt2" type="button" value="使用JQuery修改第一个DIV背景颜色,并修改DIV内部文本内容" />
		</div>
		<div id="one">
			第一个div
		</div>
		<div id="two">
			第二个div
		</div>
	</body>
</html>
```

## 二、jQuery对象和DOM对象的相互转换

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="utf-8" />
		<title>jQuery对象和DOM对象的相互转换</title>
		<style type="text/css">
			#myDiv{width: 200px; height: 200px; line-height: 200px; background-color:deeppink;
			margin: 20px; text-align: center;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				//DOM对象转Jquery对象
				$("#bt1").click(function(){
					var domObj = document.getElementById("myDiv");
					alert("DOM对象内容为:" + domObj.innerText);
					var $jqueryObj = $(domObj);
					alert("转换之后Jquery对象内容为:" + $jqueryObj.text());
				})
				//jquery对象转DOM对象
				$("#bt2").click(function(){
					var $jqueryObj = $("#myDiv");
					alert("jquery对象内容为:" + $jqueryObj.text());
					//var domObj = $jqueryObj[0];  //jquery对象转DOM对象
					var domObj = $jqueryObj.get(0); //jquery对象转DOM对象
					alert("转换之后DOM对象内容为:" + domObj.innerText);
				})
			})
		</script>
	</head>
	<body>
		<div>
			<input id="bt1" type="button" value="DOM对象转Jquery对象" />
			<input id="bt2" type="button" value="Jquery对象转DOM对象" />
		</div>
		<div id="myDiv">
			我爱Jquery!
		</div>
	</body>
</html>
```

## 三、鼠标点击变换标签样式($(this)的使用)

实现鼠标点击h标题标签,使其变化颜色的效果：

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>实现鼠标点击h标题标签,使其变化颜色的效果</title>
		<style type="text/css">
			div,ul,li{margin: 0px; padding: 0px; list-style-type: none;}
			div,h2,ul{clear: both; height: auto; overflow: auto;}
			li{width: 250px; height: 100px; line-height: 30px; 
			float: left; text-align: center; border: solid 1px black; margin-left: 20px;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				$("h2").click(function(){
					$(this).css("color","red");
				})	
			})
		</script>
	</head>
	<body>
		<h2>刘备军团(h2标签)</h2>
			<ul id="lbUl">
				<li id="guanyu" class="liubei">关羽<br>(id=guanyu,class=liubei)</li>
				<li id="zhangfei" class="liubei">张飞<br>(id=zhangfei,class=liubei)</li>
				<li id="zhaoyun" class="liubei">赵云<br>(id=zhaoyun,class=liubei)</li>
				<li id="machao" class="liubei">马超<br>(id=machao,class=liubei)</li>
			</ul>
		<h2>曹操军团(h2标签)</h2>
			<ul id="ccUl">
				<li id="dianwei" class="caocao">典韦<br>(id=dianwei,class=caocao)</li>
				<li id="caopi" class="caocao">曹丕<br>(id=caopi,class=caocao)</li>
				<li id="caozhi" class="caocao">曹植<br>(id=caozhi,class=caocao)</li>
				<li id="caoren" class="caocao">曹仁<br>(id=caoren,class=caocao)</li>			
			</ul>
		<h2>孙权军团(h2标签)</h2>
			<ul id="ccUl">
				<li id="huanggai" class="sunquan">黄盖<br>(id=huanggai,class=sunquan)</li>
				<li id="zhouyu" class="sunquan">周瑜<br>(id=zhouyu,class=sunquan)</li>
				<li id="lusu" class="sunquan">鲁肃<br>(id=lusu,class=sunquan)</li>
				<li id="taishici" class="sunquan">太史慈<br>(id=taishici,class=sunquan)</li>			
			</ul>			
	</body>
</html>
```

变换标签P中的文字样式：

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>变换标签P中的文字样式</title>
		<style type="text/css">
			p{line-height: 30px;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				$("#chp01").click(function(){
					$(this).css("font-weight","bold");
					$(this).css("font-style","italic");
					$(this).css("color","green");
				})
				
			})
		</script>
	</head>
	<body>
		<h2>三国演义</h2>
		<h3>第一章</h3>
		<p id="chp01">
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
		</p>
		<h3>第二章</h3>
		<p id="chp02">
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
		</p>
	</body>
</html>
```

## 四、添加和删除样式

添加和删除样式：

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>添加样式和删除样式</title>
		<style type="text/css">
			div,p{line-height: 30px;}
			.myPClass{font-weight: bold; font-style: italic; color: green;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				$("#bt1").click(function(){
					$("#chp01").addClass("myPClass");
				})
				$("#bt2").click(function(){
					$("#chp01").removeClass("myPClass");
				})				
			})
		</script>
	</head>
	<body>
		<div>
			<input id="bt1" type="button" value="给第一章添加样式" />
			<input id="bt2" type="button" value="移除第一章样式" />
		</div>
		<h2>三国演义</h2>
		<h3>第一章</h3>
		<p id="chp01">
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
		</p>
		<h3>第二章</h3>
		<p id="chp02">
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
		
		</p>
	</body>
</html>
```

样式的自动添加和删除：

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>样式的自动添加和删除</title>
		<style type="text/css">
			div,p{line-height: 30px;}
			.myPClass{font-weight: bold; font-style: italic; color: green;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				$("#bt1").click(function(){
					$("#chp01").toggleClass("myPClass");
				})				
			})
		</script>
	</head>
	<body>
		<div>
			<input id="bt1" type="button" value="修改样式" />
		</div>
		<h2>三国演义</h2>
		<h3>第一章</h3>
		<p id="chp01">
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
		</p>
		<h3>第二章</h3>
		<p id="chp02">
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
			话说天下大事，分久必合，合久必分。周末七国分争，并入于秦;及秦灭之后，楚汉分争,又并入汉;
			汉朝自高祖斩白蛇而起义,一统天下,后来光武中兴,传至献帝,遂分为三国
		
		</p>
	</body>
</html>
```

## 五、设置和获取元素内容

html():用于获取第一个匹配元素的html内容或文本内容。

html(content):用于设置所有匹配元素的html内容或文本内容。

text():用于获取所有匹配元素的文本内容。

text(content):用于设置所有匹配元素的文本内容。

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>设置和获取元素内容</title>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				$("#addImg").click(function(){
					$("#myP").html("<img src='img/dog.jpg'> 我们是两只小狗!");
				})
			})
		</script>
	</head>
	<body>
		<p id="myP"></p>
		<input id="addImg" type="button" value="添加图片" />
	</body>
</html>
```

## 六、文本框文字显示和消失（模拟placeholder）

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>文本框文字显示和消失</title>
		<style type="text/css">
			#txtAccount{ color: darkgray;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				$("#txtAccount").focus(function(){
					var accValue = $(this).val();
					if(accValue == "例如:example@qq.com")
					{
						$(this).val("");
						$(this).css("color","black");
					}
						
				})
				$("#txtAccount").blur(function(){
					var accValue = $(this).val();
					if(accValue == "")
					{
						$(this).val("例如:example@qq.com");
						$(this).css("color","darkgray");
					}
					else
					{
						$(this).css("color","black");
					}		
				})				
			})
		</script>
	</head>
	<body>
		<form action="#" onsubmit="return formSubmit();">
			邮箱:<input type="text" id="txtAccount" value="例如:example@qq.com"><br><br>
			密码:<input type="password" id="txtPwd"><br><br>
				<input type="submit" value="登录">
				<a href="#">立即注册</a>
		</form>		
	</body>
</html>
```

## 七、使用attr修改元素的属性

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>使用attr修改元素的属性</title>
		<style type="text/css">
			div{line-height: 30px;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				$("#bt1").click(function(){
					var imgWidth = parseInt($("#myImg").attr("width"));
					$("#myImg").attr("width",imgWidth+20);
				})
				$("#bt2").click(function(){
					var imgWidth = parseInt($("#myImg").attr("width"));
					$("#myImg").attr("width",imgWidth-20);
				})
			})
		</script>
	</head>
	<body>
		<div>
			<input id="bt1" type="button" value="放大" />
			<input id="bt2" type="button" value="缩小" />
		</div>
		<div>
			<img id="myImg" width="200" src="img/dog.jpg">
		</div>
	</body>
</html>
```

## 八、元素内部添加子节点

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>元素内部插入子节点</title>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				$("#bt1").click(function(){
					//方案一
					//$("#myUl").append("<li>" + $("#myTxt").val() + "</li>");
					//方案二
					//var $li = $("<li>" + $("#myTxt").val() + "</li>");
					//$("#myUl").append($li); //将$li追加到myUl中
					//方案三
					var $li = $("<li>" + $("#myTxt").val() + "</li>");
					$li.appendTo($("#myUl")); //将$li追加到myUl中
					
				})
				$("#bt2").click(function(){
					//方案一
					$("#myUl").prepend("<li>" + $("#myTxt").val() + "</li>");
					//方案二
					//var $li = $("<li>" + $("#myTxt").val() + "</li>");
					//$("#myUl").prepend($li); //将$li追加到myUl中
					//方案三
					//var $li = $("<li>" + $("#myTxt").val() + "</li>");
					//$li.prependTo($("#myUl")); //将$li追加到myUl中	
				})
			})
		</script>
	</head>
	<body>
		<h2>班级通讯录</h2>
		<input id="myTxt" type="text"  />
		<input id="bt1" type="button" value="在最后面添加元素"  />
		<input id="bt2" type="button" value="在最前面添加元素"  />
		<ul id="myUl">
			<li>刘德华-13558785478</li>
			<li>张学友-13558785478</li>
		</ul>
	</body>
</html>
```

## 九、元素外部插入同辈节点

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>元素外部插入同辈节点</title>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				//此方式绑定的事件,利用jquery添加的标签无法响应到事件
				//$("#myUl li").click(function(){
				//1.9及以下老版本
				//$("#myUl li").live("click",function(){
				//1.9以上版本
				$("body").on("click", "#myUl li", function(){
				//$("#myUl li").on("click",function(){
					$("#txtPos").val($(this).index())
				})
				$("#bt1").click(function(){
					var $li = $("<li><a href='javascript:void(0);'>" + $("#txtContent").val() + "</a></li>");
					var $myIndex = $("#txtPos").val();
					$("#myUl li").eq($myIndex).after($li);
					//$li.insertAfter($("#myUl li").eq($myIndex));
				})
				$("#bt2").click(function(){
					var $li = $("<li><a href='javascript:void(0);'>" + $("#txtContent").val() + "</a></li>");
					var $myIndex = $("#txtPos").val();
					$("#myUl li").eq($myIndex).before($li);
					//$li.insertBefore($("#myUl li").eq($myIndex))
				})				
			})
		</script>
	</head>
	<body>
		<h2>班级通讯录</h2>
		当前位置:<input id="txtPos" type="text" size="5"  />
		姓名电话:<input id="txtContent" type="text"  /><br /><br />
		<input id="bt1" type="button" value="在当前元素之后插入元素"  />
		<input id="bt2" type="button" value="在当前元素之前插入元素"  />
		<ul id="myUl">
			<li><a href="javascript:void(0);">刘德华-13558785478</a></li>
			<li><a href="javascript:void(0);">张学友-13558785478</a></li>
		</ul>
	</body>
</html>
```

## 十、替换节点

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>替换节点</title>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				//此方式绑定的事件,利用jquery添加的标签无法响应到事件
				//$("#myUl li").click(function(){
				//1.9及以下老版本
				//$("#myUl li").live("click",function(){
				//1.9以上版本
				$("body").on("click", "#myUl li", function(){
					$("#txtPos").val($(this).index())
				})
				$("#bt1").click(function(){
					var $li = $("<li><a href='javascript:void(0);'>" + $("#txtContent").val() + "</a></li>");
					var $myIndex = $("#txtPos").val();
					//方案一：
					//$("#myUl li").eq($myIndex).replaceWith($li);
					//方案二：
					$li.replaceAll($("#myUl li").eq($myIndex));
				})				
			})
		</script>
	</head>
	<body>
		<h2>班级通讯录</h2>
		当前位置:<input id="txtPos" type="text" size="5"  />
		姓名电话:<input id="txtContent" type="text"  /><br /><br />
		<input id="bt1" type="button" value="替换当前元素"  />
		<ul id="myUl">
			<li><a href="javascript:void(0);">刘德华-13558785478</a></li>
			<li><a href="javascript:void(0);">张学友-13558785478</a></li>
		</ul>
	</body>
</html>
```

## 十一、删除节点

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>删除节点</title>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				//此方式绑定的事件,利用jquery添加的标签无法响应到事件
				$("#myUl li").click(function(){
				//1.9及以下老版本
				//$("#myUl li").live("click",function(){
				//1.9以上版本
				//$("body").on("click", "#myUl li", function(){
					$("#txtPos").val($(this).index())
				})
				$("#bt1").click(function(){
					var $li = $("<li><a href='javascript:void(0);'>" + $("#txtContent").val() + "</a></li>");
					var $myIndex = $("#txtPos").val();
					$("#myUl li").eq($myIndex).remove();
					//$("#myUl li").remove(":eq(" + $myIndex + ")");
				})				
			})
		</script>
	</head>
	<body>
		<h2>班级通讯录</h2>
		当前位置:<input id="txtPos" type="text" size="5"  />
		<input id="bt1" type="button" value="删除当前元素"  />
		<ul id="myUl">
			<li><a href="javascript:void(0);">刘德华-13558785478</a></li>
			<li><a href="javascript:void(0);">张学友-13558785478</a></li>
			<li><a href="javascript:void(0);">周杰伦-13558785478</a></li>
			<li><a href="javascript:void(0);">孙燕姿-13558785478</a></li>
			<li><a href="javascript:void(0);">桂纶镁-13558785478</a></li>
		</ul>
	</body>
</html>
```

## 十二、复制节点

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>复制节点</title>
		<style type="text/css">
			div{text-align: center; line-height: 30px;}
			img{ margin: 20px;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				$("#bt1").click(function(){
					for(var i = 1;i <= 10;i++)
					{
						$("#cloneDiv").append($("#swk").clone());
						//$("#swk").clone().appendTo("#cloneDiv");
					}
				})
				$("#bt2").click(function(){
					$("#cloneDiv img").remove();
				})				
			})
		</script>		
	</head>
	<body>
		<div>
			<input id="bt1" type="button" value="变身多个孙悟空"  />
			<input id="bt2" type="button" value="变身一个孙悟空"  />
		</div>
		<div><img id="swk" src="img/sunwukong.png" width="80" /></div>
		<div id="cloneDiv">
			
		</div>
	</body>
</html>
```

## 十三、遍历元素

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>遍历元素</title>
		<style type="text/css">
			div{text-align: center; line-height: 30px;}
			#cloneDiv{ position: relative;}
			#cloneDiv img{ margin: 20px; position: absolute;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				$("#bt1").click(function(){
					for(var i = 1;i <= 10;i++)
					{
						$("#cloneDiv").append($("#swk").clone());
					}
					$("#cloneDiv img").each(function(){
						var $rnd = 0;
						//随机变化图片宽度
						$rnd = Math.ceil(Math.random()*80+50);
						$(this).attr("width",$rnd);
						//随机变化图片left值
						$rnd = Math.ceil(Math.random()*($("body").width()));
						$(this).css("left",$rnd);
						//随机变化图片top值
						$rnd = Math.ceil(Math.random()*500);
						$(this).css("top",$rnd);
						//随机变化旋转值
						$rnd = Math.ceil(Math.random()*120)-60;
						$(this).css("transform","rotate(" + $rnd + "deg)");
					})
				})
				$("#bt2").click(function(){
					$("#cloneDiv img").remove();
				})				
			})
		</script>
	</head>
	<body>
		<div>
			<input id="bt1" type="button" value="变身多个孙悟空"  />
			<input id="bt2" type="button" value="变身一个孙悟空"  />
		</div>
		<div><img id="swk" src="img/sunwukong.png" width="80" /></div>
		<div id="cloneDiv">
			
		</div>
	</body>
</html>
```

## 十四、模拟模态对话框效果

调用页面：

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>遮罩层对话框</title>
		<style type="text/css">
			.ModalBg{ position: fixed; width: 100%; height: 100%; 
			background-color: darkgray; opacity: 0.3; z-index: 100; left: 0px; top: 0px;
			display:none;}
			.MyModal{ position: absolute; top: 150px; left: 50%; margin: auto;   
			background-color: white; padding: 10px; z-index: 101; display: none;}
			.ModalClose{ position: absolute; top: 0px; right: 0px; 
			height:30px; line-height: 30px;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				$("#close1").click(function(){
					$(".ModalBg").css("display","none");
					$("#Modal1").css("display","none");				
				})
				$("#bt1").click(function(){
					$(".ModalBg").css("display","block");
					$("#Modal1").css("display","block");
				})

				$("#close2").click(function(){
					$(".ModalBg").css("display","none");
					$("#Modal2").css("display","none");				
				})
				$("#bt2").click(function(){
					$(".ModalBg").css("display","block");
					$("#Modal2").css("display","block");
				})
			})
		</script>
	</head>
	<body>
		<div style="margin-top: 200px; text-align: center;">
			<input id="bt1" type="button" value="弹出内部DIV对话框" />
			<input id="bt2" type="button" value="加载外部网页" />
		</div>
	</body>
</html>
<div class="ModalBg">
	
</div>

<!--由于插件样式表中left:50%,所以将margin-left设置成width的一半实现居中-->
<div id="Modal1" class="MyModal" style="width: 400px; margin-left: -200px;">
	<div class="ModalClose"><a href="#" id="close1">关闭</a>&nbsp;</div>
	<form action="">
		用户名:<input type="text" id="txtAccount"><br><br>
		密    码:<input type="password" id="txtPwd"><br><br>
			<input type="submit" value="登录">
			<input type="submit" value="取消">
	</form>		
</div>
<div id="Modal2" class="MyModal" style="width: 400px; margin-left: -200px;">
	<div class="ModalClose"><a href="#" id="close2">关闭</a>&nbsp;</div>
	<iframe src="Demo14_01.html" frameborder="no" width="380" height="200"></iframe>
</div>
```

对话框页面：

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>对话框页面</title>
	</head>
	<body>
		<form action="">
			用户名:<input type="text" id="txtAccount"><br><br>
			密    码:<input type="password" id="txtPwd"><br><br>
				<input type="submit" value="登录">
				<input type="submit" value="取消">
				<a href="">注册</a>
		</form>	
	</body>
</html>
```

