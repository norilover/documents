# C Sharp

> Grammar

* sealed

```c#
// The sealed modifier prevents other classes from inheriting from it.
// 当你不想让别的类去继承某一类时使用 sealed 关键字（类似Java 的 final用法）
// 系统库类中的String类就是这样的
sealed class A{}
class B {}

// Error
// 这时将不能继承A类
class C : A {}

// Right
// 可以继承B类
class C : B {}

```

* internal
```c#
// The internal keyword is an access modifier for type and type members
// Internal types or members are accessible only whthin files in the same assemblely(the same .dll file)
// internal 关键字主要用于限定被修饰变量的可被访问的区间或范围，同一个.dll中的类可以访问这种类型的变量（类似java protected,只有在同一个包下才可以访问）

// e.g.
// Assembly1.cs
internal class BaseClass{
    public static int i = 0;
}

// Assembly2.cs
class TestAccess{
    static void Main(){
        // Error. No Access!
        var myBase = new BaseClass();
    }
}
```

* where

```c#
// 1. The where clause in a generic definition specifies constrains on the types that are used as arguments for type parameters in a generic type, method, delegate. Constrains cans specify interfaces, base classes, or other type to be a reference.
// 向上限定，如果传入的泛型只能是其基类（父类）本身，或衍生类（子类）

// The type of T is the sub class of MonoBehaviour or itself. 
// 这里运用where可以实现，这个T类型必须是MonoBehaviour本身或其衍生类（子类）
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour{
    
}


// 2.The where clause is used in a query expression to specify which elements from the data source will be returned in the query expression.
// where还可以用于查询表达式，可以通过它对一个数据集合进行过滤处理，只保留符合条件的数据
int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

// In the following example, the where clause filters out all numbers except those that are less than five.
// queryLowNums来接受过滤后的结果
var queryLowNums =
    from num in numbers
    where num < 5
    select num;

// Execute the query.
// 这里输出原来numbers 数组中小于5的所有元素
foreach (var s in queryLowNums)
{
    Console.Write(s.ToString() + " ");
}
```

* lock

```c#
// The lock statement acquires the mutual-exclusion lock for a given object, executes a statement block, and then releases the lock.
// While a lock is held, the thread that holds the lock can again acquire and release the lock, Any other thread is blocked from acquring the lock and waits until the lock is released
object x;
lock(x)
{
    
}
```

* as

```c#
// 1.The as operator explicitly converts the result of an expression ti a given reference or nullable value type. 
// 2.If the conversion is not possiable, the as operator returns null. 
// 3.Unlike a cast expression, the as operator never throws an exception.

// Uage of key word of as
String str1 = "nori";
Object temp = st1;

// conversion

// Right conversion
String st2 = temp as String;
String st2 = (String)temp;

// Error conversion
// Use as
// There is not error and not throw an exception, but c is given null
Char c = temp as Char;

//Use common way
// There is error and will throw an exception
Char c = (Char)temp;

```


* Properties(Get, Set function)

```c#
public class Player
{
    void Start()
    {
        Player player= new Player();
        player.Experience = 10;
        int x = player.Experience;
    }
    
    private int experience;
    
    public int Experience
    {
        get
        {
            return experience;
            // also add some steps
            // return experience / 100;
        }
        set
        {
            experience = value;
            // experience = value * 100;
        }
    }
}
```

* static

```c#
// test
public class Analyze
{
	public void getEnemyNumber(){
        Enemy enemy01 = new Enemy();
        Enemy enemy02 = new Enemy();
        
        Player player01 = new Player();
        Player player02 = new Player();
        
		// directly access the variable of enemyNumber
        // output 4
		int totalNumber = CalUtil.plus(Enemy.enemyNumber, Player.playerNumber);
	}
}

// Apply to common class
public class Enemy
{
	public static int enemyNumber = 0;
    
    public Enemy(){
        Enemy.enemyNumber++;
        // Enemy.enemyNumber++;
    }
}
public class Player
{
	public static int playerNumber = 0;
    
    public Player(){
        Player.playerNumber++;
        // Enemy.playerNumber++;
    }
}

// Apply to Utility class
class CalUtil
{
	public static int plus(int num1, int num2){
        return num1 + num2;
    }
}
```

* Generics

```c#
// Test
public class Test
{
    // Generic class
    GenericClass<String> genericClass = new GenericClass<String>();
    genericClass.UpdateItem(new String("Nori"));
    
    // Generic method
    SomeClass someClas = new SomeClass();
    String str = someClas.getGeneric<String>();
}


// Apply to generic class
public class GenericClass <T>
{
    T item;
    
    public void UpdateItem(T item){
        this.item = item;
    }
}

// Apply to generic method
public class SomeClass
{
    public T getGeneric<T>(T parameter){
        return parameter;
    }
}
```

* Hide Function(new modifier)

```c#
/* 
	When used as a declaration modifier, the new keyword explicitly hides a member that is inherited from a base
class.When you hidean inherited member, the derived version of the member replaces the baseclass version
*/
...main(){
    // test
    Human human = new Human();
    // Output Human Yell()
    human.Yell();
    
    human = new Enemy();
    // Output Human Yell()
    human.Yell();
    
    human = new Player();
    // Output Human Yell()   
    human.Yell();
    
}

// The base class
public class Human
{
	public void Yell(){
        Console.WriteLine("Human Yell()");
    }
}

// The extend class
public class Enemy : Human
{
	new public void Yell(){
    	Console.WriteLine("Enemy Yell()");
    }
}

// The extend class
public class Player : Human
{
	new public void Yell(){
    	Console.WriteLine("Player Yell()");
    }
}

/*
override and new :
	It is an error to use both new and override on thesame member, becausethetwo modifiers have mutually
exclusive meanings.The new modifier creates a new member with thesame nameand causes the original
member to become hidden.The override modifier extends theimplementation for an inherited member.
*/
```

* Overriding

```c#
// Add key word of virtual when we neee to override a certain method 
public class BaseClass
{
    public virtual void BaseMehtod(){
        Console.WriteLine("Base Method");
    }
}

public class ExtendClass : BaseClass
{
     public virtual void BaseMehtod(){
         // Call base's BaseMehtod
         base.BaseMehtod();
        Console.WriteLine("Base Method");
    }   
}
```

* Interface

```c#
public interface IComparable<T>
{
    void Minus(T item1, T item2);
}

public class ComparableTest : IComparable<int>
{
    int ele = 10;
    public void Minus(int item1, int item2){
        return item1 - item2;
    }
}
```

* Extension Method

```c#
...main(){
    String str01 = "Nori";
    String str02 = null;
    
    // Use the extension method
    str01.ExtendTool();
    // Output Nori Full
    Console.WriteLine(str01);
    
    str02.ExtendTool();
    // Output Empty
    Console.WriteLine(str02);    
}

// The Extension Method
public static class ExtendMethod{
	public static void ExtendTool (this String str) {
        if(str == null){
            str = "Empty";
        }else{
            str += " Full";
        }
	}
}
```

* namespace

```C#
// Use namespace to organize more perfectly your classes
// Test
...main(){
	int item1 = 10, item2 = 10;
	int result = NoriSpace.NoriCalTool<int>(item1, item2);
	
	// Output 20
	Console.WriteLine(result);
}


namespace NoriSpace
{
	public class NoriCalTool<T>
	{
		public static T Plus(T item1, T item2){
			return item + item;
		}
	}
}
```

* Collection
```C#
..main(){
    // Single value
    // List
    List<int> listInt = new List<int>();
    listInt.Add(1);
    listInt.Add(2);
    listInt.Add(3);
    listInt.Add(4);
 
    /*
    // The other way
    List<Int32> list = new List<int>
    {
        1,
        2,
        3,
        Int32.MaxValue 
    };*/
    
    // Traverse the value of listInt
    Console.WriteLine("Element of listInt: \n");

    Console.WriteLine("Way1 \n");
    // Way1
    foreach(int i in listInt)
    {
        Console.WriteLine(i + "\n");
    }
    // Way2
    Console.WriteLine("Way2 \n");
    for(int i = 0; i < listInt.Count; i++)
    {
        Console.WriteLine(listInt[i] + "\n");
    }
    // Way3
    Console.WriteLine("Way3 \n");
    IEnumerator iterator = listInt.GetEnumerator();
    while (iterator.MoveNext())
    {
        if(iterator.Current is int)
        {
            Console.WriteLine(iterator.Current + "\n");
        }
    }

    
    // Double value
    // Dictionary
    Dictionary<string, int> dictionary = new Dictionary<string, int>();
    dictionary.Add("Nori", 23);
    dictionary.Add("Nori1", 24);
    dictionary.Add("Nori2", 25);
    dictionary.Add("Nori3", 26);
    
    /*
    Dictionary<string, int> UseFor = new Dictionary<string,string> {
            {"Nori",23},
        	{"Nori1",24},
        	{"nori2",25}
        };
     */

    // Traverse the value of dictionary
    Console.WriteLine("Element of dictionary: \n");
    // Way1
    Console.WriteLine("Way1 \n");
    foreach(string str in dictionary.Keys)
    {
        Console.WriteLine(dictionary[str] + "\n");
    }
    // Way2
    Console.WriteLine("Way2 \n");
    IEnumerator iterator01 = dictionary.GetEnumerator();
    while (iterator01.MoveNext())
    {
        KeyValuePair<string, int> keyValuePair = (KeyValuePair<string, int>)iterator01.Current;
        Console.WriteLine("Key: " + keyValuePair.Key + ", Value: " + keyValuePair.Value + "\n");
    }
}
```

* is

```c#
// Can to judge the class' detail type 
// the same effect java's instanceof
...main(){
    Object ob = new String(10);
    String str = Test(ob);
    // Output 10 Nori
	Console.WriteLine(str + "\n");
    
    ob = 10;
    // Output Empty
    str = Test(ob);
}

...String Test(Object ob){
    if(ob is String){
        return ob + " Nori"
    }else{
        return "Empty";
    }    
}

```

* Coroutine (for unity)

```c#
public class TestCoroutine
{
    void Start()
    {
        // Stop
        StopCoroutine()
        
        // Start
        StartCoroutine("MyCoroutine");
		StartCoroutine("MyCoroutine", target);
    }
    
    IEnumerator MyCoroutine(Transfrom target){
    
        while(Vector3.Distance(transform.position, target.position) > 0.05f)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, smoothing * Time.deltaTime);

            yield return null;
        }

        print("Reached the target.");
		
        // Optional item
        yield return new WaitForSeconds(3f);

        print("MyCoroutine is now finished.");    
        
    }
}
```

* Event

```c#
https://learn.unity.com/tutorial/quaternions?uv=2019.3&projectId=5c88f2c1edbc2a001f873ea5#5c8945d0edbc2a14103553dc
```

* Delegate
```c#
// A delegate is a reference type that can be used to encapsulate a named or an anonymous method.
// Delegates are similar to function pointers in C plus plus.
// Delegates are the basis for Events.
public class TestDelegate
{
    public delegate void MyDelagate<T>(T parameter);
    private MyDelagate MyDelagateTemp;
    ..main()
    {
		MyDelagateTemp = DelegateOne;
    
        // 1.Delegate DelegateOne function
        MyDelegateTemp = DelegateOne;
        
        // Not delegate DelegateOne function when we have delegated the function of DelegateOne
        // MyDelegateTemp -= DelegateOne;
        
        // 2.Delegate DelegateTwo<T> function
        MyDelegateTemp += DelegateTwo<int>;
        
        // 3.Delegate a anonymous method
        MyDelegateTemp += delegate (int parameter){
            Console.WriteLine("Anonymous Method");
            Debug.Log("Anonymous Method");
        	return parameter
        }
	
        // Output DelegateOne()
        // Output DelegateTwo()
        MyDelegateTemp();
    }
    
    public int DelegateOne(int parameter)
    {
        Console.WriteLine("DelegateOne()");
        Debug.Log("DelegateOne()");
        return parameter;
    }

    public T DelegateTwo<T>(T parameter)
    {
        Console.WriteLine("DelegateTwo()");
        Debug.Log("DelegateTwo()");
        return parameter;
    }
}

// For Delegate key word
public Delegate void delegateTemp;
public void Start(){
	delegateTemp = test01;
	// Actually call the function of test01 
	delegateTemp();

	delegateTemp = test02;
	// Actually call the function of test02
	delegateTemp();
}

public void test01(){

}

public void test02(){

}
```

* Delegates are similar to function pointers in C++

```c++
public class{
    public:
    	bool delegateVar1(String str, (int *) func(string str)){
            //
        }
     	int delegateVar2(String str{
            //
        }   
	private:
    	(bool *) var;
    	 
    	(int *) var1;
    	
    
    	main(){
            var1 v1 = delegateVar2("nori");
            var v2 = delegateVar1("nori", v1);
            var();
        }
    
    	for(auto v : vector<>){
            //
        }
}
```

* The delegate type

```c#
// In .NET, System.Action and System.Func types provide generic definitions for many common delegates.
namespace System
{
    public delegate void Action();
}

namespace System
{
    public delegate TResult Func<out TResult>();
}

namespace System
{
    public delegate TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2);
}

...main(){
    // Syste.Action
    // The three can implement the same effect
    System.Action noriAction = () => { }; 
    noriAction = delegate{}; 
    noriAction = Test01;
    
    // System.Func
    // The three can implement the same effect
    Func<string, string> selector = str => str.ToUpper();
    selector = delegate (string str){ return str.ToUpper(); }
    selector = MyToUpper

    // Create an array of strings.
    string[] words = { "orange", "apple", "Article", "elephant" };
    // Query the array and select strings according to the selector method.
    IEnumerable<String> aWords = words.Select(selector);

    // Output the results to the console.
    foreach (String word in aWords)
        Console.WriteLine(word);

    /*
    This code example produces the following output:

    ORANGE
    APPLE
    ARTICLE
    ELEPHANT

    */
    
}
public void Test01(){
    // balabala
}

public string MyToUpper(String str){
    return str.ToUpper();
}
```



* Lambda Expression 

```c#
public class Nori : MonoBehaviour
{

    public delegate void DelegateVar1();
    public delegate bool DelegateVar2(Object ob);
    
    
    public void LambdaT1(){
        // balabala
    }
    public bool LambdaT2(Object ob){
        // balabala
        return true;
    } 
    
    // Test Function
    public void FunctionT1(DelegateVar1 delegateVar1, DelegateVar2 delegateVar2)
    {
        // balabala
    }

    // Test
    public void Test()
    {
        Nori nori = new Nori();

        // Lambda Way 
        nori.FunctionT1(
            () => LambdaT1(),
            ob => LambdaT2(ob)
        );

        nori.FunctionT1(
            () =>
            {
                // balabala
            },
            ob =>
            {
                // balabala
                return false;
            }
        );

        // Delegate Way
        nori.FunctionT1(
            delegate ()
            {
                LambdaT1();
            },
            delegate (Object ob)
            {
                LambdaT2(ob);
                return true;
            }
        );

        nori.FunctionT1(
            delegate 
            {
                LambdaT1();
            },
            delegate (Object ob)
            {
                LambdaT2(ob);
                return true;
            }
        );
    }
}
```

* Attribute

```c#
https://learn.unity.com/tutorial/attributes?uv=2019.3&projectId=5c88f2c1edbc2a001f873ea5#
```

* Event

```c#
// to create a dynamic "broadcast" system using Events. 
public class TestEvent
{
    private Delegate void MyDelegate();
    
    public static event MyDelegate MyDelegateTemp;
    
}

public class TurnSomething
{
    void OnEnable(){
        TestEvent.MyDelegateTemp += TurnOne;
    }
    
    void OnDisable(){
        TestEvent.MyDelegateTemp -= TurnOne;
    }
}
```

* Nullable value types

```c#
// A nullable value T? represents all values of its underlying value type T and an additional null value.
// For bool(its value type), its value only to true or false, but bool?(its like a reference type), its value among null, true and false.
...main(){
    // can use true or false.
    bool b1 = true;
    // Will throw error.
    b1 = null;
    
    // Can use true, false and null without exception.
    // like the reference type
    bool? b2 = null; 
    
    // The T? type can be solved the trouble of interact with database, bacause the schema exist value of null for any type, but for many programming language the basic type may be no support the null's value.
}

```

* Enum

```c#
// The default value of the enum from 0 to #(# equals to that the number of element of enum minus 1) 
enum Season
{
	// 0
	Spring,
	// 1
	Summer,
	Autumn,
	// 3
	Winter
}

// You can give per element of enum default value(that is type of integer)
enum Season2
{
	Spring = 0,
	Summer = 10,
	Autumn = 20,
	Winter = 30
}
```

* Method Parameters

```c#
params : 
in  : can be read
ref : can be read or written
out : can be written.
```

* typeof

```c#
using System;
using System.Reflection;

public class Example
{
    ...Main()
    {
        Type type = typeof(String);
        
        MethodInfo substr = t.GetMethod("Substring", new Type[]{typeof(int), typeof(int)});
        
        Object message = substr.Invoke("Nori lover", new Object[]{6,5});
        
        // Output lover
        Console.WriteLine(message);
    }
}
```

* Related Clause Learning

```c#

    public delegate void MailItemAction<T>(T t);
    public MailItemAction<bool> AlterCheckedNum;
...main(){
    ...
        
    // Way1    
    if(AlterCheckedNum != null){
        AlterCheckedNum(true);
    }
    
    // implement the same effect like above code
    // Way2
    AlterCheckedNum?.Invoke(true);
}


```



* Linq Clause

```c#
using System.Linq

// Program.cs
// The Main() method
static IEnumerable<string> Suits()
{
    yield return "clubs";
    yield return "diamonds";
    yield return "hearts";
    yield return "spades";
}
static IEnumerable<string> Ranks()
{
    yield return "two";
    yield return "three";
    yield return "four";
    yield return "five";
    yield return "six";
    yield return "seven";
    yield return "eight";
    yield return "nine";
    yield return "ten";
    yield return "jack";
    yield return "queen";
    yield return "king";
    yield return "ace";
}

// Way1
static void Main(string[] args)
{
    var startingDeck = from s in Suits()
    from r in Ranks()
    select new { Suit = s, Rank = r };
    // Display each card that we've generated and placed in startingDeck in the console
	foreach (var card in startingDeck)
    {
    Console.WriteLine(card);
    }
}

// Way2 using the Linq
var startingDeck = Suits().SelectMany(suit => Ranks().Select(rank => new { Suit = suit, Rank = rank }));

// Relaited methods
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> selector);
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector);
        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector);
        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, IEnumerable<TResult>> selector);
        public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector);
        public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, int, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector);
        
```

