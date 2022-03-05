# 使用log4j记录日志

使用log4j记录日志的步骤

（1）在项目中导入log4j的jar文件。

（2）创建log4j.properties文件。

（3）在log4j.properties文件中进行日志的配置。

（4）程序中使用log4j记录日志信息。

前面两个步骤比较简单，此文章主要介绍日志的配置以及在程序中使用log4j进行记录日志信息。

## log4j.rootLogger的配置

log4j.rootLogger用于配置日志记录的优先级以及日志的输出目的地

语法如下：

```
log4j.rootLogger = [ level ] , appenderName1, appenderName2, …
```

level : 是日志记录的优先级，分为OFF、FATAL、ERROR、WARN、INFO、DEBUG、ALL。Log4j建议只使用四个级别，优先级从高到低分别是ERROR、WARN、INFO、DEBUG。通过在这里定义的级别，您可以控制到应用程序中相应级别的日志信息的开关。比如在这里定义了INFO级别，则应用程序中所有DEBUG级别的日志信息将不被打印出来。

appenderName:就是指定日志信息输出到哪个地方。您可以同时指定多个输出目的地。

## 日志输出的配置

语法：

```
log4j.appender.自定义输出类型名称 = 输出类型
log4j.appender.自定义输出类型名称.layout=日志信息格式类型
log4j.appender.自定义输出类型名称.layout.ConversionPattern=自定义格式字符串
```

**（1）其中输出类型参数取值如下：**

org.apache.log4j.ConsoleAppender（控制台）
org.apache.log4j.FileAppender（文件）
org.apache.log4j.DailyRollingFileAppender（每天产生一个日志文件）
org.apache.log4j.RollingFileAppender（文件大小到达指定尺寸的时候产生一个新的文件）

**（2）日志信息格式类型layout参数取值如下：**

org.apache.log4j.HTMLLayout（以HTML表格形式布局）
org.apache.log4j.PatternLayout（可以灵活地指定布局模式）
org.apache.log4j.SimpleLayout（包含日志信息的级别和信息字符串）
org.apache.log4j.TTCCLayout（包含日志产生的时间、线程、类别等等信息）

**（3）自定义格式字符串layout.ConversionPattern参数常用标志**

%m 输出代码中指定的消息；
%p 输出优先级，即DEBUG，INFO，WARN，ERROR，FATAL；
%r 输出自应用启动到输出该log信息耗费的毫秒数；
%c 输出所属的类目，通常就是所在类的全名；
%t 输出产生该日志事件的线程名；
%n 输出一个回车换行符，Windows平台为"rn”，Unix平台为"n”；
%d 输出日志时间点的日期或时间，默认格式为ISO8601，也可以在其后指定格式，比如：%d{yyyy-MM-dd HH:mm:ss,SSS}，输出类似：2019-10-18 22:10:28,921；
%l 输出日志事件的发生位置，及在代码中的行数；

## 完整配置示例

```
log4j.rootLogger=debug,console,logfile

log4j.appender.console=org.apache.log4j.ConsoleAppender
log4j.appender.console.layout=org.apache.log4j.PatternLayout
log4j.appender.console.layout.ConversionPattern=%d{yyyy-MM-dd HH:mm:ss} %p %m%n

log4j.appender.logfile=org.apache.log4j.DailyRollingFileAppender
log4j.appender.logfile.File=H\://logs/log4j.log
log4j.appender.logfile.layout=org.apache.log4j.PatternLayout
log4j.appender.logfile.layout.ConversionPattern=%d{yyyy-MM-dd HH:mm:ss} %p %m%n
```

备注：

（1）第一行配置输出级别为debug,输出目的地为控制台和文件

（2）中间三行配置在控制台输出，并且使用自己灵活指定布局，输出内容格式为"时间 优先级 日志内容"。

（3）最下四行配置产生文件的方式为每天产生一个日志文件，文件的存储位置，以及自己灵活指定布局，输出内容格式为"时间 优先级 日志内容"。

**按照上面的配置，在main方法中进行日志输出：**

```
PropertyConfigurator.configure("log4j.properties");    //指向log4j配置文件的位置。
Logger log = Logger.getLogger(JavaTest.class.getName());
//当发生异常或者需要写日志的时候
log.debug("写debug级别日志");
log.info("写info级别日志");
log.warn("写warn级别日志");
log.error("写error级别日志");
```

此时会在控制台以及文件中，记录日志信息。