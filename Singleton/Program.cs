using System;

namespace Singleton
{
    class Program
    {
        //The Singleton design pattern ensures a class has only one instance and provide a global point of access to it.

        //Private and parameterless single constructor
        //Sealed class.
        //Static variable to hold a reference to the single created instance
        //A public and static way of getting the reference to the created instance.

        //No Thread Safe Singleton.
        //Thread-Safety Singleton.
        //Thread-Safety Singleton using Double-Check Locking.
        //Thread-safe without a lock.
        //Using.NET 4's Lazy<T> type.

        //No Thread Safe Singleton
        public sealed class Singleton1
        {
            private Singleton1()
            {
            }

            private static Singleton1 _instance = null;

            public static Singleton1 Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton1();
                    }
                    return _instance;
                }
            }
        }

        //Thread Safety Singleton
        public sealed class Singleton2
        {
            private Singleton2()
            {
            }
            
            private static readonly object _lock = new object();
            
            private static Singleton2 _instance = null;
            
            public static Singleton2 Instance
            {
                get
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Singleton2();
                        }
                        return _instance;
                    }
                }
            }
        }

        //Thread-Safety Singleton using Double-Check Locking
        public sealed class Singleton3
        {
            private Singleton3()
            {
            }
            
            private static readonly object _lock = new object();
            
            private static Singleton3 _instance = null;
            
            public static Singleton3 Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        lock (_lock)
                        {
                            if (_instance == null)
                            {
                                _instance = new Singleton3();
                            }
                        }
                    }
                    return _instance;
                }
            }
        }

        //Thread-safe without a lock.
        public sealed class Singleton4
        {
            private static readonly Singleton4 _instance = new Singleton4();
            static Singleton4()
            {
            }
            private Singleton4()
            {
            }
            public static Singleton4 Instance
            {
                get
                {
                    return _instance;
                }
            }
        }

        //Using.NET 4's Lazy<T> type.
        public sealed class Singleton5
        {
            private Singleton5()
            {
            }
            private static readonly Lazy<Singleton5> lazy = new Lazy<Singleton5>(() => new Singleton5());
            public static Singleton5 Instance
            {
                get
                {
                    return lazy.Value;
                }
            }
        }

        static void Main(string[] args)
        {
            Singleton1 singleton1 = Singleton1.Instance;
        }
    }
}
