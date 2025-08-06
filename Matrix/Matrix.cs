using System.Data;

namespace Matrix;

public class Matrix
{
    public int Rows { get; }
    public int Columns { get; }
    private readonly int[,] _data;


    public Matrix(int[,] data)
    {
        if (data == null &&
            data.GetLength(0) <= 0 &&
            data.GetLength(1) <= 0)
            throw new ArgumentNullException(nameof(data), "Matrix null bolish kerak emas");

        Rows = data.GetLength(0);
        Columns = data.GetLength(1);
        _data = data;
    }


    /// <summary>
    /// Indexator orqali matrixni(arrayni) qiymatlarini korish. Matrixni ozgartirmagan xolatda
    /// </summary>
    public int this[int row, int col]
    {
        get => _data[row, col];
        set => _data[row, col] = value;
    }

    /// <summary>
    /// B) Matrixni sortirovka qilish
    /// </summary>
    public void SortArray()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                for (int k = j + 1; k < Columns; k++)
                {
                    if (_data[i, j] > _data[i, k])
                    {
                        int temp = _data[i, j];
                        _data[i, j] = _data[i, k];
                        _data[i, k] = temp;
                    }
                }
            }
        }
    }

    /// <summary>
    /// C) Matrixani toq elementlarini qiymatlari summasini topish;
    /// </summary>
    /// <returns>int</returns>
    public int GetSumOddNumbersOfArray()
    {
        int sum = 0;
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                if (_data[i, j] % 2 != 0)
                {
                    sum += _data[i, j];
                }
            }
        }
        return sum;
    }

    /// <summary>
    /// D) Matrixda takrorlangan elementlar indexlarini massiv ko'rinishida chiqarish;
    /// </summary>
    /// <returns></returns>
    public List<int[]> FindDuplicateIndexes()
    {
        Dictionary<int, List<int[]>> dict = new();
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                int element = _data[i, j];
                if (!dict.ContainsKey(element))
                    dict[element] = new List<int[]>();

                dict[element].Add(new int[] { i, j });
            }
        }

        return dict
            .Where(pair => pair.Value.Count >= 2)
            .SelectMany(pair => pair.Value)
            .ToList();
    }

    /// <summary>
    /// Matrixni print qilish metodi
    /// </summary>
    public void Print()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                Console.Write($"{_data[i, j]} ");
            }
            Console.WriteLine();
        }
    }
}