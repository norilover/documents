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
	
}

// Decorator
// Facade
// Flyweight
// Proxy


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

// Command
// Interpreter
// interator
// Mediator
// Memento
// Observer
// State
// Strategy
// Template Method
// Visitor



