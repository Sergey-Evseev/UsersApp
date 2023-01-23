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
using System.Windows.Media.Animation;

namespace UsersApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db; //создаем ссылку на объект класса
        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext(); //выделение памяти под объект класса 

            //объект класса анимации
            DoubleAnimation btnAnimation = new DoubleAnimation();
            btnAnimation.From = 0; //стартовый размер кнопки при запуске
            btnAnimation.To = 450; //конечный размер кнопки
            btnAnimation.Duration = TimeSpan.FromSeconds(3); //время расширения в секундах
            //к кнопке цепляем обработчик анимации с параметрами 
            //который принимает параметрами свойство ширина кнопки и саму анимацию
            regButton.BeginAnimation(Button.WidthProperty, btnAnimation);

            //временный список и вывод в текстовое поле для контроля записи в базу///////
            //List<User> users = db.Users.ToList();
            //string str = "";
            //foreach (User user in users) // в цикле перебираем каждую запись данного типа
            //{
            //    //в строку собираем поля каждой записи класса User доступом через их свойства
            //    str += "Login: " + user.Login + " E-mail: " + user.Email + " Password: " + user.Pass +"\n";

            //    exampleText.Text = str; //в поле устанавливаем нашу переменную с записями
            //}
            //end of output to temporary textbox 
        }
        //обработчик кнопки Зарегистрироваться
        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            //записываем в строковые переменные переданные значения полей текстбоксов имя и мейл и пассвордбоксов
            string login = textBoxLogin.Text.Trim();//Trim удаляет пробелы в начале и конце строки
            string pass = passBox.Password.Trim();
            string pass_2 = passBox_2.Password.Trim();
            string email = textBoxEmail.Text.Trim().ToLower(); /*приведение мейла к нижнему регистру*/
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
            else //если ошибок нет, то по нажатию кнопки устанавливаем все подсказки пустыми, а фон полей прозрачным
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;

                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;

                passBox_2.ToolTip = "";
                passBox_2.Background = Brushes.Transparent;

                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;

                MessageBox.Show("Everything's OK", "Success");

                //создаем и добавляем нового пользователя с переданными параметрами в БД
                User user = new User(login, email, pass); //объект класса с параметрами на основе класса-модели
                db.Users.Add(user); //добавление объекта User в список (DbSet)
                db.SaveChanges(); //обмен с базой данных - сохранение объекта внутри базы данных

                //переадресация на окно авторизации в случае успешной регистрации
                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                Close(); //вместо this.Hide();
            }
        }

        //обработчик кнопки Войти - переадресация на окно авторизации AuthWindow
        private void Button_Window_Auth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Close(); //this.Hide();
        }

        //вызов обработчика кнопки Зарегистрироваться при нажатии Enter на поле Email
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Button_Reg_Click(sender, e);
            }    
        }
        //проверка уникальности логина
        private void Text_Login_Changed(object sender, TextChangedEventArgs e)
        {
            //записываем в строковую переменную значения поля имя текстбокса
            string login = textBoxLogin.Text.Trim();//Trim удаляет пробелы в начале и конце строки
            if (login.Length >= 5) 
            {
                User authUser = null;
                using (ApplicationContext db = new ApplicationContext())
                {
                    authUser = db.Users.Where(b => b.Login == login).FirstOrDefault();
                }
                if (authUser != null) //если user с таким логином найден 
                {
                    MessageBox.Show($"{login} - user exists!", "Information", MessageBoxButton.OK,
                        (MessageBoxImage)MessageBoxImage.Information);
                }
            }
        }
    }
}
