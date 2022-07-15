using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        Socket soket;

        public bool poveziSe()
        {
            try
            {
                soket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ep = new IPEndPoint(IPAddress.Any, 9000);
                soket.Bind(ep);
                ThreadStart ts = osluskuj;
                new Thread(ts).Start();

                return true;
            }
            catch (Exception ee)
            {

                System.Windows.Forms.MessageBox.Show("Pokreni server " + ee.Message);
                return false;
            }
        }
        public void zaustaviServer()
        {

            try
            {
                soket.Close();
            }
            catch (Exception ee)
            {
                System.Windows.Forms.MessageBox.Show("Zaustavi server " + ee.Message);
                throw;
            }
        }
        private void osluskuj()
        {
            try
            {
                while (true)
                {
                    soket.Listen(8);
                    Socket klijent = soket.Accept();
                    NetworkStream tok = new NetworkStream(klijent);
                    new NitKlijenta(tok);
                }
            }
            catch (Exception ee)
            {

                System.Windows.Forms.MessageBox.Show("Osluskuj " + ee.Message);
                throw;
            }
        }
    }
}
