namespace APISystem.Entity
{
    public class Korisnik
    {
        public int KorisnikId { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }

        public int UlogaId { get; set; }
        public Uloga UlogaKorisnik { get; set; }

    }
}
