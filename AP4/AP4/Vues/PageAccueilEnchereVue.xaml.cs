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
    public partial class PageAccueilEnchereVue : ContentPage
    {
        PageAccueilEnchereVueModele vueModele;

        public PageAccueilEnchereVue()
        {
            InitializeComponent();
            BindingContext = vueModele = new PageAccueilEnchereVueModele();

        }
    }
}