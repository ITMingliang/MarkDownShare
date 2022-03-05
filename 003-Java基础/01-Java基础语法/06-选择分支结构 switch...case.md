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

- switch 语句中的变量类型可以是： byte、short、int 或者 char。从 Java SE 7 开始，switch 支持字符串 String 类型了，同时 case 标签必须为字符串常量或字面量。
- switch 语句可以拥有多个 case 语句。每个 case 后面跟一个要比较的值和冒号。
- case 语句中的值的数据类型必须与变量的数据类型相同，而且只能是常量或者字面常量。
- 当变量的值与 case 语句的值相等时，那么 case 语句之后的语句开始执行，直到 break 语句出现才会跳出 switch 语句。
- 当遇到 break 语句时，switch 语句终止。程序跳转到 switch 语句后面的语句执行。case 语句不必须要包含 break 语句。如果没有 break 语句出现，程序会继续执行下一条 case 语句，直到出现 break 语句。
- switch 语句可以包含一个 default 分支，该分支一般是 switch 语句的最后一个分支（可以在任何位置，但建议在最后一个）。default 在没有 case 语句的值和变量值相等的时候执行。default 分支不需要 break 语句。

**举例：**

使用switch-case语句来判断用户输入的星期几，根据星期几来打印当天的课程信息，课程信息如下：

星期一：语文、体育、英语
星期二：数学、化学、计算机
星期三：政治、历史、物理
星期四：语文、数学、英语
星期五：计算机、英语、美术
星期六和星期天：休息

```
Scanner input = new Scanner(System.in);
System.out.println("请输入星期几:");
int weekday = input.nextInt();
switch(weekday)
{
	case 1:
		System.out.println("语文、体育、英语"); break;
	case 2:
		System.out.println("数学、化学、计算机"); break;
	case 3:
		System.out.println("政治、历史、物理"); break;
	case 4:
		System.out.println("语文、数学、英语"); break;
	case 5:
		System.out.println("计算机、英语、美术"); break;
	case 6:
	case 7:
		System.out.println("休息"); break;
	default:
		System.out.println("你是外星人吧!");
}
```

