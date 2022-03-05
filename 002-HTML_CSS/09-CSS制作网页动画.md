# CSS制作网页动画

## 一、transition定义动画过度效果

```
/*transition:
    第一个参数：过渡效果生效的样式属性，all代表所有属性变化都可以有设置的过度效果
    第二个参数：过渡时间
    第三个参数：过渡效果样式
    （1）linear:匀速
    （2）ease:慢-》快-》慢
    （3）ease-in:慢->快
    （4）ease-out:快->慢
    (5)ease-in-out:慢-》中-》慢
* */
#myImg{ transition: all 1s ease-in-out;}
```

transition只是设置动画的过度效果，并不能直接产生动画，必须和以下其他的动画效果结合使用才能做出动画效果。

## 一、制作位置移动动画

```
<head>
	<meta charset="utf-8" />
	<title>制作位置平移效果</title>
	<style type="text/css">			
		#myImg{
			transition: all 1s ease-in-out;
		}
		#myImg:hover{
			transform: translate(60px,60px);
		}
	</style>
</head>
<body>
	<img id="myImg" src="img/timg.png" width="200" height="200" />
</body>
```

我们可以看到，鼠标经过图片的时候，图片会经过1秒钟向右向下平移60像素。

## 二、倾斜动画

```
<head>
	<meta charset="UTF-8">
	<title>倾斜效果</title>
	<style type="text/css">
		#myImg{ transition: all 2s ease-in-out;}
		#myImg:hover{
			transform: skew(50deg,50deg);
		}
	</style>
</head>
<body>
	<img id="myImg" src="img/timg.png" width="200" height="200" />
</body>
```

我们可以看到鼠标经过图片的时候，图片经过2秒钟时间沿着 X 和 Y 轴倾斜50度和50度。

## 三、旋转动画

```
<head>
	<meta charset="UTF-8">
	<title>旋转效果</title>
	<style type="text/css">
		#myImg{ transition: all 1s ease-in-out;}
		#myImg:hover{
			transform:rotate(360deg);
		}
	</style>
</head>
<body>
	<img id="myImg" src="img/timg.png" width="200" height="200" />
</body>
```

我们可以看到鼠标经过图片的时候，图片经过1秒钟时间旋转了360度。

## 四、缩放动画

```
<head>
	<meta charset="UTF-8">
	<title>缩放动画</title>
	<style type="text/css">
		#myImg{ transition: all 1s ease-in-out;}
		#myImg:hover{
			transform:scale(1.2);
		}
	</style>
</head>
<body>
	<img id="myImg" src="img/timg.png" width="200" height="200" />
</body>
```

我们可以看到鼠标经过图片的时候，图片经过1秒钟时间放大1.2倍。

## 五、动画组合应用

```
<head>
	<meta charset="UTF-8">
	<title>动画组合应用</title>
	<style type="text/css">
		#myImg{ transition: all 1s ease-in-out;}
		#myImg:hover{
			transform:rotate(360deg) scale(1.2);
		}
	</style>
</head>
<body>
	<img id="myImg" src="img/timg.png" width="200" height="200" />
</body>
```

我们可以将多个动画放在一起组合应用，我们可以看到鼠标经过图片的时候，图片经过1秒钟时间旋转360度，同时并且放大1.2倍。

## 六、animation制作自定义动画

HTML:

```
<img id="myImg" src="img/plane.jpg" width="180" />
```

CSS:

```
/*定义关键帧*/
@keyframes myKey{
	0%{ width: 180px; top: 0px; left: 0px;
	transform: rotate(0deg);}
	25%{width: 180px; top: 200px; left: 250px;
	transform: rotate(45deg);}
	50%{width: 180px; top: 400px; left: 500px;
	transform: rotate(0deg);}
	75%{width: 180px; top: 200px; left: 750px;
	transform: rotate(-45deg);}
	100%{width: 180px; top: 0px; left: 1000px;
	transform: rotate(0deg);}
}
/*创建自定义动画*/
#myImg{ position: absolute; animation: myKey 5s linear;}
```

我们可以看到图片会按照定义的关键帧中的5个关键节点，总共历时5秒钟，分别完成位置，旋转角度的变换过程。

