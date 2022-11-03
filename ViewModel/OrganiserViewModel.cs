using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Entities;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public partial class OrganiserViewModel : ObservableObject
    {
        private IDataService _iDataService;


        public OrganiserViewModel(IDataService iDataService)
        {
            _iDataService = iDataService;
        }

        [ObservableProperty]
        ObservableCollection<Event> events;

        [ObservableProperty]
        ObservableCollection<string> items;

        [ICommand]
        void Delete(string s)
        {
            if (Items.Contains(s))
            {
                Events.Remove(Events.Where(e => e.Name == s).Single());
                Items.Remove(s);
            }
        }

        public async Task Initialize()
        {
            Events = await _iDataService.GetAllEventsAsync();
        }

    }
}
