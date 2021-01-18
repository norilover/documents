public class FlyingEnchantment implements Enchantment{
	Logger LOGGER = new Logger();

	public void flyingEnchantment(){
		LOGGER.info("flyingEnchantment");
	}

	public void apply(){
		LOGGER.info("apply");
	}

	public void onActivate(){
		LOGGER.info("onActivate");
	}

	public void onDeactivate(){
		LOGGER.info("onDeactivate");
	}
}