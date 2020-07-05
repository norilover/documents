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

  

* Q&A

  ```
  1、输入git commit -c "comment"
      $ git commit
  
      *** Please tell me who you are.
  
      Run
  
        git config --global user.email "you@example.com"
        git config --global user.name "Your Name"
  
      to set your account's default identity.
      Omit --global to set the identity only in this repository.
  
      fatal: unable to auto-detect email address (got 'Nori@DESKTOP-BAVDO0M.(none)')
  
  ```

  

