using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicule_System_Management
{
    internal struct RegistrationInfo
    {
        public string RegistrationNumber {  get; set; }
        public DateTime RegistrationDate { get; set; }

        public RegistrationInfo (string registrationNumber, DateTime registrationDate)
        {
            RegistrationNumber = registrationNumber;
            RegistrationDate = registrationDate;
        }
    }


}
