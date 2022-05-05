using AP4.Modeles;
using AP4.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AP4.VueModeles
{
    public class PageInformationUserVueModele : BaseVueModele
    {
        #region Attributs
        private ObservableCollection<Enchere> _maListeEncheresParticipe;

        private readonly Api _apiServices = new Api();
        #endregion

        #region Constructeurs
        public PageInformationUserVueModele()
        {
            GetListeEncheresParticipe();
        }
        #endregion

        #region Getters/Setters

        public ObservableCollection<Enchere> MaListeEncheresParticipe
        {
            get
            {
                return _maListeEncheresParticipe;
            }
            set
            {
                SetProperty(ref _maListeEncheresParticipe, value);
            }
        }

        #endregion

        #region Methodes
        
        public void GetListeEncheresParticipe()
        {
            Task.Run(async () =>
            {
                do
                {
                    MaListeEncheresParticipe = await _apiServices.GetAllAsyncID<Enchere>("api/getEncheresParticipes", Enchere.CollClasse, "Id", int.Parse(await SecureStorage.GetAsync("ID")));
                    Enchere.CollClasse.Clear();
                    Thread.Sleep(2000);
                }
                while (true);

            });
        }
        #endregion
    }
}
