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
    public partial class PageEnchereFlashVue : ContentPage
    {
        PageEnchereFlashVueModele vueModele;
        public PageEnchereFlashVue(Enchere param)
        {
            InitializeComponent();
            CreationButtonGrille(); //met des spacing entre les boutons ... 
            BindingContext = vueModele = new PageEnchereFlashVueModele(param);
            
        }
        public bool visibility { get; set; }
        public void CreationButtonGrille()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Button buttonFlash = new Button();
                    buttonFlash.Text = "?";
                    buttonFlash.IsVisible = true ;
                    buttonFlash.BackgroundColor = Color.Gray;
                    buttonFlash.BorderColor = Color.Red;
                    buttonFlash.Clicked += OnClick;
                    GridEnchereFlash.Children.Add(buttonFlash,i,j);
                }
            }
            GridEnchereFlash.ColumnSpacing = 0;
            GridEnchereFlash.RowSpacing = 0;
        }
        async void OnClick(object sender, EventArgs e)
        {
            Button btnFlash = (Button)sender;
            btnFlash.IsVisible = false;
        }
    }
}