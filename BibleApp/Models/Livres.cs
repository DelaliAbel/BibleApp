using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Scraping_project
{
    public class Livres : Bible
    {
        public string NomLivre { get; set; }
        public Dictionary<int, Collection<Versets>> Contenu { get; set; }

        public Livres()
        {

        }
        public Livres(string nomLivre, Dictionary<int, Collection<Versets>> contenu)
        {
            NomLivre = nomLivre;
            Contenu = contenu;
        }
    }
}