using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent
{
    public partial class Dodaj : Form
    {
        private Komunikacija k;
        private Festival festival;
        Projekcija pr;

        public Dodaj()
        {
            InitializeComponent();
        }

        public Dodaj(Komunikacija k, Festival festival)
        {
            InitializeComponent();
            this.k = k;
            this.festival = festival;
        }

        private void Dodaj_Load(object sender, EventArgs e)
        {
            cbFilm.DataSource = k.vratiSveFilmove();

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            pr = new Projekcija();
            if (txtDatumVreme.Text == "")
            {

                MessageBox.Show("Unesite datum i vreme");
                return;
            }
            pr.DatumVremeProjekcije = DateTime.ParseExact(txtDatumVreme.Text, "dd.MM.yyyy HH:mm", null);
            pr.Film = (Film) cbFilm.SelectedItem;
            festival.ListaProjekcija.Add(pr);
            this.Close();
        }
    }
}
