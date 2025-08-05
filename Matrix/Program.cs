





int[,] numbers = { { 3, 2, 1 , 1, 2}, { 6, 5, 4 , 4, 1}, {9, 8, 7, 7, 10} };





//var result = FindDuplicateIndexes(numbers);
//foreach (var index in result)
//    Console.WriteLine($"[Row : {index[0]}, Column : {index[1]}]");




//var sortedArray = SortedArray(numbers);
//var sumOfOddNumbers = TheSumOddNumbersOfArray(numbers);


//Testlash uchun

//foreach (var item in sortedArray)
//{
//    Console.WriteLine(item);
//}

//Console.WriteLine(sumOfOddNumbers);



#region B) Matrisani sortirovka qilish

int[,] SortedArray(int[,] arr)
{
    int rows = arr.GetLength(0);
    int columns = arr.GetLength(1);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            for (int k = j + 1; k < columns; k++)
            {
                if (arr[i, j] > arr[i, k])
                {
                    int temp = arr[i, j];
                    arr[i, j] = arr[i, k];
                    arr[i, k] = temp;
                }
            }
        }
    }

    return arr;
}

#endregion



#region C) Matricani toq elementlarini qiymatlari summasini topish;

int TheSumOddNumbersOfArray(int[,] arr)
{
    int rows = arr.GetLength(0);
    int columns = arr.GetLength(1);

    int sumOfNumbers = 0;

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            if (arr[i, j] % 2 != 0)
            {
                sumOfNumbers += arr[i, j];
            }
        }
    }

    return sumOfNumbers;
}

#endregion



#region D) Matricada takrorlangan elementlar indexlarini massiv ko'rinishida chiqarish;


List<int[]> FindDuplicateIndexes(int[,] arr)
{
    int rows = arr.GetLength(0);
    int columns = arr.GetLength(1);
    Dictionary<int, List<int[]>> dict = new();

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            int element = arr[i, j];
            if (!dict.ContainsKey(element))
                dict[element] = new List<int[]>();

            dict[element].Add(new int[] { i, j });
        }
    }

    var repeatingIndicesList = dict
        .Where(pair => pair.Value.Count >= 2)
        .SelectMany(pair => pair.Value)
        .ToList();

    return repeatingIndicesList;
}



#endregion




//1.A(MxN) matrica(ikki o'lchovli) beriladi. Kiruvchi parametrlar M va N butun sonlar.
//   Quyidagilarni bajaring:
//   a) Ixtiyoriy sonlar bilan matricani to'ldirish;
//   b) Matrisani sortirovka qilish
//   c) Matricani toq elementlarini qiymatlari summasini topish;
//   d) Matricada takrorlangan elementlar indexlarini massiv ko'rinishida chiqarish;