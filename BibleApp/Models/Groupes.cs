using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Scraping_project
{
    public class Groupes : Bible
    {
        public string Titre { get; set; }
        public Collection<Livres> Livre { get; set; }
        public Groupes()
        {

        }

        public Groupes(string titre, Collection<Livres> livre)
        {
            Titre = titre;
            Livre = livre;
        }
    }
}