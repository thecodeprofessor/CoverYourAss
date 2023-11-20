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
        var newTask = new Task { Name = Name.Text, Description = Description.Text };
        //Save the task logic here.

        await Navigation.PopAsync();
    }
}