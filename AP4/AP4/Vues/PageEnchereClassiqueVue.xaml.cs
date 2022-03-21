using AP4.Modeles;
using AP4.Services;
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
    public partial class PageEnchereClassiqueVue : ContentPage
    {

        PageEnchereClassiqueVueModele vueModele;
        public PageEnchereClassiqueVue(int param)
        {
            InitializeComponent();
            BindingContext=vueModele=new PageEnchereClassiqueVueModele(param);

            //On ajoute une méthode pour l'obliger à le faire travailler en async
            Task.Run(async () =>
            {
                Enchere uneEnchere = await vueModele.GetLEnchere(param);
            });
        }




    }
}