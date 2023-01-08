using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace UsersApp
{
    class ApplicationContext : DbContext
    {
        //класс DbSet хранит в виде списка элементы переданные из таблицы
        //здесь мы создаем коллекцию элементов на основе данного класса
        //в скобках указываем элементы какого класса будут храниться в коллекции
        //название списка нужно указать как таблицу базы - Users
        public DbSet<User> Users { get; set; }

        //в конструктор ничего не принимаем, но передаем название подключения из App.config
        //которое указано в поле name в строке с базой данных - DefaultConnection
        public ApplicationContext() : base("DefaultConnection")
        { 
        
        }        
    }
}
