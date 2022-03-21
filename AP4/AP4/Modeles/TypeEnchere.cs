using System;
using System.Collections.Generic;
using System.Text;

namespace AP4.Modeles
{
    public class TypeEnchere
    {
        #region Attributs
        public static List<TypeEnchere> CollClasse = new List<TypeEnchere>();

        private int _id;
        private string _nom;
        #endregion

        #region Constructeurs
        public TypeEnchere(int id, string nom) 
        {
            TypeEnchere.CollClasse.Add(this);
            _id = id;
            _nom = nom;
        }
        #endregion

        #region Getters/
        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        #endregion

        #region Methodes
        #endregion
    }
}
