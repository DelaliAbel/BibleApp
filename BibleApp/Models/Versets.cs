using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraping_project
{
    public class Versets
    {
        public int Num { get; set; }
        public string Verset { get; set; }

        public Versets()
        {

        }

        public Versets(int num , string verset)
        {
            Num = num;
            Verset = verset;
        }
    }
}
