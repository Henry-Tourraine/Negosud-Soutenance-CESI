namespace NegosudAPI.Utils.DAO
{
    public class ApplicationDAO
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
