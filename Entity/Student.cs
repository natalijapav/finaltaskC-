namespace APISystem.Entity
{
    public class Student : Osoba
    {
        public string BrojIndeksa { get; set; }
        public string NacinFinansiranja { get; set; } //vezan za entitet finansiranje

        public Finansije Finansije { get; set; }

        public string OsobaIme { get; set; }
        public string OsobaPrezime { get; set; }
        public DateOnly GodinaRodjenja { get; set; }

        public ICollection<Predmet> Predmeti { get; set; }


    }
}
