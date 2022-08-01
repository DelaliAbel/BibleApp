using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Scraping_project
{
    public class Bible
    {
        public string Traduction { get; set; }
        public Collection<Testaments> Contenu { get; set; }

        public Bible()
        {

        }
        public Bible(string traduction, Collection<Testaments> contenu)
        {
            Traduction = traduction;
            Contenu = contenu;
        }
    }
}