using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Klijent
{
    public class Komunikacija
    {
        TcpClient klijent;
        BinaryFormatter formater;
        NetworkStream tok;

        public bool konektujSeNaServer()
        {
            try
            {
                klijent = new TcpClient("localhost", 9000);
                tok = klijent.GetStream();
                formater = new BinaryFormatter();
                return true;
            }
            catch (Exception ee)
            {

                System.Windows.Forms.MessageBox.Show("Konektuj se komunikacija " + ee.Message);
                return false;
            }
        }

        public void kraj()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.Kraj;
            formater.Serialize(tok, transfer);
        }
        public List<Grad> vratiGradove()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.VratiSveGradove;
            formater.Serialize(tok, transfer);

            transfer=(TransferKlasa)formater.Deserialize(tok);
            return (List<Grad>)transfer.Rezultat;


        }

        public int maxID()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.MaxID;
            formater.Serialize(tok, transfer);

            transfer = (TransferKlasa)formater.Deserialize(tok);
            return (int)transfer.Rezultat;


        }
        public List<Film> vratiSveFilmove()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.VratiFilmove;
            formater.Serialize(tok, transfer);

            transfer = (TransferKlasa)formater.Deserialize(tok);
            return (List<Film>)transfer.Rezultat;


        }

        public bool sacuvajFetival(Festival f)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.SacuvajFestival;
            transfer.TransferObjekat = f;
            formater.Serialize(tok, transfer);

            transfer = (TransferKlasa)formater.Deserialize(tok);
            return (bool)transfer.Rezultat;
        }

        public List<Festival> vratiFestivale()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.VratiFestivale;
            formater.Serialize(tok, transfer);

            transfer = (TransferKlasa)formater.Deserialize(tok);
            return (List<Festival>)transfer.Rezultat;


        }
    }
}
