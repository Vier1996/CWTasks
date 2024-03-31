using ProjectForTasks.Tasks.Interfaces;

namespace ProjectForTasks.Tasks;

public abstract class AbstractTask : ITask
{
    public void Bootstrapp() => Execute();

    public virtual void Dispose()
    {
        
    }
    
    public abstract void Execute();
}