namespace HT22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] B = new int[3,4];
            int sum = 0;
            int indexIMinValue = 0; int indexJMinValue = 0; int indexIMaxValue = 0; int indexJMaxValue = 0;
            Random random = new Random();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    B[i,j] = random.Next(-100,100);
                }
            }
            int minValue = B[0,0]; int maxValue = B[0, 0];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(B[i,j] + " ");
                }
                Console.WriteLine();
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (minValue > B[i, j]) { minValue = B[i, j]; indexIMinValue = i; indexJMinValue = j; }

                    if (maxValue < B[i, j]) { maxValue = B[i, j]; indexIMaxValue = i; indexJMaxValue = j; }
                }
            }
            Console.WriteLine($"MinValue: {minValue} по индексам {indexIMinValue}{indexJMinValue}");
            Console.WriteLine($"MaxValue: {maxValue} по индексам {indexIMaxValue}{indexJMaxValue}");

            if (minValue != maxValue)
            {
                if ((indexIMinValue > indexIMaxValue && indexJMinValue > indexJMaxValue)
                    || (indexIMinValue > indexIMaxValue)
                    || (indexIMinValue == indexIMaxValue && indexJMinValue > indexJMaxValue))
                {
                    int temp = indexIMaxValue;
                    indexIMaxValue = indexIMinValue;
                    indexIMinValue = temp;
                    temp = indexJMaxValue;
                    indexJMaxValue = indexJMinValue;
                    indexJMinValue = temp;
                    if ((indexIMaxValue == indexIMinValue && indexJMaxValue - indexJMinValue == 1)
                        || (indexIMaxValue - indexIMinValue == 1 && indexJMinValue == 3 && indexJMaxValue == 0))
                    {
                        sum = 0;
                    }
                }
                else
                {
                    for (int i = indexIMinValue; i <= indexIMaxValue; i++)
                    {
                        if (i == indexIMinValue && indexIMinValue == indexIMaxValue)
                        {
                            for (int j = indexJMinValue + 1; j < indexJMaxValue; j++)
                            {
                                sum += B[i, j];
                            }
                        }
                        else if (i == indexIMinValue && indexIMinValue != indexIMaxValue)
                        {
                            for (int j = indexJMinValue + 1; j < 4; j++)
                            {
                                sum += B[i, j];
                            }
                        }
                        else if (i == indexIMaxValue)
                        {
                            for (int j = 0; j < indexJMaxValue; j++)
                            {
                                sum += B[i, j];
                            }
                        }
                        else
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                sum += B[i, j];
                            }
                        }

                    }                  

                }
                Console.WriteLine($"Сумма между минимальным и максимальным элементами: {sum}");
            }
            else
            {
                Console.WriteLine("Чудо! 12 элементов одинаковы!");
            }

        }
    }
}