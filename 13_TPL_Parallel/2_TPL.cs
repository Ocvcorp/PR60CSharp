using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using System.Linq;

namespace ConsoleApp
{
    class SortClass
    {
        public int[] arr;
        public bool isIncrease;
        public SortClass(int[] arr, bool isIncrease=true)
        {
            this.isIncrease = isIncrease;
            int N = arr.Length;
            this.arr = new int[N];
            for (int i = 0; i < N; i++)
                this.arr[i] = arr[i];            
        }
        public void SortIncrease()
        {
            Array.Sort(arr);
        }
        public void SortDecrease()
        {
            Array.Sort(arr);
            Array.Reverse(arr);
        }
        public void TaskSorting()
        {
            if (isIncrease)
                SortIncrease();
            else
                SortDecrease();
        }
        public void TaskSorting(Task t)
        {
            if (isIncrease)
                SortIncrease();
            else
                SortDecrease();
        }

    }
    class Programm
    {
        static void Main()
        {
            //2-demension random array
            int[,] Mtrx = new int[5,20];
            int[,] MtrxSorted1 = new int[5,20];
            int[,] MtrxSorted2 = new int[5, 20];
            int[,] MtrxSorted3 = new int[5, 20];
            Random rnd = new Random();
            for (int i= 0; i<5;i++)
                for (int j = 0; j < 20; j++)
                    Mtrx[i,j] = rnd.Next(10, 99);
            //5 tasks with lambda
            Task task;
            int[] buff = new int[20];
            int id;
            for (int i = 0; i < 5; i++) 
            {
                for (int j = 0; j < 20; j++)
                    buff[j] = Mtrx[i, j];               
                task=Task.Factory.StartNew(() =>
                        {
                            id = (int)Task.CurrentId;
                            Console.WriteLine($"Task({i}) starts with id = {id}");
                            Array.Sort(buff);
                            if (id % 2 != 0)
                                Array.Reverse(buff);                           
                        }
                    );
                task.Wait(); 
                for (int j = 0; j < 20; j++)
                    MtrxSorted1[i, j] = buff[j];
                Console.WriteLine($"Task({i}) finishes");                            
            }
            //5 tasks with examplar methods

            SortClass sortClass;
            for (int i = 0; i< 5; i++) 
            {
                for (int j = 0; j < 20; j++)
                    buff[j] = Mtrx[i, j];
                sortClass =new SortClass(buff);
                task = new Task(sortClass.TaskSorting);
                id = task.Id;
                if (id % 2 != 0) sortClass.isIncrease = false;
                task.Start();
                Console.WriteLine($"Task({i+5}) starts with id = {id}");
                task.Wait();
                for (int j = 0; j < 20; j++)
                    MtrxSorted2[i, j] = sortClass.arr[j];
                Console.WriteLine($"Task({i+5}) finishes");
            }
            
            //5 tasks with ContinueWith (for first task we will use examplar method, for continues - lambda)
            Task[] tasks = new Task[5];
            //First task
            for (int j = 0; j < 20; j++)
                buff[j] = Mtrx[0, j];
            sortClass = new SortClass(buff, false);
            tasks[0] = new Task(sortClass.TaskSorting);
            tasks[0].Start();
            //Continues tasks
            if (Mtrx.IsSynchronized) Console.WriteLine("Can't apply parallel tasks"); else Console.WriteLine("Hello, parallelizm!");//
            for (int i=1;i<5;i++)
            {
                for (int j = 0; j < 20; j++)
                    buff[j] = Mtrx[i, j];
                
                tasks[i] = tasks[i-1].ContinueWith((first)=> 
                {
                    id = (int)Task.CurrentId;
                    Console.WriteLine($"Task({i+10}) starts with id = {id}");
                    Array.Sort(buff);
                    if (id % 2 != 0)
                        Array.Reverse(buff);
                    for (int j = 0; j < 20; j++)
                        MtrxSorted3[i, j] = buff[j];
                });
                tasks[i].Wait();
            }
            //First method results
            for (int j = 0; j < 20; j++)
                MtrxSorted3[0, j] = sortClass.arr[j];
            //finish messages
            for (int i=0; i<5; i++)
                Console.WriteLine($"Task({i + 10}) finishes");
            
            //Outputs
            PrintMtrx("Initial matrix",Mtrx);
            PrintMtrx("Sorted matrix (lambda-tasks)", MtrxSorted1);
            PrintMtrx("Sorted matrix (examplar-tasks)", MtrxSorted2);
            PrintMtrx("Sorted matrix (ContinueWith)", MtrxSorted3);
            
        }
         
        static void PrintMtrx(string preText,int[,] Mtrx)
        {
            string outputStr = "";
            int col = 0;
            Console.WriteLine("\n" + preText);
            foreach (int m in Mtrx)
            {
                outputStr += (m+" ");
                col++;
                if (col == 20)
                {
                    Console.WriteLine(outputStr);
                    col = 0;
                    outputStr = "";
                }
            }
        }
    }
}
