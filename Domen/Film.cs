using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Film
    {
        int id;
        String naziv;
        String reziser;
        int godina;
        public override string ToString()
        {
            return naziv + " - " + godina;
        }
        public int Id { get => id; set => id = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public string Reziser { get => reziser; set => reziser = value; }
        public int Godina { get => godina; set => godina = value; }
    }
}
