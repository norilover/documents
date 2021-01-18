public final class SimpleTask extends Task{
	private static final Logger LOGGER = getLogger(SimpleTask.class);

	// Override
	public void execute(){
		LOGGER.info("SimpleTask!");
	}	
}