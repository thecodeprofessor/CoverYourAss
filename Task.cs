// Importing the CommunityToolkit.Mvvm.ComponentModel namespace
using CommunityToolkit.Mvvm.ComponentModel;

// Defining the namespace for the current code
namespace CoverYourAss
{
    // The Task class represents each task. This is our blueprint of what a task is.
    // The Task class inherits from the ObservableObject class, which is part of the MVVM Toolkit.
    // ObservableObject provides an implementation of the INotifyPropertyChanged interface, 
    // which is used to notify that a property has been changed and thus to update the UI.
    public class Task : ObservableObject
    {
        // Private fields to hold the values of Name and Description
        private int _id;
        private string _name;
        private string _description;

        // Public properties for Name and Description
        // These properties are using the SetProperty method (inherited from ObservableObject)
        // SetProperty will update the field value and raise the PropertyChanged event if the value has changed.
        // This ensures the UI is updated to reflect the new values.
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }
    }
}