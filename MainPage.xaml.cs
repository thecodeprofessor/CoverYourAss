using System.Collections.ObjectModel;

namespace CoverYourAss
{
    // MainPage class of the application, inheriting from ContentPage.
    public partial class MainPage : ContentPage
    {
        // A collection that can be observed for changes. Used here to hold Task items.
        public ObservableCollection<Task> Tasks { get; set; }

        // Constructor for MainPage.
        public MainPage()
        {
            // Initializes the page components.
            InitializeComponent();

            // Initialize the Tasks collection.
            Tasks = new ObservableCollection<Task>();

            // Add sample tasks to the Tasks collection.
            Tasks.Add(new Task { Name = "Task 1", Description = "Description for Task 1" });
            Tasks.Add(new Task { Name = "Task 2", Description = "Description for Task 2" });
            Tasks.Add(new Task { Name = "Task 3", Description = "Description for Task 3" });
            Tasks.Add(new Task { Name = "Task 4", Description = "Description for Task 4" });
            Tasks.Add(new Task { Name = "Task 5", Description = "Description for Task 5" });

            // Set the source of data for the TasksCollectionView to the Tasks collection.
            TasksCollectionView.ItemsSource = Tasks;
        }

        // Event handler for the Add button click.
        private async void OnAddButtonClicked(object sender, EventArgs e)
        {
            // Navigate to the TaskPage when the Add button is clicked.
            //await Navigation.PushAsync(new TaskPage());
        }
    }
}