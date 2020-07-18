public class Test{
	public static void main(String[] args) {
		String quifiedName = "Class";

		char[] chars = quifiedName.toCharArray();
		chars[0] += 32;

		System.out.println(String.valueOf(chars));


		// 
		String url = "www//nori//edu///cn";

		System.out.println(url.replaceAll("/+", "."));
	}
}