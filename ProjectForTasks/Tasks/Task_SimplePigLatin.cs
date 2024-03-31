using System.Text;
using ProjectForTasks.Analyzer;

namespace ProjectForTasks.Tasks
{
    //Move the first letter of each word to the end of it, then add "ay" to the end of the word.
    //Leave punctuation marks untouched.
    
    // Examples
    //Kata.PigIt("Pig latin is cool"); // igPay atinlay siay oolcay
    //Kata.PigIt("Hello world !");     // elloHay orldway !
    
    public class Task_SimplePigLatin : AbstractTask
    {
        public override void Execute()
        {
            ExecutionWatcher.Start();
            
            string answer = PigItShort("Pig latin is cool !");

            ExecutionWatcher.Stop();
            ExecutionWatcher.GetInfo();
            
            Console.WriteLine(answer);
        }
        
        private string PigIt(string str)
        {
            StringBuilder builder = new StringBuilder();
            List<string> separatedWords = str.Split(' ').ToList();
            string specSymbols = "!";

            for (int i = 0; i < separatedWords.Count; i++)
            {
                string word = separatedWords[i];

                if (word.Contains(specSymbols))
                {
                    builder
                        .Append(word[0])
                        .Append(' ');
                    
                    continue;
                }

                builder
                    .Append(word.Substring(1, word.Length - 1))
                    .Append(word[0])
                    .Append("ay")
                    .Append(' ');
            }
            
            return builder.ToString().Substring(0, builder.Length - 1);
        }

        private string PigItShort(string str)
        {
            return string.Join(" ", str.Split(' ').Select(w => w.Any(char.IsPunctuation) ? w : w.Substring(1) + w[0] + "ay"));
        }
    }
}