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
   public class CitanjeClassOstv : ICitanjeFajlova
    {

        public CitanjeClassOstv()
        {
        }

        public List<DateTime> listaVremena = new List<DateTime>();
        DateTime vreme = DateTime.Now;

        private PROGNOZIRANI_LOAD PL = new PROGNOZIRANI_LOAD();
        public bool EndOfStream { get; }
        public List<DateTime> ListaVremena { get => listaVremena; set => listaVremena = value; }
        internal List<PROGNOZIRANI_LOAD> Lista { get => lista; set => lista = value; }

        private List<PROGNOZIRANI_LOAD> lista = new List<PROGNOZIRANI_LOAD>();

        public void AuditTabela()
        {
            // KREIRANJE AUDIT TABELE

            XmlDocument xmlDok = new XmlDocument();
            XmlDeclaration xmlDeclaration = xmlDok.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmlDok.AppendChild(xmlDeclaration);

            XmlElement audit = xmlDok.CreateElement("AUDIT_TABELA");
            xmlDok.AppendChild(audit);
         
            xmlDok.Save("audit_tabela_ostv.xml");           

            // KREIRANJE AUDIT TABELE
        }

        public void Citanje()
        {

            FileStream read = File.OpenRead("ostv_2020_05_07.xml");
            StreamReader reader = new StreamReader(read);
            string line;

            try
            {
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
        public void AuditGreske()
        {
            foreach (PROGNOZIRANI_LOAD pp in lista)
            {
                if (pp.Sat > 25)
                {
                    Console.WriteLine("Greska u XML fajlu potrosnja ne moze biti veca od 25h u jednom danu");
                    // AuditTabela.Audit();
                    //  AuditError.LogErrorToOracleAudit(errorMessage);

                    string filePat = "audit_tabela_prog.xml";

                    XmlDocument xmlDoca = new XmlDocument();

                    xmlDoca.Load(filePat);

                    XmlElement greskaa = xmlDoca.CreateElement("GRESKA");
                    DateTime dat = DateTime.Now;
                    greskaa.InnerText = dat.ToString();

                    XmlElement fajle = xmlDoca.CreateElement("FAJL");
                    fajle.InnerText = "prog_2020_05_07.xml";
                    greskaa.AppendChild(fajle);

                    XmlElement rootElement = xmlDoca.DocumentElement;

                    rootElement.AppendChild(greskaa);

                    xmlDoca.Save(filePat);

                }
            }
        }
    }
}


