using Domen;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Broker
    {
        SqlCommand komanda;
        SqlConnection konekcija;
        SqlTransaction transakcija;

         Broker()
        {
            konekcija = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Septembar_2018;Integrated Security=True;");
            komanda = konekcija.CreateCommand();
        }
        static Broker instanca;
        public static Broker dajSesiju()
        {
            if (instanca == null) instanca = new Broker();
            return instanca;
        }
        public List<Grad> vratiGradove()
        {
            List<Grad> lista = new List<Grad>();

            try
            {
                konekcija.Open();
                komanda.CommandText = "Select * from Grad";
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Grad g = new Grad();
                    g.Id = citac.GetInt32(0);
                    g.Ptt = citac.GetString(1);
                    g.Naziv = citac.GetString(2);
                    lista.Add(g);

                }
                citac.Close();
                return lista;
            }
            catch (Exception eee)
            {
                System.Windows.Forms.MessageBox.Show("Vrati grad  " + eee.Message);
                throw;
            }
            finally { if (konekcija != null) konekcija.Close(); }

        }
        public int maxID()
        {
            try
            {
                try
                {
                    int br = 0;
                    konekcija.Open();
                    komanda.CommandText = "Select max(FestivalID) from Festival";
                    br = (int)komanda.ExecuteScalar();
                   
                    return br + 1;
                }
                catch (Exception)
                {

                    return 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { if(konekcija!=null) konekcija.Close(); }


        }
        public List<Film> vratiFilmove()
        {
            List<Film> lista = new List<Film>();
            try
            {
                konekcija.Open();
                komanda.CommandText = "Select * from Film";
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Film f = new Film();
                    f.Id = citac.GetInt32(0);
                    f.Naziv = citac.GetString(1);
                    f.Reziser = citac.GetString(2);
                    f.Godina = citac.GetInt32(3);

                    lista.Add(f);
                }
                citac.Close();
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
            finally { if (konekcija != null) konekcija.Close(); }


        }
        public bool sacuvajFestival(Festival f)
        {

            try
            {
                konekcija.Open();
                transakcija = konekcija.BeginTransaction();
                komanda = new SqlCommand("", konekcija, transakcija);
                komanda.CommandText = "Insert into Festival (FestivalID, Naziv, DatumOd, DatumDo, GradID) " +
                    "values("+f.Id+", '"+f.Naziv+"', '"+f.DatumOd.ToString("dd.MM.yyyy") +"', '"+f.DatumDo.ToString("dd.MM.yyyy") +"', "+f.Grad.Id+")";
                komanda.ExecuteNonQuery();
                foreach(Projekcija pro in f.ListaProjekcija)
                {
                    pro.Id = projekcijaID();
                    komanda.CommandText = "Insert into Projekcija values("+f.Id+", "+pro.Id+", '"+pro.DatumVremeProjekcije.ToString("dd.MM.yyyy HH:mm") +"', "+pro.Film.Id+")";
                    komanda.ExecuteNonQuery();

                }
                transakcija.Commit();
                return true;
            }
            catch (Exception eeee)
            {
                System.Windows.Forms.MessageBox.Show("Sacuvaj  "  +eeee.Message);
                transakcija.Rollback();
                return false;
                throw;
            }
            finally
            {
                if (konekcija != null) konekcija.Close();
            }


        }
        public int projekcijaID()
        {
            try
            {
                try
                {
                    int br = 0;
                   
                    komanda.CommandText = "Select max(ProjekcijaID) from Projekcija";
                    br = (int)komanda.ExecuteScalar();

                    return br + 1;
                }
                catch (Exception)
                {

                    return 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
            


        }
        public List<KlasaZaServer> vratiZaServer()
        {
            List<KlasaZaServer> lista = new List<KlasaZaServer>();
            try
            {
                konekcija.Open();
                komanda.CommandText = "select f.Naziv, f.Reziser,f.Godina, COUNT(p.FilmID)  from Film f join Projekcija p on f.FilmID=p.FilmID group by f.Naziv, f.Reziser,f.Godina";
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    KlasaZaServer k = new KlasaZaServer();
                    k.Naziv = citac.GetString(0);
                    k.Reziser = citac.GetString(1);
                    k.Godina = citac.GetInt32(2);
                    k.BrojProjekcija = citac.GetInt32(3);

                    lista.Add(k);

                }
                citac.Close();
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public List<Festival> vratiFestivale()
        {
            List<Festival> lista = new List<Festival>();
            try
            {

                konekcija.Open();
                komanda.CommandText = "Select * from Festival";
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Festival f = new Festival();
                    f.Id = citac.GetInt32(0);
                    f.Naziv = citac.GetString(1);
                    f.DatumOd = citac.GetDateTime(2);
                    f.DatumDo = citac.GetDateTime(3);
                    f.Grad = new Grad();
                    f.Grad.Id = citac.GetInt32(4);

                    lista.Add(f);

                }
                citac.Close();
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        public List<KlasaZaServer> listaFilterNaziv(string s)
        {
            List<KlasaZaServer> lista = new List<KlasaZaServer>();
            try
            {
                konekcija.Open();
                komanda.CommandText = $"select f.Naziv, f.Reziser,f.Godina, COUNT(p.FilmID)  from Film f join Projekcija p on f.FilmID=p.FilmID where f.Naziv like '{s}%' group by f.Naziv, f.Reziser,f.Godina";
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    KlasaZaServer k = new KlasaZaServer();
                    k.Naziv = citac.GetString(0);
                    k.Reziser = citac.GetString(1);
                    k.Godina = citac.GetInt32(2);
                    k.BrojProjekcija = citac.GetInt32(3);
                    lista.Add(k);
                 }
                citac.Close();
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }

        }

        public List<KlasaZaServer> listaFilterDatum(DateTime datum)
        {
            List<KlasaZaServer> lista = new List<KlasaZaServer>();
            try
            {
                konekcija.Open();
                komanda.CommandText = $"select f.Naziv, f.Reziser,f.Godina, COUNT(p.FilmID)  from Film f join Projekcija p on f.FilmID=p.FilmID where p.DatumVremeProjekcije ='{datum}' group by f.Naziv, f.Reziser,f.Godina";
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    KlasaZaServer k = new KlasaZaServer();
                    k.Naziv = citac.GetString(0);
                    k.Reziser = citac.GetString(1);
                    k.Godina = citac.GetInt32(2);
                    k.BrojProjekcija = citac.GetInt32(3);
                    lista.Add(k);
                }
                citac.Close();
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }

        }

    }
}
