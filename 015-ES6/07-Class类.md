# class类

## 一、class基本语法

JavaScript 语言中,编写一个学生类,代码如下：（prototype可以个对象添加属性和方法）

```
function Student(stuno,stuname)
{
	this.stuno = stuno;
	this.stuname = stuname;
}
Student.prototype.stusex = "";
Student.prototype.sayHi = function()
{
	console.log("大家好,我是"+this.stuname+",我的学号是"+this.stuno+",性别:"+this.stusex);
}
var stu = new Student("001","孙悟空");
stu.stusex = "男";
//或
// var stu = new Student();
// stu.stuno = "001";
// stu.stuname = "孙悟空";
// stu.stusex = "男";
stu.sayHi(); //大家好,我是孙悟空,我的学号是001,性别:男
```

ES6提供了更接近传统语言的写法,引入了Class这个概念：

constructor为构造函数,当创建对象的时候自动调用：

```
class Student
{
	constructor(stuno,stuname) {
		this.stuno = stuno;
		this.stuname = stuname;
	}
	sayHi()
	{
		console.log("大家好,我是"+this.stuname+",我的学号是"+this.stuno);
	}
}
var stu = new Student("001","孙悟空");
//或
// var stu = new Student();
// stu.stuno = "001";
// stu.stuname = "孙悟空";
stu.sayHi();	//大家好,我是孙悟空,我的学号是001
```

注意:类的声明第一行除了class Student外,还可以如下写法:

```
let Student = class
let Student = class Student
```

## 二、类的属性和方法

实例属性和实例方法：

```
class Student
{
	stuno = "";
	stuname = "";
	sayHi()  //此处方法有的地方称为原型方法
	{
		console.log("大家好,我是"+this.stuname+",我的学号是"+this.stuno);
	}
}
var stu = new Student();
stu.stuno = "001";
stu.stuname = "孙悟空";
stu.sayHi();
```

静态属性和静态方法：

```
class Student
{
	stuno = "";
	stuname = "";
	static proName = "";  //专业名称
	static proIntroduce()
	{
		console.log("专业名称:"+Student.proName);
	}
	sayHi()
	{
		console.log("大家好,我是"+this.stuname+",我的学号是"+this.stuno);
	}
}
Student.proName = "计算机";
Student.proIntroduce();
```

## 三、实例方法的两种写法

**方案一：（又称原型方法）**

```
class Student
{
	sayHi()
	{
		console.log("hi!");
	}
}
let stu = new Student();
stu.sayHi();
```

等同于ES5中：

```
function Student(){			}
Student.prototype.sayHi=function()
{
	console.log("hi!");
}
var stu = new Student();
stu.sayHi();
```

**方案二：**

```
class Student
{
	constructor()
	{
		this.sayHi = function()
		{
			console.log("hi");
		}
	}
}
let stu = new Student();
stu.sayHi();
```

等同于ES5中：

```
function Student()
{
	this.sayHi = function()
	{
		console.log("hi");
	}
}
var stu = new Student();
stu.sayHi();
```

**当两个方案冲突的时候,constructor里面的函数会覆盖外面的函数：**

```
class Student
{
	sayHi()  //等同Student.prototype.sayHi=function(){...}
	{
		console.log("hi!");
	}
	constructor()
	{
		this.sayHi = function() //等同在function内部定义
		{
			console.log("hello!");
		}
	}
}
let stu = new Student();
stu.sayHi(); //hello!
```

等同于ES5中：

```
function Student()
{
	this.sayHi = function()
	{
		console.log("hello!");
	}
}
Student.prototype.sayHi=function()
{
	console.log("hi!");
}
var stu = new Student();
stu.sayHi(); //hello!
```

## 四、class属性封装

在类的内部可以使用get和set关键字,对某个属性设置存值函数和取值函数,拦截该属性的存取行为。

```
class Student
{
	get stuAge(){
		return this._stuAge;
	}
	set stuAge(age)
	{
		if(age >= 18 && age <= 120)
			this._stuAge = age;
		else
		{
			this._stuAge = 18;
			console.log("年龄有错误,设置默认值18!");
		}
	}
}
let stu = new Student();
stu.stuAge = 17;   //年龄有错误,设置默认值18!
console.log(stu.stuAge); //18
//------------------------------------------------------------------------------
//注意:
//(1)在get和set后的属性名不能和函数里的取值和设置值的变量名相同(stuAge和_stuAge)
//(2)getter不可单独出现
//(3)getter与setter必须同级出现(不能一个在父类,一个在子类)
```

## 五、继承

**通过 extends 实现类的继承。**

```
//通过 extends 实现类的继承。
class People //父类
{
	name = "";
	sex = "";
	age = 0;
	sayHi()
	{
		console.log(`姓名:${this.name},性别:${this.sex},年龄:${this.age}`);
	}
}
class Student extends People  //子类继承父类,拥有父类的属性和方法
{
	
}
class Teacher extends People //子类继承父类,拥有父类的属性和方法
{
	salary = 0; //子类在父类基础上扩展一个属性
	sayHi() //子类在父类基础上重写父类方法
	{
		console.log(`姓名:${this.name},性别:${this.sex},年龄:${this.age},月薪:${this.salary}`);
	}
}
let stu = new Student();
stu.name = "孙悟空";
stu.sex = "男";
stu.age = 500;
stu.sayHi(); //姓名:孙悟空,性别:男,年龄:500

let tc = new Teacher();
tc.name = "唐僧";
tc.sex = "男";
tc.age = 100;
tc.salary = 6000;
tc.sayHi(); //姓名:唐僧,性别:男,年龄:100,月薪:6000
```

## 六、继承和构造方法

**子类通过super()调用父类构造方法：**

```
class People
{
	constructor(name,sex,age)
	{
		this.name = name;
		this.sex = sex;
		this.age = age;
	}
	sayHi()
	{
		console.log(`姓名:${this.name},性别:${this.sex},年龄:${this.age}`);
	}
}
class Student extends People
{
	constructor(name,sex,age)
	{
		super(name,sex,age);
	}
}
class Teacher extends People
{
	constructor(name,sex,age,salary)
	{
		super(name,sex,age);
		this.salary = salary;
	}
	sayHi()
	{
		console.log(`姓名:${this.name},性别:${this.sex},年龄:${this.age},月薪:${this.salary}`);
	}
}
let stu = new Student("孙悟空","男",500);
stu.sayHi(); //姓名:孙悟空,性别:男,年龄:500

let tc = new Teacher("唐僧","男",100,6000);
tc.sayHi();	//姓名:唐僧,性别:男,年龄:100,月薪:6000
//------------------------------------------------
//注意:
//(1)子类 constructor 方法中必须有 super ，且必须出现在 this 之前。
//(2)调用父类构造函数,只能出现在子类的构造函数。
//	例如在sayHi()中调用super就会报错;
```

**super 作为对象的使用：**