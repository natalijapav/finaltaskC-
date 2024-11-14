namespace APISystem.Entity
{
    public class Student : Osoba
    {
        public string BrojIndeksa { get; set; }
        public string NacinFinansiranja { get; set; } //vezan za entitet finansiranje

        public Finansije Finansije { get; set; }

        public ICollection<Predmet> Predmeti { get; set; }


    }
}
