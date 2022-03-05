# 第一题

标题: 猜年龄

美国数学家维纳(N.Wiener)智力早熟，11岁就上了大学。他曾在1935~1936年应邀来中国清华大学讲学。

一次，他参加某个重要会议，年轻的脸孔引人注目。于是有人询问他的年龄，他回答说：“我年龄的立方是个4位

数。我年龄的4次方是个6位数。这10个数字正好包含了从0到9这10个数字，每个都恰好出现1次。”

请你推算一下，他当时到底有多年轻。

通过浏览器，直接提交他那时的年龄数字。

注意：不要提交解答过程，或其它的说明文字。

**解析：**

```
import java.util.HashSet;
import java.util.Set;
public class Demo01 {
	private static boolean CheckSame(String age3, String age4) 
	{
		String str = age3+age4;
		//Set的特点为不能插入重复内容
		Set<Character> set = new HashSet<Character>();
		for (int i = 0; i < str.length(); i++) {
			set.add(str.charAt(i));
		}
		return set.size() == 10;
	}
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		int age = 11;
		for(age=11;age<=100;age++)
		{
			String age3 = age*age*age+"";
			String age4 = age*age*age*age+"";
			if(age3.length()==4 && age4.length()==6 && CheckSame(age3,age4)==true)
			{
				System.out.println(age);
				break;
			}
		}
	}
}
```

```
执行结果：18
```

# 第二题

标题: 组素数

素数就是不能再进行等分的数。比如：2 3 5 7 11 等。9 = 3 * 3 说明它可以3等分，因而不是素数。

我们国家在1949年建国。如果只给你 1 9 4 9 这4个数字卡片，可以随意摆放它们的先后顺序（但卡片不能倒着摆

放啊，我们不是在脑筋急转弯！），那么，你能组成多少个4位的素数呢？

比如：1949，4919 都符合要求。

请你提交：能组成的4位素数的个数，不要罗列这些素数!!

注意：不要提交解答过程，或其它的辅助说明文字。

**解析：**

**方案一：使用四组循环进行嵌套所有情况**

```
import java.util.HashSet;
import java.util.Set;
public class Test {
	static Set<Integer> set = new HashSet<Integer>();
	public static void main(String[] args) 
	{
		int[] arr = new int[]{1,9,4,9};
		for (int a = 0; a < arr.length; a++) 
		{
			for (int b = 0; b < arr.length; b++) 
			{	if(b==a) continue;
				for (int c = 0; c < arr.length; c++) 
				{	if(c==a || c == b) continue;
					for (int d = 0; d < arr.length; d++) 
					{	if(d==a || d==b || d==c) continue;
						int num = arr[a]*1000+arr[b]*100+ arr[c]*10+arr[d];
						boolean isSushu = true; //假设是素数
						for (int i = 2; i <= Math.sqrt(num); i++) 
						{
							if(num%i==0)
							{
								isSushu = false;
								break;
							}
						}
						if(isSushu == true)
						{
							//System.out.println(num);
							set.add(num);
						}
					}
				}
			}
		}
		System.out.println(set.size());
	}	
}
```

```
执行结果：
6
```

**方案二：借助全排列的固定算法，如下：**

下面的代码可以将1，2，3，三个数字的所有排列组合进行打印。

```
public static void main(String[] args)
{
	int[] arr = new int[]{1,2,3};
	fullSort(arr,0,arr.length-1);
}
public static void fullSort(int[] arr,int start,int end)
{
	if(start == end)
	{
		for (int i = 0; i < arr.length; i++) {
			System.out.print(arr[i] + "\t");
		}
		System.out.println();
	}
	for (int i = start; i <=end; i++) {
		swap(arr,start,i);
		fullSort(arr,start+1,end);
		swap(arr,start,i);
	}
}
public static void swap(int[] arr,int i,int j)
{
	int temp = arr[i];
	arr[i] = arr[j];
	arr[j] = temp;
}
```

本题代码：

```
import java.util.HashSet;
import java.util.Set;
public class Demo02 {
	static Set<Integer> set = new HashSet<Integer>();
	public static void main(String[] args) 
	{
		int[] arr = new int[]{1,9,4,9};
		fullSort(arr,0,arr.length-1);
		System.out.println(set.size());
	}	
	public static void fullSort(int[] arr,int start,int end)
	{
		if(start == end)
		{
			int x = arr[0]*1000+arr[1]*100+arr[2]*10+arr[3];
			boolean isSushu = true; //假设是素数
			for (int i = 2; i <= Math.sqrt(x); i++) 
			{
				if(x%i==0)
				{
					isSushu = false;
					break;
				}
			}
			if(isSushu == true)
			{
				//System.out.println(x);
				set.add(x);
			}
		}
		for (int i = start; i <=end; i++) {
			swap(arr,start,i);
			fullSort(arr,start+1,end);
			swap(arr,start,i);
		}
	}
	public static void swap(int[] arr,int i,int j)
	{
		int temp = arr[i];
		arr[i] = arr[j];
		arr[j] = temp;
	}
}
```

```
执行结果：
6
```

# 第三题

标题: 马虎的算式

小明是个急性子，上小学的时候经常把老师写在黑板上的题目抄错了。

有一次，老师出的题目是：36 x 495 = ?，他却给抄成了：396 x 45 = ?

但结果却很戏剧性，他的答案竟然是对的！！因为 36 * 495 = 396 * 45 = 17820

类似这样的巧合情况可能还有很多，比如：27 * 594 = 297 * 54

假设 a b c d e 代表1~9不同的5个数字（注意是各不相同的数字，且不含0）

能满足形如： ab * cde = adb * ce 这样的算式一共有多少种呢？

请你利用计算机的优势寻找所有的可能，并回答不同算式的种类数。

满足乘法交换律的算式计为不同的种类，所以答案肯定是个偶数。

答案直接通过浏览器提交。

注意：只提交一个表示最终统计种类数的数字，不要提交解答过程或其它多余的内容。

**解析：**

**方案一：（循环嵌套法）**

```
int count = 0;
for (int a = 1; a <= 9; a++) {
	for (int b = 1; b <= 9; b++) {
		if(b == a) continue;
		for (int c = 1; c <= 9; c++) {
			if(c == a || c == b) continue;
			for (int d = 1; d <=9; d++) {
				if(d == a || d == b || d == c) continue;
				for (int e = 1; e <= 9; e++) {
					if(e == a || e == b || e == c || e == d) continue;
					if((a*10+b)*(c*100+d*10+e) == (a*100+d*10+b)*(c*10+e))
						count++;
				}
			}
		}
	}
}
System.out.println(count);
```

```
结果：142
```

**方案二：（递归全排列）**

先写出M个数取N个数全排列的框架:（如果M个数字中有重复数字，则在List集合中不存储具体数据，而存储下

标，则可算出全排列的下标，然后根据下标得到全排列的数字）。

```
static int count = 0;
/**
 * 从m个元素中任取n个并对结果进行全排列
 * @param list   用于承载可能的排列情况的List
 * @param ints   总的整形数组，长度为m
 * @param n      从中取得字符个数
 */
public static void listAll(List<Integer> list, int[] ints, int n) 
{
    if (n == 0) {
        System.out.println(list);                   // 输出一种可能的排列
        count++;
        return;
    }
    for (int i = 0; i < ints.length; i++) {
		if(!list.contains(ints[i]))
		{
			list.set(list.size()-n, ints[i]);
		}
		else{ 	continue;	}
        listAll(list, ints, n - 1);                // 下一位
        list.set(list.size() - n, -1);             // 还原			
	}
}
public static void main(String[] args) {
    //  以字符数组承载总的字符集合
    int[] ints = {1,2,3,4,5};
    int n = 3; //n=3则是取3个数
    List<Integer> intList = new ArrayList<Integer>();
    //通过这一步初始化序列的长度(i<3则是取三个数)
    for (int i = 0; i < n; i++) {
    	intList.add(-1);
    }
    listAll(intList, ints, n); 
    System.out.println(count);
}
```

然后在以上框架基础上，在n==0的判断中去加工：

```
static int count = 0;
public static void listAll(List<Integer> list, int[] ints, int n) 
{
    if (n == 0) {
        //System.out.println(list);                   // 输出一种可能的排列
    	int a = list.get(0); int b=list.get(1); int c=list.get(2); int d=list.get(3); int e=list.get(4);
    	if((a*10+b)*(c*100+d*10+e) == (a*100+d*10+b)*(c*10+e))
    		count++;
        return;
    }
    for (int i = 0; i < ints.length; i++) {
		if(!list.contains(ints[i]))
		{
			list.set(list.size()-n, ints[i]);
		}
		else{ 	continue;	}
        listAll(list, ints, n - 1);                // 下一位
        list.set(list.size() - n, -1);             // 还原			
	}
}
public static void main(String[] args) {
    //  以字符数组承载总的字符集合
    int[] ints = {1,2,3,4,5,6,7,8,9};
    int n = 5; //n=3则是取3个数
    List<Integer> intList = new ArrayList<Integer>();
    //通过这一步初始化序列的长度(i<3则是取三个数)
    for (int i = 0; i < n; i++) {
    	intList.add(-1);
    }
    listAll(intList, ints, n); 
    System.out.println(count);
}
```

**扩展：M个数字取N个数字全排列（如果M个数字中有数字重复）的模板**

如果M个数字中有重复数字，则在List集合中不存储具体数据，而存储下标，则可算出全排列的下标，然后根据下

标得到全排列的数字。

```
static Set<String> set = new HashSet<String>();
public static void main(String[] args) {
	int[] ints = {1,2,2,4,5};
	int n = 3; //取三个数字
	List<Integer> list = new ArrayList<Integer>();
	for (int i = 0; i < n; i++) 
		list.add(-1);
	listAll(list,ints,n);
	System.out.println(set);
	System.out.println(set.size());
}
public static void listAll(List<Integer> list,int[] ints,int n)
{
	if(n == 0) //其中一种排列方式完成
	{
		String r = ints[list.get(0)]+""+ints[list.get(1)]+""+ints[list.get(2)];
		set.add(r);
		return;
	}
	for (int i = 0; i < ints.length; i++) {
		if(!list.contains(i))
			list.set(list.size()-n, i);
		else
			continue;
		listAll(list,ints,n-1);
		list.set(list.size()-n, -1);
	}
}
```

# 第四题

标题: 第39级台阶

小明刚刚看完电影《第39级台阶》，离开电影院的时候，他数了数礼堂前的台阶数，恰好是39级!

站在台阶前，他突然又想着一个问题：

如果我每一步只能迈上1个或2个台阶。先迈左脚，然后左右交替，最后一步是迈右脚，也就是说一共要走偶数

步。那么，上完39级台阶，有多少种不同的上法呢？

请你利用计算机的优势，帮助小明寻找答案。

要求提交的是一个整数。
注意：不要提交解答过程，或其它的辅助说明文字。

**解析：**

先简化题目将数字变小来推理，求一个人可以一次迈一个台阶，也可以迈两个台阶，问此人走三步，一共有多少种

走法。

```
static int count = 0;
static int[] arr = new int[3]; 
public static void main(String[] args) {
    walk(0,0);
    System.out.println(count);
}
/**
* @param step:行走过程中跨过的总台阶数量
* @param walkCount:走路的步数
*/
public static void walk(int step,int walkCount)
{
    if(walkCount>=3)  //正好最后一个台阶，并且是右脚
    {
        count++;
        System.out.println(arr[0]+" "+arr[1]+" "+arr[2]+" ");
        return;
    }
    //此处递归出所有情况
    arr[walkCount] = 1;
    walk(step+1,walkCount+1);
    arr[walkCount] = 2;
    walk(step+2,walkCount+1);
}
```

由上述程序可知，两次walk的递归调用，可以将该人所有的上台阶方案全部列举出来。

**所以：该题目代码如下：**

利用两次递归调用，列举所有的走路方案，在方案中判断是否正好39级台阶以及是否偶数步。

```
static int count = 0;
public static void main(String[] args) {
	// TODO Auto-generated method stub
	walk(0,0);
	System.out.println(count);
}
/**
 * @param step:行走过程中跨国的总台阶数量
 * @param walkCount:走路的步数
 */
public static void walk(int step,int walkCount)
{
	if(step > 39) return;
	if(step == 39 && walkCount % 2 == 0)  //正好最后一个台阶，并且是右脚
	{
		count++;
		return;
	}
	//此处递归出所有情况
	walk(step+1,walkCount+1);
	walk(step+2,walkCount+1);
}
```

# 第五题

标题：有理数类

有理数就是可以表示为两个整数的比值的数字。一般情况下，我们用近似的小数表示。但有些时候，不允许出现误差，必须用两个整数来表示一个有理数。

这时，我们可以建立一个“有理数类”，下面的代码初步实现了这个目标。为了简明，它只提供了加法和乘法运算。

```
class Rational
{
	private long ra;
	private long rb;
	
	private long gcd(long a, long b){
		if(b==0) return a;
		return gcd(b,a%b);
	}
	public Rational(long a, long b){
		ra = a;
		rb = b;	
		long k = gcd(ra,rb);
		if(k>1){ //需要约分
			ra /= k;  
			rb /= k;
		}
	}
	// 加法
	public Rational add(Rational x){
		return ________________________________________;  //填空位置
	}
	// 乘法
	public Rational mul(Rational x){
		return new Rational(ra*x.ra, rb*x.rb);
	}
	public String toString(){
		if(rb==1) return "" + ra;
		return ra + "/" + rb;
	}
}
```

使用该类的示例：

```
Rational a = new Rational(1,3);
Rational b = new Rational(1,6);
Rational c = a.add(b);
System.out.println(a + "+" + b + "=" + c);
```

请分析代码逻辑，并推测划线处的代码，通过网页提交

注意：仅把缺少的代码作为答案，千万不要填写多余的代码、符号或说明文字！！

解析：

```
答案为：
return new Rational(ra*x.rb + rb*x.ra, rb*x.rb);
解析：
(1)gcd()求最大公因数：
例如：gcd(1,18)=1; 	gcd(20,25)=5	
(2)Rational构造函数调用gcd实现的功能为约分，将ra,rb变成最简分数的分子和分母
例如：Rational(1, 18)会将ra=1,rb=18;	对象的结果为 1/18
Rational(20, 25)会将ra=4,rb=5; 对象的结果为 4/5
(3)根据如下代码测试mul乘法运算：
Rational a = new Rational(1,3);
Rational b = new Rational(1,6);
Rational c = a.mul(b);
System.out.println(c);
其中调用mul方法，即执行new Rational(ra*x.ra, rb*x.rb);
a.ra = 1,	a.rb = 3 
b.ra = 1,	b.rb = 6
根据（1）（2）推导，调用完成后，ra=1,rb=18，toString()之后显示 1/18,乘法成立。
（4）题目需要实现加法，根据如下代码测试加法运算：
Rational a = new Rational(1,3);
Rational b = new Rational(1,6);
Rational c = a.add(b);
System.out.println(c);
其中调用add方法：可以执行new Rational(？, ？);
a.ra = 1,	a.rb = 3 
b.ra = 1,	b.rb = 6
我们只需要将new Rational(？, ？)第一个参数变成9，第二个参数变成18，即可实现ra=1,rb=2,toString()之后显示 1/2,加法成立。
所以第一个参数为：ra*x.rb + rb*x.ra，第二个参数为rb*x.rb
```



# 第六题

标题：逆波兰表达式

正常的表达式称为中缀表达式，运算符在中间，主要是给人阅读的，机器求解并不方便。

例如：3 + 5 * (2 + 6) - 1 ；而且，常常需要用括号来改变运算次序。

相反，如果使用逆波兰表达式（前缀表达式）表示，上面的算式则表示为：  - + 3 * 5 + 2 6 1

不再需要括号，机器可以用递归的方法很方便地求解。

为了简便，我们假设：

1. 只有 + - * 三种运算符
2. 每个运算数都是一个小于10的非负整数

下面的程序对一个逆波兰表示串进行求值。

其返回值为一个数组：其中第一元素表示求值结果，第二个元素表示它已解析的字符数。

```
static int[] evaluate(String x)
{
    if(x.length()==0) return new int[] {0,0};

    char c = x.charAt(0);
    if(c>='0' && c<='9') return new int[] {c-'0',1};

    int[] v1 = evaluate(x.substring(1));
    int[] v2 = __________________________________________;  //填空位置

    int v = Integer.MAX_VALUE;
    if(c=='+') v = v1[0] + v2[0];
    if(c=='*') v = v1[0] * v2[0];
    if(c=='-') v = v1[0] - v2[0];

    return new int[] {v,1+v1[1]+v2[1]};
}
```

请分析代码逻辑，并推测划线处的代码，通过网页提交。

注意：仅把缺少的代码作为答案，千万不要填写多余的代码、符号或说明文字！！

解析：

```
(1)将表达式简化即"3+5"变成逆波兰表达式为"+35",代入程序中思考。
(2)根据如下代码：
    if(c=='+') v = v1[0] + v2[0];
    if(c=='*') v = v1[0] * v2[0];
    if(c=='-') v = v1[0] - v2[0];
可推测v1[0]=3,v2[0]=5;
(3)根据题意evaluate函数返回一个数组，其中第一元素表示求值结果，第二个元素表示它已解析的字符数
则int[] v1 = evaluate(x.substring(1));即执行evaluate("35");v1[0]=3;
(4)那么利用填空位置，我们需要求出v2[0]=5即可，我们马上想到答案：
int[] v2 = evaluate(x.substring(2));即执行evaluate("5");v2[0]=5;
(5)在main函数中用如下代码进行测试：
		int[] arr = evaluate("+35");
		System.out.println(arr[0]);
结果为8,没有问题。
(6)但我们将题目中表达式"-+3*5+261"代入进行测试：
		int[] arr = evaluate("-+3*5+261");
		System.out.println(arr[0]);
结果为40，而3 + 5 * (2 + 6) - 1 = 42，显然结果不对
(7)继续分析，我们可以得到第一个减号左边为"+3*5+26",右边为"1"。
则int[] v1 = evaluate(x.substring(1));   v1[0]为"+3*5+26"的结果,v1[1]为解析的字符数=7。
(8)那么填空位置,我们需要求出v2[0]=1即可,我们可以得到答案：
int[] v2 = evaluate(x.substring(8));即int[] v2 = evaluate(x.substring(v1[1]+1));
所以答案为：
evaluate(x.substring(v1[1]+1))
```



# 第七题

标题：核桃的数量

小张是软件项目经理，他带领3个开发组。工期紧，今天都在加班呢。为鼓舞士气，小张打算给每个组发一袋核桃（据传言能补脑）。他的要求是：

1. 各组的核桃数量必须相同
2. 各组内必须能平分核桃（当然是不能打碎的）
3. 尽量提供满足1,2条件的最小数量（节约闹革命嘛）

程序从标准输入读入：

a b c

a,b,c都是正整数，表示每个组正在加班的人数，用空格分开（a,b,c<30）

程序输出：

一个正整数，表示每袋核桃的数量。

例如：

```
用户输入：
2 4 5
程序输出：
20

再例如：
用户输入：
3 1 1
程序输出：
3
```

资源约定：
峰值内存消耗（含虚拟机） < 64M
CPU消耗  < 1000ms

请严格按要求输出，不要画蛇添足地打印类似：“请您输入...” 的多余内容。

所有代码放在同一个源文件中，调试通过后，拷贝提交该源码。
注意：不要使用package语句。不要使用jdk1.6及以上版本的特性。
注意：主类的名字必须是：Main，否则按无效代码处理。

**解析：方案一**

每袋核桃的数量从1开始循环到最大值（三个开发组的人数乘积），依次判断

```
Scanner input = new Scanner(System.in);
int a = input.nextInt();
int b = input.nextInt();
int c = input.nextInt();
//核桃数量的可能数量最大值为a*b*c
for (int i = 1; i <= a*b*c; i++) 
{
	if(i%a==0 && i%b ==0 && i%c==0)
	{
		System.out.println(i);
		break;
	}
}
```

**方案二：**

求出三个开发组人数最大值，每袋核桃的数量一定是该最大值的倍数，将最大值的倍数依次判断

```
Scanner input = new Scanner(System.in);
int a = input.nextInt();
int b = input.nextInt();
int c = input.nextInt();
int max = Math.max(Math.max(a, b), c); //求a,b,c最大值
int i = 1;  //循环计数变量
int r = 1;	//保存max的倍数
//利用循环将max的值不停求倍数,判断倍数是否符合条件
while(true)
{
	r = max*i;
	if(r%a == 0 && r%b == 0 && r%c == 0)
	{
		System.out.println(r);
		return;
	}
	i++;
}
```



# 第八题

标题：打印十字图

小明为某机构设计了一个十字型的徽标（并非红十字会啊），如下所示(可参见p1.jpg)

![p1](img\p1.JPG)

```

                     $$$$$$$$$$$$$
                     $           $
                   $$$ $$$$$$$$$ $$$
                   $   $       $   $
                   $ $$$ $$$$$ $$$ $
                   $ $   $   $   $ $
                   $ $ $$$ $ $$$ $ $
                   $ $ $   $   $ $ $
                   $ $ $ $$$$$ $ $ $
                   $ $ $   $   $ $ $
                   $ $ $$$ $ $$$ $ $
                   $ $   $   $   $ $
                   $ $$$ $$$$$ $$$ $
                   $   $       $   $
                   $$$ $$$$$$$$$ $$$
                     $           $
                     $$$$$$$$$$$$$
```

对方同时也需要在电脑dos窗口中以字符的形式输出该标志，并能任意控制层数。

为了能准确比对空白的数量，程序要求对行中的空白以句点（.）代替。

输入格式：
一个正整数 n (n<30) 表示要求打印图形的层数

输出：
对应包围层数的该标志。

例如：

```
用户输入：
1
程序应该输出：
..$$$$$..
..$...$..
$$$.$.$$$
$...$...$
$.$$$$$.$
$...$...$
$$$.$.$$$
..$...$..
..$$$$$..

再例如：
用户输入：
3
程序应该输出：
..$$$$$$$$$$$$$..
..$...........$..
$$$.$$$$$$$$$.$$$
$...$.......$...$
$.$$$.$$$$$.$$$.$
$.$...$...$...$.$
$.$.$$$.$.$$$.$.$
$.$.$...$...$.$.$
$.$.$.$$$$$.$.$.$
$.$.$...$...$.$.$
$.$.$$$.$.$$$.$.$
$.$...$...$...$.$
$.$$$.$$$$$.$$$.$
$...$.......$...$
$$$.$$$$$$$$$.$$$
..$...........$..
..$$$$$$$$$$$$$..
```

请仔细观察样例，尤其要注意句点的数量和输出位置。

资源约定：
峰值内存消耗（含虚拟机） < 64M
CPU消耗  < 1000ms


请严格按要求输出，不要画蛇添足地打印类似：“请您输入...” 的多余内容。

所有代码放在同一个源文件中，调试通过后，拷贝提交该源码。
注意：不要使用package语句。不要使用jdk1.6及以上版本的特性。
注意：主类的名字必须是：Main，否则按无效代码处理。

**解析：**

```
static char[][] arr;  //用于保存正方形的矩阵
static int sideLength; //用于存储整个矩形的边长
static int layer; //存储用户输入的总层数
public static void main(String[] args) 
{
	//不区分红色区域($)还是白色区域(.),实际是一个正方形，并且
	//层数:1，边长:9;层数:2，边长:13;层数:3，边长:17;层数:4，边长:21;
	//所以： 边长= 9+(层数-1)*4
	Scanner input = new Scanner(System.in);
	layer = input.nextInt();  //接收用户输入的层数
	sideLength = 9+(layer-1)*4; //根据层数计算边长
	arr = new char[sideLength][sideLength];
	InitDot(); //初始化矩阵所有内容都为点符号
	//从外层开始向内层一层一层将边框上的红色区域($)替换掉白色区域(.)
	for (int i = layer; i >= 1; i--) 
		Replace$(i);
	ReplaceTen(); //替换中间的十字架
	PrintResult(); //打印结果
}

//初始化矩阵所有内容都为点符号的函数
public static void InitDot()
{
	for (int i = 0; i < arr.length; i++) {
		for (int j = 0; j < arr[i].length; j++) {
			arr[i][j] = '.';
		}
	}
}

//将某层上的红色区域($)替换掉白色区域(.)
public static void Replace$(int nowLayer)
{
	//根据当前层数计算当前层正方形的开始点和结束点，规律如下（假设总共4层）
	//假设当前第四层：开始位置0,0;结束位置:20,20
	//假设当前第三层：开始位置2,2;结束位置:18,18
	//假设当前第二层：开始位置4,4;结束位置:16,16
	//假设当前第一层：开始位置6,6;结束位置:14,14
	//所以:开始位置两个数=(总层数-当前层)*2
	//所以:结束位置两个数=整个正方形边长-(总层数-当前层)*2-1
	int start = (layer-nowLayer)*2;	
	int end = sideLength-(layer-nowLayer)*2-1;
	//替换第一行和最后一行为红色($)
	for (int i = start+2; i <= end-2; i++) {
		arr[start][i] = '$';
		arr[end][i] = '$';
	}
	//替换第二行和倒数第二行为红色
	arr[start+1][start+2] = '$'; arr[start+1][end-2] = '$';
	arr[end-1][start+2] = '$'; arr[end-1][end-2] = '$';
	//替换倒数第三行和第三行为红色
	for (int i = start; i <= start+2; i++) {
		arr[start+2][i] = '$';		//替换第三行左边
		arr[end-2][i] = '$';		//替换倒数第三行左边
	}
	for (int i = end-2; i <= end; i++) {
		arr[start+2][i] = '$';		//替换第三行右边
		arr[end-2][i] = '$';		//替换倒数第三行右边			
	}
	//替换其他行
	for (int i = start+3; i <=end-3; i++) {
		arr[i][start] = '$';
		arr[i][end] = '$';
	}
}

//替换中间的十字
public static void ReplaceTen()
{
	int center = sideLength/2;  //计算十字架中心
	for (int i = center-2; i <= center+2; i++) {
		arr[center][i] = '$'; //替换十字架的横向
		arr[i][center] = '$'; //替换十字架的纵向
	}	
}

//打印最后结果
public static void PrintResult()
{
	for (int i = 0; i < arr.length; i++) {
		for (int j = 0; j < arr[i].length; j++) {
			System.out.print(arr[i][j]);
		}
		System.out.println();
	}
}
```

# 第九题

标题：买不到的数目

小明开了一家糖果店。他别出心裁：把水果糖包成4颗一包和7颗一包的两种。糖果不能拆包卖。

小朋友来买糖的时候，他就用这两种包装来组合。当然有些糖果数目是无法组合出来的，比如要买 10 颗糖。

你可以用计算机测试一下，在这种包装情况下，最大不能买到的数量是17。大于17的任何数字都可以用4和7组合出来。

本题的要求就是在已知两个包装的数量时，求最大不能组合出的数字。

输入：
两个正整数，表示每种包装中糖的颗数(都不多于1000)

要求输出：
一个正整数，表示最大不能买到的糖数

不需要考虑无解的情况

例如：

```
用户输入：
4 7
程序应该输出：
17

再例如：
用户输入：
3 5
程序应该输出：
7
```

资源约定：
峰值内存消耗（含虚拟机） < 64M
CPU消耗  < 3000ms


请严格按要求输出，不要画蛇添足地打印类似：“请您输入...” 的多余内容。

所有代码放在同一个源文件中，调试通过后，拷贝提交该源码。
注意：不要使用package语句。不要使用jdk1.6及以上版本的特性。
注意：主类的名字必须是：Main，否则按无效代码处理。

**解析：**

（1）此题目，如果两个数是有公约数的，那么此题无解，但题目提示“不需要考虑无解的情况”，所以我们不需要

考虑此情况，只需要考虑两个数字互为质数的情况。

（2）如果两个输入数字为a,b；则a*b及之后的数字一定是可以组合出来的，例如输入4和7，则28及之后的数字一

定是可以组合出来的。

**方案一：**

此方案利用数学公式：

```
Scanner input = new Scanner(System.in);
int a = input.nextInt(); //第一种包装有a颗糖
int b = input.nextInt(); //第二种包装有b颗糖
System.out.println(a*b-a-b);
```

**方案二：**

将a*b的结果作为上限最大值，然后依次减一循环，逐个判断每个数字是否可以组合出结果，遇到的第一个不能组

合出结果的数字即是答案。

```
public static void main(String[] args) {
	Scanner input = new Scanner(System.in);
	int a = input.nextInt(); //第一种包装有a颗糖
	int b = input.nextInt(); //第二种包装有b颗糖
	int max = a*b; //当需要买糖的数量>=a*b的时候是一定可以组合出来的,所以max是上限
	for (int i = max; i >= 1; i--) 
	{
		if(BuyCandy(a,b,i) == false)
		{
			System.out.println(i);
			break;
		}
	}
}	
//a,b代表两种包装糖果数量count代表买糖果的数量
public static boolean BuyCandy(int a,int b,int count)
{
	boolean r = false; //假设不能通过组合的方式买到固定数量的糖果
	for (int i = 0; i*a<=count; i++)  //循环第一种包装的糖果组合几袋
	{
		for (int j = 0; i*a+j*b<=count; j++) //循环第二种包装的糖果组合几袋
		{
			if(i*a+j*b == count)
			{
				r = true;
			}
		}
	}
	return r;
}
```

此种方案，在每种假设情况下，都进行了组合计算，即BuyCandy函数里面的循环代码。

**方案三：**

（1）先将所有可能的组合条件下的总糖果数量使用集合进行记录。

（2）然后从a*b为起点，依次减一循环，判断第一个在集合种找不到的元素则为答案。

此方案相对方案二，BuyCandy函数的循环代码只需要执行一次。

```
Scanner input = new Scanner(System.in);
int a = input.nextInt(); //第一种包装有a颗糖
int b = input.nextInt(); //第二种包装有b颗糖
int max = a*b; //当需要买糖的数量>=a*b的时候是一定可以组合出来的,所以max是上限
Set<Integer> set = new HashSet<Integer>();
//将所有能够组合出来的数量存储到集合中
for (int i = 0; i*a<=max; i++)  //循环第一种包装的糖果组合几袋
{
	for (int j = 0; i*a+j*b<=max; j++) //循环第二种包装的糖果组合几袋
	{
		set.add(i*a+j*b);
	}
}
//倒序循环判断如果有数字不在上述集合中，则为答案
for (int i = max; i >= 0; i--) 
{
	if(!set.contains(i))
	{
		System.out.println(i);
		break;
	}
}
```

# 第十题

标题：剪格子

如图p1.jpg所示，3 x 3 的格子中填写了一些整数。

我们沿着图中的红色线剪开，得到两个部分，每个部分的数字和都是60。

![7](img/7.JPG)

![6](img/6.JPG)

本题的要求就是请你编程判定：对给定的m x n 的格子中的整数，是否可以分割为两个部分，使得这两个区域的数字和相等。

如果存在多种解答，请输出包含左上角格子的那个区域包含的格子的最小数目。  如果无法分割，则输出 0

程序输入输出格式要求：
程序先读入两个整数 m n 用空格分割 (m,n<10)
表示表格的宽度和高度
接下来是n行，每行m个正整数，用空格分开。每个整数不大于10000
程序输出：在所有解中，包含左上角的分割区可能包含的最小的格子数目。

例如：

```
用户输入：
3 3
10 1 52
20 30 1
1 2 3

则程序输出：
3

再例如：
用户输入：
4 3
1 1 1 1
1 30 80 2
1 1 1 100

则程序输出：
10
```

资源约定：
峰值内存消耗（含虚拟机） < 64M
CPU消耗  < 5000ms


请严格按要求输出，不要画蛇添足地打印类似：“请您输入...” 的多余内容。

所有代码放在同一个源文件中，调试通过后，拷贝提交该源码。
注意：不要使用package语句。不要使用jdk1.6及以上版本的特性。
注意：主类的名字必须是：Main，否则按无效代码处理。

**解析：**

首先理解题意，题目含义概述如下：

（1）有一个矩阵，矩阵中每个格子里面有一个数字，可以看成一个二维数组。

（2）在矩阵中进行裁剪分割，将矩阵分割成两个部分，两个部分的和相等，即每个部分都是总和的一半。

（3）分割之后符合两个部分和都相等的情况可能没有，可能有一种可能，也可能有多种可能。

（4）输出结果为符合分割之后两个部分都相等情况下，包含第一行第一列的部分格子的最小数量

思路：

（1）以第一行第一列格子为起点，利用递归（上下左右）四个方向进行移动联接，遍历所有的裁剪情况。

（2）在递归中进行格子上数字的累加，如果累加结果正好是所有数字之和的一半则符合裁剪条件。

（3）每次计算出符合裁剪条件的时候记录格子数量，并求最小值。

```
static int[][] arr;   //二维数组保存格子每个元素的数据
static int[][] state;  //二维数组标记每个格子是否已经走过1:走过,0:没有走过
static int m = 0;	//二维数组的列
static int n = 0; //二维数组的行
static int sum = 0; //二维数组元素之和
static int min = 100; //假设符合条件的区块数量最小值(题目(m,n<10))
public static void move(int row,int col,int step,int add)
{
	//判断当格子走出边界,或已经走过的格子,或累加之和已经超过所有数字之和的一半则退出
	if(row < 0 || col <0 || row > n-1 || col > m-1 || state[row][col]==1 || add > sum/2)
		return;
	//判断
	if(add == sum/2)
	{
		min = step < min ?step:min;
		return;
	}
	state[row][col]=1; //标记该格子已经走过了	
	move(row-1,col,step+1,add+arr[row][col]); //上
	move(row+1,col,step+1,add+arr[row][col]); //下
	move(row,col-1,step+1,add+arr[row][col]); //左
	move(row,col+1,step+1,add+arr[row][col]); //右
	state[row][col]=0;//将标记进行还原
}

public static void main(String[] args) {
	//用户输入
	Scanner input = new Scanner(System.in);
	m = input.nextInt();
	n = input.nextInt();
	arr = new int[n][m];
	state = new int[n][m];
	sum = 0;
	for (int i = 0; i < arr.length; i++) 
	{
		for (int j = 0; j < arr[i].length; j++) {
			arr[i][j] = input.nextInt();
			sum += arr[i][j];
		}
	}
	//调用递归方法
	move(0,0,0,0);
	System.out.println(min==100?0:min);  //如果无解则输出0
}
```

**优化一：**

上述代码只考虑了以第一行第一列格子为起点进行移动，但从第一行第一列格子为起点进行移动会漏掉一些裁剪情况，例如：

```
2 2
1 1
1 3
```

上述代码执行结果为0，但正确结果为3

或：

```
3 3
1 2 1
3 1 2
1 1 0
```

上述代码执行结果为4，但正确结果为3

所以不能只从第一行第一列格子为起点进行移动，需要以每个格子为起点进行移动，代码如下：

```
static int[][] arr;   //二维数组保存格子每个元素的数据
static int[][] state;  //二维数组标记每个格子是否已经走过1:走过,0:没有走过
static int m = 0;	//二维数组的列
static int n = 0; //二维数组的行
static int sum = 0; //二维数组元素之和
static int min = 100; //假设符合条件的区块数量最小值(题目(m,n<10))

public static void move(int row,int col,int step,int add)
{
	//判断当格子走出边界,或已经走过的格子,或累加之和已经超过所有数字之和的一半则退出
	if(row < 0 || col <0 || row > n-1 || col > m-1 || state[row][col]==1 || add > sum/2)
		return;
	//判断累加的和正好等于总和一半，并且第一行第一列为已经走过的格子
	if(add == sum/2 && state[0][0]==1)
	{	
		min = step < min ?step:min;
		return;
	}
	state[row][col]=1; //标记该格子已经走过了	
	move(row-1,col,step+1,add+arr[row][col]); //上
	move(row+1,col,step+1,add+arr[row][col]); //下
	move(row,col-1,step+1,add+arr[row][col]); //左
	move(row,col+1,step+1,add+arr[row][col]); //右
	state[row][col]=0;//将标记进行还原
}

public static void main(String[] args) {
	//用户输入
	Scanner input = new Scanner(System.in);
	m = input.nextInt();
	n = input.nextInt();
	arr = new int[n][m];
	state = new int[n][m];
	sum = 0;
	for (int i = 0; i < arr.length; i++) 
	{
		for (int j = 0; j < arr[i].length; j++) {
			arr[i][j] = input.nextInt();
			sum += arr[i][j];
		}
	}
    if(sum % 2 == 1)  //如果奇数，直接打印结果
    {
        System.out.println(0);
        return;
    }
	//从每个起点开始出发
	for (int i = 0; i < arr.length; i++) 
	{
		for (int j = 0; j < arr[i].length; j++) {
			move(i,j,0,0);
		}
	}
	//调用递归方法
	
	System.out.println(min==100?0:min);  //如果无解则输出0
}
```

**优化二：**

上述代码并没有考虑不包含第一行第一列的部分被切断的情况，如果被切断，则不符合题意，如下数据：

```
4 3
1 1 5 1
2 3 4 1
1 1 1 9
```

上述代码执行结果为5：

```
1 * 5 *
2 3 4 *
* * * *
```

但正确结果为6：

```
1 1 5 1
* 3 4 *
* * * *
```

所以在前面代码基础上添加函数判断被裁切另外一部分是否是联通的，通过此函数解决上述问题。

可以利用是否走过保存状态的数组进行判断，很容易想到判断每个0状态数字是否有上下左右同类，如果有一个0元素没有上下左右同类则表示图形被裁切数量>2，即

```
1 0 1 0
1 1 1 0
0 0 0 0
```

此种情况，第一行第二列的0元素上下左右找不到同类，则被裁切数量>2的，很好理解，算法设计也相对简单，但此思路是错误的，因为此思路无法求解如下情况：

```
1 0 0 1
1 1 1 1
0 0 0 0
```

上面的思路不行，我们更换思路，此时的思路为记录下任意一个为0元素的下标，让其自由行走，并不做重复的坐标不能走动的判断。

遇到0元素就改变其值为2并继续走，遇到1元素则停止，最后通过如下公式判断是否裁切为2部分：

裁切包含左上角的元素个数 + 状态为2的元素个数  != 元素总个数，则没有将图像裁切成2部分。

```
public static int[][] step = {{-1,0},{1,0},{0,-1},{0,1}};
static int[][] arr;   //二维数组保存格子每个元素的数据
static int[][] state;  //二维数组标记每个格子是否已经走过1:走过,0:没有走过
static int m = 0;	//二维数组的列
static int n = 0; //二维数组的行
static int sum = 0; //二维数组元素之和
static int min = 100; //假设符合条件的区块数量最小值(题目(m,n<10))
//判断另外被裁切的另外一部分是否是联通的
public static void Check(int x, int y, int[][] v)
{
    v[x][y] = 2;
    for(int i = 0;i < 4;i++) {
        int x1 = x + step[i][0];
        int y1 = y + step[i][1];
        if(x1 < 0 || x1 >= n || y1 < 0 || y1 >= m)
            continue;
        if(v[x1][y1] == 0)
        	Check(x1, y1, v);
    }		
}
public static void move(int row,int col,int step,int add)
{
	//判断当格子走出边界,或已经走过的格子,或累加之和已经超过所有数字之和的一半则退出
	if(row < 0 || col <0 || row > n-1 || col > m-1 || state[row][col]==1 || add > sum/2)
		return;	
	//判断累加的和正好等于总和一半，并且第一行第一列为已经走过的格子
	if(add == sum/2 && state[0][0]==1)
	{	
		int x = 0, y = 0, step2 = 0;
        int[][] v = new int[n][m];
        for(int i = 0;i < n;i++) {
            for(int j = 0;j < m;j++) {
                if(state[i][j] == 0) {
                    x = i;
                    y = j;
                }    
                v[i][j] = state[i][j];
            }
        }
        Check(x, y, v);
        for(int i = 0;i < n;i++)
            for(int j = 0;j < m;j++)
                if(v[i][j] == 2)
                	step2++;
        //包含左上角的区域数量+未走过的区域数量如果不等于总数量,则没有裁切成2块
        if(step2+step != n*m) 
        	return;
		min = step < min ?step:min;
		return;
	}
	state[row][col]=1; //标记该格子已经走过了
	move(row-1,col,step+1,add+arr[row][col]); //上
	move(row+1,col,step+1,add+arr[row][col]); //下
	move(row,col-1,step+1,add+arr[row][col]); //左
	move(row,col+1,step+1,add+arr[row][col]); //右
	state[row][col]=0;//将标记进行还原
}

public static void main(String[] args) {
	//用户输入
	Scanner input = new Scanner(System.in);
	m = input.nextInt();
	n = input.nextInt();
	arr = new int[n][m];
	state = new int[n][m];
	sum = 0;
	for (int i = 0; i < arr.length; i++) 
	{
		for (int j = 0; j < arr[i].length; j++) {
			arr[i][j] = input.nextInt();
			sum += arr[i][j];
		}
	}
	if(sum % 2 == 1)  //如果奇数，直接打印结果
	{
		System.out.println(0);
		return;
	}
	//从每个起点开始出发
	for (int i = 0; i < arr.length; i++) 
	{
		for (int j = 0; j < arr[i].length; j++) {
			move(i,j,0,0);
		}
	}
	//调用递归方法		
	System.out.println(min==100?0:min);  //如果无解则输出0
}
```

