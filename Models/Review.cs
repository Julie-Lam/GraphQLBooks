namespace GraphQLBooks.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public DateTime ReviewDate { get; set; }

        public string User { get; set; }
    }
}
