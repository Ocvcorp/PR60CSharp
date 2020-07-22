using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class MyTask
    {
        public int[] sortArr;
        public Task task;
        int taskID;
        string parallelMethod;
        public MyTask(int[,] inMtrx, int rowNum, string parallelMethod="None")
        {
            sortArr = new int[20];
            this.parallelMethod = parallelMethod;
            task = new Task(() =>
            {
                taskID = (int)Task.CurrentId;
                for (int j = 0; j < 20; j++) sortArr[j] = inMtrx[rowNum, j];
                Console.WriteLine($"{parallelMethod} task({taskID}) starts with id = {taskID}");
                Array.Sort(sortArr);
                if (taskID % 2 != 0) 
                    Array.Reverse(sortArr);
                Console.WriteLine($"{parallelMethod} task({taskID}) finishes");
            });
        }
        public void Run()
        {
            task.Start();
        }
    }
    class Programm
    {
        
        static void Main()
        {
            //2-demension random array
            int[,] Mtrx = new int[5, 20];
            int[,] MtrxSorted1 = new int[5, 20];
            int[,] MtrxSorted2 = new int[5, 20];
            int[,] MtrxSorted3 = new int[5, 20];
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 20; j++)
                    Mtrx[i, j] = rnd.Next(10, 99);
            //5 tasks (For, ForEach, Invoke)
            MyTask[] tasksFor = new MyTask[5];
            MyTask[] tasksForEach = new MyTask[5];
            MyTask[] tasksInvoke = new MyTask[5];
            for (int i = 0; i < 5; i++)
                tasksFor[i] = new MyTask(Mtrx, i, "\"For\" parallel method");
            for (int i = 0; i < 5; i++)
                tasksForEach[i] = new MyTask(Mtrx, i, "\"ForEach\" parallel method");
            for (int i = 0; i < 5; i++)
                tasksInvoke[i] = new MyTask(Mtrx, i, "\"Invoke\" parallel method");
            //For
            Parallel.For(0, 5,(int i)=> tasksFor[i].Run());           
            //ForEach
            Parallel.ForEach<MyTask>(tasksForEach,(t)=>  t.Run());
            //Invoke
            Parallel.Invoke(() => tasksInvoke[0].Run(),
                            () => tasksInvoke[1].Run(), 
                            () => tasksInvoke[2].Run(),
                            () => tasksInvoke[3].Run(),
                            () => tasksInvoke[4].Run());

            Task output=Task.Factory.StartNew(() =>
            {
                MtrxCompliting(tasksFor, MtrxSorted1);
                MtrxCompliting(tasksForEach, MtrxSorted2);
                MtrxCompliting(tasksInvoke, MtrxSorted3);
                PrintMtrx("Initial matrix", Mtrx);
                PrintMtrx("Sorted matrix (Parallel For result)", MtrxSorted1);
                PrintMtrx("Sorted matrix (Parallel ForEach result)", MtrxSorted2);
                PrintMtrx("Sorted matrix (Parallel Invoke result)", MtrxSorted3);
            }
            );
            output.Wait();
        }
        static void MtrxCompliting(MyTask[] myTasks, int[,] outMtrx)
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 20; j++)
                    outMtrx[i, j] = myTasks[i].sortArr[j];
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
