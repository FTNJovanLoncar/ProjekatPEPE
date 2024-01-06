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

        public void Preuzimanje(int a)
        {
            if (a == 1)
            {
                lista = ostv.uzimanjeListe();
            }
            else if(a == 2)
            {
                lista = prog.uzimanjeListe();
            }
        }

        public void Ispis(int a)
        {
            XmlDocument dokument = new XmlDocument();

            XmlDeclaration declaration = dokument.CreateXmlDeclaration("1.0", "UTF-8", null);
            dokument.AppendChild(declaration);

            XmlElement root = dokument.CreateElement("PROGNOZIRANI_LOAD");
            dokument.AppendChild(declaration);

            XmlElement stavka = dokument.CreateElement("STAVKA");
            root.AppendChild(stavka);

            foreach (PROGNOZIRANI_LOAD pp in lista)
            {

                XmlElement sat = dokument.CreateElement("SAT");
                sat.InnerText = pp.Sat.ToString();
                stavka.AppendChild(sat);

                XmlElement load = dokument.CreateElement("LOAD");
                load.InnerText = pp.Load.ToString();
                stavka.AppendChild(load);

                XmlElement oblast = dokument.CreateElement("OBLAST");
                oblast.InnerText = pp.Oblast.ToString();
                stavka.AppendChild(oblast);

            }


            if (a == 1)
            {
                dokument.Save("ostv.xml");
            }
            else if (a == 2)
            {
                dokument.Save("prog.xml");
            }

            Console.WriteLine("XML file created successfully.");

        }
    }
}
