/*
1)С помощью Parallel.For реализовать сложение двух матриц.
2)С помощью Parallel.For реализовать умножение двух матриц.
Измерить время выполнения

 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class lec16_ParallelMatrix
    {
        static void mtrxOutPut(int[,] Mtrx, int nI, int mJ, string preText="")
        {
            Console.WriteLine(preText);
            string outPutStr = "";
            for (int i=0; i<nI; i++)
            {
                for (int j = 0; j < mJ; j++)
                {
                    outPutStr += ((Mtrx[i,j]).ToString() + "\t");
                }
                Console.WriteLine(outPutStr);
                outPutStr = "";
            }
        }
        static void Main()
        {
            int[,] mtrx1 = 
                {
                    {1, 2, 3 },
                    {4, 5, 6 },
                    {7, 8, 9 },
                    {10, 11, 12 }
                };
            int[,] mtrx2 =
                {
                    {12, 11, 10 },
                    {9, 8, 7 },
                    {6, 5, 4 },
                    {3, 2, 1 }
                };
            int[,] mtrx3 =
                {
                    {12, 9, 6, 3 },
                    {11, 8, 5, 2 },
                    {10, 7, 4, 1 }
                };
            //Output initial conditions
            mtrxOutPut(mtrx1, 4, 3, "mtrx1:");
            mtrxOutPut(mtrx2, 4, 3, "mtrx2:");
            mtrxOutPut(mtrx3, 3, 4, "mtrx3:");
            //Matrices sum
            
            int[,] mtrxSum = new int[4, 3];
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Parallel.For(0, 4, i => 
            {
                Parallel.For(0, 3, j => 
                {
                    mtrxSum[i,j]=mtrx1[i, j] + mtrx2[i, j];
                });                
            });
            mtrxOutPut(mtrxSum, 4, 3, "Matrices (mtrx1 & mtrx2) SUM:");
            sw.Stop();
            Console.WriteLine("Timing(ms): " + sw.Elapsed.TotalMilliseconds);
            //Matrix multipling mtrx1 & mtrx3
            int[,] mtrxProduct = new int[3, 3];
            int sum=0;
            sw.Restart();
            Parallel.For(0, 3, i =>
            {
                for (int j=0; j<3; j++) 
                {
                    for(int k=0; k<4; k++)
                    {
                        sum += (mtrx3[i, k] * mtrx1[k, j]);
                    };
                    mtrxProduct[i, j] = sum;
                    sum = 0;
                };
                
            });
            mtrxOutPut(mtrxProduct, 3, 3, "Matrices (mtrx3 & mtrx1) PRODUCT:");
            sw.Stop();
            Console.WriteLine("Timing(ms): "+sw.Elapsed.TotalMilliseconds);
            Console.ReadKey();
        }
    }
}
