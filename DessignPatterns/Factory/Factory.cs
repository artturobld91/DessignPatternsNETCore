using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory
{
    /// <summary>
    /// Factory is a creational design patterns that solves the problem of creating product objects without specifying concrete subclases.
    /// Factory defines a method that must be used to create objects, instead of a direct call to the constructor (new operator).
    /// The subclases can overwrite this method to change the objects classes that are created.
    /// </summary>
    //The Factory class declares the factory method that is supposed to return
    // an object of a Product class. The Factory's subclasses usually provide
    // the implementation of this method.
    public abstract class Factory
    {
        // Note that the Creator may also provide some default implementation of
        // the factory method.
        public abstract IProduct FactoryMethod();

        // Also note that, despite its name, the Creator's primary
        // responsibility is not creating products. Usually, it contains some
        // core business logic that relies on Product objects, returned by the
        // factory method. Subclasses can indirectly change that business logic
        // by overriding the factory method and returning a different type of
        // product from it.
        public string SomeOperation()
        {
            // Call the factory method to create a Product object.
            var product = FactoryMethod();
            // Now, use the product.
            var result = "Creator: The same creator's code has just worked with "
                + product.Operation();

            return result;
        }
    }

    // Factory Creators override the factory method in order to change the
    // resulting product's type.
    public class FactoryCreatorA : Factory
    {
        // Note that the signature of the method still uses the abstract product
        // type, even though the concrete product is actually returned from the
        // method. This way the Creator can stay independent of concrete product
        // classes.
        public override IProduct FactoryMethod()
        {
            return new FactoryProductA();
        }
    }

    // Factory Creators override the factory method in order to change the
    // resulting product's type.
    public class FactoryCreatorB : Factory
    {
        // Note that the signature of the method still uses the abstract product
        // type, even though the concrete product is actually returned from the
        // method. This way the Creator can stay independent of concrete product
        // classes.
        public override IProduct FactoryMethod()
        {
            return new FactoryProductB();
        }
    }

    // Factory Products provide various implementations of the Product
    // interface.
    class FactoryProductA : IProduct
    {
        public string Operation()
        {
            return "{Result of FactoryProductA}";
        }
    }

    // Factory Products provide various implementations of the Product
    // interface.
    class FactoryProductB : IProduct
    {
        public string Operation()
        {
            return "{Result of FactoryProductB}";
        }
    }

    // The Product interface declares the operations that all concrete products
    // must implement.
    public interface IProduct
    {
        string Operation();
    }
}
