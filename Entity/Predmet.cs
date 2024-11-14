using APSystem.Entity;

namespace APISystem.Entity
{
    public class Predmet
    {
        public int PredmetId { get; set; }
        public string Naziv { get; set; }
        public int ProfesorId { get; set; }
        public int DepartmantId { get; set; }

        public Profesor Profesor { get; set; }
        public Departmant Departmant { get; set; }  

        public ICollection<Student> Studenti { get; set; }



    }
}
