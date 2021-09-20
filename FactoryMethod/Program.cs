using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{

    //Product
    //This defines the interface of objects the factory method creates

    //ConcreteProduct
    //This is a class that implements the Product interface.

    //Creator
    //This is an abstract class and declares the factory method, which returns an object of type Product.
    //This may also define a default implementation of the factory method that returns a default ConcreteProduct object.
    //This may call the factory method to create a Product object.

    //ConcreteCreator
    //This is a class that implements the Creator class and overrides the factory method to return an instance of a ConcreteProduct.

    //Product - CreditCard
    //ConcreteProduct- MoneyBackCreditCard, TitaniumCreditCard, PlatinumCreditCard
    //Creator- CreditCardFactory
    //ConcreteCreator- ConcreteCreditCardFactory


    public interface CreditCard
    {
        void GetCreditCard();
    }

    public class MoneyBackCreditCard : CreditCard
    {
        public void GetCreditCard()
        {
            Console.WriteLine("Money back credit card is created with limit of R1,00,000.00 and annual charge of R100.00.");
        }
    }

    public class TitaniumCreditCard : CreditCard
    {
        public void GetCreditCard()
        {
            Console.WriteLine("Titanium credit card is created with limit of R2,50,000.00 and annual charge of R250.00.");
        }
    }

    public class PlatinumCreditCard : CreditCard
    {
        public void GetCreditCard()
        {
            Console.WriteLine("Platinum credit card is created with limit of R5,00,000.00 and annual charge of R500.00.");
        }
    }

    public abstract class CreditCardFactory
    {
        public abstract CreditCard GetCreditCard(string type);
    }

    public class ConcreteCreditCardFactory : CreditCardFactory
    {
        public override CreditCard GetCreditCard(string type)
        {
            switch (type.ToLower())
            {
                case "moneyback":
                    return new MoneyBackCreditCard();
                case "titanium":
                    return new TitaniumCreditCard();
                case "platinum":
                    return new PlatinumCreditCard();
                default:
                    throw new ApplicationException(string.Format("Credit card '{0}' cannot be created", type));
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CreditCardFactory creditCardFactory = new ConcreteCreditCardFactory();
            Console.Write("Enter the card type you would like to create: ");

            string type = Console.ReadLine();
            CreditCard creditCard = creditCardFactory.GetCreditCard(type);

            creditCard.GetCreditCard();
            Console.ReadLine();
        }
    }
}
