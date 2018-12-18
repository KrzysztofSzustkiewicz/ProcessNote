using System.Diagnostics;

namespace ProcessNote
{
    public class SingleProcess
    {
        public int ProcessId { get; set; }
        public string ProcessName { get; set; }


        public SingleProcess(Process process)
        {
            ProcessId = process.Id;
            ProcessName = process.ProcessName;
        }
    }
    
    
}