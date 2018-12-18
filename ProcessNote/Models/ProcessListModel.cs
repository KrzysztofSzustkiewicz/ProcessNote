using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Threading;

namespace ProcessNote.Models

{
    public class ProcessListModel : ObservableObject
    {
        private ObservableCollection<SingleProcess> singleProcessesList;
        private Process[]  Processes { get; set; }

        private DispatcherTimer Timer { get; set; }


        public ProcessListModel()
        {
            Processes = Process.GetProcesses();
            ListCurrentProcesses();
            Timer = new DispatcherTimer {Interval = new TimeSpan(0, 0, 0, 5)};
            Timer.Tick += ListCurrentProcessesHandler;
            Timer.Start();  
        }


        public ObservableCollection<SingleProcess> SingleProcessesList
        {
            get => singleProcessesList;
            private set
            {
                singleProcessesList = value;
                OnPropertyChanged("SingleProcessesList");
            }
        }


        private void GetProcesses()
        {
            Processes = Process.GetProcesses();
        }
        
        
        private void ListCurrentProcessesHandler(object sender, EventArgs e)
        {
            ListCurrentProcesses();
        }


        private void ListCurrentProcesses()
        {
            GetProcesses();
            var currentProcessesList = new ObservableCollection<SingleProcess>();
            foreach (var process in Processes)
            {
                currentProcessesList.Add(new SingleProcess(process));
            }
            SingleProcessesList = currentProcessesList;
        }  
    }
}