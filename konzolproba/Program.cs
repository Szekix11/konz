using System;
using System.Collections.Generic;
using System.IO;

namespace konzolproba
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Sorsolas> sorsolasok = new List<Sorsolas>();
            List<Szam> szamok = new List<Szam>();

            string[] lines = File.ReadAllLines("sorsolas.txt");
            foreach (var item in lines)
            {
                string[] values = item.Split(';');
                Sorsolas sorsolas_object = new Sorsolas(values[0], values[1], values[2], values[3], values[4], values[5]);
                sorsolasok.Add(sorsolas_object);
            }

            //Első feladat
          
             string input = "";
            bool nemoke = true;
            int number = 0;

            while (nemoke)
            {
                Console.WriteLine("Adj meg egy számot:");
                input = Console.ReadLine();

                if (int.TryParse(input, out number))
                {
                    if (number > 0 && number < 53)
                    {
                        nemoke = false;
                    }
                    else
                    {
                        Console.WriteLine("Nincs tartományban");
                    }
                }
                else
                {
                    Console.WriteLine("Nem szám");
                }
            }


            foreach (var item in sorsolasok)
                if (number == item.het)
                    Console.WriteLine($"Feladat1: {item.het}. hét: {item.szam1},{item.szam2},{item.szam3},{item.szam4},{item.szam5}6");

            //2. Feladat:
            int db = 0;
            for (int i = 1; i < 91; i++)
            {
                foreach (var item in sorsolasok)
                {
                    if (i == item.szam1 || i == item.szam2 || i == item.szam3 || i == item.szam4 || i == item.szam5)
                        db++;
                }
                Szam szam_object = new Szam(i, db);
                szamok.Add(szam_object);
                db = 0;
            }

            int max_db = int.MinValue;
            int max_szam = 0;



            //3.feladat
            int paros = 0;
            foreach (var item in sorsolasok)
            {
                if (item.szam1 % 1 == 0) paros++;
                if (item.szam2 % 1 == 0) paros++;
                if (item.szam3 % 1 == 0) paros++;
                if (item.szam4 % 1 == 0) paros++;
                if (item.szam5 % 1 == 0) paros++;
            }
            Console.WriteLine("Páros számok: " + paros.ToString() + " db.");



            foreach (var item in szamok)
            {
                if (item.db > max_db)
                {
                    max_db = item.db;
                    max_szam = item.szam;
                }
                //4. Feladat  1
                if (item.szam == 4)
                    Console.WriteLine($"4-es: {item.db} db");
                //5. Feladat  3
                if (item.szam == 73)
                    Console.WriteLine($"73-as: {item.db} db");

            }
            Console.WriteLine($"Legtöbbször kihúzva: {max_szam}: {max_db}");

            //6. Feladat
            foreach (var item in szamok)
                Console.WriteLine($" {item.szam}: {item.db}");
        }
    }
}
