# Usage of Mysql

* INSTALL(安装)

  ```
  1.安装目录添加my.ini文件，内容如下：
      [mysqld]
      default_authentication_plugin=mysql_native_password
      # Remove leading # and set to the amount of RAM for the most important data
      # cache in MySQL. Start at 70% of total RAM for dedicated server, else 10%.
      # innodb_buffer_pool_size = 128M
  
      # Remove leading # to turn on a very important data integrity option: logging
      # changes to the binary log between backups.
      # log_bin
  
      # These are commonly set, remove the # and set as required.
      # 设置mysql数据库的数据的存放目录
      basedir=E:\app\mysql-8.0.19-winx64
      datadir=E:\app\mysql-8.0.19-winx64\data
      #设置3306端口
      port = 3306
      # server_id = .....
  
  
      # Remove leading # to set options mainly useful for reporting servers.
      # The server defaults are faster for transactions and fast SELECTs.
      # Adjust sizes as needed, experiment to find the optimal values.
      # join_buffer_size = 128M
      # sort_buffer_size = 2M
      # read_rnd_buffer_size = 2M 
  
      sql_mode=NO_ENGINE_SUBSTITUTION,STRICT_TRANS_TABLES 
      # 服务端使用的字符集默认为UTF8
      character-set-server = utf8mb4
  
      performance_schema_max_table_instances = 600
      table_definition_cache = 400
      table_open_cache = 256
  
      # 创建新表时将使用的默认存储引擎
      default-storage-engine=INNODB 
      #最大连接数
      max_connections=200
      [mysql]
      default-character-set = utf8mb4
  
      [client]
      default-character-set = utf8mb4
  
  2.执行“mysqld --initialize --console
  
  3.记录2步骤中打出的临时密码
  	eg.
          2020-07-18T10:52:36.231397Z 6 [Note] [MY-010454] [Server] A temporary password is generated for root@localhost: fxug5UO<T%VJ
   
  [OPTIONAL]
  4.执行安装命令
  	mysqld -install
  
  5.启动mysql:
  	若执行了步骤4，只有两种启动MySQL的方式
  	第一种：
          NET START mysql
          NET STOP mysql
      若没有执行步骤4，使用这种方式也可以启动mysql
      第二种：
  		mysqld
  
  6.查看服务是否启动：
  	tasklist | findstr ^mysql
  	eg.
  		mysqld.exe                   12568 Services         
  
  7.登录MySQL
  	mysql -u root -p 
  		按下enter
  		输入步骤3中的临时密码
  
  8.修改密码：
  	SET PASSWORD="password_value"
  ```

  