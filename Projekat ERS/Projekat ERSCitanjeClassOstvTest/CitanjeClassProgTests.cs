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
    public class CitanjeClassProgTests
    {
        [TestMethod()]
        public void CitanjeClassProgTest()
        {
            try
            {
                CitanjeClassOstv prog = new CitanjeClassOstv();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod()]
        public void AuditTabelaTest()
        {
            CitanjeClassOstv prog = new CitanjeClassOstv();
            try
            {
                prog.AuditTabela();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    

        [TestMethod()]
        public void CitanjeTest()
        {
        CitanjeClassOstv prog = new CitanjeClassOstv();
        try
        {
            prog.Citanje();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

        [TestMethod()]
        public void AuditGreskeTest()
        {
        CitanjeClassOstv prog = new CitanjeClassOstv();
        try
        {
            prog.AuditGreske();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    }
}