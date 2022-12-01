using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using NegosudClient.Components.Admin;

namespace NegosudClient.Components
{
    public class MainViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        UserControl Connection { get; set; }
        UserControl Inscription { get; set; }
        UserControl Admin { get; set; }

        UserControl _view;
        public UserControl View { get
            {
                return _view;
            }
            set {
                _view = value;
                OnPropertyRaised("View");
            }
        }
        public RelayCommand connect { get; set; }
        public RelayCommand signup { get; set; }
        public RelayCommand admin { get; set; }
        public MainViewModel()
        {
            Connection = new Connection();
            Inscription = new Inscription();
            Admin = new AdminView();

            View = Connection;
            connect = new RelayCommand(o => { View = Connection; }, o=>true);
            signup = new RelayCommand(o => { View = Inscription; }, o => true);
            admin = new RelayCommand(o => { View = Admin; }, o => true);
        }



      
        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
