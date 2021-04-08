using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab5._3
{



    class Program
    {
        static void GetCarInfo()
        {
            Console.WriteLine("So you'd like to add your old beater to the lot. Let's get a little info on it real quick.");
            Console.Write("What's the make?: ");
            string make = Console.ReadLine();
            Console.Write("What's the model?: ");
            string model = Console.ReadLine();
            string yearStr = "";
            string priceStr = "";
            string mileageStr = "";
            do
            {
                Console.Write("What year is it?: ");
                yearStr = Console.ReadLine();  
            } while (Validator.CheckInt(yearStr));
            int year = Int32.Parse(yearStr);
            do
            {
                Console.Write("How much is it?: $");
                priceStr = Console.ReadLine();
            } while (Validator.CheckDec(priceStr));
            decimal price = Decimal.Parse(priceStr);
            do
            {
                Console.Write("How many miles?: ");
                mileageStr = Console.ReadLine();
            } while (Validator.CheckDouble(mileageStr));
            double mileage = Double.Parse(mileageStr);

            CarLot.AddCar(new UsedCar(make, model, year, price, mileage));
        }

        public static string GetCorrectSpacing(List<Car> carList)
        {
            int maxMakeLen = 0;
            int maxModelLen = 0;
            int maxPriceLen = 0;

            foreach (Car car in CarLot.carList)
            {
                if (car.Make.Length > maxMakeLen)
                {
                    maxMakeLen = car.Make.Length;
                }
                if (car.Model.Length > maxModelLen)
                {
                    maxModelLen = car.Model.Length;
                }
                string priceStr = Convert.ToString(car.Price);
                if (priceStr.Length > maxPriceLen)
                {
                    maxPriceLen = priceStr.Length;
                }

            }

            return "{0} {1, " + (maxMakeLen + 2) + "} {2, " + (maxModelLen + 2) + "} ${3, " + maxPriceLen + "}";
        }

        static void Main(string[] args)
        {

            CarLot.AddCar(new Car("Chevy", "Blazer", 2021, 28800m));
            CarLot.AddCar(new Car("Kia", "Telluride", 2021, 32190m));
            CarLot.AddCar(new Car("Aston Martin", "Vantage", 2021, 139000m));
            CarLot.AddCar(new UsedCar("Alfa Romeo", "Stelvio Sport", 2018, 25990m, 41509));
            CarLot.AddCar(new UsedCar("Dodge", "Charger", 2019, 39646m, 15992));
            CarLot.AddCar(new UsedCar("GMC", "Yukon SLT", 2018, 45000m, 30864));

            bool done = false;
            while (!done)
            {
                Console.Clear();

                CarLot.ListCars();

                bool isValid = false;
                while (!isValid)
                {

                    Console.Write($"\nWhich car would you like? ");
                    bool isInt = Int32.TryParse(Console.ReadLine(), out int choice);
                    if (isInt && choice >= 1 && choice <= CarLot.carList.Count)
                    {
                        isValid = true;
                        Console.Clear();
                        Console.WriteLine($"You have selected the {CarLot.carList[choice - 1].Make} {CarLot.carList[choice - 1].Model} for ${CarLot.carList[choice - 1].Price}");

                        bool validAns = false;
                        while (!validAns)
                        {

                            Console.Write($"\nWould you like to buy the {CarLot.carList[choice - 1].Make} {CarLot.carList[choice - 1].Model}? (y/n): ");
                            string userAns = Console.ReadLine().ToLower();
                            if (userAns == "y" || userAns == "n")
                            {
                                validAns = true;
                                if (userAns == "y")
                                {
                                    Console.WriteLine($"Congratulations on your new {CarLot.carList[choice - 1].Make} {CarLot.carList[choice - 1].Model}!");
                                    CarLot.carList.RemoveAt(choice - 1);
                                }
                                else
                                {
                                    Console.WriteLine($"Are you sure??? Ok, no worries.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Sorry, that was not a valid option. Please try again");
                            }
                        }


                    }
                    else if (isInt && (choice == CarLot.carList.Count + 1 || choice == CarLot.carList.Count + 2))
                    {
                        isValid = true;
                        if (choice == CarLot.carList.Count + 1)
                        {
                            GetCarInfo();
                        }
                        else
                        {
                            done = true;
                            Console.Clear();
                            Console.WriteLine("Goodbye! Have a beautiful time!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Sorry, that was not a valid option. Please try again");
                    }
                }
            }
        }
    }
}
