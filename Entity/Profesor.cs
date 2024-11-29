using APSystem.Entity;

namespace APISystem.Entity
{
    public class Profesor : Osoba
    {
        public int DepartmantId { get; set; }
        public string OsobaIme { get; set; }
        public string OsobaPrezime { get; set; }
        public DateOnly GodinaRodjenja { get; set; }

        public Departmant Departmant { get; set; }

        public ICollection<Predmet> Predmeti { get; set; }
    }
}