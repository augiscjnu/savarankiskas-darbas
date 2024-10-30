using Knygos.Core.Models;
using Knygos.Core.Repositories;
using System;
using System.Collections.Generic;

namespace Knygos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var repository = new KnyguRepository("knygos.txt");

            while (true)
            {
                Console.WriteLine("Pasirinkite veiksmą:\n1. Pagal autorių\n2. Pagal metus\n3. Klasikos žanras\n4. Baigti");
                string pasirinkimas = Console.ReadLine();

                switch (pasirinkimas)
                {
                    case "1":
                        RodytiKnygasPagalAutoriu(repository);
                        break;
                    case "2":
                        RodytiKnygasPagalMetus(repository);
                        break;
                    case "3":
                        RodytiKlasikosKnygas(repository);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Neteisingas pasirinkimas.");
                        break;
                }
            }
        }

        static void RodytiKnygasPagalAutoriu(KnyguRepository repository)
        {
            Console.Write("Autorius: ");
            var rezultatai = repository.RastiKnygasPagalAutoriu(Console.ReadLine());
            RodytiKnygas(rezultatai);
        }

        static void RodytiKnygasPagalMetus(KnyguRepository repository)
        {
            Console.Write("Metai: ");
            if (int.TryParse(Console.ReadLine(), out int metai))
            {
                var rezultatai = repository.RastiKnygasPagalMetus(metai);
                RodytiKnygas(rezultatai);
            }
            else
            {
                Console.WriteLine("Neteisingi metai.");
            }
        }

        static void RodytiKlasikosKnygas(KnyguRepository repository)
        {
            var rezultatai = repository.RastiKlasikosKnygas();
            RodytiKnygas(rezultatai);
        }

        static void RodytiKnygas(List<Knyga> knygos)
        {
            if (knygos.Count > 0)
            {
                foreach (var knyga in knygos)
                {
                    Console.WriteLine($"{knyga.KnygosID}: {knyga.Pavadinimas}, {knyga.Autorius}, {knyga.IsleidimoMetai}, {knyga.Zanras}");
                }
            }
            else
            {
                Console.WriteLine("Knygų nerasta.");
            }
        }
    }
}
