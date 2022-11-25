using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labgestiondeprojet
{
    internal class Employe
    {
        int matricule;
        string nom;
        string prenom;

        public int Matricule { get => matricule; set => matricule = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }

        public override string ToString()
        {
            return matricule + " " + nom + " " + prenom + " " ;
        }
    }
}
