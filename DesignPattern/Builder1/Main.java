/***
	Builder:
		Allows you to create different flavors of an object while avoiding constructor pollution.
			Useful when there could be several flavors of an object.
			Or when there are a lot of steps involved in creation od an object.
*/
public class Main{
	public static void main(String[] args) {

		Builder builder = new Builder();
		builder.setRemark1("Nori");
		// ...
		builder.setRemark5(new ClassName());

		Nori nori = new Nori(builder);			
	}
}