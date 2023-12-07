using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CoverYourAss.Models;
using CoverYourAss.Services;

namespace CoverYourAss.ViewModels
{
    public class ActivityListViewModel : ObservableRecipient
    {
        protected static DataServiceSQLite Database => DataServiceSQLite.Instance;

        public ObservableCollection<Activity> Activities { get; set; }

        public IAsyncRelayCommand GetCommand { get; }
        public IAsyncRelayCommand AddCommand { get; }
        public IAsyncRelayCommand EditCommand { get; }

        public ActivityListViewModel()
        {
            GetCommand = new AsyncRelayCommand(Get);
            AddCommand = new AsyncRelayCommand(Add);
            EditCommand = new AsyncRelayCommand<Activity>(Edit);
        }

        private async Task Get()
        {
            Activities = await Database.GetAsync<Activity>();
            OnPropertyChanged(nameof(Activities));
        }

        private async Task Add()
        {
            await Shell.Current.GoToAsync($"///{nameof(Views.ActivityDetailsView)}");
        }

        private async Task Edit(Activity activity)
        {
            await Shell.Current.GoToAsync($"///{nameof(Views.ActivityDetailsView)}?id={activity.Id}");
        }
    }
}