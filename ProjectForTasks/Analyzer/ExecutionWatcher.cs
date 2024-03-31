using System.Diagnostics;

namespace ProjectForTasks.Analyzer;

public static class ExecutionWatcher
{
    private static Stopwatch _watch = new();
    
    public static void Start() => _watch.Start();
    
    public static void Stop() => _watch.Stop();

    public static void GetInfo() => 
        Console.WriteLine($"[Analyzer]: ElapsedTime [{_watch.ElapsedMilliseconds}]");
}