# 列表视图ListView

**ListView控件的常用属性：**

| **属性**       | **说明**                                |
| -------------- | --------------------------------------- |
| Name           | 控件的名称                              |
| Dock           | 控件在父容器中的停靠方式                |
| Items          | 包含控件中所有项的集合                  |
| Columns        | 控件中显示的所有列标题的集合            |
| View           | 控件的显示视图                          |
| LargeImageList | 当控件以大图标视图显示时使用的ImageList |
| SmallImageList | 当控件以小图标视图显示时使用的ImageList |
| GridLines      | 在包含控件中的行和列之间是否显示网格线  |
| MultiSelect    | 是否可以选择多项                        |
| SelectedItems  | 获取在控件选定的项                      |
| FullRowSelect  | 单击某项是否选择其所有子项              |

**ListView控件的常用方法：**

| **方法** | **说明**                             |
| -------- | ------------------------------------ |
| Clear    | 从控件中移除所有项和列，清空ListView |

**ListView控件的常用事件：**

| **事件**             | **说明**                 |
| -------------------- | ------------------------ |
| Click                | 在单击ListView控件时触发 |
| SelectedIndexChanged | 当选定项发生更改时触发   |

**ListView控件具有5种显示视图，由View属性设置，View属性的值及说明见下表：**

| **属性值**          | **说明**                               |
| ------------------- | -------------------------------------- |
| Details             | 详细视图，标准的二维表格，第一行为表头 |
| LargeIcon（默认值） | 大图标，每一项显示为一个大图标         |
| SmallIcon           | 小图标，每一项显示为一个小图标         |
| List                | 列表，每项显示一行                     |
| Tile                | 平铺，显示大图标，并在右侧显示详细信息 |

（1）详细视图（Details）

![0015](img\0015.png)

（2）大图标（LargeIcon）

![0016](img\0016.png)

（3）小图标（SmallIcon）

![0017](img\0017.png)

（4）列表（List）

![0018](img\0018.png)

（5）平铺（Tile）

![0019](img\0019.png)

**ListView的结构：**

（1）ListView控件可以展示多项数据，Items属性表示所有项的集合。

（2）其中每一项均为ListViewItem对象。

（3）每个ListViewItem对象中包含SubItems属性表示该项中所有子项的集合。

（4）其中每个子项均为ListViewSubItem对象。

## 一、给ListView添加删除项目

示例：使用ListView控件展示游戏人物的信息。

采用两种方法分别实现此功能：

（1）使用ListView编辑器添加，删除项。  

（2）使用代码为ListView添加，删除项。

**使用ListViewItem集合编辑器添加，删除项：**

实现步骤：

（1）创建窗体，并向其中拖入ListView控件

（2）设置ListView控件的Dock属性在父容器中停靠。

（3）向ListView控件中添加，删除列（点击右上角三角，编辑列）。

（4）设置ListView控件的显示视图为Detail，此时可以看到列标题

（5）向ListView控件中添加，删除项（点击右上角三角，编辑项）

（6）添加ListViewItem项目，在text属性中设置第一列内容，在SubItems里面设置后续列内容。

注意：如果该项数据有图片

（1）需要拖入两个ImageList控件，分别存储大图标和小图标的图片。

（2）点击ListView控件右上角三角，将ListView控件与两个ImageList控件关联。

（3）然后直接在该项ListViewItem上设置ImageIndex属性设置图片的索引。

特别注意：如果ListView与ImageList关联，ListView的Detail视图中的行高会随着小图标视图的ImageList的图像高度而改变。而且取消与ImageList的关联后也无法还原，此时可以通过设置ImageList的图像大小来控制行高。

**使用代码为ListViewItem添加项：**

实现步骤：

（1）创建窗体，并向其中拖入ListView控件

（2）设置ListView控件的Dock属性在父容器中停靠，name属性为lvTimi。

（3）向ListView控件中添加列（点击右上角三角，编辑列）。

（4）设置ListView控件的显示视图为Detail，此时可以看到列标题。

（5）在窗体加载时，编写代码为ListView添加项。

```
private void Form1_Load(object sender, EventArgs e)
{
    //创建ListViewItem对象，设置text值（第一列的值）
    ListViewItem item1 = new ListViewItem("安琪拉");
    item1.Name = "itemAjl"; //设置当前项的名字
    item1.ImageIndex = 0;  //设置图标索引
    //设置除第一列外其他列数据
    item1.SubItems.Add("超弱");
    item1.SubItems.Add("中等");
    item1.SubItems.Add("超强");
    item1.SubItems.Add("难");
    this.lvTimi.Items.Add(item1);
    //下面同理，添加其他项
    //......
}
```

**使用代码为ListViewItem删除项：**

```
//直接通过ListViewItem对象名删除
this.lvTimi.Items.Remove(item1);
//通过索引小标删除
this.lvTimi.Items.RemoveAt(0);
//通过键值对中的键删除，此处的键就是ListViewItem对象的name
this.lvTimi.Items.RemoveByKey("itemAjl");
```

## 二、响应事件，获取选中项目内容。

设置FullRowSelect属性为true，保证单击某项整行选中效果，选择ListView控件的DoubleClick（双击）事件,编写如下代码：

```
ListViewItem item = this.lvTimi.SelectedItems[0];
if (item == null)
	return;
string result = "";
result += "名字:" + item.Text + "\n";
result += "生存能力:" + item.SubItems[1].Text +"\n";
result += "攻击伤害:" + item.SubItems[2].Text + "\n";
result += "技能效果:" + item.SubItems[3].Text + "\n";
result += "上手难度:" + item.SubItems[4].Text + "\n";
MessageBox.Show(result);
```

## 三、结合右键实现删除以及视图切换

拖入ConTextMenuStrip控件，制作如下菜单，并设置ListView控件的ContextMenuStrip属性用来关联ListView控件和ContextMenuStrip控件：

![0020](img\0020.PNG)

删除菜单响应代码：

```
private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
{
    if (this.lvTimi.SelectedItems.Count == 0)
    {
        MessageBox.Show("您没有选中项目!");
        return;
    }
    ListViewItem item = this.lvTimi.SelectedItems[0];
    this.lvTimi.Items.Remove(item);
}
```

各种视图菜单响应代码：

```
private void 大图标ToolStripMenuItem_Click(object sender, EventArgs e)
{
	this.lvTimi.View = View.LargeIcon;
}

private void 小图标ToolStripMenuItem_Click(object sender, EventArgs e)
{
	this.lvTimi.View = View.SmallIcon;
}

private void 详细ToolStripMenuItem_Click(object sender, EventArgs e)
{
	this.lvTimi.View = View.Details;
}

private void 列表ToolStripMenuItem_Click(object sender, EventArgs e)
{
	this.lvTimi.View = View.List;
}

private void 平铺ToolStripMenuItem_Click(object sender, EventArgs e)
{
	this.lvTimi.View = View.Tile;
}
```

