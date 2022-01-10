# Windows Command 

* /? & get-help

  ```powershell
  // 类似在Linux上面，使用 man, --help 等方式获取命令帮助，
  // 在Windoews上面，这里以PowerShell为例，可以使用help 或则 get-help, /?去获得命令的帮助
  
  // EG.
  PS C:\Users\Jerry> help dir
  
  // 输出如下
  名称
      Get-ChildItem
  
  语法
      Get-ChildItem [[-Path] <string[]>] [[-Filter] <string>]  [<CommonParameters>]
  
      Get-ChildItem [[-Filter] <string>]  [<CommonParameters>]
  
  
  别名
      gci
      ls
      dir
  
  
  备注
      Get-Help 在此计算机上找不到该 cmdlet 的帮助文件。它仅显示部分帮助。
          -- 若要下载并安装包含此 cmdlet 的模块的帮助文件，请使用 Update-Help。
          -- 若要联机查看此 cmdlet 的帮助主题，请键入: "Get-Help Get-ChildItem -Online" 或
             转到 https://go.microsoft.com/fwlink/?LinkID=113308。
  ```



* nsloolup

  ```powershell
  // nslookup domain_name
  // 查看 域名对应 ip
  // 格式：
  // 输入： nslookup + 域名
  // 输出：
  /*
  	...
  	Address：ip地址
  */
  // EG.
      PS C:\Users\Jerry> nslookup superlight.sine.space
      服务器:  UnKnown
      Address:  192.168.0.1
  
      非权威应答:
      名称:    superlight.sine.space
      Address:  54.227.126.68
  ```



* findstr

  > 这个可以使用去过滤内容，类似grep,像一个过滤器

  ```powershell
  // 查看谷歌浏览器相关的进程
  // tasklist : 可以显示所有运行在这个电脑上的进程
  // |        : 管道，相当于将左边的结果当成右边的输入
  // findstr  : 过滤函数
  // chrome   : 需要匹配的字符串
  PS C:\Users\Jerry> tasklist | findstr chrome
  chrome.exe                   16640 Console                    1     96,284 K
  chrome.exe                   16676 Console                    1      6,928 K
  chrome.exe                   16812 Console                    1     69,960 K
  chrome.exe                   16828 Console                    1     30,704 K
  chrome.exe                   16920 Console                    1     15,104 K
  chrome.exe                   17416 Console                    1     65,200 K
  chrome.exe                   17724 Console                    1     36,084 K
  chrome.exe                   17288 Console                    1     19,200 K
  ```

  > 官方文档
  >
  > 你可以在命令行中输入 findstr /? 

  ```powershell
  findstr 在文件中寻找字符串。
  
  FINDSTR [/B] [/E] [/L] [/R] [/S] [/I] [/X] [/V] [/N] [/M] [/O] [/P] [/F:file]
          [/C:string] [/G:file] [/D:dir list] [/A:color attributes] [/OFF[LINE]]
          strings [[drive:][path]filename[ ...]]
  
    /B         在一行的开始配对模式。
    /E         在一行的结尾配对模式。
    /L         按字使用搜索字符串。
    /R         将搜索字符串作为一般表达式使用。
    /S         在当前目录和所有子目录中搜索匹配文件。
    /I         指定搜索不分大小写。
    /X         打印完全匹配的行。
    /V         只打印不包含匹配的行。
    /N         在匹配的每行前打印行数。
    /M         如果文件含有匹配项，只打印其文件名。
    /O         在每个匹配行前打印字符偏移量。
    /P         忽略有不可打印字符的文件。
    /OFF[LINE] 不跳过带有脱机属性集的文件。
    /A:attr    指定有十六进位数字的颜色属性。请见 "color /?"
    /F:file    从指定文件读文件列表 (/ 代表控制台)。
    /C:string  使用指定字符串作为文字搜索字符串。
    /G:file    从指定的文件获得搜索字符串。 (/ 代表控制台)。
    /D:dir     查找以分号为分隔符的目录列表
    strings    要查找的文字。
    [drive:][path]filename
               指定要查找的文件。
  
  除非参数有 /C 前缀，请使用空格隔开搜索字符串。
  例如: 'FINDSTR "hello there" x.y' 在文件 x.y 中寻找 "hello" 或
  "there"。'FINDSTR /C:"hello there" x.y' 文件 x.y  寻找
  "hello there"。
  
  一般表达式的快速参考:
    .        通配符: 任何字符
    *        重复: 以前字符或类出现零或零以上次数
    ^        行位置: 行的开始
    $        行位置: 行的终点
    [class]  字符类: 任何在字符集中的字符
    [^class] 补字符类: 任何不在字符集中的字符
    [x-y]    范围: 在指定范围内的任何字符
    \x       Escape: 元字符 x 的文字用法
    \<xyz    字位置: 字的开始
    xyz\>    字位置: 字的结束
  ```




* cls

  ```powershell
  名称
      Clear-Host
  这个可以实现类似一般shell的 Ctrl + l(L的小写)的功能，清除当前屏幕的内容
  ```




* sort

  ```powershell
  名称
      Sort-Object
  摘要
      Sorts objects by property values.
  参数
      -CaseSensitive <System.Management.Automation.SwitchParameter> 
      
      -Descending <System.Management.Automation.SwitchParameter>
      -desc
          Descending order. The default is ascending order.   
          
  使用这个查看详情
  	get-help sort -detailed           
  ```




* select

  ```powershell
  名称
      Select-Object
  摘要
      Selects objects or object properties.
  参数
      -First <System.Int32>
          Specifies the number of objects to select from the beginning of an array of input objects（可以使用这个去过滤结果只返回前面特定的行数）.
  
  使用这个查看详情
  	get-help select -detailed        
  ```

  

* sleep

  ```powershell
  名称
      Start-Sleep
  摘要
      Suspends the activity in a script or session for the specified period of time.
  参数
      -Milliseconds <System.Int32>
      -Seconds <System.Int32>
      	睡眠时间
  
  使用这个查看详情
  	get-help sleep -detailed        
  ```



* 在Power Shell中显示类似执行top的结果，查看系统进程信息

  ```powershell
  rem 使用一个死循环显示进程信息 -> While (1)
  rem Ps、gps 是 Get-Process 命令的别名 -> Ps : Gets the processes that are running on the local computer（获取本地运行进程）.
  rem Sort 是 Sort-Object 的别名 -> Sort :  Sorts objects by property values（通过属性对问题进行排序，可通过 输入 “ get-help Sort-Object -detailed ” 查看详细介绍）.
  
  rem 下面主要介绍输出的几个参数的含义：
  rem Handles: The number of handles that the process has opened（这个进程打开的handle数量）.
  rem PM(K): The amount of pageable memory that the process is using, in kilobytes（Pageable Memory 这个进程使用的内存数量，单位为KB）.
  rem WS(K): The size of the working set of the process, in kilobytes. The working set consists of the pages of memory that were recently referenced by the process（Working Set 这个进程工作集大小，单位为KB；工作集指的是一段连续的内存页，并且最近被进程使用）.
  rem VM(M): The amount of virtual memory that the process is using, in megabytes. Virtual memory includes storage in the paging files on disk（Virtual Memory 这个进程使用的虚拟内存，单位为MB；虚拟内存包括在磁盘上存储的分页文件）.
  rem CPU(s): The amount of processor time that the process has used on all processors, in seconds（中央处理器）.
  rem ID: The process ID (PID) of the process（进程在本地的进程唯一标识符）.
  
  rem 在命令行输入下面的内容
  While (1) {
     Ps | Sort -desc cpu | Select -first 30; Sleep -seconds 2; Cls;
     Write-Host "Handles  NPM(K)    PM(K)      WS(K) VM(M)   CPU(s)     Id ProcessName";
     Write-Host "-------  ------    -----      ----- -----   ------     -- -----------"
  }
  
  rem 结果如下：
  Handles  NPM(K)    PM(K)      WS(K) VM(M)   CPU(s)     Id ProcessName
  -------  ------    -----      ----- -----   ------     -- -----------
      999     119   243088     229116   1,398.25   3892   0 chrome
  ```



* netstat

  ```powershell
  // netstat -paras_prefix
  // 查看本地网络相关信息
  // 
  // EG.
  	// Start server terminal
  	// 如果开启一个服务端，也就是监听一个本地的端口
  	// 这里服务端监听了，10443的端口，输入下面的命令，即可看到相关的信息
      PS C:\Users\Jerry> netstat -an | findstr "10443"
        TCP    0.0.0.0:10443          0.0.0.0:0              LISTENING
        
      // Start client terminal   
      PS C:\Users\Jerry> netstat -an | findstr "10443"
        TCP    0.0.0.0:10443          0.0.0.0:0              LISTENING
        TCP    192.168.123.246:10975  34.233.119.119:10443   TIME_WAIT
  ```



* tasklist

  ```powershell
  PS C:\Users\Jerry> tasklist
  
  映像名称                       PID 会话名              会话#       内存使用
  ========================= ======== ================ =========== ============
  System Idle Process              0 Services                   0          8 K
  System                           4 Services                   0        148 K
  Registry                       148 Services                   0    102,264 K
  ```




* 在PowerShell 下查看进程下开启的所有端口

  ```powershell
  rem Search Photon related task
  rem 搜索Photon相关的进程信息
  PS C:\Users\Jerry> tasklist | findstr "Photon"
  PhotonSocketServer.exe        3528 Services                   0    101,940 K
  PhotonControl.exe            13148 Console                    1     51,560 K
  
  rem According to PID to find the network info
  rem 根据PID查看改进程下的网络信息
  PS C:\Users\Jerry> netstat -ano | findstr 3528
    TCP    0.0.0.0:843            0.0.0.0:0              LISTENING       3528
    TCP    0.0.0.0:943            0.0.0.0:0              LISTENING       3528
    TCP    0.0.0.0:4530           0.0.0.0:0              LISTENING       3528
    TCP    0.0.0.0:9090           0.0.0.0:0              LISTENING       3528
    UDP    0.0.0.0:56425          *:*                                    3528
    UDP    0.0.0.0:56426          *:*                                    3528
    UDP    0.0.0.0:56427          *:*                                    3528
    UDP    0.0.0.0:56428          *:*                                    3528
    UDP    127.0.0.1:5055         *:*                                    3528
    UDP    192.168.0.26:5055      *:*                                    3528
  ```



* 查找特定端口的打开数量

  ```powershell
  rem 服务器压测时可以使用这个脚本,
  
  while(1){netstat -ano | findstr 10443 | findstr ESTABLISH | Measure-Object -Character -Line -Word | Select -first 30; Sleep -seconds 1; Cls;
     Write-Host "Count  other   others";
     Write-Host "-----  -----   ------"
   }
  
  // 结果如下：807为建立的连接数,这个结果会每隔30秒刷新一次
  Count  other   others
  -----  -----   ------
    807      0          0
  ```



* TCP客户端状态分析：

  ```tex
  LISTENING ：
  服务端监听某一ip:port时的状态
  
  ESTABLISHED ：
  客户端与某一ip:port连接时的状态
  
  TIME_WAIT ：
  客户端等待服务器响应的z
  
  FIN_WAIT_1
  客户端与服务器断开或超时的状态(客户端以无法连接服务器,或长时间无应答,这个是对TCP来说),一般与4次挥手关联
  
  FIN_WAIT_2
  客户端与服务器断开的最后状态,或则客户端尝试连接服务器,但多次尝试还是没有结果,这个是 FIN_WAIT_1的下一个状态,也是关闭这个socket的前一个状态
  ```



* 修改hosts文件

  ```powershell
  rem 需要管理员权限
  rem 将live的域名对应的ip指向本地
  echo "127.0.0.1 superlight.sine.space" >  C:\WINDOWS\system32\drivers\etc\hosts
  
  rem 将preview的域名对应的ip指向本地
  echo "127.0.0.1 superlight-preview.sine.space" >  C:\WINDOWS\system32\drivers\etc\hosts
  ```

  

​	   

  



