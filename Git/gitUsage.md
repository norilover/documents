# The Record of Git

* 向GitHub中添加SSH Keys

  ```shell
  # 1、先回到用户家目录。
  cd
  
  # 2、输入生成密钥的命令。
  # 命令格式： ssh-keygen -t encry_type -C "E-mail"。
  ssh-keygen -t rsa -C "Email"
  # 此时输入三次密码，可以不输入，连续按三次回车即可。
  
  # 3、将“用户家目录”下的.ssh中的生成的id_rsa.pub中的内容copy，打开Github中用户“Setting(设置)”里的“SSH and GPG keys"，点击"New SSH key"，将刚刚copy的内容paste到"Key"中，"Title"可以不写。
  # 4、点击“Add SSH key"即可完成添加。
  ```

* Git基本操作

  ```shell
  # 1、初始化。
  git init
  
  # 2、pull(拉取)项目（前提是，有Permission）。
  git clone git@github.com:norilover/documents.git
  # 输入密码（第一次会提示输入yes)
  
  # 3、push(增加新内容到)项目。
  # 3.1
  git add .
  # 3.2、commit与本地Git仓库同步。
  # 命令格式： git commit [ -c "comment_content" ]。
  git commit -c "First Commit!"
  # 3.3、将内容铺push到远程Git仓库。
  git push origin master
  # 输入密码。
  ```

* 创建一个新的仓库

  ```shell
  echo "# documents" >> README.md
  git init
  git add README.md
  git commit -m "first commit"
  git remote add origin git@github.com:norilover/documents.git
  git push -u origin master
  ```

* fast-forward

  ```
  当多个用户提交本地改变时，第二个提交的用户将会在push时出现下面的【问题】
  	! [rejected]        master -> master (fetch first)
  error: failed to push some refs to 'git@github.com:norilover/documents.git'
  
  【原因】
  	在remote的repository上只保留一个master的HEAD指针，当A用户push后，HEAD指针指向“HEAD_A", 此时B用户push就会出现上面的问题
  
  【解决办法】
  	git pull 将remote repository中的改变拉到本地，如果存在conflict先解决conflict
  
  ```

  

* Q&A

  ```tex
  1、输入git commit -c "comment"
  Q:
      $ git commit
  
      *** Please tell me who you are.
  
      Run
  
        git config --global user.email "you@example.com"
        git config --global user.name "Your Name"
  
      to set your account's default identity.
      Omit --global to set the identity only in this repository.
  
      fatal: unable to auto-detect email address (got 'Nori@DESKTOP-BAVDO0M.(none)')
  A:
  # 在shell中输入：
  	git config --global user.email hhhwzc_17@126.com
  	git config --global user.name norilover
  	# 可通过下面查看
  	# git config --global user.email
  	# git config --global user.name
  
  ```

  

