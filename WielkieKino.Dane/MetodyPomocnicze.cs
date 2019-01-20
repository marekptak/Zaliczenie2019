using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WielkieKino.Lib;

namespace WielkieKino.Dane
{
    /// <summary>
    /// Metody do implementacji (raczej) bez wykorzystania LINQ
    /// </summary>
    public class MetodyPomocnicze
    {


        /// <summary>
        /// Sprawdzenie czy dane miejsce w konkretnym seansie nie jest zajęte
        /// </summary>
        /// <param name="sprzedaneBilety"></param>
        /// <param name="seans"></param>
        /// <param name="rzad"></param>
        /// <param name="miejsce"></param>
        /// <returns></returns>
        public bool CzyMoznaKupicBilet(List<Bilet> sprzedaneBilety, Seans seans, int rzad, int miejsce)
        {
            bool czyMoznaKupic = true;
            foreach (Bilet bilet in sprzedaneBilety)
            {
                if (bilet.Seans == seans && bilet.Rzad == rzad && bilet.Miejsce == miejsce)
                {
                    czyMoznaKupic = false;
                }
            }
            return czyMoznaKupic;
        }

        /// <summary>
        /// Sprawdzenie czy można projekcja filmu o zadanej godzinie nie nakłada się z już
        /// dodanymi seansami w tej sali.
        /// </summary>
        /// <param name="aktualneSeanse"></param>
        /// <param name="sala"></param>
        /// <param name="film"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool CzyMoznaDodacSeans(List<Seans> aktualneSeanse, Sala sala, DateTime data)
        {
            // np. nie można zagrać filmu "Egzamin" w sali Kameralnej 2019-01-20 o 17:00
            // można natomiast zagrać "Egzamin" w tej sali 2019-01-20 o 14:00
            bool wolnaSala = true;
            foreach (Seans seans in aktualneSeanse)
            {
                if (seans.Sala == sala && seans.Date == data)
                {
                    wolnaSala = false;
                }
                //metodanie uwzględnia czasu trwania filmów
            }
            return wolnaSala;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sprzedaneBilety">wszystkie sprzedane bilety</param>
        /// <param name="seansDoSprawdzenia"></param>
        /// <returns></returns>
        public int LiczbaWolnychMiejscWSali(List<Bilet> sprzedaneBilety, Seans seansDoSprawdzenia)
        {
            // Właściwa odpowiedź: np. na pierwszy seans z listy seansów w klasie SkladDanych są 72 miejsca
            
            int liczbaKupionychBiletowNaSeans = 0;
            foreach (Bilet bilet in sprzedaneBilety)
            {
                if (bilet.Seans == seansDoSprawdzenia)
                {
                    liczbaKupionychBiletowNaSeans += 1;
                }

            }
            int liczbaWolnychMiejscWSali = (seansDoSprawdzenia.Sala.LiczbaMiejscWRzedzie
                        * seansDoSprawdzenia.Sala.LiczbaRzedow) - liczbaKupionychBiletowNaSeans;

             return liczbaWolnychMiejscWSali;
            }

            public double CalkowitePrzychodyZBiletow(List<Bilet> sprzedaneBilety)
            {

            // Właściwa odpowiedź: 400.00
            double suma = 0;
                foreach(Bilet bilet in sprzedaneBilety)
            {
                suma += bilet.Cena;
            }

                return suma;
            }
        }
    } 
