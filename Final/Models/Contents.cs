using Final.Pages;
using PCLExt.FileStorage.Folders;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final.Models
{
    public class Contents
    {
        public SQLiteConnection conexao;
        public Contents()
        {
            // Criar/Abrir Base de Dados
            var pasta = new LocalRootFolder();
            var arquivo = pasta.CreateFile("SenhasDB", PCLExt.FileStorage.CreationCollisionOption.OpenIfExists);
            conexao = new SQLiteConnection(arquivo.Path);

            // Criar/Abrir Tabela Passwords
            conexao.CreateTable<Passwords>();
            conexao.CreateTable <User>();

            // Incluir Senha Acesso
            if (conexao.Find<User>(1) == null)
            {
                User user = new User();
                user.Email = "teste@teste123.com";
                user.Senha = Login.MD5Hash("1234");

                Inserir(user);
            }
        }
        // Inserir Dados
        public void Inserir<T>(T modelo)
        {
            conexao.Insert(modelo);
        }
        // Alterar Dados
        public void Alterar<T>(T modelo)
        {
            conexao.Update(modelo);
        }
        // Excluir Dados
        public void Excluir<T>(T modelo)
        {
            conexao.Delete(modelo);
        }
    }
}
