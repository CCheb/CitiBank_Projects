using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BankAPI.Models;

public class Account
{
    // Need to specify that the element named "id" within the mongo document should match this var
    [BsonElement("id")]
    public int Id { get; set; }
    [BsonElement("accountNumber")]
    public string? AccountNumber { get; set; }
    [BsonElement("balance")]
    public float Balance { get; set; }

}