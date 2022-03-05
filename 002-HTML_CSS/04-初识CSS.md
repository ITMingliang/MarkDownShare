# 初识CSS

CSS：Cascading Style Sheet  层叠样式表

CSS优点：

（1）内容与表现分离。
（2）网页的表现统一，容易修改。
（3）丰富的样式，使得页面布局更加灵活。
（4）减少网页的代码量，增加网页的浏览速度，节省网络带宽。
（5）运用独立于页面的CSS，有利于网页被搜索引擎收录。

## 一、样式表写在什么地方

（1）样式表直接写在标签里面（行内样式）

```
<div style="color:blue; font-size: 20px;">
	好久没有上课了，今天上课好开心！
</div>
```

（2）样式表写在网页的style标签里面（内部样式）

编写样式

```
<style type="text/css">
	.myfont{ color: coral; font-size: 40px;}
</style>
```

使用样式

```
<div class="myfont">
	好久没有上课了，今天上课好开心！
</div>
```

（3）样式表写在外部CSS文件中（外部样式）

在项目中创建css.css样式表文件，编写样式：

```
.myfont1{ color:chartreuse; font-size:80px }
```

在网页头部使用link语法导入样式表文件

```
<link rel="stylesheet" href="css/css.css" />
```

使用样式

```
<div class="myfont1">
	好久没有上课了，今天上课好开心！
</div>
```

**备注：**样式表直接写在标签里面只能对当前标签进行样式设置；将样式表写在网页的style标签里面可以对当前网页中的多个地方进行样式设置；将样式表写在外部的CSS文件中，可以对整个站点的所有页面的多个地方进行样式设置。

**三种样式表引入方式的优先级别如下：**

行内样式 > 内部样式 > 外部样式

## 二、基本选择器

（1）标签选择器

```
td{ color: pink;}
```

```
<table width="1000" border="1">
	<tr>
		<td width="200">关羽</td>
		<td width="200">诸葛亮</td>
		<td width="200">张飞</td>
		<td width="200">徐伟</td>
		<td width="200">赵云</td>
	</tr>
	<tr>
		<td width="200">曹植</td>
		<td width="200">曹丕</td>
		<td width="200">司马懿</td>
		<td width="200">徐晃</td>
		<td width="200">典韦</td>
	</tr>
	<tr>
		<td width="200">周瑜</td>
		<td width="200">大乔</td>
		<td width="200">小乔</td>
		<td width="200">太史慈</td>
		<td width="200">陆逊</td>
	</tr>
</table>
```

此时表格所有单元格文字显示为粉红色；对所有的td标签生效。

（2）ID选择器

```
<style type="text/css">
    td{ color: #FF7F50;}
    #guanyu{ color:red; font-weight: bold;}
</style>
```

```
<table width="1000" border="1">
	<tr>
		<td width="200" id="guanyu">关羽</td>
		<td width="200">诸葛亮</td>
		<td width="200">张飞</td>
		<td width="200">徐伟</td>
		<td width="200">赵云</td>
	</tr>
	<tr>
		<td width="200">曹植</td>
		<td width="200">曹丕</td>
		<td width="200">司马懿</td>
		<td width="200">徐晃</td>
		<td width="200">典韦</td>
	</tr>
	<tr>
		<td width="200">周瑜</td>
		<td width="200">大乔</td>
		<td width="200">小乔</td>
		<td width="200">太史慈</td>
		<td width="200">陆逊</td>
	</tr>
</table>
```

ID选择器，在选择器名称前面加 # ,在使用样式的地方需要使用ID属性。

此时，所有文字为粉红色，只有“关羽”文字为红色，并且字体加粗。

（3）类选择器

```
<style type="text/css">
    .liubei{ color: green;}
    .caocao{ color: yellow;}
    .sunquan{ color: blue;}
</style>
```

```
<table width="1000" border="1">
    <tr>
        <td width="200" id="guanyu" class="liubei">关羽</td>
        <td width="200" class="liubei">诸葛亮</td>
        <td width="200" class="liubei">张飞</td>
        <td width="200" class="liubei">徐伟</td>
        <td width="200" class="liubei">赵云</td>
    </tr>
    <tr>
        <td width="200" class="caocao">曹植</td>
        <td width="200" class="caocao">曹丕</td>
        <td width="200" class="caocao">司马懿</td>
        <td width="200" class="caocao">徐晃</td>
        <td width="200" class="caocao">典韦</td>
    </tr>
    <tr>
        <td width="200" class="sunquan">周瑜</td>
        <td width="200" class="sunquan">大乔</td>
        <td width="200" class="sunquan">小乔</td>
        <td width="200" class="sunquan">太史慈</td>
        <td width="200" class="sunquan">陆逊</td>
    </tr>
</table>
```

类选择器，在选择器名字前面加 . ,在使用样式的地方需要使用class属性。

此时刘备的人变成绿色，曹操的人变成黄色，孙权的人变成蓝色。

**备注：**

三种基本选择器的优先级别为：ID选择器 > 类选择器 > 标签选择器。

## 三、高级选择器

（1）群组选择器：

```
<style type="text/css">
	#zhugeliang,#simayi{ color: green; font-weight: bold;}
</style>
```

此时代表ID为zhugeliang和ID为simayi的标签内文本颜色绿色，字体加粗。

（2）包含选择器：

```
<style type="text/css">
	#liubei td{ color: green; font-weight: bold;}
</style>
```

此时代表ID为liubei的标签内部包含的所有td标签内文本绿色，字体加粗。

（3）儿子选择器：

```
<style type="text/css">
	#liubei>p{ color: green; font-weight: bold;}
</style>
```

此时代表ID为liubei的标签内部下一级P标签内文本绿色，字体加粗，这里只能设置到下一级，不能设置层次更深的标签的样式，及只能设置儿子的样式，不能设置孙子及层次更深的样式。

（4）相邻兄弟选择器

```
<style type="text/css">
	#liubei+p{ color: green; font-weight: bold;}
</style>
```

此时代表紧连着ID为liubei的后面的一个P标签，二者具有相同的父亲，选择此标签设置文本绿色，字体加粗。

（5）通用选择器

```
<style type="text/css">
	#liubei~p{ color: green; font-weight: bold;}
</style>
```

此时代表紧连着ID为liubei的后面的所有P标签，他们具有相同的父亲，选择这些标签设置文本绿色，字体加粗。

（6）结构伪类选择器

```
<style>
    /*ul的第一个子元素,如果正好是li*/
    ul li:first-child{background: red;}
    
    /*ul的最后一个子元素,如果正好是li*/
    ul li:last-child{background: green;}

    /*ul的第二个子元素,如果正好是li*/
    ul li:nth-child(2){background: green;}

    /*ul的第奇数个子元素,如果正好是li*/
    ul li:nth-child(odd){background: green;}
    
    /*ul的第偶数个子元素,如果正好是li*/
    ul li:nth-child(even){background: green;}
    
    /*父元素body里第1个类型为p的元素*/
    body p:first-of-type{background: blue;}
    
    /*父元素body里最后1个类型为p的元素*/
    body p:last-of-type{background: blue;}
    
    /*父元素body里第2个类型为p的元素*/
    body p:nth-of-type(2){background: blue;}
    
    /*nth-of-type同样也支持 even和odd*/
</style>
```

（7）属性选择器

```
<style type="text/css">
	/*a标签中存在属性id的元素*/
	p[id]{background: red;}
	
	/*a标签中存在属性id,并且id值为red的元素*/
	p[id=red]{background: red;}	

	/*a标签中存在属性class,并且class值为red的元素*/
	p[class=red]{background: red;}
    
  	/*a标签中存在属性class,并且class值中包含red的元素*/
	p[class*=red]{background: red;}  
	
	/*a标签的href属性以http开头的元素*/
	a[href^=http]{background: red;}
	
	/*a标签的href属性以php结尾的元素*/
	a[href$=php]{background: red;}
</style>
```

（8）伪类选择器

```
<style type="text/css">
    /*link:正常状态，hover:鼠标经过 active:鼠标正在点击 visited:访问之后*/
    #liubei a:link{ color: black;} 
    #liubei a:hover{ color: green;}
    #liubei a:active{ color: red;}
    #liubei a:visited{ color: blue;}
</style>
```

