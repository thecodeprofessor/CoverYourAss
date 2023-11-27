using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using CoverYourAss.Models;
using Task = CoverYourAss.Models.Task;

namespace CoverYourAss.Services
{
    public class DataService
    {
        // Singleton instance
        private static DataService _instance;

        // Property to access the singleton instance
        public static DataService Instance => _instance ??= new DataService();

        // The ObservableCollection of tasks
        public ObservableCollection<Task> Tasks { get; private set; }

        // Private field to keep track of the last id
        private int _lastId = 0;

        // Private constructor to prevent external instantiation
        private DataService()
        {
            Tasks = new ObservableCollection<Task>();
            Tasks.CollectionChanged += Tasks_CollectionChanged; // Subscribe to CollectionChanged event

            // Initialize with sample data
            LoadSampleTasks();
        }

        private void Tasks_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Check if new items were added
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                // Find all items that have an id of 0 and set the id to the next id
                foreach (Task task in e.NewItems)
                {
                    task.Id = ++_lastId;
                }
            }
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
