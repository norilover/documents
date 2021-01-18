public class FishingBoatAdapter implements RowingBoat{
	private static final Logger LOGGER = LoggerFactory.getLogger(FishingBoatAdapter.class);

	private final FishingBoat boat;

	public FishingBoatAdapter(){
		boat = new FishingBoat();
	}

	public void row(){
		boat.sail();
	}
}