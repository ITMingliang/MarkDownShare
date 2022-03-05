# CSS美化网页元素

## 一、字体相关样式

```
p {
    color: red; 	/*设置前景颜色，即字体颜色*/
    font-size: 24px; /*设置字体大小为24像素*/
    font-weight: bold;  /*设置字体加粗;bold：加粗; normal:正常*/
    /*设置字体样式，可以设置多个字体，优先级从左到右，所有字体客户端都没有安装，显示默认宋体*/
    font-family: Times,"Times New Roman", "楷体";  
    font-style:italic;   /*设置字体为斜体;italic:斜体;normal:正常*/
}
```

## 二、文本相关样式

```
p{
	text-align:center; /*文本对其方式;left:左;center:中;right:右;*/
	/*设置文本有下划线;overline:上划线;line-through:中间删除线;underline:下划线;none:没有线;*/
	text-decoration:underline;
	text-indent:2em;  /*段落第一行缩进2个字符的长度*/
	line-height:28px; /*每行高度28像素*/
	/*文本阴影;参数依次为 水平阴影的位置，垂直阴影的位置，模糊的距离，阴影的颜色*/
	text-shadow: 5px 5px 5px #FF0000;
}
```

图片和文字混合排版垂直对齐方式：

样式如下：

```
<style type="text/css">
img.top {vertical-align:text-top}
img.bottom {vertical-align:text-bottom}
</style>
```

HTML如下：

```
<p>
这是一幅<img class="top" border="0" src="/i/eg_cute.gif" />位于段落中的图像。
</p> 
<p>
这是一幅<img class="bottom" border="0" src="/i/eg_cute.gif" />位于段落中的图像。
</p>
```

我们可以看到第一个段落中的文字垂直方向居上；第二个段落文字垂直方向居下；如果需要设置文本垂直居中，可以在样式表中设置vertical-align:middle;

## 三、背景相关样式

**背景颜色**

```
background-color:red;  /*设置背景颜色为红色*/
```

**背景图片**

```
background-image: url("img/1.jpg");
```

**背景重复**

```
background-repeat: repeat-x;
```

repeat：x轴和y轴一起重复平铺；repeat-x：x轴方向重复平铺；repeat-y：y轴方向重复平铺；no-repeat：不平铺；

**背景定位**

```
background-position:center center;
```

设置背景图片的起始位置；第一个参数是水平起始位置，第二个参数是垂直水平位置；

第一个参数可以取值left,center,right,代表水平起始位置左中右，也可以直接使用数字进行设置；

第二个参数可以取值top,center,bottom,代表垂直起始位置上中下，也可以直接使用数字进行设置；

**背景样式的简写**

```
background:url("img/1.jpg") no-repeat center center;
```

第一个参数是背景图片路径地址，第二个参数是背景平铺方式，第三个和第四个参数代表背景水平和垂直起始位置。

**背景图像尺寸**

```
background-size:80px 60px;  /*设置背景图像尺寸为宽80像素，高60像素*/
background-size:100% 100%;  /*百分比设置背景图像尺寸，此代码代表伸展背景图像完全填充内容区域*/
background-size:cover /*把背景图像扩展至足够大，以使背景图像完全覆盖背景区域*/
background-size:contain /*把图像图像扩展至最大尺寸，以使其宽度和高度完全适应内容区域。*/
```

取值cover和contain的区别：

两者都是等比例扩展图片，取值为cover的时候，背景区域完全被背景覆盖，但是背景图片的某些区域可能会丢失，无法显示出来；而取值为contain的时候，如果背景不平铺，背景区域可能不会被背景完全覆盖，可能在水平或垂直方向有留白区域。

