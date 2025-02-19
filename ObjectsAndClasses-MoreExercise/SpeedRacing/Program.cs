﻿namespace SpeedRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             Your task is to implement a program that keeps track of cars and their fuel 
            and supports methods for moving the cars. 
            Define a class Car that keeps a track of a car's model, fuel amount,
            fuel consumption per kilometer and traveled 
            distance. A Car's model is unique - there will never be 2 cars with the same model.
            On the first line of the input, you will receive a number N – the number of cars you need to track.
            On each of the next N lines, you will receive information about cars in the following format
            "<Model> <FuelAmount> <FuelConsumptionFor1km>".
            All cars start at 0 kilometers traveled.
            After the N lines, until the command "End" is received, you will receive commands in the following format 
            "Drive <CarModel> <amountOfKm>". 
            Implement a method in the Car class to calculate whether or not a car can move that distance.
            If it can, the car's fuel amount should be reduced by the amount of used fuel and its traveled distance
            should be increased by the number of the traveled kilometers. 
            Otherwise, the car should not move (its fuel amount and the traveled distance should stay the same)
            and you should print on the console "Insufficient fuel for the drive". 
            After the "End" command is received, print each car, its current fuel amount and the traveled distance 
            in the format "<Model> <fuelAmount> <distanceTraveled>". Print the fuel amount rounded to two digits 
            after the decimal separator.
            */
           
                int nuberOfCar = int.Parse(Console.ReadLine());
                List<Car> cars = new List<Car>();
                for (int i = 0; i < nuberOfCar; i++)
                {
                    string[] input = Console.ReadLine().Split();
                    string model = input[0];
                    double fuelAmount = double.Parse(input[1]);
                    double fuelByKm = double.Parse(input[2]);

                    cars.Add(new Car(model, fuelAmount, fuelByKm));
                }
                string command = "";
                while ((command = Console.ReadLine()) != "End")
                {
                    string[] action = command.Split().ToArray();
                    string model = action[1];
                    double distance = double.Parse(action[2]);
                    cars.Find(m => m.Model == model).MoveCar(distance);
                }
                Console.WriteLine(string.Join("\n", cars));

        }
         
    }
    class Car
    {
        public Car(string model, double fuelAmount, double fuelByKm)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionFor1km = fuelByKm;
            Distance = 0;
        }
        public void MoveCar(double km)
        {
            if (FuelConsumptionFor1km * km <= FuelAmount)
            {
                Distance += km;
                FuelAmount -= FuelConsumptionFor1km * km;
            }
            else { Console.WriteLine("Insufficient fuel for the drive"); }

        }
        public override string ToString()
        {
            return $"{Model} {FuelAmount:f2} {Distance}";
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }

        public double FuelConsumptionFor1km { get; set; }

        public double Distance { get; set; }
    }
}   
        
    
