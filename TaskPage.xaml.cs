namespace CoverYourAss;

public partial class TaskPage : ContentPage
{
    public TaskPage()
    {
        InitializeComponent();
    }

    private async void SaveTaskClicked(object sender, EventArgs e)
    {
        var newTask = new Task { Name = Name.Text, Description = Description.Text };
        //Save the task logic here.

        await Navigation.PopAsync();
    }
}