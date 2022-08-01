using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Scraping_project
{
    public class Testaments : Bible
    {
        public string Titre { get; set; }
        public Collection<Groupes> Groupe { get; set; }
        public Testaments()
        {

        }

        public Testaments(string titre, Collection<Groupes> groupe)
        {
            Titre = titre; 
            Groupe = groupe;   
        }
    }
}