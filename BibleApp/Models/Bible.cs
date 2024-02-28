using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BibleApp.Models
{
	public class Bible
    {
        public string Traduction { get; set; }
        public Collection<Testaments> ContenuBible { get; set; }

        public Bible()
        {

        }
        public Bible(string traduction, Collection<Testaments> contenuBible)
        {
            Traduction = traduction;
            ContenuBible = contenuBible;
        }
    }
}