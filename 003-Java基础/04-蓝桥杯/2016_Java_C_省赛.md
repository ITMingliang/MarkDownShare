# 第一题

有奖猜谜

小明很喜欢猜谜语。
最近，他被邀请参加了X星球的猜谜活动。

每位选手开始的时候都被发给777个电子币。
规则是：猜对了，手里的电子币数目翻倍，
猜错了，扣除555个电子币, 扣完为止。

小明一共猜了15条谜语。
战果为：vxvxvxvxvxvxvvx
其中v表示猜对了，x表示猜错了。

请你计算一下，小明最后手里的电子币数目是多少。

请填写表示最后电子币数目的数字。
注意：你提交的应该是一个整数，不要填写任何多余的内容或说明性文字。

**解析：**

```
char[] arr = "vxvxvxvxvxvxvvx".toCharArray();
int m = 777;
for (int i = 0; i < arr.length; i++) 
{
    if(arr[i] == 'v')
    	m = m*2;
    if(arr[i] == 'x')
    	m = m-555;		
}
System.out.println(m);
```

```
答案：58497
```



# 第二题

煤球数目

有一堆煤球，堆成三角棱锥形。具体：
第一层放1个，
第二层3个（排列成三角形），
第三层6个（排列成三角形），
第四层10个（排列成三角形），
....
如果一共有100层，共有多少个煤球？

请填表示煤球总数目的数字。
注意：你提交的应该是一个整数，不要填写任何多余的内容或说明性文字。

```
int step = 1;  //每层煤球增加的步长
int rowNum = 0;   //每层的煤球数
int sum = 0; //总共的煤球数
for (int i = 1; i <= 100; i++) 
{
    rowNum = rowNum+step;  //当前层的煤球数
    sum = sum + rowNum;    //煤球的数量总和
    step++;  //每层煤球数量增长的步长
}
System.out.println(sum);
```

```
答案：171700
```

备注：每层煤球增加数量并不是一样的，而是以1，2，3，4，5的规律递增的。



# 第三题

平方怪圈

如果把一个正整数的每一位都平方后再求和，得到一个新的正整数。
对新产生的正整数再做同样的处理。

如此一来，你会发现，不管开始取的是什么数字，
最终如果不是落入1，就是落入同一个循环圈。

请写出这个循环圈中最大的那个数字。

请填写该最大数字。
注意：你提交的应该是一个整数，不要填写任何多余的内容或说明性文字。

**解析：**

```
Scanner input = new Scanner(System.in);
int num = input.nextInt();
for(int i = 1;i<=1000;i++)  //计算每位数字的平方和，计算1000次，
{
	int sum = 0;
	while(true)
	{
		//取每位余数，并且累加之和
		int mod = num%10;
		sum = sum + mod*mod;
		//将本身数字进行变换除10
		num = num / 10;
		//num = 0之后证明平方和已经计算完毕，将num值变成平方和后的结果，在进行下一轮运算
		if(num == 0)
		{
			num = sum;
			break;
		}
	}
	System.out.println(sum); //记录每次求平方和后的结果。		
}
```

```
答案：145
```

备注：通过上述代码打印结果，可以看出，最后打印内容在一组相同的数据范围内不停在循环，并且这组相同的数据中最大值为145。

# 第四题

骰子游戏

我们来玩一个游戏。
同时掷出3个普通骰子（6个面上的数字分别是1~6）。
如果其中一个骰子上的数字等于另外两个的和，你就赢了。

下面的程序计算出你能获胜的精确概率（以既约分数表示）

```
public class Main
{
	public static int gcd(int a, int b)
	{
		if(b==0) return a;
		return gcd(b,a%b);
	}
	
	public static void main(String[] args)
	{	
		int n = 0;
		for(int i=0; i<6; i++)
		for(int j=0; j<6; j++)
		for(int k=0; k<6; k++){
			if(________________________________) n++;   //填空位置
		}
		
		int m = gcd(n,6*6*6);
		System.out.println(n/m + "/" + 6*6*6/m);
	}
}
```

仔细阅读代码，填写划线部分缺少的内容。

注意：不要填写任何已有内容或说明性文字。

**解析：**

```
答案：i+1==j+k+2 || j+1==i+k+2 || k+1==i+j+2
```

备注：代码可以看出，三重循环是求n，即符合赢的可能情况总数，但是题目有陷阱，三重循环并不是从1开始，而是从0开始，所以答案并不是“i==j+k || j==i+k || k==i+j”。

既约分数： 最简分数，是分子、分母只有公因数1的分数，或者说分子和分母互质的分数 。

# 第五题

分小组

9名运动员参加比赛，需要分3组进行预赛。
有哪些分组的方案呢？

我们标记运动员为 A,B,C,... I
下面的程序列出了所有的分组方法。

该程序的正常输出为：

```
ABC DEF GHI
ABC DEG FHI
ABC DEH FGI
ABC DEI FGH
ABC DFG EHI
ABC DFH EGI
ABC DFI EGH
ABC DGH EFI
ABC DGI EFH
ABC DHI EFG
ABC EFG DHI
ABC EFH DGI
ABC EFI DGH
ABC EGH DFI
ABC EGI DFH
ABC EHI DFG
ABC FGH DEI
ABC FGI DEH
ABC FHI DEG
ABC GHI DEF
ABD CEF GHI
ABD CEG FHI
ABD CEH FGI
ABD CEI FGH
ABD CFG EHI
ABD CFH EGI
ABD CFI EGH
ABD CGH EFI
ABD CGI EFH
ABD CHI EFG
ABD EFG CHI
..... (以下省略，总共560行)。
```

```
public class A
{
	public static String remain(int[] a)
	{
		String s = "";
		for(int i=0; i<a.length; i++){
			if(a[i] == 0) s += (char)(i+'A');
		}	
		return s;
	}
	
	public static void f(String s, int[] a)
	{
		for(int i=0; i<a.length; i++){
			if(a[i]==1) continue;
			a[i] = 1;
			for(int j=i+1; j<a.length; j++){
				if(a[j]==1) continue;
				a[j]=1;
				for(int k=j+1; k<a.length; k++){
					if(a[k]==1) continue;
					a[k]=1;
					System.out.println(__________________________________);  //填空位置
					a[k]=0;
				}
				a[j]=0;
			}
			a[i] = 0;
		}
	}
	
	public static void main(String[] args)
	{
		int[] a = new int[9];		
		a[0] = 1;
		
		for(int b=1; b<a.length; b++){
			a[b] = 1;
			for(int c=b+1; c<a.length; c++){
				a[c] = 1;
				String s = "A" + (char)(b+'A') + (char)(c+'A');
				f(s,a);
				a[c] = 0;
			}
			a[b] = 0;
		}
	}
}
```

仔细阅读代码，填写划线部分缺少的内容。

注意：不要填写任何已有内容或说明性文字。

**解析：**

```
s+" "+(char)(i+'A')+(char)(j+'A')+(char)(k+'A')+" "+remain(a)
```

备注：main函数中s，实际已经求出以A开头的所有组合。

在f函数中，接收main中的s以及标记哪些已经使用过的数组a,在通过三层嵌套循环在通过数组a判断哪些字符没有使用过，进行剩下6个字符中的三个的排列。

在f函数运行过程中调用remain，实际上是处理最后剩下的三个字符将其排列。

此题可以先打印s,判断s为前三列，然后打印remain(a),判断remain(a)为最后三列，在f中有三层嵌套循环，并且每层循环都做了==1,continue的处理，可以猜测每层循环在判断使用过的字符跳过循环，即没有使用过得字符需要添加到打印结果中，其中i,j,k可以代表字符的向右移动步长，即中间三列为(char)(i+'A')+(char)(j+'A')+(char)(k+'A')。



# 第六题

凑算式

```
     B      DEF
A + --- + ------- = 10
     C      GHI
```

（如果显示有问题，可以参见图片）

![5](img\5.jpg)

这个算式中A~I代表1~9的数字，不同的字母代表不同的数字。

比如：
6+8/3+952/714 就是一种解法，
5+3/1+972/486 是另一种解法。

这个算式一共有多少种解法？

注意：你提交应该是个整数，不要填写任何多余的内容或说明性文字。

解析一：（循环嵌套）

```
int count = 0;
for (int a = 1; a <= 9; a++) 
{
	for (int b = 1; b <= 9; b++) 
	{
		if(b==a) continue;
		for (int c = 1; c <= 9; c++) 
		{
			if(c==a || c == b) continue;
			for (int d = 1; d <= 9; d++) 
			{
				if(d==a || d==b || d==c) continue;
				for (int e = 1; e <= 9; e++) 
				{
					if(e==a || e==b || e== c || e==d) continue;
					for (int f = 1; f <= 9; f++) 
					{
						if(f == a || f == b || f==c || f==d || f==e) continue;
						for (int g = 1; g <= 9; g++) 
						{
							if(g == a || g== b || g==c || g==d || g==e || g==f) continue;
							for (int h = 1; h <= 9; h++) 
							{
								if(h == a || h== b || h==c || h==d || h==e || h==f || h==g) continue;
								for (int i = 1; i <= 9; i++) 
								{
									if(i == a || i== b || i==c || i==d || i==e || i==f || i==g || i==h) continue;
										if(a + b*1.0/c + (d*100+e*10+f)*1.0/(g*100+h*10+i) == 10)
											count++;
								}
							}
						}
					}
				}
			}
		}
	}
}
System.out.println(count);
```

```
答案：29
```

解析二：（全排列递归）

```
static int count;
public static void main(String[] args)
{
	int[] arr = new int[]{1,2,3,4,5,6,7,8,9};
	fullSort(arr,0,arr.length-1);
	System.out.println(count);
}
public static void fullSort(int[] arr,int start,int end)
{
	if(start == end)
	{
//			for (int i = 0; i < arr.length; i++) {
//				System.out.print(arr[i] + "\t");
//			}
//			System.out.println();
		if(arr[0] + arr[1]*1.0/arr[2]+(arr[3]*100+arr[4]*10+arr[5])*1.0/(arr[6]*100+arr[7]*10+arr[8]) == 10)
		{
			count++;
			
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
```

```
答案：29
```



# 第七题

搭积木

小明最近喜欢搭数字积木，
一共有10块积木，每个积木上有一个数字，0~9。

搭积木规则：
每个积木放到其它两个积木的上面，并且一定比下面的两个积木数字小。
最后搭成4层的金字塔形，必须用完所有的积木。

```
下面是两种合格的搭法：

   0
  1 2
 3 4 5
6 7 8 9

   0
  3 1
 7 5 2
9 8 6 4    

请你计算这样的搭法一共有多少种？
```

请填表示总数目的数字。
注意：你提交的应该是一个整数，不要填写任何多余的内容或说明性文字。

**解析：**

方案一：循环嵌套

假设数字分别是a,b,c,d,e,f,g,h,i,j。

```
   a
  b c
 d e f
g h i j
```

```
int ans = 0;
for (int a = 0; a <= 9; a++) {
	for (int b = 0; b <= 9; b++) {
		if(b==a) continue;
		for (int c = 0; c <= 9; c++) {
			if(c==a || c==b) continue;
			for (int d = 0; d <= 9; d++) {
				if(d==a ||d==b || d==c) continue;
				for (int e = 0; e <= 9; e++) {
					if(e==a || e==b || e==c || e==d) continue;
					for (int f = 0; f <= 9; f++) {
						if(f==a || f==b || f==c || f==d || f==e) continue;
						for (int g = 0; g <= 9; g++) {
							if(g==a || g==b || g==c || g==d || g==e || g==f) continue;
							for (int h = 0; h <= 9; h++) {
								if(h==a || h==b || h==c || h==d || h==e || h==f || h==g) continue;
								for (int i = 0; i <= 9; i++) {
									if(i==a || i==b || i==c || i==d || i==e || i==f || i==g || i==h) continue;
									for (int j = 0; j <= 9; j++) {
										if(j==a || j==b || j==c || j==d || j==e || j==f || j==g || j==h || j==i) 
											continue;
										if( a < b && a < c && 
												b < d && b < e && c < e && c < f && 
												d <g && d<h && e<h && e<i && f<i && f<j)
											ans++;
									}
								}
							}
						}
					}
				}
			}
		}
	}			
}
System.out.println(ans);
```

```
答案：768
```

方案二：全排列递归

```
static int count = 0;  //计算排列方案的数量
public static void main(String[] args)
{
	int[] arr = new int[]{0,1,2,3,4,5,6,7,8,9};
	fullSort(arr,0,arr.length-1);
	System.out.println(count);
}

public static void fullSort(int[] arr,int start,int end)
{
	if(start == end)  //此处为true则证明排列完成一次
	{
		if(arr[0]<arr[1] && arr[0]<arr[2] &&
				arr[1]<arr[3] && arr[1]<arr[4] && 
				arr[2]<arr[4] && arr[2]<arr[5] && 
				arr[3]<arr[6] && arr[3]<arr[7] && 
				arr[4]<arr[7] && arr[4]<arr[8] &&
				arr[5]<arr[8] && arr[5]<arr[9])
			count++;
	}
	for (int i = start; i <=end; i++) {
		swap(arr,start,i);
		fullSort(arr,start+1,end);
		swap(arr,start,i);
	}
}

public static void swap(int[] arr,int i,int j)
{
	int temp = arr[i];  arr[i] = arr[j]; arr[j] = temp;
}
```



# 第八题

冰雹数

任意给定一个正整数N，
如果是偶数，执行： N / 2
如果是奇数，执行： N * 3 + 1

生成的新的数字再执行同样的动作，循环往复。

通过观察发现，这个数字会一会儿上升到很高，
一会儿又降落下来。
就这样起起落落的，但最终必会落到“1”
这有点像小冰雹粒子在冰雹云中翻滚增长的样子。

比如N=9
9,28,14,7,22,11,34,17,52,26,13,40,20,10,5,16,8,4,2,1
可以看到，N=9的时候，这个“小冰雹”最高冲到了52这个高度。

输入格式：
一个正整数N（N<1000000）
输出格式：
一个正整数，表示不大于N的数字，经过冰雹数变换过程中，最高冲到了多少。

例如，输入：
10
程序应该输出：
52

再例如，输入：
100
程序应该输出：
9232

资源约定：
峰值内存消耗（含虚拟机） < 256M
CPU消耗  < 1000ms


请严格按要求输出，不要画蛇添足地打印类似：“请您输入...” 的多余内容。

所有代码放在同一个源文件中，调试通过后，拷贝提交该源码。
注意：不要使用package语句。不要使用jdk1.7及以上版本的特性。
注意：主类的名字必须是：Main，否则按无效代码处理。

**解析：**

题意有描述不清的地方，需要理解，即输入一个正整数N和前面的N=9举例的N并不是相同的含义：在举例中的N代表，N=9的时候最高值；而输入一个正整数N代表从1到N的所有数字进行计算求其中的最高值。

方案一：

```
private static long getMax(long n) {
	long max = n;  //假设最大值
	while(true)
	{
		if(n % 2 == 0)
			n = n/2;
		else
			n = n*3+1;	
		if(max < n)
			max = n;			
		if(n == 1)
			break;
	}
	return max;
}
public static void main(String[] args) {
	Scanner input = new Scanner(System.in);
	int n = input.nextInt();
	long max = n;
	for (int i = 1; i <= n; i++) {
		long fMax = getMax(i);
		if(max < fMax)
			max = fMax;
	}
	System.out.println(max);
}
```

以上方案可以出结果，但是效率较低，优化版本如下：

方案二：

```
private static long getMax(long n,long max) {
	//long max = n;  //假设最大值
	long oldValue = n; //记录原始的值
	while(true)
	{
        if(n % 2 == 0)
        	n = n/2;
        else
        	n = n*3+1;
        if(n < oldValue) //如果运算后的结果比本身还小，直接退出循环
        	break;
        if(max < n)
        	max = n;			
        if(n == 1)
        	break;
	}
	return max;
}

public static void main(String[] args) {
	Scanner input = new Scanner(System.in);
	int n = input.nextInt();
	long max = n;
	for (int i = n; i >= 1; i--) {
		long fMax = getMax(i,max);
		if(max < fMax)
			max = fMax;
	}
	System.out.println(max);
}
```



# 第九题

四平方和

四平方和定理，又称为拉格朗日定理：
每个正整数都可以表示为至多4个正整数的平方和。
如果把0包括进去，就正好可以表示为4个数的平方和。

比如：
5 = 0^2 + 0^2 + 1^2 + 2^2
7 = 1^2 + 1^2 + 1^2 + 2^2
（^符号表示乘方的意思）

对于一个给定的正整数，可能存在多种平方和的表示法。
要求你对4个数排序：
0 <= a <= b <= c <= d
并对所有的可能表示法按 a,b,c,d 为联合主键升序排列，最后输出第一个表示法

程序输入为一个正整数N (N<5000000)
要求输出4个非负整数，按从小到大排序，中间用空格分开

例如，输入：
5
则程序应该输出：
0 0 1 2

再例如，输入：
12
则程序应该输出：
0 2 2 2

再例如，输入：
773535
则程序应该输出：
1 1 267 838

资源约定：
峰值内存消耗（含虚拟机） < 256M
CPU消耗  < 3000ms


请严格按要求输出，不要画蛇添足地打印类似：“请您输入...” 的多余内容。

所有代码放在同一个源文件中，调试通过后，拷贝提交该源码。
注意：不要使用package语句。不要使用jdk1.7及以上版本的特性。
注意：主类的名字必须是：Main，否则按无效代码处理。

**解析：**

方案一：采取四层嵌套循环进行

```
Scanner input = new Scanner(System.in);
int n = input.nextInt();
boolean isBreak = false;
for (int a = 0; a*a <= n; a++) {
	if(isBreak == true) break;
	for (int b = a; a*a+b*b <= n; b++) {
		if(isBreak == true) break;
		for (int c = b; a*a+b*b+c*c <= n; c++) {
			if(isBreak == true) break;
			for (int d = c; a*a+b*b+c*c+d*d <= n; d++) {
				if(isBreak == true) break;
				if(n == a*a+b*b+c*c+d*d)
				{
					System.out.println(a+" "+ b+" "+c+" "+d+" ");
					isBreak = true;
				}						
			}
		}
	}
}
```

此方案执行效率不高，可以先组合a和b，然后在组合c和d。

```
Map<Integer, Point> map = new HashMap<Integer, Point>();
Scanner input = new Scanner(System.in);
int n = input.nextInt();
//将c和d组合填充到map中(先组合c,d然后在组合a,b能够保证a<b<c<d)
for (int c = 0; c*c <= n/2; c++) {
	for (int d = c; c*c+d*d <= n; d++) {
		if(map.containsKey(c*c+d*d))
			continue;
		map.put(c*c+d*d, new Point(c,d));
	}
}
//将c和d组合与之前的map进行判断
boolean isBreak = false;
for (int a = 0; a*a <= n/4; a++) {
	if(isBreak == true) break;
	for (int b = a; a*a+b*b <= n/2; b++) {
		if(isBreak == true) break;
		if(map.containsKey(n-a*a-b*b))
		{
			int c = map.get(n-a*a-b*b).x;
			int d = map.get(n-a*a-b*b).y;	
			System.out.println(a+" "+b+" "+c+" "+d);
			isBreak = true;
		}
	}
}
```



# 第十题

密码脱落

X星球的考古学家发现了一批古代留下来的密码。
这些密码是由A、B、C、D 四种植物的种子串成的序列。
仔细分析发现，这些密码串当初应该是前后对称的（也就是我们说的镜像串）。
由于年代久远，其中许多种子脱落了，因而可能会失去镜像的特征。

你的任务是：
给定一个现在看到的密码串，计算一下从当初的状态，它要至少脱落多少个种子，才可能会变成现在的样子。

输入一行，表示现在看到的密码串（长度不大于1000）
要求输出一个正整数，表示至少脱落了多少个种子。

例如，输入：
ABCBA
则程序应该输出：
0

再例如，输入：
ABDCDCBABC
则程序应该输出：
3

资源约定：
峰值内存消耗（含虚拟机） < 256M
CPU消耗  < 3000ms


请严格按要求输出，不要画蛇添足地打印类似：“请您输入...” 的多余内容。

所有代码放在同一个源文件中，调试通过后，拷贝提交该源码。
注意：不要使用package语句。不要使用jdk1.7及以上版本的特性。
注意：主类的名字必须是：Main，否则按无效代码处理。

**解析：**

方案一：

（1）比较第一个和最后一个字符是否相等，不相等则在左边补字符或者在右边补字符保证两端相等。

（2）比较第二个和倒数第二个是否相等，不相等则在左边补字符或者在右边补字符保证两端相等。

（3）依次进行下去。。。

![13](img/13.PNG)

```
static int min = 1000; //假设最小值为1000
private static void pwd(String s,int left,int right,int count) 
{
	if(left >= right)	
	{
		if(count < min)
			min = count;
		return;
	}
	//如果不想等需要左或右进行补字符(不需要真把字符插入，直接递归即可)
	//左补字符right-1即可，右补left+1即可
	if(s.charAt(left) != s.charAt(right)) 
	{
		pwd(s,left,right-1,count+1);
		pwd(s,left+1,right,count+1);
	}
	else	//当连个字符相等时，直接left+1和right-1同时进行
		pwd(s,left+1,right-1,count);
}
public static void main(String[] args) {
	Scanner input = new Scanner(System.in);
	String s = input.next();
	pwd(s,0,s.length()-1,0);
	System.out.println(min);
}
```

由于字符串长度最长为1000，所以此递归深度会很深，效率较低。

方案二：

（1）将原始字符串和倒序之后的字符串进行对比，如下：

```
ABDCDCBABC
CBABCDCDBA
```

（2）找出其最长公共子序列字符串的长度，即如下这种情况是最长情况，结果为7。

![14](img/14.PNG)

（3）最少补位数量 = 字符串总长度 - 最长公共子序列长度 = 10 - 7 = 3。

（4）最长公共子序列求解，将两个字符串进行横轴和纵轴摆放比对；

第一行：交叉字符相等为1；交叉字符不相等第一个数字为0，其它数字为左边的数字。

第一列：交叉字符相等为1；交叉字符不相等第一个数字为0，其它数字为上面的数字。

两者交叉字符相等：取左上角+1。

两者交叉字符不相等：取上和左两个数字中的最大值。

```
	A	B	D	C	D	C	B	A	B	C
C	0	0	0	1	1	1	1	1	1	1
B	0	1	1	1	1	1	2	2	2	2
A	1	1	1	1	1	1	1	3	3	3
B	1	2	2	2	2	2	2	3	4	4
C	1	2	2	3	3	3	3	3	4	5
D	1	2	3	3	4	4	4	4	4	5
C	1	2	3	4	4	5	5	5	5	5
D	1	2	3	4	5	5	5	5	5	5
B	1	2	3	4	5	5	6	6	6	6
A	1	2	3	4	5	5	5	7	7	7
```

取右下角即为最大公共子序列长度 = 7。

```
private static String reserve(String s) 
{
	char[] arr1 = s.toCharArray();	//原始字符串
	char[] arr2 = new char[arr1.length];		//反转之后字符串
	int j = arr1.length-1; //记录原值字符串的下标（依次递减赋值到反转字符串上去）
	for (int i = 0; i < arr2.length; i++) {
		arr2[i] = arr1[j];
		j--;
	}
	return new String(arr2);
}
public static void main(String[] args) {
	Scanner input = new Scanner(System.in);
	String s1 = input.next();  //原始字符串
	String s2 = reserve(s1);	//反转之后字符串
	int[][] arr = new int[s1.length()][s2.length()]; //数组保存子序列数量矩阵
	//处理矩阵第一行数据
	//第一行：交叉字符相等为1；交叉字符不相等第一个数字为0，其它数字为左边的数字。
	for (int j = 0; j < s1.length(); j++) {
		if(s1.charAt(j) == s2.charAt(0))
			arr[0][j] = 1;
		else
			arr[0][j] = j	==	0	?	0	:	arr[0][j-1]	;
	}
	//处理矩阵第一列数据
	//第一列：交叉字符相等为1；交叉字符不相等第一个数字为0，其它数字为上面的数字。
	for (int i = 0; i < s2.length(); i++) {
		if(s2.charAt(i) == s1.charAt(0))
			arr[i][0] = 1;
		else
			arr[i][0] = i == 0 ? 0 : arr[i-1][0] ;
	}
	//处理矩阵其它位置
	//两者交叉字符相等：取左上角+1；两者交叉字符不相等：取上和左两个数字中的最大值。
	for (int i = 1; i < arr.length; i++) {
		for (int j = 1; j < arr.length; j++) {
			if(s1.charAt(j) == s2.charAt(i))
				arr[i][j] = arr[i-1][j-1] + 1;
			else
				arr[i][j] = Math.max(arr[i-1][j], arr[i][j-1]);
		}
	}
	int ans = s1.length() - arr[s2.length()-1][s1.length()-1];
	System.out.println(ans);		
}
```

