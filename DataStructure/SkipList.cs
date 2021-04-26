public class SkipList<TK, TV> : IDictionary<TK, TV> where TK, IComparable{
	private SkipListNode<TK, TV> head;

	private int count;

	public int Count{ get {return count; }}

	public bool IsReadOnly{ get {return false; }}

	public TV this[TK k]{
		get{ return get(k); }

		set{ Add(key, value); }
	}

	public ICollection<TK> Keys{
		get{
			List<TK> keys = new List<TK>(count);
			walkEntries(n => keys.Add(n.key));
			return keys;
		}
	}

	public ICollection<TV> Values{
		get{
			List<TV> values = new List<TV>(count);
			walkEntries(n => values.Add(n.value));
			return values;
		}
	}

	public SkipList(){
		this.head = new SkipListNode<TK, TV>();
		count = 0;
	}

	private struct SkipListKVPair<W, X>{
		private W key;
		public W Key{
			get{ return key; }
		}	

		public X Value;

		public SkipListKVPair(W key, X value){
			this.key = key;
			this.value = value;
		}
	}

	private class SkipListNode<TNK, TNV>{
		public SkipListNode<TNK, TNV> forward, back, up, down;

		public SkipListKVPair<TNK, TNV> keyValue;

		public bool isFront = false;

		public TNKey key{
			get{ return keyValue.key; }
		}

		public TNV value{
			get{ return keyValue.Value; }
			set{ return keyValue.Value = value; }
		}

		public SkipListNode(){
			this.keyValue = new SkipLisyKVPair<TNK, TNV>(default(TNK), default(TNV));
			this.isFront = true;
		}

		public SkipListNode(SkipListKVPair<TNK, TNV> keyValue){
			this.keyValue = keyValue;
		}		

		public SkipListNode(TNK key, TNV value){
			this.keyValue = new SkipListKVPair<TNK, TNV>(key, value);
		}
	} 


	public void Add(TK key, TV value){
		SkipListNode<TK, TV> position;

		bool found = search(key, out position);
		if(found)
			position.value = value;
		else{
			SkipListNode<TK, TV> newEntry = new SkipListNode<TK, TV>(key, value);
			count++;

?
			promote(newEntry);
		}
	}

	public void Add(KeyValuePair<TK, TV> keyValue){
		Add(keyValue.Key, keyValue.Value);
	}

	public void Clear(){
		head = new SkipListNode<TK, TV>();
		count = 0;
	}

	public bool ContainsKey(TK key){
		SkipListNode<TK, TV> notUsed;
		return search(key, out notUsed);
	}

	public bool Contains(KeyValuePair<TK, TV> keyValue){
		return ContainsKey(keyValue.Key);
	}

	public bool Remove(TK key){
		SkipListNode<TK, TV> position;
		bool found = search(key, out position);
		if(!found)
			return false;
		else{
			SkipListNode<TK, TV> old = position;

			do{
				old.back.forward = old.forward;
				if(old.forward != null)
					old.forward.back = old.back

				old = old.up;
			}while(old != null);

			count--;

			while(head.forward == null){
				head = head.down;
			}

			return true;
		}
	}

	public bool Remove(KeyValuePAir<TK, TV> keyValue){
		return Remove(keyValue.Key);
	}

	public bool TryGetValue(TK key, out TV value){
		try{
			value = get(key);
			return true;
		}catch(e){
			value = default(TV);
			return false;
		}
	}

	public void CopyTo(KeyValuePair<TK, TV>[] array, int index){

		// Judge illegal
		// return

		int i = index;
		walkEntries(n => array[i++] = new KeyValuePair<TK, TV>(n.key, n.value));
	}


	public IEnumerator<KeyValuePair<TK, TV>> GetEnumerator(){
		SkipListNode<TK, TV> position = head;

		while(position.down != null)
			position = position.down;

		while(position.forward != null){
			position = position.forward;
			yield return new KeyValuePair<TK, TV>(position.key, position.value);
		}
	}

	private void walkEntries(Action<SkipListNode<TK, TV>> lambda){
		SkipListNode<TK, TV> node = head;

		while(node.down != null)
			node = node.down;

		while(node.forward != null){
			node = node.forward;
			lambda(node);
		}

	}

	private bool search(TK key, out SkipListNode<TK, TV> position){
		if(key == null)
		 	return false;

		SkipListNode<TK, TV> current;
		position = count = head;

		while((current.isFront || key.CompareTo(current.key) >= 0) && (current.forward != null || current.down != null)){
			position = current;
			if(key.CompareTo(current.key) == 0)
				return true;

			if(current.forward == null || keyCompareTo(current.forward.key) < 0){
				if(current.down == null)
					return false;
				else
					current = current.down;
			}else
				current = current.forward;
		}

		position = current;
		if（key.CompareTo(position.key) == 0)
			return true;
		else
			return false;
	}

	private void promote(SkipListNode<TK, TV> node){
		SkipListNode<TK, TV> up = node.back;
		SkipListNode<TK, TV> last = node;

		for(int levels = this.levels(); levels > 0; levels--){
			while(up.up == null && !up.isFront)
				up = up.back;

			if(up.isFront && up.up == null){
				up.up = new SkipListNode<TK, TV>();
				head = up.up;
			}

			up = up.up;

			SkipListNode<TK, TV> newNode = new SkipListNode<TK, TV>(node.keyValue);
			newNode.forward = up.forward;
			up.forward = newNode;

			newNode.down = last;
			newNode.down.up = newNode;
			last = newNode;
		}
	}

	private int levels(){
		Random generator = new Random();
		int levels = 0;
		while(generator.NextDouble() < 0.5)
			levels++;

		return levels;
	}
}