using APSystem.Entity;

namespace APISystem.Entity
{
    public class Profesor : Osoba
    {
        public int DepartmantId { get; set; }
        public Departmant Departmant { get; set; }

        public ICollection<Predmet> Predmeti { get; set; } 
    }
}
