using System.Collections.ObjectModel;

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
    }
}