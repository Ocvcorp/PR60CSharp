/*
 * Поместить элементы динамического целочисленного массива X в текстовый файл «unsafe.txt» в обратном порядке, 
 * исключив элементы, превосходящие по абсолютной величине вводимое значение R.
•	Размер массива при инициализации задать статическим «readonly» полем собственного класса «SizeArrayClass». 
Далее использовать это поле класса при работе с массивом. Размер – не менее 100 элементов;
•	Элементы массива заполнить случайными значениями от 0 до 200, возведенные в квадрат. 
Использовать предопределенный .NET класс Random;
•	При работе с массивом воспользоваться механизмом индексации через указатель на базовый тип (арифметические операции над указателями для получения доступа к элементам);
•	Вывести размер массива (в байтах), используя инструкцию «sizeof»;
•	При работе с текстовым файлом использовать инструкцию «using»;
•	Попробовать определить массив X в стеке, а не в динамической области памяти;
•	Создать критический раздел кода для сортировки массива Х. Для этого создать копию массива Х в объекте встроенного класса Array, для которого согласуется блокировка;
•	Явно контролировать возможное переполнение при арифметических операциях, и обработать возможное появления исключения «OverflowException»;
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    class SizeArrayClass
    {
        public static readonly int arrSize=150;
    }
    class Program
    {
        static void Main()
        {
            //array
            int size = SizeArrayClass.arrSize;
            int[] X = new int[size];
            int sizeReversed = 0;
            Random rand = new Random();
            //criteria
            int R = 10000;
            
            unsafe
            {
                try
                {                    
                    int* pX = stackalloc int[size];
                    int r;
                    Console.WriteLine("Initial array with elements more than {0}:", R);
                    for (int i=0;i<size;i++)
                    {
                        r = rand.Next(0, 200);
                        checked
                        {
                            *(pX + i) = (int)r * r;
                        }
                        //X-array
                        
                        if((*(pX + i))>R)
                        {
                            X[sizeReversed] = *(pX + i);
                            Console.WriteLine(*(pX + i));
                            sizeReversed++;
                        }                       
                    }
                    if (sizeReversed>0)
                    {
                        int[] Xcopy=new int[sizeReversed];
                        Array.Copy(X,Xcopy, sizeReversed);
                        lock (Xcopy)
                        {
                            Array.Reverse(Xcopy);
                        }
                        using (StreamWriter sw=new StreamWriter("unsafe.txt"))
                        {
                            fixed(int* pXcopy=Xcopy)
                            {
                                for (int i=0; i<sizeReversed;i++)
                                {
                                    sw.WriteLine(*(pXcopy+i));
                                }
                            }                            
                            sw.Close();
                        }                        
                        Console.WriteLine("Unsafe.txt is filled!");
                    }
                    else 
                    {
                        Console.WriteLine("No data to write in unsafe.txt");
                    }
                    
                }
                catch(StackOverflowException)
                {
                    Console.WriteLine("Переполнение стека");
                }
                catch(OverflowException)
                {
                    Console.WriteLine("Переполнение");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("Array size is {0} bytes", size*sizeof(int));
            }

        }

    }
}
