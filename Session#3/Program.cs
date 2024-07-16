using System;

namespace MyFirstProgram;
class Program
{
    static void Main(string[] args)
    {
        Car car = new Car();
        // Vehicle vehicle = new Vehicle(); // Error: Cannot create an instance of the abstract type or interface 'Vehicle'

        var tuple = ("Youse", "Computer Engineering");
        Console.WriteLine($"Name: {tuple.Item1}, Department: {tuple.Item2}");
        // var tuple = (name: "Youse", department: "Computer Engineering");
        // Console.WriteLine($"Name: {tuple.name}, Department: {tuple.department}");

        (string name, string department) = tuple;
        Console.WriteLine($"Name: {name}, Department: {department}");

    }
}
abstract class Vehicle
{
    public int speed = 0;

    public void go()
    {
        Console.WriteLine("This vehicle is moving!");
    }
}
sealed class Car : Vehicle
{
    public int wheels = 4;
    int maxSpeed = 500;
}

// class CarChild : Car  // 'CarChild': cannot derive from sealed type 'Car'
// {
//     public int wheels = 4;
//     int maxSpeed = 300;
// }
class Bicycle : Vehicle
{
    public int wheels = 2;
    int maxSpeed = 50;
}
class Boat : Vehicle
{
    public int wheels = 0;
    int maxSpeed = 100;
}
