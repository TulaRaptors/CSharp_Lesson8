
// В двумерном массиве целых чисел. Удалить строку и столбец, на пересечении которых расположен наименьший элемент.

void FillMatrix(int[,] matrix, int minimum, int maximum)
{
    Random random = new Random();
    for (int i = 0; i < matrix.GetLength(0); i++)
        for (int j = 0; j < matrix.GetLength(1); j++)
            matrix[i, j] = random.Next(minimum, maximum);
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
            Console.Write($"{matrix[i, j]} ");
        Console.WriteLine();
    }
}

void DeleteRowColWithMinElement(int[,] matrix)
{
    int[,] array = new int[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];

    int min = matrix[0, 0];
    int m = 0;
    int n = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
        for (int j = 0; j < matrix.GetLength(1); j++)
            if (matrix[i, j] < min)
            {
                min = matrix[i, j];
                m = i;
                n = j;
            }
    Console.WriteLine($"Минимальный элемент равен {min}. Удаляем {m + 1} строку и {n + 1} столбец");

    for (int i = 0; i < matrix.GetLength(0); i++)
        for (int j = 0; j < matrix.GetLength(1); j++)
            if (i < m)
            {
                if (j < n)
                    array[i, j] = matrix[i, j];
                else if (j > n)
                    array[i, j - 1] = matrix[i, j];
            }
            else if (i > m)
            {
                if (j < n)
                    array[i - 1, j] = matrix[i, j];
                else if (j > n)
                    array[i - 1, j - 1] = matrix[i, j];
            }
    Console.WriteLine("Новая матрица: ");
    Console.WriteLine();
    PrintMatrix(array);
}


Console.Clear();
Console.Write("Введите количество строк: ");
int rows = int.Parse(Console.ReadLine() ?? "0");
Console.Write("Введите количество столбцов: ");
int columns = int.Parse(Console.ReadLine() ?? "0");
int[,] matrix = new int[rows, columns];
FillMatrix(matrix, 0, 10);
Console.WriteLine("Создана матрица: ");
Console.WriteLine();
PrintMatrix(matrix);
Console.WriteLine();
DeleteRowColWithMinElement(matrix);