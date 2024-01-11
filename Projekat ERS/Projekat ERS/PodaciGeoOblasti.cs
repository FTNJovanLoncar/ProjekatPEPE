using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_ERS
{
   public class PodaciGeoOblasti
    {
        string imeGeoOblasti;
        int sifra;

       public  PodaciGeoOblasti()
        {

        }

        public PodaciGeoOblasti(string s, int si)
        {
            this.ImeGeoOblasti = s;
            this.sifra = si;
        }

        public string ImeGeoOblasti { get => imeGeoOblasti; set => imeGeoOblasti = value; }
        public int Sifra { get => sifra; set => sifra = value; }
    }
}
