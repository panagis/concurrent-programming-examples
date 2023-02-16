using Examples.LockingOnAsyncTasks;

namespace Tests;

public class Tests
{
    [Test]
    public async Task AsyncLockTest()
    {
        object lockObject = new();

        Console.WriteLine($"Trying to connect on thread : {Thread.CurrentThread.ManagedThreadId}");

        using (await AsyncLock.Lock(lockObject))
        {
            Console.WriteLine($"Connected on thread : {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(1000);
            Console.WriteLine($"Connection established on thread : {Thread.CurrentThread.ManagedThreadId}");
        }

        Console.WriteLine($"Finished on thread : {Thread.CurrentThread.ManagedThreadId}");
    }
}