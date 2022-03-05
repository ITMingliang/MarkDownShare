# Map和Set

## 一、Map对象

Map 对象保存键值对。任何值(对象或者原始值) 都可以作为一个键或一个值。 

Map中的键值是有序的。

```
let myMap = new Map();
myMap.set("23","乔丹");
myMap.set("33","皮蓬");
let name = myMap.get("33");
console.log(name);  //皮蓬
let has = myMap.has("24"); //查找是否含有此键
console.log(has); //false
```

**Map的迭代：**

```
let myMap = new Map();
myMap.set("23","乔丹");
myMap.set("33","皮蓬");
myMap.set("99","罗德曼");
//循环键
for (let key of myMap.keys()) {
  console.log(key);
}		
//循环值
for (let value of myMap.values()) {
  console.log(value);
}			
//循环键和值
for (let [key, value] of myMap) {
  console.log(key + " = " + value);
}
//或
for (let [key, value] of myMap.entries()) {
  console.log(key + " = " + value);
}
			
//使用forEach循环
myMap.forEach(function(value,key){
	console.log(key + "=" + value);
},myMap);
```

**Map 与 Array的转换：**

```
//二维数组转换成map对象
let arr = [[23,"乔丹"],[33,"皮蓬"],[99,"罗德曼"]];
let myMap = new Map(arr);
for (let [key, value] of myMap) {
  console.log(key + " = " + value);
}
//map对象转换成二维数组
let outArr = Array.from(myMap);
console.log(outArr);
```

**Map的克隆：**

```
let myMap1 = new Map([[23,"乔丹"],[33,"皮蓬"],[99,"罗德曼"]]);
let myMap2 = new Map(myMap1);
for (let [key, value] of myMap2) {
   console.log(key + " = " + value);
}
```

**Map的合并(合并两个 Map 对象时，如果有重复的键值，则后面的会覆盖前面的)**

	let myMap1 = new Map([[23,"乔丹"],[33,"皮蓬"],[99,"罗德曼"]]);
	let myMap2 = new Map([[23,"詹姆斯"],[24,"科比"],[11,"姚明"]]);
	let myMap = new Map([...myMap1,...myMap2]); //合并之后詹姆斯会替换乔丹
	for (let [key, value] of myMap) {
		console.log(key + " = " + value);
	}
## 二、Set对象

 Set 对象允许你存储任何类型的唯一值，无论是原始值或者是对象引用。 

 Set 对象存储的值总是唯一的，所以需要判断两个值是否恒等。有几个特殊值需要特殊对待： 

（1） +0 与 -0 在存储判断唯一性的时候是恒等的，所以不重复； 

（2） undefined 与 undefined 是恒等的，所以不重复； 

（3） NaN 与 NaN 是不恒等的，但是在 Set 中只能存一个，不重复。 

```
let mySet = new Set();
mySet.add(1);
mySet.add("hello");  //这里体现了类型的多样性
mySet.add(2);
mySet.add(1); //这里添加不了,这里体现了值的唯一性
console.log(mySet); //{1,"hello",2}
console.log(mySet.has(3)); //false, 是否含有3
```

以下代码体现了对象之间引用不同不恒等，即使值相同，Set 也能存储

```
let mySet = new Set();
let o = {a: 1, b: 2}; 
mySet.add(o);
mySet.add({a: 1, b: 2});
console.log(mySet);
```

**Set类型转换：**

```
//Array 转 Set
let arr = ["乔丹","皮蓬","罗德曼"];
let mySet = new Set(arr);
console.log(mySet);

//Set转Array(使用...)
let mySet = new Set();
mySet.add("乔丹");
mySet.add("皮蓬");
mySet.add("罗德曼");
let arr = [...mySet];
console.log(arr);

//字符串转Set(注:Set中toString方法是不能将Set转换成String)
let mySet = new Set("hello");
console.log(mySet);  //h e l o (两个l只出现一次)
```

**Set对象的作用：**

```
//数组去重复
let mySet = new Set([1,2,1,2,3,3,4,5,6,4,7]);
let arr = [...mySet];
console.log(arr); //1,2,3,4,5,6,7

//数组求并集
let a = new Set([1, 2, 3]);
let b = new Set([4, 3, 2]);
let union = new Set([...a, ...b]);
let arr = [...union];
console.log(arr); //1, 2, 3, 4

//数组求交集
let a = new Set([1, 2, 3]);
let b = new Set([4, 3, 2]);
let intersect = new Set([...a].filter(p=>b.has(p)));
let arr = [...intersect];
console.log(arr); //2, 3
```

