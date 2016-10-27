using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    class Vehicle
    {

        public string REGNR { get; set; }
        public string Color { get; set; }
        public int Wheels { get; set; }
        public string type{ get; set; }

        public override string ToString()
        {
            return (this.type + " : " + this.REGNR + " : " + this.Color + " : Number of Wheels " + this.Wheels);
        }
    }


}
