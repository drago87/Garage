using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    class Garage
    {
        SaveLoad saveLoad = new SaveLoad();
        List<Vehicle> fordon = new List<Vehicle>();
        int maxNumberOfVehicles;
        

        public Garage(int GarageSice)
        {
            maxNumberOfVehicles = GarageSice;
            try
            {
                fordon = new List<Vehicle>(saveLoad.ReadVehicleFromFile(@"../TestFolder\fordon.txt"));
            }
            catch
            {
                
            }
            
            //addVeicle("Car", "SOU510", "Gray", 4);
                //REGNR = "SOU510", Color = "Gray", Wheels = 4 });
                //name_list2 = new List<string>(name_list1);
        }

        public void Save()
        {
            saveLoad.PrintVehiclesToFile(fordon, @"../TestFolder\fordon.txt");
        }

        public string addVeicle(string type, string regnr, string color, int wheels)
        {
            if (!isGarageFull())
            {
                if (!DoesVehicleWithRegnumberExist(regnr))
                {
                    if (type == "Car")
                    {
                        fordon.Add(new Car() { REGNR = regnr.ToUpper(), Color = color.ToUpper(), Wheels = wheels });
                    }
                    else if (type == "Buss")
                    {
                        fordon.Add(new Buss() { REGNR = regnr.ToUpper(), Color = color.ToUpper(), Wheels = wheels });
                    }
                    else if (type == "Boat")
                    {
                        fordon.Add(new Boat() { REGNR = regnr.ToUpper(), Color = color.ToUpper(), Wheels = wheels });
                    }
                    else if (type == "Motorcycle")
                    {
                        fordon.Add(new Motorcycle() { REGNR = regnr.ToUpper(), Color = color.ToUpper(), Wheels = wheels });
                    }
                    else if (type == "Airplane")
                    {
                        fordon.Add(new Airplane() { REGNR = regnr.ToUpper(), Color = color.ToUpper(), Wheels = wheels });
                    }

                    return "true";
                }

                return "null";
            }
            else
            {
                return "false";
            }

        }

        
        public bool isGarageFull()
        {
            if (fordon.Count < maxNumberOfVehicles)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public IEnumerable<Vehicle> getAllVehiclesInGarage()
        {
            IEnumerable<Vehicle> Quarry = from v in fordon
                                          select v;
            return Quarry;
        }
        
        public string GetAlltypesOfVehiclesInGarage()
        {
            IEnumerable<Vehicle> Quarry = from v in fordon
                                          orderby v.type
                                          select v;
            int numberofCars = 0;
            int numberofBoats = 0;
            int numberofBusses = 0;
            int numberofMotorcycles = 0;
            int numberofAirplanes = 0;
            foreach (var s in Quarry)
            {
                if (s.type=="Car")
                {
                    numberofCars = numberofCars +1;
                }
                else if (s.type=="Boat")
                {
                    numberofBoats = numberofBoats + 1;
                }
                else if (s.type == "Buss")
                {
                    numberofBusses = numberofBusses + 1;
                }
                else if (s.type == "Motorcycle")
                {
                    numberofMotorcycles = numberofMotorcycles + 1;
                }
                else if (s.type == "Airplane")
                {
                    numberofAirplanes = numberofAirplanes + 1;
                }
            }

            return "Cars: " + numberofCars + "\nBoats: " + numberofBoats + "\nBusses: " + numberofBusses + "\nMotorcycles: " + numberofMotorcycles + "\nAirplanes: " + numberofAirplanes;

        }

        public bool removeVehicleFromGarage(string regnumber)
        {
            regnumber = regnumber.ToUpper();
            int count = fordon.Count();
            try
            {
                var temp = (from v in fordon
                            where v.REGNR == regnumber
                            select v).First();
                fordon.Remove(temp);
            }
            catch 
            {
                return false;
            }
            

            
            int count2 = fordon.Count();
            if (count == count2)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
        
        public string SearchForVehicleWithRegnumber(string regnumber)
        {
            regnumber = regnumber.ToUpper();
            try
            {
                var temp = (from v in fordon
                            where v.REGNR == regnumber
                            select v).First();

                return temp.ToString();
            }
            catch 
            {

                return "That Vehicle does not exist.";
            }
            
       
        }
        public IEnumerable<Vehicle> Search(string what)
        {
            
            try
            {
                int temp = int.Parse(what);
                return from v in fordon
                       where v.Wheels == temp
                       select v;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
                return from v in fordon
                       where v.type.ToUpper() == what.ToUpper() || v.REGNR == what.ToUpper() || v.Color == what.ToUpper()
                       select v;                
            }
            
            
            
        }
        private bool DoesVehicleWithRegnumberExist(string regnumber)
        {
            regnumber = regnumber.ToUpper();
            try
            {
                var temp = (from v in fordon
                            where v.REGNR == regnumber
                            select v).First();

                return true;
            }
            catch 
            {
                return false;
            }
            

        }
    }
}
