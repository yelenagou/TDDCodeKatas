using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using DataService;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging;


namespace TestDataService
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var svc = new CalculationService(new NullLogger<CalculationService>());
            var result = svc.AddTwoPositiveNumbers(3, 5);
            Assert.AreEqual(8, result, "Result is not correct");
        }
        [Test]
        public void Test2()
        {
            var serviceProvider = new ServiceCollection()
                    .AddLogging()
                    .BuildServiceProvider();
            var svcLogger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<CalculationService>();
            var svc = new CalculationService(svcLogger);
            var result = svc.AddTwoPositiveNumbers(2,3);
            Assert.AreEqual(5, result);

           
        }
    }
}