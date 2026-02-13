using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicule_System_Management.Vehicule
{
    internal class Motorcycle: Vehicule
    {
        public Motorcycle(string make, string model, RegistrationInfo registrationInfo, int year) : base(make, model,VehiculeType.Motorcycle, registrationInfo, year)
        {
        }


        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("Motorcycle Details:");
        }
    }
}
