using System;
using System.Diagnostics;
using System.Threading;

namespace TestTryCatchLoopTime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] array = new string[100];

            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            InLoop(array);
            stopwatch1.Stop();
            TimeSpan ts1 = stopwatch1.Elapsed;
            string time1 = string.Format("{0:00}:{1:00}:{2:00}:{3:00}", ts1.Hours, ts1.Minutes, ts1.Seconds, ts1.Milliseconds / 10);

            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            OutLoop(array);
            stopwatch2.Stop();
            TimeSpan ts2 = stopwatch2.Elapsed;
            string time2 = string.Format("{0:00}:{1:00}:{2:00}:{3:00}", ts2.Hours, ts2.Minutes, ts2.Seconds, ts2.Milliseconds / 10);

            Console.WriteLine(time1);
            Console.WriteLine(time2);
            Console.ReadKey();
        }

        static void InLoop(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                try
                {
                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {

                }
            }
        }

        static void OutLoop(string[] array)
        {
            try
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
