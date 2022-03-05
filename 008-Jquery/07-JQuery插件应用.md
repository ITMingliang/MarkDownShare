# JQuery插件应用

本教程主要以Jquery UI为例，简单介绍Jquery插件的使用。

使用JQuery UI提供的基本功能，需要如下文件支持:

(1) jquery-ui.css

(2) jquery.js

(3) jquery-ui.js

jquery ui主题风格:可以通过如下网站地址选择风格或者自定义

https://jqueryui.com/themeroller/

## 一、JqueryUI-Autocomplete

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="utf-8">
		<title>JqueryUI-Autocomplete</title>
		<link rel="stylesheet" href="jqueryui/jquery-ui.css" />
		<script src="jquery/jquery.js"></script>
		<script src="jqueryui/jquery-ui.js"></script>
		<style type="text/css">
			#content{ margin-top: 200px; text-align: center;}
			#myTxt{ width: 600px; font-size: 18px;}
			#myButton{ width: 100px; height: 28px;}
		</style>
		<script type="text/javascript">
			$(function(){
				var availableTags = ["马云","马化腾","刘德华","刘强东","雷军","马超"];
				$( "#myTxt" ).autocomplete({
					source: availableTags
				});
			})
		</script>
	</head>
	<body>
		<div id="content">
			<h1>JqueryUI实现Autocomplete自动补全</h1>
			<input type="text" id="myTxt" />
			<input type="button" id="myButton" value="百度一下" />
		</div>
	</body>
</html>
```

## 二、JqueryUI实现draggable(拖拽)插件

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>JqueryUI实现draggable(拖拽)插件</title>
		<link rel="stylesheet" href="jqueryui/jquery-ui.css" />
		<script src="jquery/jquery.js"></script>
		<script src="jqueryui/jquery-ui.js"></script>
		<style type="text/css">
			#myDiv{width: 214px; height: 214px; cursor: pointer;}
		</style>
		<script type="text/javascript">
			$(function(){
				var setting={opacity:0.5, //拖拽过程中透明度
			 		//containment:"parent",//拖拽的区域
			 		revert:false//拖拽结束后是否返回原地，true:返回，false:不返回
		               };
				$("#myDiv").draggable(setting);
			})
		</script>		
	</head>
	<body>
		<div id="myDiv">
			<img src="img/timg.gif"  />
		</div>
	</body>
</html>
```

## 三、JqueryUI实现折叠面板

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>JqueryUI实现实现折叠面板</title>
		<link rel="stylesheet" href="jqueryui/jquery-ui.css" />
		<script src="jquery/jquery.js"></script>
		<script src="jqueryui/jquery-ui.js"></script>
		<style type="text/css">
			#myAccordion{ width: 400px;}
		</style>		
		<script type="text/javascript">
			$(function(){
				$("#myAccordion").accordion();
			})
		</script>
	</head>
	<body>
		<div id="myAccordion">
			<h3>游戏竞技</h3>
			<div>
				<img src="img/game.gif" width="300" height="200">
			</div>
			<h3>娱乐天地</h3>
			<div>
				<img src="img/yule.jpg" width="300" height="200">
			</div>
			<h3>科技教育</h3>
			<div>
				<img src="img/kjjy.jpg" width="300" height="200">
			</div>
			<h3>视频直播</h3>
			<div>
				<img src="img/zdx.jpg" width="300" height="200">
			</div>
		</div>
	</body>
</html>
```

## 四、queryUI实现日历控件

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>JqueryUI实现日历控件-本地化控件</title>
		<link rel="stylesheet" href="jqueryui/jquery-ui.css" />
		<script src="jquery/jquery.js"></script>
		<script src="jqueryui/jquery-ui.js"></script>
		<!-- 日历控件的汉化 -->
		<script src="js/jquery.ui.datepicker-zh-CN.js"></script>
		<script type="text/javascript">
			$(function(){
				//默认样式显示
				//$("#datepicker").datepicker();
				//格式化返回字符串显示
//				mm/dd/yy
//				yy-mm-dd
//				d M, y
//				d MM, y
//				DD, d MM, yy
//				$("#datepicker").datepicker();
//				$("#datepicker").datepicker( "option","dateFormat","yy-mm-dd" );
				//更多设置
				$("#datepicker").datepicker({inline: true,
					 //changeMonth:true, //显示选择月份的下拉列表
					 //changeYear:true,//显示选择年份的下拉列表
					 showOtherMonths: true, //显示上月和下月空出来的日期
					 selectOtherMonths: true, //可以显示上月和下月空出来的日期
					 showWeek:false,//显示日期对应的星期
					 //showButtonPanel:true,//显示"关闭"按钮面板
					 //closeText:"关闭",//设置关闭按钮的文本
					 //yearRange:'2000:2020',//设置年份的范围
					 dateFormat:'yy-mm-dd',//设置显示在文本框中的日期格式
					 //showAnim:"slideDown"//设置显示或隐藏日期选择窗口的方式。可以设置的方式有："show"、"slideDown"、"fadeIn"
				});
			})
		</script>
	</head>
	<body>
		<!--需要点击文本框后显示-->
		<p>日期：<input type="text" id="datepicker"></p>
		<!--直接内联显示-->
		<!--<div id="datepicker"></div>-->
	</body>
</html>
```

## 五、JqueryUI实现Tab选项卡

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>JqueryUI实现Tab选项卡</title>
		<link rel="stylesheet" href="jqueryui/jquery-ui.css" />
		<script src="jquery/jquery.js"></script>
		<script src="jqueryui/jquery-ui.js"></script>
		<style type="text/css">
			#myTabs{width: 600px; margin: 50px auto;}
		</style>
		<script type="text/javascript">
			$(function(){
				$("#myTabs").tabs();
			})
		</script>
	</head>
	<body>
		<div id="myTabs">
			<ul>
				<li><a href="#tab1">JavaScript介绍</a></li>
				<li><a href="#tab2">JQuery介绍</a></li>
				<li><a href="#tab3">ASP.NET介绍</a></li>
			</ul>
			<div id="tab1">
				JavaScript一种直译式脚本语言，是一种动态类型、弱类型、基于原型的语言，内置支持类型。
				它的解释器被称为JavaScript引擎，为浏览器的一部分，广泛用于客户端的脚本语言，
				最早是在HTML（标准通用标记语言下的一个应用）网页上使用，用来给HTML网页增加动态功能。
			</div>
			<div id="tab2">
				jQuery是一个快速、简洁的JavaScript框架，是继Prototype之后又一个优秀的JavaScript代码库（或JavaScript框架）。
				jQuery设计的宗旨是“write Less，Do More”，即倡导写更少的代码，做更多的事情。
				它封装JavaScript常用的功能代码，提供一种简便的JavaScript设计模式，优化HTML文档操作、事件处理、动画设计和Ajax交互。
			</div>
			<div id="tab3">
				ASP.NET又称为ASP+，不仅仅是ASP的简单升级，而是微软公司推出的新一代脚本语言。
				ASP.NET基于.NET Framework的Web开发平台，不但吸收了ASP以前版本的最大优点并参照Java、VB语言的开发优势加入了许多新的特色，
				同时也修正了以前的ASP版本的运行错误。				
			</div>
		</div>
	</body>
</html>
```

## 六、JqueryUI实现Dialog对话框

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>JqueryUI实现Dialog对话框</title>
		<link rel="stylesheet" href="jqueryui/jquery-ui.css" />
		<script src="jquery/jquery.js"></script>
		<script src="jqueryui/jquery-ui.js"></script>		
		<style type="text/css">
			#myTable{ width: 1000px; margin: 0px auto; background-color: #008000;}
			#myTable td,#myTable th{ background-color: white;}
			#dialog{display: none;}
		</style>
		<script type="text/javascript">
			$(function(){
				$(".del").click(function(){
					//直接调用
					//$("#dialog").dialog();
					//设置关键参数调用
					$("#dialog").dialog({
						modal: true,  //模态样式
						height:220,
						buttons: {
							"确定删除": function() {
								$(this).dialog("close");
								alert('删除成功!');
							},
							"取消": function() {
								$(this).dialog("close");
							}
						}
					});
				});
			})
		</script>
	</head>
	<body>
		<div id="dialog" title="****信息管理系统">
			<p>是否确定要删除此信息,删除后无法恢复。</p>
		</div>
		<table cellspacing="1" id="myTable">
			<tr>				
				<th width="200">姓名</th>
				<th width="200">性别</th>
				<th width="200">专业</th>
				<th width="200">爱好</th>
				<th width="200">操作</th>
			</tr>
			<tr>
				<td>刘备</td>
				<td>男</td>
				<td>软件开发</td>
				<td>抽烟</td>
				<td><a href="#" class="del">删除</a></td>
			</tr>
			<tr>
				<td>关羽</td>
				<td>男</td>
				<td>国际贸易</td>
				<td>喝酒</td>
				<td><a href="#" class="del">删除</a></td>
			</tr>
			<tr>
				<td>张飞</td>
				<td>男</td>
				<td>园林设计</td>
				<td>烫头发</td>
				<td><a href="#" class="del">删除</a></td>
			</tr>
			<tr>
				<td>赵云</td>
				<td>男</td>
				<td>平面设计</td>
				<td>抽烟</td>
				<td><a href="#" class="del">删除</a></td>
			</tr>
			<tr>
				<td>黄忠</td>
				<td>男</td>
				<td>影视制作</td>
				<td>玩游戏</td>
				<td><a href="#" class="del">删除</a></td>
			</tr>
			<tr>
				<td>小乔</td>
				<td>女</td>
				<td>高级护理</td>
				<td>唱歌</td>
				<td><a href="#" class="del">删除</a></td>
			</tr>
		</table>		
	</body>
</html>
```

## 七、JqueryUI实现Tooltip提示框

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>JqueryUI实现Tooltip提示框</title>
		<link rel="stylesheet" href="jqueryui/jquery-ui.css" />
		<script src="jquery/jquery.js"></script>
		<script src="jqueryui/jquery-ui.js"></script>
		<style type="text/css">
			#myDiv{ width: 600px; margin: 0px auto; }
			/*找到jqueryui中的样式表,进行重新定义,可以修改其外观*/
			.ui-tooltip {
				padding: 8px;
				position: absolute;
				z-index: 9999;
				max-width: 300px;
			}
		</style>	
		<script type="text/javascript">
			$(function(){
				$("#myDiv").tooltip({width:100});
				$("#myDiv div").css("width","1000px");
			})
		</script>
	</head>
	<body>
		<div id="myDiv">
			JavaScript一种直译式脚本语言，是一种动态类型、弱类型、基于原型的语言，内置支持类型。
			它的解释器被称为JavaScript引擎，为浏览器的一部分，广泛用于客户端的脚本语言，
			最早是在
			<a href="#" title="超文本标记语言,就是指页面内可以包含图片、链接，甚至音乐、程序等非文字元素">HTML</a>
			（标准通用标记语言下的一个应用）网页上使用，用来给HTML网页增加动态功能。
		</div>
	</body>
</html>
```

## 八、JqueryUI更换主题

https://jqueryui.com/themeroller/，在这个地址提供了一套工具，可以下载JqueryUI所有的风格主题，也可以在

工具里面自定义主题样式后在进行下载。

将下载的主题文件夹复制粘贴到项目中，引入样式表文件即可实现主题的更换，例如：

```
<link rel="stylesheet" href="jqueryui/jquery-ui.css" />
<!-- 		
此样式切换jqueryui风格：
可以在jqueryui官网下载所有风格和自定义风格下载
下载完成后会有多种风格,将需要的风格文件夹复制到项目中
-->
<link rel="stylesheet" href="jqueryui/themes/dark-hive/theme.css"/>
<script src="jquery/jquery.js"></script>
<script src="jqueryui/jquery-ui.js"></script>
```

## 九、幻灯片插件slidr

此插件与JqueryUI没有关系，可以在教学资料中找到该插件的官方Demo。

```
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>幻灯片插件slidr的使用</title>
		<style type="text/css">
			#ppt{ width: 996px; height: 300px; margin: 50px auto;}
		</style>
		<script type="text/javascript" src="jquery/jquery.js" ></script>
		<script type="text/javascript" src="js/slidr.js" ></script>
		<script type="text/javascript">
			$(function(){
				//默认左右箭头来切换
				//slidr.create('ppt').start();
				
				//带设置参数
//				slidr.create('ppt', {
//				  after: function(e) { console.log('in: ' + e.in.slidr); }, //幻灯片转换结束后的回调函数
//				  before: function(e) { console.log('out: ' + e.out.slidr); }, //在幻灯片过渡开始之前的回调函数
//				  breadcrumbs: true,  //显示或隐藏面包屑
//				  controls: 'border',  //显示或隐藏控制箭头。‘边框’、‘拐角’或‘没有’(`border`, `corner` or `none`)
//				  direction: 'horizontal', //新幻灯片的默认方向。“水平”或“垂直”(horizontal,vertical)
//				  fade: false,  //幻灯片过渡是否应该淡入/淡出
//				  keyboard: true, //是否启用鼠标键盘导航
//				  overflow: false, //是否在SLLDR边界上溢出转换
//				  pause: true, //在运行时是否暂停鼠标操作
//				  theme: '#222', //设置面包屑/控件的颜色主题
//				  timing: { 'cube': '0.5s ease-in' }, //自定义动画定时应用。{“过渡”：“计时”}。(`{'transition': 'timing'}`)
//				  touch: true, //是否启用移动设备的触摸导航
//				  transition: 'cube' //要应用的默认转换。“立方体”、“线性”、“渐变”或“无”。(`cube`, `linear`, `fade`, or `none`)
//				}).start();

				//自动播放
				slidr.create('ppt', {
				  after: function(e) { console.log('in: ' + e.in.slidr); }, //幻灯片转换结束后的回调函数
				  before: function(e) { console.log('out: ' + e.out.slidr); }, //在幻灯片过渡开始之前的回调函数
				  breadcrumbs: true,  //显示或隐藏面包屑
				  controls: 'border',  //显示或隐藏控制箭头。‘边框’、‘拐角’或‘没有’(`border`, `corner` or `none`)
				  direction: 'horizontal', //新幻灯片的默认方向。“水平”或“垂直”(horizontal,vertical)
				  fade: false,  //幻灯片过渡是否应该淡入/淡出
				  keyboard: true, //是否启用鼠标键盘导航
				  overflow: false, //是否在SLLDR边界上溢出转换
				  pause: false, //在运行时是否暂停鼠标操作
				  theme: '#222', //设置面包屑/控件的颜色主题
				  timing: { 'cube': '0.5s ease-in' }, //自定义动画定时应用。{“过渡”：“计时”}。(`{'transition': 'timing'}`)
				  touch: true, //是否启用移动设备的触摸导航
				  transition: 'cube' //要应用的默认转换。“立方体”、“线性”、“渐变”或“无”。(`cube`, `linear`, `fade`, or `none`)
				}).add('h', ['one', 'two', 'three', 'four','five','one'])
				.auto(5000);
			})
		</script>		
		
	</head>
	<body>	
		<div id="ppt">
			<img data-slidr="one" src="img/01.jpg" width="996" height="300"  />
			<img data-slidr="two" src="img/02.jpg" width="996" height="300"  />
			<img data-slidr="three" src="img/03.jpg" width="996" height="300"  />
			<img data-slidr="four" src="img/04.jpg" width="996" height="300"  />
			<img data-slidr="five" src="img/05.jpg" width="996" height="300"  />
		</div>
	</body>
</html>
```

