using Microsoft.VisualStudio.TestTools.UnitTesting;
using WielkieKino.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WielkieKino.Dane;
using WielkieKino.Lib;

namespace WielkieKino.Logic.Tests
{
    [TestClass()]
    public class DataProcessingTests
    {
        List<Sala> sale = SkladDanych.Sale;
        List<Film> filmy = SkladDanych.Filmy;
        List<Seans> seanse = SkladDanych.Seanse;
        List<Bilet> bilety = SkladDanych.Bilety;
        DataProcessing dp = new DataProcessing();

        [TestMethod()]
        public void WybierzFilmyZGatunkuTest()
        {
            Assert.AreEqual(1, dp.WybierzFilmyZGatunku(filmy, "Fantasy").Count());
        
        }
        [TestMethod()]
        public void NajpopularniejszyGatunekTest()
        {
            Assert.AreEqual("Obyczajowy", dp.NajpopularniejszyGatunek(filmy));
        }
        [TestMethod()]
        public void ZwrocSalePosortowanePoCalkowitejLiczbieMiejscTest()
        {
            Assert.AreEqual(sale[2], dp.ZwrocSalePosortowanePoCalkowitejLiczbieMiejsc(sale)[0]);
        }
        [TestMethod()]
        public void PodajCalkowiteWplywyZBiletowTest()
        {
            Assert.AreEqual(400, dp.PodajCalkowiteWplywyZBiletow(bilety));
        }

    }
}