// Сформировать трехмерный массив не повторяющимися двузначными числами 
// показать его построчно на экран выводя индексы соответствующего элемента

void NonrepeatingRandom(int[] array, int length)
{
    Random random = new Random();
    for (int i = 0; i < length; i++)
    {
        int number = random.Next(-99, 100);
        for (int j = 0; j < i + 1;)
            if (array[j] == number || (number >= -9 && number <= 9))
            {
                number = random.Next(-99, 100);
                j = 0;
            }
            else
                j++;
        array[i] = number;
    }
}


void FillMatrix(int[,,] matrix)
{
    int length = matrix.GetLength(0) * matrix.GetLength(1) * matrix.GetLength(2);
    int count = 0;
    int[] array = new int[length];
    NonrepeatingRandom(array, length);
    for (int i = 0; i < matrix.GetLength(0); i++)
        for (int j = 0; j < matrix.GetLength(1); j++)
            for (int k = 0; k < matrix.GetLength(2); k++)
            {
                matrix[i, j, k] = array[count];
                count++;
            }
}

void PrintMatrix(int[,,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
        for (int j = 0; j < matrix.GetLength(1); j++)
            for (int k = 0; k < matrix.GetLength(2); k++)
                Console.WriteLine($"Индекс: ({i}, {j}, {k}) - Элемент: {matrix[i, j, k]}");
}

Console.Clear();
Console.Write("Введите количество строк: ");
int rows = int.Parse(Console.ReadLine() ?? "0");
Console.Write("Введите количество столбцов: ");
int columns = int.Parse(Console.ReadLine() ?? "0");
Console.Write("Введите количество страниц: ");
int page = int.Parse(Console.ReadLine() ?? "0");
int[,,] matrix = new int[rows, columns, page];
if (rows * columns * page <= 180)
{
    FillMatrix(matrix);
    Console.WriteLine("Создана матрица: ");
    Console.WriteLine();
    PrintMatrix(matrix);
}
else
    Console.WriteLine("Размер матрицы больше количества доступных двухзначных чисел!");
