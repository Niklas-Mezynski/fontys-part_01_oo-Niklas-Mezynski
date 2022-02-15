using System;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using oo_part_1;
using oo_part_1.App;

namespace UnitTests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestCar()
    {
        Car car = new Car(12345.67, "NE NM 2001", 200, 5);
        Assert.AreEqual(0, car.Id);
        Assert.AreEqual(12345.67, car.Price);
        Assert.AreEqual("NE NM 2001", car.LicencePlate);
        Assert.AreEqual(200, car.TopSpeed);
        Assert.AreEqual(5, car.NoOfSeats);
    }
    
    [TestMethod]
    public void TestTruck()
    {
        Truck truck = new Truck(12345.67, "NE NM 2001", 200, 500);
        Assert.AreEqual(0, truck.Id);
        Assert.AreEqual(12345.67, truck.Price);
        Assert.AreEqual("NE NM 2001", truck.LicencePlate);
        Assert.AreEqual(200, truck.TopSpeed);
        Assert.AreEqual(500, truck.MaxTrailerWeight);
    }
    
    [TestMethod]
    public void TestMotorcycle()
    {
        Motorcycle motorcycle = new Motorcycle(12345.67, "NE NM 2001", 200, 9);
        Assert.AreEqual(0, motorcycle.Id);
        Assert.AreEqual(12345.67, motorcycle.Price);
        Assert.AreEqual("NE NM 2001", motorcycle.LicencePlate);
        Assert.AreEqual(200, motorcycle.TopSpeed);
        Assert.AreEqual(9, motorcycle.LevelOfCoolness);
    }
    
    [TestMethod]
    public void TestVehicleManager()
    {
        var vehicleManager = new VehicleManager();
        Car car = new Car(1000, "NE NM 2001", 150, 5);
        vehicleManager.addCar(1000, "NE NM 2001", 150, 5);
        vehicleManager.printAllVehicles();
        Assert.AreEqual(car, vehicleManager.searchVehicleById(0));
        Assert.AreEqual(car, vehicleManager.searchVehicleByLicencePlate("NE NM 2001"));
    }
    
    [TestMethod]
    public void TestPriceIncrease()
    {
        var vehicleManager = new VehicleManager();
        var addCar = vehicleManager.addCar(1000, "NE NM 2001", 150, 5);
        vehicleManager.increasePriceOfAllVehicles(100);
        Assert.AreEqual(2000, addCar.Price);
    }
}