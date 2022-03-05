# 第一题

标题：外星日历

某星系深处发现了文明遗迹。

他们的计数也是用十进制。
他们的文明也有日历。日历只有天数，没有年、月的概念。
有趣的是，他们也使用了类似“星期”的概念，
只不过他们的一个星期包含了9天，
为了方便，这里分别记为: A,B,C....H,I

从一些资料上看到，
他们的23日是星期E
他们的190日是星期A
他们的343251日是星期I

令人兴奋的是，他们居然也预见了“世界末日”的那天，
当然是一个很大很大的数字
651764141421415346185

请你计算一下，这遥远的一天是该文明的星期几？

你需要提交的是一个大写字母，表示该文明的星期几，
不要填写任何多余的内容。

**解析：**

```
System.out.println(23%9);  
//此处余数5，题目说星期E，则余数和星期关系如下：
//A	B	C	D	E	F	G	H	I
//1	2	3	4	5	6	7	8	0
//定义bigInteger类型存储天数
BigInteger year = new BigInteger("651764141421415346185");  
//定义bigInteger存储数字9
BigInteger nine = new BigInteger("9");  
//定义一个bigInteger存储最后得到的余数
BigInteger mod = year.mod(nine);
System.out.println(mod.toString());
//此处打印7，则星期为G
```

```
答案：G
```

------------------



# 第二题

标题：兴趣小组

为丰富同学们的业余文化生活，某高校学生会创办了3个兴趣小组
（以下称A组，B组，C组）。
每个小组的学生名单分别在【A.txt】,【B.txt】和【C.txt】中。（查看file\2017_Java_C_省赛文件夹）
每个文件中存储的是学生的学号。

由于工作需要，我们现在想知道：
既参加了A组，又参加了B组，但是没有参加C组的同学一共有多少人？

请你统计该数字并通过浏览器提交答案。

注意：答案是一个整数，不要提交任何多余的内容。

笨笨有话说：
    哇塞！数字好多啊！一眼望过去就能发现相同的，好像没什么指望。
不过，可以排序啊，要是每个文件都是有序的，那就好多了。

歪歪有话说：
    排什么序啊，这么几行数字对计算机不是太轻松了吗？
    我看着需求怎么和中学学过的集合很像啊.....

**解析（方案一）：**

```
Scanner in = new Scanner(System.in);
//接收三份学号名单
int[] A = new int[]{
		12894792, 92774113, 59529208, 22962224, 2991600, 83340521, 87365045, 
		40818286, 16400628, 39475245, 55933381, 76940287, 61366748, 95631228, 
		17102313, 50682833, 61562613, 87002524, 83062019, 51743442, 61977890, 
		32010762, 69680621, 87179571, 81761697, 32364296, 7833271, 36198035, 
		26588918, 84046668, 43059468, 73191775, 56794101, 454780, 11141030, 
		10008994, 35072237, 44945158, 53959980, 75758119, 18560273, 35801494, 
		42102550, 22496415, 3981786, 34593672, 13074905, 07733442, 42374678, 
		23452507, 98586743, 30771281, 17703080, 52123562, 5898131, 56698981, 
		90758589, 18238802, 18217979, 4511837, 75682969, 31135682, 55379006, 
		42224598, 98263070, 40228312, 28924663, 11580163, 25686441, 45944028, 
		96731602, 53675990, 3854194, 14858183, 16866794, 40677007, 73141512, 
		32317341, 56641725, 43123040, 15201174, 62389950, 72887083, 76860787, 
		61046319, 6923746, 17874548, 46028629, 10577743, 48747364, 5328780, 
		59855415, 60965266, 20592606, 14471207, 70896866, 46938647, 33575820, 
		53426294, 56093931, 51326542, 94050481, 80114017, 33010503, 72971538, 
		22407422, 17305672, 78974338, 93209260, 83461794, 41247821, 26118061, 
		10657376, 42198057, 15338224, 50284714, 32232841, 26716521, 76048344, 
		23676625, 62897700, 69296551, 59653393, 38704390, 48481614, 69782897, 
		26850668, 37471053, 88720989, 51010849, 94951571, 60024611, 29808329, 
		70377786, 13899299, 9683688, 58218284, 46792829, 97221709, 45286643, 
		48158629, 57367208, 26903401, 76900414, 87927040, 9926730, 1508757, 
		15101101, 62491840, 43802529
};
int[] B = new int[]{
		44894050, 34662733, 44141729, 92774113, 99208727, 91919833, 23727681, 
		10003409, 55933381, 54443275, 13584702, 96523685, 50682833, 61562613, 
		62380975, 20311684, 93200452, 23101945, 42192880, 28992561, 18460278, 
		19186537, 58465301, 01111066, 62680429, 23721241, 20277631, 91708977, 
		57514737, 3981786, 81541612, 07346443, 93154608, 19709455, 37446968, 
		17703080, 72378958, 66200696, 30610382, 89586343, 33152171, 67040930, 
		35696683, 63242065, 99948221, 96233367, 52593493, 98263070, 1418023, 
		74816705, 89375940, 58405334, 96731602, 84089545, 16866794, 94737626, 
		01673442, 70548494, 13638168, 8163691, 11106566, 64375392, 40267902, 
		897705, 56447313, 54532235, 94738425, 66642634, 83219544, 40546096, 
		66924991, 20592606, 96037590, 73434467, 70896866, 91025618, 57892091, 
		8487641, 32500082, 84412833, 23311447, 38380409, 79957822, 72971538, 
		69645784, 91863314, 73099909, 93209260, 83461794, 81378487, 30423273, 
		22233715, 32232841, 26716521, 03511221, 29196547, 58263562, 56233305, 
		52547525, 55812835, 87253244, 52484232, 80837360, 94098464, 52028151, 
		53267501, 66381929, 84381316, 59788467, 9683688, 67082008, 71605255, 
		80654064, 21434307, 45286643, 76556656, 82465821, 57367208, 79218980, 
		48460468, 59170479, 46046391, 43043164, 96544490, 83340521, 70837892, 
		18926791, 40818286, 28936302, 11489524, 51031183, 73860337, 13241219, 
		9025448, 10718828, 76360986, 26031606, 76558053, 97726139, 46473415, 
		48406387, 23625539, 86756012, 35164187, 49161302, 78082834, 35072237, 
		8602486, 29815841, 56562216, 77684187, 81751704, 20160464, 50407962, 
		27786415, 19893526, 934129, 37759498, 52636463, 25666982, 43262852, 
		38393436, 2581136, 29323250, 56950657, 5898131, 95286262, 75574581, 
		54057961, 6703896, 90758589, 57782642, 34492535, 41919697, 6395464, 
		10993500, 81212949, 34017532, 69569396, 99009936, 57129610, 67401593, 
		71044018, 62076698, 29533873, 71936325, 86874388, 26545032, 35695544, 
		30433724, 53127345, 72887083, 25390873, 63711546, 6923746, 27783723, 
		33199575, 35929698, 16491251, 18276792, 62744775, 92096155, 06336570, 
		56141974, 73007273, 31416832, 00171057, 64176982, 46938647, 58460388, 
		69972026, 73724304, 27435484, 51568616, 15531822, 47788699, 11818851, 
		41594694, 83561325, 43107163, 56965375, 10557343, 26118061, 74650126, 
		90076467, 10657376, 49901436, 03425162, 61164599, 15797769, 5427896, 
		14444084, 36795868, 18079449, 59653393, 72942548, 06763077, 33895610, 
		94892653, 12085268, 65174140, 79567366, 23020126, 74290047, 13498869, 
		21696323, 27724594, 54941003, 38229841, 7050068
};	
int[] C = new int[]{
		13404901, 39952424, 47847739, 94939581, 13809950, 70966043, 11161555, 
		17102313, 47079425, 50682833, 74154313, 61562613, 93200452, 37103342, 
		18479435, 32502597, 36198035, 54210010, 73191775, 48358178, 85544503, 
		5996766, 54651623, 52113220, 27465181, 23871783, 22496415, 54107041, 
		65899605, 56528700, 82671109, 61176034, 42374678, 51612628, 63329997, 
		56591652, 04552733, 12789324, 89586343, 51935014, 38611966, 43916409, 
		70996050, 98263070, 1418023, 65345049, 21734275, 76846198, 71506230, 
		833171, 67128139, 41367555, 64769510, 44010700, 16475199, 93164325, 
		9386162, 95324041, 80688223, 67629139, 79552617, 76219736, 50368644, 
		45096021, 54972488, 63779011, 28862942, 73145521, 74078605, 66924991, 
		12806850, 02171001, 70896866, 73434467, 8487641, 44415025, 32500082, 
		84412833, 83896188, 52243759, 49191410, 38744339, 48079796, 44937032, 
		06267501, 81866886, 38575984, 25978688, 78974338, 41247821, 12356966, 
		64842303, 79127158, 2366944, 68000570, 12426275, 96409230, 705972, 
		8266503, 83820884, 8831807, 43273308, 23216105, 29196547, 95160161, 
		05553537, 52182214, 32641346, 91553427, 24436506, 77433749, 1979664, 
		52028151, 88985343, 1761499, 76203088, 63237368, 23405334, 59788467, 
		9683688, 67755443, 29946533, 12053603, 437479, 15200030, 45286643, 
		93537527, 82465821, 57367208, 53899751, 15354933, 97760830, 68933762, 
		80220545, 1892750, 39868288, 21524323, 69716610, 65083815, 78048499, 
		3227391, 83340521, 87365045, 71720254, 51031183, 89168555, 8503028, 
		37086236, 25103057, 87002524, 22808816, 80928090, 90741678, 15993372, 
		99117082, 49938176, 21755083, 86903426, 87830263, 53959980, 75758119, 
		59781354, 58679691, 25666982, 56307643, 47180521, 62776522, 78136608, 
		44882734, 90758589, 8075999, 66303819, 23480347, 11580163, 87080118, 
		18329165, 92514163, 89404632, 92377859, 3912329, 17499963, 59699979, 
		79876366, 63894807, 37857001, 86003935, 90087123, 29433345, 80298948, 
		61531153, 61046319, 37839841, 19421134, 48747364, 35196916, 62484573, 
		59907079, 36845702, 21631642, 72739317, 26283700, 80114017, 76639390, 
		29154110, 35159758, 47788699, 11818851, 56520669, 36396767, 36031167, 
		83817428, 10657376, 90076467, 14676452, 11024560, 16327605, 76048344, 
		14444084, 95452011, 99612346, 65172562, 84813675, 88618282, 38704390, 
		27998014, 63859011, 33787505, 60024611, 16229880, 13899299, 35240335, 
		29173227, 45036451, 66177893, 82658333, 43100730, 44520187, 74290047, 
		85013538, 9926730, 27724594, 95148523, 20503000, 64390907, 26006953, 
		98116293, 97457666, 29017396, 04634371, 70791589
};
//将数组内容转换到集合中
List<Integer> listA = new ArrayList<Integer>();
List<Integer> listB = new ArrayList<Integer>();
List<Integer> listC = new ArrayList<Integer>();
for (int i = 0; i < A.length; i++) {
	listA.add(A[i]);
}
for (int i = 0; i < B.length; i++) {
	listB.add(B[i]);
}
for (int i = 0; i < C.length; i++) {
	listC.add(C[i]);
}
int count = 0;  //定义计数器记录符合条件的次数
//循环listA集合
for (int i = 0; i < listA.size(); i++) {
	int num = listA.get(i);
	if(listB.contains(num) == true && listC.contains(num) == false)
	{
		count++;
	}
}
System.out.println(count);
```

```
答案：20
```

**解析（方案二）：**

由于不确定题目是否考察读文件操作，所以此版本没有将文件内容复制出来，而是采取读文件的方式读取内容。

```
public static String ReadFile(String path) throws IOException
{
	FileInputStream fis = new FileInputStream(path);
	int size = fis.available();
	byte[] arrTxt = new byte[size];
	fis.read(arrTxt);
	String str = new String(arrTxt);
	fis.close();
	return str;
}
public static void main(String[] args) throws IOException {
	String A = ReadFile("E:\\教学资料V3.0\\MarkDown\\003-Java基础\\04-蓝桥杯\\file\\2017_Java_C_省赛\\A.txt");
	String B = ReadFile("E:\\教学资料V3.0\\MarkDown\\003-Java基础\\04-蓝桥杯\\file\\2017_Java_C_省赛\\B.txt");
	String C = ReadFile("E:\\教学资料V3.0\\MarkDown\\003-Java基础\\04-蓝桥杯\\file\\2017_Java_C_省赛\\C.txt");
	A = A.replace(" ", "").replace("\r\n", "");
	B = B.replace(" ", "").replace("\r\n", "");
	C = C.replace(" ", "").replace("\r\n", "");
	String[] arrA = A.split(",");
	String[] arrB = B.split(",");
	String[] arrC = C.split(",");
	List<String> listA = new ArrayList<String>();
	List<String> listB = new ArrayList<String>();
	List<String> listC = new ArrayList<String>();
	for (int i = 0; i < arrA.length; i++) {
		listA.add(arrA[i]);
	}
	for (int i = 0; i < arrB.length; i++) {
		listB.add(arrB[i]);
	}
	for (int i = 0; i < arrC.length; i++) {
		listC.add(arrC[i]);
	}
	//循环listA集合
	int count = 0;
	for (int i = 0; i < listA.size(); i++) {
		String str = listA.get(i);
		if(listB.contains(str) && !listC.contains(str))
			count++;
	}
	System.out.println(count);
}
```

```
答案：20
```



# 第三题

标题：纸牌三角形

A,2,3,4,5,6,7,8,9 共9张纸牌排成一个正三角形（A按1计算）。要求每个边的和相等。
下图就是一种排法（如有对齐问题，参看p1.png）。

![4](img\4.png)

```
      A
     9 6
    4   8
   3 7 5 2
```

这样的排法可能会有很多。

如果考虑旋转、镜像后相同的算同一种，一共有多少种不同的排法呢？

请你计算并提交该数字。

注意：需要提交的是一个整数，不要提交任何多余内容。

笨笨有话说：
    感觉可以暴力破解哦。
    麻烦的是，对每个排法还要算出它的旋转、镜像排法，看看有没有和历史重复。

歪歪有话说：
    人家又不让你把所有情况都打印出来，只是要算种类数。
    对于每个基本局面，通过旋转、镜像能造出来的新局面数目不是固定的吗？

**解析方案一(循环嵌套)：**

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
							if(a+b+c+d != d+e+f+g) continue;
							for (int h = 1; h <= 9; h++) 
							{
								if(h == a || h== b || h==c || h==d || h==e || h==f || h==g) continue;
								for (int i = 1; i <= 9; i++) 
								{
									if(i == a || i== b || i==c || i==d || i==e || i==f || i==g || i==h) continue;
									if(a+b+c+d == d+e+f+g && a+b+c+d == g + h + i + a)
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
//旋转之后有3种一样的情况，旋转之后每种情况还有一个镜像，所以这里除6
System.out.println(count/6);  
```

```
答案：144
```

**解析方案二(递归)：**

```
static int count = 0;
public static void main(String[] args)
{
	int[] arr = new int[]{1,2,3,4,5,6,7,8,9};
	fullSort(arr,0,arr.length-1);
	//旋转之后有3种一样的情况，旋转之后每种情况还有一个镜像，所以这里除6
	System.out.println(count/6);
}
public static void fullSort(int[] arr,int start,int end)
{
	if(start == end)
	{
		int a = arr[0] + arr[1] + arr[2] + arr[3];
		int b = arr[3] + arr[4] + arr[5] + arr[6];
		int c = arr[6] + arr[7] + arr[8] + arr[0];
		if(a == b && a == c)
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
	int temp = arr[i];
	arr[i] = arr[j];
	arr[j] = temp;
}
```

```
答案：144
```

**解析方案二中涉及到一种全排列算法，具体算法举例如下：**

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



# 第四题

标题：承压计算

X星球的高科技实验室中整齐地堆放着某批珍贵金属原料。

每块金属原料的外形、尺寸完全一致，但重量不同。
金属材料被严格地堆放成金字塔形。

```
                             7 
                            5 8 
                           7 8 8 
                          9 2 7 2 
                         8 1 4 9 1 
                        8 1 8 8 4 1 
                       7 9 6 1 4 5 4 
                      5 6 5 5 6 9 5 6 
                     5 5 4 7 9 3 5 5 1 
                    7 5 7 9 7 4 7 3 3 1 
                   4 6 4 5 5 8 8 3 2 4 3 
                  1 1 3 3 1 6 6 5 5 4 4 2 
                 9 9 9 2 1 9 1 9 2 9 5 7 9 
                4 3 3 7 7 9 3 6 1 3 8 8 3 7 
               3 6 8 1 5 3 9 5 8 3 8 1 8 3 3 
              8 3 2 3 3 5 5 8 5 4 2 8 6 7 6 9 
             8 1 8 1 8 4 6 2 2 1 7 9 4 2 3 3 4 
            2 8 4 2 2 9 9 2 8 3 4 9 6 3 9 4 6 9 
           7 9 7 4 9 7 6 6 2 8 9 4 1 8 1 7 2 1 6 
          9 2 8 6 4 2 7 9 5 4 1 2 5 1 7 3 9 8 3 3 
         5 2 1 6 7 9 3 2 8 9 5 5 6 6 6 2 1 8 7 9 9 
        6 7 1 8 8 7 5 3 6 5 4 7 3 4 6 7 8 1 3 2 7 4 
       2 2 6 3 5 3 4 9 2 4 5 7 6 6 3 2 7 2 4 8 5 5 4 
      7 4 4 5 8 3 3 8 1 8 6 3 2 1 6 2 6 4 6 3 8 2 9 6 
     1 2 4 1 3 3 5 3 4 9 6 3 8 6 5 9 1 5 3 2 6 8 8 5 3 
    2 2 7 9 3 3 2 8 6 9 8 4 4 9 5 8 2 6 3 4 8 4 9 3 8 8 
   7 7 7 9 7 5 2 7 9 2 5 1 9 2 6 5 3 9 3 5 7 3 5 4 2 8 9 
  7 7 6 6 8 7 5 5 8 2 4 7 7 4 7 2 6 9 2 1 8 2 9 8 5 7 3 6 
 5 9 4 5 5 7 5 5 6 3 5 3 9 5 8 9 5 4 1 2 6 1 4 3 5 3 2 4 1 
X X X X X X X X X X X X X X X X X X X X X X X X X X X X X X 
```

其中的数字代表金属块的重量（计量单位较大）。
最下一层的X代表30台极高精度的电子秤。

假设每块原料的重量都十分精确地平均落在下方的两个金属块上，
最后，所有的金属块的重量都严格精确地平分落在最底层的电子秤上。
电子秤的计量单位很小，所以显示的数字很大。

工作人员发现，其中读数最小的电子秤的示数为：2086458231

请你推算出：读数最大的电子秤的示数为多少？

注意：需要提交的是一个整数，不要填写任何多余的内容。

笨笨有话说：
    不断的除2，加到下面，除2,加到下面,.... 不会浮点精度溢出吧？
歪歪有话说：
    怕除不开还不好办， 把每个数字扩大一定的倍数不就好了。

**解析：**

```
Scanner input  = new Scanner(System.in);
double[][] arr = new double[30][30];
System.out.println("将题目中原始字符串复制进来:");
//将题目中的等腰三角形，理解成一个直角三角形，然后给二维数组赋值，没有赋值的地方，默认值为0
for (int i = 0; i < arr.length-1; i++) {
	for (int j = 0; j <= i; j++) {
		arr[i][j] = input.nextDouble();
	}
}
System.out.println();
//为了避免计算过程中不停的除2，造成小数精度有问题，将数组所有元素*1000000000
for (int i = 0; i < arr.length-1; i++) {
	for (int j = 0; j <= i; j++) {
		arr[i][j] = arr[i][j]*Math.pow(2, 30);  //此处取一个比2的30次避免浮点精度溢出
	}
}
//从第二行开始，重新赋值，赋值到最后一行，即可直到最下面电子称的值,
//因为第二行开始，实际重量等于自身重量+上面元素压力下的重量
//具体公式：arr[i][j] += (arr[i-1][j-1]+arr[i-1][j])/2,第一列除外，第一列公式arr[i][j] += arr[i-1][j]/2
//最后一行在前面没有赋值，默认0，所以最后一行没有自身重量，正好全部是上面的压力重量。
for (int i = 1; i < arr.length; i++) 
{
	for (int j = 0; j <= i; j++) {
		if(j==0)
		{
			arr[i][j] += arr[i-1][j]/2;
		}
		else
		{
			arr[i][j] += (arr[i-1][j-1]+arr[i-1][j])/2;
		}
	}
}
//将最后一行进行排序，第一个元素就是最小重量，最后一个元素就是最大重量
Arrays.sort(arr[29]);
double min = arr[29][0];
double max = arr[29][29];
//已知最小2086458231，但不知道单位，所以
//min/2086458231 == max/?
//即我们计算的最小值和给出的最小值的比例，和计算的最大值与实际最大值比例一定相等。
System.out.println(max*2086458231/min);
```

```
答案：7.2665192664E10 即 72665192664
```



# 第五题

标题： 杨辉三角

杨辉三角也叫帕斯卡三角，在很多数量关系中可以看到，十分重要。

```
第0行：           1
第1行：          1 1
第2行：         1 2 1
第3行：        1 3 3 1
第4行：       1 4 6 4 1
....
```

两边的元素都是1， 中间的元素是左上角的元素与右上角的元素和。

我们约定，行号，列号都从0计数。
所以： 第6行的第2个元素是15，第3个元素是20

直观地看，需要开辟一个二维数组，其实一维数组也可以胜任。
如下程序就是用一维数组“腾挪”的解法。

```
public class A
{
	// 杨辉三角形的第row行第col列
	static long f(int row, int col){
		if(row<2) return 1;
		if(col==0) return 1;
		if(col==row) return 1;
		
		long[] a = new long[row+1];
		a[0]=1;
		a[1]=1;
		
		int p = 2;
		
		while(p<=row){
			a[p] = 1;
			for( __________________ ) a[q] = a[q] + a[q-1];
			p++;
		}
		
		return a[col];
	}
	
	public static void main(String[] args){
		System.out.println(f(6,2));
		System.out.println(f(6,3));		
	}
}
```

请仔细分析源码，并完成划线部分缺少的代码。
注意：只提交缺少的代码，不要提交已有的代码和符号。也不要提交说明性文字。

**解析：**

```
/*
1
1 1
1 2 1
1 3 3 1
1 4 6 4 1
 * */
// 杨辉三角形的第row行第col列
static long f(int row, int col){
	if(row<2) return 1;    //第一行和第二行全部为1
	if(col==0) return 1;   //第一列全部为1
	if(col==row) return 1;	//每行最后一列全部为1
	//以上3行代码符合的情况直接返回		
	long[] a = new long[row+1];   //定义数组存储当前行元素，元素个数=row+1
	//初始化第二行的状态，第二行2个数字都是1
	a[0]=1;    //此处a[0]=1,不但初始化第二行状态，也为后面每个循环行的第一个元素赋值1
	a[1]=1;  
	//p=2,使用p计数进行循环，意味着从第三行开始循环
	int p = 2;   //行数，在下面从第三行开始循环
	//循环行,从第三行开始循环,分别用数组记录第三行结果，
	//第四行结果由第三行结果得到
	//第五行结果由第四行结果得到
	//以此类推.......
	while(p<=row)   
	{
		a[p] = 1;  //每行的最后一个元素=1
		//当前行的数据=while上次循环行的同一列，和上一列的和
		for(int q=p-1;q>=1;q-- ) a[q] = a[q] + a[q-1];
		p++;
	}
	return a[col];
}

public static void main(String[] args){
	System.out.println(f(6,2));
	System.out.println(f(6,3));	
}
```



# 第六题

标题：最大公共子串

最大公共子串就是求两个串的所有子串中能够匹配上的最大长度是多少。

比如："abcdkkk" 和 "baabcdadabc"，
可以找到的最长的公共子串是"abcd",所以最大公共子串长度为4。

下面的程序是采用矩阵法进行求解的，这对串的规模不大的情况还是比较有效的解法。

请分析该解法的思路，并补全划线部分缺失的代码。

```
public class A
{
	static int f(String s1, String s2)
	{
		char[] c1 = s1.toCharArray();
		char[] c2 = s2.toCharArray();
		
		int[][] a = new int[c1.length+1][c2.length+1];
		
		int max = 0;
		for(int i=1; i<a.length; i++){
			for(int j=1; j<a[i].length; j++){
				if(c1[i-1]==c2[j-1]) {
					a[i][j] = _______________________ ; //填空 
					if(a[i][j] > max) max = a[i][j];
				}
			}
		}
		
		return max;
	}
	
	public static void main(String[] args){
		int n = f("abcdkkk", "baabcdadabc");
		System.out.println(n);
	}
}
```

注意：只提交缺少的代码，不要提交已有的代码和符号。也不要提交说明性文字。

**解析：**

```
答案：a[i-1][j-1]+1;
当前计数 = 两个字符串前面一次比较后的结果+1。
```

以两个字符串为"abcdkkk"和"baabcdadabc"为例，长度分别为7和11，则定义8行12列数组。

| 0    | 0-b  | 0-a  | 0-a  | 0-b  | 0-c  | 0-d  | 0-a  | 0-d  | 0-a  | 0-b  | 0-c  |
| ---- | ---- | ---- | ---- | ---- | ---- | ---- | ---- | ---- | ---- | ---- | ---- |
| 0-a  | ？   | ？   | ？   | ？   | ？   | ？   | ？   | ？   | ？   | ？   | ？   |
| 0-b  | ？   | ？   | ？   | ？   | ？   | ？   | ？   | ？   | ？   | ？   | ？   |
| 0-c  | ？   | ？   | ？   | ？   | ？   | ？   | ？   | ？   | ？   | ？   | ？   |
| 0-d  | ？   | ？   | ？   | ？   | ？   | ？   | ？   | ？   | ？   | ？   | ？   |
| 0-k  | ？   | ？   | ？   | ？   | ？   | ？   | ？   | ？   | ？   | ？   | ？   |
| 0-k  | ？   | ？   | ？   | ？   | ？   | ？   | ？   | ？   | ？   | ？   | ？   |
| 0-k  | ？   | ？   | ？   | ？   | ？   | ？   | ？   | ？   | ？   | ？   | ？   |

然后在循环中依次改变数组中?区域的值，最后求出所有?值的最大值即是最终答案。

每个？的值记录两个字符串当前是连续第几次相等：

即比较第一个字符串i位置和第二个字符串j位置

# 第七题

标题： Excel地址

Excel单元格的地址表示很有趣，它使用字母来表示列号。

```
比如，
A表示第1列，
B表示第2列，
Z表示第26列，
AA表示第27列，
AB表示第28列，
BA表示第53列，
....
```

当然Excel的最大列号是有限度的，所以转换起来不难。
如果我们想把这种表示法一般化，可以把很大的数字转换为很长的字母序列呢？

本题目既是要求对输入的数字, 输出其对应的Excel地址表示方式。

例如，
输入：
26
则程序应该输出：
Z

再例如，
输入：
2054
则程序应该输出：
BZZ

我们约定，输入的整数范围[1,2147483647]

资源约定：
峰值内存消耗（含虚拟机） < 256M
CPU消耗  < 1000ms


请严格按要求输出，不要画蛇添足地打印类似：“请您输入...” 的多余内容。

所有代码放在同一个源文件中，调试通过后，拷贝提交该源码。
不要使用package语句。不要使用jdk1.7及以上版本的特性。
主类的名字必须是：Main，否则按无效代码处理。

笨笨有话说：
    这有点像进制关系，又不完全是。好像末2位是以1当26，末3位是以1当26*26

歪歪有话说：
    要是从字母序列转数字还好点，倒过来有点麻烦，不过计算机跑得快啊。

**解析一：**

定义集合，在集合中插入N个元素来模拟数字的变大操作，集合中每个元素取值范围为1-26，集合元素填充完成后，将集合中的数字和A-Z字母进行对应，即题目中歪歪同学的常规思路。

```
List<Integer> list = new ArrayList<Integer>();
Scanner input = new Scanner(System.in);
long n = input.nextLong();
list.add(0);
//每循环一次，则模拟一次+1操作
for (int i = 1; i <= n; i++) {
	int num =list.get(list.size()-1)+1; //最后一个元素+1
	if(num <= 26)
		list.set(list.size()-1, num);  //将最后一个元素+1的值写入集合最后一个元素
	else	//当num==27的时候的处理
	{
		//集合只有一个元素则插入一个元素,设置两个元素值都为1
		if(list.size()-1==0) 
		{
			list.add(0, 1);
			list.set(1, 1);
		}
		else //集合有多个元素则从倒数第二个开始倒序循环尝试+1操作
		{
			boolean isJia1 = false;  //假设一直都没有机会在前面+1,则前面全部是26
			for (int j = list.size()-2; j >= 0; j--) {
				if(list.get(j) < 26)  //前面位数<26则+1操作，并且后面全部设置为1
				{
					list.set(j, list.get(j)+1);
					for (int j2 = j+1; j2 < list.size(); j2++) {
						list.set(j2, 1);
					}
					isJia1 = true;
					break;
				}
			}
			if(isJia1 == false)  //一直都没有+1,则添加一位1，进位,后面全部设置为1
			{
				list.add(0, 1);
				for (int j = 1; j < list.size(); j++) {
					list.set(j, 1);
				}				
			}
			
		}
	}		
}
String result = "";
for (int i = 0; i < list.size(); i++) 
{
	//因为A的ASCII码为65，所以加65就可以找到相对应的字符.
	result = result + (char)(list.get(i)+64);
	//System.out.println(list.get(i));
}
System.out.println(result);
```

**解析二：**

根据十进制向其它进制转换的规则，除以基数取逆余数，但此题目与进制转换有如下区别：

（1）进制转换中的余数可能为0，而此题中的结果不能含有0。

（2）如将52不停除以26取逆余数，结果为2：0，即B：0，而其实52结果应为A：Z。

（3）此时需要将余数的0转换为26，然后将相除之后结果 -1，才能满足题意，如下举例：

【1】52 / 26 等于2余0，此时将0变成26，将2减一操作变成1。此余数取26。

【2】将结果 1 / 26 等于0余1，此时余数取1。

【3】最后取逆余数为 1：26，即A：Z。

```
//输入数字
Scanner input = new Scanner(System.in);
long n = input.nextLong();
//定义一个集合存储余数
List<Integer> list = new ArrayList<Integer>();
while(true)
{
	int mod = (int)(n%26);
	//求出的余数是0-25，利用下面的判断转换成1-26
	if(mod == 0)
	{
		list.add(26);
		n--; //此处-1，举例52需要得到AZ,如果不减1，n=2,下轮循环2%26余数2，得到BZ
	}
	else
		list.add(mod);
	n=n/26;
	if(n == 0)
		break;
}
//倒序循环存储余数的循环
String result = "";
for (int i = list.size()-1; i >= 0; i--) 
{
	//因为A的ASCII码为65，所以加65就可以找到相对应的字符.
	result = result + (char)(list.get(i)+64);
	//System.out.println(list.get(i));
}
System.out.println(result);
```



# 第八题

标题：拉马车

小的时候，你玩过纸牌游戏吗？
有一种叫做“拉马车”的游戏，规则很简单，却很吸引小朋友。

其规则简述如下：
假设参加游戏的小朋友是A和B，游戏开始的时候，他们得到的随机的纸牌序列如下：
A方：[K, 8, X, K, A, 2, A, 9, 5, A]
B方：[2, 7, K, 5, J, 5, Q, 6, K, 4]

其中的X表示“10”，我们忽略了纸牌的花色。

从A方开始，A、B双方轮流出牌。

当轮到某一方出牌时，他从自己的纸牌队列的头部拿走一张，放到桌上，并且压在最上面一张纸牌上（如果有的话）。

此例中，游戏过程：
A出K，B出2，A出8，B出7，A出X，此时桌上的序列为：

K,2,8,7,X

当轮到B出牌时，他的牌K与桌上的纸牌序列中的K相同，则把包括K在内的以及两个K之间的纸牌都赢回来，放入自己牌的队尾。注意：为了操作方便，放入牌的顺序是与桌上的顺序相反的。
此时，A、B双方的手里牌为：
A方：[K, A, 2, A, 9, 5, A]
B方：[5, J, 5, Q, 6, K, 4, K, X, 7, 8, 2, K]

赢牌的一方继续出牌。也就是B接着出5，A出K，B出J，A出A，B出5，又赢牌了。
5,K,J,A,5
此时双方手里牌：
A方：[2, A, 9, 5, A]
B方：[Q, 6, K, 4, K, X, 7, 8, 2, K, 5, A, J, K, 5]

注意：更多的时候赢牌的一方并不能把桌上的牌都赢走，而是拿走相同牌点及其中间的部分。但无论如何，都是赢牌的一方继续出牌，有的时候刚一出牌又赢了，也是允许的。

当某一方出掉手里最后一张牌，但无法从桌面上赢取牌时，游戏立即结束。

对于本例的初始手牌情况下，最后A会输掉，而B最后的手里牌为：9K2A62KAX58K57KJ5

本题的任务就是已知双方初始牌序，计算游戏结束时，赢的一方手里的牌序。当游戏无法结束时，输出-1。

输入为2行，2个串，分别表示A、B双方初始手里的牌序列。
输出为1行，1个串，表示A先出牌，最后赢的一方手里的牌序。

例如，
输入：
96J5A898QA
6278A7Q973

则程序应该输出：
2J9A7QA6Q6889977

再比如，
输入：
25663K6X7448
J88A5KJXX45A

则程序应该输出：
6KAJ458KXAX885XJ645

我们约定，输入的串的长度不超过30

资源约定：
峰值内存消耗（含虚拟机） < 256M
CPU消耗  < 1000ms


请严格按要求输出，不要画蛇添足地打印类似：“请您输入...” 的多余内容。

所有代码放在同一个源文件中，调试通过后，拷贝提交该源码。
不要使用package语句。不要使用jdk1.7及以上版本的特性。
主类的名字必须是：Main，否则按无效代码处理。

笨笨有话说：
    不断删除前边的，又要后边添加.... 如果用数组，需要开一个大点的，请佛祖保佑在游戏结束前，不会用到数组的边缘。

歪歪有话说：
    反正串也不长，不如每次操作都返回一个新的串。

默默有话说：
    我一般都不吱声，这是典型的队列结构，动态数组最好，没有？自己造一个呗！

**解析：**

```
//模拟出牌，改变手上的牌和桌上的牌
//判断是否赢牌，此处赢牌不是指最终的输赢，而是指当前出牌是否可以从桌上赢牌到手上
public static boolean PlayPoker(StringBuilder strPlayer,StringBuilder strDesk)
{
	char ch = strPlayer.charAt(0); //记录手上当前出的牌
	strPlayer.deleteCharAt(0); //从手上删除一张牌
	strDesk.append(ch); //桌上放了一张牌
	if(strDesk.lastIndexOf(ch+"", strDesk.length()-2) != -1) //赢牌
	{
		int index = strDesk.indexOf(ch+""); //记录桌上与出的牌相同的牌的下标
		for(int i = strDesk.length()-1; i >= index;i--)  //将桌上牌赢到手上
		{
			strPlayer.append(strDesk.charAt(i));
		}
		strDesk.delete(index, strDesk.length());  //删除桌上的牌
		return true;
	}
	else
		return false;
}
public static void main(String[] args) {
	Scanner input = new Scanner(System.in);
	StringBuilder strA = new StringBuilder(input.next());  //A的牌
	StringBuilder strB = new StringBuilder(input.next());  //B的牌
	StringBuilder strDesk = new StringBuilder("");  //桌上的牌
	char AB = 'A'; //A先出牌
	for(int i=1; i<=100000; i++)
	{
		if(AB == 'A') //A出牌的过程
		{
			boolean isWin = PlayPoker(strA,strDesk); //模拟出牌
			if(strA.length() == 0) //A输了
			{
				System.out.println(strB.toString());
				return;
			}
			AB = isWin == true ? 'A':'B';
		}
		else  //B出牌的过程
		{
			boolean isWin = PlayPoker(strB,strDesk); //模拟出牌
			if(strB.length() == 0) //B输了
			{
				System.out.println(strA.toString());
				return;
			}
			AB = isWin == true ? 'B':'A';
		}
	}
	System.out.println("-1");
}
```

在程序中如果无法知道出牌的哪个环节出了问题，可以在出牌循环中加入输入代码让每次出牌暂停，输入任意内容后继续，并且打印每次出牌后的结果来分析问题，调试版本如下：

```
//模拟出牌，改变手上的牌和桌上的牌
//判断是否赢牌，此处赢牌不是指最终的输赢，而是指当前出牌是否可以从桌上赢牌到手上
public static boolean PlayPoker(StringBuilder strPlayer,StringBuilder strDesk)
{
	char ch = strPlayer.charAt(0); //记录手上当前出的牌
	strPlayer.deleteCharAt(0); //从手上删除一张牌
	strDesk.append(ch); //桌上放了一张牌
	if(strDesk.lastIndexOf(ch+"", strDesk.length()-2) != -1) //赢牌
	{
		int index = strDesk.indexOf(ch+""); //记录桌上与出的牌相同的牌的下标
		for(int i = strDesk.length()-1; i >= index;i--)  //将桌上牌赢到手上
		{
			strPlayer.append(strDesk.charAt(i));
		}
		strDesk.delete(index, strDesk.length()); //删除桌上的牌
		return true;
	}
	else
		return false;
}
public static void main(String[] args) {
	Scanner input = new Scanner(System.in);
	StringBuilder strA = new StringBuilder(input.next());  //A的牌
	StringBuilder strB = new StringBuilder(input.next());  //B的牌
	StringBuilder strDesk = new StringBuilder("");  //桌上的牌
	char AB = 'A'; //A先出牌
	for(int i=1; i<=100000; i++)
	{
		Scanner sc = new Scanner(System.in);
		int temp = sc.nextInt();
		if(AB == 'A') //A出牌的过程
		{
			boolean isWin = PlayPoker(strA,strDesk); //模拟出牌
			if(strA.length() == 0) //A输了
			{
				System.out.println(strB.toString());
				return;
			}
			AB = isWin == true ? 'A':'B';
		}
		else  //B出牌的过程
		{
			boolean isWin = PlayPoker(strB,strDesk); //模拟出牌
			if(strB.length() == 0) //B输了
			{
				System.out.println(strA.toString());
				return;
			}
			AB = isWin == true ? 'B':'A';
		}
		System.out.print("A:");
		System.out.println(strA.toString());
		System.out.print("B:");
		System.out.println(strB.toString());	
		System.out.print("Desk:");
		System.out.println(strDesk.toString());
	}
	System.out.println("-1");
}
```

# 第九题

标题：青蛙跳杯子

X星球的流行宠物是青蛙，一般有两种颜色：白色和黑色。
X星球的居民喜欢把它们放在一排茶杯里，这样可以观察它们跳来跳去。
如下图，有一排杯子，左边的一个是空着的，右边的杯子，每个里边有一只青蛙。

```
*WWWBBB
```

其中，W字母表示白色青蛙，B表示黑色青蛙，*表示空杯子。

X星的青蛙很有些癖好，它们只做3个动作之一：
       1. 跳到相邻的空杯子里。
    2. 隔着1只其它的青蛙（随便什么颜色）跳到空杯子里。
    3. 隔着2只其它的青蛙（随便什么颜色）跳到空杯子里。

对于上图的局面，只要1步，就可跳成下图局面：

```
WWW*BBB
```

本题的任务就是已知初始局面，询问至少需要几步，才能跳成另一个目标局面。

输入为2行，2个串，表示初始局面和目标局面。
输出要求为一个整数，表示至少需要多少步的青蛙跳。

```
例如：
输入：
*WWBB
WWBB*

则程序应该输出：
2

再例如，
输入：
WWW*BBB
BBB*WWW

则程序应该输出：
10
```

我们约定，输入的串的长度不超过15

资源约定：
峰值内存消耗（含虚拟机） < 256M
CPU消耗  < 1000ms

请严格按要求输出，不要画蛇添足地打印类似：“请您输入...” 的多余内容。

所有代码放在同一个源文件中，调试通过后，拷贝提交该源码。
不要使用package语句。不要使用jdk1.7及以上版本的特性。
主类的名字必须是：Main，否则按无效代码处理。

笨笨有话说：
    我梦见自己是一棵大树，
    青蛙跳跃，
    我就发出新的枝条，
    春风拂动那第 5 层的新枝,
    哦，我已是枝繁叶茂。

**解析：**

```
import java.util.LinkedList;
import java.util.Queue;
import java.util.Scanner;
import java.util.TreeSet;

//WWW*BBBWWWBBBW
//BBB*WWWBBBWWWW
//结果：20，用于测试执行速度
class MyNode
{
	String str;  //字符串
	int step;   //字符串变化中的步骤是第几步
	public MyNode(String str,int step)
	{
		this.str = str;
		this.step = step;
	}
}
public class T09 
{
	//存储所有跳杯子过程中的字符串,用于循环中查重，剪枝
	//此处不能使用ArrayList或LinkedList,执行效率会很低下。
	static TreeSet<String> set = new TreeSet<String>(); 
	public static void main(String[] args)
	{
		Scanner input = new Scanner(System.in);
		String strStart = input.next();
		String strEnd = input.next();
		jump(strStart,strEnd);
	}	
	public static void jump(String strStart,String strEnd)
	{
		Queue<MyNode> queue = new LinkedList<MyNode>();
		queue.add(new MyNode(strStart,0));  //队列中添加第一个元素
		set.add(strStart); //set中添加第一个元素
		while(queue.size() != 0)
		{ 
			MyNode myNode = queue.poll(); //队列取出第一个元素并且删除第一个元素
			//System.out.println("------"+myNode.str );
			if(myNode.str.equals(strEnd)) //如果当前队列内容和目标内容相同，则程序结束
			{
				System.out.println(myNode.step);
				break;
			}
			char[] arrCh = myNode.str.toCharArray();  //字符串转字符数组
			int index = myNode.str.indexOf("*");   //确定*的位置
			//确定交换的开始和结束位置
			int start = index-3;   //与*交换的开始位置
			int end = index + 3; //与*交换的结束位置
			if(start <= 0) start = 0;
			if(end >= arrCh.length - 1) end = arrCh.length-1;
			//循环计算当前节点下所有跳杯后的结果
			for (int i = start; i <=end; i++)
			{
				if(arrCh[i] == '*')   //自己和自己不用交换
					continue;
				swap(arrCh,i,index); //交换跳杯
				//判断当前交换后的字符串在原始的set中是否存在，不存在则需要添加到队列,存在则不需要添加
				if(set.contains(String.valueOf(arrCh)) == false)
				{
					MyNode tempNode = new MyNode(String.valueOf(arrCh), myNode.step+1);
					queue.add(tempNode);
					set.add(tempNode.str);
					//System.out.println(tempNode.str + "," + tempNode.step);
				}
				swap(arrCh,i,index); //还原交换跳杯
			}	
		}
	}
	public static void swap(char[] arr,int i,int j)
	{
		char temp = arr[i];
		arr[i] = arr[j];
		arr[j] = temp;
	}	
}
```

备注：

（1）此题思路为用队列Queue存储第一个自定义节点MyNode，节点字符串为题目输入开始字符串，step为0，

（2）然后取出Queue队列的每个元素，并且删除该元素，将该元素可以移动成为的所有字符串在添加到Queue队列中，并且将其step赋值当前节点的step+1.（此处如果交换计算得出的字符串在TreeSet中已经存在则不添加，实现模拟剪枝操作）。

（3）在不停的取Queue队列每个元素过程中，判断当前节点的字符串是否和目标字符串相等，相等则打印step结果。

（4）此题中step的变化一定是从小到大的，也就是说一定是将step=1的所有字符串处理完成后才会处理step=2的情况，所以只要出现相等情况，则step就是最小值。

（5）此题存储历史字符串集合，不用使用List接口下的LinkedList或ArrayList，会超过时间，需要使用TreeSet。



# 第十题

标题：图形排版

小明需要在一篇文档中加入 N 张图片，其中第 i 张图片的宽度是 Wi，高度是 Hi。  

假设纸张的宽度是 M，小明使用的文档编辑工具会用以下方式对图片进行自动排版：

​    1. 该工具会按照图片顺序，在宽度 M 以内，将尽可能多的图片排在一行。该行的高度是行内最高的图片的高度。例如在 M=10 的纸张上依次打印 3x4, 2x2, 3x3 三张图片，则效果如下图所示，这一行高度为4。(分割线以上为列标尺，分割线以下为排版区域；数字组成的矩形为第x张图片占用的版面)

```
0123456789
----------
111
111  333
11122333
11122333
```

2. 如果当前行剩余宽度大于0，并且小于下一张图片，则下一张图片会按比例缩放到宽度为当前行剩余宽度(高度向上取整)，然后放入当前行。例如再放入一张4x9的图片，由于剩余宽度是2，这张图片会被压缩到2x5，再被放入第一行的末尾。此时该行高度为5：

```
0123456789
----------
        44
111     44
111  33344
1112233344
1112233344
```

​    3. 如果当前行剩余宽度为0，该工具会从下一行开始继续对剩余的图片进行排版，直到所有图片都处理完毕。此时所有行的总高度和就是这 N 张图片的排版高度。例如再放入11x1, 5x5, 3x4 的图片后，效果如下图所示，总高度为11：

```
0123456789
----------
        44
111     44
111  33344
1112233344
1112233344
5555555555
66666
66666777
66666777
66666777
66666777
```

现在由于排版高度过高，图片的先后顺序也不能改变，小明只好从 N 张图片中选择一张删除掉以降低总高度。他希望剩余N-1张图片按原顺序的排版高度最低，你能求出最低高度是多少么？

输入：
第一行包含两个整数 M 和 N，分别表示纸张宽度和图片的数量。
接下来 N 行，每行2个整数Wi, Hi，表示第 i 个图大小为 Wi*Hi。

对于30%的数据，满足1<=N<=1000
对于100%的数据，满足1<=N<=100000，1<=M, Wi, Hi<=100

输出：
一个整数，表示在删除掉某一张图片之后，排版高度最少能是多少。

样例输入：
4 3
2 2
2 3
2 2

样例输出：
2

另一个示例，
样例输入：
2 10
4 4
4 3
1 3
4 5
2 1
2 3
5 4
5 3
1 5
2 4

样例输出：
17

资源约定：
峰值内存消耗（含虚拟机） < 256M
CPU消耗  < 2000ms


请严格按要求输出，不要画蛇添足地打印类似：“请您输入...” 的多余内容。

所有代码放在同一个源文件中，调试通过后，拷贝提交该源码。
不要使用package语句。不要使用jdk1.7及以上版本的特性。
主类的名字必须是：Main，否则按无效代码处理。

**解析：**

```
//自定义类型存储图形的宽高
class MyShape
{
	int width;  //宽
	int height; //高
}

public class Demo10 
{
	public static void main(String[] args) 
	{
		List<MyShape> listShape = new ArrayList<MyShape>();  //定义形状集合
		Scanner input = new Scanner(System.in);
		int paperWidth = input.nextInt();  //输入纸张宽度
		int picNum = input.nextInt();      //输入形状图片数量
		//循环输入每个图形的宽与高
		for (int i = 1; i <= picNum; i++) 
		{
			MyShape myShape = new MyShape();
			myShape.width = input.nextInt();
			myShape.height = input.nextInt();
			listShape.add(myShape);
		}
		int[] arr_sum_max_height = new int[picNum]; //定义数组存储删除每张图后的最大高度
		for (int i = 0; i < listShape.size(); i++)  //控制删除每张图片 
		{
			int sy_width = paperWidth;  //纸张剩余宽度=纸张的原始宽度
			int row_max_height = 0;  //纸张的当前行最大高度
			int sum_max_height = 0;  //纸张的总体最大高度
			//循环往纸张上放入图形
			for (int j = 0; j < listShape.size(); j++)  
			{
				int s_width = listShape.get(j).width;  //存储当前图片宽度
				int s_height = listShape.get(j).height; //存储当前图片高度
				//忽略删除的图片
				if(i == j)
					continue;
				//当剩余宽度大于等于当前形状的宽度的时候,直接在右边放入图片
				if(sy_width > s_width)
				{
					if(row_max_height < s_height)
						row_max_height = s_height;	//跟新最大高度值
					sy_width = sy_width - s_width; //跟新纸张剩余宽度
					continue;
				}
				//当剩余宽度正好等于当前形状宽度的时候
				if(sy_width == s_width)
				{
					if(row_max_height < s_height)
						row_max_height = s_height;	//跟新最大高度值
					sy_width = paperWidth; //跟新下一行纸张剩余宽度
					sum_max_height += row_max_height;  //累加总高度
					row_max_height = 0; //跟新下一行的纸张最大高度
					continue;
				}
				//当纸张剩余宽度小于当前形状宽度的时候，缩放后在进行存放
				if(sy_width > 0 && sy_width < s_width)
				{
					//图形宽度/剩余宽度 = 图形高度/纸张占用高度，所以
					//纸张占用高度 = 图形高度/(图形宽度/剩余宽度)
					int height = (int)Math.ceil((s_height*1.0)/((s_width*1.0)/(sy_width*1.0)));
					if(row_max_height < height)
						row_max_height = height;	//跟新最大高度值
					sy_width = paperWidth; //跟新下一行纸张剩余宽度
					sum_max_height += row_max_height;  //累加总高度
					row_max_height = 0; //跟新下一行的纸张最大高度
				}
				
			}
			//测试删除每个图形后的最大高度
			//System.out.println(sum_max_height+row_max_height);
			//此时需要+row_max_height，因为sum_max_height只是存储整行宽度排版完成之后的最大值，
			//也就是当前行上面所有行的最大高度。
			arr_sum_max_height[i] = sum_max_height+row_max_height;
		}
		//求arr_sum_max_height数组的最小值即是最终结果。
		int min = Integer.MAX_VALUE;
		for (int j = 0; j < arr_sum_max_height.length; j++) {
			if(min > arr_sum_max_height[j])
				min = arr_sum_max_height[j];
		}
		System.out.println(min);		
	}
}
```

备注：此题采取假设每个图形是被忽略的，依次算出最大高度，然后在所有的最大高度中取最小值。

