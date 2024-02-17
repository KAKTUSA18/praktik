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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для регистрация.xaml
    /// </summary>
    public partial class регистрация : Window
    {
        public регистрация()
        {
            InitializeComponent();
        }

         private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow win = new MainWindow();
            win.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            личный_аккаунт win = new личный_аккаунт();
            win.Show();

            var imya = imyas.Text;
            var login = Logins.Text;
            var password = Passwords.Text;

            var context = new AppDbContext();

            var user_exists = context.Users.FirstOrDefault(x => x.Login == login);
            if (user_exists is not null)
            {
                MessageBox.Show("Такой пользователь уже зарегистрирован");
                return;
            }

            var user = new User { Imya = imya, Login = login, Password = password };
            context.Users.Add(user);
            context.SaveChanges();
            MessageBox.Show("Вы успешно зарегистрированы");

            App.Current.Resources["TextTest"] = imyas.Text;
            NavigationService.GetNavigationService(this).Navigate(new Uri("/регистрация/личный аккаунт.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
