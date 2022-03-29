using AP4.Modeles;
using AP4.VueModeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AP4.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageAccueilVue : ContentPage
    {
        PageAccueilVueModele vueModele;
        public PageAccueilVue()
        {
            InitializeComponent();
            BindingContext = vueModele = new PageAccueilVueModele();
        }
        private async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var enchere = (Enchere)e.CurrentSelection.FirstOrDefault();
            await Navigation.PushAsync(new PageEnchereClassiqueVue(enchere));
        }


    }
}