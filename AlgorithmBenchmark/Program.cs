using BenchmarkDotNet.Running;
using System;
using System.Diagnostics;
using System.Text;

namespace AlgorithmBenchmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Замер времени выполнения
            // С помощью класса StopWatch - но замеры будут слишком варироваться, то есть как бы неточные
            //Estimate(20);

            // С помощью DotNet Benchmark. (нужно запускать с Release и запускать без отладки)
            //var summary = BenchmarkRunner.Run<Testing>();


            // Профилирование
            // Профилирование — сбор характеристик работы программы, таких как время выполнения подпрограмм, число верно предсказанных условных переходов и пр.
            // Инструмент, используемый для анализа работы, называют профилировщиком или профайлером.
            // Утечка памяти — это процесс неконтролируемого уменьшения объёма свободной оперативной памяти компьютера, связанный с ошибками в работающих программах.

            // Профилировщик производительности Visual Studio (пункт меню Отладка и выбрать Профилировщик производительности)
            //Estimate2(20);
            //Console.ReadKey();

            // Профилировщики JetBrains: dotMemory и dotTrace (платные)



            // Задание 1 - тест string + string и stringbuilder на время
            var summary = BenchmarkRunner.Run<Testing2>();

            // Задание 2 - профилирование string + string и stringbuilder
            //Console.WriteLine("Method UseString start...");
            //UseString(70000);
            //Console.WriteLine("Method UseString finished");
            //Console.WriteLine("Ready to switch");
            //Console.ReadKey();

            //Console.WriteLine("Method UseStringBuilder start...");
            //UseStringBuilder(70000);
            //Console.WriteLine("Method UseStringBuilder finished");
            //Console.ReadKey();
        }

        static void CreateMatrix(int n)
        {
            var matrix = new int[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = new int[n];
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i][j] = i + j;
                }
            }
        }
        static void Estimate(int n)
        {
            var timer = new Stopwatch();
            timer.Start();

            for (int i = 0; i < n; i++)
            {
                timer.Restart();

                CreateMatrix(10000);

                timer.Stop();
                Console.WriteLine(timer.ElapsedMilliseconds);
            }
        }



        static void Estimate2(int n)
        {
            for (int i = 0; i < n; i++)
            {
                CreateMatrix(10000);
            }
        }



        static string UseString(int n)
        {
            string value = "";

            for (int i = 0; i < n; i++)
            {
                value += i.ToString();
                value += " ";
            }

            return value;
        }
        static string UseStringBuilder(int n)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                builder.Append(i.ToString());
                builder.Append(" ");
            }

            return builder.ToString();
        }
    }
}
