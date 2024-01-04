using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projekat_ERS
{
    class CitanjeClassProg : CitanjeFajlova
    {


        public CitanjeClassProg()
        {
        }

        private PROGNOZIRANI_LOAD PL;
        public bool EndOfStream { get; }
        List<PROGNOZIRANI_LOAD> lista = new List<PROGNOZIRANI_LOAD>();


        public void Citanje()
        {
            XmlSerializer serz = new XmlSerializer(typeof(PROGNOZIRANI_LOAD));

            FileStream read = File.OpenRead("prog_2020_05_07.xml");
            StreamReader reader = new StreamReader(read);

            while (!reader.EndOfStream)
            {

                var result = (PROGNOZIRANI_LOAD)(serz.Deserialize(read));
                PL = result;
                lista.Add(PL);
            }

            foreach(PROGNOZIRANI_LOAD pp in lista)
            {
                if(pp.Sat > 25)
                {
                    Console.WriteLine("Greska u XML fajlu potrosnja ne moze biti veca od 25h u jednom danu");
                    return;
                }
            }
        }
    }
}

