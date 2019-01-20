using Microsoft.VisualStudio.TestTools.UnitTesting;
using WielkieKino.Dane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WielkieKino.Logic;
using WielkieKino.Lib;

namespace WielkieKino.Dane.Tests
{
    [TestClass()]
    public class MetodyPomocniczeTests
    {
        List<Sala> sale = SkladDanych.Sale;
        List<Film> filmy = SkladDanych.Filmy;
        List<Seans> seanse = SkladDanych.Seanse;
        List<Bilet> bilety = SkladDanych.Bilety;
        MetodyPomocnicze mp = new MetodyPomocnicze();



        [TestMethod()]
        public void CzyMoznaKupicBiletTest()
        {
            Assert.AreEqual(false, mp.CzyMoznaKupicBilet(bilety, seanse[0], 5, 5));
            Assert.AreEqual(true, mp.CzyMoznaKupicBilet(bilety, seanse[0], 4, 5));
        }

        [TestMethod()]
        public void CzyMoznaDodacSeansTest()
        {
            Assert.AreEqual(false, mp.CzyMoznaDodacSeans(seanse, sale[2], seanse[2].Date));
            Assert.AreEqual(false, mp.CzyMoznaDodacSeans(seanse, sale[1], seanse[1].Date));
        }

        [TestMethod()]
        public void LiczbaWolnychMiejscWSaliTest()
        {
            Assert.AreEqual(72, mp.LiczbaWolnychMiejscWSali(bilety, seanse[0]));
            Assert.AreNotEqual(73, mp.LiczbaWolnychMiejscWSali(bilety, seanse[0]));
        }

        [TestMethod()]
        public void CalkowitePrzychodyZBiletowTest()
        {
            Assert.AreEqual(400, mp.CalkowitePrzychodyZBiletow(bilety));
        }
    }
}