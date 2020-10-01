using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final.Models
{
    public class Passwords
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Observacoes { get; set; }
    }
}
