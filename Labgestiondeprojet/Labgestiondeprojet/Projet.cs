using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labgestiondeprojet
{
    internal class Projet
    {
        string numero;
        string date;
        string budget;
        string description;
        string employe;

        public string Numero { get => numero; set => numero = value; }
        public string Date { get => date; set => date = value; }
        public string Budget { get => budget; set => budget = value; }
        public string Description { get => description; set => description = value; }
        public string Employe { get => employe; set => employe = value; }

        public override string ToString()
        {
            return "Numero de projet :" + Numero + "\n" + "Description du projet : " + Description + "\n" + "Date du projet : " + Date + "\n" + "EMploye chargee du projet : " + Employe + "";
        }
    }
}
