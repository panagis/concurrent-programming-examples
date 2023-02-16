namespace Examples.LockingOnAsyncTasks;

public class AsyncLock
{
    public static async Task<IDisposable> Lock(object obj)
    {
        while (!Monitor.TryEnter(obj))
            await Task.Delay(1000);
        
        Console.WriteLine($"Lock acquired on thread : {Thread.CurrentThread.ManagedThreadId}");
            
        return new ExitDisposable(obj);
    }

    private class ExitDisposable : IDisposable
    {
        private readonly object _obj;
        public ExitDisposable(object obj) { _obj = obj; }

        public void Dispose()
        {
            Monitor.Exit(_obj);
            Console.WriteLine($"Lock disposed on thread : {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}