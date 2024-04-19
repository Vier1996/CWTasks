using System.Net;
using ProjectForTasks.Analyzer;

namespace ProjectForTasks.Tasks
{
    /*This address has 4 octets where each octet is a single byte (or 8 bits).

    1st octet 128 has the binary representation: 10000000
    2nd octet 32 has the binary representation: 00100000
    3rd octet 10 has the binary representation: 00001010
    4th octet 1 has the binary representation: 00000001
    So 128.32.10.1 == 10000000.00100000.00001010.00000001

    Because the above IP address has 32 bits, we can represent it as the unsigned 32 bit number: 2149583361

    Complete the function that takes an unsigned 32 bit number and returns a string representation of its IPv4 address.*/
    
    // EXAMPLES
    // 2149583361 ==> "128.32.10.1"
    // 32         ==> "0.0.0.32"
    // 0          ==> "0.0.0.0"
    
    public class Task_int32toIPv4 : AbstractTask
    {
        public override void Execute()
        {
            ExecutionWatcher.Start();
            UInt32ToIP2(2149583361);
            ExecutionWatcher.Stop();

            ExecutionWatcher.GetInfo();
        }
        
        private string UInt32ToIP(uint ip) => 
            BitConverter
                .GetBytes(ip)
                .Reverse()
                .Aggregate("", (current, @byte) => current + $"{@byte}.")
                .TrimEnd('.');
        
        public static string UInt32ToIP2(uint ip) => $"{IPAddress.Parse(ip.ToString())}";
    }
}
