using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    /*
     * Реализовать класс RandomArray, представляющий собой массив натуральных чисел. 
    •	В классе RandomArray есть 2 индексатора, которые контролируют выход индекса за пределы массива, 
    а также возможность записи в массив только числа являющегося степенью двойки.
    •	Второй индексатор перегружает первый с возможностью обработки индекса нецелого типа
    •	Реализовать в классе свойства, используемые для хранения длины массива (int) и ошибки последней обработки (bool).
    Редактирование поддерживаемого свойством поля запрещено в вызывающем коде.
    •	Массив необходимо заполнить случайными значениями, являющиеся степенями двойки (числа 2, 4, 8, 16, 32, 64, 128…). 
    •	В классе RandomArray создать открытый метод AmountOfDegrees, возвращающий отношение: 
    произведение степеней основания 2 / сумму степеней основания 2.
    Например: в  массиве числа  {2, 256, 4, 32, 16}. 
    AmountOf Degrees должен вернуть значение:
    = (1*8*2*5*4) / (1+8+2+5+4)
    •	Продемонстрировать работу всех методов класса. Массив должен быть заполнен полностью, в процессе выполнения кода программы.
    •	Использовать встроенный .NET класс Random для генерации случайной последовательности чисел при заполнении массива, реализуемого 
    классом RandomArray.
    •	Перед заполнением массива, запросить ввод требуемого количества элементов массива в диапазоне от 10 и до 100.
    •	Продемонстрировать проверку возможности записи и чтения массива объекта RandomArray только чисел, являющихся степенью двойки.

     */
    class RandomArray
    {
        int[] arr;
        public int lowerBound; // наименьший индекс
        public int upperBound;  // наибольший индекс
        public int Length ; //длина массива
        public bool Error;
        public RandomArray(int low, int len)
        {
            arr = new int[len];
            Length = len;
            lowerBound = low;
            upperBound = low+len-1;
            //заполнение массива
            Random random = new Random(1);
            for (int i=0; i<Length;i++)
            {
                arr[i] = (int)Math.Pow(2, random.Next(0, 16));
            }
        }
        public int this[int index]
        {
            get 
            {
                if (ok(index))
                {
                    Error = false;
                    return arr[index - lowerBound];
                }
                Error = true;
                return 0;
            }
            set
            {
                if (ok(index)&& binaryDigit((int)value))
                {
                    arr[index - lowerBound] = (int)value;
                    Error = false;
                }
                Error = true;
            }
        }
        public int this[double index]
        {
            get 
            {
                if ((index - (int)index) < 0.5)
                    index = (int)index;
                else
                    index = (int)index + 1;
            
                if (ok((int) index))
                {
                    Error = false;
                    return arr[(int)index - lowerBound];
                }
                else
                {
                    Error = true;
                    return 0;
                }
            }
            set
            {
                if ((index - (int)index) < 0.5)
                    index = (int)index;
                else
                    index = (int)index + 1;
                if (ok((int)index) && binaryDigit((int)value))
                {
                    arr[(int)index - lowerBound] = (int)value;
                    Error = false;
                }
                else Error = true;
            }
        }
        public double AmountOfDegrees()
        {
            double sumDegs = 0;
            double prodDegs = 1;
            double ans = 0;
            foreach (int a in arr)
            {
                sumDegs += Math.Log2(a);
                prodDegs += Math.Log2(a);
            }
            if (sumDegs>0)
                ans= prodDegs / sumDegs;
            return ans;
        }
        public void PrintArray()
        {
            string outPut = "";
            foreach (int a in arr)
            {
                outPut += (a + " ");
            }
            Console.WriteLine("The array:\n"+outPut);
        }

        // Возврат логического значения true, если
        // индекс находится в установленных границах.
        private bool ok(int index)
        {
            if (index >= lowerBound & index <= upperBound) return true;
            return false;
        }
        //проверка на степень числа двойки
        private bool binaryDigit(int N)
        {
            bool ans = false;
            if (N > 1)
            {
                if ((N & (N - 1)) == 0)
                    ans = true;
            }
            return ans;
        }
    }
    public class Programm
    {
        public static void Main()
        {
            int numEls, lowInd;
            Console.WriteLine("Input an array length between 10 and 100, than any lower index");
            bool isNumEls = Int32.TryParse(Console.ReadLine(), out numEls);
            bool isLowInd = Int32.TryParse(Console.ReadLine(), out lowInd);
            if (isNumEls&&isLowInd)
            {
                RandomArray randArr = new RandomArray(lowInd, numEls);
                randArr.PrintArray();
                Console.WriteLine("Array data:\nLowerBoound-{0}\nUpperBoound-{1}:\nLength-{2}\nAmountOfDegrees-{3}",
                            randArr.lowerBound, randArr.upperBound, randArr.Length, randArr.AmountOfDegrees());
                Console.WriteLine("Changing the values. Enter an value and the index 4 times (double or int).");
                int val;
                int intInd;
                double dblInd;
                for (int i = 1; i < 5; i++)
                {
                    Console.WriteLine("Value:");
                    val = Int32.Parse(Console.ReadLine());
                    if (i<3)
                    {
                        Console.WriteLine("Index (integer):");
                        intInd = Int32.Parse(Console.ReadLine());
                        randArr[intInd] = val;
                    }
                    else
                    {
                        Console.WriteLine("Index (double):");
                        dblInd = Double.Parse(Console.ReadLine());
                        randArr[dblInd] = val;
                    }                    
                }
                randArr.PrintArray();
            }
            
        }
    }
}
