using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApp
{
    class User
    {
        public int id { get; set; }
        private string login, pass, email;

        public string Login //публичное свойство реализующее геттер и сеттер для login
        {
        get { return login; }
        set { login = value; }
        }
        
        public string Pass 
        {
            get { return pass; }
            set { pass = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public User() { } //конструктор по умолчанию
        public User(string login, string email, string pass)//конструктор с параметрами
        {
            this.login = login;
            this.email = email;
            this.pass = pass;           
        }
    }
}
