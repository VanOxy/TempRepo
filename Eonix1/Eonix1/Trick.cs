namespace Data.Models
{
    public class Trick
    {
        public enum TrickType
        {
            Acrobatics,
            Musical
        }

        public string Name { get; set; }
        public TrickType TypeOfTrick { get; set; }
    }
}