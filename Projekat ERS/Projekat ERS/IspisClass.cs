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

       List<DateTime> listaVremena = new List<DateTime>();
        CitanjeClassOstv ostv = new CitanjeClassOstv();
        CitanjeClassProg prog = new CitanjeClassProg();
        int i = 0;

        
        public void Ispis(int a)
        {
            if (a == 1)
            {
                ostv.Citanje();
                listaVremena = ostv.ListaVremena;
                lista = ostv.Lista;

            }
            else if (a == 2)
            {
                prog.Citanje();
                lista = prog.Lista;
                listaVremena = prog.ListaVremena;
            }

            XmlDocument dokument = new XmlDocument();

            XmlDeclaration declaration = dokument.CreateXmlDeclaration("1.0", "UTF-8", null);
            dokument.AppendChild(declaration);

            XmlElement root = dokument.CreateElement("PROGNOZIRANI_LOAD"); 
            dokument.AppendChild(root);

            foreach (PROGNOZIRANI_LOAD pp in lista)
            {
                XmlElement stavka = dokument.CreateElement("STAVKA");

                XmlElement load = dokument.CreateElement("LOAD");
                load.InnerText = pp.Load.ToString();

                XmlElement imeFajla = dokument.CreateElement("ImeFajla");
                imeFajla.InnerText = (a == 1) ? "ostv_2020_05_07.xml" : "prog_2020_05_07.xml";
                load.AppendChild(imeFajla);

                if(i > listaVremena.Count())
                {
                    i = 0;
                }
                XmlElement vrem = dokument.CreateElement("Vreme");
                vrem.InnerText = listaVremena[0].ToString();
                load.AppendChild(vrem);
                i++;

                stavka.AppendChild(load);

                XmlElement oblast = dokument.CreateElement("OBLAST");
                oblast.InnerText = pp.Oblast;

                XmlElement sat = dokument.CreateElement("SAT");
                sat.InnerText = pp.Sat.ToString();
                oblast.AppendChild(sat);

                stavka.AppendChild(oblast);
                root.AppendChild(stavka);
            }

            string fileName = (a == 1) ? "ostv.xml" : "prog.xml";
            dokument.Save(fileName);

            Console.WriteLine("XML fajl napravljen.");
        }
    }
}
