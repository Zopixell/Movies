using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Grad
    {
        int id;
        String ptt;
        String naziv;
        public override string ToString()
        {
            return naziv;
        }
        public int Id { get => id; set => id = value; }
        public string Ptt { get => ptt; set => ptt = value; }
        public string Naziv { get => naziv; set => naziv = value; }
    }
}
