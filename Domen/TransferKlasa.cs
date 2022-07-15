﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public enum Operacije { Kraj=1,
        VratiSveGradove = 2,
        MaxID = 3,
        VratiFilmove = 4,
        SacuvajFestival = 5,
        VratiFestivale = 6
    }

    [Serializable]
    public class TransferKlasa
    {
        public Operacije Operacija;
        public Object TransferObjekat;
        public Object Rezultat;
    }
}
