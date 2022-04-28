using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

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
        private double _latitude;
        private double _longitude;
        private Position _position;
        #endregion

        #region Constructeurs
        public Magasin(int id, string nom, string adresse, string ville, int codePostal, int portable, double latitude, double longitude)
        {
            _id = id;
            _nom = nom;
            _adresse = adresse;
            _ville = ville;
            _codePostal = codePostal;
            _portable = portable;
            _latitude = latitude;
            _longitude = longitude;
            _position = new Position(latitude,longitude);
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
        public double Latitude { get => _latitude; set => _latitude = value; }
        public double Longitude { get => _longitude; set => _longitude = value; }
        public Position Position { get => _position; set => _position = value; }
        #endregion

        #region Methodes
        #endregion
    }
}
