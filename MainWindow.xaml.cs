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

namespace UsersApp
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

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            string login;
=======
            //записываем в строковые переменные переданные значения полей текстбоксов имя и мейл и пассвордбоксов
            string login = textBoxLogin.Text.Trim();//Trim удаляет пробелы в начале и конце строки
            string pass = passBox.Password.Trim();
            string pass_2 = passBox_2.Password.Trim();
            string email = textBoxEmail.Text.ToLower(); /*приведение мейла к нижнему регистру*/
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
            else if (pass != pass_2)
            {
                passBox_2.ToolTip = "Entered passwords do not match!";
                passBox_2.Background = Brushes.DarkRed;
            }
            //проверка email на длину, наличие знака собаки и точки
            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                textBoxEmail.ToolTip = "E-mail is incorrect!";
                textBoxEmail.Background = Brushes.DarkRed;
            }
            else //если ошибок нет, то устанавливаем все подсказки пустыми, а фон полей прозрачным
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;

                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;

                passBox_2.ToolTip = "";
                passBox_2.Background = Brushes.Transparent;

                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;

                MessageBox.Show("Everything's OK");
            }
>>>>>>> parent of 7615959... connect to DB
        }
    }
}
