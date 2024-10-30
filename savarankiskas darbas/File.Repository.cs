using Knygos.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Knygos.Core.Repositories
{
    public class KnyguRepository
    {
        private List<Knyga> knygos;

        public KnyguRepository(string fileLocation)
        {
            knygos = File.ReadLines(fileLocation)
                .Select(eilute =>
                {
                    var duomenys = eilute.Split(',');
                    return new Knyga(int.Parse(duomenys[0]), duomenys[1], duomenys[2], int.Parse(duomenys[3]), duomenys[4]);
                }).ToList();
        }

        public List<Knyga> RastiKnygasPagalAutoriu(string autorius) =>
            knygos.Where(k => k.Autorius.Contains(autorius, StringComparison.OrdinalIgnoreCase)).ToList();

        public List<Knyga> RastiKnygasPagalMetus(int metai) =>
            knygos.Where(k => k.IsleidimoMetai >= metai).ToList();

        public List<Knyga> RastiKlasikosKnygas() =>
            knygos.Where(k => k.Zanras.Equals("Classic", StringComparison.OrdinalIgnoreCase)).ToList();
    }
}
