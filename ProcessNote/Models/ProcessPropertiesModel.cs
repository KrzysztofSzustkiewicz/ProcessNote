using System;
using System.Diagnostics;

namespace ProcessNote
{
    public class ProcessPropertiesModel
    {
        public DateTime ProcessStart { get; set; }
        private double processRamUsage { get; set; }
        private double processCPU { get; set; }
        private TimeSpan runningTime { get; set; }

        public ProcessPropertiesModel(object singleProcess)
        {
          
            var process = Process.GetProcessById(777);

            ProcessStart = process.StartTime;
            getRamUsage(process.ProcessName);
            getCPU(process.ProcessName);
            runningTime = DateTime.Now - process.StartTime;

        }

        private void getRamUsage(string processName)
        {
            PerformanceCounter ramCounter = new PerformanceCounter("Process", "Working Set", processName);
            processRamUsage = ramCounter.NextValue();
        }

        private void getCPU(string processName)
        {
            PerformanceCounter cpuCounter = new PerformanceCounter("Process", "% Processor Time", processName);
            processCPU = cpuCounter.NextValue();
        }
    }
}