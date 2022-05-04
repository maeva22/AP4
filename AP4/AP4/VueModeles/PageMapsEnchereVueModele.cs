using AP4.Modeles;
using AP4.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace AP4.VueModeles
{
    public class PageMapsEnchereVueModele : BaseVueModele
    {
        #region Attributs
        private ObservableCollection<Enchere> _maListeEncheres;

        private readonly Api _apiServices = new Api();
        #endregion

        #region Constructeurs
        public PageMapsEnchereVueModele()
        {
            GetListeEncheres();
        }
        #endregion

        #region Getters/Setters

        public ObservableCollection<Enchere> MaListeEncheres
        {
            get
            {
                return _maListeEncheres;
            }
            set
            {
                SetProperty(ref _maListeEncheres, value);
            }
        }

        #endregion

        #region Methodes
        /// <summary>
        /// Permet d'avoir la liste des enchères en cours
        /// </summary>
        public async void GetListeEncheres()
        {
            MaListeEncheres = await _apiServices.GetAllAsync<Enchere>("api/getEnchere", Enchere.CollClasse);
            Enchere.CollClasse.Clear();
        }
        #endregion
    }
}
