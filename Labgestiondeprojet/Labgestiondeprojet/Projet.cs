using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labgestiondeprojet
{
    internal class Projet
    {
        int numero;
        double date;
        int budget;
        string description;
        string employe;

        public int Numero { get => numero; set => numero = value; }
        public double Date { get => date; set => date = value; }
        public int Budget { get => budget; set => budget = value; }
        public string Description { get => description; set => description = value; }
        public string Employe { get => employe; set => employe = value; }
    }
}
