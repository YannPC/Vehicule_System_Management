using System;
using System.IO;
using Xunit;
using Vehicule_System_Management;
using Vehicule_System_Management.Vehicule;

namespace Vehicule_System_Management.Vehicule
{
    public class VehiculeTests
    {
        [Fact]
        public void Vehicule_DisplayInfo_WritesExpectedOutput()
        {
            // Arrange
            var reg = new RegistrationInfo("KEMAYRSD", new DateTime(2001, 1, 1));
            var v = new Vehicule("Toyota", "Corolla", VehiculeType.Car, reg, 2001);
            v.OwnerName = "Alice";

            using var sw = new StringWriter();
            var originalOut = Console.Out;
            Console.SetOut(sw);

            try
            {
                // Act
                v.DisplayInfo();
            }
            finally
            {
                // restore
                Console.SetOut(originalOut);
            }

            // Assert
            string output = sw.ToString();
            Assert.Contains("Owner Name: Alice", output);
            Assert.Contains("Make: Toyota", output);
            Assert.Contains("Model: Corolla", output);
            Assert.Contains("Type: Car", output);
            Assert.Contains("Year: 2001", output);
            Assert.Contains("KEMAYRSD", output);
            Assert.Contains("2001", output); // registration date appears
        }

        [Fact]
        public void Vehicule_Constructor_SetsProperties()
        {
            // Arrange
            var reg = new RegistrationInfo("REG123", new DateTime(2020, 5, 5));

            // Act
            var v = new Vehicule("Ford", "F-150", VehiculeType.Truck, reg, 2020);

            // Assert
            Assert.Equal("Ford", v.Make);
            Assert.Equal("F-150", v.Model);
            Assert.Equal(VehiculeType.Truck, v.Type);
            Assert.Equal(2020, v.Year);
            Assert.Equal("REG123", v.RegistrationInfo.RegistrationNumber);
            Assert.Equal(new DateTime(2020, 5, 5), v.RegistrationInfo.RegistrationDate);
        }

        public class ProgramTests
        {
            [Fact]
            public void AddVehicle_ValidInput_AddsVehicleAndWritesSuccess()
            {
                // Arrange
                var inputText = string.Join(Environment.NewLine, new[]
                {
                "Car",               // type
                "Toyota",            // make
                "Corolla",           // model
                "2001",              // year
                "KEMAYRSD",          // reg number
                "2001-01-01",        // reg date
                "Alice"              // owner
            }) + Environment.NewLine; // ensure final newline

                using var input = new StringReader(inputText);
                using var output = new StringWriter();
                var vehicles = new List<Vehicule>();

                //// Act
               AddVehicle(vehicles, input, output);
                var outStr = output.ToString();

                // Assert
                Assert.Contains("Enter vehicle type", outStr);
                Assert.Contains("Vehicle added successfully!", outStr);
                Assert.Single(vehicles);
                Assert.Equal("Toyota", vehicles[0].Make);
                Assert.Equal("Corolla", vehicles[0].Model);
                Assert.Equal(VehiculeType.Car, vehicles[0].Type);
                Assert.Equal("Alice", vehicles[0].OwnerName);
                Assert.Equal("KEMAYRSD", vehicles[0].RegistrationInfo.RegistrationNumber);
            }

            private void AddVehicle(List<Vehicule> vehicles, StringReader input, StringWriter output)
            {
                throw new NotImplementedException();
            }
        }

        [Fact]
        public void MainMenu_AddThenDisplayThenExit_IntegrationFlow()
        {
            // Arrange: menu choice 1 (add), vehicle inputs, then 2 (display), then 3 (exit)
            var inputs = new[]
            {
                "1",                // menu: Add Vehicle
                "Truck",            // type
                "MakeX",            // make
                "ModelY",           // model
                "2022",             // year
                "REG01",            // reg number
                "2022-01-01",       // reg date
                "OwnerZ",           // owner
                "2",                // menu: Display All Vehicles
                "3"                 // menu: Exit
            };
            var inputText = string.Join(Environment.NewLine, inputs) + Environment.NewLine;
            using var input = new StringReader(inputText);
            using var output = new StringWriter();
            var vehicles = new List<Vehicule>();

            // Act
           MainMenu(input, output, vehicles);
            var outStr = output.ToString();

            // Assert menu flow and results
            Assert.Contains("Vehicle Management System", outStr);
            Assert.Contains("Enter vehicle type", outStr);
            Assert.Contains("Vehicle added successfully!", outStr);
            Assert.Contains("Make: MakeX", outStr);
            Assert.Single(vehicles);
            Assert.Equal("OwnerZ", vehicles[0].OwnerName);
        }

        private void MainMenu(StringReader input, StringWriter output, List<Vehicule> vehicles)
        {
            throw new NotImplementedException();
        }
    }

}

