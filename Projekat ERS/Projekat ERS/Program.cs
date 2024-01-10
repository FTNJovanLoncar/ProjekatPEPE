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
            CitanjeClassOstv cOstv = new CitanjeClassOstv();
            CitanjeClassProg cProg = new CitanjeClassProg();
            IspisClass ispis = new IspisClass();
            IspisOP prognoza = new IspisOP();
            Console.WriteLine("Unesite 1 za ostv, ili 2 za prog");
            int broj = int.Parse(Console.ReadLine());
            cOstv.Citanje();
            cProg.Citanje();
            ispis.Ispis(broj);
            prognoza.ispisOstvarenojPotrosnji();
        }
    }
}
