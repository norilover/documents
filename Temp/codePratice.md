# Code



* PDD

```java
public List<Integer> getRange(int offset, int n, int len1, int len2){
	List<Integer> list = new ArrayList<>(4);
	int l11 = 0;
	int l12 = 0;
	int l21 = 0;
	int l22 = 0;

	int b1 = len1 - offset;
	if(offset < len1){
		l11 = offset;

		if(n < b1){
			l12 = l11 + n;

			// l21 = 0;
			// l22 = 0;
		}else{
			l12 = len1;

			// l21 = 0;
			l22 = n - b1;
		}
	}else{
		// l11 = 0;
		// l12 = 0;

		// l21 = 0;
		if(len2 < n){
			l22 = len2;
		}else{
			l22 = n;
		}
	}

	list.add(l11);
	list.add(l12);
	list.add(l21);
	list.add(l21);

	return list;
}
```

