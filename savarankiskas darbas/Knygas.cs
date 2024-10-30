namespace Knygos.Core.Models
{
    public class Knyga
    {
        public int KnygosID { get; set; }
        public string Pavadinimas { get; set; }
        public string Autorius { get; set; }
        public int IsleidimoMetai { get; set; }
        public string Zanras { get; set; }

        public Knyga() { }

        public Knyga(int id, string pavadinimas, string autorius, int isleidimoMetai, string zanras)
        {
            KnygosID = id;
            Pavadinimas = pavadinimas;
            Autorius = autorius;
            IsleidimoMetai = isleidimoMetai;
            Zanras = zanras;
        }
    }
}
