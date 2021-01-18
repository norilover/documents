public class Captain{
	private final RowingBoat rowingBoat;

	// Default constructor and setter for rowingBoat
	public Captain(RowingBoat rowingBoat){
		this.rowingBoat = rowingBoat;
	}

	// implementation of RowingBoat interface to be able to move
	public void row(){
		rowingBoat.row();
	}
}