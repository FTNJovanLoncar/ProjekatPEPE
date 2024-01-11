using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_ERS
{
   public class CSVfile
    {
        public CSVfile(){
        }
        public void PravljenjeCSV()
        {
            string filePath = "output.csv";

            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLine("Naslov\n\n");
                   


                    Console.WriteLine($"CSV file napravljen na {filePath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
