using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace BibleApp.Models
{
    public class Chapitres
    {
        #region Champs
        public string _numeroChapitre;
        public SoundPlayer _audio;
        public Collection<Versets> _contenuVersets;
        #endregion

        #region Proprietés
        public string NumeroChapitre { get; set; }
        public SoundPlayer Audio { get; set; }
        public Collection<Versets> ContenuVersets { get; set; }
        #endregion

        public Chapitres()
        {

        }

        public Chapitres(string i_numero, Collection<Versets> i_contenuVersets)
        {
            _numeroChapitre = i_numero;
            _contenuVersets = i_contenuVersets;
        }

        public Chapitres(string i_numero, SoundPlayer i_audio, Collection<Versets> i_contenuVersets)
        {
            _numeroChapitre = i_numero;
            _audio = i_audio;
            _contenuVersets = i_contenuVersets;
        }
    }
}
