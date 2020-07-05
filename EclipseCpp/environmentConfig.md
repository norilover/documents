# The Record of Eclipse-cpp

```tex
1、在Eclipse官网下载eclipse-cpp-2020-06-R-win32-64。

2、下载MinGw,安装”Basic Setup"即可。

3、打开Eclipse: Help -> Eclipse Marketplace, 搜索 “CDT", 点击安装。

4、配置path：
	MinGw家目录：MINGW_HOME -> MinGW_home
	PATH 追加 %MINGW_HOME%\bin
	LIBRARY_PATH -> %MINGW_HOME%\lib
	C_INCLUDE_PATH -> %MINGW_HOME%\lib\gcc\mingw32\9.2.0\include\c++
	
5、进入Eclipse的 Windows -> References -> C/C++ -> NewC/C++ Project Wizard -> Makefile Project，点击 ”Binary Parsers" 选择 “PE64 Windows Parsers", 点击保存。
```



