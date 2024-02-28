using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BibleApp.Models
{
	public class Testaments : Bible
    {
        public string Titre { get; set; }
        public Collection<Livres> Livres { get; set; }
        public Testaments()
        {

        }

        public Testaments(string titre, Collection<Livres> livres)
        {
            Titre = titre;
            Livres = livres;   
        }
    }
}