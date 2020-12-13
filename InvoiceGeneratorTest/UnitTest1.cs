using NUnit.Framework;
using CabInvoiceGenerater;
using System.Collections.Generic;

namespace InvoiceGeneratorTest
{
    public class Tests
    {

        InvoicGenerator invoicGenerator;
        List<Ride> rides;

        [SetUp]
        public void Setup()
        {
            invoicGenerator = new InvoicGenerator();
        }

        [Test]
        public void givenDistanceAndTime_ShouldRetuenNormalCalculateTheFare()
        {
            double distance = 2.0;
            int time = 5;
            invoicGenerator = new InvoicGenerator(RideType.NORMAL);
            double result = invoicGenerator.CalculateFare(new Ride( distance, time));
            Assert.AreEqual(result, 25);
        }
        [Test]
        public void givenDistanceAndTime_ShouldReturnPremiumCalculateTheFare()
        {
            double distance = 2.0;
            int time = 5;
            invoicGenerator = new InvoicGenerator(RideType.PREMIUM);
            double result = invoicGenerator.CalculateFare(new Ride(distance, time));
            Assert.AreEqual(result, 40);
        }
        [Test]
        public void givenMinDistnceAndMinTime_ShouldReturnMinFare()
        {
            double distance = 0.2;
            int time = 1;
            double result = invoicGenerator.CalculateFare(new Ride(distance, time));
            Assert.AreEqual(result, 5);
        }
        [Test]
        public void givenInvalidDistnceAndValidMinTime_ShouldReturnException()
        {
            double distance = -3;
            int time = 10;
            var result = Assert.Throws<InvoiceException>(() =>  invoicGenerator.CalculateFare(new Ride(distance, time)));
            Assert.AreEqual(InvoiceException.ExceptionType.INVALID_DISTANCE, result.type);
        }
        [Test]
        public void givenvalidDistnceAndInValidMinTime_ShouldReturnException()
        {
            double distance = 3;
            int time = -10;
            var result = Assert.Throws<InvoiceException>(() => invoicGenerator.CalculateFare(new Ride(distance, time)));
            Assert.AreEqual(InvoiceException.ExceptionType.INVALID_TIME, result.type);
        }

        [Test]
        public void givenMultipleRides_ShouldcalculateTheTotalFare()
        {
            rides =new List<Ride> { new Ride(2.0, 5),
                             new Ride(0.2, 1),
                            };
            double result = invoicGenerator.TotalFareForMultipleRides(rides);
            Assert.AreEqual(30, result);
        }
        [Test]
        public void givenNullRides_ShouldReturnException()
        {
            rides = new List<Ride> { new Ride(5, 20), null, new Ride(2, 10) };
            var result = Assert.Throws<InvoiceException>(() => invoicGenerator.TotalFareForMultipleRides(rides));
            Assert.AreEqual(InvoiceException.ExceptionType.NULL_RIDES, result.type);
        }
        [Test]
        public void givenUserId_WhenPresent_ShouldReturn_InvoiceSummary()
        {
            rides = new List<Ride> { new Ride(5, 20), new Ride(3, 15), new Ride(2, 10) };
            double expectedFare = 145;
            int expectedRides = 3;
            double expectedAverage = expectedFare / expectedRides;

            invoicGenerator.AddRides(1, rides);
            InvoiceService data = invoicGenerator.GetUserInvoice(1);
            Assert.IsTrue(data.numOfRides == expectedRides && data.totalFare == expectedFare && data.avgFare == expectedAverage);
        }
        [Test]
        public void GivenUserId_WhenAbsent_Should_Return_CabInvoiceException()
        {
            invoicGenerator = new InvoicGenerator(RideType.NORMAL);

            var result = Assert.Throws<InvoiceException>(() => invoicGenerator.GetUserInvoice(1));

            Assert.AreEqual(InvoiceException.ExceptionType.INVALID_USER_ID, result.type);
        }
    }
}