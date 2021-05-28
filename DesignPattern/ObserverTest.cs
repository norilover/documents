using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ConsoleTest.DP
{
    /***
     * 观察者模式模拟：
     *
     * 1.创立学校
     * 2.老师订阅学校的平台
     * 3.学校发布消息(给老师)：
     *      老师收到消息(execute onNext())
     * 4.学校结束消息发布
     */
    public class ObserverTest
    {
        private static void print(string receivesValue) => Console.WriteLine(receivesValue);
        public static void _Main(string[] args)
        {
            // 1.创立学校
            SchoolObservable schoolObservable = new SchoolObservable();
            
            // 2.老师订阅学校的平台
            schoolObservable.subscribe(new Class1TeacherObserver("1"));
            schoolObservable.subscribe(new Class2TeacherObserver("2"));
            schoolObservable.subscribe(new Class3TeacherObserver("3"));
            
            // 3.学校发布消息(给老师)：
            //      老师收到消息(execute onNext())           
            schoolObservable.onNext(1000);
            
            // 4.学校结束消息发布
            schoolObservable.onCompleted();
        }
        /**
         * 观察者
         */
        public interface IObserver
        {
            void onNext(int value);
            void onError(Exception exception);
            void onCompleted();
        }
        
        /***
         * 发布者
         */
        public interface IObservable
        {
            void subscribe(IObserver iObserver);
        }


        public class SchoolObservable : IObservable, IObserver
        {
            private List<IObserver> _list = new List<IObserver>();
            public void subscribe(IObserver iObserver)
            {
                _list.Add(iObserver);    
            }

            public void onNext(int value)
            {
                _list.ForEach((iObserver)=>iObserver.onNext(value));
            }

            public void onError(Exception exception)
            {
                _list.ForEach((iObserver)=>iObserver.onError(exception));
            }

            public void onCompleted()
            {
                _list.ForEach((iObserver)=>iObserver.onCompleted());
            }
        }


        public class Class1TeacherObserver : IObserver
        {
            private readonly string _className;

            public Class1TeacherObserver(string className)
            {
                _className = className;
            }
            
            public void onNext(int value)
            {
                ObserverTest.print(_className + " receives value " + value);
            }

            public void onError(Exception exception)
            {
                throw new NotImplementedException();
            }

            public void onCompleted()
            {
                print(_className + " Completed");
            }
        }


        public class Class2TeacherObserver : IObserver
        {
            private readonly string _className;

            public Class2TeacherObserver(string className)
            {
                _className = className;
            }

            
            public void onNext(int value)
            {
                ObserverTest.print(_className + " receives value " + value);
            }

            public void onError(Exception exception)
            {
                throw new NotImplementedException();
            }

            public void onCompleted()
            {
                print(_className + " Completed");
            }
        }
        
        public class Class3TeacherObserver : IObserver
        {
            private readonly string _className;

            public Class3TeacherObserver(string className)
            {
                _className = className;
            }

            public void onNext(int value)
            {
                ObserverTest.print(_className + " receives value " + value);
            }

            public void onError(Exception exception)
            {
                throw new NotImplementedException();
            }

            public void onCompleted()
            {
                print(_className + " Completed");
            }
        }
    }
}