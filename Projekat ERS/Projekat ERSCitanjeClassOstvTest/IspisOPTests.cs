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
    public class IspisOPTests
    {
        [TestMethod()]
        public void IspisOPTest()
        {
            try
            {
                IspisOP ispOp = new IspisOP();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod()]
        public void ispisOstvarenojPotrosnjiTest()
        {
            try
            {
                IspisOP ispOp = new IspisOP();
                ispOp.ispisOstvarenojPotrosnji();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}