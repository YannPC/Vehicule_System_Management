using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicule_System_Management.Vehicule
{
    // Remove or rename this class definition if another 'Vehicule' class exists in the same namespace.
    // The CS0101 error means there are two or more 'Vehicule' class definitions in the 'Vehicule_System_Management' namespace.
    // To fix, ensure only one 'Vehicule' class exists in this namespace.
    // If you need both, rename one of them or move it to a different namespace.

    public class Vehicule
    {
        private string model;
        private string make;
        private int year;
        private VehiculeType type;
        private RegistrationInfo registrationInfo;

        public string OwnerName { get; set; }
        public string Make
        {
            get { return make; }
            set { make = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public VehiculeType Type
        {

            get { return type; }
            set { type = value; }
        }

        public RegistrationInfo RegistrationInfo
        {
            get { return registrationInfo; }
            set { registrationInfo = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public Vehicule(string make, string model, VehiculeType type, RegistrationInfo
        registrationInfo, int year)
        {

            Make = make;
            Model = model;
            Type = type;
            RegistrationInfo = registrationInfo;
            Year = year;
        }

        public virtual void DisplayInfo()

        {
            Console.WriteLine($"Owner Name: { OwnerName ?? " N / A " }");
            Console.WriteLine($"Make: {Make}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine($"Year: {Year}");
            Console.WriteLine($" Registration Number:{RegistrationInfo.RegistrationNumber}");
           
            Console.WriteLine($"Registration Date: { RegistrationInfo.RegistrationDate}"); 
            

        }
    }
}

