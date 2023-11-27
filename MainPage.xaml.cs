using System.Collections.ObjectModel;
using CoverYourAss.Models;
using Task = CoverYourAss.Models.Task;

namespace CoverYourAss
{
    // MainPage class of the application, inheriting from ContentPage.
    public partial class MainPage : ContentPage
    {
        // Constructor for MainPage.
        public MainPage()
        {
            // Initializes the page components.
            InitializeComponent();

            // Access the Tasks from the DataService
            TasksCollectionView.ItemsSource = DataService.Instance.Tasks;
        }

        // Event handler for the Add button click.
        private async void OnAddButtonClicked(object sender, EventArgs e)
        {
            // Navigate to the TaskPage when the Add button is clicked.
            await Navigation.PushAsync(new TaskPage());
        }
        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the first selected item from the list of currently selected items.
            // 'as Task' is used to safely cast the selected item to the type 'Task'
            var selectedTask = e.CurrentSelection.FirstOrDefault() as Task;
            if (selectedTask != null)
            {
                // Navigate to TaskPage with the selected task details
                await Navigation.PushAsync(new TaskPage(selectedTask));
            }

            // Deselect item
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}