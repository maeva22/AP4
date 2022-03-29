using System;
using System.Collections.Generic;
using System.Text;

namespace AP4.Modeles
{
    public class Encherir
    {
        #region Attributs
        private int _id;
        private int _idEnchere;
        private int _idUser;
        private float _prixEnchere;
        private Enchere _lEnchere;
        private string _pseudo;


        public static List<Encherir> CollClasse = new List<Encherir>();

        #endregion

        #region Constructeur
        public Encherir(int id, int idEnchere, int idUser, float prixEnchere, string pseudo)
        {
            Id = id;
            IdEnchere = idEnchere;
            IdUser = idUser;
            PrixEnchere = prixEnchere;
            Pseudo = pseudo;

            Encherir.CollClasse.Add(this);
        }

        #endregion

        #region Getters/Setters
        public int Id { get => _id; set => _id = value; }
        public int IdEnchere { get => _idEnchere; set => _idEnchere = value; }
        public int IdUser { get => _idUser; set => _idUser = value; }
        public float PrixEnchere { get => _prixEnchere; set => _prixEnchere = value; }
        public Enchere LEnchere { get => _lEnchere; set => _lEnchere = value; }
        public string Pseudo { get => _pseudo; set => _pseudo = value; }

        #endregion

        #region Methodes
        #endregion
    }
}
