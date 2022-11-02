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
        private IMockService _iMockService;

        public ArrangerViewModel(IMockService iMockService)
        {
            _iMockService = iMockService;
            Events = new ObservableCollection<string>();
        }

        [ObservableProperty]
        ObservableCollection<string> events;

        [ObservableProperty]
        string name;

        void Initialize()
        {
            foreach (Event item in _iMockService.Events)
            {

            }
        }

        [ICommand]
        void Delete(string s)
        {
            if (Events.Contains(s))
            {
                Events.Remove(s);
            }
        }

    }
}
