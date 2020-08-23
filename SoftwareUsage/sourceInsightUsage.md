# Source Insight

* 修改trial时间

  ```
  在官网上下载Source Insight 4.0的安装程序.
  
  目前版本4.00.0098可用
  
  30天的试用安装
  
  首次启动选择授权方式，这里选择第二个选项，30天试用。
  
  点击下一步，输入名称、公司或组织名称、邮箱信息，申请30天的试用。
  输入完成后，点击下一步，直到安装完成。
  
  修改sourceinsight4.exe
  
  用16进制编辑器（sublime text）打开sourceinsight4.exe文件，找到c800 0000 742a 83bc 2408 这一段，修改74 为 eb。
  
  修改license文件
  
  打开 C:\ProgramData\Source Insight\4.0\si4.lic
  将Expiration=”2017-XX-XX”中的2017修改为2030。
  
  注意：过一段时间提示过期后，把Date=“2019-10-24 00:00:00”，改成前一天的，又能继续使用。
  ```

* 新建工程

  ```
  1、点击开始界面左上方的Project按钮 -> 点击New Project
  2、输入 New project Project, 选择项目数据存放目录， 点击确认
  3、将源代码放在2步骤中创建目录的同级目录中，2步骤后的界面直接点击确认
  4、在 File Name中选择源代码目录，点击 Add, 勾选弹出页面的未勾选，选项，点击确认
  5、进入项目点击源代码的某一文件， 右键点击File Name 栏下的内容，选择Synchronize Files,点击确认更新文件索引
  ```

* 快捷键

  ```
  ALT + , : Go Back
  	  . : Go Forward 
  	
  CTRL + = : Go Definition
  
  ```

  



  