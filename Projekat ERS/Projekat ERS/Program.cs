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
            Console.WriteLine("Unesite 1 za ostv, ili 2 za prog");
            int broj = int.Parse(Console.ReadLine());
            if (broj == 1) {
                cOstv.Citanje();
            }
            else if(broj == 2)
            {
                cProg.Citanje();
            }
        }
    }
}
