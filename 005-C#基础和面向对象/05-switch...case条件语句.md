# 选择分支结构 switch...case

switch case 语句判断一个变量与一系列值中某个值是否相等，每个值称为一个分支。 

语法：

```
switch(expression){
    case value :
       //语句
       break; //可选
    case value :
       //语句
       break; //可选
    //你可以有任意数量的case语句
    default : //可选
       //语句
}
```

 **switch case 语句有如下规则：** 

- switch 语句中的变量类型可以是： bool,char,string,int,enum或可以自动转成其类型的类型。
- switch 语句可以拥有多个 case 语句。每个 case 后面跟一个要比较的值和冒号。
- case 语句中的值的数据类型必须与变量的数据类型相同，而且只能是常量或者字面常量。
- 当变量的值与 case 语句的值相等时，那么 case 语句之后的语句开始执行，直到 break 语句出现才会跳出 switch 语句。
- 当遇到 break 语句时，switch 语句终止。程序跳转到 switch 语句后面的语句执行。
- switch 语句可以包含一个 default 分支，该分支一般是 switch 语句的最后一个分支（可以在任何位置，但建议在最后一个）。default 在没有 case 语句的值和变量值相等的时候执行。

**举例：**

使用switch-case语句来判断用户输入的星期几，根据星期几来打印当天的课程信息，课程信息如下：

星期一：语文、体育、英语
星期二：数学、化学、计算机
星期三：政治、历史、物理
星期四：语文、数学、英语
星期五：计算机、英语、美术
星期六和星期天：休息

```
Console.WriteLine("请输入星期几:");
int day = int.Parse(Console.ReadLine());
switch (day)
{
    case 1:
    	Console.WriteLine("语文、体育、英语"); break;
    case 2:
    	Console.WriteLine("数学、化学、计算机"); break;
    case 3:
    	Console.WriteLine("政治、历史、物理"); break;
    case 4:
    	Console.WriteLine("语文、数学、英语"); break;
    case 5:
    	Console.WriteLine("计算机、英语、美术"); break;
    case 6:
    case 7:
    	Console.WriteLine("休息"); break;
    default:
    	Console.WriteLine("输入错误!"); break;
}
```

