# 小工具-flex-多媒体

## 一、小工具

Bootstrap4 提供了一些小工具，可以让我们不用写 CSS 代码就能实现想要的效果。

**边框：**

```
<style type="text/css">
.border {display: inline-block; width: 70px; height: 70px; margin: 6px;}
</style>
<!-- 使用 border 类可以添加或移除边框: -->
<span class="border"></span>
<span class="border border-0"></span>
<span class="border border-top-0"></span>
<span class="border border-right-0"></span>
<span class="border border-bottom-0"></span>
<span class="border border-left-0"></span>
```

**边框颜色：**

```
<style type="text/css">
.border {display: inline-block; width: 70px; height: 70px; margin: 6px;}
</style>
<!-- Bootstrap4 提供了一些类来设置边框颜色: -->
<span class="border border-primary"></span>
<span class="border border-secondary"></span>
<span class="border border-success"></span>
<span class="border border-danger"></span>
<span class="border border-warning"></span>
<span class="border border-info"></span>
<span class="border border-light"></span>
<span class="border border-dark"></span>
<span class="border border-white"></span>
```

**边框圆角设计：**

```
<!-- 使用rounded 类可以添加圆角边框: -->
<style type="text/css">
    .test1{display: inline-block; width: 70px; height: 70px; margin: 6px;
    background-color: lightcoral;}
</style>
<span class="rounded test1"></span>
<span class="rounded-top test1"></span>
<span class="rounded-right test1"></span>
<span class="rounded-bottom test1"></span>
<span class="rounded-left test1"></span>
<span class="rounded-circle test1"></span>
<span class="rounded-0 test1"></span>
```

**浮动：**

```
<!--.float-right类用于设置元素右浮动,.float-left设置元素左浮动,.clearfix 类用于清除浮动-->
<div class="clearfix">
    <span class="float-left">左浮动</span>
    <span class="float-right">右浮动</span>
</div>
```

**响应式浮动：**

```
<!-- 我们看可以设置浮动 (.float-*-left|right: * 为 sm, md, lg 或 xl)的方向依赖于屏幕的大小: -->
<div class="float-sm-right">在大于小屏幕尺寸上右浮动</div><br />
<div class="float-md-right">在大于中等屏幕尺寸上右浮动</div><br />
<div class="float-lg-right">在大于大屏幕尺寸上右浮动</div><br />
<div class="float-xl-right">在大于超大屏幕尺寸上右浮动</div><br />
<div class="float-none">没有浮动</div>
```

**居中对齐：**

```
<!-- 使用 .mx-auto 类来设置居中对齐: -->
<div class="mx-auto bg-warning" style="width:150px">居中显示</div>
```

**宽度：**

```
<!-- 元素上使用 w-* 类 (.w-25, .w-50, .w-75, .w-100, .mw-100) 来设置宽度 -->
<div class="w-25 bg-warning">宽度 25%</div><br />
<div class="w-50 bg-warning">宽度 50%</div><br />
<div class="w-75 bg-warning">宽度 75%</div><br />
<div class="w-100 bg-warning">宽度 100%</div><br />
<div class="mw-100 bg-warning">最大宽度 100%</div><br />
```

**高度：**

```
<style type="text/css">
	.test2{ margin: 0 20px 0px 0px; }
</style>
<!-- 元素上使用 h-* 类 (.h-25, .h-50, .h-75, .h-100, .mh-100) 来设置高度 -->
<div style="height:200px;background-color:#ddd;padding: 0px;">
<div class="h-25 bg-warning float-left test2">高度 25%</div>
<div class="h-50 bg-warning float-left test2">高度 50%</div>
<div class="h-75 bg-warning float-left test2">高度 75%</div>
<div class="h-100 bg-warning float-left test2">高度 100%</div>
<div class="mh-100 bg-warning float-left test2" style="height:500px">最大高度 100%</div>
</div>
```

## 二、Flex弹性布局

Bootstrap 3 与 Bootstrap 4 最大的区别就是 Bootstrap 4 使用弹性盒子来布局，而不是使用浮动来布局。

弹性盒子是 CSS3 的一种新的布局模式，更适合响应式的设计，如果你还不了解 flex，可以阅读CSS3中的Flex弹性

布局。

**使用 d-flex 类创建一个弹性盒子容器，并设置三个弹性子元素**

```
<div class="d-flex p-3 bg-secondary text-white">
    <div class="p-2 bg-info">Flex item 1</div>
    <div class="p-2 bg-warning">Flex item 2</div>
    <div class="p-2 bg-primary">Flex item 3</div>
</div>
```

**创建显示在同一行上的弹性盒子容器可以使用d-inline-flex类**

```
<div class="d-inline-flex p-3 bg-secondary text-white">
    <div class="p-2 bg-info">Flex item 1</div>
    <div class="p-2 bg-warning">Flex item 2</div>
    <div class="p-2 bg-primary">Flex item 3</div>
</div>
<div class="d-inline-flex p-3 bg-secondary text-white">
    <div class="p-2 bg-info">Flex item 1</div>
    <div class="p-2 bg-warning">Flex item 2</div>
    <div class="p-2 bg-primary">Flex item 3</div>
</div>
```

**水平方向**

.flex-row 可以设置弹性子元素水平显示，这是默认的。

使用.flex-row-reverse 类用于设置右对齐显示，即与.flex-row方向相反。

```
<div class="d-flex p-2 mb-2 flex-row bg-secondary">
    <div class="p-2 bg-info">Flex item 1</div>
    <div class="p-2 bg-warning">Flex item 2</div>
    <div class="p-2 bg-primary">Flex item 3</div>
</div>

<div class="d-flex p-2 flex-row-reverse bg-secondary">
    <div class="p-2 bg-info">Flex item 1</div>
    <div class="p-2 bg-warning">Flex item 2</div>
    <div class="p-2 bg-primary">Flex item 3</div>
</div>
```

**垂直方向**

.flex-column 类用于设置弹性子元素垂直方向显示。

.flex-column-reverse 用于翻转子元素。

```
<div class="d-flex p-2 mb-2 bg-secondary flex-column">
    <div class="p-2 bg-info">Flex item 1</div>
    <div class="p-2 bg-warning">Flex item 2</div>
    <div class="p-2 bg-primary">Flex item 3</div>
</div>

<div class="d-flex p-2 bg-secondary flex-column-reverse">
    <div class="p-2 bg-info">Flex item 1</div>
    <div class="p-2 bg-warning">Flex item 2</div>
    <div class="p-2 bg-primary">Flex item 3</div>
</div>
```

**内容排列方式**

.justify-content-* 类用于修改弹性子元素的排列方式。

*号允许的值有：start (默认), end, center, between 或 around。

```
<div class="d-flex justify-content-start bg-secondary mb-3 p-2">
    <div class="p-2 bg-info">Flex item 1</div>
    <div class="p-2 bg-warning">Flex item 2</div>
    <div class="p-2 bg-primary">Flex item 3</div>
</div>
<div class="d-flex justify-content-end bg-secondary mb-3 p-2">
    <div class="p-2 bg-info">Flex item 1</div>
    <div class="p-2 bg-warning">Flex item 2</div>
    <div class="p-2 bg-primary">Flex item 3</div>
</div>
<div class="d-flex justify-content-center bg-secondary mb-3 p-2">
    <div class="p-2 bg-info">Flex item 1</div>
    <div class="p-2 bg-warning">Flex item 2</div>
    <div class="p-2 bg-primary">Flex item 3</div>
</div>
<div class="d-flex justify-content-between bg-secondary mb-3 p-2">
    <div class="p-2 bg-info">Flex item 1</div>
    <div class="p-2 bg-warning">Flex item 2</div>
    <div class="p-2 bg-primary">Flex item 3</div>
</div>
<div class="d-flex justify-content-around bg-secondary mb-3 p-2">
    <div class="p-2 bg-info">Flex item 1</div>
    <div class="p-2 bg-warning">Flex item 2</div>
    <div class="p-2 bg-primary">Flex item 3</div>
</div>
```

**等宽**

.flex-fill 类强制设置各个弹性子元素的宽度是一样的。

	<div class="d-flex p-2 bg-secondary">
	    <div class="p-2 bg-info flex-fill">Flex item 1</div>
	    <div class="p-2 bg-warning flex-fill">Flex item 2</div>
	    <div class="p-2 bg-primary flex-fill">Flex item 3</div>
	</div>
**扩展(剩余空间)**

.flex-grow-1 用于设置子元素使用剩下的空间。

以下实例中前面两个子元素只设置了它们所需要的空间，最后一个获取剩余空间。

```
<div class="d-flex p-2 bg-secondary">
    <div class="p-2 bg-info">Flex item 1</div>
    <div class="p-2 bg-warning">Flex item 2</div>
    <div class="p-2 bg-primary flex-grow-1">Flex item 3</div>
</div>
```

**排序**

.order类可以设置弹性子元素的排序，从.order-1到.order-12，数字越低权重越高( .order-1排在.order-2之前)。

```
<div class="d-flex p-2 bg-secondary">
    <div class="p-2 bg-info order-3">Flex item 1</div>
    <div class="p-2 bg-warning order-2">Flex item 2</div>
    <div class="p-2 bg-primary order-1">Flex item 3</div>
</div>
```

**外边距**

.mr-auto类可以设置子元素右外边距为 auto，即 margin-right: auto!important;

.ml-auto 类可以设置子元素左外边距为 auto，即 margin-left: auto!important;

```
<div class="d-flex bg-secondary mb-2 p-2 ">
    <div class="p-2 mr-auto bg-info">Flex item 1</div>
    <div class="p-2 bg-warning">Flex item 2</div>
    <div class="p-2 bg-primary">Flex item 3</div>
</div>

<div class="d-flex bg-secondary mb-2 p-2">
    <div class="p-2 bg-info">Flex item 1</div>
    <div class="p-2 bg-warning">Flex item 2</div>
    <div class="p-2 ml-auto bg-primary">Flex item 3</div>
</div>
```

**包裹**

弹性容器中包裹子元素可以使用以下三个类

.flex-nowrap (默认), .flex-wrap 或 .flex-wrap-reverse。设置 flex 容器是单行或者多行。

```
<div class="d-flex p-2 mb-2 bg-secondary text-white">
    <div class="p-2 bg-info">Flex item 1</div>
    <div class="p-2 bg-warning">Flex item 2</div>
    <div class="p-2 bg-primary">Flex item 3</div>
    <div class="p-2 bg-info">Flex item 4</div>
    <div class="p-2 bg-warning">Flex item 5</div>
    <div class="p-2 bg-primary">Flex item 6</div>
    <div class="p-2 bg-info">Flex item 7</div>
    <div class="p-2 bg-warning">Flex item 8</div>
    <div class="p-2 bg-primary">Flex item 9</div>
    <div class="p-2 bg-info">Flex item 10</div>
    <div class="p-2 bg-warning">Flex item 11</div>
    <div class="p-2 bg-primary">Flex item 12</div>
    <div class="p-2 bg-info">Flex item 13</div>
    <div class="p-2 bg-warning">Flex item 14</div>
    <div class="p-2 bg-primary">Flex item 15</div>			  
</div>
<div class="d-flex flex-wrap p-2 mb-2 bg-secondary text-white">
    <div class="p-2 bg-info">Flex item 1</div>
    <div class="p-2 bg-warning">Flex item 2</div>
    <div class="p-2 bg-primary">Flex item 3</div>
    <div class="p-2 bg-info">Flex item 4</div>
    <div class="p-2 bg-warning">Flex item 5</div>
    <div class="p-2 bg-primary">Flex item 6</div>
    <div class="p-2 bg-info">Flex item 7</div>
    <div class="p-2 bg-warning">Flex item 8</div>
    <div class="p-2 bg-primary">Flex item 9</div>
    <div class="p-2 bg-info">Flex item 10</div>
    <div class="p-2 bg-warning">Flex item 11</div>
    <div class="p-2 bg-primary">Flex item 12</div>
    <div class="p-2 bg-info">Flex item 13</div>
    <div class="p-2 bg-warning">Flex item 14</div>
    <div class="p-2 bg-primary">Flex item 15</div>
</div>
<div class="d-flex flex-wrap-reverse p-2 mb-2 bg-secondary text-white">
    <div class="p-2 bg-info">Flex item 1</div>
    <div class="p-2 bg-warning">Flex item 2</div>
    <div class="p-2 bg-primary">Flex item 3</div>
    <div class="p-2 bg-info">Flex item 4</div>
    <div class="p-2 bg-warning">Flex item 5</div>
    <div class="p-2 bg-primary">Flex item 6</div>
    <div class="p-2 bg-info">Flex item 7</div>
    <div class="p-2 bg-warning">Flex item 8</div>
    <div class="p-2 bg-primary">Flex item 9</div>
    <div class="p-2 bg-info">Flex item 10</div>
    <div class="p-2 bg-warning">Flex item 11</div>
    <div class="p-2 bg-primary">Flex item 12</div>
    <div class="p-2 bg-info">Flex item 13</div>
    <div class="p-2 bg-warning">Flex item 14</div>
    <div class="p-2 bg-primary">Flex item 15</div>
</div>
```

**内容对齐**

我们可以使用 .align-content-* 来控制在垂直方向上如何去堆叠子元素，包含的值有：

.align-content-start (默认), .align-content-end, .align-content-center, .align-content-between, 

.align-content-around 和 .align-content-stretch。

这些类在只有一行的弹性子元素中是无效的。

```
<div class="d-flex p-2 mb-2 flex-wrap align-content-start bg-secondary text-white" style="height: 200px;">
    <div class="p-2 bg-info">Flex item 1</div>
    <div class="p-2 bg-warning">Flex item 2</div>
    <div class="p-2 bg-primary">Flex item 3</div>
    <div class="p-2 bg-info">Flex item 4</div>
    <div class="p-2 bg-warning">Flex item 5</div>
    <div class="p-2 bg-primary">Flex item 6</div>
    <div class="p-2 bg-info">Flex item 7</div>
    <div class="p-2 bg-warning">Flex item 8</div>
    <div class="p-2 bg-primary">Flex item 9</div>
    <div class="p-2 bg-info">Flex item 10</div>
    <div class="p-2 bg-warning">Flex item 11</div>
    <div class="p-2 bg-primary">Flex item 12</div>
    <div class="p-2 bg-info">Flex item 13</div>
    <div class="p-2 bg-warning">Flex item 14</div>
    <div class="p-2 bg-primary">Flex item 15</div>			  
</div>
<div class="d-flex p-2 mb-2 flex-wrap align-content-end bg-secondary text-white" style="height: 200px;">
    <div class="p-2 bg-info">Flex item 1</div>
    <div class="p-2 bg-warning">Flex item 2</div>
    <div class="p-2 bg-primary">Flex item 3</div>
    <div class="p-2 bg-info">Flex item 4</div>
    <div class="p-2 bg-warning">Flex item 5</div>
    <div class="p-2 bg-primary">Flex item 6</div>
    <div class="p-2 bg-info">Flex item 7</div>
    <div class="p-2 bg-warning">Flex item 8</div>
    <div class="p-2 bg-primary">Flex item 9</div>
    <div class="p-2 bg-info">Flex item 10</div>
    <div class="p-2 bg-warning">Flex item 11</div>
    <div class="p-2 bg-primary">Flex item 12</div>
    <div class="p-2 bg-info">Flex item 13</div>
    <div class="p-2 bg-warning">Flex item 14</div>
    <div class="p-2 bg-primary">Flex item 15</div>			  
</div>
<div class="d-flex p-2 mb-2 flex-wrap align-content-center bg-secondary text-white" style="height: 200px;">
    <div class="p-2 bg-info">Flex item 1</div>
    <div class="p-2 bg-warning">Flex item 2</div>
    <div class="p-2 bg-primary">Flex item 3</div>
    <div class="p-2 bg-info">Flex item 4</div>
    <div class="p-2 bg-warning">Flex item 5</div>
    <div class="p-2 bg-primary">Flex item 6</div>
    <div class="p-2 bg-info">Flex item 7</div>
    <div class="p-2 bg-warning">Flex item 8</div>
    <div class="p-2 bg-primary">Flex item 9</div>
    <div class="p-2 bg-info">Flex item 10</div>
    <div class="p-2 bg-warning">Flex item 11</div>
    <div class="p-2 bg-primary">Flex item 12</div>
    <div class="p-2 bg-info">Flex item 13</div>
    <div class="p-2 bg-warning">Flex item 14</div>
    <div class="p-2 bg-primary">Flex item 15</div>			  
</div>
<div class="d-flex p-2 mb-2 flex-wrap align-content-around bg-secondary text-white" style="height: 200px;">
    <div class="p-2 bg-info">Flex item 1</div>
    <div class="p-2 bg-warning">Flex item 2</div>
    <div class="p-2 bg-primary">Flex item 3</div>
    <div class="p-2 bg-info">Flex item 4</div>
    <div class="p-2 bg-warning">Flex item 5</div>
    <div class="p-2 bg-primary">Flex item 6</div>
    <div class="p-2 bg-info">Flex item 7</div>
    <div class="p-2 bg-warning">Flex item 8</div>
    <div class="p-2 bg-primary">Flex item 9</div>
    <div class="p-2 bg-info">Flex item 10</div>
    <div class="p-2 bg-warning">Flex item 11</div>
    <div class="p-2 bg-primary">Flex item 12</div>
    <div class="p-2 bg-info">Flex item 13</div>
    <div class="p-2 bg-warning">Flex item 14</div>
    <div class="p-2 bg-primary">Flex item 15</div>			  
</div>
<div class="d-flex p-2 mb-2 flex-wrap align-content-stretch bg-secondary text-white" style="height: 200px;">
    <div class="p-2 bg-info">Flex item 1</div>
    <div class="p-2 bg-warning">Flex item 2</div>
    <div class="p-2 bg-primary">Flex item 3</div>
    <div class="p-2 bg-info">Flex item 4</div>
    <div class="p-2 bg-warning">Flex item 5</div>
    <div class="p-2 bg-primary">Flex item 6</div>
    <div class="p-2 bg-info">Flex item 7</div>
    <div class="p-2 bg-warning">Flex item 8</div>
    <div class="p-2 bg-primary">Flex item 9</div>
    <div class="p-2 bg-info">Flex item 10</div>
    <div class="p-2 bg-warning">Flex item 11</div>
    <div class="p-2 bg-primary">Flex item 12</div>
    <div class="p-2 bg-info">Flex item 13</div>
    <div class="p-2 bg-warning">Flex item 14</div>
    <div class="p-2 bg-primary">Flex item 15</div>			  
</div>
```

**子元素对齐**

如果要设置单行的子元素对齐可以使用 .align-items-* 类来控制，包含的值有：

.align-items-start, .align-items-end, .align-items-center, .align-items-baseline(第一行文字底部对齐), 

和 .align-items-stretch (默认)。

```
<div class="d-flex p-2 mb-2 flex-wrap align-items-start bg-secondary text-white" style="height: 100px;">
    <div class="p-2 bg-info">Flex item 1</div>
    <div class="p-2 bg-warning">Flex item 2</div>
    <div class="p-2 bg-primary">Flex item 3</div>			  
</div>	
<div class="d-flex p-2 mb-2 flex-wrap align-items-end bg-secondary text-white" style="height: 100px;">
    <div class="p-2 bg-info">Flex item 1</div>
    <div class="p-2 bg-warning">Flex item 2</div>
    <div class="p-2 bg-primary">Flex item 3</div>			  
</div>
<div class="d-flex p-2 mb-2 flex-wrap align-items-center bg-secondary text-white" style="height: 100px;">
    <div class="p-2 bg-info">Flex item 1</div>
    <div class="p-2 bg-warning">Flex item 2</div>
    <div class="p-2 bg-primary">Flex item 3</div>			  
</div>
<div class="d-flex p-2 mb-2 flex-wrap align-items-baseline bg-secondary text-white" style="height: 100px;">
    <div class="p-2 bg-info">Flex item 1</div>
    <div class="p-2 bg-warning">Flex item 2</div>
    <div class="p-2 bg-primary">Flex item 3</div>			  
</div>
<div class="d-flex p-2 mb-2 flex-wrap align-items-stretch bg-secondary text-white" style="height: 100px;">
    <div class="p-2 bg-info">Flex item 1</div>
    <div class="p-2 bg-warning">Flex item 2</div>
    <div class="p-2 bg-primary">Flex item 3</div>			  
</div>
```

**指定子元素对齐**

如果要设置指定子元素对齐对齐可以使用 .align-self-* 类来控制，包含的值有：

.align-self-start, .align-self-end, .align-self-center, .align-self-baseline, 和 .align-self-stretch (默认)。

```
<div class="d-flex p-2 mb-2 bg-secondary text-white" style="height: 100px;">
    <div class="p-2 bg-info align-self-start">Flex item 1</div>
    <div class="p-2 bg-warning align-self-end">Flex item 2</div>
    <div class="p-2 bg-primary align-self-center">Flex item 3</div>			 
</div>
```

**响应式flex类**

我们可以根据不同的设备，设置 flex 类，从而实现页面响应式布局，以下表格中的 * 号可以的值有：sm, md, lg 

或 xl, 对应的是小型设备、中型设备，大型设备，超大型设备。 

| 弹性容器           |                                        |
| ------------------ | -------------------------------------- |
| `.d-*-flex`        | 根据不同的屏幕设备创建弹性盒子容器     |
| `.d-*-inline-flex` | 根据不同的屏幕设备创建行内弹性盒子容器 |

| 方向                     |                                                        |
| ------------------------ | ------------------------------------------------------ |
| `.flex-*-row`            | 根据不同的屏幕设备在水平方向显示弹性子元素             |
| `.flex-*-row-reverse`    | 根据不同的屏幕设备在水平方向显示弹性子元素，且右对齐   |
| `.flex-*-column`         | 根据不同的屏幕设备在垂直方向显示弹性子元素             |
| `.flex-*-column-reverse` | 根据不同的屏幕设备在垂直方向显示弹性子元素，且方向相反 |

| 内容对齐                     |                                                   |
| ---------------------------- | ------------------------------------------------- |
| `.justify-content-*-start`   | 根据不同屏幕设备在开始位置显示弹性子元素 (左对齐) |
| `.justify-content-*-end`     | 根据不同屏幕设备在尾部显示弹性子元素 (右对齐)     |
| `.justify-content-*-center`  | 根据不同屏幕设备在 flex 容器中居中显示子元素      |
| `.justify-content-*-between` | 根据不同屏幕设备使用 "between" 显示弹性子元素     |
| `.justify-content-*-around`  | 根据不同屏幕设备使用 "around" 显示弹性子元素      |

| 等宽           |                            |
| -------------- | -------------------------- |
| `.flex-*-fill` | 根据不同的屏幕设备强制等宽 |

| 扩展             |                          |
| ---------------- | ------------------------ |
| `.flex-*-grow-0` | 不同的屏幕设备不设置扩展 |
| `.flex-*-grow-1` | 不同的屏幕设备设置扩展   |

| 收缩               |                          |
| ------------------ | ------------------------ |
| `.flex-*-shrink-0` | 不同的屏幕设备不设置收缩 |
| `.flex-*-shrink-1` | 不同的屏幕设备设置收缩   |

| 包裹                   |                              |
| ---------------------- | ---------------------------- |
| `.flex-*-nowrap`       | 不同的屏幕设备不设置包裹元素 |
| `.flex-*-wrap`         | 不同的屏幕设备设置包裹元素   |
| `.flex-*-wrap-reverse` | 不同的屏幕设备反转包裹元素   |

| 内容排列                   |                                          |
| -------------------------- | ---------------------------------------- |
| `.align-content-*-start`   | 根据不同屏幕设备在起始位置堆叠元素       |
| `.align-content-*-end`     | 根据不同屏幕设备在结束位置堆叠元素       |
| `.align-content-*-center`  | 根据不同屏幕设备在中间位置堆叠元素       |
| `.align-content-*-around`  | 根据不同屏幕设备，使用 "around" 堆叠元素 |
| `.align-content-*-stretch` | 根据不同屏幕设备，通过伸展元素来堆叠     |

| 元素对齐                  |                                                  |
| ------------------------- | ------------------------------------------------ |
| `.align-items-*-start`    | 根据不同屏幕设备，让元素在头部显示在同一行。     |
| `.align-items-*-end`      | 根据不同屏幕设备，让元素在尾部显示在同一行。     |
| `.align-items-*-center`   | 根据不同屏幕设备，让元素在中间位置显示在同一行。 |
| `.align-items-*-baseline` | 根据不同屏幕设备，让元素在基线上显示在同一行。   |
| `.align-items-*-stretch`  | 根据不同屏幕设备，让元素延展高度并显示在同一行。 |

| 单独一个子元素的对齐方式 |                                                |
| ------------------------ | ---------------------------------------------- |
| `.align-self-*-start`    | 据不同屏幕设备，让单独一个子元素显示在头部。   |
| `.align-self-*-end`      | 据不同屏幕设备，让单独一个子元素显示在尾部     |
| `.align-self-*-center`   | 据不同屏幕设备，让单独一个子元素显示在居中位置 |
| `.align-self-*-baseline` | 据不同屏幕设备，让单独一个子元素显示在基线位置 |
| `.align-self-*-stretch`  | 据不同屏幕设备，延展一个单独子元素             |

## 三、多媒体

Bootstrap 提供了很好的方式来处理多媒体对象（图片或视频）和内容的布局。应用场景有博客评论、微博等。