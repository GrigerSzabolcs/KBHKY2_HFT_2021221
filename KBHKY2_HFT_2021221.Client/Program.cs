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
                else { return false; }
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
                var car = rest.GetSingle<Car>($"car/{id}");
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
        static void CreateCar(RestService rest)
        {
            Car c = new Car();
            Console.WriteLine("To create a new car in the database, please fill out the followings:");
            Console.Write("\nModel of the car: ");
            c.Model = Console.ReadLine();
            Console.Write("\nBasePrice of the car: ");
            string input = "x";
            while (!intInputCheck(input))
            {
                input = Console.ReadLine();
                if (intInputCheck(input) == false) { Console.WriteLine("Error! Wrong input format, try again!"); }
            }
            c.BasePrice = int.Parse(input);
            Console.Write("\nIn case you've changed your mind and dont want to create a new car, give 'x' as an input here!");
            Console.Write("\nBrand of the car (give the ID of the brand): ");

            string input2 = "asd";
            bool wecool = false;
            bool changedMind = false;
            while (!wecool)
            {
                input2 = Console.ReadLine();
                if (input2 == "x") { wecool = true; changedMind = true; }
                else
                {
                    if (intInputCheck(input2) == false) { Console.WriteLine("Error! Wrong input format, try again!"); }
                    else if (intInputCheck(input2) == true)
                    {
                        var brand = rest.GetSingle<Brand>($"brand/{input2}");
                        if (brand == null) { Console.WriteLine($"We could not find a brand in the database with the ID of {input2}. Try again!"); }
                        else { c.BrandId = int.Parse(input2); wecool = true; Console.WriteLine("A new car was inserted to the database!"); }
                    }
                }
            }
            if (!changedMind) { rest.Post<Car>(c, "car"); }
            else { Console.WriteLine("CreateCar aborted!"); }
        }
        static void CreateBrand(RestService rest)
        {
            Brand b = new Brand();
            var brands = rest.Get<Brand>("brand").Select(b => b.Name);
            bool wecool = false;
            Console.WriteLine("To create a new brand in the database, please fill out the followings:");
            do
            {
                Console.Write("\nName of the brand: ");
                b.Name = Console.ReadLine();
                if (!brands.Contains(b.Name)) { wecool = true; }
                else { Console.WriteLine($"There is already a brand in the database with the name: {b.Name}. Try another name!"); }
            } while (!wecool);
            rest.Post<Brand>(b, "brand");
            Console.WriteLine("A new brand was inserted to the database!");
        }
        static void CreateOwner(RestService rest)
        {
            Owner o = new Owner();           
            Console.WriteLine("To create a new owner in the database, please fill out the followings:");
            Console.Write("\nFirst name of the owner: ");
            o.FirstName = Console.ReadLine();
            Console.Write("\nLast name of the owner: ");
            o.LastName = Console.ReadLine();
            Console.Write("\nAge of the owner: ");
            string input = "x";
            while (!intInputCheck(input))
            {
                input = Console.ReadLine();
                if (intInputCheck(input) == false) { Console.WriteLine("Error! Wrong input format, try again!"); }
            }
            o.Age = int.Parse(input);

            Console.Write("\nIn case you've changed your mind and dont want to create a new owner, give 'x' as an input here!");
            Console.Write("\nCar of the owner (give the ID of the car): ");          
            string input2 = "asd";
            bool wecool = false;
            bool changedMind = false;
            while (!wecool)
            {
                input2 = Console.ReadLine();
                if (input2 == "x") { wecool = true; changedMind = true; }
                else
                {
                    if (intInputCheck(input2) == false) { Console.WriteLine("Error! Wrong input format, try again!"); }
                    else if (intInputCheck(input2) == true)
                    {
                        var car = rest.GetSingle<Car>($"car/{input2}");
                        if (car == null) { Console.WriteLine($"We could not find a car in the database with the ID of {input2}. Try again!"); }
                        else { o.CarId = int.Parse(input2); wecool = true; Console.WriteLine("A new owner was inserted to the database!"); }
                    }
                }
            }         
            if (!changedMind) { rest.Post<Owner>(o, "owner"); }
            else { Console.WriteLine("CreateOwner aborted!"); }
        }
        static void UpdateCar(RestService rest)
        {
            Car c = new Car();

            Console.WriteLine("To update a car in the database, please fill out the followings:");
            Console.Write("\nIn case you've changed your mind and dont want to update the car, give 'x' as an input here!");
            Console.Write("\nID of the car:");
            string input3 = "asd";
            bool wecool2 = false;
            bool changedMind2 = false;
            while (!wecool2)
            {
                input3 = Console.ReadLine();
                if (input3 == "x") { wecool2 = true; changedMind2 = true; }
                else
                {
                    if (intInputCheck(input3) == false) { Console.WriteLine("Error! Wrong input format, try again!"); }
                    else if (intInputCheck(input3) == true)
                    {
                        var car = rest.GetSingle<Car>($"car/{input3}");
                        if (car == null) { Console.WriteLine($"We could not find a car in the database with the ID of {input3}. Try again!"); }
                        else { c.Id = int.Parse(input3); wecool2 = true;  }
                    }
                }
            }
            bool changedMind = false;
            if (!changedMind2)
            {
                Console.Write("\nNew model of the car: ");
                c.Model = Console.ReadLine();
                Console.Write("\nNew basePrice of the car: ");
                string input = "x";
                while (!intInputCheck(input))
                {
                    input = Console.ReadLine();
                    if (intInputCheck(input) == false) { Console.WriteLine("Error! Wrong input format, try again!"); }
                }
                c.BasePrice = int.Parse(input);
                Console.Write("\nIn case you've changed your mind and dont want to update the car, give 'x' as an input here!");
                Console.Write("\nNew brand of the car (give the ID of the brand): ");

                string input2 = "asd";
                bool wecool = false;
                
                while (!wecool)
                {
                    input2 = Console.ReadLine();
                    if (input2 == "x") { wecool = true; changedMind = true; }
                    else
                    {
                        if (intInputCheck(input2) == false) { Console.WriteLine("Error! Wrong input format, try again!"); }
                        else if (intInputCheck(input2) == true)
                        {
                            var brand = rest.GetSingle<Brand>($"brand/{input2}");
                            if (brand == null) { Console.WriteLine($"We could not find a brand in the database with the ID of {input2}. Try again!"); }
                            else { c.BrandId = int.Parse(input2); wecool = true; Console.WriteLine("Car has been updated!"); }
                        }
                    }
                }
            }
            if (changedMind || changedMind2) { Console.WriteLine("Car update aborted!"); }
            else { rest.Put<Car>(c, "car"); }
        }
        static void UpdateBrand(RestService rest)
        {
            Brand b = new Brand();
            Console.WriteLine("To update a brand in the database, please fill out the followings:");
            Console.Write("\nIn case you've changed your mind and dont want to update the brand, give 'x' as an input here!");
            Console.Write("\nID of the brand:");
            string input = "asd";
            bool wecool = false;
            bool changedMind = false;
            while (!wecool)
            {
                input = Console.ReadLine();
                if (input == "x") { wecool = true; changedMind = true; }
                else
                {
                    if (intInputCheck(input) == false) { Console.WriteLine("Error! Wrong input format, try again!"); }
                    else if (intInputCheck(input) == true)
                    {
                        var brand = rest.GetSingle<Brand>($"brand/{input}");
                        if (brand == null) { Console.WriteLine($"We could not find a brand in the database with the ID of {input}. Try again!"); }
                        else { b.Id = int.Parse(input); wecool = true; }
                    }
                }
            }
            Console.Write("\nNew Name of the brand: ");
            b.Name = Console.ReadLine();
            if (changedMind) { Console.WriteLine("Brand update aborted!"); }
            else { rest.Put<Brand>(b, "brand"); }
        }
        static void UpdateOwner(RestService rest)
        {
            Owner o = new Owner();

            Console.WriteLine("To update an owner in the database, please fill out the followings:");
            Console.Write("\nIn case you've changed your mind and dont want to update the owner, give 'x' as an input here!");
            Console.Write("\nID of the owner:");
            string input3 = "asd";
            bool wecool2 = false;
            bool changedMind2 = false;
            while (!wecool2)
            {
                input3 = Console.ReadLine();
                if (input3 == "x") { wecool2 = true; changedMind2 = true; }
                else
                {
                    if (intInputCheck(input3) == false) { Console.WriteLine("Error! Wrong input format, try again!"); }
                    else if (intInputCheck(input3) == true)
                    {
                        var owner = rest.GetSingle<Owner>($"owner/{input3}");
                        if (owner == null) { Console.WriteLine($"We could not find an owner in the database with the ID of {input3}. Try again!"); }
                        else { o.Id = int.Parse(input3); wecool2 = true; }
                    }
                }
            }
            bool changedMind = false;
            if (!changedMind2)
            {
                Console.Write("\nNew LastName of the owner: ");
                o.LastName = Console.ReadLine();
                Console.Write("\nNew FirstName of the owner: ");
                o.FirstName = Console.ReadLine();


                Console.Write("\nNew age of the owner: ");
                string input = "x";
                while (!intInputCheck(input))
                {
                    input = Console.ReadLine();
                    if (intInputCheck(input) == false) { Console.WriteLine("Error! Wrong input format, try again!"); }
                }
                o.Age = int.Parse(input);

                Console.Write("\nIn case you've changed your mind and dont want to update the owner, give 'x' as an input here!");
                Console.Write("\nNew car of the owner (give the ID of the car): ");

                string input2 = "asd";
                bool wecool = false;

                while (!wecool)
                {
                    input2 = Console.ReadLine();
                    if (input2 == "x") { wecool = true; changedMind = true; }
                    else
                    {
                        if (intInputCheck(input2) == false) { Console.WriteLine("Error! Wrong input format, try again!"); }
                        else if (intInputCheck(input2) == true)
                        {
                            var car = rest.GetSingle<Car>($"car/{input2}");
                            if (car == null) { Console.WriteLine($"We could not find a car in the database with the ID of {input2}. Try again!"); }
                            else { o.CarId = int.Parse(input2); wecool = true; Console.WriteLine("Owner has been updated!"); }
                        }
                    }
                }
            }
            if (changedMind || changedMind2) { Console.WriteLine("Owner update aborted!"); }
            else { rest.Put<Owner>(o, "owner"); }
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
                    case 10:
                        CreateCar(rest);
                        break;
                    case 11:
                        CreateBrand(rest);
                        break;
                    case 12:
                        CreateOwner(rest);
                        break;
                    case 13:
                        UpdateCar(rest);
                        break;
                    case 14:
                        UpdateBrand(rest);
                        break;
                    case 15:
                        UpdateOwner(rest);
                        break;
                    default:
                        break;
                }
                //Would you like to go back to the menu or exit the app
                Console.WriteLine("\nTo get back to the menu, please press 1. To exit the application please press 2.");
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
            Console.WriteLine("[13] UpdateCar");
            Console.WriteLine("[14] UpdateBrand");
            Console.WriteLine("[15] UpdateOwner");
            Console.WriteLine("[16] ModelNamesWithBrand");
            Console.WriteLine("[17] AVGPriceByBrands");
            Console.WriteLine("[18] CountCarsByBrand");
            Console.WriteLine("[19] SeniorOwners");
            Console.WriteLine("[20] ExpensiveCarOwners");
            Console.WriteLine("[21] MAXPriceByBrands");
            int input = int.Parse(Console.ReadLine());
            Console.Clear();
            return input;
        }
    }
}
