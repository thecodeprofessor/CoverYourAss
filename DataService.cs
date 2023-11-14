using System.Collections.ObjectModel;

namespace CoverYourAss
{
    public class DataService
    {
        // Singleton instance
        private static DataService _instance;

        // Property to access the singleton instance
        public static DataService Instance => _instance ??= new DataService();

        // The ObservableCollection of tasks
        public ObservableCollection<Task> Tasks { get; private set; }

        // Private constructor to prevent external instantiation
        private DataService()
        {
            Tasks = new ObservableCollection<Task>();
            // Initialize with sample data
            LoadSampleTasks();
        }

        private void LoadSampleTasks()
        {
            Tasks.Add(new Task { Name = "Task 1", Description = "Description for Task 1" });
            Tasks.Add(new Task { Name = "Task 2", Description = "Description for Task 2" });
            Tasks.Add(new Task { Name = "Task 3", Description = "Description for Task 3" });
            Tasks.Add(new Task { Name = "Task 4", Description = "Description for Task 4" });
            Tasks.Add(new Task { Name = "Task 5", Description = "Description for Task 5" });
        }
    }
}