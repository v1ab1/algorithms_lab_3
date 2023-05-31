using System;

class Program
{
  static void Main()
  {
    GenerateRandomNumbers();
    GenerateFuzzyNumbers();
    Console.WriteLine("Выберите задание:");
    Console.WriteLine("1. Арифметические операции со случайной величиной.");
    Console.WriteLine("2. Операции с нечеткими числами.");
    Console.Write("Введите номер задания: ");
    int choice = int.Parse(Console.ReadLine());

    switch (choice)
    {
      case 1:
        PerformRandomValueOperations();
        break;
      case 2:
        PerformFuzzyNumberOperations();
        break;
      default:
        Console.WriteLine("Некорректный номер задания.");
        break;
    }
  }

  static void GenerateRandomNumbers()
  {
    Random random = new Random();
    List<double> randomNumbers = new List<double>();

    for (int i = 0; i < 1000; i++)
    {
      double randomNumber = random.NextDouble();
      randomNumbers.Add(randomNumber);
    }

    using (StreamWriter writer = new StreamWriter("../report/random.txt"))
    {
      foreach (double number in randomNumbers)
      {
        writer.WriteLine(number);
      }
    }

    Console.WriteLine("Random numbers generated and saved to 'random.txt'.");
  }

  static void GenerateFuzzyNumbers()
  {
    Random random = new Random();
    List<double> fuzzyNumbers = new List<double>();

    for (int i = 0; i < 1000; i++)
    {
      double fuzzyNumber = random.NextDouble() * 0.5 + 0.5;
      fuzzyNumbers.Add(fuzzyNumber);
    }

    using (StreamWriter writer = new StreamWriter("../report/fuzzy.txt"))
    {
      foreach (double number in fuzzyNumbers)
      {
        writer.WriteLine(number);
      }
    }

    Console.WriteLine("Fuzzy numbers generated and saved to 'fuzzy.txt'.");
  }

  static void PerformRandomValueOperations()
  {
    Console.WriteLine("Вы выбрали задание 1 - Арифметические операции со случайной величиной.");

    Console.Write("Введите количество случайных значений: ");
    int count = int.Parse(Console.ReadLine());

    RandomValue randomValue = new RandomValue();

    for (int i = 0; i < count; i++)
    {
      double value = randomValue.GenerateRandomValue();
      Console.WriteLine($"Сгенерированное случайное значение: {value}");
    }

    RunRandomValueTests();
  }

  static void PerformFuzzyNumberOperations()
  {
    Console.WriteLine("Вы выбрали задание 2 - Операции с нечеткими числами.");

    Console.Write("Введите значение первого нечеткого числа: ");
    double value1 = double.Parse(Console.ReadLine());

    Console.Write("Введите значение второго нечеткого числа: ");
    double value2 = double.Parse(Console.ReadLine());

    FuzzyNumber fuzzyNumber1 = new FuzzyNumber(value1);
    FuzzyNumber fuzzyNumber2 = new FuzzyNumber(value2);

    Console.WriteLine("Выберите операцию:");
    Console.WriteLine("1. Сложение");
    Console.WriteLine("2. Вычитание");
    Console.WriteLine("3. Умножение");
    Console.WriteLine("4. Деление");
    Console.Write("Введите номер операции: ");
    int operation = int.Parse(Console.ReadLine());

    switch (operation)
    {
      case 1:
        FuzzyNumber sum = fuzzyNumber1 + fuzzyNumber2;
        Console.WriteLine($"Результат сложения: {sum.Value}");
        break;
      case 2:
        FuzzyNumber difference = fuzzyNumber1 - fuzzyNumber2;
        Console.WriteLine($"Результат вычитания: {difference.Value}");
        break;
      case 3:
        FuzzyNumber product = fuzzyNumber1 * fuzzyNumber2;
        Console.WriteLine($"Результат умножения: {product.Value}");
        break;
      case 4:
        FuzzyNumber quotient = fuzzyNumber1 / fuzzyNumber2;
        Console.WriteLine($"Результат деления: {quotient.Value}");
        break;
      default:
        Console.WriteLine("Некорректный номер операции.");
        break;
    }
  }

  static void RunRandomValueTests()
  {
    RandomValue randomValue1 = new RandomValue();
    RandomValue randomValue2 = new RandomValue();

    RandomValue sum = randomValue1 + randomValue2;
    RandomValue difference = randomValue1 - randomValue2;

    Console.WriteLine($"Сложение случайных значений: {sum.GenerateRandomValue()}");
    Console.WriteLine($"Вычитание случайных значений: {difference.GenerateRandomValue()}");
  }
}

class RandomValue
{
  private Random random;

  public RandomValue()
  {
    random = new Random();
  }

  public double GenerateRandomValue()
  {
    return random.NextDouble();
  }

  public static RandomValue operator +(RandomValue a, RandomValue b)
  {
    double sum = a.GenerateRandomValue() + b.GenerateRandomValue();
    return new RandomValue { random = new Random() };
  }

  public static RandomValue operator -(RandomValue a, RandomValue b)
  {
    double difference = a.GenerateRandomValue() - b.GenerateRandomValue();
    return new RandomValue { random = new Random() };
  }
}

class FuzzyNumber
{
  private double value;

  public FuzzyNumber(double value)
  {
    this.value = value;
  }

  public double Value
  {
    get { return value; }
    set { this.value = value; }
  }

  public static FuzzyNumber operator +(FuzzyNumber a, FuzzyNumber b)
  {
    double sumValue = a.Value + b.Value;
    return new FuzzyNumber(sumValue);
  }

  public static FuzzyNumber operator -(FuzzyNumber a, FuzzyNumber b)
  {
    double differenceValue = a.Value - b.Value;
    return new FuzzyNumber(differenceValue);
  }

  public static FuzzyNumber operator *(FuzzyNumber a, FuzzyNumber b)
  {
    return new FuzzyNumber(a.Value * b.Value);
  }

  public static FuzzyNumber operator /(FuzzyNumber a, FuzzyNumber b)
  {
    if (b.Value == 0)
    {
      throw new DivideByZeroException("Деление на ноль недопустимо.");
    }
    return new FuzzyNumber(a.Value / b.Value);
  }
}
