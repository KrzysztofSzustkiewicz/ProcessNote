using System.Collections.ObjectModel;
using System.ComponentModel;
using ProcessNote.Models;


namespace ProcessNote
{
    public class ViewModel : ObservableObject
    {
        private ProcessListModel ProcessListModel { get; set; } 
        private ObservableCollection<SingleProcess> currentProcesses = new ObservableCollection<SingleProcess>();


        public ViewModel()
        {
            ProcessListModel = new ProcessListModel();
            CurrentProcesses = ProcessListModel.SingleProcessesList;
            ProcessListModel.PropertyChanged += EventHandler;
        }
        

        public ObservableCollection<SingleProcess> CurrentProcesses
        {
            get => currentProcesses;

            set
            {
                currentProcesses = value;
                OnPropertyChanged("CurrentProcesses");
                
            }
        }

        private void EventHandler(object sender, PropertyChangedEventArgs e)
        {
            CurrentProcesses = ProcessListModel.SingleProcessesList;
        }
        
    }
}