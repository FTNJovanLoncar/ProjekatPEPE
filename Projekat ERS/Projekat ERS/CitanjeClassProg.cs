using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Projekat_ERS
{
   public class CitanjeClassProg : ICitanjeFajlova
    {

        public CitanjeClassProg()
        {
        }

        public List<DateTime> listaVremena = new List<DateTime>();
        DateTime vreme = DateTime.Now;

        private PROGNOZIRANI_LOAD PL = new PROGNOZIRANI_LOAD();
        public bool EndOfStream { get; }
        public List<DateTime> ListaVremena { get => listaVremena; set => listaVremena = value; }
        internal List<PROGNOZIRANI_LOAD> Lista { get => lista; set => lista = value; }

        private List<PROGNOZIRANI_LOAD> lista = new List<PROGNOZIRANI_LOAD>();



        public void Citanje()
        {
            FileStream read = File.OpenRead("prog_2020_05_07.xml");
            StreamReader reader = new StreamReader(read);
            string line;
            string errorMessage = "Greska u XML fajlu potrosnja ne moze biti veca od 25h u jednom danu";
            try
            {
                while (!reader.EndOfStream)
                {

                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load("prog_2020_05_07.xml");

                    XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/PROGNOZIRANI_LOAD/STAVKA");
                    foreach (XmlNode node in nodeList)
                    {
                        PL.Sat = int.Parse(node.SelectSingleNode("SAT").InnerText);
                        if (PL.Sat > 25)
                        {
                            Console.WriteLine("Greska u XML fajlu potrosnja ne moze biti veca od 25h u jednom danu");
                           // AuditTabela.Audit();
                          //  AuditError.LogErrorToOracleAudit(errorMessage);

                        }
                        PL.Load = int.Parse(node.SelectSingleNode("LOAD").InnerText);
                        PL.Oblast = node.SelectSingleNode("OBLAST").InnerText;
                        Console.WriteLine(PL.Sat + " " + PL.Load + " " + PL.Oblast);
                        Lista.Add(new PROGNOZIRANI_LOAD(PL.Sat, PL.Load, PL.Oblast));
                        vreme = DateTime.Now;
                        ListaVremena.Add(vreme);
                       
                      
                    }

                    
                        break;
                    }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public void printListe()
        {
            foreach(PROGNOZIRANI_LOAD pp in Lista)
            {
                Console.WriteLine(pp.Sat);
            }
        }

    }
}



