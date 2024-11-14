namespace APISystem.Entity
{
    public class Ocena
    {
        public int OcenaId { get; set; }
        public int StudentId { get; set; }
        public int PredmetId { get; set; }
        public int Vrednost { get; set; }
    }
}