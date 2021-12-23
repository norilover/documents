# LUA 

* 基本数据类型

| 数据类型 | 描述                                                         |
| :------- | :----------------------------------------------------------- |
| nil      | 这个最简单，只有值nil属于该类，表示一个无效值（在条件表达式中相当于false）。 |
| boolean  | 包含两个值：false和true。                                    |
| number   | 表示双精度类型的实浮点数                                     |
| string   | 字符串由一对双引号或单引号来表示                             |
| function | 由 C 或 Lua 编写的函数                                       |
| userdata | 表示任意存储在变量中的C数据结构                              |
| thread   | 表示执行的独立线路，用于执行协同程序                         |
| table    | Lua 中的表（table）其实是一个"关联数组"（associative arrays），数组的索引可以是数字、字符串或表类型。在 Lua 里，table 的创建是通过"构造表达式"来完成，最简单构造表达式是{}，用来创建一个空表。 |



```lua
-- print() 输出对应的内容
print("1" + 1) -- 输出2
-- .. 表示链接左右的字符
print("1" .. 1) -- 11


-- type() 输出对应的类型
print(type("Nori")) -- string
print(type(nil)) -- nil
print(type(true)) -- boolean


-- [[ string_content ]] 创建多行字符串
_str = [[
	Nori is good!
]]
print(_str) -- Nori is good


-- #string_var_name 输出字符串长度
_str = "Nori"
print(#_str) -- 4
_str = 1
print(#_str) -- error


-- { ele1, ele2, ...} 创建表
_table = {"Apple", "Orange", "Banana"}
-- ipairs :
-- The basic Lua library provides ipairs, a handy function that allows you to iterate over the elements of an array, following the convention that the array ends at its first nil element.
for i, ele in ipairs(a) do
    print(ele)
end

-- 作为哈希表
_table = {}
_table["Nori"] = "one value"
_table["Jerry"] = "another value"
print(_table["Nori"]);
print(_table["Jerry"]);

-- 作为数组
-- 默认从 下标 1 开始
_table = {1,2,3,4}
-- 效果和上面相同
--[[
_table = {
   [1] = 1,
   [2] = 2,
   [3] = 3,
   [4] = 4}
]]

print(_table[1])	-- 1
print(_table[2])	-- 2
print(_table[3])	-- 3
print(_table[4])	-- 4
print(_table[0])	-- nil
-- 接着在100 下标处赋值
_table[100] = 100
-- for循环打印, 只会打印1到4内的值
for i, val in ipairs(_table) do
    print(i .. " " .. val)
end
-- 1
-- 2
-- 3
-- 4

-- table中内容多样
tb1 = {[1] = "type1", x = 5, y = 20, type = "DAY"}
for i, val in ipairs(tb1) do
  print(i .. " " .. val)
end
-- 输出 1 type1

print(tb1.x .. " " .. tb1.y .. " " .. tb1.type)	-- 5 20 DAY


--[[ 变量：
	默认 全局变量
	local var_name 定义局部变量

	+  对于数字
	.. 对于拼接字符串
	
	将变量赋值为nil 相当于 取消变量的声明
	
	变量可接受函数
	function fun_name()
		print("Call Function!")
	end
	var_fun = fun_name

]]

-- 循环

-- for 循环选定
_table = {}
for i = 1,10 do
    _table[i] = i * 10
    -- _table[i] = io.read()
end
-- for 循环遍历 
for i, val in ipairs(_table) do
    print(i .. " " .. val)
end


-- while
while(true)
do
    	print("While cycle!");
end

-- 传统的do{ ..}while(condition)
repeat
  i = i + 2
  print(i)
until i > 12
-- 输出
--[[
    2
    4
    6
    8
    10
    12
    14
]]

-- if
if(true)
    then
    print("First if cause!")
    else
    print("Second if cause!")
    end


-- function
table = {1,2,3,4,5}
-- local 局部函数
-- 默认是全局函数
function myPrint(table)
    num = 0
    for i, val in ipairs(table) do
        print(val)
        num = num + 1;
    end
    return num
end
--[[
    1
    2
    3
    4
    5
]]

-- 可变参数
function fun1(...)
	print("Can change parameter!")    
end

-- 闭包函数
function fun1()
    return function ()
    	return 1	   
    end     
end

-- 元表（Metatable）


```
*  逻辑运算符

下表列出了 Lua 语言中的常用逻辑运算符，设定 A 的值为 true，B 的值为 false：

| 操作符 | 描述                                                         | 实例                   |
| ------ | ------------------------------------------------------------ | ---------------------- |
| and    | 逻辑与操作符。 如果两边的操作都为 true 则条件为 true。       | (A and B) 为 false。   |
| or     | 逻辑或操作符。 如果两边的操作任一一个为 true 则条件为 true。 | (A or B) 为 true。     |
| not    | 逻辑非操作符。与逻辑运算结果相反，如果条件为 true，逻辑非为 false。 | not(A and B) 为 true。 |

> 逻辑运算符扩展用法
>
> Actually, it's more like the below. This is called "short-circuited" logic, meaning the parser can stop reading the rest of the logic statement when the first part already gives you the end value. You can use this property in a lot of tricks.
>
> ```lua
> -- a and b -- (any values) b if a is truthy otherwise a
> -- EG
> a = 1 
> b = nil
> c = a and b
> print(c) -- nil
> b = 2
> c = a and b
> print(c) -- 2
> 
> -- a or b  -- (any values) a if a is truthy otherwise b
> -- EG
> a = 1 
> b = nil
> c = a or b
> print(c) -- 1
> a = nil
> b = 2
> c = a or b
> print(c) -- 2
> 
> -- EG
> -- example trick: assign a to empty table only if a isn't defined already
> -- remember how "nil" is a falsey value? if a isn't defined, a is nil, so
> -- "a or {}" will evaluate to {}.
> a = a or {}
> ```



* 其他运算法

```lua
-- #
-- 返回字符串或表的长度

-- ..

-- ~= 相当于 其它语言的 !=
if 10 ~= 11 then
    print("Not equals!")
end

-- ==
if true == true
    print("true")
end


```

* 库函数

```lua
string.reserve()
...

table.concat()
...

-- 加载模块
require("module_name")
require "module_name"
-- 
```

