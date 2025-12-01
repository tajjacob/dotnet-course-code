// 51. Tasks
/// Commands to run in terminal:
/// cd /Users/tajjacob/Documents/GitHub/dotnet-course-code/HelloWorld
/// dotnet --info
/// dotnet clean
/// dotnet build -v:m
/// dotnet run

using System.Threading.Tasks;

namespace HelloWorld
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // explanation: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/
           Task firstTask = new Task(
            () =>
            {
                Thread.Sleep(100);
                Console.WriteLine("Task 1");
            }
           );
            firstTask.Start();
           await firstTask;

           Console.WriteLine("After the task was created");
        }

    }
}