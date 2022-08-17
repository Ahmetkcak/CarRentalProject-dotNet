using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManagerTest();
            //ColorManagerTest();


            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer {UserId=2, CompanyName = "%10 indirim" });


        }







        private static void ColorManagerTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorName = "Beyaz" });
            //foreach (var item in colorManager.GetAll())
            //{
            //    Console.WriteLine(item.ColorName);
            //}
        }

        private static void CarManagerTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Car car = new Car { BrandId = 2, ColorId = 2, DailyPrice = 5000, Description = "Nostalji", ModelYear = 2002 };

            //carManager.Add(car);

            //foreach (var item in carManager.GetCarDetails())
            //{
            //    Console.WriteLine(item.CarId + " " + item.ColorName);
            //}
        }

    }
}
