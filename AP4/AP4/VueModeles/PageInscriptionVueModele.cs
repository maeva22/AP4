using AP4.Modeles;
using AP4.Services;
using AP4.Vues;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;

namespace AP4.VueModeles
{
    public class PageInscriptionVueModele : BaseVueModele
    {
        #region Attributs
        private readonly Api _apiServices = new Api();
        #endregion

        #region Constructeurs
        public PageInscriptionVueModele()
        {
            CommandBoutonRetour = new Command(ActionCommandBoutonRetour);
        }
        #endregion

        #region Getters/Setters
        public ICommand CommandBoutonRetour { get; }

        #endregion

        #region Methodes
        public void ActionCommandBoutonRetour()
        {
            Application.Current.MainPage = new PageIndexVue();
        }

        public async void PostUser(User unUser)
        {
            int resultat = await _apiServices.PostAsync<User>(unUser, "api/postUser");
        }
        #endregion
    }
}
