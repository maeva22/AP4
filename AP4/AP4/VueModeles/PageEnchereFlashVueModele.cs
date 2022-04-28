using AP4.Modeles;
using AP4.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AP4.VueModeles
{
    public class PageEnchereFlashVueModele : BaseVueModele
    {
        #region Attributs 
        private Enchere _lenchere;
        private string _idUser;
        private string _pseudoUser;

        private readonly Api _apiServices = new Api();


        #endregion
        #region Constructeurs 
        public PageEnchereFlashVueModele(Enchere param)
        {
            _lenchere = param;

        }
        #endregion

        #region Getters/Setters
        public Enchere LEnchere
        {
            get { return _lenchere; }
            set { SetProperty(ref _lenchere, value); }
        }

        public string IdUser
        {
            get => _idUser;
            set => _idUser = value;
        }
        public string PseudoUser
        {
            get => _pseudoUser;
            set => _pseudoUser = value;
        }
        #endregion

        #region Methodes
        public void tableauUser()
        {
        } 
        
        #endregion
    }
}
