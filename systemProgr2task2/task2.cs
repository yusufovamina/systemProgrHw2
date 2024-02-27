using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace systemProgrHw2
{
    internal class task2
    {
        static void Main(string[] args)
        {

            Task task = new Task(new Action(DrawEmptySquare), TaskCreationOptions.PreferFairness |
                                                            TaskCreationOptions.LongRunning);
            Task task2 = new Task(new Action(DrawFullSquare), TaskCreationOptions.PreferFairness |
                                                            TaskCreationOptions.LongRunning);

            Task task3 = new Task(new Action(DrawLine), TaskCreationOptions.PreferFairness |
                                                            TaskCreationOptions.LongRunning);
            task.Start();

            task2.Start();

            task3.Start();
            Thread.Sleep(50);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("             Metod Main vipolnyaetsa...");
                Thread.Sleep(1000);
            }
            Task.WaitAll(task, task2, task3);
        }

        private static void DrawFullSquare()
        {

            Console.WriteLine($"Task Id of Full Square: {Task.CurrentId}");
            Console.WriteLine($"Thread Id of Full Square: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine(new string('-', 80));
          
            for (int i = 0; i < 10; i++)
            {

                Console.WriteLine( "$ $ $ $ $ $ $ $ $ $");

                Thread.Sleep(1000);
            }
            Console.WriteLine($"Task was finished in Thread number: {Thread.CurrentThread.ManagedThreadId}");
        }

        private static void DrawLine()
        {

            Console.WriteLine($"Task Id of Line: {Task.CurrentId}");
            Console.WriteLine($"Thread Id of Line: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine(new string('-', 80));
            
            for (int i = 0; i < 10; i++)
            {

                Console.WriteLine("#");

                Thread.Sleep(1000);
            }
            Console.WriteLine($"Task was finished in Thread number: {Thread.CurrentThread.ManagedThreadId}");
        }

        private static void DrawEmptySquare()
        {

            Console.WriteLine($"Task Id of Empty Square: {Task.CurrentId}");
            Console.WriteLine($"Thread Id of Empty Square: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine(new string('-', 80));
            
            for (int i = 0; i < 10; i++)
            {
                if (i == 0 || i == 9)
                {
                    Console.WriteLine("* * * * * * * * * *");
                }
                else
                {
                    Console.WriteLine("*                 *");

                }
                Thread.Sleep(1000);
            }
            Console.WriteLine($"Task was finished in Thread number: {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
