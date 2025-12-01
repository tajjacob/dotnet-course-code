// 52. Async Methods
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

            Task secondTask = ConsoleAfterDelayAsync("Task 2", 150);

            ConsoleAfterDelay("Delay", 75);

            Task thirdTask = ConsoleAfterDelayAsync("Task 3", 50);

           await secondTask;
           await firstTask;
           Console.WriteLine("After the task was created");
           await thirdTask;
        }

        static void ConsoleAfterDelay(string text, int delayTime)
        {
            Thread.Sleep(delayTime);
            Console.WriteLine(text);
        } 
        
        static async Task ConsoleAfterDelayAsync(string text, int delayTime)
        {
            await Task.Delay(delayTime);
            Console.WriteLine(text);
        }

    }

    // explanation: the order of output will vary due to the asynchronous nature of the tasks. 

    
}