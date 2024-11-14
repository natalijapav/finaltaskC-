namespace APISystem.Entity
{
    public class Uloga
    {
        public int UlogaId { get; set; }
        public string NazivUloge { get; set; }
        //public string UlogaKorisnik { get; set; }
        public ICollection<Korisnik> Korisnici { get; set; } = new List<Korisnik>();

    }
}
