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

        private List<PROGNOZIRANI_LOAD> ostvLista = new List<PROGNOZIRANI_LOAD>();
        List<PROGNOZIRANI_LOAD> progLista = new List<PROGNOZIRANI_LOAD>();
        List<DateTime> ostvVremeLista = new List<DateTime>();
        List<DateTime> progVremeLista = new List<DateTime>();
        private string tabela ="";
        private double potrosnja;
        internal List<PROGNOZIRANI_LOAD> OstvLista { get => ostvLista; set => ostvLista = value; }

        public IspisOP()
        {

        }

      
        public void ispisOstvarenojPotrosnji()
        {
            ostv.Citanje();
            prog.Citanje();
            OstvLista = ostv.Lista;
            ostvVremeLista = ostv.ListaVremena;

            progLista = prog.Lista;
            progVremeLista = prog.ListaVremena;

           

            Console.WriteLine("Unesite geografsku oblast: ");
            string oblast = Console.ReadLine();


            Console.WriteLine("Unesite godinu: ");
            string godina = Console.ReadLine();
            int god = int.Parse(godina);
            if (god < 0 || god > 2024)
            {
                Console.WriteLine("Greska pri unosu godine");
            }

            Console.WriteLine("Unesite mesec: ");
            string mesec = Console.ReadLine();
            int mes = int.Parse(mesec);
            if (mes < 0 || mes > 12)
            {
                Console.WriteLine("Greska pri unosu meseca");
            }

            Console.WriteLine("Unesite dan: ");
            string dana = Console.ReadLine();
            int dan = int.Parse(dana);
            if (dan < 0 || dan > 31)
            {
                Console.WriteLine("Greska pri unosu dana");
            }
            

            for (int i = 0; i < OstvLista.Count() ; i++)
            {
                if (god == ostvVremeLista[i].Year && mes == ostvVremeLista[i].Month && dan == ostvVremeLista[i].Day && oblast == OstvLista[i].Oblast)
                { 

                tabela += "---------------------------Tabela relativnog odstupanja---------------------------\n";
                tabela += "\n";
                tabela += "Sat: ";
                tabela += OstvLista[i].Sat.ToString();
                tabela += "\n";
                tabela += "LoadProg: ";
                tabela += OstvLista[i].Load.ToString();
                tabela += "\n";
                tabela += "LoadOstv: ";
                tabela += OstvLista[i].Load.ToString();
                tabela += "\n";
                potrosnja = ((Convert.ToDouble(OstvLista[i].Load) - 2020) / Convert.ToDouble(OstvLista[i].Load)) * 100;
                tabela += "Potrosnja: ";
                tabela += potrosnja.ToString();    
                tabela += "\n";
                tabela += "---------------------------------------------------------------------------------";
                tabela += "\n";
                tabela += "\n";

                }
            }           
            Console.WriteLine(tabela);
        }
    }
}
