using HammerHacks2024Project.Models;
using HammerHacks2024Project.ViewModels;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using Windows.UI.WebUI;

namespace HammerHacks2024Project.Views;

public partial class ScheduleListView : ContentPage
{

    private bool _isPanelTranslated;
    public ScheduleListView()
    {
        InitializeComponent();
        this.BindingContext = new ScheduleListViewModel();

        panelLeft.TranslateTo(-80, 0, 150);
    }

    private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        var viewModel = (ScheduleListViewModel)BindingContext;
        viewModel.BindDataToScheduleList();
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (_isPanelTranslated)
        {
            panelLeft.TranslateTo(-80, 0, 150);
        }
        else
        {
            panelLeft.TranslateTo(0, 0, 150);
        }

        _isPanelTranslated = !_isPanelTranslated;
    }

    async void Button_Clicked(object sender, EventArgs args)
    {
        Entry titleEntry = new Entry { Text ="Event Title"};
        Entry bodyEntry = new Entry { Text = "Event Description" };
        Entry noteEntry = new Entry { Text = "Enter Notes" };
        VerticalStackLayout layout = new VerticalStackLayout { titleEntry, bodyEntry, noteEntry };
        Frame frame = new Frame { Content = layout };
        ScheduleModel newScheduleItem = new ScheduleModel
        {
            Title = titleEntry.Text,
            Description = bodyEntry.Text,
            Location = noteEntry.Text,
            StartDateTime = ((ScheduleListViewModel)BindingContext).CurrentDate,
            EndDateTime = ((ScheduleListViewModel)BindingContext).CurrentDate,
            BackgroundColor = Color.FromArgb("#9a6ead")
        };


        ((ScheduleListViewModel)BindingContext).AddScheduleItem(newScheduleItem);
    }
}