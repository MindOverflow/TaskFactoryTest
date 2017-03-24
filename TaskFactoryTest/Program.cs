using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace TaskFactoryTest
{
    internal class Program
    {
        private static void MyTask()
        {
            WriteLine($"MyTask() №{Task.CurrentId} запущен.");

            for (var count = 0; count < 10; count++)
            {
                Thread.Sleep(500);
                WriteLine($"В методе MyTask() №{Task.CurrentId}, подсчёт равен {count}");
            }

            WriteLine($"MyTask №{Task.CurrentId} завершён.");
        }

        private static void Main()
        {
            WriteLine("Основной поток выполнения запущен.");

            // Здесь идёт объявление задач и старт, которые могут выполняться параллельно.
            var task01 = Task.Factory.StartNew(MyTask);
            var task02 = Task.Factory.StartNew(MyTask);

            Task.WaitAny(task01, task02);

            WriteLine("Основной поток завершён.");
        }
    }
}
