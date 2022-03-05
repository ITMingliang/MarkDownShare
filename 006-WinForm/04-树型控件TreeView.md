# 树型控件TreeView

## 一、树型控件TreeView概述：

（1）用于显示具有层次结构的数据

（2）由层叠的节点（Node）分支构成，每个节点由图像和标签组成

（3）每个TreeView控件均包含一个或多个根节点，根节点下面包含多个子节点，子节点下面还可以包含子节点。

（4）包含子节点的节点可以展开或折叠

![0014](img\0014.PNG)

**TreeView控件的常用属性：**

| **属性**          | **说明**                                                  |
| ----------------- | --------------------------------------------------------- |
| Name              | 获取或设置控件的名称                                      |
| Dock              | 控件在父容器中的停靠方式                                  |
| Nodes             | TreeView控件根节点集合                                    |
| SelectedNode      | 获取或设置当前TreeView控件中选定的树节点                  |
| ImageList         | 获取或设置TreeView中所使用的图像集，关联ImageList控件     |
| ImageIndex        | 获取或设置树节点显示的图像在ImageList图像集中的索引       |
| SelectedImgeIndex | 获取或设置节点被选中时显示的图像在ImageList图像集中的索引 |

**TreeView控件的常用事件：**

| **事件**      | **说明**                 |
| ------------- | ------------------------ |
| AfterCollapse | 在折叠树节点后触发       |
| AfterExpand   | 在展开树节点后触发       |
| AfterSelect   | 在更改选中节点后触发     |
| Click         | 在点击TreeView控件时触发 |

注意：

（1）对TreeView控件的操作，其本质是对树节点的操作。

（2）无论是根节点，还是子节点都是TreeNode对象。



## 二、添加、删除树节点：

示例：使用TreeView展示学校的专业以及专业下的课程。

添加树节点有两种方式实现：

（1）在TreeNode编辑器中添加、删除树节点

（2）通过代码添加、删除树节点

**使用TreeNode编辑器添加删除树节点操作步骤：**

实现步骤：

（1）添加窗体“TreeViewForm”，并向其中拖入TreeView控件。

（2）选中TreeView控件，点击右上角的小三角图标，弹出快捷菜单。

（3）点击“编辑节点”，打开“TreeNode编辑器”，按层级关系添加树节点，同时也可以删除树节点。

**通过代码添加树节点：**

实现步骤：

（1）创建窗体，向其中拖入TreeView控件。

（2）设置TreeView在父容器中停靠，name属性为tv_tencent。

（3）为窗体添加Load事件，在事件处理函数中编码添加树节点，描述腾讯公司管理团队成员的信息。

```
//方案一：使用TreeNode对象进行添加节点
private void TreeViewForm1_Load(object sender, EventArgs e)
{
    //创建根节点
    TreeNode root = new TreeNode("武汉**********学院");
    //将根节点添加至TreeView控件上
    this.tvSchool.Nodes.Add(root);
    //创建专业节点
    TreeNode tnPro1 = new TreeNode("计算机技术");
    TreeNode tnPro2 = new TreeNode("电子商务");
    //将专业节点添加至根节点
    root.Nodes.Add(tnPro1);
    root.Nodes.Add(tnPro2);
    //创建课程节点
    TreeNode tnCourse1 = new TreeNode("C#");
    TreeNode tnCourse2 = new TreeNode("SQL SERVER");
    TreeNode tnCourse3 = new TreeNode("搜索引擎优化");
    TreeNode tnCourse4 = new TreeNode("网络营销推广");
    //将课程节点添加至专业节点
    tnPro1.Nodes.Add(tnCourse1);
    tnPro1.Nodes.Add(tnCourse2);
    tnPro2.Nodes.Add(tnCourse3);
    tnPro2.Nodes.Add(tnCourse4);
    //展开TreeView的所有节点
    this.tvSchool.ExpandAll();
}
//方案二：使用键值对的方式进行添加节点
private void TreeViewForm1_Load(object sender, EventArgs e)
{
    this.tvSchool.Nodes.Add("001", "武汉**********学院");
    this.tvSchool.Nodes["001"].Nodes.Add("001001", "计算机技术");
    this.tvSchool.Nodes["001"].Nodes.Add("001002", "电子商务");
    this.tvSchool.Nodes["001"].Nodes["001001"].Nodes.Add("001001001","C#");
    this.tvSchool.Nodes["001"].Nodes["001001"].Nodes.Add("001001002", "SQL SERVER");
    this.tvSchool.Nodes["001"].Nodes["001002"].Nodes.Add("001002001", "搜索引擎优化");
    this.tvSchool.Nodes["001"].Nodes["001002"].Nodes.Add("001002002", "网络营销推广");
    this.tvSchool.ExpandAll();
}
```

**通过代码删除树节点：**

例如在上面添加的节点中删除"搜索引擎优化"节点

```
//通过节点对象删除
this.tvSchool.Nodes.Remove(tnCourse3);
//通过索引下标删除
this.tvSchool.Nodes[0].Nodes[1].Nodes.RemoveAt(0);
//通过键删除节点
this.tvSchool.Nodes["001"].Nodes["001002"].Nodes.RemoveByKey("001002001");
```



## 三、管理节点图标：

需要在TreeView的节点中使用图标，我们需要借助ImageList控件，所以我们首先需要做如下操作：

（1）向窗体中添加ImageList控件，向ImageList控件中添加需要的图片。

（2）将ImageList控件与TreeView控件进行关联，即设置TreeView控件的ImageList属性。

给节点设置图标有两种情况：

（1）所有节点图标都一样：

此时直接在属性栏中或者通过代码找到TreeView控件，设置ImageIndex属性和SelectedImageIndex属性指定图片在ImageList中的索引标号，来设置所有节点正常情况和选中情况下的图片索引。

（2）节点的图标不一致：

​	【1】通过编辑器添加的节点，直接在编辑中为每个节点设置ImageIndex属性和SelectedImageIndex属性。

​	【2】通过代码，使用TreeNode对象添加的节点，在代码中为每个TreeNode设置ImageIndex属性和SelectedImageIndex属性。下面代码只为一个节点添加了图标，其他节点省略。。。

```
//方案一：
TreeNode root = new TreeNode("武汉**********学院",0,1);
//方案二：
TreeNode root = new TreeNode("武汉**********学院");
root.ImageIndex = 0;
root.SelectedImageIndex = 1;
```

​	【3】通过代码，使用键值对的方式添加的节点，在代码中为每个TreeNode设置ImageIndex属性和SelectedImageIndex属性。下面代码只为一个节点添加了图标，其他节点省略。。。

```
//方案一：
this.tvSchool.Nodes.Add("001", "武汉**********学院",0,1);
//方案二：
this.tvSchool.Nodes.Add("001", "武汉**********学院");
this.tvSchool.Nodes["001"].ImageIndex = 0;
this.tvSchool.Nodes["001"].SelectedImageIndex = 1;
```

## 四、响应事件，获取选中节点

为TreeView控件添加AfterSelect事件，节点被选中后触发，在事件处理函数中，获取选中节点，并提示其标签文本值和key。

```
TreeNode selectedNode = this.tvSchool.SelectedNode;
//如果在添加节点的时候，并不是以键值对的方式添加的或者没有设置Name值，那么selectedNode.Name里面是空字符串
MessageBox.Show(selectedNode.Text + "," + selectedNode.Name);
```

