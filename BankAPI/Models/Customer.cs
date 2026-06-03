using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BankAPI.Models;


public class Customer
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string MongoId { get; set; } = "";

    [BsonElement("id")]
    public int Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; } = "";

    [BsonElement("email")]
    public string Email { get; set; } = "";

    [BsonElement("accounts")]
    public List<Account>? Accounts { get; set; }

}