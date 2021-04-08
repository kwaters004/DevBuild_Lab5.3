using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5._3
{
    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }

        public Car()
        {
            Make = "";
            Model = "";
            Year = 0;
            Price = 0.00m;
        }

        public Car(string pMake, string pModel, int pYear, decimal pPrice)
        {
            Make = pMake;
            Model = pModel;
            Year = pYear;
            Price = pPrice;
        }

        public override string ToString()
        {
            int maxMakeLen = 0;
            int maxModelLen = 0;
            int maxPriceLen = 0;

            foreach (Car car in CarLot.carList)
            {
                if(car.Make.Length > maxMakeLen)
                {
                    maxMakeLen = car.Make.Length;
                }
                if(car.Model.Length > maxModelLen)
                {
                    maxModelLen = car.Model.Length;
                }
                string priceStr = Convert.ToString(car.Price);
                if(priceStr.Length > maxPriceLen)
                {
                    maxPriceLen = priceStr.Length;
                }

            }
            string priceFormat = "";
            if(Price >= 1000000)
            {
                priceFormat = ":0,000,000";
            }
            else if (Price < 1000000 && Price >= 10000)
            {
                priceFormat = ":0,000";
            }


            string thePrintOut = String.Format("{0} {1, " + (-1*(maxMakeLen + 1)) + "} {2, " + (-1 *(maxModelLen + 1)) + "} ${3, " + (maxPriceLen + 2) + priceFormat + "}", Year, Make, Model, Price);

            return thePrintOut;

        }
    }

    class UsedCar : Car
    {
        public double Mileage { get; set; }

        public UsedCar(string pMake, string pModel, int pYear, decimal pPrice, double pMileage) : base(pMake, pModel, pYear, pPrice)
        {
            Mileage = pMileage;
        }
        public override string ToString()
        {
            return base.ToString() + $" ({Mileage:0,000} miles) USED";
        }
    }


    class CarLot
    {
        public static List<Car> carList = new List<Car>();
        public static void AddCar(Car car)
        {
            carList.Add(car);
        }

        public static void ListCars()
        {
            int i = 1;
            foreach (Car car in carList)
            {
                Console.WriteLine($"{i}. {car.ToString()}");
                i += 1;
            }

            Console.WriteLine($"{carList.Count + 1}. Add Car");
            Console.WriteLine($"{carList.Count + 2}. Exit");


        }


        

    }

}
