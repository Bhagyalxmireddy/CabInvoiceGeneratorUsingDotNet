using NUnit.Framework;
using CabInvoiceGenerater;

namespace InvoiceGeneratorTest
{
    public class Tests
    {

        InvoicGenerator invoicGenerator;
        [SetUp]
        public void Setup()
        {
            invoicGenerator = new InvoicGenerator();
        }

        [Test]
        public void givenDistanceAndTime_ShouldCalculateTheFare()
        {
            double distance = 2.0;
            int time = 5;
            double result = invoicGenerator.CalculateFare(distance, time);
            Assert.AreEqual(result, 25);
        }
        [Test]
        public void givenMinDistnceAndMinTime_ShouldReturnMinFare()
        {
            double distance = 0.2;
            int time = 1;
            double result = invoicGenerator.CalculateFare(distance, time);
            Assert.AreEqual(result, 5);
        }
        [Test]
        public void givenMultipleRides_ShouldcalculateTheTotalFare()
        {
            Ride[] rides = { new Ride(2.0, 5),
                             new Ride(0.1, 1),
                            };
            double result = invoicGenerator.calculateTotalFare(rides);
            Assert.AreEqual(30, result);
        }
    }
}