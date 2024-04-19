using System.Numerics;

namespace ProjectForTasks.Tasks
{
    public class Task_RectangleRotation : AbstractTask
    {
        public override void Execute()
        {
            Console.WriteLine(IsEqual(Transform(new int[] {1, 2, 3, 4, 5}, 0), new int[]{1, 2, 3, 4, 5}));
            Console.WriteLine(IsEqual(Transform(new int[] {1, 2, 3, 4, 5}, 2), new int[]{3, 4, 5, 1, 2}));
            Console.WriteLine(IsEqual(Transform(new int[] {1, 2, 3, 4, 5}, 3), new int[]{4, 5, 1, 2, 3}));
            Console.WriteLine(IsEqual(Transform(new int[] {1, 2, 3, 4, 5}, 6), new int[]{2, 3, 4, 5, 1}));
            Console.WriteLine(IsEqual(Transform(new int[] {1, 2, 3, 4, 5}, 11), new int[]{2, 3, 4, 5, 1}));
            Console.WriteLine(IsEqual(Transform(new int[] {1, 2, 3, 4, 5}, -1), new int[]{5, 1, 2, 3, 4}));
            Console.WriteLine(IsEqual(Transform(new int[] {1, 2, 3, 4, 5}, -4), new int[]{2, 3, 4, 5, 1}));
            Console.WriteLine(IsEqual(Transform(new int[] {1, 2, 3, 4, 5}, -11), new int[]{5, 1, 2, 3, 4}));
            Console.WriteLine(IsEqual(Transform(new int[] {1, 2, 3, 4, 5}, 4), new int[]{5, 1, 2, 3, 4}));
            //Console.WriteLine("-----------------------------------------------------");
        }
	
        public static int[] Transform(int[] list, int offset)
        {
            offset %= list.Length;
            
            bool isNegative = offset < 0;
            
            int lastIndex = list.Length - 1;
            int from = isNegative ? lastIndex : 0;
            int to = isNegative ? 0 : lastIndex;
            List<int> inputAsList = list.ToList();
            
            for (int i = 0; i < Math.Abs(offset); i++)
            {
                int cachedValue = inputAsList[from];
                
                inputAsList.RemoveAt(from);
                inputAsList.Insert(to, cachedValue);
            }
            
            return inputAsList.ToArray();
        }
	
        public static bool IsEqual(int[] a, int[] b) 
        {
            if (a == b) 
                return true;
            if (a == null || b == null) 
                return false;
            if (a.Length != b.Length) 
                return false;
            for (var i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i]) return false;
            }
  
            return true;
        }
    }
}
