using GraphQLBooks.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Query
{
    public List<Book> Books => ReadBooks();   

    public List<Magazine> Magazines => ReadMagazines();

    public List<IReadingMaterials> ReadingMaterials => GetReadingMaterials();

    public List<IThings> Things => GetThings(); 

    private List<Book> ReadBooks()  {
        string fileName = "Database/books.json";
        string jsonString = File.ReadAllText(fileName);
        return JsonSerializer.Deserialize<List<Book>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters={new JsonStringEnumConverter()} })!;
    }


    private List<Magazine> ReadMagazines()
    {
        string fileName = "Database/magazines.json";
        string jsonString = File.ReadAllText(fileName);
        return JsonSerializer.Deserialize<List<Magazine>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new JsonStringEnumConverter() } })!;
    }

    private List<IReadingMaterials> GetReadingMaterials()
    {
        var readingMaterials = new List<IReadingMaterials>();
        readingMaterials.AddRange(ReadBooks());
        readingMaterials.AddRange(ReadMagazines());


        return readingMaterials; 

    }

    private List<IThings> GetThings()
    {
        var things = new List<IThings>();
        things.AddRange(ReadBooks());
        things.AddRange(ReadMagazines());


        return things;

    }
}