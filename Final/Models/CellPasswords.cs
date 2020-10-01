using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Final.Models
{
    class CellPasswords : ViewCell
    {
        public CellPasswords()
        {
            var Nome = new Label
            {
                FontSize = 14,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                FontAttributes = FontAttributes.Bold
            };
            Nome.SetBinding(Label.TextProperty, new Binding("Nome"));

            var Usuario = new Label
            {
                FontSize = 14,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Start
            };
            Usuario.SetBinding(Label.TextProperty, new Binding("Usuario"));

            var Senha = new Label
            {
                FontSize = 14,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Start
            };
            Senha.SetBinding(Label.TextProperty, new Binding("Senha"));

            /*
            var Observacoes = new Label
            {
                FontSize = 10,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Start
            };
            Observacoes.SetBinding(Label.TextProperty, new Binding("Observacoes"));
            */

            var linha1 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { Nome, Usuario, Senha /*, Observacoes*/ }
            };

            View = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { linha1 }
            };
        }
    }
}
