using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using NegosudClient.Components.Admin.Utilisateur.Subcomponents;
using NegosudClient.Components.Admin;
using System.Windows.Controls.Primitives;
using NegosudClient;
using System.Windows.Input;
using NegosudClient.Services;
using NegosudAPI.Utils.DTO;
using System.Collections.ObjectModel;

namespace NegosudClient.Components.Admin.Utilisateur
{
    public class LayoutItemModelView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public UserControl FormUpdate { get; set; }
        public UserControl FormCreate { get; set; }
        public UserControl Combobox { get; set; }

        public Validation  Pop = new();

        public Action PendingFunc=null;

        public UserControl ButtonItem { get; set; }

        private UserControl? view_;
        public UserControl View { 
                get
                {
                    return view_;
                }
                set
                {
                    view_ = value;
                    OnPropertyChanged();
                }
            }

        public Client<UtilisateurDTO, string> Client { get; set; }

        public UtilisateurDTO Utilisateur { get; set; }
        public ObservableCollection<UtilisateurDTO> Utilisateurs= new ObservableCollection<UtilisateurDTO>() { new UtilisateurDTO{ Admin = false, Email = "fgfd@fgd.fr", Nom = "dgdf", Prenom = "ssfdfsddf", Mod = DateTime.Now, Password = "dgdfgdf" } };
        private LayoutItemModelView()
        {
            //client to join API
            Client = new("/Utilisateur");

            //Fill list for testing list display
MessageBox.Show(Utilisateurs.Count.ToString());
            
            //INITIALIZE BUTTONS FOR TOGGLING  BETWEEN TWO FORMS
            ButtonItem = new ButtonItem();
            var b = (RadioButton)ButtonItem.FindName("Create");
            b.Click += (sender, args) =>
            {
                Utilisateurs.Add(new UtilisateurDTO { Admin = false, Email = "fgfd@fgd.fr", Nom = "dgdf", Prenom = "ssfdfsddf", Mod = DateTime.Now, Password = "dgdfgdf" });

            };
            b.IsChecked = true;
            

            var c = (RadioButton)ButtonItem.FindName("Update");
            c.Click += ToggleToUpdate;
            

            //POPUP VALIDATION
             var d = (Button)Pop.FindName("Oui");
            d.Click += (object sender, RoutedEventArgs e) => { CallPendingFunc(); Pop.Hide(); };
            var e = (Button)Pop.FindName("Non");
            e.Click += (object sender, RoutedEventArgs e) => { PendingFunc=null; Pop.Hide(); };

            //FORMS
            FormCreate = new FormItemCreate();
            FormUpdate = new FormItemUpdate();
            Combobox = new ComboItem();
            View = FormCreate;

            //FORMS HANDLING
            var FormCreateButtonSubmit = (Button)FormCreate.FindName("submit_");
           
            var FormUpdateButtonSubmit = (Button)FormUpdate.FindName("submit_");
            var FormUpdateButtonDelete = (Image)FormUpdate.FindName("Delete");

            var ComboButton = (Button)Combobox.FindName("submit_");

            FormCreateButtonSubmit.Click += (object sender, RoutedEventArgs e) =>
            {
                PendingFunc = async() => {
                    await Client.GenericCreate(Utilisateur);
                };
                Pop.Show();
            };

            FormUpdateButtonSubmit.Click += (object sender, RoutedEventArgs e) =>
            {
                PendingFunc = () => { };
                Pop.Show();
            };
            FormUpdateButtonDelete.MouseDown += ( object sender, MouseButtonEventArgs e) =>
            {
                PendingFunc = () => { };
                Pop.Show();
            };
            ComboButton.Click += (object sender, RoutedEventArgs e) =>
            {
                PendingFunc = () => { };
                Pop.Show();
            };


        }
        private static LayoutItemModelView? _instance;
        public static LayoutItemModelView GetInstance() {
            if(_instance == null)
            {
               var e = new LayoutItemModelView();
                _instance = e;
                return e;
            }
            else
            {
                return _instance;
            }
        }

        private void CallPendingFunc()
        {
            if(PendingFunc != null)
            {
                PendingFunc();
                PendingFunc = null;
            }
        }

        private void ToggleToCreate(object sender, RoutedEventArgs e)
        {
            View = FormCreate;
            
            Pop.Show();
        }
        private void ToggleToUpdate(object sender, RoutedEventArgs e)
        {
            View = FormUpdate;
        }

     

        private void OnPropertyChanged([CallerMemberName] string propertyname=null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
