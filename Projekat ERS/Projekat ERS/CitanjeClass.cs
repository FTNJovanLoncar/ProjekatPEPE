using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Projekat_ERS 
{
    class CitanjeClass : CitanjeFajlova 
    {
        PROGNOZIRANI_LOAD PL;
        void CitanjeFajlova.Citanje()
        {
            XmlSerializer serz = new XmlSerializer(typeof(PROGNOZIRANI_LOAD));

            FileStream read = File.OpenRead("ostv_2020_05_07.xml");
            var result = (PROGNOZIRANI_LOAD)(serz.Deserialize(read));
        }
    }
}
