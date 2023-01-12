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
    /// Interaction logic for UserPageWindow.xaml
    /// </summary>
    public partial class UserPageWindow : Window
    {       
        public UserPageWindow()
        {
            InitializeComponent();

            ApplicationContext db = new ApplicationContext(); //создаем объект класса для взаимодействия с базой

            List<User> users = db.Users.ToList(); //создаем список на основе класса User
                                                  //= из записей таблицы Users БД приведенных к списку
            
            listOfUsers.ItemsSource = users; //обращаемся к элементу ListView и с помощью параметра
                                             //ItemSource присваиваем ему список полученных их БД
        }
    }
}
