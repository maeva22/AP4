using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;

namespace AP4.Services
{
    public class GestionCollection
    {
        public static ObservableCollection<T> GetListes<T>(List<T> paramList)
        {
            ObservableCollection<T> resultat = new ObservableCollection<T>();

            foreach (T leParam in paramList)
            {
                resultat.Add(leParam);
            }

            return resultat;
        }
        public static T GetObjet<T>(List<T> param, int param2)

        {
            T result = default(T);
            foreach (T unparam in param)
            {
                PropertyInfo x = (unparam.GetType().GetProperty("id"));
                int nbi = Convert.ToInt32(x.GetValue(unparam));
                if (nbi == Convert.ToInt32(param2))
                {
                    result = unparam;
                    break;
                }
            }
            return result;
        }
    }
}
