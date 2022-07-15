using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Projekcija
    {
       
        Festival festival;
        int id;
        DateTime datumVremeProjekcije;
        Film film;
        [Browsable(false)]
        public Festival Festival { get => festival; set => festival = value; }
        [Browsable(false)]
        public int Id { get => id; set => id = value; }
        [Browsable(false)]
        public Film Film { get => film; set => film = value; }
        public String Film1 { get => film.Naziv; set=>film.Naziv = value; }
        public String Reziser { get => film.Reziser; set => film.Reziser = value; }
        [DisplayName("Datum i vreme projekcije")]
        public DateTime DatumVremeProjekcije { get => datumVremeProjekcije; set => datumVremeProjekcije = value; }
    }
}
