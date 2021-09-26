using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{

    //The Abstract Factory design pattern provides an interface for creating families
    //of related or dependent objects without specifying their concrete classes.

    //AbstractFactory
    //This is an interface for operations which is used to create abstract product.

    //ConcreteFactory
    //This is a class which implements the AbstractFactory interface operations to create concrete products.

    //AbstractProduct
    //This declares an interface for a type of product object

    //Product
    //This defines a product object to be created by the corresponding concrete factory also implements the AbstractProduct interface

    //Client
    //This is a class which uses AbstractFactory and AbstractProduct interfaces to create a family of related objects.

    //AbstractFactory- IMobilePhone
    //ConcreteFactory - Nokia, Samsung
    //AbstractProduct- ISmartPhone, INormalPhone
    //Product- NokiaPixel, Nokia1600, SamsungGalaxy, SamsungGuru
    //Client- MobileClient

    //AbstractProductA
    interface ISmartPhone
    {
        string GetModelDetails();
    }

    //AbstractProductB
    interface INormalPhone
    {
        string GetModelDetails();
    }

    //ProductA1
    class NokiaPixel : ISmartPhone
    {
        public string GetModelDetails()
        {
            return "Model: Nokia Pixel\nRAM: 3GB\nCamera: 8MP\n";
        }
    }

    //ProductA2
    class SamsungGalaxy : ISmartPhone
    {
        public string GetModelDetails()
        {
            return "Model: Samsung Galaxy\nRAM: 2GB\nCamera: 13MP\n";
        }
    }

    //ProductB1
    class Nokia1600 : INormalPhone
    {
        public string GetModelDetails()
        {
            return "Model: Nokia 1600\nRAM: NA\nCamera: NA\n";
        }
    }

    //ProductB2
    class SamsungGuru : INormalPhone
    {
        public string GetModelDetails()
        {
            return "Model: Samsung Guru\nRAM: NA\nCamera: NA\n";
        }
    }

    //AbstractFactory
    interface IMobilePhone
    {
        ISmartPhone GetSmartPhone();
        INormalPhone GetNormalPhone();
    }

    //ConcreteFactory1
    class Nokia : IMobilePhone
    {
        public ISmartPhone GetSmartPhone()
        {
            return new NokiaPixel();
        }

        public INormalPhone GetNormalPhone()
        { 
            return new Nokia1600();
        }
    }

    //ConcreteFactory2
    class Samsung : IMobilePhone
    {
        public ISmartPhone GetSmartPhone()
        {
            return new SamsungGalaxy();
        }

        public INormalPhone GetNormalPhone()
        {
            return new SamsungGuru();
        }
    }

    //Client
    class MobileClient
    {
        ISmartPhone smartPhone;
        INormalPhone normalPhone;

        public MobileClient(IMobilePhone factory)
        {
            smartPhone = factory.GetSmartPhone();
            normalPhone = factory.GetNormalPhone();
        }

        public string GetSmartPhoneModelDetails()
        {
            return smartPhone.GetModelDetails();
        }

        public string GetNormalPhoneModelDetails()
        {
            return normalPhone.GetModelDetails();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IMobilePhone nokiaMobilePhone = new Nokia();
            MobileClient nokiaClient = new MobileClient(nokiaMobilePhone);

            Console.WriteLine("********* NOKIA **********");
            Console.WriteLine(nokiaClient.GetSmartPhoneModelDetails());
            Console.WriteLine(nokiaClient.GetNormalPhoneModelDetails());

            IMobilePhone samsungMobilePhone = new Samsung();
            MobileClient samsungClient = new MobileClient(samsungMobilePhone);

            Console.WriteLine("******* SAMSUNG **********");
            Console.WriteLine(samsungClient.GetSmartPhoneModelDetails());
            Console.WriteLine(samsungClient.GetNormalPhoneModelDetails());

            Console.ReadKey();
        }
    }
}
