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
    public class ClassViewModel : ObservableRecipient
    {
        public RestCollection<PlayerClass> Classes { get; set; }
        public ICommand CreateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }

        private PlayerClass selectedClass;

        public PlayerClass SelectedClass
        {
            get { return selectedClass; }
            set 
            {
                if(value != null) 
                {
                    selectedClass = new PlayerClass()
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

        public ClassViewModel()
        {
            if (!IsInDesignMode)
            {
                Classes = new RestCollection<PlayerClass>("http://localhost:8797/", "PlayerClass", "hub");
                CreateCommand = new RelayCommand(() =>
                {
                    Classes.Add(new PlayerClass()
                    {
                        Name = SelectedClass.Name
                    });
                });
                UpdateCommand = new RelayCommand(() =>
                {
                    Classes.Update(SelectedClass);
                },
                () =>
                {
                    return SelectedClass != null;
                });
                DeleteCommand = new RelayCommand(() =>
                {
                    Classes.Delete(SelectedClass.Id);
                },
                () =>
                {
                    return SelectedClass != null;
                });
            }
        }
    }
}
