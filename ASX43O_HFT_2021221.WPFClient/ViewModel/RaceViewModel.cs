using ASX43O_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ASX43O_HFT_2021221.WPFClient.ViewModel
{
    public class RaceViewModel : ObservableRecipient
    {
        public RestCollection<PlayerRace> Races { get; set; }
        public ICommand CreateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }

        private PlayerRace selectedRace;

        public PlayerRace SelectedRace
        {
            get { return selectedRace; }
            set
            {
                if (value != null)
                {
                    selectedRace = new PlayerRace()
                    {
                        Id = value.Id,
                        Name = value.Name
                    };
                }
                OnPropertyChanged();
                (DeleteCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public RaceViewModel()
        {
            if (!IsInDesignMode)
            {
                Races = new RestCollection<PlayerRace>("http://localhost:8797/", "PlayerRace", "hub");
                CreateCommand = new RelayCommand(() =>
                {
                    Races.Add(new PlayerRace()
                    {
                        Name = SelectedRace.Name
                    });
                });
                UpdateCommand = new RelayCommand(() =>
                {
                    Races.Update(SelectedRace);
                },
                () =>
                {
                    return SelectedRace != null;
                });
                DeleteCommand = new RelayCommand(() =>
                {
                    Races.Delete(SelectedRace.Id);
                },
                () =>
                {
                    return SelectedRace != null;
                });
            }
        }
    }
}
