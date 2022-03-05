# JQuery页面导航

## 一、普通二级下拉菜单

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="utf-8" />
		<title>普通下拉菜单</title>
		<style type="text/css">
			*{margin: 0px; padding: 0px;}
			#menu{ height: 35px; background-image: url(img/menubg.jpg);}
			#menu ul{ list-style-type: none;}
			#menu li{ height: 35px; line-height: 35px;}
			#menu a{ display: block; padding: 0px 30px; 
			text-decoration: none; font-size: 14px; font-weight: bold; color: black;}
			#menu>ul>li{float: left; position: relative;}
			#menu>ul>li>ul{ display: none; position: absolute; left: 0px; background-color:ghostwhite}
			#menu>ul>li>ul>li{ clear: both;}
			#content{ background-color: gainsboro; text-align: center; padding: 200px; 
			font-size:50px; font-weight: bold;}
			.lihover{background-color: gray; }
			.lihover a{color: white;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				$("#menu>ul>li").mouseover(function(){
					$(this).children("ul").stop().slideDown(300);
				})
				$("#menu>ul>li").mouseleave(function(){
					$(this).children("ul").stop().slideUp(300);
				})
				$("#menu>ul>li>ul>li").mouseover(function(){
					$(this).addClass("lihover");
				})
				$("#menu>ul>li>ul>li").mouseleave(function(){
					$(this).removeClass("lihover");
				})				
			})

		</script>
	</head>
	<body>
		<div id="menu">
			<ul>
				<li>
					<a href="javascript:void(0);">推荐分类</a>
					<ul>
						<li><a href="javascript:void(0);">英雄联盟</a></li>
						<li><a href="javascript:void(0);">王者荣耀</a></li>
						<li><a href="javascript:void(0);">绝地求生</a></li>
						<li><a href="javascript:void(0);">二次元</a></li>
					</ul>
				</li>
				<li>
					<a href="javascript:void(0);">游戏竞技</a>
					<ul>
						<li><a href="javascript:void(0);">英雄联盟</a></li>
						<li><a href="javascript:void(0);">绝地求生</a></li>
						<li><a href="javascript:void(0);">刺激战场</a></li>
						<li><a href="javascript:void(0);">QQ飞车</a></li>
						<li><a href="javascript:void(0);">怪物猎人</a></li>
						<li><a href="javascript:void(0);">炉石传说</a></li>
					</ul>
				</li>
				<li>
					<a href="javascript:void(0);">娱乐天地</a>
					<ul>
						<li><a href="javascript:void(0);">颜值</a></li>
						<li><a href="javascript:void(0);">星娱</a></li>
						<li><a href="javascript:void(0);">二次元</a></li>
						<li><a href="javascript:void(0);">户外</a></li>
						<li><a href="javascript:void(0);">音乐电台</a></li>
					</ul>				
				</li>
				<li>
					<a href="javascript:void(0);">科技教育</a>
					<ul>
						<li><a href="javascript:void(0);">鱼教</a></li>
						<li><a href="javascript:void(0);">数码科技</a></li>
						<li><a href="javascript:void(0);">军事</a></li>
						<li><a href="javascript:void(0);">财经</a></li>
					</ul>			
				</li>
				<li>
					<a href="javascript:void(0);">语音直播</a>
					<ul>
						<li><a href="javascript:void(0);">FM233</a></li>
						<li><a href="javascript:void(0);">音乐电台</a></li>
						<li><a href="javascript:void(0);">娱乐互动</a></li>
						<li><a href="javascript:void(0);">情感调频</a></li>
					</ul>				
				</li>
				<li><a href="javascript:void(0);">其他分类</a></li>
			</ul>
		</div>
		<div id="content">
			我是网页的主要内容
		</div>
	</body>
</html>
```

## 二、无限级下拉菜单

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="utf-8" />
		<title>普通下拉菜单-三级菜单</title>
		<style type="text/css">
			*{margin: 0px; padding: 0px;}
			/*一级*/
			#menu{ height: 35px; background-image: url(img/menubg.jpg);}
			#menu>ul{ width: 1000px;}
			#menu ul{ list-style-type: none;}
			#menu li{ height: 35px; line-height: 35px; position: relative;}
			#menu a{ display: block; padding: 0px 30px; text-decoration: none; 
			font-size: 14px; font-weight: bold; color: black;}
			#menu>ul>li{float: left; }
			/*二级*/
			#menu>ul>li>ul{ display: none; position: absolute; left: 0px; background-color:ghostwhite}
			#menu>ul>li>ul>li{ clear: both;}
			#content{ background-color: gainsboro; text-align: center; padding: 200px; 
			font-size:50px; font-weight: bold;}
			/*三级或更多级*/
			#menu>ul>li>ul>li ul{ position: absolute; top: 0px; width: 100%;
			background-color:ghostwhite; display: none;}
			#menu>ul>li>ul>li li{clear: both;}
			
			.lihover{background-color: gray; }
			.lihover a{color: white;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				//二级
				$("#menu>ul>li").mouseover(function(){
					$(this).children("ul").stop().slideDown(300);
				})
				$("#menu>ul>li").mouseleave(function(){
					$(this).children("ul").stop().slideUp(300);
				})
				//三级
				$("#menu>ul>li>ul li").mouseover(function(){
					//判断菜单应该在左边还是右边显示出来
//					if($(this).offset().left + $(this).width() > $(window).width()-50)
//						$(this).children("ul").css("left","-" + $(this).width() + "px");
//					else
//						$(this).children("ul").css("left",$(this).width() + "px");
					
					$(this).children("ul").css("left",$(this).width() + "px");
					$(this).children("ul").stop().slideDown(300);
				})			
				$("#menu>ul>li>ul li").mouseleave(function(){
					$(this).children("ul").stop().slideUp(300);
				})	
				//li高亮显示效果
				$("#menu>ul>li>ul li").mouseover(function(){
					$(this).addClass("lihover");
				})
				$("#menu>ul>li>ul li").mouseleave(function(){
					$(this).removeClass("lihover");
				})				
			})

		</script>
	</head>
	<body>
		<div id="menu">
			<ul>
				<li>
					<a href="javascript:void(0);">推荐分类</a>
					<ul>
						<li><a href="javascript:void(0);">英雄联盟</a></li>
						<li><a href="javascript:void(0);">王者荣耀</a></li>
						<li><a href="javascript:void(0);">绝地求生</a></li>
						<li><a href="javascript:void(0);">二次元</a></li>
					</ul>
				</li>
				<li>
					<a href="javascript:void(0);">游戏竞技</a>
					<ul>
						<li>
							<a href="javascript:void(0);">网游竞技</a>
							<ul>
								<li><a href="javascript:void(0);">英雄联盟</a></li>
								<li><a href="javascript:void(0);">堡垒之夜</a></li>
								<li><a href="javascript:void(0);">DOTA2</a></li>
								<li><a href="javascript:void(0);">穿越火线</a></li>
							</ul>
						</li>
						<li>
							<a href="javascript:void(0);">单击热游</a>
							<ul>
								<li><a href="javascript:void(0);">绝地求生</a></li>		
								<li><a href="javascript:void(0);">战地风云</a></li>
								<li><a href="javascript:void(0);">NBA2k</a></li>
								<li><a href="javascript:void(0);">全面战争</a></li>
							</ul>
						</li>
						<li>
							<a href="javascript:void(0);">手游休闲</a>
							<ul>
								<li><a href="javascript:void(0);">刺激战场</a></li>
								<li><a href="javascript:void(0);">王者荣耀</a></li>
								<li><a href="javascript:void(0);">QQ飞车</a></li>
								<li><a href="javascript:void(0);">狼人杀</a></li>
							</ul>
						</li>
					</ul>
				</li>
				<li>
					<a href="javascript:void(0);">娱乐天地</a>
					<ul>
						<li><a href="javascript:void(0);">颜值</a></li>
						<li><a href="javascript:void(0);">星娱</a></li>
						<li><a href="javascript:void(0);">二次元</a></li>
						<li><a href="javascript:void(0);">户外</a></li>
						<li><a href="javascript:void(0);">音乐电台</a></li>
					</ul>				
				</li>
				<li>
					<a href="javascript:void(0);">科技教育</a>
					<ul>
						<li><a href="javascript:void(0);">鱼教</a></li>
						<li><a href="javascript:void(0);">数码科技</a></li>
						<li><a href="javascript:void(0);">军事</a></li>
						<li><a href="javascript:void(0);">财经</a></li>
					</ul>			
				</li>
				<li>
					<a href="javascript:void(0);">语音直播</a>
					<ul>
						<li><a href="javascript:void(0);">FM233</a></li>
						<li><a href="javascript:void(0);">音乐电台</a></li>
						<li><a href="javascript:void(0);">娱乐互动</a></li>
						<li><a href="javascript:void(0);">情感调频</a></li>
					</ul>				
				</li>
				<li><a href="javascript:void(0);">其他分类</a></li>
			</ul>
		</div>
		<div id="content">
			我是网页的主要内容
		</div>
	</body>
</html>
```

## 三、水平伸缩菜单

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>水平伸缩菜单</title>
		<style type="text/css">
			*{margin: 0px; padding: 0px; font-size: 12px;}
			#menu ul{ list-style-type: none;}
			#menu{margin-left:8px;width: 150px;}
			#menu li{width: 52px; clear: both; height: 52px; line-height: 52px; 
			margin-top: 20px; float: right; overflow: hidden;}
			#menu li,#menu img{ vertical-align: middle;}
			#menu a{ color: coral; font-weight: bold; text-decoration: none; font-size: 22px;}
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				$("#menu>ul>li").mouseover(function(){
					$(this).stop().animate({"width":"150px"},200);
				})
				$("#menu>ul>li").mouseleave(function(){
					$(this).stop().animate({"width":"52px"},200);
				})				
			})

		</script>
	</head>
	<body>
		<div id="menu">
			<ul>
			    <li><a href="#"><img src="img/home.png" alt="" width="50" height="50" border="0"/> Home</a></li>
			    <li><a href="#"><img src="img/about.png" alt="" width="50" height="50" border="0"/> About</a></li>
			    <li><a href="#"><img src="img/contact.png" alt="" width="50" height="50" border="0"/> Contact</a></li>				
			</ul>
		</div>
	</body>
</html>
```

## 四、TreeView菜单

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>TreeView菜单</title>
		<style type="text/css">
			*{margin: 0px; padding: 0px; font-size: 12px;}
			#menu{margin-left: 26px;}
			#menu ul{ list-style-type: none; clear: both;}
			#menu ul a{ text-decoration: none; color: black;}
			#menu li{line-height: 26px; clear: both; cursor:pointer}
			#menu ul>li ul{display:none; margin: 0px; padding: 0px;}
			.mypage{ background: url(img/page.png) no-repeat left 8px; padding-left: 16px;}
			.myplus{ background: url(img/plus.png) no-repeat left 8px; padding-left: 16px;}
			.myminus{ background: url(img/minus.png) no-repeat left 8px; padding-left: 16px;}			
		</style>
		<script type="text/javascript" src="js/jquery.js" ></script>
		<script type="text/javascript">
			$(function(){
				var $plusMenu = $("#menu>ul li:has(ul)");
				$plusMenu.removeClass("mypage").removeClass("myminus").addClass("myplus");
				var $pageMenu = $("#menu>ul li:not(:has(ul))");
				$pageMenu.removeClass("myminus").removeClass("myplus").addClass("mypage");
				
				$plusMenu.click(function(){
					//$(this).attr("target","_blank");
					//先打开链接地址
					//本窗口打开
					//window.location.href = $(this).children("a").attr("href");
					//新窗口打开
					//window.open($(this).children("a").attr("href"));
					if($(this).hasClass("myplus"))
					{
						$(this).removeClass("mypage").removeClass("myplus").addClass("myminus");
						$(this).children("ul").slideDown(100);
					}
					else
					{
						$(this).removeClass("mypage").removeClass("myminus").addClass("myplus");
						$(this).children("ul").slideUp(100);
					}
					return false;
				})
				$pageMenu.click(function(){
					//$(this).attr("target","_blank");
					//先打开链接地址
					//本窗口打开
					//window.location.href = $(this).children("a").attr("href");
					//新窗口打开
					//window.open($(this).children("a").attr("href"));
					return false;
				})				
				

			})

		</script>
	</head>
	<body>
	  <div id="menu">
	      <ul class="first" id="nav">
	         <li><a href="http://www.baidu.com">首页</a></li>
	         <li><a href="http://www.baidu.com">文化</a>
	             <ul>
	                <li><a href="http://www.baidu.com">企业文化</a></li>
	                <li><a href="http://www.baidu.com">企业精神</a></li>
	                <li><a href="http://www.baidu.com">经营理念</a></li>
	             </ul>
	         </li>
	         <li><a href="http://www.baidu.com">新闻</a>
	               <ul>
	                <li><a href="http://www.baidu.com">公司新闻</a></li>
	                <li><a href="http://www.baidu.com">产品发布新闻</a></li>
	             </ul>
	         </li>
	         <li><a href="http://www.baidu.com">招聘</a>
	            <ul>
	                <li><a href="http://www.baidu.com">企业招聘</a></li>
	                <li><a href="#">个人求职</a>
	                  <ul>
	                       <li><a href="#">java工程师</a></li>
	                        <li><a href="#">.net工程师</a></li>
	                    </ul>
	                </li>
	               <li><a href="http://www.baidu.com">联系我们</a></li>
	               <li><a href="http://www.baidu.com">51job</a></li>
	             </ul>
	         </li>
	      </ul>
	  </div>
		
	</body>
</html>
```

