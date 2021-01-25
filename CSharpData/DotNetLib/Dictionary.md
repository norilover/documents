# Dictionary





> put(添加操作)

* 流程

```tex
调用Add(Key)
	// 这里value可以为null
	-> TryInsert(key, value, InsertionBehavior.ThrowOnExisting)

拿key计算对应的哈希值(保持该值始终在[0,length),左闭右开)
	-> if 哈希值对应的位置已经存在元素
		-> 拿到该位置现存的元素(Entry),通过它的next变量获取下一个位置的哈希值
			->if 不存在则通过相应的解决冲突方法计算对应的哈希值
                -> 将计算的哈希值在存入这个不存在下一个哈希值的元素的next中
                -> 将对应的元素放在该哈希值对应的位置中			
			-> else 存在则继续获取对应元素下一个位置的哈希值

	-> else	不存在元素
		-> 直接放入对应位置
```



* 核心代码

```c#
// 其实就是一个Entry类型的数据，不过这个结构体在Dictionary内部私有
private struct Entry
{
    public int hashCode;  // key对应的哈希编码（GetHashCode(), 由下分析可知，该值最大为Int32的最大值） 
    public int next;	// 下一个元素对应的哈希值
    public TKey key;	// 这一个Entry的 key
    public TValue value;	// 这一个Entry的 value
}

public void Add(TKey key, TValue value) => this.TryInsert(key, value, InsertionBehavior.ThrowOnExisting); // .Net 6.0 grammar
// 其实和这个一样
public void Add(TKey key, TValue value){
	this.TryInsert(key, value, InsertionBehavior.ThrowOnExisting);    
}

private bool TryInsert(TKey key, TValue value, InsertionBehavior behavior)
{
    if ((object) key == null)
        throw new ArgumentNullException(nameof (key));
    if (this.buckets == null)
        this.Initialize(0);
    int num1 = this.comparer.GetHashCode(key) & int.MaxValue;
    int index1 = num1 % this.buckets.Length;
    int num2 = 0;
    for (int index2 = this.buckets[index1]; index2 >= 0; index2 = this.entries[index2].next)
    {
        if (this.entries[index2].hashCode == num1 && this.comparer.Equals(this.entries[index2].key, key))
        {
            if (behavior == InsertionBehavior.OverwriteExisting)
            {
                this.entries[index2].value = value;
                ++this.version;
                return true;
            }
            if (behavior == InsertionBehavior.ThrowOnExisting)
                throw new ArgumentException(SR.Format("An item with the same key has already been added. Key: {0}", (object) key));
            return false;
        }
        ++num2;
    }
    int index3;
    if (this.freeCount > 0)
    {
        index3 = this.freeList;
        this.freeList = this.entries[index3].next;
        --this.freeCount;
    }
    else
    {
        if (this.count == this.entries.Length)
        {
            this.Resize();
            index1 = num1 % this.buckets.Length;
        }
        index3 = this.count;
        ++this.count;
    }
    this.entries[index3].hashCode = num1;
    this.entries[index3].next = this.buckets[index1];
    this.entries[index3].key = key;
    this.entries[index3].value = value;
    this.buckets[index1] = index3;
    ++this.version;
    if (num2 > 100 && this.comparer is NonRandomizedStringEqualityComparer)
    {
        this.comparer = (IEqualityComparer<TKey>) EqualityComparer<string>.Default;
        this.Resize(this.entries.Length, true);
    }
    return true;
}
```



> select(查找操作)

* 流程

```tex
调用ContainsKey(Key)
	-> FindEntry(key)
		-> 判断参数key是否为null
			-> 是 则抛出异常
		-> 判断哈希桶(Buckets)是否为null
			-> 否
				-> 通过比较器(comparer)获取HashCode, 并将该HashCode值于int32的最大值进行与(&)操作，获取一个num值，这样可以保持num的值始终小于等于int32的最大值（具体值看核心代码部分）			 
                -> 寻找该key对应的位置(如果没有冲突，一次就找到了)(详细的看上面的添加操作部分)				
				-> 开始寻找对应的key所在的位置
                    -> 将 num变量 与 哈希桶的长度 求余， 将求余的结果当成哈希桶中的下标index，
                    -> if index在entry数组中的元素值等于num, 并且entry[index].key也等于传入的key，则表明找到对应的元素,直接返回index
                    -> 否则，将entry[index].next 的值赋给index，重复前一步的过程，直到找到对应的元素或index被赋为-1,返回
```

* 核心代码

```c#
public bool ContainsKey(TKey key) => this.FindEntry(key) >= 0;

/*
基本变量及条件：
	this.buckets -> private int[] buckets;
	
	this.comparer -> private IEqualityComparer<TKey> comparer;
	这里主要使用这个比较器的 GetHashCode(), Equals()
	
	MaxValue 为 int System.Int32.MaxValue = 2147483647; 
    表示 Int32 的最大可能值。 此字段为常数
 	
 	this.entries ->  private Dictionary<TKey, TValue>.Entry[] entries;
 	其实就是一个Entry类型的数据，不过这个结构体在Dictionary内部私有，结构如看put(添加操作)部分  
*/
private int FindEntry(TKey key)
{
    if ((object) key == null)
        throw new ArgumentNullException(nameof (key));
    if (this.buckets != null)
    {
        int num = this.comparer.GetHashCode(key) & int.MaxValue;
        for (int index = this.buckets[num % this.buckets.Length]; index >= 0; index = this.entries[index].next)
        {
            if (this.entries[index].hashCode == num && this.comparer.Equals(this.entries[index].key, key))
                return index;
        }
    }
    return -1;
}
```

