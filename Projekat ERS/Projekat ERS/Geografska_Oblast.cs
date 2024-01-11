using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Projekat_ERS
{
    public class Geografska_Oblast : IGeografska_oblast
    {

        List<PodaciGeoOblasti> listaOblasti = new List<PodaciGeoOblasti>();
        int counter = 0;

        public Geografska_Oblast()
        {

        }

        public void geo_oblast()
        {
            Console.WriteLine("Unesite ime geo oblasti");
            string geoIme = Console.ReadLine();
            Console.WriteLine("Unesite sifru");
            string sif = Console.ReadLine();
            int sifra = int.Parse(sif);

            if (counter == 0)
            {
                listaOblasti.Add(new PodaciGeoOblasti(geoIme, sifra));
                XmlDocument doc = new XmlDocument();

                XmlDeclaration oblasti = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(oblasti);



                XmlElement geoOblast = doc.CreateElement("GEOGRAFSKA_OBLAST");
                geoOblast.InnerText = geoIme;

                XmlElement sifs = doc.CreateElement("SIFRA");
                sifs.InnerText = sifra.ToString();
                geoOblast.AppendChild(sifs);

                doc.AppendChild(geoOblast);


                doc.Save("geoOblasti.xml");

                Console.Write("Zadata oblast nije postojala u listi i sada je dodata\n");
                counter = 1;
            }

            foreach (PodaciGeoOblasti pp in listaOblasti)
            {
                if (geoIme != pp.ImeGeoOblasti)
                {

                    string filePath = "geoOblasti.xml";

                    XmlDocument xmlDoca = new XmlDocument();
                    xmlDoca.Load(filePath);

                    XmlElement geo = xmlDoca.CreateElement("GEOGRAFKSA");
                    geo.InnerText = geoIme;

                    XmlElement sifa = xmlDoca.CreateElement("SIFRA");
                    sifa.InnerText = sifra.ToString();
                    geo.AppendChild(sifa);

                    XmlElement rootElement = xmlDoca.DocumentElement;
                    rootElement.AppendChild(geo);

                    xmlDoca.Save(filePath);



                    Console.WriteLine("Zadata oblast nije postojala u listi i sada je dodata");
                }
            }
        }
    }
}
