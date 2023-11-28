using System.Collections.ObjectModel;
using System.Collections.Specialized;
using CoverYourAss.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CoverYourAss.Services
{
    public class ActivityDataService : ObservableObject
    {
        private static ActivityDataService _instance;
        private int _lastId = 0;

        public static ActivityDataService Instance => _instance ??= new ActivityDataService();

        public ObservableCollection<Activity> Activities { get; private set; }

        private ActivityDataService()
        {
            Activities = new ObservableCollection<Activity>();
            Activities.CollectionChanged += Activities_CollectionChanged;

            LoadSampleActivities();
        }

        private void Activities_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Activity activity in e.NewItems)
                {
                    activity.Id = ++_lastId;
                }
            }
        }

        private void LoadSampleActivities()
        {
            for (var i = 1; i <= 5; i++)
            {
                Activities.Add(new Activity { Name = $"Activity {i}", Description = $"Description for Activity {i}", Icon = $"Icon{i}" });
            }
        }

        public void AddActivity(Activity activity)
        {
            Activities.Add(activity);
        }

        public void UpdateActivity(Activity activity)
        {
            var existingActivity = Activities.FirstOrDefault(a => a.Id == activity.Id);
            if (existingActivity != null)
            {
                // Update properties of the existing activity
                existingActivity.Name = activity.Name;
                existingActivity.Description = activity.Description;
                existingActivity.Icon = activity.Icon;
            }
        }

        public void DeleteActivity(Activity activity)
        {
            Activities.Remove(activity);
        }
    }
}
