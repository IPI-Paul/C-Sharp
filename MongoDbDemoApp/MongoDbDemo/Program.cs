using MongoDataAccess.DataAccess;
using MongoDB.Driver;
using MongoDbDemo;
using MongoDataAccess.Models;

DisplayHelp help = new DisplayHelp();
bool repeat = true;
help.show();

while (repeat)
{
  Console.WriteLine(":>");
  var example = Console.ReadLine();
  if (example != null)
  {
    if (example.Equals("tim") | example.Equals("people"))
    {
      string connectionString = "mongodb://127.0.0.1:27017";
      string databaseName = "simple_db";
      string collectionName = "people";

      var client = new MongoClient(connectionString);
      var db = client.GetDatabase(databaseName);
      var collection = db.GetCollection<PersonModel>(collectionName);
      if (example.Equals("tim"))
      {
        var person = new PersonModel { FirstName = "Tim", LastName = "Corey" };

        await collection.InsertOneAsync(person);
      }
      else if (example.Equals("people"))
      {
        var results = await collection.FindAsync(_ => true);

        foreach (var result in results.ToList())
        {
          Console.WriteLine($"{result.Id}: {result.FirstName} {result.LastName}");
        }
      }
    }
    if (example.Contains("chore"))
    {
      ChoreDataAccess db = new ChoreDataAccess();

      if (example.Contains("add tim"))
      {
        await db.CreateUser(new UserModel() { FirstName = " Tim", LastName = "Corey" });
      }
      else if (example.Contains("new"))
      {
        var users = await db.GetAllUsers();

        var chore = new ChoreModel()
        {
          AssignedTo = users.First(),
          ChoreText = "Mow the lawn",
          FrequencyInDays = 7
        };

        await db.CreateChore(chore);
      }
      else if (example.Contains("complete"))
      {
        var chores = await db.GetAllChores();
        var newChore = chores.First();
        newChore.LastCompleted = DateTime.UtcNow;

        await db.CompleteChore(newChore);
      }
    }
    else if (example.Contains("help"))
    {
      help.show();
    }
    else if (example.Contains("exit"))
    {
      repeat = false;
    }
  }
}