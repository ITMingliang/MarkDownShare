# Form窗体

Windows应用程序也称为WinForm应用程序，通常包含一个或多个窗体，窗体中又包含了多种控件，如按钮、文本框等。

基于可视化的窗体和控件，用户能够较好的与应用程序进行交互。

开发Windows应用程序，推荐使用微软的Visual Studio集成开发工具，它提供了带有拖放控件功能的可视化设计器，实现了所见即所。

![0001](img\0001.PNG)

## 一、创建第一个Windows Form应用程序

功能需求如下图，点击第一张图片的按钮，程序切换成第二张图的状态，在左侧显示Hello World!

![0002](img\0002.PNG)

![0003](img\0003.PNG)

实现步骤：

（1）新建项目，并且选择语言为"C#",项目类型选择为"windows 窗体应用程序"。

（2）在工具箱中，分别找到Label控件和Button控件，分别拖入放置到窗体的左边和右边。

（3）将Label控件的Text属性设置为空字符串，将Button控件的Text属性设置为"显示"。

（4）在按钮上进行双击，切换到代码视图，编写如下代码：

```
private void button1_Click(object sender, EventArgs e)
{
	//单击按钮，将自动调用本方法处理
	this.Label1.Text = “Hello World!”;
}
```

（5）选择"调试--》开始执行"菜单运行程序。

## 二、Form窗体

Form窗体是Windows应用程序的基本单元。

Form窗体不仅是一个窗口，还是一个容器，窗体内可以放置各种控件来实现各种功能。

窗体的添加，删除操作均可以在资源管理器中进行管理，通过鼠标右键进行操作。

**（1）窗体的常用属性如下：**

Icon属性：设置窗体图标。

Text属性：设置窗体标题。

MaximizeBox:禁用窗体最大化按钮。

MinimizeBox:禁用窗体最小化按钮。

FormBorderStyle属性：设置窗体的边框样式（窗体是否固定也通过此属性设置）。

StartPosition属性：设置窗体首次出现的位置。

WindowState属性：设置窗体的初始可视状态。

TopMost属性：是否设置最前端窗口显示。

BackColor属性：设置窗体的背景颜色。

BackgroundImage属性：设置窗体背景图片。

BackgroundImageLayout属性：背景图片的布局方式。

ShowInTaskbar属性：是否在任务栏显示窗体。

**（2）窗体的常用事件：**

Load事件：窗体加载事件

Click事件：窗体单击事件

FormClosing事件：窗体关闭事件（关闭前触发）

**制作窗体关闭的确定取消效果：**

![0005](img\0005.PNG)

```
//制作窗体关闭的是否确定询问
//如果想窗体无法关闭，可以在代码中直接编写e.Cancel = true;
private void Form1_FormClosing(object sender, FormClosingEventArgs e)
{
    DialogResult result = MessageBox.Show("确定要关闭本窗体吗？","提示：	", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    
    if (result == DialogResult.Yes)
    {
      	//如果用户选择了“是”，继续执行关闭事件，关闭窗体
    }
    else
    {
        //如果用户选择了“否”，取消窗体关闭事件
        e.Cancel = true;
    }
 }
```



## 三、多窗体应用

完整的Windows应用程序通常具有多个业务模块，不可能在一个窗体界面内实现。

实现这些业务模块需要多个窗体界面，在每个窗体界面中实现相应的功能。

**项目中有多个窗体时，从哪个窗体开始运行？**

​	从项目的启动窗体开始运行

​	启动窗体在Program类的Main()方法中使用Application.Run(窗体对象)进行设置

**在多窗体应用中，窗体间应如何相互调用？** 

​	使用new关键字创建窗体对象

​	使用窗体对象.Show()或窗体对象.ShowDialog()弹出窗体

**Show()与ShowDialog()的区别：**

​	Show弹出的是非模式窗体，非模式窗体弹出时，仍能对其他窗体进行操作。

​	ShowDialog弹出的是模式窗体，模式窗体弹出时，无法对其他窗体进行操作，直至模式窗体被关闭。

**多文档界面MDI窗体，如下图：**

![0004](img\0004.PNG)

**多文档界面（MDI）的应用程序有以下特点：**

（1）每个应用程序中只能有一个MDI父窗体，在父窗体中可以打开多个MDI子窗体。

（2）任何MDI子窗体都只能在父窗体内部区域活动。

（3）当关闭任何子窗体时，对其他打开的子窗体以及父窗体均没有任何影响。

（4）当关闭父窗体时，将关闭所有打开的子窗体。

**实现MDI应用程序，分为以下四个步骤：**

（1）创建一个Windows应用程序

（2）创建多个Form窗体

（3）设置MDI父窗体（设置父窗体IsMdiContainer属性为true）

（4）设置并显示子窗体（假设父窗体名为MainForm,两个子窗体名为form1和form2）,代码如下：

```
private void MainForm_Load(object sender, EventArgs e)
{
    //创建Form1窗体对象并显示窗体
    Form1 form1 = new Form1();
    form1.Show();
    //设置Form1窗体为MDI子窗体，并置于MainForm父窗体容器内
    form1.MdiParent = this;

    Form2 form2 = new Form2();
    form2.Show();
    form2.MdiParent = this;
}
```

## 四、娱乐一下：无法被拒绝的表白

功能需求如下：

![0036](img\0036.PNG)

（1）当用户鼠标移动到按钮上，如果移动到"是的"按钮，不做任务处理，如果移动到"不是"按钮，则把两个按钮的显示文本进行互换。

（2）当用户点击右上角"关闭"按钮的时候，提示"关闭窗口也改变不了你喜欢我的事实！",并且阻止窗体的关闭。

（3）当用户点击两个按钮中任意一个的时候，提示"就知道你喜欢我！",并且退出程序。

实现步骤：

（1）创建窗体，调整至合适大小，选择一个适合的icon图标。

（2）设置窗体的MaximizeBox和MinimizeBox属性为false，去掉窗体最大化，最小化按钮。

（3）拖入控件，进行界面绘制（其中第一个按钮name=bt1,第二个按钮name=bt2）。

![0036](img\0036.PNG)

（4）在窗体的FormClosing事件中编写代码，阻止用户关闭窗体:

```
private void Form1_FormClosing(object sender, FormClosingEventArgs e)
{
    //判断是否用户点击关闭按钮
    if(e.CloseReason == CloseReason.UserClosing)
    {
        MessageBox.Show("关闭窗口也改变不了你喜欢我的事实！");
        e.Cancel = true;
    }
}
```

（5）分别为两个按钮的MouseEnter事件编写代码，判断按钮上的文本，进行文本的切换。

```
private void bt1_MouseEnter(object sender, EventArgs e)
{
    if (this.bt1.Text.Equals("不  是"))
    {
        this.bt1.Text = "是  的";
        this.bt2.Text = "不  是";
    }
}
private void bt2_MouseEnter(object sender, EventArgs e)
{
    if (this.bt2.Text.Equals("不  是"))
    {
        this.bt2.Text = "是  的";
        this.bt1.Text = "不  是";
    }
}
```

（6）分别为两个按钮的Click事件编写代码，实现用户点击之后的提示效果，并且退出程序。

```
private void bt1_Click(object sender, EventArgs e)
{
    MessageBox.Show("就知道你喜欢我！");
    Application.Exit();
}
private void bt2_Click(object sender, EventArgs e)
{
    MessageBox.Show("就知道你喜欢我！");
    Application.Exit();
}
```

## 五、Close()和Application.Exit()

在单窗体项目中，调用Close()和Application.Exit()可以起到相同的效果，都是退出整个应用程序，因为关闭启动窗体即认为关闭了整个程序。

但是在多窗体项目中，Close()代表关闭某个窗体，而Application.Exit()代表退出整个应用程序。

**案例：**

制作一个登陆窗体，点击登录按钮即直接打开程序另外一个窗体（此处跳过省略验证用户名密码的验证），并将登录窗体隐藏起来。

![0050](img\0050.PNG)

![0051](img\0051.PNG)

登录按钮代码：

```
FrmMain frm = new FrmMain();
frm.Show();
this.Hide();
```

问题：按照此种方式进行编码，虽然可以实现效果，但是当我们点击第二个弹出来的窗体的关闭按钮，我们会认为我们自己关闭了整个应用程序，但是实际上应用程序仍然在计算机后台在运行，在Windows资源管理器中能够查看的到，因为登录窗体作为启动窗体，只是隐藏了，并没有关闭，所以应用程序并没有退出。

为了解决此问题，我们可以在登录之后的第二个窗体的FormClosed事件中添加代码：

```
Application.Exit();
```

即表示，当我关闭登录之后弹出的窗体之后，将整个应用程序退出。

