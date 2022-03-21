using System;
using System.Collections.Generic;
using System.Text;

namespace AP4.Modeles
{
    public class Produit
    {
        #region Attributs
        public static List<Produit> CollClasse = new List<Produit>();

        private int _id;
        private string _nom;
        private string _photo;
        #endregion

        #region Constructeurs
        public Produit(int id, string nom, string photo) 
        {
            Id = id;
            Nom = nom;
            Photo = photo;        

            Produit.CollClasse.Add(this);
        }
        #endregion

        #region Getters/Setters
        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public string Photo { get => _photo; set => _photo = value; }
        #endregion

        #region Methodes
        #endregion
    }
}
