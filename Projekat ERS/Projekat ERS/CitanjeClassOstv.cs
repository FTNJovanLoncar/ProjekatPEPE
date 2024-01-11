﻿using System;
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
        private int counter = 0;

        private PROGNOZIRANI_LOAD PL = new PROGNOZIRANI_LOAD();
        public bool EndOfStream { get; }
        public List<DateTime> ListaVremena { get => listaVremena; set => listaVremena = value; }
        internal List<PROGNOZIRANI_LOAD> Lista { get => lista; set => lista = value; }

        private List<PROGNOZIRANI_LOAD> lista = new List<PROGNOZIRANI_LOAD>();

       
        public void Citanje()
        {

            FileStream read = File.OpenRead("ostv_2020_05_07.xml");
            StreamReader reader = new StreamReader(read);
            string line;
            string errorMessage = "Greska u XML fajlu potrosnja ne moze biti veca od 25h u jednom danu";

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
                        if (PL.Sat > 25)
                        {
                            Console.WriteLine("Greska u XML fajlu potrosnja ne moze biti veca od 25h u jednom danu");
                            // AuditTabela.Audit();
                            // AuditError.LogErrorToOracleAudit(errorMessage);
                            if (counter == 0)
                            {
                                XmlDocument xmlDok = new XmlDocument();
                                XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                                xmlDoc.AppendChild(xmlDeclaration);

                                XmlElement audit = xmlDoc.CreateElement("AUDIT_TABELA");
                                xmlDoc.AppendChild(audit);

                                DateTime data = DateTime.Now;

                                XmlElement Greska = xmlDoc.CreateElement("GRESKA");
                                Greska.InnerText = data.ToString();
                                audit.AppendChild(Greska);

                                XmlElement fajl = xmlDoc.CreateElement("FAJL");
                                fajl.InnerText = "ostv_2020_05_07.xml";
                                audit.AppendChild(fajl);


                                xmlDoc.Save("audit_tabela_ostv.xml");

                                Console.WriteLine("Greska u listi podataka dan je preko 25 sati");
                                counter = 1;

                            }
                            else
                            {
                                string filePat = "audit_tabela_ostv.xml";

                                XmlDocument xmlDoca = new XmlDocument();

                                xmlDoca.Load(filePat);

                                XmlElement greskaa = xmlDoca.CreateElement("GRESKA");
                                DateTime dat = DateTime.Now;
                                greskaa.InnerText = dat.ToString();

                                XmlElement fajle = xmlDoca.CreateElement("FAJL");
                                fajle.InnerText = "ostv_2020_05_07.xml";
                                greskaa.AppendChild(fajle);

                                XmlElement rootElement = xmlDoca.DocumentElement;

                                rootElement.AppendChild(greskaa);

                                xmlDoca.Save(filePat);

                                Console.WriteLine("Greska u listi podataka dan je preko 25 sati");


                            }


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
    }
}


