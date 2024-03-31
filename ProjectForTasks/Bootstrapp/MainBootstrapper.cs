using ProjectForTasks.Bootstrapp.Interfaces;
using ProjectForTasks.Tasks;

namespace ProjectForTasks.Bootstrapp;

public class MainBootstrapper : IBootstrapper
{
    private AbstractTask _codewarsTask;
    
    public void Bootstrapp()
    {
        _codewarsTask = new Task_SimplePigLatin();
        _codewarsTask.Bootstrapp();
    }

    public void Dispose() => _codewarsTask.Dispose();
}