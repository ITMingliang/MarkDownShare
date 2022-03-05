# JQuery初体验和选择器

 jQuery 是一个 JavaScript 库， jQuery 极大地简化了 JavaScript 编程。 

 jQuery的宗旨： Write less,do more。

**学习JQuery需要具备的基础知识：**

（1）HTML;		（2）CSS;		（3）JavaScript

## 一、$(document).ready() 的使用

思考如下程序报错如何修改：

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>$(document).ready的使用</title>
		<style type="text/css">
			#myImg{display: none;}
		</style>
		<script type="text/javascript">
			//图片默认是隐藏的,要实现图片自动显示
			//此程序会报错,原因是页面HTML还没有解析下载完成,无法获取到myImg图片
			//解决方案有如下:
			//(1)将JS代码放到myImg图片的后面
			//(2)封装成函数,在body的onload事件中取调用
			//(3)使用Jquery,并将代码写在$(document).ready中
			document.getElementById("myImg").style.display = "block";
		</script>
	</head>
	<body>	
		<img id="myImg" src="img/glm1.jpg">
	</body>
</html>
```

解决方案一：

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>$(document).ready的使用</title>
		<style type="text/css">
			#myImg{display: none;}
		</style>
	</head>
	<!--$(document).ready的使用:在窗体结构加载完毕后执行-->
	<body>		
		<img id="myImg" src="img/glm1.jpg">
	</body>
</html>
<script type="text/javascript">
	document.getElementById("myImg").style.display = "block";
</script>
```

解决方案二：

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>$(document).ready的使用</title>
		<style type="text/css">
			#myImg{display: none;}
		</style>
		<script type="text/javascript">
			function ShowImg()
			{
				document.getElementById("myImg").style.display = "block";
			}
		</script>
	</head>
	<body onload="ShowImg()">
		<img id="myImg" src="img/glm1.jpg">
	</body>
</html>
```

解决方案三：使用JQuery中的$(document).ready()事件，表示在页面结构加载完毕后执行。

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>$(document).ready的使用</title>
		<style type="text/css">
			#myImg{display: none;}
		</style>
		<script type="text/javascript" src="js/jquery.js"></script>
		<script type="text/javascript">
			// $(document).ready(function()
			// {
			// 	//$("#myImg").css("display","block");
			// 	$("#myImg").show(2000);
			// })
			
			//或简写
			
			$(function(){
				//$("#myImg").css("display","block");
				$("#myImg").show(2000);
			})			
		</script>
	</head>
	<!--$(document).ready的使用:在窗体结构加载完毕后执行-->
	<body>		
		<img id="myImg" src="img/glm1.jpg" width="500">
	</body>
</html>
```

## 二、show,hide,toggle显示隐藏

show：显示隐藏的匹配元素。

hide：隐藏显示的元素。

toggle：如果元素是可见的，切换为隐藏的；如果元素是隐藏的，切换为可见的。

**效果一：**

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="utf-8" />
		<title>编写一个简单的jQuery应用</title>
		<style type="text/css">
			#myDiv{display: none;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function()
			{
				$("#showButton").click(function()
				{
					//$("#myDiv").show();
					$("#myDiv").show(2000);
				})
				$("#hideButton").click(function()
				{
					//$("#myDiv").hide();
					$("#myDiv").hide(2000);	
				})
				$("#changeButton").click(function()
				{
					//$("#myDiv").hide();
					$("#myDiv").toggle(2000);	
				})				
			})

		</script>
	</head>
	<body>
		<div>
			<input id="showButton" type="button" value="显示图片">
			<input id="hideButton" type="button" value="隐藏图片">	
			<input id="changeButton" type="button" value="切换状态">	
		</div>
		<div id="myDiv">
			<img src="img/glm1.jpg" width="500" />
		</div>
	</body>
</html>
```

**效果二：**

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="utf-8" />
		<title>编写一个简单的jQuery应用</title>
		<style type="text/css">
			#myDiv{display: none;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			function MyAnimation()
			{
				$("#myDiv").toggle(2000);
			}
			$(function()
			{
				MyAnimation();
				setInterval("MyAnimation()",3000);
			})
		</script>
	</head>
	<body>
		<div id="myDiv">
			<img src="img/glm1.jpg" width="500" height="400" />
		</div>
	</body>
</html>
```

## 三、toggleClass与toggle的使用

toggle：如果元素是可见的，切换为隐藏的；如果元素是隐藏的，切换为可见的。

toggleClass：如果存在（不存在）就删除（添加）一个类。

制作竖向二级菜单

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>toggleClass与toggle的使用</title>
		<style type="text/css">
			#myTitle a{ text-decoration: none;}
			.highLight{ color: red; font-weight: bold;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				$("#myTitle a").mouseover(function(){
					//如果存在（不存在）就删除（添加）一个类样式。
					$(this).toggleClass("highLight");
				})
				$("#myTitle a").mouseout(function(){
					$(this).toggleClass("highLight");
				})
				$("#myTitle").click(function(){
					//如果元素是可见的，切换为隐藏的；如果元素是隐藏的，切换为可见的
					$(this).next("ul").toggle(500);
				})
			})
		</script>
	</head>
	<body>
		<h3 id="myTitle"><a href="#">个人信息维护</a></h3>
		<ul>
		   	<li>基本信息维护</li>
		   	<li>密码管理</li>
		   	<li>头像管理</li>
		   	<li>收货地址管理</li>
		</ul>
	</body>
</html>
```

## 四、常用选择器

### （1）基本选择器

ID选择器（#id）：根据给定的ID匹配一个元素。

class选择器（.class）：根据给定的css类名匹配元素。

标签选择器（element）：根据给定的元素标签名匹配所有元素。

*选择器：匹配所有元素。

合并选择器（selector1,selector2,selectorN）：将每一个选择器匹配到的元素合并后一起返回。

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>基本选择题</title>
		<style type="text/css">
			div,ul,li{margin: 0px; padding: 0px; list-style-type: none;}
			div,h2,ul{clear: both; height: auto; overflow: auto;}
			li{width: 250px; height: 100px; line-height: 30px; 
			float: left; text-align: center; border: solid 1px black; margin-left: 20px;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				//ID选择器
				$("#idSelect").click(function(){
					$("*").removeAttr("style");
					$("#zhangfei").css("backgroundColor","green");
				})
				//class选择器
				$("#classSelect").click(function(){
					$("*").removeAttr("style");
					$(".caocao").css("backgroundColor","green");
				})
				//标签选择器
				$("#tagSelect").click(function(){
					$("*").removeAttr("style");
					$("h2").css("backgroundColor","green");
				})
				//*选择器
				$("#allSelect").click(function(){
					$("*").removeAttr("style");
					$("*").css("backgroundColor","green");
				})
				//合并选择器
				$("#andSelect").click(function(){
					$("*").removeAttr("style");
					$("h2,#zhouyu,#caopi").css("backgroundColor","green");
				})
			})
		</script>
	</head>
	<body>
		<div>
			<input type="button" id="idSelect" value="选择ID为zhangfei的元素">
			<input type="button" id="classSelect" value="选择class为caocao的元素">
			<input type="button" id="tagSelect" value="选择标签名是h2的元素">
			<input type="button" id="allSelect" value="选择所有元素">
			<input type="button" id="andSelect" value="选择标签名是h2的元素、id为zhouyu的元素以及id为caopi的元素">
		</div>
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

### （2）层次选择器

后代选择器（ancestor descendant）：在给定的祖先元素下匹配所有的后代元素。

子选择器（parent > child）：在给定的父元素下匹配所有的子元素。

相邻元素选择器（prev + next）：匹配所有紧接在 prev 元素后的 next 元素

同辈元素选择器（prev ~ siblings）：匹配 prev 元素之后的所有 siblings 元素。

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>层次选择器</title>
		<style type="text/css">
			div{margin: 0px; padding: 0px; height: auto; overflow: auto; text-align: center;}
			.team{clear: both; border: solid 1px black; background-color: pink;}
			.liubei,.caocao,.sunquan{ width: 250px; height: 100px; margin: 20px; float: left;
			border: solid 1px black; line-height: 30px; background-color: pink;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				//后代选择器
				$("#allSelect").click(function(){
					$("*").removeAttr("style");
					$("body div").css("backgroundColor","green");
				})
				//子选择器
				$("#sonSelect").click(function(){
					$("*").removeAttr("style");
					$("body>div").css("backgroundColor","green");
				})
				//相邻元素选择器
				$("#nextSelect").click(function(){
					$("*").removeAttr("style");
					$("#dianwei+div").css("backgroundColor","green");
				})
				//同辈元素选择器
				$("#nextAllSelect").click(function(){
					$("*").removeAttr("style");
					$("#dianwei~div").css("backgroundColor","green");
				})	
			})
		</script>
	</head>
	<body>
		<div>
			<input type="button" id="allSelect" value="选择body内所有DIV">
			<input type="button" id="sonSelect" value="选择body内的子元素(儿子)DIV">
			<input type="button" id="nextSelect" value="选择id为dianwei的下一个DIV兄弟">
			<input type="button" id="nextAllSelect" value="选择id为dianwei的后面所有DIV兄弟">
		</div>
		<h2>刘备军团(h2标签)</h2>
			<div id="lbUl" class="team">
				<div id="guanyu" class="liubei">关羽<br>(id=guanyu,class=liubei)</div>
				<div id="zhangfei" class="liubei">张飞<br>(id=zhangfei,class=liubei)</div>
				<div id="zhaoyun" class="liubei">赵云<br>(id=zhaoyun,class=liubei)</div>
				<div id="machao" class="liubei">马超<br>(id=machao,class=liubei)</div>
			</div>
		<h2>曹操军团(h2标签)</h2>
			<div id="ccUl" class="team">
				<div id="dianwei" class="caocao">典韦<br>(id=dianwei,class=caocao)</div>
				<div class="caocao">曹丕<br>(id=caopi,class=caocao)</div>
				<div class="caocao">曹植<br>(id=caozhi,class=caocao)</div>
				<div class="caocao">曹仁<br>(id=caoren,class=caocao)</div>			
			</div>
		<h2>孙权军团(h2标签)</h2>
			<div id="ccUl" class="team">
				<div id="huanggai" class="sunquan">黄盖<br>(id=huanggai,class=sunquan)</div>
				<div id="zhouyu" class="sunquan">周瑜<br>(id=zhouyu,class=sunquan)</div>
				<div id="lusu" class="sunquan">鲁肃<br>(id=lusu,class=sunquan)</div>
				<div id="taishici" class="sunquan">太史慈<br>(id=taishici,class=sunquan)</div>			
			</div>			
	</body>
</html>
```

### （3）基本过滤选择器

:first：获取第一个元素。

:last：获取最后一个元素。

:not(selector)：去除所有与给定选择器匹配的元素。

:even：匹配所有索引值为偶数的元素，从0开始。

:odd：匹配所有索引值为奇数的元素，从0开始。

:eq(index)：匹配一个给定索引值的元素。

:gt(index)：匹配所有大于给定值的元素。

:lt(index)：匹配所有小于给定值的元素。

:header：匹配如h1,h2,h3之类的标题元素。

:animated：匹配所有正在执行动画效果的元素。

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>基本过滤选择器</title>
		<style type="text/css">
			div{margin: 0px; padding: 0px; height: auto; overflow: auto; text-align: center;}
			#myButtons{ border: solid 1px black; height: 80px; line-height: 40px;}
			.team{clear: both; border: solid 1px black; background-color: pink;}
			.liubei,.caocao,.sunquan{ width: 250px; height: 100px; margin: 20px; float: left;
			border: solid 1px black; line-height: 30px; background-color: pink;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			function MyAnimation()
			{
				$("#machao").toggle(2000);
				$("#caoren").toggle(2000);
				$("#taishici").toggle(2000);
			}
			
			$(function(){
				setInterval("MyAnimation()",2000);
				//获取第一个元素
				$("#firstSelect").click(function(){
					$("*").removeAttr("style");
					$("div:first").css("backgroundColor","green");
				})
				//获取最后一个元素
				$("#laseSelect").click(function(){
					$("*").removeAttr("style");
					$("div:last").css("backgroundColor","green");
				})
				//获取除给定选择器之外的所有元素
				$("#notSelect").click(function(){
					$("*").removeAttr("style");
					$("div:not(.liubei)").css("backgroundColor","green");
				})
				//获取索引值为偶数的元素，索引号从0开始
				$("#evenSelect").click(function(){
					$("*").removeAttr("style");
					$("div:even").css("backgroundColor","green");
				})				
				//获取索引值为奇数的元素，索引号从0开始
				$("#oddSelect").click(function(){
					$("*").removeAttr("style");
					$("div:odd").css("backgroundColor","green");
				})
				//获取索引值等于index的元素(选择索引为3的DIV元素)
				$("#eqSelect").click(function(){
					$("*").removeAttr("style");
					$("div:eq(3)").css("backgroundColor","green");
				})
				//选择索引不为3的DIV元素
				$("#notEqSelect").click(function(){
					$("*").removeAttr("style");
					$("div:not(:eq(3))").css("backgroundColor","green");
				})
				//选择索引大于3的DIV元素
				$("#gtSelect").click(function(){
					$("*").removeAttr("style");
					$("div:gt(3)").css("backgroundColor","green");
				})				
				//选择索引小于3的DIV元素
				$("#ltSelect").click(function(){
					$("*").removeAttr("style");
					$("div:lt(3)").css("backgroundColor","green");
				})
				//获取所有标题元素，如h1~h6
				$("#hSelect").click(function(){
					$("*").removeAttr("style");
					$(":header").css("backgroundColor","green");
				})				
				//获取正在执行动画效果的元素
				$("#AnimateSelect").click(function(){
					$("*").removeAttr("style");
					$(":animated").css("backgroundColor","green");
				})				
			})
		</script>
	</head>
	<body>
		<div id="myButtons">
			<input type="button" id="firstSelect" value="选择第一个DIV元素">
			<input type="button" id="laseSelect" value="选择最后一个DIV元素">
			<input type="button" id="notSelect" value="选择class不为liubei的元素">
			<input type="button" id="evenSelect" value="选择索引为偶数的DIV元素">
			<input type="button" id="oddSelect" value="选择索引为奇数的DIV元素">
			<input type="button" id="eqSelect" value="选择索引为3的DIV元素">
			<input type="button" id="notEqSelect" value="选择索引不为3的DIV元素">
			<input type="button" id="gtSelect" value="选择索引大于3的DIV元素">
			<input type="button" id="ltSelect" value="选择索引小于3的DIV元素">
			<input type="button" id="hSelect" value="选择所有的标题元素H1-H6">
			<input type="button" id="AnimateSelect" value="选择当前正在执行动画的元素">
		</div>
		<h2>刘备军团(h2标签)</h2>
			<div id="lbUl" class="team">
				<div id="guanyu" class="liubei">关羽<br>(id=guanyu,class=liubei)</div>
				<div id="zhangfei" class="liubei">张飞<br>(id=zhangfei,class=liubei)</div>
				<div id="zhaoyun" class="liubei">赵云<br>(id=zhaoyun,class=liubei)</div>
				<div id="machao" class="liubei">马超<br>(id=machao,class=liubei)</div>
			</div>
		<h2>曹操军团(h2标签)</h2>
			<div id="ccUl" class="team">
				<div id="dianwei" class="caocao">典韦<br>(id=dianwei,class=caocao)</div>
				<div id="caopi" class="caocao">曹丕<br>(id=caopi,class=caocao)</div>
				<div id="caozhi" class="caocao">曹植<br>(id=caozhi,class=caocao)</div>
				<div id="caoren" class="caocao">曹仁<br>(id=caoren,class=caocao)</div>			
			</div>
		<h2>孙权军团(h2标签)</h2>
			<div id="ccUl" class="team">
				<div id="huanggai" class="sunquan">黄盖<br>(id=huanggai,class=sunquan)</div>
				<div id="zhouyu" class="sunquan">周瑜<br>(id=zhouyu,class=sunquan)</div>
				<div id="lusu" class="sunquan">鲁肃<br>(id=lusu,class=sunquan)</div>
				<div id="taishici" class="sunquan">太史慈<br>(id=taishici,class=sunquan)</div>			
			</div>			
	</body>
</html>
```

### （4）内容过滤选择器

:contains(text)：匹配包含给定文本的元素。

:parent：匹配含有子元素或者文本的元素。

:empty：匹配所有不包含子元素或者文本的空元素。

:has(selector)：匹配含有选择器所匹配的元素的元素。

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>内容过滤选择器</title>
		<style type="text/css">
			div{margin: 0px; padding: 0px; height: auto; overflow: auto; text-align: center;}
			.team{clear: both; border: solid 1px black; background-color: pink;}
			.liubei,.caocao,.sunquan{ width: 250px; height: 100px; margin: 20px; float: left;
			border: solid 1px black; line-height: 30px; background-color: pink;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				//获取含有文本内容为text的元素
				$("#containSelect").click(function(){
					$("*").removeAttr("style");
					//找出含有曹的所有DIV
					$("div:contains('曹')").css("backgroundColor","green");
					//找出含有曹的所有DIV(只保留存放人物的小div,不包括存放整个曹操军团的大div)
					//$("div:contains('曹'):not(.team)").css("backgroundColor","green");
				})
				//获取含有文本内容为text...的元素
				$("#containMoreSelect").click(function(){
					$("*").removeAttr("style");
					$("div:contains('曹'),div:contains('黄')").css("backgroundColor","green");
				})
				//获取含有后代元素或者文本的非空元素
				$("#parentSelect").click(function(){
					$("*").removeAttr("style");
					$("div:parent").css("backgroundColor","green");
				})
				//获取不包含后代元素或者文本的空元素
				$("#emptySelect").click(function(){
					$("*").removeAttr("style");
					$("div:empty").css("backgroundColor","green");
				})
				//获取含有后代元素为selector的元素
				$("#hasSelect").click(function(){
					$("*").removeAttr("style");
					$("div:has(#zhaoyun),div:has(#zhouyu)").css("backgroundColor","green");
				})			
				
			})
		</script>
	</head>
	<body>
		<div>
			<input type="button" id="containSelect" value="选择含有文本“曹”的DIV">
			<input type="button" id="containMoreSelect" value="选择含有文本“曹”和“黄”的DIV">
			<input type="button" id="parentSelect" value="选择包含子元素(或者文本元素)的空DIV">
			<input type="button" id="emptySelect" value="选择不包含子元素(或者文本元素)的空DIV">		
			<input type="button" id="hasSelect" value="选择含有id为zhaoyun或zhouyu的子元素的DIV">
		</div>
		<h2>刘备军团(h2标签)</h2>
			<div id="lbUl" class="team">
				<div id="guanyu" class="liubei">关羽<br>(id=guanyu,class=liubei)</div>
				<div id="zhangfei" class="liubei">张飞<br>(id=zhangfei,class=liubei)</div>
				<div id="zhaoyun" class="liubei">赵云<br>(id=zhaoyun,class=liubei)</div>
				<div id="machao" class="liubei"></div>
			</div>
		<h2>曹操军团(h2标签)</h2>
			<div id="ccUl" class="team">
				<div id="dianwei" class="caocao">典韦<br>(id=dianwei,class=caocao)</div>
				<div id="caopi" class="caocao">曹丕<br>(id=caopi,class=caocao)</div>
				<div id="caozhi" class="caocao">曹植<br>(id=caozhi,class=caocao)</div>
				<div id="caoren" class="caocao"></div>
			</div>
		<h2>孙权军团(h2标签)</h2>
			<div id="ccUl" class="team">
				<div id="huanggai" class="sunquan">黄盖<br>(id=huanggai,class=sunquan)</div>
				<div id="zhouyu" class="sunquan">周瑜<br>(id=zhouyu,class=sunquan)</div>
				<div id="lusu" class="sunquan">鲁肃<br>(id=lusu,class=sunquan)</div>
				<div id="taishici" class="sunquan"></div>			
			</div>			
	</body>
</html>
```

### （5）可见性过滤选择器

:visible：匹配所有的可见元素。

:hidden：匹配所有不可见元素，或者type为hidden的元素。

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>可见性过滤选择器</title>
		<style type="text/css">
			div{margin: 0px; padding: 0px; height: auto; overflow: auto; text-align: center;}
			.team{clear: both; border: solid 1px black; background-color: pink;}
			.liubei,.caocao,.sunquan{ width: 250px; height: 100px; margin: 20px; float: left;
			border: solid 1px black; line-height: 30px; background-color: pink;}
			#zhangfei,#caopi,#zhouyu{display: none;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				//选取可见元素
				$("#visibleSelect").click(function(){
					$("*").removeAttr("style");
					$("div:visible").css("backgroundColor","green");
				})
				//选取不可见元素
				$("#hideSelect").click(function(){
					$("*").removeAttr("style");
					$("div:hidden").css("backgroundColor","green");
					$("div:hidden").show(1000);
				})			
			})
		</script>
	</head>
	<body>
		<div>
			<input type="button" id="visibleSelect" value="选择所有的可见DIV">
			<input type="button" id="hideSelect" value="选择所有的不可见DIV">
		</div>
		<h2>刘备军团(h2标签)</h2>
			<div id="lbUl" class="team">
				<div id="guanyu" class="liubei">关羽<br>(id=guanyu,class=liubei)</div>
				<div id="zhangfei" class="liubei">张飞<br>(id=zhangfei,class=liubei)</div>
				<div id="zhaoyun" class="liubei">赵云<br>(id=zhaoyun,class=liubei)</div>
				<div id="machao" class="liubei">马超<br>(id=machao,class=liubei)</div>
			</div>
		<h2>曹操军团(h2标签)</h2>
			<div id="ccUl" class="team">
				<div id="dianwei" class="caocao">典韦<br>(id=dianwei,class=caocao)</div>
				<div id="caopi" class="caocao">曹丕<br>(id=caopi,class=caocao)</div>
				<div id="caozhi" class="caocao">曹植<br>(id=caozhi,class=caocao)</div>
				<div id="caoren" class="caocao">曹仁<br>(id=caoren,class=caocao)</div>			
			</div>
		<h2>孙权军团(h2标签)</h2>
			<div id="ccUl" class="team">
				<div id="huanggai" class="sunquan">黄盖<br>(id=huanggai,class=sunquan)</div>
				<div id="zhouyu" class="sunquan">周瑜<br>(id=zhouyu,class=sunquan)</div>
				<div id="lusu" class="sunquan">鲁肃<br>(id=lusu,class=sunquan)</div>
				<div id="taishici" class="sunquan">太史慈<br>(id=taishici,class=sunquan)</div>			
			</div>			
	</body>
</html>
```

### （6）属性过滤选择器

```
[attribute]：匹配包含给定属性的元素。

[attribute=value]：匹配给定的属性是某个特定值的元素。

[attribute!=value]：匹配所有不含有指定的属性，或者属性不等于特定值的元素。

[attribute^=value]：匹配给定的属性是以某些值开始的元素。

[attribute$=value]：匹配给定的属性是以某些值结尾的元素。

[attribute*=value]：匹配给定的属性是以包含某些值的元素。

[selector1][selector2][selectorN]:复合属性选择器，需要同时满足多个条件时使用。
```

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>属性过滤选择器</title>
		<style type="text/css">
			div{margin: 0px; padding: 0px; height: auto; overflow: auto; text-align: center;}
			.team{clear: both; border: solid 1px black; background-color: pink;}
			.liubei,.caocao,.sunquan{ width: 250px; height: 100px; margin: 20px; float: left;
			border: solid 1px black; line-height: 30px; background-color: pink;}
			#myButtons{ border: solid 1px black; height: 80px; line-height: 40px;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				//获取拥有该属性的所有元素，如$('li[title]')表示获取所有包含title属性的<li>元素
				$("#bt1").click(function(){
					$("*").removeAttr("style");
					$("div[title]").css("backgroundColor","green");
				})
				//获取某属性值为value的所有元素，如$(‘li[title=test2]’)表示获取所有包含title属性且属性值等于test2的<li>元素
				$("#bt2").click(function(){
					$("*").removeAttr("style");
					$("div[title='我是张飞']").css("backgroundColor","green");
				})
				//获取某属性值不等于value的所有元素，如$(‘li[title!=test2]’)表示获取所有包含title属性且属性值不等于test2的<li>元素
				$("#bt3").click(function(){
					$("*").removeAttr("style");
					$("div[title!='我是张飞']").css("backgroundColor","green");
				})
				//选取属性值以value开头的所有元素，如$('a[href^="mailto:"]')表示获取所有包含href属性，且属性值以mailto:开头的<a>元素
				$("#bt4").click(function(){
					$("*").removeAttr("style");
					$("div[title^='我']").css("backgroundColor","green");
				})
				//选取属性值以value结束的所有元素，如$('a[href$=".zip"]')表示获取所有包含href属性，且属性值以.zip结尾的<a>元素
				$("#bt5").click(function(){
					$("*").removeAttr("style");
					$("div[title$='羽']").css("backgroundColor","green");
				})
				//选取属性值中包含value的所有元素，如$('a[href*="qq.com.cn"]')表示获取所有包含href属性且属性值中包含mstanford.com.cn的<a>元素
				$("#bt6").click(function(){
					$("*").removeAttr("style");
					$("div[title*='史']").css("backgroundColor","green");
				})
				//合并多个选择器，满足多个条件，每选择一次将缩小一次范围，如$(‘li[id][title^=test]’)选取所有拥有属性id且属性title以test开头的<li>元素
				$("#bt7").click(function(){
					$("*").removeAttr("style");
					$("div[id][title*='史']").css("backgroundColor","green");
				})	
			})
		</script>
	</head>
	<body>
		<div id="myButtons" title="myButtons">
			<input type="button" id="bt1" value="选择含有属性title的DIV">
			<input type="button" id="bt2" value="选择属性title值等于“我是张飞”的DIV">
			<input type="button" id="bt3" value="选择属性title值不等于“我是张飞”的DIV,没有属性title的也将被选中">
			<input type="button" id="bt4" value="选取属性title值以“我”开始 的div">
			<input type="button" id="bt5" value="选取属性title值以“羽”结束 的div">
			<input type="button" id="bt6" value="选取属性title值含有“史”的div元素">
			<input type="button" id="bt7" value="组合属性选择器,首先选取有属性id的div元素，然后在结果中 选取属性title值 含有“史”的元素">			
		</div>
		<h2>刘备军团(h2标签)</h2>
			<div id="lbUl" class="team">
				<div id="guanyu" class="liubei" title="我是关羽">关羽<br>(id=guanyu,class=liubei)</div>
				<div id="zhangfei" class="liubei" title="我是张飞">张飞<br>(id=zhangfei,class=liubei)</div>
				<div id="zhaoyun" class="liubei" title="我是赵云">赵云<br>(id=zhaoyun,class=liubei)</div>
				<div id="machao" class="liubei" title="我是马超">马超<br>(id=machao,class=liubei)</div>
			</div>
		<h2>曹操军团(h2标签)</h2>
			<div id="ccUl" class="team">
				<div id="dianwei" class="caocao" title="我是典韦">典韦<br>(id=dianwei,class=caocao)</div>
				<div id="caopi" class="caocao" title="我是曹丕">曹丕<br>(id=caopi,class=caocao)</div>
				<div id="caozhi" class="caocao" title="我是曹植">曹植<br>(id=caozhi,class=caocao)</div>
				<div id="caoren" class="caocao" title="我是曹仁">曹仁<br>(id=caoren,class=caocao)</div>			
			</div>
		<h2>孙权军团(h2标签)</h2>
			<div id="ccUl" class="team">
				<div id="huanggai" class="sunquan" title="我是黄盖">黄盖<br>(id=huanggai,class=sunquan)</div>
				<div id="zhouyu" class="sunquan" title="我是周瑜">周瑜<br>(id=zhouyu,class=sunquan)</div>
				<div id="lusu" class="sunquan" title="我是鲁肃">鲁肃<br>(id=lusu,class=sunquan)</div>
				<div id="taishici" class="sunquan" title="我是太史慈">太史慈<br>(id=taishici,class=sunquan)</div>			
			</div>			
	</body>
</html>
```

### （7）子元素过滤选择器

```
:first-child：匹配所给选择器( :之前的选择器)的第一个子元素。
:last-child：匹配最后一个子元素。
:nth-child：匹配其父元素下的第N个子或奇偶元素。
:only-child：如果某个元素是父元素中唯一的子元素，那将会被匹配。
```

```
:first-of-type：结构化伪类，匹配E的父元素的第一个E类型的孩子。
:last-of-type：结构化伪类，匹配E的父元素的最后一个E类型的孩子。
:nth-of-type：选择同属于一个父元素之下，并且标签名相同的子元素中的第n个。
:only-of-type：选择所有没有兄弟元素，且具有相同的元素名称的元素。
```

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>子元素过滤选择器</title>
		<script type="text/javascript" src="js/jquery.js"></script>
		<script type="text/javascript">
			$(function(){
				//第一部分：child用法
				//$("#div1 p:first-child").css("backgroundColor","red");
				//$("#div1 p:last-child").css("backgroundColor","red");
				//$("#div1 p:nth-child(2)").css("backgroundColor","red");
				//$("#div1 p:nth-child(odd)").css("backgroundColor","red");
				//$("#div1 p:nth-child(even)").css("backgroundColor","red");
				//此处测试的时候删除第二个到第六个段落
				//$("#div1 p:only-child").css("backgroundColor","red");

				//第二部分:of-type用法
				//$("#div1 p:first-of-type").css("backgroundColor","red");
				//$("#div1 p:last-of-type").css("backgroundColor","red");
				//$("#div1 p:nth-of-type(2)").css("backgroundColor","red");
				//$("#div1 p:nth-of-type(odd)").css("backgroundColor","red");
				//$("#div1 p:nth-of-type(even)").css("backgroundColor","red");
				//此处测试的时候删除第二个到第六个段落
				//$("#div1 p:only-of-type").css("backgroundColor","red");				
			});
		</script>
	</head>
	<body>
		<div id="div1">
			<p>我是第一个段落</p>
			<p>我是第二个段落</p>
			<p>我是第三个段落</p>
			<p>我是第四个段落</p>
			<p>我是第五个段落</p>
			<p>我是第六个段落</p>
		</div>	
	</body>
</html>


```

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>child和of-type区别</title>
		<script type="text/javascript" src="js/jquery.js"></script>
		<script type="text/javascript">
			$(function(){		
				//child和of-type区别
				//$("#div1 p:first-child").css("backgroundColor","red");
				$("#div1 p:first-of-type").css("backgroundColor","red");
			});
		</script>
	</head>
	<body>
		<div id="div1">
			<div>我是第一个DIV内容</div>
			<p>我是第一个段落</p>
			<p>我是第二个段落</p>
			<p>我是第三个段落</p>
			<p>我是第四个段落</p>
			<p>我是第五个段落</p>
			<p>我是第六个段落</p>
		</div>	
	</body>
</html>
```

### （8）表单选择器

```
:input：匹配所有 input, textarea, select 和 button 等元素。
:text：匹配所有的单行文本框。
:password：匹配所有密码框。
:radio：匹配所有单选按钮。
:checkbox：匹配所有复选框。
:submit：匹配所有提交按钮，理论上只匹配 type="submit" 的input或者button，但是现在的很多浏览器，button元素默认的type即为submit，所以很多情况下，不设置type的button也会成为筛选结果。
:image：匹配所有图像域。
:reset：匹配所有重置按钮。
:button：匹配所有普通按钮。
:file：匹配所有文件域。
```

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>表单选择器</title>
		<style type="text/css">
			#myButtons{line-height: 30px;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				//	获取<input><textarea><select><button>
				$("#bt1").click(function(){
					$("*").removeAttr("style");
					alert("数量:" + $(":input").length + ",radio单选和checkbox多选样式无法修改");
					$(":input").css("border","2px solid pink");
					//修改成圆角边框
					//$(":input").css("borderRadius","8px solid green");
				})		
				//	获取符合[type=text]的<input>元素
				$("#bt2").click(function(){
					$("*").removeAttr("style");
					alert("数量:" + $(":text").length);
					$(":text").css("border","2px solid pink");
				})				
				//	获取符合[type=password]的<input>元素
				$("#bt3").click(function(){
					$("*").removeAttr("style");
					alert("数量:" + $(":password").length);
					$(":password").css("border","2px solid pink");
				})
				//	获取符合[type=radio]的<input>元素
				$("#bt4").click(function(){
					$("*").removeAttr("style");
					alert("数量:" + $(":radio").length);
				})
				//	获取符合[type=checkbox]的<input>元素
				$("#bt5").click(function(){
					$("*").removeAttr("style");
					alert("数量:" + $(":checkbox").length);
				})				
				//	获取符合[type=image]的<input>元素
				$("#bt6").click(function(){
					$("*").removeAttr("style");
					alert("数量:" + $(":image").length);
					$(":image").css("border","2px solid black");
				})
				//	获取符合[type=file]的<input>元素
				$("#bt7").click(function(){
					$("*").removeAttr("style");
					alert("数量:" + $(":file").length);
					$(":file").css("border","2px solid pink");
				})
				//	获取符合[type=hidden]的<input>元素
				//选择器前加了一个input,如果不加,则<br /><meta><script>等都算在内了
				$("#bt8").click(function(){
					$("*").removeAttr("style");
					alert("数量:" + $("input:hidden").length);
				})
				//	获取<button>元素和符合[type=button]的<input>元素
				$("#bt9").click(function(){
					$("*").removeAttr("style");
					alert("数量:" + $(":button").length);
					$(":button").css("border","2px solid pink");
				})				
				//	获取符合[type=submit]的<input>元素
				$("#bt10").click(function(){
					$("*").removeAttr("style");
					alert("数量:" + $(":submit").length);
					$(":submit").css("border","2px solid pink");
				})
				//	获取符合[type=reset]的<input>元素	
				$("#bt11").click(function(){
					$("*").removeAttr("style");
					alert("数量:" + $(":reset").length);
					$(":reset").css("border","2px solid pink");
				})
			})
		</script>
	</head>
	<body>
		<div id="myButtons">
			<input type="button" id="bt1" value="获取<input><textarea><select><button>元素">
			<input type="button" id="bt2" value="获取符合[type=text]的<input>元素">
			<input type="button" id="bt3" value="获取符合[type=password]的<input>元素">
			<input type="button" id="bt4" value="获取符合[type=radio]的<input>元素">
			<input type="button" id="bt5" value="获取符合[type=checkbox]的<input>元素">
			<input type="button" id="bt6" value="获取符合[type=image]的<input>元素">
			<input type="button" id="bt7" value="获取符合[type=file]的<input>元素">
			<input type="button" id="bt8" value="获取符合[type=hidden]的<input>元素">
			<input type="button" id="bt9" value="获取<button>元素和符合[type=button]的<input>元素">
			<input type="button" id="bt10" value="获取符合[type=submit]的<input>元素">
			<input type="button" id="bt11" value="获取符合[type=reset]的<input>元素">
		</div>
		<br /><br />
		<form action="#">
		<table width="1000" align="center">
			<caption>用户注册</caption>
			<tr>
				<td width="300" align="right" height="30">用户名:</td>
				<td width="700">
					<input type="text">
					<input type="button" value="检查是否重名" />
				</td>
			</tr>
			<tr>
				<td width="300" align="right" height="30">密码:</td>
				<td width="700">
					<input type="password">
				</td>
			</tr>
			<tr>
				<td width="300" align="right" height="30">密码确认:</td>
				<td width="700">
					<input type="password">
				</td>
			</tr>
			<tr>
				<td width="300" align="right" height="30">照片:</td>
				<td width="700">
					<input type="file" />
					<input type="hidden" />
				</td>
			</tr>
			<tr>
				<td width="300" align="right" height="30">性别:</td>
				<td width="700">
					<input type="radio" name="sex"  value="男">男
					<input type="radio" name="sex"  value="女">女	
				</td>
			</tr>
			<tr>
				<td width="300" align="right" height="30">专业:</td>
				<td width="700">
					<select >
						<option value="">--请选择--</option>
						<option value="软件开发">软件开发</option>
						<option value="电子商务">电子商务</option>
						<option value="国际贸易">国际贸易</option>
						<option value="工商管理">工商管理</option>
						<option value="高级护理">高级护理</option>
					</select>
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
				</td>
			</tr>
			<tr>
				<td width="300" align="right" height="30">自我介绍:</td>
				<td width="700">
					<textarea rows="10" cols="60"></textarea>
				</td>
			</tr>
			<tr>
				<td width="300" align="right" height="30">&nbsp;</td>
				<td width="700">
					<input type="image" src="img/zc.jpg" />
					<input type="submit" value="注册" />
					<input type="reset" value="取消" />
				</td>
			</tr>
		</table>
		
		</form>	
	</body>
</html>
```

### （9）表单对象属性选择器

```
:enabled：匹配所有可用元素。
:disabled：匹配所有不可用元素。
:checked：匹配所有选中的被选中元素(复选框、单选框等，select中的option)，对于select元素来说，获取选中推荐使用:selected。
:selected：匹配所有选中的option元素。
```

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>表单对象属性选择器</title>
		<style type="text/css">
			div{line-height: 40px;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				//选取可用的表单元素
				$("#bt1").click(function(){
					$(":text:enabled").val("看我七十二变");
				})
				//选取不可用的表单元素
				$("#bt2").click(function(){
					$(":text:disabled").val("看我变变变变变");
				})
				//选取被选中的<input>元素(单选框和多选框)
				$("#bt3").click(function(){
					var str = "";
					str += "一共选中" + $("input:checked").length + "项\n";
					str += "性别:" + $("input:checked[name=sex]").val() + "\n";
					str += "爱好:";
					var strHobby ="";
					$("input:checked[name=hobby]").each(function(){
						if(strHobby.length != 0)
							strHobby += ",";
						strHobby += $(this).val();						
					})
					str += strHobby;
					str += "\n";
					alert(str);
				})
				//选取被选中的<option>元素(下拉框)
				$("#bt4").click(function(){
					var str = "";
					str += "一共选中" + $(":selected").length + "项\n";
					str += "专业:" + $("select[name=selProfessional] option:selected").val() + "\n";
					str += "地区:";
					var strArea ="";
					$("select[name=selArea] option:selected").each(function(){
						if(strArea.length != 0)
							strArea += ",";
						strArea += $(this).val();						
					})
					str += strArea;
					str += "\n";
					alert(str);
				})	
			})
		</script>
	</head>
	<body>
		<div>
			<input type="button" id="bt1" value="对可用文本框赋值">
			<input type="button" id="bt2" value="对不可用文本框赋值">
		</div>
		<div>
			可用元素:<input type="text"  />
			不可用元素:<input type="text" disabled="disabled"  />
			可用元素:<input type="text"  />
			不可用元素:<input type="text" disabled="disabled" />
		</div>
		<br /><br />
		<div>
			<input type="button" id="bt3" value="所有被选中的checked属性">
		</div>
		<div>
			性别:
			<input type="radio" name="sex"  value="男">男
			<input type="radio" name="sex"  value="女">女	
			&nbsp;&nbsp;&nbsp;&nbsp;爱好:
			<input type="checkbox" name="hobby" value="抽烟" />抽烟
			<input type="checkbox" name="hobby" value="喝酒" />喝酒
			<input type="checkbox" name="hobby" value="打游戏" />打游戏
			<input type="checkbox" name="hobby" value="烫头发" />烫头发
			<input type="checkbox" name="hobby" value="足球" />足球
			<input type="checkbox" name="hobby" value="篮球" />篮球
		</div>
		<br /><br />
		<div>
			<input type="button" id="bt4" value="被选中的option选项">
		</div>
		<div>
			专业:
			<select id="selProfessional" name="selProfessional">
				<option value="">--请选择--</option>
				<option value="软件开发">软件开发</option>
				<option value="电子商务">电子商务</option>
				<option value="国际贸易">国际贸易</option>
				<option value="工商管理">工商管理</option>
				<option value="高级护理">高级护理</option>
			</select>
			地区:
			<select id="selArea" name="selArea" multiple="multiple">
				<option value="">--请选择--</option>
				<option value="北京">北京</option>
				<option value="上海">上海</option>
				<option value="广州">广州</option>
				<option value="深圳">深圳</option>
				<option value="珠海">珠海</option>
			</select>
		</div>
	</body>
</html>
```

## 五、筛选

### （1）过滤筛选

```
is(expr|obj|ele|fn)：根据选择器、DOM元素或 jQuery 对象来检测匹配元素集合，如果其中至少有一个元素符合这个给定的表达式就返回true。

has(expr|ele)：保留包含特定后代的元素，去掉那些不含有指定后代的元素。

hasClass(calss)：检查当前的元素是否含有某个特定的类，如果有，则返回true。

eq(index|-index)：获取当前链式操作中第N个jQuery对象，返回jQuery对象，当参数大于等于0时为正向选取，比如0代表第一个，1代表第二个。当参数为负数时为反向选取，比如-1为倒数第一个。

filter(expr|obj|ele|fn)：筛选出与指定表达式匹配的元素集合。

slice(start,[end])：选取一个匹配的子集。
```

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>过滤筛选</title>
		<style type="text/css">
			div{margin: 0px; padding: 0px; height: auto; overflow: auto; text-align: center;}
			.team{clear: both; border: solid 1px black; background-color: pink;}
			.liubei,.caocao,.sunquan{ width: 250px; height: 100px; margin: 20px; float: left;
			border: solid 1px black; line-height: 30px; background-color: pink;}
			#myButtons{line-height: 30px;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				//判断id为guanyu的title是否也为guanyu
				$("#bt1").click(function(){
					//直接使用选择器
//					if($("#guanyu[title=guanyu]").length > 0)
//						alert("是");
//					else
//						alert("否");
					//使用is方法
					if($("#guanyu").is("[title=guanyu]"))
						alert("是");
					else
						alert("否");
				})
				//判断id为lbUl的子元素div中有没有class叫caocao
				$("#bt2").click(function(){
					//直接使用选择器
//					if($("#lbUl>div.caocao").length > 0)
//						alert("是");
//					else
//						alert("否");
					//使用is方法
//					if($("#lbUl>div").is(".caocao"))
//						alert("是");
//					else
//						alert("否");
					//使用hasClass方法
					if($("#lbUl>div").hasClass("caocao"))
						alert("是");
					else
						alert("否");
				})
				//获取子元素中有类名为caocao的div父元素
				$("#bt3").click(function(){
					$("*").removeAttr("style");
					//使用选择器来实现
					//$("div:has(.caocao)").css("backgroundColor","green");
					//使用has方法来实现
					$("div").has(".caocao").css("backgroundColor","green");
				})
				//获取第3个类名为caocao的div元素
				$("#bt4").click(function(){
					$("*").removeAttr("style");
					//使用选择器来实现
					//$("div.caocao:eq(2)").css("backgroundColor","green");
					//使用eq方法来实现
					$("div.caocao").eq(2).css("backgroundColor","green");
				})
				//获取div元素中文本有张飞、典韦、太史慈的元素
				$("#bt5").click(function(){
					$("*").removeAttr("style");
					//使用选择器来实现
					//$("div:contains('张飞'),div:contains('典韦'),div:contains('太史慈')").css("backgroundColor","green");
					//使用filter方法来实现
					$("div").filter(":contains(张飞),:contains(典韦),:contains(太史慈)").css("backgroundColor","green");
				})
				//获取div元素中文本有张飞、典韦、太史慈的div元素(只包括上一级div,不包括更上级div)
				$("#bt6").click(function(){
					$("*").removeAttr("style");
					//使用选择器来实现
					//$("div:contains('张飞'):not(.team),div:contains('典韦'):not(.team),div:contains('太史慈'):not(.team)").css("backgroundColor","green");
					//使用filter方法来实现
					$("div").filter(":contains(张飞),:contains(典韦),:contains(太史慈)").not(".team").css("backgroundColor","green");
				})				
				//获取class为team的div元素中子元素div的第1个
				$("#bt7").click(function(){
					$("*").removeAttr("style");
					//使用选择器来实现
					//$("div.team>:first-child").css("backgroundColor","green");
					//使用filter方法来实现
					$("div.team>*").filter(":first-child").css("backgroundColor","green");
				})
				//获取所有div的class为caocao的元素中的第2到4个
				$("#bt8").click(function(){
					$("*").removeAttr("style");
					//使用选择器来实现
					//$("div.caocao:gt(0):lt(3)").css("backgroundColor","green");
					//使用slice方法来实现
					$("div.caocao").slice(1,4).css("backgroundColor","green"); //包含1,不包含3
				})
				
			})
		</script>
	</head>
	<body>
		<div id="myButtons">
			<input type="button" id="bt1" value="判断id为guanyu的title是否也为guanyu">
			<input type="button" id="bt2" value="判断id为lbUl的子元素div中有没有class叫caocao">
			<input type="button" id="bt3" value="获取子元素中有类名为caocao的div父元素">
			<input type="button" id="bt4" value="获取第3个类名为caocao的div元素">
			<input type="button" id="bt5" value="获取div元素中文本有张飞、典韦、太史慈的div元素">	
			<input type="button" id="bt6" value="获取div元素中文本有张飞、典韦、太史慈的div元素(只包括上一级div,不包括更上级div)">
			<input type="button" id="bt7" value="获取class为team的div元素中子元素div的第1个">
			<input type="button" id="bt8" value="获取所有div的class为caocao的元素中的第2到4个">
		</div>
		<h2>刘备军团(h2标签)</h2>
			<div id="lbUl" class="team">
				<div id="guanyu" class="liubei" title="guanyu">关羽<br>(id=guanyu,class=liubei)</div>
				<div id="zhangfei" class="liubei">张飞<br>(id=zhangfei,class=liubei)</div>
				<div id="zhaoyun" class="liubei">赵云<br>(id=zhaoyun,class=liubei)</div>
				<div id="machao" class="liubei">马超<br>(id=machao,class=liubei)</div>
			</div>
		<h2>曹操军团(h2标签)</h2>
			<div id="ccUl" class="team">
				<div id="dianwei" class="caocao">典韦<br>(id=dianwei,class=caocao)</div>
				<div id="caopi" class="caocao">曹丕<br>(id=caopi,class=caocao)</div>
				<div id="caozhi" class="caocao">曹植<br>(id=caozhi,class=caocao)</div>
				<div id="caoren" class="caocao">曹仁<br>(id=caoren,class=caocao)</div>
				<div id="xiahou" class="caocao">夏侯敦<br>(id=caoren,class=caocao)</div>
			</div>
		<h2>孙权军团(h2标签)</h2>
			<div id="ccUl" class="team">
				<div id="huanggai" class="sunquan">黄盖<br>(id=huanggai,class=sunquan)</div>
				<div id="zhouyu" class="sunquan">周瑜<br>(id=zhouyu,class=sunquan)</div>
				<div id="lusu" class="sunquan">鲁肃<br>(id=lusu,class=sunquan)</div>
				<div id="taishici" class="sunquan">太史慈<br>(id=taishici,class=sunquan)</div>			
			</div>			
	</body>
</html>
```

### （2）查找筛选

```
find(expr|obj|ele):搜索所有与指定表达式匹配的元素。这个函数是找出正在处理的元素的后代元素的好方法。

children([expr]):取得一个包含匹配的元素集合中每一个元素的所有子元素的元素集合。

parent([expr])：取得一个包含着所有匹配元素的唯一父元素的元素集合。

parents([expr])：取得一个包含着所有匹配元素的祖先元素的元素集合（不包含根元素）。可以通过一个可选的表达式进行筛选。

next([expr]):取得一个包含匹配的元素集合中每一个元素紧邻的后面同辈元素的元素集合。

nextAll([expr]):查找当前元素之后所有的同辈元素。

prev([expr]):取得一个包含匹配的元素集合中每一个元素紧邻的前一个同辈元素的元素集合。

prevAll([expr]):查找当前元素之前所有的同辈元素。

siblings([expr]):取得一个包含匹配的元素集合中每一个元素的所有唯一同辈元素的元素集合。可以用可选的表达式进行筛选。

addBack():加入先前所选的加入当前元素中。
```

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>查找筛选</title>
		<style type="text/css">
			div{margin: 0px; padding: 0px; height: auto; overflow: auto; text-align: center;}
			.team{clear: both; border: solid 1px black; background-color: pink;}
			.liubei,.caocao,.sunquan{ width: 250px; height: 100px; margin: 20px; float: left;
			border: solid 1px black; line-height: 30px; background-color: pink;}
			#myButtons{line-height: 30px;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				//从body的子div查找他所有的后代div中class为team的子元素
				$("#bt1").click(function(){
					$("*").removeAttr("style");
					//使用选择器来实现
					//$("body div.caocao").css("backgroundColor","green"); //找得到
					//$("body>div.caocao").css("backgroundColor","green"); //找不到
					//使用find方法来实现
					$("body").find("div.caocao").css("backgroundColor","green"); //找得到
					//使用children方法来实现
					//$("body").children("div.caocao").css("backgroundColor","green"); //找不到
				})
				//从body中查找他所有的子元素div中class为team的子元素
				$("#bt2").click(function(){
					$("*").removeAttr("style");
					//使用选择器来实现
					//$("body>div.team").css("backgroundColor","green"); 
					$("body").children("div.team").css("backgroundColor","green");
				})
				//查找id为zhaoyun的div元素的唯一父元素
				$("#bt3").click(function(){
					$("*").removeAttr("style");
					$("div#zhaoyun").parent().css("backgroundColor","green");
				})				
				//查找class为caocao的div元素的父元素
				$("#bt4").click(function(){
					$("*").removeAttr("style");
					$("div.caocao").parent().css("backgroundColor","green");
				})
				//查找id为zhaoyun的div元素的祖先元素
				$("#bt5").click(function(){
					$("*").removeAttr("style");
					$("div#zhaoyun").parents().css("backgroundColor","green");
				})
				//查找id为dianwei的后一个同辈元素
				$("#bt6").click(function(){
					$("*").removeAttr("style");
					$("div#dianwei").next().css("backgroundColor","green");
				})
				//查找id为dianwei的后面所有同辈元素
				$("#bt7").click(function(){
					$("*").removeAttr("style");
					$("div#dianwei").nextAll().css("backgroundColor","green");
				})
				//查找id为dianwei的后面所有同辈div元素
				$("#bt8").click(function(){
					$("*").removeAttr("style");
					$("div#dianwei").nextAll("div").css("backgroundColor","green");
				})
				//查找id为machao的上一个同辈元素
				$("#bt9").click(function(){
					$("*").removeAttr("style");
					$("div#machao").prev().css("backgroundColor","green");
				})				
				//查找id为machao的前面所有同辈元素
				$("#bt10").click(function(){
					$("*").removeAttr("style");
					$("div#machao").prevAll().css("backgroundColor","green");
				})
				//查找id为zhangfei的所有同辈元素
				$("#bt11").click(function(){
					$("*").removeAttr("style");
					$("div#zhangfei").siblings().css("backgroundColor","green");
				})				
				//查找id为zhangfei的所有同辈元素(包括自己)
				$("#bt12").click(function(){
					$("*").removeAttr("style");
					$("div#zhangfei").siblings().addBack().css("backgroundColor","green");
				})				
			})
		</script>
	</head>
	<body>
		<div id="myButtons">
			<input type="button" id="bt1" value="从body中查找他所有的后代div中class为caocao的子元素">
			<input type="button" id="bt2" value="从body中查找他所有的子元素div中class为team的子元素">
			<input type="button" id="bt3" value="查找id为zhaoyun的div元素的父元素">
			<input type="button" id="bt4" value="查找class为caocao的div元素的父元素">
			<input type="button" id="bt5" value="查找id为zhaoyun的div元素的祖先元素">
			<input type="button" id="bt6" value="查找id为dianwei的后一个同辈元素">
			<input type="button" id="bt7" value="查找id为dianwei的后面所有同辈元素">
			<input type="button" id="bt8" value="查找id为dianwei的后面所有同辈div元素">
			<input type="button" id="bt9" value="查找id为machao的上一个同辈元素">
			<input type="button" id="bt10" value="查找id为machao的前面所有同辈元素">
			<input type="button" id="bt11" value="查找id为zhangfei的所有同辈元素">
			<input type="button" id="bt12" value="查找id为zhangfei的所有同辈元素(包括自己)">
		</div>
		<h2>刘备军团(h2标签)</h2>
			<div id="lbUl" class="team">
				<div id="guanyu" class="liubei" title="guanyu">关羽<br>(id=guanyu,class=liubei)</div>
				<div id="zhangfei" class="liubei">张飞<br>(id=zhangfei,class=liubei)</div>
				<div id="zhaoyun" class="liubei">赵云<br>(id=zhaoyun,class=liubei)</div>
				<div id="machao" class="liubei">马超<br>(id=machao,class=liubei)</div>
			</div>
		<h2>曹操军团(h2标签)</h2>
			<div id="ccUl" class="team">
				<div id="dianwei" class="caocao">典韦<br>(id=dianwei,class=caocao)</div>
				<div id="caopi" class="caocao">曹丕<br>(id=caopi,class=caocao)</div>
				<div id="caozhi" class="caocao">曹植<br>(id=caozhi,class=caocao)</div>
				<div id="caoren" class="caocao">曹仁<br>(id=caoren,class=caocao)</div>
				<span>我是Span标签的内容</span>
			</div>
		<h2>孙权军团(h2标签)</h2>
			<div id="ccUl" class="team">
				<div id="huanggai" class="sunquan">黄盖<br>(id=huanggai,class=sunquan)</div>
				<div id="zhouyu" class="sunquan">周瑜<br>(id=zhouyu,class=sunquan)</div>
				<div id="lusu" class="sunquan">鲁肃<br>(id=lusu,class=sunquan)</div>
				<div id="taishici" class="sunquan">太史慈<br>(id=taishici,class=sunquan)</div>			
			</div>			
	</body>
</html>
```

### （3）制作广告索引切换效果

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>广告索引切换</title>
		<style type="text/css">
			#adIndex{ width: 300px; text-align: right; height: 40px;}
			#adIndex li
			{
				list-style-type: none; 
				width: 22px; height: 22px; line-height: 22px;
				float: left; margin: 6px 6px 0px 0px;
				background-color: #FFC0CB; color: white;
				text-align: center;
			}
			#adIndex li.current
			{
				list-style-type: none; 
				width: 26px; height: 26px; line-height: 26px;
				float: left; margin: 4px 6px 0px 0px;
				background-color:#FF0000; color: white; font-weight: bold;
				text-align: center;
			}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			var currentIndex = 0;  //广告切换的当前索引
			function SetMyAdsenseIndex()
			{	
				var $allIndexs = $("#adIndex ul li"); //保存所有的li标签集合
				$allIndexs.eq(currentIndex).addClass("current"); //设置自己是高亮显示
				$allIndexs.eq(currentIndex).siblings().removeClass("current");  //将自己的同级标签去掉高亮样式
				currentIndex++;
				if(currentIndex >= $allIndexs.length)
					currentIndex = 0;
				
			}
			$(function(){
				SetMyAdsenseIndex();	
				setInterval("SetMyAdsenseIndex()",3000);
			});

			
		</script>
	</head>
	<body>
		<div id="adIndex">
			<ul>
				<li>1</li>
				<li>2</li>
				<li>3</li>
				<li>4</li>
				<li>5</li>
				<li>6</li>
			</ul>
		</div>
	</body>
</html>
```

