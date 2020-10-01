using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Final.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastro : ContentPage
    {
        public Contents contexto;
        Passwords senha = new Passwords();

        public Cadastro(Passwords Senhas)
        {
            InitializeComponent();

            contexto = new Contents();
            senha = Senhas;
        }

        protected override void OnAppearing()
        {
            Passwords pwd = new Passwords();

            if (senha != null)
            {
                txID.Text = Convert.ToString(senha.Id);
                txNome.Text = senha.Nome;
                txUsuario.Text = senha.Usuario;
                txSenha.Text = senha.Senha;
                txObs.Text = senha.Observacoes;
            }
        }

        private void btSalvar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txNome.Text))
                {
                    DisplayAlert("Erro", "Descrição inválida.", "OK");
                }
                if (string.IsNullOrEmpty(txUsuario.Text))
                {
                    DisplayAlert("Erro", "Usuário inválido.", "OK");
                }
                if (string.IsNullOrEmpty(txSenha.Text))
                {
                    DisplayAlert("Erro", "Senha inválida.", "OK");
                }

                Passwords senha = new Passwords();
                senha.Id = Convert.ToInt32(txID.Text);
                senha.Nome = txNome.Text;
                senha.Usuario = txUsuario.Text;
                senha.Senha = txSenha.Text;
                senha.Observacoes = txObs.Text;

                if (txID.Text == "0")
                {
                    contexto.Inserir(senha);
                } else
                {
                    contexto.Alterar(senha);
                }
                DisplayAlert("Alterar", "Registro gravado com sucesso!", "OK");
                Navigation.PopAsync(); 
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void btCancelar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}