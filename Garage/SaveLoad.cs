using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Garage
{
    class SaveLoad
    {
        public void PrintVehiclesToFile(List<Vehicle> list, string thefile)
        {
            if (!Directory.Exists(thefile))
            {
                Directory.CreateDirectory(@"../TestFolder");
            }
            if (File.Exists(thefile))
            {
                File.Delete(thefile);
            }
            else if (!File.Exists(thefile))
            {

                var myFile = File.Create(thefile);
                myFile.Close();

            }
            string[] tempStringArr = new string[list.Count];
            
                for (int i = 0; i < list.Count; i++)
                {
                    tempStringArr[i] = list[i].ToString();
                }
            
            System.IO.File.WriteAllLines(thefile, tempStringArr);
        }

        public List<Vehicle> ReadVehicleFromFile(string thefile)
        {

            if (!Directory.Exists(thefile))
            {
                Directory.CreateDirectory(@"../TestFolder");
            }
            if (!File.Exists(thefile))
            {
                var myFile = File.Create(thefile);
                myFile.Close();
                
            }
            string[] lines = System.IO.File.ReadAllLines(thefile);
            //Vehicle tempV = new Vehicle;
            List<Vehicle> tempList = new List<Vehicle>();
            char[] MyChar = { 'N','u','m','b','e','r',' ','o','f','W','h','l','s'};
            for (int i = 0; i < lines.Length; i = i + 1)
            {
                string[] temp = lines[i].Split(':');
                string type = temp[0].Trim();
                string regnr = temp[1].Trim();
                string color = temp[2].Trim();
                int wheels = int.Parse(temp[3].Trim(MyChar));
                if (type == "Car")
                    {
                        tempList.Add(new Car() { REGNR = regnr.ToUpper(), Color = color.ToUpper(), Wheels = wheels });
                    }
                    else if (type == "Buss")
                    {
                        tempList.Add(new Buss() { REGNR = regnr.ToUpper(), Color = color.ToUpper(), Wheels = wheels });
                    }
                    else if (type == "Boat")
                    {
                        tempList.Add(new Boat() { REGNR = regnr.ToUpper(), Color = color.ToUpper(), Wheels = wheels });
                    }
                    else if (type == "Motorcycle")
                    {
                        tempList.Add(new Motorcycle() { REGNR = regnr.ToUpper(), Color = color.ToUpper(), Wheels = wheels });
                    }
                    else if (type == "Airplane")
                    {
                        tempList.Add(new Airplane() { REGNR = regnr.ToUpper(), Color = color.ToUpper(), Wheels = wheels });
                    }
                //tempList.Add(tempV.);// int.Parse(lines[i]);
            }

            return tempList;
        }

    }
}
