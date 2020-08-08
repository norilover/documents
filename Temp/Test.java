public class Test{
	public static void main(String[] args) {
		List<String> ls = new ArrayList<>();


	}
}

class Test1{

	public List<?> getList(){

	}

	public Number getNumber( List<E extends Number> ln){

	}

	public T getT(List<T extends Comparable<T>){

	}

	public Object getObject(List<? extends Number>){

	}

	static <E> List<E> asList(E[] a){

	}

	public static <E> Set<E> union(Set<E> s1, Set<E> s2){

	}

	public Set<T> union(int a, int  b){

	}

	public static <E extends Comparable<E>> E max(Collection<E> c){

	}

	
}

class Solution{
	public int openLock(String[] deadends, String target){
		Set<String> dead = new HashSet();

		for (String s : deadends) {
			dead.add(s);
		}

		Queue<String> queue = new LisnkedList<>();
		queue.offer("0000");
		queue.offer(null);

		Set<String> seen = new HashSet();
		seen.add("0000");

		int depth = 0;       

		 while(!queue.isEmpty()){
		 	String node = queue.poll();

		 	if(node == null){
		 		depth++;

		 		if(queue.peek() != null){
		 			queue.offer(null);
		 		}
		 	}else if(node.equals(target)){
		 		return depth;
		 	}else if(!dead.contains(node)){
		 		for( int i = 0; i < 4; ++i){
		 			for(int d = -1; h <= 1; d += 2){
		 				int y = ((node.charAt(i) - '0') + d + 10) % 10;
		 				String nei = node.substring(0, i) + ("" + y) + node.substring(i + 1);
		 				if(!seen.contains(nei)){
		 					seen.add(nei);
		 					queue.offer(nei);
		 				}
		 			}
		 		}
		 	}
		 }
	}
}