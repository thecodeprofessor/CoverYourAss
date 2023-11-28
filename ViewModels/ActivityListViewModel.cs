using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CoverYourAss.Models;
using CoverYourAss.Services;
using System.Collections.ObjectModel;

namespace CoverYourAss.ViewModels
{
    public class ActivityListViewModel : ObservableRecipient
    {
        private ActivityDataService _dataService;
        private Activity _selectedActivity;

        public ObservableCollection<Activity> Activities => _dataService.Activities;

        public Activity SelectedActivity
        {
            get => _selectedActivity;
            set
            {
                if (SetProperty(ref _selectedActivity, value))
                {
                    // Automatically navigate to the Edit Activity view when an activity is selected
                    GoToEditActivityCommand.Execute(value);
                }
            }
        }

        public IRelayCommand GoToAddActivityCommand { get; }
        public IRelayCommand GoToEditActivityCommand { get; }

        public ActivityListViewModel()
        {
            _dataService = ActivityDataService.Instance;

            GoToAddActivityCommand = new RelayCommand(GoToAddActivity);
            GoToEditActivityCommand = new RelayCommand<Activity>(GoToEditActivity);
        }

        private void GoToAddActivity()
        {
            // Navigate to the Add Activity view
        }

        private void GoToEditActivity(Activity activity)
        {
            // Navigate to the Edit Activity view with the selected activity
        }
    }
}