using ProjectForTasks.Analyzer;

namespace ProjectForTasks.Tasks;

public class Task_Snail : AbstractTask
{
    public override void Execute()
    {
        int[][] array =
        {
            new []{1, 2, 3, 1, 2},
            new []{4, 5, 6, 4, 2},
            new []{7, 8, 9, 7, 3},
            new []{7, 8, 9, 7, 4},
            new []{7, 8, 9, 7, 5}
        };
        
        ExecutionWatcher.Start();
        Snail1(array);
        //Snail(array);
        //Snail(array, 0);
        ExecutionWatcher.Stop();

        ExecutionWatcher.GetInfo();
    }
    
    // Clever from CodeWars
    public static IEnumerable<int> Snail(int[][] a, int r = 0)
    {
        int n = a[0].Length - 1 - 2 * r;
        if (n < 0) return new int[0];
        if (n == 0) return new []{a[r][r]};
      
        var sides = new []{
                a[r],                             // Top
                a.Select(x => x[r+n]),            // Right
                a[r+n].Reverse(),                 // Bottom
                a.Select(x => x[r]).Reverse()     // Left
            }
            .SelectMany(x => x.Skip(r).Take(n));
 
        return (n == 1) ? sides : sides.Concat(Snail(a, r+1));
    }
    
    public static int[] Snail1(int[][] array)
    {
        int l = array[0].Length;
        int[] sorted = new int[l * l];
        Snail(array, -1, 0, 1, 0, l, 0, sorted);
        return sorted;
    }

    public static void Snail(int[][] array, int x, int y, int dx, int dy, int l, int i, int[] sorted)
    {
        if (l == 0)return;
        
        for (int j = 0; j < l; j++)
        {
            x += dx;
            y += dy;
            sorted[i++] = array[y][x];
        }
        Snail(array, x, y, -dy, dx, dy == 0 ? l - 1 : l, i, sorted);
    }
    
    //
    public static int[] Snail(int[][] array)
    {
        Direction direction = Direction.right;
        int maxDepth = array.Length;
        int maxLength = array[0].Length;
        int currentRow = 0;
        int currentColumn = 0;
        int maxIteration = maxDepth * maxLength;
        List<int> output = new List<int>(capacity: maxIteration);
        
        Rec(false);

        void Rec(bool changeValue = true)
        {
            if(maxIteration <= 0)
                return;

            if (changeValue) ChangeStep();

            bool isBoundsValid = IsBoundsValid();
            bool isVisitedValid = array[currentRow][currentColumn] != -1;

            if (isBoundsValid && isVisitedValid == false)
                ChangeStep(false);
            
            if (isBoundsValid == false || isVisitedValid == false)
            {
                direction = GetNextDirection(direction);
               
                Rec();
                
                return;
            }

            output.Add(array[currentRow][currentColumn]);
            array[currentRow][currentColumn] = -1;
            maxIteration--;
            
            Rec();
        }

        void ChangeStep(bool increment = true)
        {
            switch (direction)
            {
                case Direction.right: currentColumn += (increment ? 1 : -1); break;
                case Direction.down: currentRow += (increment ? 1 : -1);; break;
                case Direction.left: currentColumn += (increment ? -1 : 1); break;
                case Direction.up: currentRow += (increment ? -1 : 1); break;
            }
        }

        bool IsBoundsValid()
        {
            if (currentRow >= maxDepth)
            {
                currentRow = maxDepth - 1;
                return false;
            }
            
            if (currentColumn >= maxLength)
            {
                currentColumn = maxLength - 1;
                return false;
            }
            
            if (currentRow < 0)
            {
                currentRow = 0;
                return false;
            }
            
            if (currentColumn < 0)
            {
                currentColumn = 0;
                return false;
            }

            return true;
        }
        
        return output.ToArray();
    }

    private static Direction GetNextDirection(Direction currentDirection)
    {
        switch (currentDirection)
        {
            case Direction.right: return Direction.down;
            case Direction.down: return Direction.left;
            case Direction.left: return Direction.up;
            case Direction.up: return Direction.right;
            default:
                throw new ArgumentOutOfRangeException(nameof(currentDirection), currentDirection, null);
        }
    }

    enum Direction{ right, down, left, up }
}