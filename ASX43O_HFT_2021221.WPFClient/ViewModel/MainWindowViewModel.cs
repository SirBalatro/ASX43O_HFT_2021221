using ASX43O_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ASX43O_HFT_2021221.WPFClient.ViewModel
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<PlayerCharacter> Players { get; set; }

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
            if (!IsInDesignMode)
            {
                Players = new RestCollection<PlayerCharacter>("http://localhost:8797/", "PlayerCharacter");
            }
        }
    }
}
