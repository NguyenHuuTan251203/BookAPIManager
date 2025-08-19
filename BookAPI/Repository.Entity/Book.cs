using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Repository.Entity
{
    public class Book
    {
        [BsonId]
        [BsonGuidRepresentation(MongoDB.Bson.GuidRepresentation.Standard)]
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishedDate { get; set; }
        public List<string>? MyProperty { get; set; }

    }
}
