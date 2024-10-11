using System;
using System.Collections.Generic;
using System.Linq;
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

namespace AshurovRoman_DataUser.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListViewUser.xaml
    /// </summary>
    public partial class ListViewUser : Page
    {
        
        public ListViewUser()
        {
            InitializeComponent();
            ListUser.ItemsSource = Data.DataUserEntities.GetContext().User.ToList();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.AddEditUser(null));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.AddEditUser((sender as Button).DataContext as Data.User));
        }
    }
}
