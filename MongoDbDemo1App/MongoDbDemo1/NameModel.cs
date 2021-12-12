// See https://aka.ms/new-console-template for more information
using MongoDB.Bson.Serialization.Attributes;

public class NameModel
{
  public NameModel(string firstName, string lastName)
  {
    FirstName = firstName;
    LastName = lastName;
  }

  [BsonId]
  public Guid Id { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
}
