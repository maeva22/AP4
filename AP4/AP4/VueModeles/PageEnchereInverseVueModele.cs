using AP4.Modeles;
using AP4.Services;
using AP4.Vues;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AP4.VueModeles
{
    public class PageEnchereInverseVueModele : BaseVueModele
    {
        #region Attributs 
        private Enchere _lenchere;
        private string _idUser;
        private string _pseudoUser;
        private float _prixEnBaisse;
        private readonly Api _apiServices = new Api();
        private DecompteTimer tmps;
        private int _tempsRestantJour;
        private int _tempsRestantHeures;
        private int _tempsRestantMinutes;
        private int _tempsRestantSecondes; 
        private int _timePrice;
        User _unUser;
        private bool _nonGagner;
        private bool _gagner;
        private bool _animation;

        #endregion
        #region Constructeurs 
        public PageEnchereInverseVueModele(Enchere param)
        {
            NonGagner = false;
            Gagner = false;
            Animation = false;
            _lenchere = param;
            this.EnchereGagnerOuPas();
            PrixEnBaisse = LEnchere.PrixDepart;
            tmps = new DecompteTimer();
            this.GetTimerRemaining(param.DateFin);
            CommandBoutonEncherir = new Command(PostStopEncherirInverse);

        }
        #endregion

        #region Getters/Setters
        public Enchere LEnchere
        {
            get { return _lenchere; }
            set { SetProperty(ref _lenchere, value); }
        }
        public User UnUser
        {
            get { return _unUser; }
            set { SetProperty(ref _unUser, value); }
        }
        public float PrixEnBaisse
        {
            get { return _prixEnBaisse; }
            set { SetProperty(ref _prixEnBaisse, value); }
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
        public int TimePrice
        {
            get => _timePrice;
            set => _timePrice = value;
        }
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
        public bool NonGagner
        {
            get { return _nonGagner; }
            set { SetProperty(ref _nonGagner, value); }
        }
        public bool Gagner
        {
            get { return _gagner; }
            set { SetProperty(ref _gagner, value); }
        }
        public bool Animation
        {
            get{return _animation;}
            set{SetProperty(ref _animation, value);}
        }
        public ICommand CommandBoutonEncherir { get; }
        #endregion

        #region Methodes
        public void EnchereGagnerOuPas()
        {
            Task.Run(async () =>
            {
                do
                {   
                    User.CollClasse.Clear();
                    UnUser = await _apiServices.GetOneAsyncID<User>("api/getGagnant", User.CollClasse, LEnchere.Id.ToString());

                    if (UnUser != null)
                    {
                        Gagner = true;
                        NonGagner = false;
                    }
                    else
                    {
                        Gagner = false;
                        NonGagner = true;
                    }
                    Thread.Sleep(3000);
                }
                while (true);
            });
        }

        public void GetPriceMinusOne(bool param)
        {
            //if (PrixEnBaisse > LEnchere.Prixreserve)

            if (TimePrice == TempsRestantSecondes + 1 && param==true)
            {
                PrixEnBaisse = PrixEnBaisse - 1;
                TimePrice = TempsRestantSecondes;
            }
        }
        public async void PostStopEncherirInverse()
        {
            GetPriceMinusOne(false);
            if (PrixEnBaisse >= LEnchere.Prixreserve)
            {
                tmps.Stop();
                IdUser = await SecureStorage.GetAsync("ID");
                PseudoUser = await SecureStorage.GetAsync("Pseudo");
                Encherir newEncherir = new Encherir(0, LEnchere.Id, int.Parse(IdUser), PrixEnBaisse, PseudoUser);
                await _apiServices.PostAsync<Encherir>(newEncherir, "api/postEncherirInverse");
                await Application.Current.MainPage.DisplayAlert("Bravo", "L'enchère est à vous!", "OK");
                AnimationEncherir();
            }
            else
            {
                GetPriceMinusOne(true);
                await Application.Current.MainPage.DisplayAlert("L'enchère n'est pas à vous vous proposez un prix trop bas !", "Recommencez vite", "OK");
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
                TimePrice = tmps.TempsRestant.Seconds;
                do
                {
                    TempsRestantJour = tmps.TempsRestant.Days;
                    TempsRestantHeures = tmps.TempsRestant.Hours;
                    TempsRestantMinutes = tmps.TempsRestant.Minutes;
                    TempsRestantSecondes = tmps.TempsRestant.Seconds;
                    GetPriceMinusOne(true);
                }
                while (tmps.TempsRestant > TimeSpan.Zero);
            });
        }
        #endregion
    }
}
