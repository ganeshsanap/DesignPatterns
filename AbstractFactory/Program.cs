using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    interface Bike
    {
        string Name();
    }

    interface Scooter
    {
        string Name();
    }

    class RegularBike : Bike
    {
        public string Name()
        {
            return "Regular Bike- Name";
        }
    }

    class SportsBike : Bike
    {
        public string Name()
        {
            return "Sports Bike- Name";
        }
    }

    class RegularScooter : Scooter
    {
        public string Name()
        {
            return "Regular Scooter- Name";
        }
    }

    class Scooty : Scooter
    {
        public string Name()
        {
            return "Scooty- Name";
        }
    }

    interface VehicleFactory
    {
        Bike GetBike(string typeOfBike);
        Scooter GetScooter(string typeofScooter);
    }


    class HondaFactory : VehicleFactory
    {
        public Bike GetBike(string typeOfBike)
        {
            switch (typeOfBike)
            {
                case "Sports":
                    return new SportsBike();
                case "Regular":
                    return new RegularBike();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", typeOfBike));
            }

        }

        public Scooter GetScooter(string typeOfScooter)
        {
            switch (typeOfScooter)
            {
                case "Sports":
                    return new Scooty();
                case "Regular":
                    return new RegularScooter();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", typeOfScooter));
            }

        }
    }

    class HeroFactory : VehicleFactory
    {
        public Bike GetBike(string typeOfBike)
        {
            switch (typeOfBike)
            {
                case "Sports":
                    return new SportsBike();
                case "Regular":
                    return new RegularBike();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", typeOfBike));
            }

        }

        public Scooter GetScooter(string typeOfScooter)
        {
            switch (typeOfScooter)
            {
                case "Sports":
                    return new Scooty();
                case "Regular":
                    return new RegularScooter();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", typeOfScooter));
            }
        }
    }


    class VehicleClient
    {
        Bike bike;
        Scooter scooter;

        public VehicleClient(VehicleFactory factory, string type)
        {
            bike = factory.GetBike(type);
            scooter = factory.GetScooter(type);
        }

        public string GetBikeName()
        {
            return bike.Name();
        }

        public string GetScooterName()
        {
            return scooter.Name();
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            VehicleFactory honda = new HondaFactory();
            VehicleClient hondaclient = new VehicleClient(honda, "Regular");

            Console.WriteLine("******* Honda **********");
            Console.WriteLine(hondaclient.GetBikeName());
            Console.WriteLine(hondaclient.GetScooterName());

            hondaclient = new VehicleClient(honda, "Sports");
            Console.WriteLine(hondaclient.GetBikeName());
            Console.WriteLine(hondaclient.GetScooterName());

            VehicleFactory hero = new HeroFactory();
            VehicleClient heroclient = new VehicleClient(hero, "Regular");

            Console.WriteLine("******* Hero **********");
            Console.WriteLine(heroclient.GetBikeName());
            Console.WriteLine(heroclient.GetScooterName());

            heroclient = new VehicleClient(hero, "Sports");
            Console.WriteLine(heroclient.GetBikeName());
            Console.WriteLine(heroclient.GetScooterName());

            Console.ReadKey();
        }
    }
}
