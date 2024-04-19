using System.Numerics;
using System.Text;
using ProjectForTasks.Analyzer;

namespace ProjectForTasks.Tasks
{
    public class Task_AddingBigNumbers : AbstractTask
    {
        public override void Execute()
        {
            ExecutionWatcher.Start();
            Add("44213235", "44213235");
            ExecutionWatcher.Stop();
            ExecutionWatcher.GetInfo();

            //Console.WriteLine(Add("44213235", "25"));
        }
        
        private string Add(string a, string b)
        {
            BigInteger aInteger = BigInteger.Parse(a);
            BigInteger bInteger = BigInteger.Parse(b);
            
            return (aInteger + bInteger).ToString();
        }
        
        private string AddFaster(string a, string b)
        {
            var reverseResult = new StringBuilder();
            int aLength = a.Length, bLength = b.Length, length = aLength > bLength ? aLength : bLength, carry = 0;
            a = a.PadLeft(length, '0');
            b = b.PadLeft(length, '0');
    
            for (var index = length - 1; index >= 0; index--)
            {
                var sum = carry + a[index] - 48 + b[index] - 48;
                reverseResult.Append(sum % 10);
                carry = sum / 10;
            }
    
            if (carry > 0)
            {
                reverseResult.Append(1);
            }
    
            var result = reverseResult.ToString().ToCharArray();
    
            Array.Reverse(result);
    
            return String.Join(String.Empty, result);
        }
    }
}
