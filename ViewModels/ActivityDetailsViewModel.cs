using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CoverYourAss.Models;
using CoverYourAss.Services;

namespace CoverYourAss.ViewModels
{
    public class ActivityDetailsViewModel : ObservableObject
    {
        private Activity _activityToEdit;
        private ActivityDataService _dataService;

        public Activity ActivityToEdit
        {
            get => _activityToEdit;
            set => SetProperty(ref _activityToEdit, value);
        }

        public IRelayCommand SaveActivityCommand { get; }
        public IRelayCommand DeleteActivityCommand { get; }
        public IRelayCommand CancelCommand { get; }

        public ActivityDetailsViewModel()
        {
            _dataService = ActivityDataService.Instance;

            SaveActivityCommand = new RelayCommand(SaveActivity);
            DeleteActivityCommand = new RelayCommand(DeleteActivity);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void SaveActivity()
        {
            // Save the activity
        }

        private void DeleteActivity()
        {
            // Delete the activity
            _dataService.Activities.Remove(ActivityToEdit);
        }

        private void Cancel()
        {
            // Cancel the edit and navigate back
        }
    }
}