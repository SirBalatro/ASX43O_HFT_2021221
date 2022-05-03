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
    public class CharacterViewModel : ObservableRecipient
    {
        public RestCollection<PlayerCharacter> Characters { get; set; }
        public ICommand CreateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }

        private PlayerCharacter selectedCharacter;
        public PlayerCharacter SelectedCharacter
        {
            get { return selectedCharacter; }
            set 
            {
                if (value != null)
                {
                    selectedCharacter = new PlayerCharacter()
                    {
                        Id = value.Id,
                        Name = value.Name,
                        RaceId = value.RaceId,
                        ClassId = value.ClassId,
                        CharacterLevel = value.CharacterLevel
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

        public CharacterViewModel()
        {
            if (!IsInDesignMode)
            {
                Characters = new RestCollection<PlayerCharacter>("http://localhost:8797/", "PlayerCharacter", "hub");

                //Characters.CollectionChanged += (sender, eventargs) => this.OnPropertyChanged();

                CreateCommand = new RelayCommand(() =>
                {
                    Characters.Add(new PlayerCharacter() 
                    { 
                        Name = selectedCharacter.Name, 
                        CharacterLevel = selectedCharacter.CharacterLevel, 
                        ClassId = selectedCharacter.ClassId, 
                        RaceId = selectedCharacter.RaceId 
                    });
                });
                UpdateCommand = new RelayCommand(() =>
                {
                    Characters.Update(SelectedCharacter);
                },
                () =>
                {
                    return SelectedCharacter != null;
                });
                DeleteCommand = new RelayCommand(() =>
                {
                    Characters.Delete(SelectedCharacter.Id);
                },
                () =>
                {
                    return SelectedCharacter != null;
                });
            }
        }
    }
}
