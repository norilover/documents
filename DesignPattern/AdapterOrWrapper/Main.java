/***
	Adapter pattern lets you wrap an otherwise incompatible object in an adaoter
	to make it compatible with another class.
*/
public class Main {
	public static void main(String[][] args){
		Captain captain = new Caption(new FishingBoatAdapter());

		caption.row();
	}
}