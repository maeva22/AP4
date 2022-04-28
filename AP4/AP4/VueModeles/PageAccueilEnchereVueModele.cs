using AP4.Modeles;
using AP4.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AP4.VueModeles
{
    public class PageAccueilEnchereVueModele : BaseVueModele
    {
        #region Attributs
        private ObservableCollection<Enchere> _maListeEncheres;

        private readonly Api _apiServices = new Api();
        #endregion

        #region Constructeurs
        public PageAccueilEnchereVueModele()
        {
            GetListeEncheresEnCoursInversees();
        }
        #endregion

        #region Getters/Setters

        public ObservableCollection<Enchere> MaListeEncheres
        {
            get { return _maListeEncheres; }
            set { SetProperty(ref _maListeEncheres, value); }
        }

        #endregion

        #region Methodes

        public async void GetListeEncheresEnCoursInversees()
        {
            MaListeEncheres = await _apiServices.GetAllAsync<Enchere>("api/getEnchere", Enchere.CollClasse);
            Enchere.CollClasse.Clear();
        }
        #endregion
    }
}
