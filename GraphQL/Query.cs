using GraphQLBooks.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GraphQLBooks.GraphQL
{
    public class Query
    {
        //public List<Book> Books => ReadAllBooks();   

        public List<Magazine> Magazines => ReadMagazines();

        public List<IReadingMaterials> ReadingMaterials => GetReadingMaterials();

        public List<IThings> Things => GetThings();

        private List<Book> ReadAllBooks()
        {
            string fileName = "Database/books.json";
            string jsonString = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<List<Book>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new JsonStringEnumConverter() } })!;
        }

        public List<Book> Books(string nameContains = "")
        {
            var books = ReadAllBooks();
            if (string.IsNullOrWhiteSpace(nameContains))
            {
                return books;
            }


            return books.Where(b => b.Name.Contains(nameContains)).ToList();


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
            readingMaterials.AddRange(ReadAllBooks());
            readingMaterials.AddRange(ReadMagazines());


            return readingMaterials;

        }

        private List<IThings> GetThings()
        {
            var things = new List<IThings>();
            things.AddRange(ReadAllBooks());
            things.AddRange(ReadMagazines());


            return things;

        }
    }
}