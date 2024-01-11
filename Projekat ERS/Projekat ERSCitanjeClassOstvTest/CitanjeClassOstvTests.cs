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
    public class CitanjeClassOstvTests
    {
        [TestMethod()]
        public void CitanjeClassOstvTest()
        {
            
            try
            {
                CitanjeClassOstv ostv = new CitanjeClassOstv();
  
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    

        [TestMethod()]
        public void AuditTabelaTest()
        {
            CitanjeClassOstv ostv = new CitanjeClassOstv();
            try
            {
                ostv.AuditTabela();
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod()]
        public void CitanjeTest()
        {

            CitanjeClassOstv ostv = new CitanjeClassOstv();
            try
            {
                ostv.Citanje();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod()]
        public void AuditGreskeTest()
        {
            CitanjeClassOstv ostv = new CitanjeClassOstv();
            try
            {
                ostv.AuditGreske();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}