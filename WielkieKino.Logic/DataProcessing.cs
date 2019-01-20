using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WielkieKino.Lib;

namespace WielkieKino.Logic
{
    /// <summary>
    /// Metody do napisania z wykorzystaniem LINQ (w składni zapytania, wyrażeń
    /// lambda lub mieszanej)
    /// </summary>
    public class DataProcessing
    {
        public List<string> WybierzFilmyZGatunku(List<Film> filmy, string gatunek)
        {
            // Właściwa odpowiedź: np. "Konan Destylator" dla "Fantasy"
            List<string> wynik = (from film in filmy
                         where film.Gatunek == gatunek
                         select film.Tytul).ToList();
            return wynik;
        }

        /// <summary>
        /// Sumujemy wpływy bez względu na datę seansu
        /// </summary>
        /// <param name="bilety"></param>
        /// <returns></returns>
        public double PodajCalkowiteWplywyZBiletow(List<Bilet> bilety)
        {
            // Właściwa odpowiedź: 400
            double wynik = (from bilet in bilety
                         select bilet.Cena).Sum();
            return wynik;
        }

        public List<Film> WybierzFilmyPokazywaneDanegoDnia(List<Seans> seanse, DateTime data)
        {
            List<Film> wynik = (from seans in seanse
                                where seans.Date.DayOfYear == data.DayOfYear
                                select seans.Film).ToList();
            return wynik;
        }


        /// <summary>
        /// Zwraca gatunek, z którego jest najwięcej filmów. Jeśli jest kilka takich
        /// gatunków, to zwraca dowolny z nich.
        /// </summary>
        /// <param name="filmy"></param>
        /// <returns></returns>
        public string NajpopularniejszyGatunek(List<Film> filmy)
        {
            // Właściwa odpowiedź: Obyczajowy
            string wynik = (from film in filmy
                            orderby film.Gatunek
                            select film.Gatunek).Last();
            return wynik;
        }

        public List<Sala> ZwrocSalePosortowanePoCalkowitejLiczbieMiejsc(List<Sala> sale)
        {
            // Właściwa odpowiedź: Kameralna, Bałtyk, Wisła (lub w odwrotnej kolejności)
            List<Sala> wynik = (from sala in sale
                                orderby (sala.LiczbaMiejscWRzedzie * sala.LiczbaRzedow)
                                select sala).ToList();
            return wynik;
        }

        public Sala ZwrocSaleGdzieJestNajwiecejSeansow(List<Seans> seanse, DateTime data1)
        {
            // Właściwa odpowiedź dla daty 2019-01-20: sala "Wisła" 
            Sala wynik = (from seans in seanse
                          where seans.Date.DayOfYear == data1.DayOfYear
                          orderby seans.Sala
                          select seans.Sala).Last();
                          
                       
            return null;
        }

        /// <summary>
        /// Uwaga: Nie wszystkie parametry przekazane do metody muszą być użyte przy
        /// implementacji. Jeśli jest kilka takich filmów, zwracamy dowolny.
        /// </summary>
        /// <param name="filmy"></param>
        /// <param name="bilety"></param>
        /// <returns></returns>
        public Film ZwrocFilmNaKtorySprzedanoNajwiecejBiletow(List<Film> filmy, List<Bilet> bilety)
        {
            //Właściwa odpowiedź: "Konan Destylator"
            //Film wynik = from bilet in bilety
            //             orderby (from bilet2 in bilety
            //                      orderby bilet2.)

            return null;
        }

 

        /// <summary>
        /// Uwaga: Nie wszystkie parametry metody muszą być wykorzystane przy
        /// implementacji. Filmy z takim samym przychodem zwracamy w dowolnej kolejności
        /// </summary>
        /// <param name="filmy"></param>
        /// <param name="bilety"></param>
        /// <returns></returns>
        public Film PosortujFilmyPoDochodach(List<Film> filmy, List<Bilet> bilety)
        {
            //Film wynik = (from bilet in bilety
            //              orderby 
            //               )
            return null;
        }


    }
}
