using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class NitKlijenta
    {
        private NetworkStream tok;
        BinaryFormatter formater;

        public NitKlijenta(NetworkStream tok)
        {
            this.tok = tok;
            formater = new BinaryFormatter();
            ThreadStart ts = obradi;
            new Thread(ts).Start();
        }

        private void obradi()
        {
            try
            {
                int operacija = 0;
                while (operacija!=(int)Operacije.Kraj)
                {
                    TransferKlasa transfer = formater.Deserialize(tok) as TransferKlasa;
                    switch (transfer.Operacija)
                    {
                        case Operacije.VratiFestivale:
                            transfer.Rezultat = (List<Festival>)Broker.dajSesiju().vratiFestivale();
                            formater.Serialize(tok, transfer);
                            break;

                        case Operacije.SacuvajFestival:
                            transfer.Rezultat = (bool)Broker.dajSesiju().sacuvajFestival((Festival)transfer.TransferObjekat);
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacije.VratiFilmove:
                            transfer.Rezultat = (List<Film>)Broker.dajSesiju().vratiFilmove();
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacije.MaxID:
                            transfer.Rezultat = (int)Broker.dajSesiju().maxID();
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacije.VratiSveGradove:
                            transfer.Rezultat = (List<Grad>)Broker.dajSesiju().vratiGradove();
                            formater.Serialize(tok, transfer);
                            break;
                        case Operacije.Kraj:
                            operacija = 1;
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
