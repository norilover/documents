/***
	Callback:
	Callback is a method passed to the execytor which will be called at defined moment.
	Like function of pointer(C/C++, Go) or delegate(C#) and so on.
*/
public class Main{
	public static void main(String[] args) {
		Task task = new SimpleTask();

		task.executeWith(() -> {
			LOGGER.info("Callback execute!")
		});			
	}	
}