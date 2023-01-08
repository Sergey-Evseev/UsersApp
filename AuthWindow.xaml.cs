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
using System.Windows.Shapes;

namespace UsersApp
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();

            //проверки 
            if (login.Length < 5) //если введенный логин меньше 5 символов (или не введен вовсе)
            {
                textBoxLogin.ToolTip = "Login is too short!"; //вывести соответствующее сообщение 
                textBoxLogin.Background = Brushes.DarkRed; //через класс Brushes меняем цвет фона
            }
            else if (pass.Length < 5)
            {
                passBox.ToolTip = "Password is too short!"; //вывести соответствующее сообщение 
                passBox.Background = Brushes.DarkRed; //через класс Brushes меняем цвет фона
            }
            else //установка полей пустыми при корректном вводе 
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;

                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;

                User authUser = null;
                using (ApplicationContext db = new ApplicationContext())
                {
                    authUser = db.Users.Where(b => b.Login == login && b.Pass == pass).FirstOrDefault();
                }
                if (authUser != null) //если user найден 
                    MessageBox.Show("Everything's OK!", "Success");
                else //если совпадения не найдены
                    MessageBox.Show("Incorrect credentials!", "Error", MessageBoxButton.OK, 
                        (MessageBoxImage)MessageBoxImage.Error );
            }
        }
    }
}
