using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_ERS
{
    public class IspisOP : IIspisOP
    {
        CitanjeClassOstv ostv = new CitanjeClassOstv();
        CitanjeClassProg prog = new CitanjeClassProg();

        List<PROGNOZIRANI_LOAD> ostvLista = new List<PROGNOZIRANI_LOAD>();
        List<PROGNOZIRANI_LOAD> progLista = new List<PROGNOZIRANI_LOAD>();
        List<DateTime> ostvVremeLista = new List<DateTime>();
        List<DateTime> progVremeLista = new List<DateTime>();
        private string tabela ="";

        public IspisOP()
        {

        }
        public void ispisOstvarenojPotrosnji()
        {
            ostvLista = ostv.uzimanjeListe();
            ostvVremeLista = ostv.uzimanjeListeVremena();
            
            progLista = prog.uzimanjeListe();
            progVremeLista = prog.uzimanjeListeVremena();

            Console.WriteLine("Unesite geografsku oblast: ");
            string oblast = Console.ReadLine();
            

            Console.WriteLine("Unesite datum: ");
            string vreme = Console.ReadLine();
  
            if (DateTime.TryParse(vreme, out DateTime dateTime))
            {
                int potrosnja = 0;
               
                for (int i = 0; i< progVremeLista.Count; i++)
                {
                    if(dateTime.Year == progVremeLista[i].Year && dateTime.Month == progVremeLista[i].Month && dateTime.Day == progVremeLista[i].Day && oblast == progLista[i].Oblast) 
                    {
                        tabela += "---------------------------Tabela relativnog odstupanja---------------------------\n";
                        tabela += "\n";
                        tabela += "Sat: ";
                        tabela += progLista[i].Sat.ToString();
                        tabela += "\n";
                        tabela += "LoadProg: ";
                        tabela += progLista[i].Load.ToString();
                        tabela += "\n";
                        tabela += "LoadOstv: ";
                        tabela += ostvLista[i].Load.ToString();
                        tabela += "\n";
                        potrosnja = ((ostvLista[i].Load - progLista[i].Load) / ostvLista[i].Load) * 100;
                        tabela += "Potrosnja: ";
                        tabela += potrosnja.ToString();
                        tabela += "---------------------------------------------------------------------------------";
                        tabela += "\n";
                        tabela += "\n";


                    }
                }
                
            }
            else
            {
                Console.WriteLine("Niste uneli dobar format.");
            }
            Console.WriteLine(tabela);
        }
    }
}
