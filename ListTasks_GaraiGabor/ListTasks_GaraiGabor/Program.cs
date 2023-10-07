using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListTasks_GaraiGabor
{
    internal class Program
    {
        //Függvény, ami kiíja a listába ágyazott lista elemeit(2)
        static void IntListInListWrite(List<List<int>> list)
        {
            for (int i = 0; i < list.Count(); i++)
            {
                Console.Write($"#{i + 1} Pár --> ");
                for (int j = 0; j < list[i].Count(); j++)
                {
                    Console.Write($"{list[i][j]} ");
                }
                Console.WriteLine();
            }
        }

        // Függvény, ami kiírja a számos lista elemeit
        static void IntListWrite(List<int> list)
        {
            for (int i = 0; i < list.Count(); i++)
                Console.Write($"{list[i]} ");
            Console.WriteLine();
        }

        // Függvény, ami kiírja a számos lista elemeit
        static void StringListWrite(List<string> list)
        {
            for (int i = 0; i < list.Count(); i++)
                if (i != list.Count - 1)
                    Console.Write($"{list[i]}, ");
                else
                    Console.WriteLine(list[i]);
            Console.WriteLine();
        }

        // Metódus, ami megvizsgálja, hogy prím e a szám
        static bool IsPrim(int num)
        {
            if (num <= 1)
                return false;

            for (int j = 2; j < 100; j++)
            {
                if (num % j == 0 && num != j) return false;
            }

            return true;
        }

        // Függvény az eredmény kiíráshoz
        static void FeladatKiIr(List<int> list, string feladat)
        {
            Console.Write("A lista elemei: ");
            IntListWrite(list);
            Console.WriteLine();
            Console.WriteLine(feladat);
        }

        //Metódus lista feltöltéséhez random számokkal
        static List<int> ListaFeltolt(int db, int min, int max)
        {
            List<int> list = new List<int>();
            Random r = new Random();
            for (int i = 0; i < db; i++)
                list.Add(r.Next(min, max));

            return list;
        }


        //Feladat01 Metódus --> Létrehozunk egy listába ágyazott listát, majd visszadjuk a szorzó párosokat
        static List<List<int>> Task01()
        {
            List<int> integers = new List<int> { 2, 4, 6, 8, 10 };
            List<List<int>> result = new List<List<int>>();
            for (int i = 0; i < integers.Count(); i++)
            {
                for (int j = i + 1; j < integers.Count(); j++)
                {
                    if (Math.Max(integers[i], integers[j]) % Math.Min(integers[i], integers[j]) == 0
                        &&
                        integers[i] != integers[j])
                    {
                        result.Add(new List<int>() { integers[i], integers[j] });
                    }
                }
            }

            FeladatKiIr(integers, "Ebből a párosok: ");

            return result;
        }

        //Feladat02 Függvény --> Megvizsgáljuk egy lista szavainak a hosszúságát, majd az átlag és a leghosszabb szó visszadása
        static void Task02(List<string> words)
        {
            double avg = 0;
            int max = 0;
            for (int i = 0; i < words.Count; i++)
            {
                avg += words[i].Length;
                if (words[i].Length > max)
                {
                    max = words[i].Length;
                }
            }
            avg /= words.Count();

            //A feladat és elemeinek kiírása
            Console.Write("A lista elemei: ");
            foreach (string word in words)
            {
                if (!(word == words[words.Count - 1]))
                    Console.Write($"{word}, ");
                else
                    Console.WriteLine($"{word}");
            }
            Console.WriteLine();
            Console.WriteLine($"A lista átlaga:\n{Math.Round(avg)} \nA leghosszabb szó hossza pedig:\n{max}");
        }

        //Feladat03 Metódus --> Random számok létrehozása egy listában, majd a prímek visszaadása
        static List<int> Task03()
        {

            List<int> ints = new List<int>();

            //Lista feltöltése

            ints = ListaFeltolt(30, 1, 101);

            // Ciklus, hogy feltöltsük az eredmény listánkat, a prím számokkal

            List<int> result = new List<int>();
            for (int i = 0; i < ints.Count; i++)
            {
                if (IsPrim(ints[i]))
                {
                    result.Add(ints[i]);
                }
            }
            FeladatKiIr(ints, "Ebből a prímek: ");

            return result;
        }

        //Feladat04 Metódus -> Duplikált elemek eltávolítása egy listából, majd az új lista visszadása
        static List<int> Task04()
        {
            List<int> integers = new List<int>();
            List<int> result = new List<int>();

            integers = ListaFeltolt(30, 1, 10);

            for (int i = 0; i < integers.Count; i++)
            {
                if (!result.Contains(integers[i]))
                    result.Add(integers[i]);
            }

            FeladatKiIr(integers, "A lista elemei dublikálás nélkül: ");
            return result;
        }

        //Feladat05 Metódus --> A második legnagyobb szám visszaadása
        static int Task05()
        {
            List<int> ints = new List<int>();
            ints = ListaFeltolt(30, 1, 101);

            int max = ints[0];
            int secondMax = 0;

            for (int i = 1; i < ints.Count; i++)
            {
                if (ints[i] > max)
                {
                    secondMax = max;
                    max = ints[i];
                }
                else if (ints[i] > secondMax && ints[i] < max)
                    secondMax = ints[i];
            }
            Console.WriteLine("A lista elemei:");
            IntListWrite(ints);
            Console.WriteLine();
            Console.WriteLine("Ebből a második legnagyobb:");
            return secondMax;
        }

        //Feladat06 Metódus --> Palindron szavak visszaadása egy listából
        static List<string> Task06()
        {
            List<string> words = new List<string> { "búb", "pép", "halmaz", "apa", "körte", "alma", "bob", "torta" };
            List<string> result = new List<string>();

            foreach (string word in words)
            {
                bool palindron = true;
                int index = 0;
                for (int i = word.Length - 1; i > 0; i--)
                {
                    if (word[i] != word[index])
                    {
                        palindron = false;
                    }
                    index++;
                }
                if (palindron)
                {
                    result.Add(word);
                }
            }

            //A feladat és elemeinek kiírása
            Console.Write("A lista elemei: ");
            foreach (string word in words)
            {
                if (!(word == words[words.Count - 1]))
                    Console.Write($"{word}, ");
                else
                    Console.WriteLine($"{word}");
            }
            Console.WriteLine();
            Console.WriteLine("Ebből a palindronok:");

            return result;
        }

        //Feladat07 Függvény --> Összesen hány számjegy van a listában 
        static int Task07()
        {
            //Feladatban nem volt kritérium ezért negatív értékkel nem tesz különbséget a függvény
            int result = 0;

            List<int> ints = new List<int>();
            ints = ListaFeltolt(25, -10000, 10000);

            foreach (int i in ints)
            {
                if (i >= 0)
                {
                    if (i < 10) result++;
                    else if (i < 100) result += 2;
                    else if (i < 1000) result += 3;
                    else if (i < 10000) result += 4;
                    else if (i < 100000) result += 5;
                    else if (i < 1000000) result += 6;
                    else if (i < 10000000) result += 7;
                    else if (i < 100000000) result += 8;
                    else if (i < 1000000000) result += 9;
                    else
                        result += 10;
                }
                else
                {
                    if (i > -10) result++;
                    else if (i > -100) result += 2;
                    else if (i > -1000) result += 3;
                    else if (i > -10000) result += 4;
                    else if (i > -100000) result += 5;
                    else if (i > -1000000) result += 6;
                    else if (i > -10000000) result += 7;
                    else if (i > -100000000) result += 8;
                    else if (i > -1000000000) result += 9;
                    else
                        result += 10;
                }
            }
            FeladatKiIr(ints, "Az összes számjegy(db):");
            Console.WriteLine();
            return result;
        }

        //Feladat08 Metódus --> Két lista azaons indexű elemeinek az összeadása,
        //majd egy új listában visszaadása
        static List<int> Task08()
        {
            List<int> result = new List<int>();
            List<int> integers = ListaFeltolt(15, 1, 50);
            List<int> integers2 = ListaFeltolt(15, -10, 50);

            for (int i = 0; i < integers.Count; i++)
            {
                int sum = integers[i] + integers2[i];
                result.Add(sum);
            }
            Console.WriteLine("A két lista elemei:");
            IntListWrite(integers);
            Console.WriteLine();
            IntListWrite(integers2);
            Console.WriteLine();
            Console.WriteLine("Az azonos indexű elemek összege pedig:");

            return result;
        }

        //Feladat 10 Metódus --> két lista összefűzésére, majd visszaadása egy harmadikban
        static List<string> Task10()
        {
            //Az első lista létrehozása és feltöltése stringekkel
            List<string> list = new List<string> { "alma", "körte", "barack" };

            //A második lista létrehozása és feltöltése stringekkel
            List<string> list2 = new List<string> { "narancs", "citrom", "dinnye" };

            //A harmadik lista létrehozása és értéknek átadjuk a 2 lista összefűzését
            List<string> list3 = list.Concat(list2).ToList();

            Console.WriteLine("Az első lista: ");
            StringListWrite(list);
            Console.WriteLine();
            Console.WriteLine("A második lista: ");
            StringListWrite(list2);
            Console.WriteLine();
            Console.WriteLine("A kettő összefűzve: ");

            return list3;

        }

        static void Main(string[] args)
        {
            //Feladat01
            Console.WriteLine("Feladat 01");
            Console.WriteLine();
            IntListInListWrite(Task01());
            Console.WriteLine();

            //Feladat02
            Console.WriteLine("Feladat 02");
            Console.WriteLine();
            Task02(new List<string> { "Ez", "egy", "régóta", "elfogadott", "tény", "miszerint", "egy", "olvasót", "zavarja", "az", "olvasható", "szöveg", "miközben", "a", "szöveg", "elrendezését", "nézi" });
            Console.WriteLine();

            //Feladat03
            Console.WriteLine("Feladat 03");
            Console.WriteLine();
            IntListWrite(Task03());
            Console.WriteLine();

            //Feladat04
            Console.WriteLine("Feladat 04");
            Console.WriteLine();
            IntListWrite(Task04());
            Console.WriteLine();

            //Feladat05
            Console.WriteLine("Feladat 05");
            Console.WriteLine();
            Console.WriteLine(Task05());
            Console.WriteLine();

            //Feladat06
            Console.WriteLine("Feladat 06");
            Console.WriteLine();
            StringListWrite(Task06());
            Console.WriteLine();

            //Feladat07
            Console.WriteLine("Feladat 07");
            Console.WriteLine();
            Console.WriteLine(Task07());
            Console.WriteLine();

            //Feladat08
            Console.WriteLine("Feladat 08");
            Console.WriteLine();
            IntListWrite(Task08());
            Console.WriteLine();

            //Feladat10
            Console.WriteLine("Feladat 10");
            Console.WriteLine();
            StringListWrite(Task10());
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
