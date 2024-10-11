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
    /// Логика взаимодействия для AddEditUser.xaml
    /// </summary>
    public partial class AddEditUser : Page
    {
        public string Flag = "";
        public Data.User _currrentUser = new Data.User();
        public AddEditUser(Data.User _User)
        {
            InitializeComponent();
            if(_User == null)
            {
                Flag = "add";
            }
            else
            {
                Flag = "edit";
                _currrentUser = _User;
            }
            DataContext = _currrentUser;
            Init();
        }

        public void Init()
        {
            RoleBox.ItemsSource = Data.DataUserEntities.GetContext().Role.ToList();
            GenderBox.ItemsSource = Data.DataUserEntities.GetContext().Gender.ToList();
            if(Flag == "add")
            {
                Idbox.Text = Data.DataUserEntities.GetContext().User.Max(d => d.UserId+1).ToString();
                Idbox.Visibility = Visibility;
                FirstBox.Text = "";
                NameBox.Text = "";
                PatronicBox.Text = "";
                PhoneBox.Text = "";
                EmailBox.Text = "";
                LoginBox.Text = "";
                PasswordBox.Text = "";
                Password2Box.Text = "";
                RoleBox.SelectedIndex = -1;
                GenderBox.SelectedIndex = -1;

            }
            if(Flag == "edit")
            {
                FirstBox.Text = _currrentUser.UserLastName.ToString();
                NameBox.Text = _currrentUser.UserName.ToString();
                PatronicBox.Text = _currrentUser.UserFirstName.ToString();

                var selected = _currrentUser.UserRoleId;
                RoleBox.SelectedIndex = selected;

                PhoneBox.Text = _currrentUser.UserPhone.ToString();
                

                EmailBox.Text = _currrentUser.UserEmail.ToString();
                LoginBox.Text = _currrentUser.UserLogin.ToString();
                PasswordBox.Text = _currrentUser.UserPassword.ToString();
                Password2Box.Text = _currrentUser.UserPassword.ToString();
            }

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.ListViewUser());
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _currrentUser.UserFirstName = PatronicBox.Text;
            _currrentUser.UserName = NameBox.Text;
            _currrentUser.UserLastName = FirstBox.Text;

            _currrentUser.UserPhone = PhoneBox.Text;
            _currrentUser.UserEmail = EmailBox.Text;
            _currrentUser.UserLogin = LoginBox.Text;
            
            var searchRole = Data.DataUserEntities.GetContext().Role.Where(d => d.RoleName == RoleBox.Text).FirstOrDefault();
            _currrentUser.UserRoleId = searchRole.RoleId;

            var searchGender = Data.DataUserEntities.GetContext().Gender.Where(d => d.GenderName == GenderBox.Text).FirstOrDefault();
            _currrentUser.UserGenderId = searchGender.GenderId;

            _currrentUser.UserPassword = PasswordBox.Text;
            _currrentUser.UserPassport = "0";
            
                if(Flag =="add"){
                try
                {
                    Data.DataUserEntities.GetContext().User.Add(_currrentUser);
                    Data.DataUserEntities.GetContext().SaveChanges();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "fgj",MessageBoxButton.OK,MessageBoxImage.None);
                }
            }
        }
    }
}
