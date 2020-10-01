using Final.Pages;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Final.Models
{
    public class User
    {
        public Contents contexto;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public User() { }

        public User(string senha)
        {
            contexto = new Contents();
            this.Senha = Login.MD5Hash(senha);
        }
        public bool ValidateLogin()
        {
            var data = contexto.conexao.Table<User>();

            if (data.Where(x => x.Senha == this.Senha).FirstOrDefault() != null)
                return true;
            else
                return false;
        }
    }
}
