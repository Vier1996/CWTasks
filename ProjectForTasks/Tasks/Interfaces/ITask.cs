using ProjectForTasks.Bootstrapp.Interfaces;

namespace ProjectForTasks.Tasks.Interfaces;

public interface ITask : IBootstrapper
{
    public void Execute();
}