using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_ERS
{
    class PROGNOZIRANI_LOAD
    {
        private int sat;
        private int load;
        private string oblast;

        public PROGNOZIRANI_LOAD()
        {
            this.Sat = 0;
            this.Load = 0;
            this.Oblast = "";
        }

        public PROGNOZIRANI_LOAD(int sat, int load, string oblast)
        {
            this.Sat = sat;
            this.Load = load;
            this.Oblast = oblast;
        }

        public int Sat { get => sat; set => sat = value; }
        public int Load { get => load; set => load = value; }
        public string Oblast { get => oblast; set => oblast = value; }


    }


}
