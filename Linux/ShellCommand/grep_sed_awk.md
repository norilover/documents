# GREP SED AWK Usage

> grep

```bash
grep "str_content" file_name

parameter:
	-c --count : Print the number of line which were matched
    -i --ignore-case : Ignore the case of str_content(supper case  or lowwer case)
    -v --invert-match : Ivert the sense of matching
    -w -- word-regexp : Select only those lines containing matchs the form whole line
    -- color[=color_name] : Surround the matched strings 
    -m NUM Stop reading a file after NUM matching lines
    -o --only-matching : Print only the matched (no-empty) parts of matching line
    
    
Context Line Control 
	-A NUM --after-context=NUM
			print NUM lines of leading context after matching 
	-B NUM --before-context=NUM
		print NUM lines of leading context before matching lines
	-C NUM -NUM, --context=NUM
		Print NUM lines of output context.
```



>  wk

```shell
   // the default parameter of -F is ' ' or '\n'
   # awk '{print $1, $2, $3}'
   # awk -F # '{print $1, $2, $3}'
```

