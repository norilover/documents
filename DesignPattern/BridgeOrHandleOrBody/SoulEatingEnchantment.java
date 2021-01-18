public class SoulEatingEnchantment implements Enchantment{
	Logger LOGGER = new Logger();
	public void soulEatingEnchantment(){
		LOGGER.info("soulEatingEnchantment");
	}

	public void onActivate(){
		LOGGER.info("onActivate");
	}

	public void onDeactivate(){
		LOGGER.info("onDeactivate");
	}
}