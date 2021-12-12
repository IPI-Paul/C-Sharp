// See https://aka.ms/new-console-template for more information
using MongoDB.Bson;
using MongoDB.Driver;

public class MongoCRUD
{
  private IMongoDatabase db;

  public MongoCRUD(string database)
  {
    // MongoClient() connects to local Instance without username or password. Add a connection string for the 3 other types of connection
    var client = new MongoClient();
    db = client.GetDatabase(database);
  }

  public void InsertRecord<T>(string table, T record)
  {
    var collection = db.GetCollection<T>(table);
    collection.InsertOne(record);
  }

  public List<T> LoadNames<T>( string table)
  {
    var collection = db.GetCollection<PersonModel>("Users");
    return collection.Find(new BsonDocument()).ToList().Select(x => new NameModel(x.FirstName, x.LastName)).ToList().Cast<T>().ToList();
  }

  public List<T> LoadRecords<T>(string table)
  {
    var collection = db.GetCollection<T>(table);

    return collection.Find(new BsonDocument()).ToList();
  }

  public T LoadRecordById<T>(string table, Guid id)
  {
    var collection = db.GetCollection<T>(table);
    var filter = Builders<T>.Filter.Eq("Id", id);

    return collection.Find(filter).First();
  }

  public void UpsertRecord<T>(string table, Guid id, T record)
  {
    var collection = db.GetCollection<T>(table);

    var result = collection.ReplaceOne(
      new BsonDocument("_id", id),
      record,
      new UpdateOptions { IsUpsert = true });
  }

  public void DeleteRecord<T>(string table, Guid id)
  {
    var collection = db.GetCollection<T>(table);
    var filter = Builders<T>.Filter.Eq("Id", id);
    collection.DeleteOne(filter);
  }
}