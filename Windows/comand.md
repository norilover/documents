# Windows Command 

* nsloolup

  ```powershell
  nslookup domain_name
  // EG.
      PS C:\Users\Jerry> nslookup superlight.sine.space
      Server:  PandoraBox.lan
      Address:  192.168.123.1
  
      Non-authoritative answer:
      Name:    superlight.sine.space
      Address:  34.233.119.119
  ```
  
  

* netstat

  ```powershell
  netstat -paras_prefix
  
  // EG.
  	// Start server terminal
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


* Cls

  ```powershell
  名称
      Clear-Host
  这个可以实现类似一般shell的 Ctrl + l(L的小写)的功能，清除当前屏幕的内容
  ```
  
* Sort

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

* Select

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
  
* Sleep

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



* 再Power Shell中显示类似执行top的结果，查看系统进程信息

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



* 查找特定端口的打开数量

  ```powershell
  netstat -ano | findstr 10443 | Measure-Object -Character -Line -Word
  
  while(1){netstat -ano | findstr 10443 | Measure-Object -Character -Line -Word | Select -first 30; Sleep -seconds 1; Cls; Write-Host "number"}
  
   while(1){
   netstat -ano | findstr 10443 | findstr ESTABLISH | Measure-Object -Character -Line -Word | Select -first 30; Sleep -seconds 1; Cls;
     Write-Host "Count  other   others";
     Write-Host "-----  -----   ------"
   }
  
  rem 结果如下：
  Lines Words Characters Property
  ----- ----- ---------- --------
    807  4035      61300
  ```
  
  



