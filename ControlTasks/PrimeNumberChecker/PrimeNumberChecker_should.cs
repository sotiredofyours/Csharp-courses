using NUnit.Framework;

namespace ControlTasks;

[TestFixture]
public class PrimeNumberChecker_should
{
    private readonly PrimeNumberChecker _primeChecker = new();
    
    [TestCase(4)]
    [TestCase(22)]
    [TestCase(82)]
    [TestCase(9999)]
    public void NotPrimeNumbers(int number)
    {
        Assert.False(_primeChecker.isPrime(number));
    }
    
    [TestCase(2)]
    [TestCase(1)]
    [TestCase(17)]
    [TestCase(283)]
    public void PrimeNumbers(int number)
    {
        Assert.True(_primeChecker.isPrime(number));
    }
    
    [TestCase(-10)]
    [TestCase(999999999)]
    public void OutOfRangeNumbers(int number)
    {
        Assert.Catch<Exception>(() => _primeChecker.isPrime(number));
    }
}