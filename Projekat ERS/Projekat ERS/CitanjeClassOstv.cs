using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Projekat_ERS 
{
    class CitanjeClassOstv : CitanjeFajlova 
    {
        public CitanjeClassOstv()
        {
        }


        private PROGNOZIRANI_LOAD PL;
        public bool EndOfStream { get; }
        List<PROGNOZIRANI_LOAD> lista = new List<PROGNOZIRANI_LOAD>();

      

        public void Citanje()
        {
            XmlSerializer serz = new XmlSerializer(typeof(PROGNOZIRANI_LOAD));

            FileStream read = File.OpenRead("ostv_2020_05_07.xml");
            StreamReader reader = new StreamReader(read);

            while (!reader.EndOfStream)
            {

                var result = (PROGNOZIRANI_LOAD)(serz.Deserialize(read));
                PL = result;
                lista.Add(PL);
            }
        }
    }
}


