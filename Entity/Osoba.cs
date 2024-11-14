namespace APISystem.Entity
{
    public class Osoba
    {
        public int OsobaId { get; set; }
        public string OsobaIme { get; set; }
        public string OsobaPrezime { get; set; }
        public DateOnly GodinaRodjenja { get; set; }
    }
}
