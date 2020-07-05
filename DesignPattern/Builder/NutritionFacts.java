/***
  * Builder 建造者模式
  * 1、解决多构造问题,简单型  
  */
class NutritionFacts{
	private final int servingSize;
	private final int servings;
	private final int calories;
	private final int fat;
	private final int sodium;
	private final int carbohydrate;

	public static class Builder{
		private int servingSize;
		private int servings;
		private int calories;
		private int fat;
		private int sodium;
		private int carbohydrate;

		public Builder(int servingSize, int servings){
			this.servingSize = servingSize;
			this.servings = servings;
		}

		public Builder calories(int calories){
			this.calories = calories;
			return this;
		}

		public Builder fat(int fat){
			this.fat = fat;
			return this;

		}

		public Builder sodium(int sodium){
			this.sodium = sodium;
			return this;

		}

		public Builder carbohydrate(int carbohydrate){
			this.carbohydrate = carbohydrate;
			return this;
		}

		public NutritionFacts build(){
			return new NutritionFacts(this);
		}

	}

	private NutritionFacts(Builder builder){
		this.servingSize = builder.servingSize;
		this.servings = builder.servings;
		this.calories = builder.calories;
		this.fat = builder.fat;
		this.sodium = builder.sodium;
		this.carbohydrate = builder.carbohydrate;
	}

	public static void main(String[] args) {
		NutritionFacts nutritionFacts = new NutritionFacts.Builder(240, 8)
		.calories(100).sodium(35).carbohydrate(27).build();
	}
}