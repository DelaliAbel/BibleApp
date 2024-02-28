using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibleApp.Models
{
	public class Versets
    {
        public int NumeroVerset { get; set; }
        public string Verset { get; set; }

        public Versets()
        {

        }

        public Versets(int numeroVerset, string verset)
        {
            NumeroVerset = numeroVerset;
            Verset = verset;
        }
    }
}
