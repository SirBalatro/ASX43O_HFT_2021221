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
    public class MainWindowViewModel : ObservableRecipient
    {
        public ICommand SelectCharacterViewCommand { get; set; }
        public ICommand SelectRaceViewCommand { get; set; }
        public ICommand SelectClassViewCommand { get; set; }

        public CharacterViewModel CharView { get; set; }
        public RaceViewModel RaceView { get; set; }
        public ClassViewModel ClassView { get; set; }

        private object currentView;

        public object CurrentView
        {
            get { return currentView; }
            set
            {
                SetProperty(ref currentView, value);
                (SelectCharacterViewCommand as RelayCommand).NotifyCanExecuteChanged();
                (SelectClassViewCommand as RelayCommand).NotifyCanExecuteChanged();
                (SelectRaceViewCommand as RelayCommand).NotifyCanExecuteChanged();
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

        public MainWindowViewModel()
        {
            CharView = new CharacterViewModel();
            RaceView = new RaceViewModel();
            ClassView = new ClassViewModel();

            this.CharView.Characters.CollectionChanged += (sender, eventargs) => this.OnPropertyChanged();
            this.RaceView.Races.CollectionChanged += (sender, eventargs) => this.OnPropertyChanged();
            this.ClassView.Classes.CollectionChanged += (sender, eventargs) => this.OnPropertyChanged();

            if (!IsInDesignMode)
            {
            }

            SelectCharacterViewCommand = new RelayCommand(() =>
            {
                CurrentView = CharView;
            },
            () => currentView != CharView);
            SelectClassViewCommand = new RelayCommand(() =>
            {
                CurrentView = ClassView;
            },
            () => currentView != ClassView);
            SelectRaceViewCommand = new RelayCommand(() =>
            {
                CurrentView = RaceView;
            },
            () => currentView != RaceView);
        }
    }
}
