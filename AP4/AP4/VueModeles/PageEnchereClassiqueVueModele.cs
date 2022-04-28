using AP4.Modeles;
using AP4.Services;
using AP4.Vues;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AP4.VueModeles
{
    public class PageEnchereClassiqueVueModele : BaseVueModele
    {
        #region Attributs 
        private Enchere _lenchere;
        private ObservableCollection<Encherir> _listeEncherirDeLEnchere;
        private Encherir _prixActuel;
        private float _newPrixEnchere;
        private string _idUser;
        private string _pseudoUser;
        private readonly Api _apiServices = new Api();
        private DecompteTimer tmps;
        private int _tempsRestantJour;
        private int _tempsRestantHeures;
        private int _tempsRestantMinutes;
        private int _tempsRestantSecondes;
        private bool _animation;

        #endregion
        #region Constructeurs 
        public PageEnchereClassiqueVueModele(Enchere param)
        {
            Animation = false;
            _lenchere = param;
            this.GetActualPrice();
            this.GetListeEncherir();
            tmps = new DecompteTimer();
            this.GetTimerRemaining(param.DateFin);
            CommandBoutonEncherir = new Command(ActionCommandBoutonEncherir);

        }
        #endregion

        #region Getters/Setters
        public Enchere LEnchere
        {
            get{ return _lenchere; }
            set{ SetProperty(ref _lenchere, value); }
        }
        public float NewPrixEnchere
        {
            get{ return _newPrixEnchere; }
            set{ SetProperty(ref _newPrixEnchere, value); }
        }
        public ObservableCollection<Encherir> ListeEncherirDeLEnchere
        {
            get{ return _listeEncherirDeLEnchere; }
            set{ SetProperty(ref _listeEncherirDeLEnchere, value); }
        }
        public Encherir PrixActuel
        {
            get { return _prixActuel; }
            set { SetProperty(ref _prixActuel, value); }
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
        public ICommand CommandBoutonEncherir { get; }

        public int TempsRestantHeures
        {
            get { return _tempsRestantHeures; }
            set { SetProperty(ref _tempsRestantHeures, value); }
        }
        public int TempsRestantJour
        {
            get { return _tempsRestantJour; }
            set { SetProperty(ref _tempsRestantJour, value); }
        }
        public int TempsRestantMinutes
        {
            get { return _tempsRestantMinutes; }
            set { SetProperty(ref _tempsRestantMinutes, value); }
        }
        public int TempsRestantSecondes
        {
            get { return _tempsRestantSecondes; }
            set { SetProperty(ref _tempsRestantSecondes, value); }
        }

        public bool Animation
        {
            get{ return _animation; }
            set{ SetProperty(ref _animation, value); }
        }
        #endregion

        #region Methodes
        public void GetListeEncherir()
        {
            Task.Run(async () =>
            {
                do
                {
                    Encherir.CollClasse.Clear();
                    ListeEncherirDeLEnchere = await _apiServices.GetAllAsyncID<Encherir>("api/getLastSixOffer", Encherir.CollClasse, "Id", LEnchere.Id);

                    Thread.Sleep(2000);
                }
                while(true);
            });
        }
        private void GetActualPrice()
        {
            Task.Run(async () =>
            {
                do
                {
                    PrixActuel = await _apiServices.GetOneAsyncID<Encherir>("api/getActualPrice", Encherir.CollClasse, LEnchere.Id.ToString());
                    Thread.Sleep(2000);
                }
                while (true);  

            });
        }
        public async void ActionCommandBoutonEncherir()
        {
            IdUser = await SecureStorage.GetAsync("ID");
            if (NewPrixEnchere > PrixActuel.PrixEnchere)
            {    
                if(PrixActuel.Id != int.Parse(IdUser))
                {
                    PseudoUser = await SecureStorage.GetAsync("Pseudo");
                    Encherir newEncherir = new Encherir(0, LEnchere.Id, int.Parse(IdUser), NewPrixEnchere, PseudoUser);
                    await _apiServices.PostAsync<Encherir>(newEncherir, "api/postEncherir");
                    AnimationEncherir();
                }   
                else
                {
                    await Application.Current.MainPage.DisplayAlert("L'enchère est à vous !", "Attendez que quelqu'un renchérisse", "OK");
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Vous devez proposer un prix plus grand que celui actuel! ","Changez votre prix", "OK");
            }

        }
        public void AnimationEncherir()
        {
            Task.Run(async () =>
            {
                Animation = true;
                Thread.Sleep(10000);
                Animation = false;
            });
        }
        public void GetTimerRemaining(DateTime param)
        {
            DateTime datefin = param;
            TimeSpan interval = datefin - DateTime.Now;


            Task.Run(() =>
            {
                tmps.Start(interval);
                do
                {
                    TempsRestantJour = tmps.TempsRestant.Days;
                    TempsRestantHeures = tmps.TempsRestant.Hours;
                    TempsRestantMinutes = tmps.TempsRestant.Minutes;
                    TempsRestantSecondes = tmps.TempsRestant.Seconds;
                }
                while (tmps.TempsRestant > TimeSpan.Zero) ;
            });
        }
        #endregion
    }
}
