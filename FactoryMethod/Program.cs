using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{

    #region Product
    public interface IFactory
    {
        void Create();
    }
    #endregion

    #region Concrete Product
    public class Bike : IFactory
    {
        public void Create()
        {
            Console.WriteLine("BIKE is created from factory!");
        }
    }

    public class Car : IFactory
    {
        public void Create()
        {
            Console.WriteLine("CAR is created from factory!");
        }
    }
    #endregion

    #region Creator
    public abstract class VehicleFactory
    {
        public abstract IFactory GetVehicle(string vehicle);
    }
    #endregion

    #region Concrete Creator
    public class ConcreteVehicleFactory : VehicleFactory
    {
        public override IFactory GetVehicle(string vehicle)
        {
            switch (vehicle.ToLower())
            {
                case "bike":
                    return new Bike();
                case "car":
                    return new Car();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", vehicle));
            }
        }
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            VehicleFactory factory = new ConcreteVehicleFactory();

            IFactory bike = factory.GetVehicle("Bike");
            bike.Create();

            IFactory car = factory.GetVehicle("Car");
            car.Create();

            Console.ReadKey();
        }
    }
}
