using System;
using System.Collections.Generic;
using System.Linq;

class RandomValue
{
    private readonly Random random;

    public RandomValue()
    {
        random = new Random();
    }

    public double Generate()
    {
        return random.NextDouble();
    }

    public double Add(double a, double b)
    {
        return a + b;
    }

    public double Subtract(double a, double b)
    {
        return a - b;
    }
}

class FuzzyNumber
{
    private readonly List<double> membershipValues;

    public FuzzyNumber(List<double> membershipValues)
    {
        this.membershipValues = membershipValues;
    }

    public List<double> MembershipValues
    {
        get { return membershipValues; }
    }

    public FuzzyNumber Add(FuzzyNumber other)
    {
        List<double> result = new List<double>();
        for (int i = 0; i < membershipValues.Count && i < other.MembershipValues.Count; i++)
        {
            result.Add(membershipValues[i] + other.MembershipValues[i]);
        }
        return new FuzzyNumber(result);
    }

    public FuzzyNumber Subtract(FuzzyNumber other)
    {
        List<double> result = new List<double>();
        for (int i = 0; i < membershipValues.Count && i < other.MembershipValues.Count; i++)
        {
            result.Add(membershipValues[i] - other.MembershipValues[i]);
        }
        return new FuzzyNumber(result);
    }

    public FuzzyNumber Multiply(FuzzyNumber other)
    {
        List<double> result = new List<double>();
        for (int i = 0; i < membershipValues.Count && i < other.MembershipValues.Count; i++)
        {
            result.Add(membershipValues[i] * other.MembershipValues[i]);
        }
        return new FuzzyNumber(result);
    }

    public FuzzyNumber Divide(FuzzyNumber other)
    {
        List<double> result = new List<double>();
        for (int i = 0; i < membershipValues.Count && i < other.MembershipValues.Count; i++)
        {
            if (other.MembershipValues[i] != 0)
            {
                result.Add(membershipValues[i] / other.MembershipValues[i]);
            }
            else
            {
                // Handle division by zero error
                result.Add(double.PositiveInfinity);
            }
        }
        return new FuzzyNumber(result);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Пример использования класса RandomValue
        RandomValue randomValue = new RandomValue();
        double value1 = randomValue.Generate();
        double value2 = randomValue.Generate();
        double sum = randomValue.Add(value1, value2);
        double difference = randomValue.Subtract(value1, value2);
        Console.WriteLine($"Value 1: {value1}");
        Console.WriteLine($"Value 2: {value2}");
        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Difference: {difference}");

        // Пример использования класса FuzzyNumber
        List<double> membershipValues1 = new List<double> { 0.2, 0.4, 0.6, 0.8 };
        List<double> membershipValues2 = new List<double> { 0.1, 0.3, 0.5, 0.7 };
        FuzzyNumber fuzzyNumber1 = new FuzzyNumber(membershipValues1);
        FuzzyNumber fuzzyNumber2 = new FuzzyNumber(membershipValues2);
        FuzzyNumber sumFuzzy = fuzzyNumber1.Add(fuzzyNumber2);
        FuzzyNumber differenceFuzzy = fuzzyNumber1.Subtract(fuzzyNumber2);
        FuzzyNumber productFuzzy = fuzzyNumber1.Multiply(fuzzyNumber2);
        FuzzyNumber quotientFuzzy = fuzzyNumber1.Divide(fuzzyNumber2);
        Console.WriteLine("Fuzzy Number 1: " + string.Join(", ", fuzzyNumber1.MembershipValues));
        Console.WriteLine("Fuzzy Number 2: " + string.Join(", ", fuzzyNumber2.MembershipValues));
        Console.WriteLine("Sum: " + string.Join(", ", sumFuzzy.MembershipValues));
        Console.WriteLine("Difference: " + string.Join(", ", differenceFuzzy.MembershipValues));
        Console.WriteLine("Product: " + string.Join(", ", productFuzzy.MembershipValues));
        Console.WriteLine("Quotient: " + string.Join(", ", quotientFuzzy.MembershipValues));
    }
}
