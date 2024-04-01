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

        Snail(array);
    }
    
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