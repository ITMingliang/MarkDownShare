# NPM使用

## 一、NPM使用介绍

NPM是随同NodeJS一起安装的包管理工具，能解决NodeJS代码部署上的很多问题，常见的使用场景有以下几种：

（1）允许用户从NPM服务器下载别人编写的第三方包到本地使用。

（2）允许用户从NPM服务器下载并安装别人编写的命令行程序到本地使用。

（3）允许用户将自己编写的包或命令行程序上传到NPM服务器供别人使用。

由于新版的nodejs已经集成了npm，所以之前npm也一并安装好了。同样可以通过输入 "npm -v" 来测试是否成功安装。命令如下，出现版本提示表示安装成功:

```
npm -v
```

如果你安装的是旧版本的 npm，可以很容易得通过 npm 命令来升级，命令如下：

```
npm install npm -g
```

或淘宝镜像

```
npm install -g cnpm --registry=https://registry.npm.taobao.org
```

## 二、NPM全局安装和本地安装

**本地安装：**

​	【1】将安装包放在 ./node_modules 下（运行 npm 命令时所在的目录），如果没有 node_modules 目录，会在当前执行 npm 命令的目录下生成 node_modules 目录。

​	【2】可以通过 require() 来引入本地安装的包。

**全局安装：**

​	【1】将安装包放在 /usr/local 下或者你 node 的安装目录。

​	【2】可以直接在命令行里使用。

**本地安装与全局安装命令：**

```
npm install ModuleName           # 本地安装
npm install ModuleName -g   	 # 全局安装
```

## 三、npm安装package.json

在nodejs安装目录下已经存在package.json文件，所以不需要进行全局安装package.json，我们下面介绍本地安装package.json文件。

package.json是一个描述和管理的文件，通过如下命令进行安装：

```
npm init
```

命令执行后会提示输入信息，全部使用默认值直接回车，最后提示 Is this OK(yes) ,此时输入yes即可。

安装成功后会创建package.json文件，文件属性内容说明如下：

```
name - 包名。
version - 包的版本号。
description - 包的描述。
homepage - 包的官网 url 。
author - 包的作者姓名。
contributors - 包的其他贡献者姓名。
dependencies - 依赖包列表。如果依赖包没有安装，npm 会自动将依赖包安装在 node_module 目录下。
repository - 包代码存放的地方的类型，可以是 git 或 svn，git 可在 Github 上。
main - main 字段指定了程序的主入口文件，require('moduleName') 就会加载这个文件。这个字段的默认值是模块根目录下面的 index.js。
keywords - 关键字
```

## 四、npm安装模块

npm本地安装模块，需要先安装package.json。

以web框架模块 express为例，进行express模块的安装，命令如下：

```
npm install express          # 本地安装
npm install express -g       # 全局安装
```

如果出现以下错误：

```
npm err! Error: connect ECONNREFUSED 127.0.0.1:8087
```

解决办法为：

```
$ npm config set proxy null
```

## 五、模块的其他操作

在操作命令中，最后加上 -g 代表进行全局操作。

**查看模块安装信息：**

```
npm list	
```

**查看某个模块的版本号：**

```
npm list express
```

**更新模块：**

```
npm update express
```

**搜索模块：**

```
npm search express
```

**卸载模块：**

```
npm uninstall express
```

卸载后，你可以到 /node_modules/ 目录下查看包是否还存在，或者使用以下命令查看：

```
npm ls
```

## 六、版本号

使用NPM下载和发布代码时都会接触到版本号。NPM使用语义版本号来管理代码，这里简单介绍一下。

语义版本号分为X.Y.Z三位，分别代表主版本号、次版本号和补丁版本号。当代码变更时，版本号按以下原则更新。

（1）如果只是修复bug，需要更新Z位。

（2）如果是新增了功能，但是向下兼容，需要更新Y位。

（3）如果有大变动，向下不兼容，需要更新X位。

版本号有了这个保证后，在申明第三方包依赖时，除了可依赖于一个固定版本号外，还可依赖于某个范围的版本号。例如"argv": "0.0.x"表示依赖于0.0.x系列的最

新版argv。

NPM支持的所有版本号范围指定方式可以查看[官方文档](https://npmjs.org/doc/files/package.json.html#dependencies)。

## 七、npm常用命令

除了本章介绍的部分外，NPM还提供了很多功能，package.json里也有很多其它有用的字段。

除了可以在npmjs.org/doc/查看官方文档外，这里再介绍一些NPM常用命令。

NPM提供了很多命令，例如install和publish，使用npm help可查看所有命令。

```
使用npm help <command>可查看某条命令的详细帮助，例如npm help install。

在package.json所在目录下使用npm install . -g可先在本地安装当前命令行程序，可用于发布前的本地测试。

使用npm update <package>可以把当前目录下node_modules子目录里边的对应模块更新至最新版本。

使用npm update <package> -g可以把全局安装的对应命令行程序更新至最新版。

使用npm cache clear可以清空NPM本地缓存，用于对付使用相同版本号发布新版本代码的人。

使用npm unpublish <package>@<version>可以撤销发布自己发布过的某个版本代码。
```

## 八、使用淘宝的npm镜像

大家都知道国内直接使用 npm 的官方镜像是非常慢的，这里推荐使用淘宝 NPM 镜像。

淘宝 NPM 镜像是一个完整 npmjs.org 镜像，你可以用此代替官方版本(只读)，同步频率目前为 10分钟 一次以保证尽量与官方服务同步。

你可以使用淘宝定制的 cnpm (gzip 压缩支持) 命令行工具代替默认的 npm:

```
npm install -g cnpm --registry=https://registry.npm.taobao.org
```

这样就可以使用 cnpm 命令来安装模块了：

```
cnpm install [name]
```

## 九、安装报错

如果你遇到了使用 npm 安 装node_modules 总是提示报错：报错: npm resource busy or locked.....。

可以先删除以前安装的 node_modules :

```
npm cache clean
npm install
```

