using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekat_ERS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_ERS.Tests
{
    [TestClass()]
    public class PROGNOZIRANI_LOADTests
    {
        [TestMethod()]
        public void PROGNOZIRANI_LOADTest()
        {
            try
            {
                PROGNOZIRANI_LOAD progLoad = new PROGNOZIRANI_LOAD();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod()]
        public void PROGNOZIRANI_LOADTest1()
        {
            int i = 4;
            int i1 = 2560;
            string str ="BGD";
            try
            {
                PROGNOZIRANI_LOAD progLoad = new PROGNOZIRANI_LOAD(i,i1,str);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    
}