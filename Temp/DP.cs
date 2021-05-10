/*
Create
	Abstract Factory
	Builder
	Factory Method
	Prototype
	Singleton
*/
// Abstract Factory
{

	public class Test{
		...main(){
			TranslationFactory translationFactory = new SH_TranslationFactory();
			translationFactory.createPassenger().getDescription();
			translationFactory.createDriver().getDescription();
			translationFactory.createPoliceman().getDescription();

			translationFactory = new BJ_TranslationFactory();	
			translationFactory.createPassenger().getDescription();
			translationFactory.createDriver().getDescription();
			translationFactory.createPoliceman().getDescription();

		}
	}

	public interface Passenger{
		void getDescription();
	}

	public interface Driver{
		void getDescription();
	}

	public interface Policeman{
		void getDescription();
	}

	public class SH_Passenger : Passenger{
		public void getDescription(){
			log("Get common passager description!");
		}
	}

	public class SH_Driver : Passenger{
		public void getDescription(){
			log("Get common driver description!");
		}
	}

	public class SH_Policeman : Passenger{
		public void getDescription(){
			log("Get common policeman description!");
		}
	}

	public class BJ_Passenger : Passenger{
		public void getDescription(){
			log("Get common passager description!");
		}
	}

	public class BJ_Driver : Passenger{
		public void getDescription(){
			log("Get common driver description!");
		}
	}

	public class BJ_Policeman : Passenger{
		public void getDescription(){
			log("Get common policeman description!");
		}
	}
	public interface TranslationFactory{
		Passenger createPassenger();
		Driver createDriver();
		Policeman createPoliceman();
	}

	public class SH_TranslationFactory : TranslationFactory{
		public void Passenger createPassenger(){
			return new SH_Passenger();
		}
		public void Driver createDriver(){
			return new SH_Driver();
		}
		public void Policeman createPoliceman(){
			return new SH_Policeman();
		}
	}

	public class BJ_TranslationFactory : TranslationFactory{
		public void Passenger createPassenger(){
			return new BJ_Passenger();
		}
		public void Driver createDriver(){
			return new BJ_Driver();
		}
		public void Policeman createPoliceman(){
			return new BJ_Policeman();
		}
	}
}


// Builder
public class NoriInfo(){
	private String name;

	private int age;

	private Date birthday;

	private String homeAddress;

	private String workAddress;

	private String description;

	private String remark;

	//... so many property

	// Set and Get function

	public class NoriInfoBuilder(){
		NoriInfo noriInfo

		public NoriInfoBuilder(String name, int age){
			noriInfo = new NoriInfo();
			noriInfo.name = name;
			noriInfo.age = age;
			return this;
		}

		public NoriInfoBuilder SetBirthday(Date birthday){
			noriInfo.birthday = birthday;
			return this;
		}

		public NoriInfoBuilder SetHomeAddress(String homeAddress){
			noriInfo.homeAddress = homeAddress;
			return this;
		}

		public NoriInfoBuilder SetWorkAddress(String workAddress){
			noriInfo.workAddress = workAddress;
			return this;
		}

		//... so many set function

		public void build(){
			return noriInfo;
		}
	}
}


// Not important
// Factory Method
{
	public class AttackResult{

	}
	public enum AttackType{
		Silent,
		violet,
	}

	public interface Attackable{
		AttackResult getAttackResult(AttackType attackType);
	}

	public class ChildAttack : Attackable{
		Map<AttackType, AttackResult> map = new Map<>();

		public AttackResult getAttackResult(AttackType attackType){
			return map.get(attackType);
		}
	}

	public class AdultAttack : Attackable{
		Map<AttackType, AttackResult> map = new Map<>();

		public AttackResult getAttackResult(AttackType attackType){
			return map.get(attackType);
		}
	}
}

// Like Singleton
// Prototype 
{
	public class Test{

	}
}

// Singleton
public class ServerInfo{
	private static UniqueSign uniqueSign = null;
	private static Object lockObj = new Object();
	public static GetUniqueSignInstance(){
		if(uniqueSign == null){
			lock(lockObj){
				if(uniqueSign == null)
					uniqueSign = new UniqueSign();
			}
		}

		return uniqueSign;
	}
}

/*
Structure
	Adapter
	Bridge
	Composite
	Decorator
	Facade
	Flyweight
	Proxy
*/
// Adapter
{
	public class Test{
		...main(){
			KeyboardAdapterable keyboardAdapterable	= new KeyboardAdapter();
			keyboardAdapterable.pressedKeyUp();
		}
	}

	public class WindowsKeyboard{

		public void pressedKeyUp(...){
			log("Pressed key up!")
		}
		public void pressedKeyDown(...){
			log("Pressed key down!")
		}

		//... so many
	}

	public class MacKeyboard{

		public void pressedKeyUp(...){
			log("Pressed key up!")
		}
		public void pressedKeyDown(...){
			log("Pressed key down!")
		}

		//... so many
	}

	public interface KeyboardAdapterable{

		void pressedKeyUp(...);
		void pressedKeyDown(...);

		//... so many
	}

	public class KeyboardAdapter : KeyboardAdapterable{
		WindowsKeyboard windowsKeyboard;
		MacKeyboard macKeyboard;
		// and so on.

		public KeyboardAdapter(){
			// 只初始化对应系统键盘类
			#if Windows System
				windowsKeyboard = new WindowsKeyboard();
			#elif Mac System
				macKeyboard = new MacKeyboard();
			#end			
		}

		public void pressedKeyUp(...){
			if(windowsKeyboard != null)
				windowsKeyboard.pressedKeyUp(...);
			else if(macKeyboard != null){
				macKeyboard.pressedKeyUp();
			}else if(...)
			//...
		}
		public void pressedKeyDown(...){
			if(windowsKeyboard != null)
				windowsKeyboard.pressedKeyDown(...);
			else if(macKeyboard != null){
				macKeyboard.pressedKeyDown();
			}else if(...)
			//...		}
	}
}

// Bridge
{
	public interface Actionable{
		void eat();
		void sleep();
		void walk();

		AdditionalActionable additionalActionable;
	}

	public class Cat : Actionable{
		public Cat(AdditionalActionable additionalActionable){
			this.additionalActionable = additionalActionable;
		}

		public void eat(){
			additionalActionable.prepare2Eat();
			log("Ation: eat!");
		}
		public void sleep(){
			additionalActionable.prepare2Sleep();
			log("Ation: sleep!");
		}
		public void walk(){
			additionalActionable.preapre2Walk();			
			log("Ation: walk!");
		}

		public AdditionalActionable getAdditionalActionable(){
			return additionalActionable;
		}	
	}

	public class Dog : Actionable{
		public Dog(AdditionalActionable additionalActionable){
			this.additionalActionable = additionalActionable;
		}

		public void eat(){
			additionalActionable.prepare2Eat();
			log("Ation: eat!");
		}
		public void sleep(){
			additionalActionable.prepare2Sleep();
			log("Ation: sleep!");
		}
		public void walk(){
			additionalActionable.preapre2Walk();			
			log("Ation: walk!");
		}

		public AdditionalActionable getAdditionalActionable(){
			return additionalActionable;
		}	
	}

	public interface AdditionalActionable{
		void prepare2Eat();
		void prepare2Sleep();
		void preapre2Walk();
	}

	public class CatAdditionalAction ： AdditionalActionable{
		public void prepare2Eat(){
			log("Prepare eat!")
		}
		public void prepare2Sleep(){
			log("Prepare sleep!")
		}
		public void preapre2Walk(){
			log("Prepare walk!")
		}
	}

	public class DogAdditionalAction ： AdditionalActionable{
		public void prepare2Eat(){
			log("Prepare eat!")
		}
		public void prepare2Sleep(){
			log("Prepare sleep!")
		}
		public void preapre2Walk(){
			log("Prepare walk!")
		}
	}

	public class Test{
		...main(){
			Actionable actionable = new Cat(new CatAdditionalAction());
			actionable.eat();
			actionable.sleep();
			actionable.walk();

			Actionable actionable = new Dog(new DogAdditionalAction());
			actionable.eat();
			actionable.sleep();
			actionable.walk();

		}
	}
}

// Composite
{
	public abstract LetterComposite{
		private List<LetterComposite> children = new List<>();

		public void add(LetterComposite letter){
			children.add(letter);
		}

		public int count(){
			return children.size();
		}

		protected void printBefore(){}
		protected void printAfter(){}

		public void print(){
			printBefore();

			children.forEach(LetterComposite::print);

			printAfter();
		}
	}		

	public class Sentence extends LetterComposite {

		Words words = new Words();
		
		public Sentence(List<Word> words) {
			words.forEach(this::add);
		}

		// @Override
		protected void printThisAfter() {
			log(".");
		}
	}	

}

// Decorator
{
	public class Test{
		...main(){
			Restaurantable restaurantable = new SH_Restaurant(new BJ_Restaurant());
			restaurantable.orderFood();
			restaurantable.serveFood();
			restaurantable.checkOut();
		}
	}

	public interface Restaurantable{
		void orderFood();
		void serveFood();
		void checkOut();
	}

	public class SH_Restaurant : Restaurantable{
		private Restaurantable restaurantable;
		public SH_Restaurant(Restaurantable restaurantable){
			this.restaurantable = restaurantable;
		}

		public void orderFood(){
			restaurantable.orderFood();
			log("Order Food!");
		}
		public void serveFood(){
			restaurantable.serveFood();
			log("Serve Food!");
		}
		public void checkOut(){
			restaurantable.checkOut();
			log("Check Food!");
		}
	}

	public class BJ_Restaurant : Restaurantable{
		private Restaurantable restaurantable;
		public BJ_Restaurant(Restaurantable restaurantable){
			this.restaurantable = restaurantable;
		}

		public void orderFood(){
			restaurantable.orderFood();
			log("Order Food!");
		}
		public void serveFood(){
			restaurantable.serveFood();
			log("Serve Food!");
		}
		public void checkOut(){
			restaurantable.checkOut();
			log("Check Food!");
		}
	}
}


// No Important
// No Implement
// Facade
{
	public class Test{

	}
}


// Flyweight
{
	public class Test{
		...main(){
			ProvinceFactory provinceFactory = new ProvinceFactory();
			log(provinceFactory.getProvinceInfo(ProvinceType.SH).getName());
			log(provinceFactory.getProvinceInfo(ProvinceType.BJ).getName());
			// log(provinceFactory.getProvinceInfo(ProvinceType.LY).getName());
		}
	}

	public enum ProvinceType{
		SH,
		BJ,
		HN,
		// ...so many
	}

	public interface ProvincialCapital{
		String getName();

		// ...so many
	}

	public class SH_ProvincialCapital : ProvincialCapital{
		public String getName(){
			return "SH";
		}
	}

	public class BJ_ProvincialCapital : ProvincialCapital{
		public String getName(){
			return "BJ";
		}
	}

	public class ProvinceFactory{
		private static Map<ProvinceType, ProvincialCapital> map = new Map<>();
		
		static {
			if(!map.containsKey(ProvinceType.SH)){
				map.put(ProvinceType.SH, new SH_ProvincialCapital);
			}

			if(!map.containsKey(ProvinceType.BJ)){
				map.put(ProvinceType.BJ, new BJ_ProvincialCapital);
			}

			// ... so many
		}

		public ProvincialCapital getProvinceInfo(ProvinceType provinceType){
			return map.containsKey(provinceType) ? map.get(provinceType) ? null;

		}
	}	
}


// Proxy
{
	public class Test{
		...main(){
			Actionable actionable = new Policeman(new Passenger());
			actionable.enter(new Action("Crash car!"));
		}
	}

	public interface Actionable{
		void enter(Action action);
	}

	public class Action{
		String name;
		public void setName(String name){
			this.name = name;
		}

		public String toString(){
			return this.name;
		}
	}

	public class Passenger : Actionable{
		Actionable actionable;
		public Passenger(Actionable actionable){
			this.actionable = actionable;
		}

		public void enter(Action action){
			log("Native passenger! " + action.toString());
			actionable.enter(action);
		}
	}

	public class Policeman : Actionable{
		Actionable actionable;
		public Passenger(Actionable actionable){
			this.actionable = actionable;
		}

		public void enter(Action action){
			log("Policeman! " + action.toString());
			actionable.enter(action);
		}
	}
}

/*
Action
	Chain of Responsibility
	Command
	Interpreter
	Interator
	Mediator
	Memento
	Observer
	State
	Strategy
	Template Method
	Visitor
*/

// Chain of Responsibility
{
	public class Chain{
		public int index = 0;
		public List<Filterable> chains = new List<>();

		public Chain setFilter(Fliterable fliter){
			chains.add(fliter);
			return this;
		}

		public void startFilter(){

			if(index >= chains.length)
				return;

			chains[index++].doFilter(this);
		}
	}	

	public interface Filterable{
		void doFilter(Chain chain);
	}

	public class FilterUnsafe : Filterable{
		public void doFilter(Chain chain){
			// Native filter
			log("Execute fliter: " chain.index);

			chain.startFilter();

			log("Execute fliter: " + chain.index)
		}	
	}	

	public class FilterOther : Filterable{
		public void doFilter(Chain chain){
			// Native filter
			log("Execute fliter: " chain.index);

			chain.startFilter();

			log("Execute fliter: " + chain.index)
		}	
	}	
	public class Test{
		main(){
			new Chain().setFilter(new Unsafe()).setFilter(new FilterOther()).startFilter();
		}
	}
}


// No Implement
// Command
{
	public class Test{
		...main(){

		}
	}

	public class Operate{
		private Deque<Command> redoCom = new LinkedList<>();
		private Deque<Command> undoCom = new LinkedList<>();

		public bool undoCommand(){
			if(undoCom.size() <= 0)
				return false;

			var undoCommand = undoCom.PopTopEle();
			redoCom.pushBottomEle(undoCommand); 
		}

		public bool redoCommand(){
			if(redoCom.size() <= 0)
				return false;

			var redoCommand = undoCom.PopTopEle();
			undoCom.pushBottomEle(redoCommand); 
		}
	}
}


// No Implement
// Explain grammar of code or some one else
// Interpreter
{
	public class Test{

	}
}


// Interator
{
	public class Test{
		...main(){
			NoriList<Nori> noriList = new NoriList<>();
			Iterator<Nori> iterator = noriList.getIterator();

			while(iterator.hasNext())
				log(interator.next());
		}
	}

	// 迭代器接口
	public interface Iterator<T>{
		Iterator<T> getIterator();

		boolean hasNext();

		T next();
	}

	// 实现迭代器的集合
	public class NoriList<T> : Iterator<T>{
		// 迭代器遍历时使用的集合
		private NoriList noriList;
		private int index;
		// 当前 index 所指向的元素
		private T current;

		public Iterator<T> getIterator(){
			setEnumerator(new NoriList<>(this));
		}

		// 内部方法构造迭代器
		private void setEnumerator(NoriList noriList){
			this.noriList = noriList;
			this.index = 0;
			// 第一个元素为T类型的默认值
			this.current = default(T);
		}

		public boolean hasNext(){
			// 首先赋值当前元素为null
			<p></p>current = null;

			if(this.noriList == null)
				return false;

			// 移向下一个元素的位置
			index = index + 1;

			// 判断元素是否存在
			if(index >= this.noriList.size())
				return false;

			current = this.noriList[index];

			return true;

		}

		// 获取当前元素
		public T next(){
			return current;
		}
	}
}

// No Implement
// Mediator
{
	public interface Party{

	}

	public interface PartyMember{

	}

	public class PartyImp : Party{

	}

	public class PartyMemberBase : PartyMember{

	}
}


// 可用于实现快照
// Memento
// Memento pattern captures object internal state making it easy to store and restore objects in any point of time.
{
	public class Test{

	}
}


// Observer
{
	public class Test{

	}
}


// State
{
	public class Test{

	}
}


// Strategy
{
	public class Test{

	}
}


// Template Method
{
	public class Test{

	}
}


// Visitor
{
	public class Test{

	}
}

Test Svn version from 12419 to 14462, main including below fix question:
	1.MainWin concerning the attaching question.
	2.Member for some one region except region's own, giving the Grid own and admin priority to modify function located in the below of Member tab.
	3.


