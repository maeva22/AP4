using AP4.Modeles;
using AP4.Services;
using AP4.VueModeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AP4.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageEnchereFlashVue : ContentPage
    {
        PageEnchereFlashVueModele vueModele;
        public List<Button> ListeButton = new List<Button>();
        private readonly Api _apiServices = new Api();
        private bool OnCancel = false;
        public PageEnchereFlashVue(Enchere param)
        {
            InitializeComponent(); 
            BindingContext = vueModele = new PageEnchereFlashVueModele(param);
            CreationButtonGrille(); //met des spacing entre les boutons ...
            GetJoueurActif();
        }

        /// <summary>
        /// Creation de tous les boutons et les affiches si ils sont à 0 et non à 1
        /// </summary>
        public void CreationButtonGrille()
        {
            string[] textSplit = vueModele.LEnchere.TableauFlash.Split(',');
            int nb = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    var buttonFlash = new Button();
                    buttonFlash.Text = "?";
                    if (textSplit[nb] == "0")
                    {
                        buttonFlash.IsVisible = true;
                    }
                    else
                    {
                        buttonFlash.IsVisible = false;
                    }
                    buttonFlash.BackgroundColor = Color.Gray;
                    buttonFlash.BorderColor = Color.Red;
                    buttonFlash.Clicked += OnClick;
                    GridEnchereFlash.Children.Add(buttonFlash,j,i);
                    ListeButton.Add(buttonFlash);
                    nb++;
                }
            }
            GridEnchereFlash.ColumnSpacing = 0;
            GridEnchereFlash.RowSpacing = 0;
        }
    
        public void ReconstruireTableauFlash(List<Button> param)
        {
            vueModele.LEnchere.TableauFlash = "";
            foreach (Button leButton in param)
            {
                if (leButton.IsVisible == true)
                { vueModele.LEnchere.TableauFlash += "0,"; }
                else
                { vueModele.LEnchere.TableauFlash += "1,"; }
            }

            vueModele.LEnchere.TableauFlash = vueModele.LEnchere.TableauFlash.Remove(31);
        }
        /// <summary>
        /// Permet qu'une fois le button cliquer le button disparais et enchérit sur l'enchère 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void OnClick(object sender, EventArgs e)
        {
            this.BloquerLesCases(ListeButton);
            Button btnFlash = (Button)sender;
            btnFlash.IsVisible = false;
            this.ReconstruireTableauFlash(ListeButton);
            vueModele.EncherirFlash();
            if (vueModele.tmps != null && vueModele.tmps.TempsRestant >= TimeSpan.Zero)
            {
                vueModele.tmps.TempsRestant = TimeSpan.Zero;
                vueModele.tmps.Stop();
            }
        }
        /*public void BloquerDernierJoueur()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    EnchereFlash uneEnchereFlash = new EnchereFlash("", 0, vueModele.LEnchere.Id, "", false, "", "");
                    uneEnchereFlash = await _apiServices.GetOneAsync<EnchereFlash>("api/getJoueurActifActuel", EnchereFlash.CollClasse, uneEnchereFlash);
                    vueModele.IdUserGagnant = await SecureStorage.GetAsync("ID");
                    foreach (Button unButton in ListeButton)
                    {
                        if (uneEnchereFlash.IdUser == int.Parse(vueModele.IdUserGagnant))
                        {
                            Device.BeginInvokeOnMainThread(() =>
                            {
                                unButton.IsEnabled = false;
                            });
                        }
                        else
                        {
                            Device.BeginInvokeOnMainThread(() =>
                            {
                                unButton.IsEnabled = true;
                            });
                        }
                    }
                }
            });
        }*/
        public void BloquerLesCases(List<Button> param)
        {
            foreach (Button leButton in param)
            {
                
                    leButton.IsEnabled = false;
              

            }
        }
        public void DebloquerLesCases(List<Button> param)
        {
            foreach (Button leButton in param)
            {
                //Device.BeginInvokeOnMainThread(() =>
                //{
                    leButton.IsEnabled = true;
                //});

            }
        }
        public void GetJoueurActif()
        {
            BloquerLesCases(ListeButton);
            Task.Run(async () =>
            {
                while (OnCancel == false)
                {
                    EnchereFlash uneEnchereFlash = new EnchereFlash("", "", vueModele.LEnchere.Id.ToString(), "", false, "", "");
                    uneEnchereFlash = await _apiServices.GetOneAsync<EnchereFlash>("api/getJoueurActifActuel", EnchereFlash.CollClasse, uneEnchereFlash);
                    if (uneEnchereFlash != null)
                    {
                        vueModele.IdUserGagnant = await SecureStorage.GetAsync("ID");
                        if (int.Parse(uneEnchereFlash.IdUser) != int.Parse(vueModele.IdUserGagnant))
                        {
                           // if (vueModele.tmps == null) vueModele.GestionPhaseEncherir();
                            if (vueModele.tmps != null && vueModele.tmps.TempsRestant <= TimeSpan.Zero)
                            {
                                vueModele.tmps = null;
                                BloquerLesCases(ListeButton);
                                vueModele.RencherirJePasse();

                            }
                            else
                            {
                                DebloquerLesCases(ListeButton);
                            }
                        }
                        else
                        {
                            BloquerLesCases(ListeButton);
                        }
                    }
                    Thread.Sleep(5000);
                }

            });
        }
    }
}