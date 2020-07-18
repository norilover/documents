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