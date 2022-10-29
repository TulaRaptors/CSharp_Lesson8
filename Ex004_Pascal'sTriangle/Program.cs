// Показать треугольник Паскаля *Сделать вывод в виде равнобедренного треугольника

long Factorial(int n)
{
    long factorial = 1;
    for (int i = 1; i <= n; i++)
        factorial *= i;
    return factorial;
}

int DigitNumber(long number)
{
    int count = 0;
    while (number > 0)
    {
        number = number / 10;
        count++;
    }
    return count;
}

void PrintTriangle(int n)
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j <= (n - i); j++)
            Console.Write("    ");
        for (int k = 0; k <= i; k++)
        {
            long number = Factorial(i) / (Factorial(k) * Factorial(i - k));
            if (DigitNumber(number) == 1)
                Console.Write($"      {number} ");
            else if (DigitNumber(number) == 2)
                Console.Write($"     {number} ");
            else if (DigitNumber(number) == 3)
                Console.Write($"    {number} ");
            else if (DigitNumber(number) == 4)
                Console.Write($"   {number} ");
            else if (DigitNumber(number) == 5)
                Console.Write($"  {number} ");
            else if (DigitNumber(number) == 6)
                Console.Write($" {number} ");
        }
        Console.WriteLine();
    }
}

Console.Clear();
Console.Write("Введите количество строк треугольника Паскаля: ");
int n = int.Parse(Console.ReadLine() ?? "0");
PrintTriangle(n);

// на своем мониторе смог проверить вывод до 20 строк.