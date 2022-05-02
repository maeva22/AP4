using AP4.Modeles;
using AP4.Services;
using AP4.Vues;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AP4.VueModeles
{
    public class PageConnexionVueModele : BaseVueModele
    {
        #region Attributs
        //private ObservableCollection<Produit> _maListeProduits;
        private readonly Api _apiServices = new Api();

        protected Page page;
        private string _emailEntry;
        private string _passwordEntry;
        private bool auth = false;
        #endregion

        #region Constructeurs
        public PageConnexionVueModele(Page page)
        {
            CommandBoutonRetour = new Command(ActionCommandBoutonRetour);
            CommandBoutonConnexion = new Command(OnSubmit);
        }
        #endregion

        #region Getters/Setters
        public string EmailEntry
        {
            get { return _emailEntry; }
            set { SetProperty(ref _emailEntry, value);}
        }

        public string PasswordEntry
        {
            get { return _passwordEntry; }
            set { SetProperty(ref _passwordEntry, value); }
        }
        public ICommand CommandBoutonRetour { get; }
        public ICommand CommandBoutonConnexion { get; private set; }

        //public ObservableCollection<Produit> MaListeProduits { get => _maListeProduits; set => _maListeProduits = value; }

        #endregion

        #region Methodes
        /// <summary>
        /// Aller à la page PageIndexVue
        /// </summary>
        public void ActionCommandBoutonRetour()
        {
            Application.Current.MainPage = new PageIndexVue();
        }
        /// <summary>
        /// permet de se connecter en regardant si l'utilisateur correspond à un utilisateur dans l'API 
        /// Si l'utilisateur correspond à un utilisateur dans l'API alors il est connecté
        /// et est renvoyé l'utilisateur sur la page des enchère en cours avec un message lui disant qu'il est bien connecté
        /// sinon il est renvoyé un message d'erreur et reste sur la page actuelle
        /// </summary>
        public async void OnSubmit()
        {
            User unUser = new User(EmailEntry, PasswordEntry, "nd","l",0);
            unUser = await _apiServices.GetOneAsync<User>("api/getUserByMailAndPass", User.CollClasse, unUser);

            if (unUser != null)
            {
                auth = true;
                Storage.StockerMotDePasse(unUser.Id.ToString(),unUser.Pseudo);
                Application.Current.MainPage = new AppShell();
                await Application.Current.MainPage.DisplayAlert("Authentification Réussis !", "Vous êtes connecté", "OK");

            }
            else
            {
                auth = false;
                await Application.Current.MainPage.DisplayAlert("Authentification Echoué !", "Êtes-vous sur d'avoir un compte ?", "OK");
            }
        }
        #endregion
    }
}
