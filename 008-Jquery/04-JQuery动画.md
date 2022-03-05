# JQuery动画

## 一、show、hide、toggle和toggleClass

实现图片显示隐藏：

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="utf-8" />
		<title>show()方法与hide()方法</title>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				$("#myButton").click(function(){
					//方案一：
					if($(this).val() == "显示")
					{
						$("#myImg").show(2000,function(){
							$(this).css("border","1px solid gray");
							$(this).css("padding","3px");
						})
						$(this).val("隐藏");
					}
					else
					{
						$("#myImg").hide(2000);
						$(this).val("显示");					
					}
					//方案二：
					// $("#myImg").toggle(2000,function(){
					// 	$(this).css("border","1px solid gray");
					// 	$(this).css("padding","3px");
					// 	if($("#myButton").val() == "显示")
					// 		$("#myButton").val("隐藏");
					// 	else
					// 		$("#myButton").val("显示");
					// })
				})				
			})
		</script>
	</head>
	<body>
		<img id="myImg" src="img/two.jpg" style="display: none;"  /><br/>
		<input id="myButton" type="button" value="显示"  />
	</body>
</html>
```

实现导航菜单项的显示隐藏：

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>toggle()方法进行显示隐藏</title>
		<style type="text/css">
			* {
				margin: 0px;
				padding: 0px;
			}
			body {
				font-size: 12px;
			}
			div#menu{
				margin:30px;
				width: 100px;			
			}
			ul {
				list-style: none;
			}
			ul li {
				height: 30px;
				line-height: 30px;
				text-align:center;
				border: 1px solid #93D6C5;
				border-bottom: none;
			}
			ul li a{
				text-decoration:none;
			}
			ul li.title {
				background-color: #F90;
			}
			ul li.lastItem{
				background-image:url(img/up.jpg);
				background-position:center top;
				background-repeat:no-repeat;
				cursor:pointer;
				border:none;
				border-top:1px solid #93D6C5;
			}
			ul li.down{
				background-image:url(img/down.jpg);
			}			
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				$("#menu li.lastItem").click(function(){
					$("#menu li:gt(5):not(:last)").toggle();
					$(this).toggleClass("down");
				})				
			})

		</script>		
	</head>
	<body>
		<div id="menu">
		  <ul>
		    <li class="title">商品服务分类</li>
		    <li><a href="#">鞋包配饰</a></li>
		    <li><a href="#">运动户外</a></li>
		    <li><a href="#">珠宝手表</a></li>
		    <li><a href="#">手机数码</a></li>
		    <li><a href="#">家电办公</a></li>
		    <li><a href="#">护肤彩妆</a></li>
		    <li><a href="#">母婴用品</a></li>
		    <li><a href="#">家纺居家</a></li>
		    <li class="lastItem"></li>
		  </ul>
		</div>

	</body>
</html>
```

## 二、fadeIn、fadeOut、fadeToggle、fadeTo

我们可以使用fadeIn、fadeOut、fadeToggle、fadeTo利用透明度的变化制作淡入淡出效果。

实现图片淡入淡出显示隐藏：

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>fadeIn()方法与fadeOut()方法</title>
		<!--fadeIn:实现淡入的动画效果，最终显示当前元素-->
		<!--fadeOut:实现淡出的动画效果，最终隐藏当前元素-->
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				$("#myButton").click(function(){
					//方案一：
					// if($(this).val() == "显示")
					// {
					// 	$("#myImg").fadeIn(2000,function(){
					// 		$(this).css("border","1px solid gray");
					// 		$(this).css("padding","3px");
					// 	})
					// 	$(this).val("隐藏");
					// }
					// else
					// {
					// 	$("#myImg").fadeOut(2000);
					// 	$(this).val("显示");					
					// }
					//方案二：
					$("#myImg").fadeToggle(2000,function(){
						$(this).css("border","1px solid gray");
						$(this).css("padding","3px");
						if($("#myButton").val() == "显示")
							$("#myButton").val("隐藏");
						else
							$("#myButton").val("显示");
					})
				})				
			})
		</script>
	</head>
	<body>
		<img id="myImg" src="img/two.jpg" style="display: none;"  /><br/>
		<input id="myButton" type="button" value="显示"  />
	</body>
</html>
```

实现导航菜单项淡入淡出的显示隐藏：

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>fadeToggle()方法</title>
		<!--fadeToggle()会动态地改变当前元素的透明度，最终切换当前元素的可见状态。
		即如果元素是可见的，则通过淡出效果切换为隐藏状态；如果元素是隐藏的，则通过淡入效果切换为可见状态-->
		<style type="text/css">
			* {
				margin: 0px;
				padding: 0px;
			}
			body {
				font-size: 12px;
			}
			div#menu{
				margin:30px;
				width: 100px;			
			}
			ul {
				list-style: none;
			}
			ul li {
				height: 30px;
				line-height: 30px;
				text-align:center;
				border: 1px solid #93D6C5;
				border-bottom: none;
			}
			ul li a{
				text-decoration:none;
			}
			ul li.title {
				background-color: #F90;
			}
			ul li.lastItem{
				background-image:url(img/up.jpg);
				background-position:center top;
				background-repeat:no-repeat;
				cursor:pointer;
				border:none;
				border-top:1px solid #93D6C5;
			}
			ul li.down{
				background-image:url(img/down.jpg);
			}			
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				$("#menu li.lastItem").click(function(){
					$("#menu li:gt(5):not(:last)").fadeToggle(2000);
					$(this).toggleClass("down");
				})				
			})

		</script>		
	</head>
	<body>
		<div id="menu">
		  <ul>
		    <li class="title">商品服务分类</li>
		    <li><a href="#">鞋包配饰</a></li>
		    <li><a href="#">运动户外</a></li>
		    <li><a href="#">珠宝手表</a></li>
		    <li><a href="#">手机数码</a></li>
		    <li><a href="#">家电办公</a></li>
		    <li><a href="#">护肤彩妆</a></li>
		    <li><a href="#">母婴用品</a></li>
		    <li><a href="#">家纺居家</a></li>
		    <li class="lastItem"></li>
		  </ul>
		</div>
	</body>
</html>
```

将图片调整到指定的透明度：

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>fadeTo()方法调整透明度</title>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				$("#mySel").change(function(){
					$("#myImg").fadeTo(2000,$(this).val());
				})				
			})
		</script>
	</head>
	<body>
		<img id="myImg" src="img/two.jpg"  /><br/>
		<select id="mySel">
			<option value="1">1</option>
			<option value="0.8">0.8</option>
			<option value="0.6">0.6</option>
			<option value="0.4">0.4</option>
			<option value="0.2">0.2</option>
			<option value="0">0</option>
		</select>
	</body>
</html>
```

## 三、slideDown、slideUp和slideToggle

扩展事件细节：

mouseover:无论鼠标指针穿过被选元素或其子元素，都会触发。

mouseenter:只有在鼠标指针穿过被选元素的时候才会触发。

mouseout:无论鼠标指针离开被选元素或其子元素，都会触发。

mouseleave:只有在鼠标指针离开被选元素的时候才会触发。

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="utf-8">
		<title>鼠标事件扩展</title>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				//mouseover:无论鼠标指针穿过被选元素或其子元素，都会触发。
				//mouseenter:只有在鼠标指针穿过被选元素的时候才会触发。
				//mouseout:无论鼠标指针离开被选元素或其子元素，都会触发。
				//mouseleave:只有在鼠标指针离开被选元素的时候才会触发。
				
				//鼠标在里面的单元格移动也会触发事件
				// $("table").mouseover(function(){
				// 	alert("mouseover");
				// });
				//只有鼠标移动到表格里面才会触发
				// $("table").mouseenter(function(){
				// 	alert("mouseenter");
				// });
				//鼠标在里面的单元格移动也会触发事件
				// $("table").mouseout(function(){
				// 	alert("mouseout");
				// });
				//只有鼠标离开表格的时候才会触发
				$("table").mouseleave(function(){
					alert("mouseleave");
				});
			});
		</script>
	</head>
	<body>
		<table width="1000" align="center" border="1">
			<tr height="50">
				<td>1</td>
				<td>2</td>
				<td>3</td>
				<td>4</td>
			</tr>
			<tr height="50">
				<td>1</td>
				<td>2</td>
				<td>3</td>
				<td>4</td>
			</tr>
		</table>
	</body>
</html>
```

制作横向导航二级菜单：

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>slideDown()方法与slideUp()方法</title>
		<style type="text/css">
			*{margin: 0px; padding: 0px;}
			#head{ width: 100%; height: 70px; background-color:darkgray;}
			#head ul{ list-style-type: none;}
			#head li{height:auto; overflow: visible; line-height: 70px; text-align: center;}
			#head a{ padding: 0px 20px; text-decoration: none; 
			font-size: 16px; color: white; height: 70px; line-height: 70px;
			display: block;}
			
			#head>ul>li{ float: left;  position: relative;}
			#head>ul>li>ul{ position:absolute; display: none; background-color:darkgray; }
			.select{ background-color: gray; font-weight: bold;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				//mouseover:无论鼠标指针穿过被选元素或其子元素，都会触发。
				//mouseenter:只有在鼠标指针穿过被选元素的时候才会触发。
				//mouseout:无论鼠标指针离开被选元素或其子元素，都会触发。
				//mouseleave:只有在鼠标指针离开被选元素的时候才会触发。
				//先看Demo03_04.html搞清楚这几个事件的区别
				
				
				// $("#head>ul>li").mouseenter(function(){				
				// 	$(this).children("ul").slideDown(1000);
				// 	//$(this).children("ul").css("display","block");
				// })
				// $("#head>ul>li").mouseleave(function(){
				// 	$(this).children("ul").slideUp(1000);
				// 	//$(this).children("ul").css("display","none");
				// })
				
				$("#head>ul>li").hover(
					function(){
						$(this).children("ul").slideDown(1000);
					},
					function(){
						$(this).children("ul").slideUp(1000);
					}					
				)
				$("#head li").hover(
					function(){
						$(this).addClass("select");
					},
					function(){
						$(this).removeClass("select");
					}					
				)
			})
		</script>
	</head>
	<body>
		<div id="head">
		  <ul>
		    <li><a href="#">购物车</a></li>
		    <li><a href="#">我的当当</a>
		       <ul>
		          <li><a href="#">我的订单</a></li>
		          <li><a href="#">我的收藏</a></li>
		          <li><a href="#">我的余额</a></li>
		       </ul>
		    </li>
		    <li><a href="#">手机当当</a></li>
		    <li><a href="#">企业采购</a></li>
		    <li><a href="#">自助服务</a></li>
		  </ul>
		</div>
		<div><h1 style="text-align: center;">网页正文内容</h1></div>
	</body>
</html>
```

制作横向导航二级菜单（优化）：

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>slideDown()方法与slideUp()方法</title>
		<style type="text/css">
			*{margin: 0px; padding: 0px;}
			#head{ width: 100%; height: 70px; background-color:darkgray;}
			#head ul{ list-style-type: none;}
			#head li{height:auto; overflow: visible; line-height: 70px; text-align: center;}
			#head a{ padding: 0px 20px; text-decoration: none; 
			font-size: 16px; color: white; height: 70px; line-height: 70px;
			display: block;}
			
			#head>ul>li{ float: left;  position: relative;}
			#head>ul>li>ul{ position:absolute; display: none; background-color:darkgray; }
			.select{ background-color: gray; font-weight: bold;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				//以下代码当鼠标快速切换状态的时候,动画会执行多次
//				$("#head>ul>li").hover(
//					function(){
//						$(this).children("ul").slideDown(1000);
//					},
//					function(){
//						$(this).children("ul").slideUp(1000);
//					}					
//				)
				//可以加上stop实现先停止当前动画,然后在执行新的动画
				$("#head>ul>li").hover(
					function(){
						$(this).children("ul").stop().slideDown(1000);
					},
					function(){
						$(this).children("ul").stop().slideUp(1000);
					}					
				)
				$("#head li").hover(
					function(){
						$(this).addClass("select");
					},
					function(){
						$(this).removeClass("select");
					}					
				)
			})
		</script>
	</head>
	<body>
		<div id="head">
		  <ul>
		    <li><a href="#">购物车</a></li>
		    <li><a href="#">我的当当</a>
		       <ul>
		          <li><a href="#">我的订单</a></li>
		          <li><a href="#">我的收藏</a></li>
		          <li><a href="#">我的余额</a></li>
		       </ul>
		    </li>
		    <li><a href="#">手机当当</a></li>
		    <li><a href="#">企业采购</a></li>
		    <li><a href="#">自助服务</a></li>
		  </ul>
		</div>
		<div>aaaaaaaaaaaasaaaaaaaaaaaaaaa</div>
	</body>
</html>
```

slideToggle实现横向导航菜单：

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>slideToggle()方法</title>
		
		<style type="text/css">
			*{margin: 0px; padding: 0px;}
			#head{ width: 100%; height: 70px; background-color:darkgray;}
			#head ul{ list-style-type: none;}
			#head li{height:auto; overflow: visible; line-height: 70px; text-align: center;}
			#head a{ padding: 0px 20px; text-decoration: none; 
			font-size: 16px; color: white; height: 70px; line-height: 70px;
			display: block;}
			
			#head>ul>li{ float: left;  position: relative;}
			#head>ul>li>ul{ position:absolute; display: none; background-color:darkgray; }
			.select{ background-color: gray; font-weight: bold;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){

//				$("#head>ul>li").mouseenter(function(){				
//					$(this).children("ul").slideDown(1000);
//					//$(this).children("ul").css("display","block");
//				})
//				$("#head>ul>li").mouseleave(function(){
//					$(this).children("ul").slideUp(1000);
//					//$(this).children("ul").css("display","none");
//				})
				
				$("#head>ul>li").hover(
					function(){
						$(this).children("ul").stop().slideToggle(1000);
					}					
				)
				$("#head li").hover(
					function(){
						$(this).toggleClass("select");
					}					
				)
			})
		</script>
	</head>
	<body>
		<div id="head">
		  <ul>
		    <li><a href="#">购物车</a></li>
		    <li><a href="#">我的当当</a>
		       <ul>
		          <li><a href="#">我的订单</a></li>
		          <li><a href="#">我的收藏</a></li>
		          <li><a href="#">我的余额</a></li>
		       </ul>
		    </li>
		    <li><a href="#">手机当当</a></li>
		    <li><a href="#">企业采购</a></li>
		    <li><a href="#">自助服务</a></li>
		  </ul>
		</div>
		<div><h1 style="text-align: center;">网页正文内容</h1></div>
	</body>
</html>
```

## 四、animate()自定义动画

变大和移动：

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>animate()自定义动画</title>
		<style type="text/css">
			#myImg{position: relative;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				$("#myButton").click(function(){
					$("#myImg").animate({
						"width":"400px",
						"left":"300px",
						"top":"100px"
					},2000)
				})
			})
		</script>		
	</head>
	<body>
		<input id="myButton" type="button" value="变大和移动"  /><br/><br/>
		<img id="myImg" src="img/two.jpg" width="200" />	
	</body>
</html>
```

变大移动后改变透明度：

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>animate()自定义动画-队列中的动画</title>
		<style type="text/css">
			#myImg{position: relative;}
		</style>
		<!--$(this).css("transform","rotate(" + $rnd + "deg)");-->
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				$("#myButton").click(function(){
					$("#myImg").animate({
						"width":"400px",
						"left":"300px",
						"top":"100px"
					},2000)
					.animate({"opacity":"0.3"},2000)
					.animate({"opacity":"1"},3000)
				})
			})
		</script>		
	</head>
	<body>
		<input id="myButton" type="button" value="变大和移动"  /><br/><br/>
		<img id="myImg" src="img/two.jpg" width="200" />	
	</body>
</html>
```

## 五、scrollLeft或scrollTop滚动HTML内容

图片滚动效果一：

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>scrollLeft或scrollTop滚动HTML内容</title>
		<style type="text/css">
			*{margin: 0px; padding: 0px;}
			#divBox{ margin: 30px; border: 2px solid deeppink;
			width: 390px; height: 130px; overflow: hidden;}
			/*12张图片总长度1560*/
			#divPics{ width: 1560px;} 
			#divPics img{ width: 130px; height: 130px; float: left;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				var imgWidth=130;
				var moveJuli = 1;  //每次移动距离
				var count = 1; //移动次数计算
				setInterval(function(){
					$("#divBox").scrollLeft(count*moveJuli);
					//当图片滑动到最后的123的时候自动切换成最前面的123（1560-130*3）
					if($("#divBox").scrollLeft() >= 1170)
						count = 0;
					count++;
				},10);
			})
		</script>		
	</head>
	<body>
		
		<h1>滚动图片</h1>
		<div id="divBox">
		    <div id="divPics">
		        <img src="img/1.jpg" width="130" height="130"/>
		        <img src="img/2.jpg" width="130" height="130"/>
		        <img src="img/3.jpg" width="130" height="130"/>
		        <img src="img/4.jpg" width="130" height="130"/>
		        <img src="img/5.jpg" width="130" height="130"/>
		        <img src="img/6.jpg" width="130" height="130"/>
		        <img src="img/7.jpg" width="130" height="130"/>
		        <img src="img/8.jpg" width="130" height="130"/>
		        <img src="img/9.jpg" width="130" height="130"/>
		        <img src="img/1.jpg" width="130" height="130"/>
		        <img src="img/2.jpg" width="130" height="130"/>
		        <img src="img/3.jpg" width="130" height="130"/>
		    </div>
	    </div>
	</body>
</html>
```

图片滚动效果二：

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>scrollLeft或scrollTop滚动HTML内容</title>
		<style type="text/css">
			*{margin: 0px; padding: 0px;}
			#divBox{ margin: 30px; border: 2px solid deeppink;
			width: 390px; height: 130px; overflow: hidden;}
			/*12张图片总长度1560*/
			#divPics{ width: 1560px;} 
			#divPics img{ width: 130px; height: 130px; float: left;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			var imgWidth=130;
			var moveStep = 10; //移动时间间隔
			var moveJuli = 1;  //每次移动距离
			var count = 1; //移动次数计算
			function ImgScroll()
			{
				moveStep = 10; //设置间隔时间为10毫秒
				$("#divBox").scrollLeft(count*moveJuli);
				if($("#divBox").scrollLeft() % imgWidth == 0)
					moveStep = 2000;
				//当图片滑动到最后的123的时候自动切换成最前面的123（1560-130*3）
				if($("#divBox").scrollLeft() >= 1170)
					count = 0;
				count++;
				setTimeout("ImgScroll()",moveStep);
			}
			$(function(){
				ImgScroll();
			})
		</script>		
	</head>
	<body>	
		<h1>滚动图片</h1>
		<div id="divBox">
		    <div id="divPics">
		        <img src="img/1.jpg" width="130" height="130"/>
		        <img src="img/2.jpg" width="130" height="130"/>
		        <img src="img/3.jpg" width="130" height="130"/>
		        <img src="img/4.jpg" width="130" height="130"/>
		        <img src="img/5.jpg" width="130" height="130"/>
		        <img src="img/6.jpg" width="130" height="130"/>
		        <img src="img/7.jpg" width="130" height="130"/>
		        <img src="img/8.jpg" width="130" height="130"/>
		        <img src="img/9.jpg" width="130" height="130"/>
		        <img src="img/1.jpg" width="130" height="130"/>
		        <img src="img/2.jpg" width="130" height="130"/>
		        <img src="img/3.jpg" width="130" height="130"/>
		    </div>
	    </div>
	</body>
</html>
```

## 六、图片轮播效果

利用滑动的效果轮播4幅图片：

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>利用滑动的效果轮播4幅图片</title>
		<style type="text/css">
        * {margin:0px;padding:0px;}
        #main ul {list-style: none;}
		#main { margin:20px;width:500px; height:300px; overflow: hidden; position:relative;}
		#imgarea li{width:500px; height:300px;}
		#imgarea img{ border:none;}
		#imgID{position: absolute; right: 5px; bottom: 5px;}
		#imgID li{float: left; width: 16px; height: 16px; text-align: center; line-height: 16px;
		background-color: #fff;border: 1px solid #069;color: #069;cursor: pointer; margin: 2px;}
	   	#imgID li.active{color: #fff;line-height: 16px;width: 16px;height: 16px;font-size: 14px;
		border: 1px solid #069; background-color: #069; font-weight: bold;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">			
			$(function(){
				var $index = 1; //当前播放图片的索引
				var $stop = false; //标识是否是手动播放，默认false表示自动播放
				var $pagesLis = $("#main").find("#imgID li");//保存组织编号的li

                var $mainDivh = $("div#main").height();  //获取div的高度
                setInterval(function () { //自动播放
	               	if ($stop) 
						return;
	               	$("ul#imgarea").stop(true, true); //清空动画序列，立即完成正在执行的动画   
					$("ul#imgarea").animate({"marginTop":-$mainDivh*$index},1000);
					$pagesLis.eq($index)
						.addClass("active")
						.siblings()
						.removeClass("active");
					$index++;
					if ($index >= $pagesLis.length) 
					{
					   $index = 0;//从头播放
					}
           		}, 3000);
           		
	           	$pagesLis.mouseover(function () { //控制手动播放
               		$stop = true; //自动轮播结束
               		$index = $pagesLis.index($(this)); ///光标移入的编号
               		$("ul#imgarea").stop(true, true) //清空动画序列，立即完成正在执行的动画
                	.animate({ "marginTop": -$mainDivh * $index }, 1000);
               		$(this).addClass("active")
                      .siblings()
                      .removeClass("active");
       			})
	           	$pagesLis.mouseout(function(){
	           		$stop = false;
	           	})
	           	
			})
		</script>		
	
	</head>
	<body>
	  <div id="main" >
	    <ul id="imgarea" >
	      <li><a href="#"><img src="img/list1.jpg"  width="500" height="300"/></a></li>
	      <li><a href="#"><img src="img/list2.jpg"  width="500" height="300"/></a></li>
	      <li><a href="#"><img src="img/list3.jpg"  width="500" height="300"/></a></li>
	      <li><a href="#"><img src="img/list4.jpg"  width="500" height="300"/></a></li>
	    </ul>
	    <ul id="imgID" >
	      <li class="active">1</li>
	      <li>2</li>
	      <li>3</li>
		  <li>4</li>
	    </ul>
	  </div>
		
	</body>
</html>
```

利用滑动的效果轮播4幅图片-无缝循环：

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>利用滑动的效果轮播4幅图片-无缝循环</title>
		<style type="text/css">
        * {margin:0px;padding:0px;}
        #main ul {list-style: none;}
		#main { margin:20px;width:500px; height:300px; overflow: hidden; position:relative;}
		#imgarea li{width:500px; height:300px;}
		#imgarea img{ border:none;}
		#imgID{position: absolute; right: 5px; bottom: 5px;}
		#imgID li{float: left; width: 16px; height: 16px; text-align: center; line-height: 16px;
		background-color: #fff;border: 1px solid #069;color: #069;cursor: pointer; margin: 2px;}
	   	#imgID li.active{color: #fff;line-height: 16px;width: 16px;height: 16px;font-size: 14px;
		border: 1px solid #069; background-color: #069; font-weight: bold;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">			
			$(function(){
				var $index = 1; //当前数字索引
				var $imgIndex = 1; //当前图片索引
				var $imgLen = $("#main").find("#imgarea li").length;  //图片数量
				var $stop = false; //标识是否是手动播放，默认false表示自动播放
				var $pagesLis = $("#main").find("#imgID li");//保存组织编号的li

                var $mainDivh = $("div#main").height();  //获取div的高度
                setInterval(function () { //自动播放
	               	if ($stop) 
						return;
	               	$("ul#imgarea").stop(true, true); //清空动画序列，立即完成正在执行的动画   
					$("ul#imgarea").animate({"marginTop":-$mainDivh*$imgIndex},1000);
					//如果动画为4-1,则马上变化成1的初始状态
					if($imgIndex == $imgLen-1)
					{
						$("ul#imgarea").animate({"marginTop":0},0);
						$imgIndex = 0;
					}
						
					$pagesLis.eq($index)
						.addClass("active")
						.siblings()
						.removeClass("active");
					$index++;
					if ($index >= $pagesLis.length) 
					   $index = 0;//从头播放
					$imgIndex++;
           		}, 3000);
           		
	           	$pagesLis.mouseover(function () { //控制手动播放
               		$stop = true; //自动轮播结束
               		$index = $pagesLis.index($(this)); //光标移入的编号
					$imgIndex = $index;
               		$("ul#imgarea").stop(true, true); //清空动画序列，立即完成正在执行的动画
					//鼠标选中1，则0秒切换到4，1秒切换5，0秒切换1
					if($imgIndex == 0)
					{
						$("ul#imgarea").animate({"marginTop":-$mainDivh * ($imgLen-2)},0);
						$("ul#imgarea").animate({"marginTop": -$mainDivh * ($imgLen-1)}, 1000);
						$("ul#imgarea").animate({"marginTop":0},0);
					}
					else//鼠标选中不是1，则0秒切换上一张，1秒切换到鼠标选中
					{
						$("ul#imgarea").animate({"marginTop":-$mainDivh * ($imgIndex-1)},0);
						$("ul#imgarea").animate({"marginTop": -$mainDivh * $imgIndex }, 1000);						
					}

               		$(this).addClass("active")
                      .siblings()
                      .removeClass("active");
       			})
	           	$pagesLis.mouseout(function(){
	           		$stop = false;
	           	})
			})
		</script>		
	
	</head>
	<body>
	  <div id="main" >
	    <ul id="imgarea" >
	      <li><a href="#"><img src="img/list1.jpg"  width="500" height="300"/></a></li>
	      <li><a href="#"><img src="img/list2.jpg"  width="500" height="300"/></a></li>
	      <li><a href="#"><img src="img/list3.jpg"  width="500" height="300"/></a></li>
	      <li><a href="#"><img src="img/list4.jpg"  width="500" height="300"/></a></li>
		  <li><a href="#"><img src="img/list1.jpg"  width="500" height="300"/></a></li>
	    </ul>
	    <ul id="imgID" >
	      <li class="active">1</li>
	      <li>2</li>
	      <li>3</li>
		  <li>4</li>
	    </ul>
	  </div>	
	</body>
</html>
```

利用透明度的效果轮播4幅图片：

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>利用透明度的效果轮播4幅图片</title>
		<style type="text/css">
			*{ margin: 0px; padding: 0px; list-style-type: none;}
			#imgarea li{ font-size: 0px;}
			#main{ margin: 10px; width: 500px; height: 300px; overflow: hidden; 
			position: relative;}
			#imgID { position: absolute; right: 5px; bottom: 5px;}
			#imgID li{ float: left; width: 16px; height: 16px; line-height: 16px;
			text-align: center; font-size: 12px; background-color: white;
			border:solid 1px #0000FF; margin-left: 5px; cursor: pointer;}
			#imgID li.active{background-color: #0000FF; color: white;}
		</style>
		<script src="js/jquery.js"></script>
		<script>
			$(function(){
				var $index = 1;  //记录当前播放图片的索引（小图标的索引）
				var $imgHeight = $("#main").height();
				var $pageList = $("#imgID li");
				var $stop = false; //false:自动播放，true:手动播放
				setInterval(function(){
					if($stop == true)
						return;
					$("#imgarea").stop(true,true)
					.animate({"marginTop":-$index*$imgHeight},0)
					.animate({"opacity":0.3},0)
					.animate({"opacity":1},1000);
					$pageList.eq($index).addClass("active").siblings().removeClass("active");
					$index++;
					if($index >= $pageList.length)
						$index = 0;
				},3000);
				
				$pageList.mouseover(function(){
					$stop = true;
					$index = $pageList.index($(this));
					$("#imgarea").stop(true,true)
					.animate({"marginTop":-$index*$imgHeight},0)
					.animate({"opacity":0.3},0)
					.animate({"opacity":1},1000);
					$pageList.eq($index).addClass("active").siblings().removeClass("active");					
				})
				$pageList.mouseout(function(){
					$stop = false;
				});
				
			});
		</script>
	</head>
	<body>
	  <div id="main" >
	    <ul id="imgarea" >
	      <li><a href="#"><img src="img/list1.jpg"  width="500" height="300"/></a></li>
	      <li><a href="#"><img src="img/list2.jpg"  width="500" height="300"/></a></li>
	      <li><a href="#"><img src="img/list3.jpg"  width="500" height="300"/></a></li>
	      <li><a href="#"><img src="img/list4.jpg"  width="500" height="300"/></a></li>
	    </ul>
	    <ul id="imgID" >
	      <li class="active">1</li>
	      <li>2</li>
	      <li>3</li>
		  <li>4</li>
	    </ul>
	  </div>
	</body>
</html>
```

