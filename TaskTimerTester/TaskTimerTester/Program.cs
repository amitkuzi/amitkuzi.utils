using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using amitkuzi.TPLExtention;

namespace TaskTimerTester
{
    class Program
    {
        static Stopwatch sw = new Stopwatch();
        private static CancellationTokenSource cs;
        static void Main(string[] args)
        {
            sw.Start();
            try
            {
                 cs = TaskTimer.Run(Action, TimeSpan.FromMilliseconds(300), TimeSpan.FromMilliseconds(500), TimeSpan.FromMilliseconds(3000),OnFinish);
                
                 
            }
            catch (Exception expException)
            {
                Console.WriteLine(expException);
            }
            Console.ReadLine();
            cs.Cancel();
            Console.ReadLine();
        }

        private static void OnFinish(Task task)
        {
            Console.WriteLine($"exit app at {sw.ElapsedMilliseconds} ");
            Console.WriteLine($"exit IsCanceled {task.IsCanceled} ");
            Console.WriteLine($"exit IsCompleted {task.IsCompleted} ");
            Console.WriteLine($"exit IsFaulted {task.IsFaulted} ");
            Console.WriteLine($"exit Exception {task.Exception} ");
 
        }

        private static void Action()
        {
            Console.Write($" start op at {sw.ElapsedMilliseconds} ");
            Thread.Sleep(500);
            Console.WriteLine($"\t\t end op at {sw.ElapsedMilliseconds} ");
            
        }
    }
}
