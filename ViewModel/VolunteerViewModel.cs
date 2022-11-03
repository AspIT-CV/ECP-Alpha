using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace ViewModel
{
    public partial class VolunteerViewModel : ObservableObject
    {
        public VolunteerViewModel()
        {
            arrangementsInNeedOfVolunteers = new ObservableCollection<string>();
        }

        [ObservableProperty]
        ObservableCollection<string> arrangementsInNeedOfVolunteers;

        [ObservableProperty]
        string text;
    }
}