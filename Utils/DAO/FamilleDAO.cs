namespace NegosudAPI.Utils.DAO
{
    public class FamilleDAO
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public DateTime Mod { get; set; } = DateTime.Now;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
