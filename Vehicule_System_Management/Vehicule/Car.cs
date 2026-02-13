using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicule_System_Management.Vehicule
{
    internal class Car : Vehicule
    {
        public Car(string make, string model, RegistrationInfo registrationInfo, int year) : base(make, model, VehiculeType.Car, registrationInfo, year)
        {
        }
  

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("Car Details:");
        }
    } 
}
