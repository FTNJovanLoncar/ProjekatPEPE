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
    public class PodaciGeoOblastiTests
    {
        [TestMethod()]
        public void PodaciGeoOblastiTest()
        {
            try
            {
                PodaciGeoOblasti podaci = new PodaciGeoOblasti();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod()]
        public void PodaciGeoOblastiTest1()
        {
            string str = "VOJ";
            int i = 3;
            try
            {
                PodaciGeoOblasti podaci = new PodaciGeoOblasti(str, i);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}