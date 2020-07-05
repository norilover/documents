/***
  * Builder 建造者模式
  * 2、解决多构造问题,复杂型,类层次型  
  */
public class BuilderComplexed{
	public static void main(String[] args) {
		NyPizza nyPizza = new NyPizza.Builder(SMALL).addTopping(SAUSAGE).addTopping(ONION).build();

		Calzone calzone = new Calzone.Builder().addTopping(HAM).sauceInside().build();
	}
}

abstract class Pizza{
	public enum Topping {HAM, HUSHROOM, ONION, PEPPER, SAUSAGE}
	final Set<Topping> toppings;

	abstract static class Builder<T extends Builder<T>>{
		EnumSet<Topping> toppings = EnumSet.noneOf(Topping.class);
		public T addTopping(Topping topping){
			topping.add（Objects.requireNonNull(topping));
			return self();
		}		
		abstract Pizza build();

		protected abstract T self();
	}
	Pizza(Builder<?> builder){
		topping = builder.toppings.clone();
	}
}

class NyPizza extends Pizza{
	public enum Size{SMALL, MEDIUM, LARGE}
	private final Size size;

	public static class Builder extends Pizza.Builder<Builder>{
		private final Size size;

		public Builder(Size size){
			this.size = Objects.requireNonNull(size);
		}

		@Override
		public NyPizza build(){
			return new NyPizza(this);
		}

		@Override
		protected Builder self(){
			return this;
		}
	}
	private NyPizza(Builder builder){
		super(builder);
		size = builder.size;
	}
}

class Calzone extends Pizza{
	private final boolean sauceInside;

	public static class Builder extends Pizza.Builder<Builder>{
		private boolean sauceInside = false;

		public Builder sauceInside(){
			sauceInside = true;
			return this;
		}

		@Override
		public Calzone build(){
			return new Calzone（this);
		}

		@Override
		protected Builder self(){
			return this;
		}
	}

	private CalZone(Builder builder){
		super(builder);
		sauceInside = builder.sauceInside;
	}
}

