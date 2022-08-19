namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;
        private string make = "VW";
        private string model = "Golf";
        private double fuelConsumption = 5.5;
        private double fuelCapacity = 63.0;

        [SetUp]
        public void SetUp()
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
        }

        [Test]
        public void When_PropertiesProvided_ShouldBeSetCorrectly()
        {
            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void When_MakeIsEmptyOrNull_ShouldThrowException(string make)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void When_ModelIsEmptyOrNull_ShouldThrowException(string model)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void When_FuelConsumptionIsNegativeOrZero_ShouldThrowException(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void When_FuelCapacityIsNegativeOrZero_ShouldThrowException(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void When_RefuelValueIsNegativeOrZero_ShouldThrowException(double fuel)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(fuel));
        }

        [Test]
        [TestCase(10)]
        public void When_RefuelCarFuelAmount_ShouldBeChanged(double fuel)
        {
            car.Refuel(fuel);
            Assert.That(car.FuelAmount, Is.Not.EqualTo(0));
        }

        [Test]
        public void When_RefuelCarWithMoreFuelThanFuelCapacity_ShouldSetFuelAmountToFuelCapacity()
        {
            car.Refuel(70);
            Assert.That(car.FuelAmount, Is.EqualTo(car.FuelCapacity));
        }

        [Test]
        [TestCase(10)]
        public void When_FuelIsNotEnough_ShouldThrowException(double distance)
        {
            Assert.Throws<InvalidOperationException>(() => car.Drive(distance));
        }

        [Test]
        [TestCase(100)]
        public void When_CarIsDriveFuelAmount_ShouldDecrease(double distance)
        {
            car.Refuel(63);
            car.Drive(distance);
            Assert.That(car.FuelAmount, Is.EqualTo(57.5));

        }
    }
}
