namespace GraphQLBooks.Models
{
    public interface IReadingMaterials
    {

        string Name { get; set; }
        BookGenre Genre { get; set; }
    }
}
