using NegosudClient.Components.Admin.Utilisateur;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NegosudClient.Components.Admin
{
    public class AdminViewModel : INotifyPropertyChanged
    {
        
        public UserControl Utilisateur { get; set; }
        UserControl Menu { get; set; }
        UserControl _view;
        public UserControl View
        {
            get
            {
                return _view;
            }
            set
            {
                _view = value;
                OnPropertyChanged("View");
            }
        }
        public AdminViewModel()
        {
            Utilisateur = new NegosudClient.Components.Admin.Utilisateur.LayoutItem();
            Menu = new NegosudClient.Components.Admin.Menu();
            View = Utilisateur;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        public void DisplayUtilisateur(object sender, RoutedEventArgs e)
        {
            View = Utilisateur;
        }

    }
}
