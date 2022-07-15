using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Festival
    {
        int id;
        String naziv;
        DateTime datumOd;
        DateTime datumDo;
        Grad grad;
        BindingList<Projekcija> listaProjekcija = new BindingList<Projekcija>();

        public int Id { get => id; set => id = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public DateTime DatumOd { get => datumOd; set => datumOd = value; }
        public DateTime DatumDo { get => datumDo; set => datumDo = value; }
        public Grad Grad { get => grad; set => grad = value; }
        public BindingList<Projekcija> ListaProjekcija { get => listaProjekcija; set => listaProjekcija = value; }
    }
}
