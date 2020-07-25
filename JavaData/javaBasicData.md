# Java Basic Knowledge

* <E super T>

* <E extends T>

  ```
  <E super T> 
  	向下限定：E是T的基类（父类）
  		经常往里插入
  		
  <E extends T>
  	想上限定：E是T的派生类（子类）
  		频繁往外读取内容
  ```

* <?>

  ```
  PECS(Producer-Extends Consumer-Super) principle(原则)
      <? super T>：
      	消费者原则	
      <? extends T>：
      	生产者原则
  eg.
  ```

  ```java
  package edu.nori.cn;
  
  import java.util.ArrayList;
  import java.util.Collection;
  import java.util.Iterator;
  import java.util.List;
  /***
   * producer:生产者
   * consumer: 消费者
   * @author Nori
   *
   */
  public class Fruit{
  	public static void main(String[] args) {
  		// FruitClass.test(new Other());
  		List<Apple> ia = new ArrayList<>();
  		Apple apple = new Apple("NORI");
  		ia.add(apple);
  		apple = new Apple("TOM");
  		ia.add(apple);
  		new FruitClass<Fruits>().testExtend(ia);
  	
  
  		List<Fruits> lf = new ArrayList<>();
  		FruitClass<Apple> fruitClass = new FruitClass<Apple>();
  		List<Apple> lfs = new ArrayList<>();
  		lfs.add(new Apple("LILI"));
  		lfs.add(new Apple("SUSA"));
  		fruitClass.setLs(lfs);
  		fruitClass.testSuper(lf);
  		for(Fruits f : lf) {
  			System.out.println("lf: " + f.toString());
  		}
  	}
  }
  
  
  abstract class Fruits{
  
  	private String name;
  
  	public String getName() {
  		return name;
  	}
  
  	public void setName(String name) {
  		this.name = name;
  	}
  }
  
  class Apple extends Fruits{
  
  	public Apple(String name) {
  		super.setName(name);
  	}
  
  	@Override
  	public String toString() {
  		return "Apple [getName()=" + getName() + ", getClass()=" + getClass() + ", hashCode()=" + hashCode()
  				+ ", toString()=" + super.toString() + "]";
  	}
  
  }
  
  class FruitClass<E>{
  	private List<E> ls = new ArrayList<>();
  	public void setLs(List<E> ls) {
  		this.ls = ls;
  	}
  
  	public boolean testExtend(Collection<? extends E> set) {
  		for(E e : set) {
  			ls.add(e);
  		}
  
  		for(E e : ls) {
  			System.out.println("ls: " + e.toString());
  		}
  
  		return false;
  	}
  
  	public boolean testSuper(Collection<? super E> set) {
  		
  		for(E e : ls) {
  			set.add(e);
  		}
  
  		return false;
  	}
  }
  
  
  ```

  

