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
        private IEventService<Event> _iEventService;


        public OrganiserViewModel(IEventService<Event> iEventService)
        {
            _iEventService = iEventService;
            Events = new();
        }

        [ObservableProperty]
        ObservableCollection<Event> events;

        [ObservableProperty]
        ObservableCollection<Assignment> assignments;

        [ObservableProperty]
        string text;

        [ICommand]
        async Task Search()
        {
            try
            {
                Events.Clear();
                var tempEvents = await _iEventService.GetEventsByOrganiserAsync(int.Parse(Text));
                Text = string.Empty;
                tempEvents.ForEach(@event => Events.Add(@event));
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        [ICommand]
        async Task Details(int assignmentId)
        {

        }

        [ICommand]
        async Task Delete(int eventId)
        {
            try
            {
                Text = await _iEventService.DoHttpDeleteRequest($"Event/{eventId}");
                Events.Remove(Events.Single(s => s.EventId == eventId));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Initialize()
        {
            List<Event> tempEvents = await _iEventService.GetAllEventsAsync();
            tempEvents.ForEach(@event => Events.Add(@event));
            //tempEvents.ForEach(@event => Assignments.Add(@event.Assignments.Single()));
        }

    }
}
