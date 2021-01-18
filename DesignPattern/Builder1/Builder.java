public static class Builder{
	private final String remark1;
	private final String remark2;
	private final String remark3;
	private final String remark4;
	private ClassName remark5;

	private Builder setRemark1(String remark1){
		this.remark1 = remark1;
		return this;
	}

	private Builder setRemark2(String remark2){
		this.remark2 = remark2;
		return this;
	}

	private Builder setRemark3(String remark3){
		this.remark3 = remark3;
		return this;
	}

	private Builder setRemark4(String remark4){
		this.remark4 = remark4;
		return this;
	}

	private Builder setRemark5(ClassName remark5){
		this.remark5 = remark5;
		return this;
	}
}