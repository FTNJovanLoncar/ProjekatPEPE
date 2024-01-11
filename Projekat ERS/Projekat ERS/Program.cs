using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_ERS
{
    class Program
    {
        static void Main(string[] args)
        {
            CSVfile CSV = new CSVfile();
            
            CitanjeClassOstv cOstv = new CitanjeClassOstv();
            
            CitanjeClassProg cProg = new CitanjeClassProg();
            
            IspisClass ispis = new IspisClass();
            
            IspisOP prognoza = new IspisOP();
            
            Geografska_Oblast geo = new Geografska_Oblast();
            
            CSV.PravljenjeCSV(); //pravimo CSV fajl pre nego sto u njega upisemo
            
            cProg.AuditTabela(); // pravimo tabelu za greske na pocetku
            
            cOstv.AuditTabela();

            int broj = 0;

            do
            {
                Console.WriteLine("Unesite 1 za ostv, ili 2 za prog");

                broj = int.Parse(Console.ReadLine());
                if (broj == 1)
                {
                    cOstv.Citanje();
                    break;
                }
                else if (broj == 2)
                {
                    cProg.Citanje();
                    break;
                }
                else
                {
                    Console.WriteLine("NISTE UNELI DOBAR BROJ");
                }
            } while (true);

            cProg.AuditGreske(); // Belezi gresku ako je doslo do nje
            
            prognoza.ispisOstvarenojPotrosnji(); // 2.tacka
            
            geo.geo_oblast(); // 3.tacka
            
            ispis.Ispis(broj); // ispis nove tabele
            
            Console.ReadLine();
        }
    }
}
