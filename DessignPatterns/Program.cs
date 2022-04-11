using DesignPatterns.Builder;
using DesignPatterns.Singleton.SingletonBasic;
using DesignPatterns.Singleton.SingletonThread;
using DesignPatterns.Prototype;
using System;
using System.Threading;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            //Prototype
            Prototype();

            //Singleton Basic
            Singleton_Basic();
            //Singleton Threaded
            Singleton_Threaded();

            //Builder
            Builder();
        }

        #region Prototype

        public static void Prototype()
        {
            Console.WriteLine("----------------------------- Prototype -----------------------------");
            DesignPatterns.Prototype.Prototype prototype = new DesignPatterns.Prototype.Prototype();
            prototype.PrototypePattern();
            Console.WriteLine("----------------------------- Prototype -----------------------------");
        }

        #endregion

        #region Singleton Basic

        public static void Singleton_Basic()
        {
            Console.WriteLine("----------------------------- Singleton Basic -----------------------------");
            // The client code.
            SingletonBasic s1 = SingletonBasic.GetInstance();
            SingletonBasic s2 = SingletonBasic.GetInstance();

            if (s1 == s2)
            {
                Console.WriteLine("Singleton works, both variables contain the same instance.");
            }
            else
            {
                Console.WriteLine("Singleton failed, variables contain different instances.");
            }
            Console.WriteLine("----------------------------- Singleton Basic -----------------------------");
        }

        #endregion

        #region Singleton Threaded

        public static void Singleton_Threaded()
        {
            Console.WriteLine("----------------------------- Singleton Threaded -----------------------------");
            Console.WriteLine(
               "{0}\n{1}\n\n{2}\n",
               "If you see the same value, then singleton was reused (yay!)",
               "If you see different values, then 2 singletons were created (booo!!)",
               "RESULT:"
           );

            Thread process1 = new Thread(() =>
            {
                TestSingleton("FOO");
            });
            Thread process2 = new Thread(() =>
            {
                TestSingleton("BAR");
            });

            process1.Start();
            process2.Start();

            process1.Join();
            process2.Join();

            Console.WriteLine("----------------------------- Singleton Threaded -----------------------------");
        }

        public static void TestSingleton(string value)
        {
            SingletonThreaded singleton = SingletonThreaded.GetInstance(value);
            Console.WriteLine(singleton.Value);
        }

        #endregion

        #region Builder

        public static void Builder()
        {
            Console.WriteLine("----------------------------- Builder -----------------------------");
            // The client code creates a builder object, passes it to the
            // buildermanager and then initiates the construction process. The end
            // result is retrieved from the builder object.
            var builderManager = new BuilderManager();
            var builder = new Builder.Builder();
            builderManager.Builder = builder;

            Console.WriteLine("Standard basic product:");
            builderManager.BuildMinimalViableProduct();
            Console.WriteLine(builder.GetProduct().ListParts());

            Console.WriteLine("Standard full featured product:");
            builderManager.BuildFullFeaturedProduct();
            Console.WriteLine(builder.GetProduct().ListParts());

            // Remember, the Builder pattern can be used without a BuilderManager
            // class.
            Console.WriteLine("Custom product:");
            builder.BuildPartA();
            builder.BuildPartC();
            Console.Write(builder.GetProduct().ListParts());
            Console.WriteLine("----------------------------- Builder -----------------------------");
        }

        #endregion
    }
}
