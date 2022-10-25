
// Найти произведение двух матриц


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

int[,] ProductTwoMatrix(int[,] matrixA, int[,] matrixB)
{
    int[,] prod = new int[matrixA.GetLength(0), matrixB.GetLength(1)];
    for (int i = 0; i < matrixA.GetLength(0); i++)
        for (int j = 0; j < matrixB.GetLength(1); j++)
        {
            int sum = 0;
            for (int k = 0; k < matrixA.GetLength(1); k++)
                sum += matrixA[i, k] * matrixB[k, j];
            prod[i, j] = sum;
        }
    return prod;
}

int[,] Matrix()
{
    Console.Write("Введите количество строк: ");
    int rows = int.Parse(Console.ReadLine() ?? "0");
    Console.Write("Введите количество столбцов: ");
    int columns = int.Parse(Console.ReadLine() ?? "0");
    int[,] matrix = new int[rows, columns];
    FillMatrix(matrix, 0, 10);
    PrintMatrix(matrix);
    Console.WriteLine();
    return matrix;
}

Console.Clear();
Console.WriteLine("Матрица А");
int[,] matrixA = Matrix();
Console.WriteLine("Матрица B");
int[,] matrixB = Matrix();

if (matrixA.GetLength(1) != matrixB.GetLength(0))
    Console.WriteLine("Матрицы нельзя перемножить! (Количество столбцов А не равно количеству строк В)");
else
{
    int[,] prod = ProductTwoMatrix(matrixA, matrixB);
    Console.WriteLine("Произведение матрицы А на матрицу В: ");
    PrintMatrix(prod);
}