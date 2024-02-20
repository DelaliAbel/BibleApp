using BibleApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BibleApp.Models
{
	public class Livres
    {
        public string Abreviation { get; set; }
        public string NomLivre { get; set; }
        public Collection<Chapitres> ContenuChapitre { get; set; }

        public Livres()
        {

        }

        public Livres(string nomLivre, Collection<Chapitres> contenu)
        {
            NomLivre = nomLivre;
            ContenuChapitre = contenu;
        }

        public Livres(string nomLivre, Collection<Chapitres> contenu, string i_abreviation)
        {
            NomLivre = nomLivre;
            ContenuChapitre = contenu;
            Abreviation = i_abreviation;
        }


    }
}