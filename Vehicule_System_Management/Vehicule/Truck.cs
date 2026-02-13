using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicule_System_Management.Vehicule
{
    internal class Truck : Vehicule
    {
      
            public Truck(string make, string model, RegistrationInfo registrationInfo, int year) : base(make, model, VehiculeType.Truck, registrationInfo, year)
            {
            }

            public override void DisplayInfo()
            {
                base.DisplayInfo();
                Console.WriteLine("Truck Details:");
            }
       
    }
}
