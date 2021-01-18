public class Nori{
	private final String remark1;
	private final String remark2;
	private final String remark3;
	private final String remark4;
	private final ClassName remark5;

	private Nori(Builder builder){
		this.remark1 = builder.remark1;
		this.remark2 = builder.remark2;
		this.remark3 = builder.remark3;
		this.remark4 = builder.remark4;
		this.remark5 = builder.remark5;
	}
}
