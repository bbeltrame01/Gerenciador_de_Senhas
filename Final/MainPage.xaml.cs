using Final.Models;
using Final.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Final
{
    public partial class MainPage : ContentPage
    {
        private int id;
        public Contents contexto;
        public MainPage()
        {
            InitializeComponent();

            contexto = new Contents();            
        }

        protected override void OnAppearing()
        {
            AtualizarLista();
        }

        private void lstSenhas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var Senha = (Passwords)e.SelectedItem;
                id = Senha.Id;

                btEditar.IsEnabled = true;
                btExcluir.IsEnabled = true;
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void btIncluir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Cadastro(null));
        }

        private void btEditar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Cadastro((Passwords)lstSenhas.SelectedItem));
        }

        private async void btExcluir_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (id > 0)
                {
                    // Confirmar Exclusão
                    if (await DisplayAlert("Exclusão", "Confirma exclusão?", "Sim", "Não"))
                    {
                        contexto.conexao.Execute($"DELETE FROM Passwords WHERE ID={Convert.ToString(id)}");
                        await DisplayAlert("Excluir", "Registro excluído com sucesso!", "OK");
                    }                    
                }
                else
                {
                    await DisplayAlert("Erro", "Selecione um registro na lista para excluir.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }

            AtualizarLista();
        }
        private void AtualizarLista()
        {
            lstSenhas.ItemTemplate = new DataTemplate(typeof(CellPasswords));
            lstSenhas.ItemsSource = contexto.conexao.Query<Passwords>("SELECT * FROM Passwords").ToList();
            btEditar.IsEnabled = false;
            btExcluir.IsEnabled = false;
        }
    }
}
