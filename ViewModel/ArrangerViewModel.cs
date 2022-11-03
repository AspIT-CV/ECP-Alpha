using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public partial class ArrangerViewModel : ObservableObject
    {
        private IDataService _iDataService;


        public ArrangerViewModel(IDataService iDataService)
        {
            Events = new ObservableCollection<Event>();

            _iDataService = iDataService;

            _iDataService.GetAllEventsAsync();


        }

        [ObservableProperty]
        ObservableCollection<Event> events;

        [ObservableProperty]
        string name;


        [ICommand]
        void Delete(string s)
        {
            
        }

    }
}
