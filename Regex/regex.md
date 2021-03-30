# Regex

> Quantifiers(量词)

* \+ : plus

```
匹配1次或多次
```



* \*  : star 

```
匹配0次或大于0次
```



* {#1,#2} :

```
匹配#1到#2次
be{1,2}
	best_beet_bee
	匹配 ： be bee
两种特殊情况:
	{#1} : 精确匹配 #1次
	{#1,} : 将匹配至少#1次
```



* ? : optional

```
匹配0到1次
colou?r:
	colorcolour
	匹配 ： color colour
```



* | : OR

```shell
b(a|e|r)d :
	bad bud bod bed biAd
	匹配：bad bed 
```



* [\s\S]

```
匹配所有。\s 是匹配所有空白符，包括换行，\S 非空白符，不包括换行。
```

* () 组

```
组匹配：
	
	(balabala)+ : 匹配balabala整体一次或多次 
		
	类似于：
		a+ : 匹配a出现一次货多次
	这样就可以使用量词(Quantifiers)去处理超过一个字符的情况
```

* [] 任意匹配

- ```
  [anz] : 匹配中括号中的任意一个字符
  	abc : 匹配 a 
  ```

