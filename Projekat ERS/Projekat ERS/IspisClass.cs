using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Projekat_ERS
{
    class IspisClass : IIspis
    {
        List<PROGNOZIRANI_LOAD> lista = new List<PROGNOZIRANI_LOAD>();

        CitanjeClassOstv ostv = new CitanjeClassOstv();
        CitanjeClassProg prog = new CitanjeClassProg();
        List<DateTime> listaVremena = new List<DateTime>();
        DateTime vreme;

        public void Preuzimanje(int a)
        {
            if (a == 1)
            {
                lista = ostv.uzimanjeListe();
                listaVremena = ostv.uzimanjeListeVremena();
            }
            else if(a == 2)
            {
                lista = prog.uzimanjeListe();
                listaVremena = prog.uzimanjeListeVremena();
            }
        }

        public void Ispis(int a)
        {
            XmlDocument dokument = new XmlDocument();

            XmlDeclaration declaration = dokument.CreateXmlDeclaration("1.0", "UTF-8", null);
            dokument.AppendChild(declaration);

            XmlElement root = dokument.CreateElement("PROGNOZIRANI_LOAD");
            dokument.AppendChild(root);

            XmlElement stavka = dokument.CreateElement("STAVKA");
            root.AppendChild(stavka);

            foreach (PROGNOZIRANI_LOAD pp in lista)
            {

                XmlElement load = dokument.CreateElement("LOAD");
                load.InnerText = pp.Load.ToString();
                stavka.AppendChild(load);

                if (a == 1) 
                {
                    XmlElement imeFajla = dokument.CreateElement("ImeFajla");
                    load.InnerText = "ostv_2020_05_07.xml";
                    load.AppendChild(imeFajla);
                }
                else if(a == 2)
                {
                    XmlElement imeFajla = dokument.CreateElement("ImeFajla");
                    load.InnerText = "prog_2020_05_07.xml";
                    load.AppendChild(imeFajla);
                }

                int i = 0;
                if (i > lista.Count)
                i = 0;
                    XmlElement vrem = dokument.CreateElement("Vreme");
                    vrem.InnerText = listaVremena[i].ToString();
                    load.AppendChild(vrem);
                    i++;
                

                XmlElement oblast = dokument.CreateElement("OBLAST");
                oblast.InnerText = pp.Oblast.ToString();
                stavka.AppendChild(oblast);
                foreach(PROGNOZIRANI_LOAD pe in lista)
                {
                    if(pp.Oblast == pe.Oblast)
                    {
                        XmlElement sat = dokument.CreateElement("SAT");
                        sat.InnerText = pp.Sat.ToString();
                        oblast.AppendChild(sat);
                    }
                }

            }


            if (a == 1)
            {
                dokument.Save("ostv.xml");
            }
            else if (a == 2)
            {
                dokument.Save("prog.xml");
            }

            Console.WriteLine("XML fajl napravljen.");

        }
    }
}
