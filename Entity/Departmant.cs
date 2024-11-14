using APISystem.Entity;

namespace APSystem.Entity
{
    public class Departmant
    {
        public int DepartmantId { get; set; }
        public string DepartmantIme { get; set; }

        public ICollection<Profesor> Profesori { get; set; } 
        public ICollection<Predmet> Predmeti { get; set; }
    }
}
