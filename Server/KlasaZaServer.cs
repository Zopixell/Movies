using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    [Serializable]
    public class KlasaZaServer
    {
        String naziv;
        String reziser;
        int godina;
        int brojProjekcija;

        public string Naziv { get => naziv; set => naziv = value; }
        public string Reziser { get => reziser; set => reziser = value; }
        public int Godina { get => godina; set => godina = value; }
        [DisplayName("Broj projekcija")]
        public int BrojProjekcija { get => brojProjekcija; set => brojProjekcija = value; }
    }
}
