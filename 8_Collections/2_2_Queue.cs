/*
 * 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class lec7_1
    {
        public static void Main()
        {
            //array initialization
            Random rnd = new Random();
            int[] initArr = new int[50];
            for (int i = 0; i < 50; i++)
            {
                initArr[i] = rnd.Next(0, 100);
            }
            //arrayList of queues
            ArrayList nums = new ArrayList();
            for (int i = 0; i < 10; i++)
            {
                Queue q = new Queue();
                q.Enqueue(i);
                foreach (int el in initArr)
                {
                    if (el % 10 == i)
                    {
                        q.Enqueue(el);
                    }
                }
                nums.Add(q);
            }
            //array output
            string str;
            for (int i = 0; i < 10; i++)
            {
                str = "";
                foreach (int el in (Queue)nums[i])
                {
                    str += (" " + el);
                }
                Console.WriteLine(str);
            }
        }
    }
}
