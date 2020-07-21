/*
2 часть. Изучение перенаправления потоков
1.	Используя перенаправление потоков для программы, написанной в части 1 данного задания, 
организовать печать в файл «system.log» содержимого окна консоли. 
2.	Используя перенаправление потоков организовать печать из одного файла в другой, 
при этом посредником должно выступать окно консоли.
----------------------------------------------------------------------------------------------------
1 часть. Изучение файлового потока ввода-вывода
1.	Пользователь вводит с клавиатуры количество чисел (больше 30). 
Программа формирует текстовый файл «1.txt», на каждой строке которого записаны случайные двузначные натуральные числа. 
Количество чисел в файле должно соответствовать заданному с клавиатуры значению. Закрыть файл после записи.
2.	Далее программа открывает файл «1.txt» для чтения. Последовательно считывая из файла каждое натуральное число, 
вычислить количество чётных и нечётных чисел. Если чётных чисел больше, чем нечётных, то вычислить среднее арифметическое всех чисел, 
в противном случае - среднее геометрическое. 
3.	Вывести на экран содержимое файла «1.txt», количество четных и нечетных чисел, 
среднее арифметическое или среднее геометрическое, сопровождая вывод поясняющими фразами.
4.	Далее программа создаёт файл «2.txt», в который записывает те числа из файла «1.txt», 
которые расположены между максимальным и минимальным натуральными числами, найденными в файле «1.txt».
 */

using System;
using System.IO;


namespace ConsoleApp
{
    public class s8_1_FileStreamIO
    {
        public static void Main()
        {
            
            
            Console.WriteLine("Enter a number count (>30)");
            int numCount = Int32.Parse(Console.ReadLine());
            //2.1
            StreamWriter logOut=new StreamWriter("D:\\system.log");
            TextWriter twrConsole = Console.Out;
            Console.SetOut(logOut);

            {
                //-----------------------1 part---------------------------------------------------------
                //1.1.
                FileStream fOut = new FileStream("D:\\1.txt", FileMode.Create);
                StreamWriter fStrOut = new StreamWriter(fOut);
                string inputString;
                Random randNum = new Random();
                for (int i = 0; i < numCount; i++)
                {
                    inputString = Convert.ToString(randNum.Next(10, 99)) + "\r\n";
                    fStrOut.Write(inputString);
                }
                fStrOut.Close();
                //1.2.
                int currentNum, evenCount = 0, oddCount = 0, sum = 0;
                long prod = 1;
                int ans;
                int maxNum = 0, minNum = 100;// для 4.
                FileStream fIn = new FileStream("D:\\1.txt", FileMode.Open, FileAccess.Read);
                StreamReader fStrIn = new StreamReader(fIn);
                try
                {
                    for (int i = 0; i < numCount; i++)
                    {
                        currentNum = Convert.ToInt32(fStrIn.ReadLine());
                        ans = (currentNum % 2 == 0) ? (evenCount++) : (oddCount++);
                        sum += currentNum;
                        prod *= currentNum;
                        //для 4.
                        if (currentNum > maxNum) maxNum = currentNum;
                        if (currentNum < minNum) minNum = currentNum;
                        //для 4.
                    }
                }
                catch (IOException exc)
                {
                    Console.WriteLine(exc.Message + "Ошибка при работе с файлом");
                }
                double arythmGeom;
                arythmGeom = (evenCount > oddCount) ? (sum / numCount) : (Math.Pow(prod, 1.0 / numCount));
                fStrIn.Close();
                //1.3.
                fIn = new FileStream("D:\\1.txt", FileMode.Open, FileAccess.Read);
                fStrIn = new StreamReader(fIn);
                string consoleAns, file1Content = "";
                for (int i = 0; i < numCount; i++)
                    file1Content += (fStrIn.ReadLine() + " ");
                consoleAns = (evenCount > oddCount) ? "more than Odds, the arithmetical mean" : "less than Odds, the geometric mean";
                Console.WriteLine("Numbers in \"1.txt\" file:\n" + file1Content);
                Console.WriteLine("There are {0} even numbers and {1} odd numbers in a file. Because we have Evens {2} is {3:F2}",
                    evenCount, oddCount, consoleAns, arythmGeom);
                //Console.ReadKey();
                fStrIn.Close();
                //1.4.
                FileStream fOut2 = new FileStream("D:\\2.txt", FileMode.Create);
                fIn = new FileStream("D:\\1.txt", FileMode.Open, FileAccess.Read);
                StreamWriter fStrOut2 = new StreamWriter(fOut2);
                fStrIn = new StreamReader(fIn);
                string currentString;
                int isWriting = -1;
                for (int i = 0; i < numCount; i++)
                {
                    currentString = fStrIn.ReadLine();
                    currentNum = Convert.ToInt32(currentString);
                    if (currentNum == maxNum || currentNum == minNum)
                    {
                        isWriting += 1;
                        continue;
                    }
                    if (isWriting == 0)
                        fStrOut2.Write(currentString + "\r\n");
                }
                fStrOut2.Close();
                fStrIn.Close();
                //-----------------------1 part---------------------------------------------------------
            }
            Console.WriteLine("A numbers from 1.txt between minimum and maximum have copied to 2.txt");
            
            logOut.Close();
            Console.SetOut(twrConsole);
            //2.2
            //Files
            FileStream inFstr = new FileStream ("D:\\2.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(inFstr);
            FileStream outFstr = new FileStream ("D:\\3.txt", FileMode.Create, FileAccess.Write);
            StreamWriter swr = new StreamWriter(outFstr);
            //Console
            //TextWriter twrConsole = Console.Out;
            TextReader trConsole = Console.In;
            //Redirection
            Console.SetIn(sr);
            Console.SetOut(swr);
            string buff;
            while(true)
            {
                if (sr.EndOfStream)
                    break;
                buff = Console.ReadLine();
                Console.WriteLine(buff);
            }
           
            
            sr.Close();
            inFstr.Close();
            swr.Close();
            outFstr.Close();
            
            Console.SetOut(twrConsole);            
            Console.SetIn(trConsole);
            Console.WriteLine("Finish");
            Console.ReadKey();
        }

    }
}
