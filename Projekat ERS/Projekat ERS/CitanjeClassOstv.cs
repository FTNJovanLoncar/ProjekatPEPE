using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace Projekat_ERS 
{
    class CitanjeClassOstv : CitanjeFajlova 
    {
        public CitanjeClassOstv()
        {
        }


        private PROGNOZIRANI_LOAD PL = new PROGNOZIRANI_LOAD();
        public bool EndOfStream { get; }
        List<PROGNOZIRANI_LOAD> lista = new List<PROGNOZIRANI_LOAD>();

      

        public void Citanje()
        {

            FileStream read = File.OpenRead("ostv_2020_05_07.xml");
            StreamReader reader = new StreamReader(read);


            while (!reader.EndOfStream)
            {
                
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("ostv_2020_05_07.xml");


                XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/PROGNOZIRANI_LOAD/STAVKA");
                foreach (XmlNode node in nodeList)
                {
                    PL.Sat = int.Parse(node.SelectSingleNode("SAT").InnerText);
                    PL.Load = int.Parse(node.SelectSingleNode("LOAD").InnerText);
                    PL.Oblast = node.SelectSingleNode("OBLAST").InnerText;
                    Console.WriteLine(PL.Sat + " " + PL.Load + " " + PL.Oblast);
                    lista.Add(PL);
                   
                }

            }

            foreach (PROGNOZIRANI_LOAD pp in lista)
            {
                if (pp.Sat > 25)
                {
                    Console.WriteLine("Greska u XML fajlu potrosnja ne moze biti veca od 25h u jednom danu");
                    return;
                }
            }
        }
    }
}


