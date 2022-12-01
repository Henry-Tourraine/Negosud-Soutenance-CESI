using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NegosudClient.Components.Admin.Utilisateur.Subcomponents
{
    /// <summary>
    /// Interaction logic for ComboUtilisateur.xaml
    /// </summary>
    public partial class ComboItem : UserControl, INotifyPropertyChanged
    {
        public List<string> Properties = new List<string>
        {
            "Prenom",
            "Nom",
            "Email"
        };

        private string? selectedItem;
        public string SelectedItem {
            get
            {
                return selectedItem;
            }
            set {
                selectedItem = value;
                OnPropertyChanged();
            } 
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void ComboBox_SelectionChanged(object sender, EventArgs e)
        {
            SelectedItem = (string)ComboBox1.SelectedItem;
            MessageBox.Show(SelectedItem);
        }
        
        public ComboItem()
        {
            InitializeComponent();
            ComboBox1.ItemsSource = Properties;
        }
    }
}
