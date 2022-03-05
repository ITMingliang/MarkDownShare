# 第一个Java程序

## 一、开发环境的搭建

开发环境快速搭建步骤：

（1）下载解压版eclipse,下载地址： https://www.eclipse.org/downloads/packages/ 

（2）将eclipse文件夹复制到自己希望的存放位置，建议不要放在桌面

（3）下载解压版JDK1.8或以上版本，然后将jdk文件夹中的jre文件夹复制一份到eclipse文件夹中。

（4）运行eclipse文件夹中的eclipse.exe文件，即可启动eclipse编程软件。

（5）启动eclipse软件后，会提示选择一个工作空间，此时选择一个自己希望存放代码的位置。此后默认情况下，你的代码将存放在你选择的工作空间中。

![2](img\2.PNG)

（6）点击“lanuch”按钮，进入开发环境主界面。

此时，恭喜你，开发环境就已经搭建完成了，下一步就是在开发环境中编写具体的代码了。

-----------------------

## 二、编写第一个Java程序"Hello,world!"

（1）打开开发环境，进入到eclipse主界面。

（2）在主界面中选择 File-->New-->Project，如下图

![3](img\3.png)

（3）在弹出的窗口中选择 Java-->Java Project,点击Next按钮，如下图：

![4](img\4.PNG)

（4）在Project name处输入自己的项目名称，并且选择对应的jdk版本为1.6版本，直接点击Finish完成Java项目的创建，如下图：



![5](img\5.PNG)

（5）此时在开发环境的左侧，项目管理器中会出现上一个步骤创建的项目，如下图所示：

![6](img\6.PNG)

（6）在src文件夹图标上 鼠标右键-->New-->Class,即可创建一个Java类文件。

（7）在Java类文件的 Name中输入类名，并且勾选 “public static void main”多选框，点击Finish按钮，如下图：

![7](img\7.PNG)

（8）此时eclipse会创建类文件，代码如下：

```
public class Demo01 {
	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}
}
```

（9）我们在main里面添加代码，如下，实现打印"hello,world!"

```
public class Demo01 {
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		System.out.println("hello,world!");
	}
}
```

（10）点击工具箱中的"run按钮"![8](img\8.PNG)，即可执行程序，程序结果会在eclipse底部的Console面板中显示。

备注：

（1）当第一次创建Java项目成功后，后面每次创建Java项目无需“File-->New-->Project”，然后在界面中选择项目类型，而可以直接"File-->New-->Java Project".

（2）在生成的代码文件中，main是程序的入口，无论代码如何编写，程序永远从main里面的第一行代码开始执行。

-------------------------------

版权所有：屌丝学编程。

