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
    public class Geografska_OblastTests
    {
        [TestMethod()]
        public void Geografska_OblastTest()
        {           
            try
            {
                Geografska_Oblast geo = new Geografska_Oblast();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

     /*   [TestMethod()]
        public void geo_oblastTest()
        {
            Geografska_Oblast geo = new Geografska_Oblast();
            try
            {
                geo.geo_oblast();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
*/    }
}