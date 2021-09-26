using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    //The Factory Method design pattern defines an interface for creating an object, 
    //but let subclasses decide which class to instantiate.
    //This pattern lets a class defer instantiation to subclasses.

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

    //Product
    public abstract class CreditCard
    {
        public abstract string CardType { get; }
        public abstract int CreditLimit { get; set; }
        public abstract int AnnualCharge { get; set; }
    }

    //ConcreteProduct1
    public class MoneyBackCreditCard : CreditCard
    {
        private readonly string _cardType;
        private int _creditLimit;
        private int _annualCharge;

        public MoneyBackCreditCard(int creditLimit, int annualCharge)
        {
            _cardType = "MoneyBack";
            _creditLimit = creditLimit;
            _annualCharge = annualCharge;
        }

        public override string CardType
        {
            get { return _cardType; }
        }

        public override int CreditLimit
        {
            get { return _creditLimit; }
            set { _creditLimit = value; }
        }

        public override int AnnualCharge
        {
            get { return _annualCharge; }
            set { _annualCharge = value; }
        }
    }

    //ConcreteProduct2
    public class TitaniumCreditCard : CreditCard
    {
        private readonly string _cardType;
        private int _creditLimit;
        private int _annualCharge;

        public TitaniumCreditCard(int creditLimit, int annualCharge)
        {
            _cardType = "Titanium";
            _creditLimit = creditLimit;
            _annualCharge = annualCharge;
        }

        public override string CardType
        {
            get { return _cardType; }
        }

        public override int CreditLimit
        {
            get { return _creditLimit; }
            set { _creditLimit = value; }
        }

        public override int AnnualCharge
        {
            get { return _annualCharge; }
            set { _annualCharge = value; }
        }
    }

    //ConcreteProduct3
    public class PlatinumCreditCard : CreditCard
    {
        private readonly string _cardType;
        private int _creditLimit;
        private int _annualCharge;

        public PlatinumCreditCard(int creditLimit, int annualCharge)
        {
            _cardType = "Platinum";
            _creditLimit = creditLimit;
            _annualCharge = annualCharge;
        }

        public override string CardType
        {
            get { return _cardType; }
        }

        public override int CreditLimit
        {
            get { return _creditLimit; }
            set { _creditLimit = value; }
        }

        public override int AnnualCharge
        {
            get { return _annualCharge; }
            set { _annualCharge = value; }
        }
    }

    //Creator
    public abstract class CreditCardFactory
    {
        public abstract CreditCard GetCreditCard();
    }

    //ConcreteCreator1
    public class MoneyBackFactory : CreditCardFactory
    {
        private int _creditLimit;
        private int _annualCharge;

        public MoneyBackFactory(int creditLimit, int annualCharge)
        {
            _creditLimit = creditLimit;
            _annualCharge = annualCharge;
        }

        public override CreditCard GetCreditCard()
        {
            return new MoneyBackCreditCard(_creditLimit, _annualCharge);
        }
    }

    //ConcreteCreator2
    public class TitaniumFactory : CreditCardFactory
    {
        private int _creditLimit;
        private int _annualCharge;

        public TitaniumFactory(int creditLimit, int annualCharge)
        {
            _creditLimit = creditLimit;
            _annualCharge = annualCharge;
        }

        public override CreditCard GetCreditCard()
        {
            return new TitaniumCreditCard(_creditLimit, _annualCharge);
        }
    }

    //ConcreteCreator3
    public class PlatinumFactory : CreditCardFactory
    {
        private int _creditLimit;
        private int _annualCharge;

        public PlatinumFactory(int creditLimit, int annualCharge)
        {
            _creditLimit = creditLimit;
            _annualCharge = annualCharge;
        }

        public override CreditCard GetCreditCard()
        {
            return new PlatinumCreditCard(_creditLimit, _annualCharge);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CreditCardFactory factory = null;
            Console.Write("Enter the card type you would like to visit: ");
            string card = Console.ReadLine();

            switch (card.ToLower())
            {
                case "moneyback":
                    factory = new MoneyBackFactory(50000, 0);
                    break;
                case "titanium":
                    factory = new TitaniumFactory(100000, 500);
                    break;
                case "platinum":
                    factory = new PlatinumFactory(500000, 1000);
                    break;
                default:
                    break;
            }

            if (factory != null)
            {
                CreditCard creditCard = factory.GetCreditCard();
                Console.WriteLine("\nYour card details are below :");
                Console.WriteLine("Card Type: {0}\nCredit Limit: {1}\nAnnual Charge: {2}", creditCard.CardType, creditCard.CreditLimit, creditCard.AnnualCharge);
            }
            else
            {
                Console.WriteLine("Card type {0} not supported.", card);
            }

            Console.ReadKey();
        }
    }
}
