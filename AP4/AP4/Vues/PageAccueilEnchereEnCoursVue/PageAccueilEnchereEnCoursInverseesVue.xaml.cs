using AP4.Modeles;
using AP4.VueModeles.PageAccueilEnchereEnCoursVueModele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AP4.Vues.PageAccueilEnchereEnCoursVue
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageAccueilEnchereEnCoursInverseesVue : ContentPage
    {
        PageAccueilEnchereEnCoursInverseesVueModele vueModele;
        public PageAccueilEnchereEnCoursInverseesVue()
        {
            InitializeComponent();
            BindingContext = vueModele = new PageAccueilEnchereEnCoursInverseesVueModele();
        }
        private async void SelectionEnchereEnCoursInversees(object sender, SelectionChangedEventArgs e)
        {
            var enchere = (Enchere)e.CurrentSelection.FirstOrDefault();
            await Navigation.PushAsync(new PageEnchereInverseVue(enchere));
        }
    }
}