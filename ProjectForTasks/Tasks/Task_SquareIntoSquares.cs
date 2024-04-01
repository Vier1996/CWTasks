using System.Numerics;
using System.Text;
using ProjectForTasks.Analyzer;

namespace ProjectForTasks.Tasks
{
    // Given a positive integral number n,
    // return a strictly increasing sequence (list/array/string depending on the language) of numbers,
    // so that the sum of the squares is equal to n².

    // If there are multiple solutions (and there will be),
    // return as far as possible the result with the largest possible values:
    
    public class Task_SquareIntoSquares : AbstractTask
    {
        public override void Execute()
        {
            long n = 50000;
            
            ExecutionWatcher.Start();
            string answer = Decompose(n);
            ExecutionWatcher.Stop();
            
            ExecutionWatcher.GetInfo();
            
            Console.WriteLine(answer);
        }
        
        private string Decompose(long n)
        {
            if (n >= 1 && n < 6)
                return "Nothing";

            bool answerFound = false;
            int additionDecrement = 1;
            StringBuilder answerBuilder = new StringBuilder();
            List<int> pickedIndexes = new List<int>();

            while (!answerFound)
            {
                long baseSquare = n * n;

                pickedIndexes.Clear();

                for (int i = (int)n - 1 - additionDecrement; i >= 0; i--)
                {
                    long currentPow = (i + 1) * (i + 1);

                    if (currentPow <= baseSquare)
                    {
                        baseSquare -= currentPow;
                        pickedIndexes.Add(i);
                    }
                }

                if (additionDecrement == n - 1)
                    return "Nothing";

                if (baseSquare == 0 && pickedIndexes.Contains(0))
                    answerFound = true;

                additionDecrement++;
            }

            pickedIndexes.Reverse();

            foreach (int index in pickedIndexes)
            {
                answerBuilder.Append($"{index + 1} ");
            }

            return answerBuilder.ToString().Trim();
        }
    }
}