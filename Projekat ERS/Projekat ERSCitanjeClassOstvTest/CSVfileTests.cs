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
    public class CSVfileTests
    {
        [TestMethod()]
        public void CSVfileTest()
        {
            try
            {
                CSVfile csv = new CSVfile();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod()]
        public void PravljenjeCSVTest()
        {
            try
            {
                CSVfile csv = new CSVfile();
                csv.PravljenjeCSV();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}