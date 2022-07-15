using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class ServerForma : Form
    {
        Server s;
        Timer t;
        public ServerForma()
        {
            InitializeComponent();
        }

        private void ServerForma_Load(object sender, EventArgs e)
        {
            s = new Server();
            if (s.poveziSe())
            {
                this.Text = "POVEZAN SERVER";
                t = new Timer();
                t.Interval = 10000;
                t.Tick += osvezi;
                t.Start();
            }

        }

        private void osvezi(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new BindingList<KlasaZaServer>(Broker.dajSesiju().vratiZaServer());
        }

        private void ServerForma_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnPronadji_Click(object sender, EventArgs e)
        {
            string s = txtPretraga.Text;

           
            DateTime datu;
            DateTime.TryParse(txtDatum.Text, out datu);

            if (checkDatum.Checked)
            {
                dataGridView1.DataSource = new BindingList<KlasaZaServer>(Broker.dajSesiju().listaFilterDatum(datu));
            }
            if (checkNaziv.Checked)
            { 
                dataGridView1.DataSource = new BindingList<KlasaZaServer>(Broker.dajSesiju().listaFilterNaziv(s));
            }
        }
    }
}
