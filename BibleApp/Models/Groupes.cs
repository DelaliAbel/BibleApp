using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BibleApp.Models
{
	public class Groupes : Bible
    {
        public string Titre { get; set; }
        public Collection<Livres> Livres { get; set; }
        public Groupes()
        {

        }

        public Groupes(string titre, Collection<Livres> livre)
        {
            Titre = titre;
            Livres = livre;
        }
    }
}