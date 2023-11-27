using CoverYourAss.Models;
using Task = CoverYourAss.Models.Task;

namespace CoverYourAss;

public partial class TaskPage : ContentPage
{
    private Task _task;

    public TaskPage(Task task = null)
    {
        InitializeComponent();

        _task = task ?? new Task();
        BindingContext = _task;
    }

    private async void SaveTaskClicked(object sender, EventArgs e)
    {
        if (_task.Id == 0)
        {
            DataService.Instance.Tasks.Add(_task);
        }

        await Navigation.PopAsync();
    }
}