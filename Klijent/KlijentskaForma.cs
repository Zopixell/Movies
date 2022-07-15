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
    public partial class KlijentskaForma : Form
    {
        Komunikacija k;
        Festival festival;

        public KlijentskaForma()
        {
            InitializeComponent();
        }

        private void KlijentskaForma_Load(object sender, EventArgs e)
        {
            k = new Komunikacija();
            festival = new Festival();
            if (k.konektujSeNaServer())
            {
                this.Text = "Povezana komunikacija";
                cbGrad.DataSource = k.vratiGradove();
                dataGridView1.DataSource = festival.ListaProjekcija;
                dataGridView1.AllowUserToAddRows = false;
                //DataGridViewComboBoxColumn film = new DataGridViewComboBoxColumn();
                //film.DataSource = k.vratiGradove();
                //film.DataPropertyName = "Film";
                //dataGridView1.Columns.Add(film);
            }
        }

        private void KlijentskaForma_FormClosed(object sender, FormClosedEventArgs e)
        {
            k.kraj();
        }

        private void btnKreirajSifru_Click(object sender, EventArgs e)
        {
            txtFestivalID.Text = k.maxID().ToString();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            new Dodaj(k,festival).ShowDialog();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            Projekcija p = new Projekcija();
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Morate odabrati barem jedan red za brisanje");
                return;
            }
            p = (Projekcija)dataGridView1.CurrentRow.DataBoundItem;
            if (p == null)
            {
                MessageBox.Show("Niste odabrali projekciju");
                return;
            }
            festival.ListaProjekcija.Remove(p);
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (txtDatumDo.Text == "")
            {
                MessageBox.Show("Unesite datum");
                return;
            }

            if (txtDatumDo.Text == "")
            {
                MessageBox.Show("Unesite datum");
                return;
            }
            if (txtNaziv.Text == "")
            {
                MessageBox.Show("Unesite naziv festivala");
                return;
            }
            if (festival.ListaProjekcija.Count < 1)
            {
                MessageBox.Show("Festival mora imati barem jednu projekciju");
                return;

            }
           foreach(Projekcija pr in festival.ListaProjekcija)
            {
                if(pr.DatumVremeProjekcije>festival.DatumDo || pr.DatumVremeProjekcije < festival.DatumOd)
                {
                    MessageBox.Show("Projekcija nije u okviru definisanog intervala");
                    break;
                }

            }
            festival.Id =Int32.Parse(txtFestivalID.Text);
            festival.Naziv = txtNaziv.Text;
            festival.DatumOd = DateTime.ParseExact(txtDatumOD.Text, "dd.MM.yyyy", null);
            festival.DatumDo = DateTime.ParseExact(txtDatumDo.Text, "dd.MM.yyyy", null);
            festival.Grad =(Grad)cbGrad.SelectedItem;
            if (k.sacuvajFetival(festival))
            {

                MessageBox.Show("Uspesno sacuvan festival");
                return;
            }
            else
            {
                MessageBox.Show("Niste sacuvali festival");
                return;
            }
        }
    }
}
