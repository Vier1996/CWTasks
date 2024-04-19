using ProjectForTasks.Analyzer;

namespace ProjectForTasks.Tasks;

public class Task_Rudolf : AbstractTask
{
    public override void Execute()
    {
        ExecutionWatcher.Start();
        ExecutionWatcher.Stop();
        ExecutionWatcher.GetInfo();

        int[] intMass = new int[10];

        List<int> intList = new List<int>();
        List<int> intList2 = new List<int>(intMass);
        
        intList.Remove(3);
        intList.RemoveAt(1);
        
        intList.Clear();

        for (int i = 0; i < 3; i++) 
            intList.Add(i + 10);
        
        if (intList.Contains(25))
        {
            int index = intList.IndexOf(25);
            
            intList.Remove(25);
            intList.RemoveAt(index);
        }
    }

    private void T(int[] intMass)
    {
        List<int> intList = new List<int>(intMass);
    }
}