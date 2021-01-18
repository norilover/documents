public class Sword implements Weapon{
	private final Enchantment enchantment;

	public Sword(Enchnantment enchantment){
		this.enchantment = enchantment;
	}

	// Override
	public void wield(){
		LOGGER.info("The sword is wielded!");
		enchantment.onActivate();
	}


	// Override
	public void swing(){
		LOGGer.info("The sword is swinged!");
		enchantment.onActivate();
	}

	// Override
	public void unwield(){
		LOGGER.info("The sword is unwield");
		enchantment.onDeactivate();
	}

	// Override
	public Enchantment getEnchantment(){
		return enchantment;
	}
}

