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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            

            var imya = imyas.Text;
            var login = logins.Text;
            var password = passwords.Text;

            var context = new AppDbContext();

            var user = context.Users.FirstOrDefault(x => x.Login == login && x.Password == password);
            if (user is null)
            {
                MessageBox.Show("Неправильный пароль или логин!");
                return;
                    
            }
            else
            {
                MessageBox.Show("Вы успешно вошли в аккаунт!");
                this.Hide();
                личный_аккаунт win = new личный_аккаунт();
                win.Show();
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            регистрация win = new регистрация();
            win.Show();
        }
    }
}
