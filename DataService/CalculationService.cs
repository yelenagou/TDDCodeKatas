using System;
using Microsoft.Extensions.Logging;

namespace DataService
{
    public interface ICalculationService
    {
        int AddTwoPositiveNumbers(int a, int b);
    }

    public class CalculationService : ICalculationService
    {
        private readonly ILogger<CalculationService> _logger;
        public CalculationService(ILogger<CalculationService> logger)
        {
            _logger = logger;
        }

        public int AddTwoPositiveNumbers(int a, int b)
        {
            if (a <= 0 || b <= 0)
            {
                _logger.LogError("Arguments should both be positive");
                return 0;
            }
            _logger.LogInformation($"Adding {a} and {b}");
            return a + b;
        }
    }
}
