using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    class Program
    {
        static void Main(string[] args)
        {
            Garage1<Vehicle> FirstGarage = new Garage1<Vehicle>(10);


            while (true)
            {
                Console.Clear();
                Console.WriteLine("What do you want to do? Anser with a number corresponding to one of the things below.");
                Console.WriteLine("1. Get all vehicles in the garage\n2. How meny of each vehicle type is there in the garage\n3. Add a new vehicle to the garage\n4. Remove a vehicle from the garage\n5. Search for a vehicle based on a REG-NR\n6. Seach for vehicles \n0. Exit Program");
                string input = Console.ReadLine();
                char nav = new char();
                try
                {
                    nav = input[0];
                }
                catch
                {
                    Console.WriteLine("Please enter a valid input (1,2,3,4,5 or 0)");

                }
                //string value = input.Substring(1);

                switch (nav)
                {
                    case '1':
                        IEnumerable<Vehicle> temp = FirstGarage.getAllVehiclesInGarage();
                        Console.Clear();
                        foreach (var item in temp)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        Console.ReadKey();
                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine(FirstGarage.GetAlltypesOfVehiclesInGarage());
                        Console.ReadKey();
                        break;
                    case '3':
                        Console.Clear();
                        Console.Write("What type of Vehicle do you want to add.\n (Car, Buss, Boat, Motorcycle or Airplane): ");
                        string veicle = Console.ReadLine();
                        string regnr;
                        string color;
                        int wheels;
                        if (veicle == "Car" || veicle == "Buss" || veicle == "Boat" || veicle == "Motorcycle" || veicle == "Airplane")
                        {
                            Console.Write("What is the REG-NR of the Vehicle: ");
                            regnr = Console.ReadLine().ToUpper();
                            if (regnr == "" || regnr == null)
                            {
                                Console.WriteLine("You have enterd something wrong sending you back to main meny");
                                Console.ReadKey();
                                break;
                            }
                            Console.Write("What is the Color of the Vehicle: ");
                            color = Console.ReadLine().ToUpper();
                            Console.Write("What is the number of Wheels of the Vehicle: ");
                            try
                            {
                                wheels = int.Parse(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("You have enterd something wrong sending you back to main meny");
                                Console.ReadKey();
                                break;                                
                            }

                            string temp2 = FirstGarage.addVeicle(veicle, regnr, color, wheels);
                            if (temp2=="true")
                            {
                                Console.WriteLine("Vehicle Added");
                            }
                            else if (temp2 == "null")
                            {
                                Console.WriteLine("That Vehicle is already in the garage");
                            }
                            else
                            {
                                Console.WriteLine("Garage is full could not add Vehicle");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You have enterd something wrong sending you back to main meny");
                        }
                        Console.ReadKey();
                        break;
                    case '4':
                        Console.Clear();
                        Console.Write("What is the REG-NR of the Vehicle you want to remove from the garage?: ");
                        bool temp3 = FirstGarage.removeVehicleFromGarage(Console.ReadLine());
                        if (temp3)
                        {
                            Console.Write("The Vehicle has been sucsessfully removed.");
                        }
                        else
                        {
                            Console.Write("The Vehicle does not exist in the garage.");
                        }
                        Console.ReadKey();
                        break;
                    case '5':
                        Console.Clear();
                        Console.Write("Search for a Vehicle with it's Reg-nr: ");
                        Console.WriteLine(FirstGarage.SearchForVehicleWithRegnumber(Console.ReadLine()));
                        
                        Console.ReadKey();

                        break;
                    case '6':
                        Console.Clear();
                        Console.Write("You can Search for type, Reg-Nr, Color or Amount of wheels: ");                       
                        string cont = Console.ReadLine();                       
                        IEnumerable<Vehicle> temp5 = FirstGarage.Search(cont);
                        if (temp5.Count() == 0)
                        {
                            Console.WriteLine("The Seach did not find enything.");
                        }
                        foreach (var item in temp5)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        Console.ReadKey();
                        break;
                    case '0':
                        FirstGarage.Save();
                        return;
                    default:
                        {
                            Console.WriteLine("Please enter some valid input (1,2,3,4,5 or 0)");
                            break;
                        }
                }
            }
        }
    }
}
