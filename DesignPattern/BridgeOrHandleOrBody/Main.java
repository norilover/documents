/***
	Bridge pattern is about preferring composition over inheritance.
		Implementation detail are pushed from a hierarchy to another object with a separate hierarchy.
*/
public class Main{
	public static void main(String[][] args){
		Sword sword = new Sword(new SoulEatingEnchantment());
		sword.swing();
		sword.unwield();
		sword.wield();

		Hammer hammer = new Hammer(new FlyingEnchantment());
		hammer.swing();
		hammer.unwield();
		hammer.wield();
	}
}