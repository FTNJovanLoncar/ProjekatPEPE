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
    public class IspisClassTests
    {
        [TestMethod()]
        public void IspisTest()
        {

            IspisClass ispi = new IspisClass();
                try
                {
                int a = 1;
                ispi.Ispis(a);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            try
            {
                int a = 2;
                ispi.Ispis(a);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                int a = 3;
                ispi.Ispis(a);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}