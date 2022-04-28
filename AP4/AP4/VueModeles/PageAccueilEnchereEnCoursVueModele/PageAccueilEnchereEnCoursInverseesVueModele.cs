using AP4.Modeles;
using AP4.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AP4.VueModeles.PageAccueilEnchereEnCoursVueModele
{
    public class PageAccueilEnchereEnCoursInverseesVueModele : BaseVueModele
    {
        #region Attributs
        private ObservableCollection<Enchere> _maListeEncheresEnCoursInversees;

        private readonly Api _apiServices = new Api();
        #endregion

        #region Constructeurs
        public PageAccueilEnchereEnCoursInverseesVueModele()
        {
            GetListeEncheresEnCoursInversees(2);
        }
        #endregion

        #region Getters/Setters

        public ObservableCollection<Enchere> MaListeEncheresEnCoursInversees
        {
            get
            {
                return _maListeEncheresEnCoursInversees;
            }
            set
            {
                SetProperty(ref _maListeEncheresEnCoursInversees, value);
            }
        }

        #endregion

        #region Methodes

        public void GetListeEncheresEnCoursInversees(int idEnchereEnCoursInversees)
        {
            Task.Run(async () =>
            {
                do
                {
                    MaListeEncheresEnCoursInversees = await _apiServices.GetAllAsyncID<Enchere>("api/getEncheresEnCours", Enchere.CollClasse, "IdTypeEnchere", idEnchereEnCoursInversees);
                    Enchere.CollClasse.Clear();
                    Thread.Sleep(2000);
                }
                while (true);

            });
        }
        #endregion
    }
}
