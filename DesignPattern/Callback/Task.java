public abstract class Task{
	final void executeWith(Callback callback){
		execute();
		Optional.ofNullable(callback).fiPresent(Callback::call);
	}

	public abstract void execute();
}