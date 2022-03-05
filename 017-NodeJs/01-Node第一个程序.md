# Node第一个程序

简单的说 Node.js 就是运行在服务端的 JavaScript。

Node.js 是一个基于Chrome JavaScript 运行时建立的一个平台。

Node.js是一个事件驱动I/O服务端JavaScript环境，基于Google的V8引擎，V8引擎执行Javascript的速度非常快，性能非常好。

## 一、适合人群

如果你是一个前端程序员，你不懂得像PHP、Python或Ruby等动态编程语言，然后你想创建自己的服务，那么Node.js是一个非常好的选择。

Node.js 是运行在服务端的 JavaScript，如果你熟悉Javascript，那么你将会很容易的学会Node.js。

当然，如果你是后端程序员，想部署一些高性能的服务，那么学习Node.js也是一个非常好的选择。

在继续本教程之前，你应该了解一些基本的计算机编程术语。如果你学习过Javascript,PHP，Java等编程语言，将有助于你更快的了解Node.js编程。

## 二、Node安装配置

Node.js 安装包及源码下载地址为：https://nodejs.org/en/download/。

Windows版本下根据提示进行Node的安装，关于Node的环境变量应该是会自动配置的，可以检查一下Path环境变量中是否有Node相关的设置。

检查Node是否正常安装，可以在Windows控制台使用如下命令检查其版本。

```
node --version
```

## 三、第一个控制台输出程序

在本地创建一个Hello.js的文件，文件内容为：

```
console.log("Hello World");
```

保存该文件，使用控制台进入到文件目录，执行如下命令进行测试：

```
node hello.js
```

如果可以在控制台打印出 hello world,则表示成功！

## 四、第一个Web程序

和其它后端语言不同，使用 Node.js 时，我们不仅仅在实现一个应用，同时还实现了整个 HTTP 服务器

（1）在目录下创建一个web.js的文件。

（2）引入 required 模块

我们使用 require 指令来载入 http 模块，并将实例化的 HTTP 赋值给变量 http，实例如下:

```
var http = require("http");
```

（3）创建服务器

接下来我们使用 http.createServer() 方法创建服务器，并使用 listen 方法绑定 8888 端口。 函数通过 request, response 参数来接收和响应数据。

实例如下，在web.js中写入以下代码：

```
var http = require('http');

http.createServer(function (request, response) {

    // 发送 HTTP 头部 
    // HTTP 状态值: 200 : OK
    // 内容类型: text/plain
    response.writeHead(200, {'Content-Type': 'text/plain'});

    // 发送响应数据 "Hello World"
    response.end('Hello World\n');
}).listen(8888);

// 终端打印如下信息
console.log('Server running at http://127.0.0.1:8888/');
```

（4）使用node命令执行如上代码，创建一个HTTP服务器。

```
node web.js
```

（5）在浏览器地址栏输入http://127.0.0.1:8888/或者http://localhost:8888/ 可以打开一个网页，显示"hello World！"。

