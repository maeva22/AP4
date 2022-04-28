using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AP4.Modeles
{
    public class Enchere
    {
        #region Attributs

        public static List<Enchere> CollClasse = new List<Enchere>();
        private int _id;
        private DateTime _dateDebut;
        private DateTime _dateFin;
        private float _prixreserve;
        private float _prixdepart;
        private int _type_enchere_id;
        
        private Produit _leProduit;
        private TypeEnchere _leTypeEnchere;
        private Magasin _leMagasin;

        public static ObservableCollection<Enchere> CollEnchere = new ObservableCollection<Enchere>();
        #endregion

        #region Constructeurs

        public Enchere(int id, DateTime dateDebut, DateTime dateFin, float prixreserve, float prixdepart, int type_enchere_id, Produit leProduit, TypeEnchere letypeenchere, Magasin leMagasin)
        {
            _id = id;
            _dateDebut = dateDebut;
            _dateFin = dateFin;
            _prixreserve = prixreserve;
            _prixdepart = prixdepart;
            _type_enchere_id = type_enchere_id;
            _leProduit = leProduit;
            _leTypeEnchere = letypeenchere;
            _leMagasin = leMagasin;
            
            Enchere.CollClasse.Add(this);

        }

        #endregion

        #region Getters/Setters
        public int Id { get => _id; set => _id = value; }
        public DateTime DateDebut { get => _dateDebut; set => _dateDebut = value; }
        public DateTime DateFin { get => _dateFin; set => _dateFin = value; }
        public float Prixreserve { get => _prixreserve; set => _prixreserve = value; }
        public float PrixDepart { get => _prixdepart; set => _prixdepart = value; }
        public int Type_enchere_id { get => _type_enchere_id; set => _type_enchere_id = value; }
        
        public Produit LeProduit { get => _leProduit; set => _leProduit = value; }
        public TypeEnchere LeTypeEnchere { get => _leTypeEnchere; set => _leTypeEnchere = value; }
        public Magasin LeMagasin { get => _leMagasin; set => _leMagasin = value; }


        #endregion

        #region Methodes

        #endregion
    }
}
