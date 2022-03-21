using System;
using System.Collections.Generic;
using System.Text;

namespace AP4.Modeles
{
    public class Magasin
    {
        #region Attributs
        public static List<Magasin> CollClasse = new List<Magasin>();

        private int _id;
        private string _nom;
        private string _adresse;
        private string _ville;
        private int _codePostal;
        private int _portable;
        private double _lagitude;
        private double _longitude;
        #endregion

        #region Constructeurs
        public Magasin(int id, string nom, string adresse, string ville, int codePostal, int portable, double lagitude, double longitude)
        {
            _id = id;
            _nom = nom;
            _adresse = adresse;
            _ville = ville;
            _codePostal = codePostal;
            _portable = portable;
            _lagitude = lagitude;
            _longitude = longitude;

            Magasin.CollClasse.Add(this);
        }
        #endregion

        #region Getters/Setters
        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public string Adresse { get => _adresse; set => _adresse = value; }
        public string Ville { get => _ville; set => _ville = value; }
        public int CodePostal { get => _codePostal; set => _codePostal = value; }
        public int Portable { get => _portable; set => _portable = value; }
        public double Lagitude { get => _lagitude; set => _lagitude = value; }
        public double Longitude { get => _longitude; set => _longitude = value; }
        #endregion

        #region Methodes
        #endregion
    }
}
