using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class MonitorTestExample
{
    static Random rnd;
    static int thrCount=1;
    static void fornewthread()
    {
        int[] values = new int[10000];
        int thrTotal = 0;
        int thrN = 0;
        int ctr = 0;
        Monitor.Enter(rnd);
        // Generate 10,000 random integers
        for (ctr = 0; ctr < 10000; ctr++)
            values[ctr] = rnd.Next(0, 1001);
        Monitor.Exit(rnd);
        thrN = ctr;
        foreach (var value in values)
            thrTotal += value;
     
        Console.WriteLine("Mean for thread #{0}, {1,2}: {2:N2} (N={3:N0})", thrCount++,
                          Thread.CurrentThread.Name, (thrTotal * 1.0) / thrN,
                          thrN);
    }
    public static void Main()
    {
        List<Thread> threads = new List<Thread>();
        rnd = new Random();
        int n = 10;


        for (int taskCtr = 0; taskCtr < n; taskCtr++)
            threads.Add(new Thread(fornewthread));
        try
        {
            foreach (Thread t in threads)
            {
                t.Start();               
                t.Join();
                
            }


        }
        catch (Exception e)
        {
            Console.WriteLine("Exc: " + e.Message);
        }
        
    }
}

 