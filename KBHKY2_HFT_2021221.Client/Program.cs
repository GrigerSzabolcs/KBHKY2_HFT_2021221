using KBHKY2_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KBHKY2_HFT_2021221.Client
{
    class Program
    {
        static bool intInputCheck(string input)
        {
            bool eredmeny = true;
            if (input.Length >= 10) { return false; }
            for (int i = 0; i < input.Length; i++)
            {
                if(input[i]=='0' || input[i] == '1' || input[i] == '2' || input[i] == '3' || input[i] == '4' || input[i] == '5' || input[i] == '6' || input[i] == '7' || input[i] == '8' || input[i] == '9') { }
                else { eredmeny = false; }
            }
            return eredmeny;
        }
        static void GetCars(RestService rest)
        {
            Console.WriteLine("Cars in the database:");
            var cars = rest.Get<Car>("car");
            int indexer = 1;
            foreach (var item in cars)
            {
                Console.WriteLine("{0}. Car - Model: {1}, BasePrice: {2}, Brand: {3}, Id: {4}", indexer, item.Model, item.BasePrice, rest.GetSingle<Brand>($"brand/{item.BrandId}").Name,item.Id);
                indexer++;
            }
        }
        static void GetBrands(RestService rest)
        {
            Console.WriteLine("Brands in the database:");
            var brands = rest.Get<Brand>("brand");
            int indexer = 1;
            foreach (var item in brands)
            {
                Console.WriteLine("{0}. Brand - BrandName: {1}, Id: {2}", indexer, item.Name, item.Id);
                indexer++;
            }
        }
        static void GetOwners(RestService rest)
        {
            Console.WriteLine("Owners in the database:");
            var owners = rest.Get<Owner>("owner");
            int indexer = 1;
            foreach (var item in owners)
            {
                Console.WriteLine("{0}. Owner - FirstName: {1}, LastName: {2}, Age: {3}, His/Her car: {4}, Id: {5}", indexer, item.FirstName, item.LastName, item.Age, rest.GetSingle<Car>($"car/{item.CarId}").Model, item.Id);
                indexer++;
            }
        }
        static void GetCar(RestService rest)
        {
            Console.Write("Enter the ID of the car you would like to get: ");
            string input = Console.ReadLine();
            if (intInputCheck(input))
            {
                int id = int.Parse(input);
                var car = rest.GetSingle<Car>($"car/{id}");
                if (car != null) { Console.WriteLine("Car - Model: {0}, BasePrice: {1}, Brand: {2}, Id: {3}", car.Model, car.BasePrice, rest.GetSingle<Brand>($"brand/{car.BrandId}").Name, car.Id); }
                else { Console.WriteLine($"We could not find a car in the database with the ID of {id}."); }
            }
            else { Console.WriteLine("Wront ID! ID can only be a positive number. Are you sure you gave the right input? (Input must be less than 1.000.000.000)"); }
            Console.WriteLine();
        }
        static void GetBrand(RestService rest)
        {
            Console.Write("Enter the ID of the brand you would like to get: ");
            string input = Console.ReadLine();
            if (intInputCheck(input))
            {
                int id = int.Parse(input);
                var brand = rest.GetSingle<Brand>($"brand/{id}");
                if (brand != null) { Console.WriteLine("Brand - BrandName: {0}, Id: {1}", brand.Name, brand.Id); }
                else { Console.WriteLine($"We could not find a brand in the database with the ID of {id}."); }
            }
            else { Console.WriteLine("Wront ID! ID can only be a positive number. Are you sure you gave the right input? (Input must be less than 1.000.000.000)"); }
            Console.WriteLine();
        }
        static void GetOwner(RestService rest)
        {
            Console.Write("Enter the ID of the owner you would like to get: ");
            string input = Console.ReadLine();
            if (intInputCheck(input))
            {
                int id = int.Parse(input);
                var owner = rest.GetSingle<Owner>($"owner/{id}");
                if (owner != null) { Console.WriteLine("Owner - FirstName: {0}, LastName: {1}, Age: {2}, His/Her car: {3}, Id: {4}", owner.FirstName, owner.LastName, owner.Age, rest.GetSingle<Car>($"car/{owner.CarId}").Model, owner.Id); }
                else { Console.WriteLine($"We could not find an owner in the database with the ID of {id}."); }
            }
            else { Console.WriteLine("Wront ID! ID can only be a positive number. Are you sure you gave the right input? (Input must be less than 1.000.000.000)"); }      
            Console.WriteLine();
        }
        static void DeleteCar(RestService rest)
        {
            Console.Write("Enter the ID of the car you would like to delete: ");
            string input = Console.ReadLine();
            if (intInputCheck(input))
            {
                int id = int.Parse(input);
                var car = rest.GetSingle<Car>($"owner/{id}");
                if (car != null)
                {
                    rest.Delete(id, "car");
                    Console.WriteLine("The car with the ID of {0} was deleted from the database with its owner.", id);
                }
                else { Console.WriteLine($"There is no car in the database with the ID of {id}."); }
            }
            else { Console.WriteLine("Wront ID! ID can only be a positive number. Are you sure you gave the right input? (Input must be less than 1.000.000.000)"); }
            Console.WriteLine();
        }
        static void DeleteBrand(RestService rest)
        {
            Console.Write("Enter the ID of the brand you would like to delete: ");
            string input = Console.ReadLine();
            if (intInputCheck(input))
            {
                int id = int.Parse(input);
                var brand = rest.GetSingle<Brand>($"brand/{id}");
                if (brand != null)
                {
                    rest.Delete(id, "brand");
                    Console.WriteLine("The brand with the ID of {0} was deleted from the database with its children.", id);
                }
                else { Console.WriteLine($"There is no brand in the database with the ID of {id}."); }
            }
            else { Console.WriteLine("Wront ID! ID can only be a positive number. Are you sure you gave the right input? (Input must be less than 1.000.000.000)"); }
            Console.WriteLine();
        }
        static void DeleteOwner(RestService rest)
        {
            Console.Write("Enter the ID of the owner you would like to delete: ");
            string input = Console.ReadLine();
            if (intInputCheck(input))
            {
                int id = int.Parse(input);
                var owner = rest.GetSingle<Owner>($"owner/{id}");
                if (owner != null)
                {
                    rest.Delete(id, "owner");
                    Console.WriteLine("The owner with the ID of {0} was deleted from the database.", id);
                }
                else { Console.WriteLine($"There is no owner in the database with the ID of {id}."); }
            }
            else { Console.WriteLine("Wront ID! ID can only be a positive number. Are you sure you gave the right input? (Input must be less than 1.000.000.000)"); }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(3000);
            RestService rest = new RestService("http://localhost:54669");

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                int input = GetOptionInput();

                Console.WriteLine("[" + input + "]" + " was your option.");
                //Do stuff according to the input
                switch (input)
                {
                    case 1:
                        GetCars(rest);
                        break;
                    case 2:
                        GetBrands(rest);
                        break;
                    case 3:
                        GetOwners(rest);
                        break;
                    case 4:
                        GetCar(rest);
                        break;
                    case 5:
                        GetBrand(rest);
                        break;
                    case 6:
                        GetOwner(rest);
                        break;
                    case 7:
                        DeleteCar(rest);
                        break;
                    case 8:
                        DeleteBrand(rest);
                        break;
                    case 9:
                        DeleteOwner(rest);
                        break;
                    default:
                        break;
                }
                //Would you like to go back to the menu or exit the app
                Console.WriteLine("To get back to the menu, please press 1. To exit the application please press 2.");
                int input2 = int.Parse(Console.ReadLine());
                if (input2 == 2) { exit = true; };
            }
            Environment.Exit(0);                   

        }
        static private int GetOptionInput()
        {
            Console.WriteLine("Things to know about the database. This database contains bla bla... Every owner in the database has a car, but not every car has an owner");
            Console.WriteLine("Welcome to the menu");
            Console.WriteLine("Pick an option:");
            Console.WriteLine("[1] GetAllCars");
            Console.WriteLine("[2] GetAllBrands");
            Console.WriteLine("[3] GetAllOwners");
            Console.WriteLine("[4] GetOneCar");
            Console.WriteLine("[5] GetOneBrand");
            Console.WriteLine("[6] GetOneOwner");
            Console.WriteLine("[7] DeleteCar");
            Console.WriteLine("[8] DeleteBrand");
            Console.WriteLine("[9] DeleteOwner");
            Console.WriteLine("[10] CreateCar");
            Console.WriteLine("[11] CreateBrand");
            Console.WriteLine("[12] CreateOwner");
            int input = int.Parse(Console.ReadLine());
            Console.Clear();
            return input;
        }
    }
}
