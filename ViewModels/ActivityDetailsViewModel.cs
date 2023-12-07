using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CoverYourAss.Models;
using CoverYourAss.Services;

namespace CoverYourAss.ViewModels
{
    public class ActivityDetailsViewModel : ObservableObject, IQueryAttributable
    {
        protected static DataServiceSQLite Database => DataServiceSQLite.Instance;

        private Activity _activity;
        public Activity Activity
        {
            get { return _activity; }
            set
            {
                _activity = value;
                OnPropertyChanged(nameof(Activity));
            }
        }

        public IAsyncRelayCommand SaveCommand { get; }
        public IAsyncRelayCommand DeleteCommand { get; }
        public IAsyncRelayCommand CancelCommand { get; }

        public ActivityDetailsViewModel()
        {
            SaveCommand = new AsyncRelayCommand(Save);
            DeleteCommand = new AsyncRelayCommand(Delete);
            CancelCommand = new AsyncRelayCommand(Cancel);
        }

        private async Task Save()
        {
            await Database.SaveAsync<Activity>(_activity);
            await Shell.Current.GoToAsync($"///{nameof(Views.ActivityListView)}");
        }

        private async Task Delete()
        {
            await Database.DeleteAsync<Activity>(_activity);
            await Shell.Current.GoToAsync($"///{nameof(Views.ActivityListView)}");
        }

        private async Task Cancel()
        {
            await Shell.Current.GoToAsync($"///{nameof(Views.ActivityListView)}");
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (!query.ContainsKey("id"))
                return;

            var id = Convert.ToInt32(query["id"].ToString());
            GetActivity(id);
        }

        private async void GetActivity(int id)
        {
            _activity = await Database.GetAsync<Activity>(id);
            OnPropertyChanged(nameof(Activity));
        }
    }
}